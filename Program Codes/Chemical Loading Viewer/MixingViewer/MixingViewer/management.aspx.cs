using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Text;
using UniqueIdGenerator;
using ElmorCabalfinExcelLibrary.ExcelExport;
using MySql.Data.MySqlClient;

namespace GSrequest
{
    public partial class management : System.Web.UI.Page
    {
        private void BindGrid()
        {
            DataTable dt = new DataTable();
            string connection = ConfigurationManager.ConnectionStrings["connectionMYSQL"].ConnectionString;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    string sql = "SELECT T1.*,CONCAT(T2.FIRST_NAME,' ' ,T2.LAST_NAME) AS FULLNAME FROM mixing_chemicals_data T1 LEFT OUTER JOIN hrd_employee1 T2 ON T1.EMP_NO=T2.EMP_NUMBER ORDER BY SYS_DATE ASC";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    {
                        conn.Open();
                        da.Fill(dt);
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string fullname = String.Empty;

                if (!String.IsNullOrEmpty(dt.Rows[i]["ADDED_BY"].ToString()))
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(connection))
                        {
                            string sql =
                                "select CONCAT(FIRST_NAME, ' ' ,LAST_NAME) as fullname from hrd_employee1 where EMP_NUMBER='" +
                                dt.Rows[i]["ADDED_BY"].ToString() + "'";
                            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                            {
                                conn.Open();
                                MySqlDataReader rd = cmd.ExecuteReader();
                                if (rd.Read())
                                {
                                    fullname = rd["fullname"].ToString();
                                }
                                conn.Close();
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally
                    {
                        dt.Rows[i]["ADDED_BY"] = fullname;
                    }
                }
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Session["Login"] == null)
                {
                    Response.Redirect("main.aspx");
                }
                else
                {
                    this.BindGrid();
                }
            }
        }

        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[1].Text;
                foreach (LinkButton button in e.Row.Cells[15].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }

        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void GridView1_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void GridView1_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string mcId = GridView1.DataKeys[e.RowIndex].Values[0].ToString();
            string TextBox1 = (row.FindControl("TextBox1") as TextBox).Text;
            string TextBox2 = (row.FindControl("TextBox2") as TextBox).Text;
            string TextBox3 = (row.FindControl("TextBox3") as TextBox).Text;
            string TextBox4 = (row.FindControl("TextBox4") as TextBox).Text;
            string TextBox5 = (row.FindControl("TextBox5") as TextBox).Text;
            string TextBox6 = (row.FindControl("TextBox6") as TextBox).Text;
            string TextBox7 = (row.FindControl("TextBox7") as TextBox).Text;
            string TextBox8 = (row.FindControl("TextBox8") as TextBox).Text;
            string DropDownList1 = (row.FindControl("DropDownList1") as DropDownList).SelectedItem.Text;

            string connection = ConfigurationManager.ConnectionStrings["connectionMYSQL"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                string sql = "UPDATE mixing_chemicals_data SET WEIGHT_PALLET=@WEIGHT_PALLET,WEIGHT_BAG=@WEIGHT_BAG,BAGS_PALLET=@BAGS_PALLET,REQUIREMENT=@REQUIREMENT,MAX_LOAD_BAG=@MAX_LOAD_BAG,EQUIV_HRS=@EQUIV_HRS,EMP_NO=@EMP_NO,UPDATED_DATE=@UPDATED_DATE,UOM=@UOM,PLANT=@PLANT,MAX_SCAN=@MAX_SCAN WHERE MCD_ID=@MCD_ID";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@WEIGHT_PALLET", TextBox1);
                    cmd.Parameters.AddWithValue("@WEIGHT_BAG", TextBox2);
                    cmd.Parameters.AddWithValue("@BAGS_PALLET", TextBox3);
                    cmd.Parameters.AddWithValue("@REQUIREMENT", TextBox4);
                    cmd.Parameters.AddWithValue("@MAX_LOAD_BAG", TextBox5);
                    cmd.Parameters.AddWithValue("@EQUIV_HRS", TextBox6);
                    cmd.Parameters.AddWithValue("@EMP_NO", Session["ID"].ToString());
                    cmd.Parameters.AddWithValue("@UPDATED_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UOM", TextBox7);
                    cmd.Parameters.AddWithValue("@PLANT", DropDownList1);
                    cmd.Parameters.AddWithValue("@MAX_SCAN", TextBox8);
                    cmd.Parameters.AddWithValue("@MCD_ID", mcId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            GridView1.EditIndex = -1;
            this.BindGrid();
        }

        protected void GridView1_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int mcId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string mcId = (row.FindControl("Label1") as Label).Text;
            string connection = ConfigurationManager.ConnectionStrings["connectionMYSQL"].ConnectionString;

            try
            {
                DataTable dt = new DataTable();

                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    string sql = "SELECT * FROM mixing_chemicals_data WHERE MCD_ID=@MCD_ID";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    {
                        conn.Open();
                        da.SelectCommand.Parameters.AddWithValue("@MCD_ID", mcId);
                        da.Fill(dt);
                        conn.Close();
                    }
                }

                dt.TableName = "DELETED";

                ExcelExport excelExport = new ExcelExport();
                excelExport.ExportFromDataTable(Server.MapPath("~/Deleted/"), Session["ID"].ToString() + "_DELETED" + ".xlsx", dt);

            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    string sql = "DELETE FROM mixing_chemicals_data WHERE MCD_ID=@MCD_ID";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@MCD_ID", mcId);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            this.BindGrid();
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            string connection = ConfigurationManager.ConnectionStrings["connectionMYSQL"].ConnectionString;
            bool hasRows = false;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    string sql = "SELECT * FROM mixing_chemicals_data WHERE ITEM_CODE=@ITEM_CODE AND PLANT=@PLANT";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@ITEM_CODE", TextBox9.Text);
                        cmd.Parameters.AddWithValue("@PLANT", DropDownList2.SelectedItem.Text);
                        MySqlDataReader rd = cmd.ExecuteReader();
                        hasRows = rd.HasRows;
                        rd.Close();
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                if (hasRows == false)
                {
                    GenerateId generateId = new GenerateId("MCD");

                    using (MySqlConnection conn = new MySqlConnection(connection))
                    {
                        string sql =
                            "INSERT INTO mixing_chemicals_data (MCD_ID,ADDED_BY,ITEM_CODE,WEIGHT_PALLET,WEIGHT_BAG,BAGS_PALLET,REQUIREMENT,MAX_LOAD_BAG,EQUIV_HRS,UOM,PLANT,MAX_SCAN) VALUES ('" +
                            generateId.UniqueCode.ToString() + "','" + Session["ID"].ToString() + "','" + TextBox9.Text + "'," +
                            Convert.ToDecimal(TextBox10.Text) + "," + Convert.ToDecimal(TextBox11.Text) + "," +
                            Convert.ToDecimal(TextBox12.Text) + "," + Convert.ToDecimal(TextBox13.Text) + "," +
                            Convert.ToDecimal(TextBox14.Text) + "," + Convert.ToDecimal(TextBox15.Text) + ",'" +
                            TextBox16.Text + "','" + DropDownList2.SelectedItem.Text + "'," +
                            Convert.ToDecimal(TextBox17.Text) + ")";
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }

                    this.BindGrid();
                }
                else
                {
                    string script = "alert(\"Already in the database!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                       "ServerControlScript", script, true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}