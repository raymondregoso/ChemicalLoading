using OfficeOpenXml;
using OfficeOpenXml.Style;
using Oracle.ManagedDataAccess.Client;
using ElmorCabalfinExcelLibrary.ExcelExport;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoSoftGlobal;
using MySql.Data.MySqlClient;

namespace GSrequest
{
    public partial class application : System.Web.UI.Page
    {
        string connection = ConfigurationManager.ConnectionStrings["connectionMYSQL"].ToString();
        int count = 0;
        int xcount = 0;
        public List<string> _material = new List<string>();
        List<int> _countPerMaterial = new List<int>();
        private DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Login"] == null)
                {
                    Response.Redirect("main.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] date_add = TextBox3.Text.Split('/');
                string new_add_date = date_add[0] + "/" + ((Convert.ToInt32(date_add[1]) + 1).ToString()) + "/" +
                                      date_add[2];
                string date = "";
                string startHr = string.Empty;
                string endHr = String.Empty;
                if (DropDownList3.SelectedItem.Value == "All")
                {
                    startHr = "07:00:00";
                    endHr = "06:59:59";
                    date = " AND SYS_DATE_TIME BETWEEN '" + TextBox3.Text + " " + startHr +
                           "' AND '" + new_add_date + " " + endHr +
                           "'";
                }
                else if (DropDownList3.SelectedItem.Value == "Day")
                {
                    startHr = "07:00:00";
                    endHr = "14:59:59";
                    date = " AND SYS_DATE_TIME BETWEEN '" + TextBox3.Text + " " + startHr +
                           "' AND '" + TextBox3.Text + " " + endHr +
                           "'";
                }
                else if (DropDownList3.SelectedItem.Value == "Swing")
                {
                    startHr = "15:00:00";
                    endHr = "22:59:59";
                    date = " AND SYS_DATE_TIME BETWEEN '" + TextBox3.Text + " " + startHr +
                           "' AND '" + TextBox3.Text + " " + endHr + "'";

                }
                else
                {
                    startHr = "23:00:00";
                    endHr = "06:59:59";
                    date = " AND SYS_DATE_TIME BETWEEN '" + TextBox3.Text + " " + startHr +
                           "' AND  '" + new_add_date + " " + endHr + "'";
                }

                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    string query = "SELECT * FROM output_tbl WHERE MACHINE_NAME='" +
                                   DropDownList2.SelectedItem.Value + "' " + date +
                                   " ORDER BY TAG_NO ASC, REM_WT_PALLET DESC";
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.Fill(dtclass.dt);
                        GridView1.DataSource = dtclass.dt;
                        GridView1.DataBind();
                    }
                }

                var Vmaterial = PerMaterial._distictPerMat_all(date, DropDownList2.Text);
                _material = Vmaterial;
                _getcount(_material,date);
                string ttest1 = "CHEMICALS USED" + " as of " + TextBox3.Text;
                showGraph("<chart caption = '" + ttest1 + "' canvasBaseDepth = '5' anchorBorderThickness = '3' anchorBorderColor = '888888'  anchorRadius = '5' PYAxisName='Actual Count'>");

            }
            catch
            {
            }
        }

        public DataSet _getcount(List<string> _material,string xdate)
        {
            DataTable dt = new DataTable();

            for (int i = 0; i < 2; i++)
            {
                dt.Rows.Add();
            }

            int artNum = 1; //for headings count
            string material = ""; // declare variable for retrieving each Material

            // filling in your data Table
            for (int b = 0; b < _material.Count; b++)
            {
                dt.Columns.Add("Article_" + artNum); // headings description
                material = _material[b].ToString();

                 count = PerMaterial._countPerMaterial(xdate, material, DropDownList2.Text);
                 _countPerMaterial.Add(count);
                
                dt.Rows[0][b] = Convert.ToString(material);
                dt.Rows[1][b] = _countPerMaterial[b].ToString();
                artNum++;
            }
            dt.TableName = "tbl_CountPerMaterial";
            ds.Tables.Add(dt);

            return ds;
        }

        protected void DumpExcel(OracleCommand _command, string _filename, string _sheetName, string _headingRange)
        {
            OracleConnection _conn = new OracleConnection(connection);
            DataTable _dt = new DataTable();

            try
            {
                OracleDataAdapter _da = new OracleDataAdapter();
                _da.SelectCommand = new OracleCommand();
                _da.SelectCommand = _command;
                _da.Fill(_dt);
            }
            catch (Exception ex)
            {
                //lblMsg.Text = "ERROR: " + ex.Message;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open) _conn.Close();
                _conn.Dispose();
            }

            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(_sheetName);

                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                ws.Cells["A1"].LoadFromDataTable(_dt, true);

                //Format the header for column 1-3
                using (ExcelRange rng = ws.Cells[_headingRange])
                {
                    rng.Style.Font.Bold = true;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(153, 0, 0));  //Set color to dark blue
                    rng.Style.Font.Color.SetColor(Color.White);
                }
                //Write it back to the client
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=" + _filename + ".xlsx");
                Response.BinaryWrite(pck.GetAsByteArray());
                Response.End();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            dtclass.dt.TableName = "ExtractedData";
            ExcelExport excelExport = new ExcelExport();
            excelExport.ExportFromDataTable(Server.MapPath("~/DownloadedExcel/"), Session["ID"].ToString() + "_ExtractedData"  + ".xlsx", dtclass.dt);
        }

        protected void Button5_OnClick(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    string query = "SELECT * FROM output_tbl WHERE " + DropDownList4.SelectedItem.Value + " LIKE @" + DropDownList4.SelectedItem.Value + " ORDER BY TAG_NO ASC, REM_WT_PALLET DESC";
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dtable = new DataTable();
                        adapter.SelectCommand.Parameters.Add("@" + DropDownList4.SelectedItem.Value, "%" + TextBox5.Text + "%");
                        adapter.Fill(dtable);
                        GridView1.DataSource = dtable;
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void showGraph(string chartTitle)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                StringBuilder _data1 = new StringBuilder();
                StringBuilder _data2 = new StringBuilder();
                _data1.Append(chartTitle);
                _data1.Append("<categories>");
                _data2.Append("<dataset seriesName='Article' >");
                for (int col = 0; col < ds.Tables[0].Columns.Count; col++)
                {
                    string article = ds.Tables[0].Rows[0][col].ToString();
                    _data1.Append("<category label='" + article + "' />");
                    _data1.Append("<set value='" + ds.Tables[0].Rows[0][col] + "' />");
                    _data2.Append("<set value='" + ds.Tables[0].Rows[1][col] + "' />");
                }
                _data1.Append("</categories>");
                _data2.Append("</dataset>");
                _data2.Append("</chart>");

                _data1.Append(_data2);
                Literal1.Text = FusionCharts.RenderChart("scripts/MSColumn3DLineDY.swf", "", _data1.ToString(), "", "100%", "400", false, true, true);
            }
        }
    }
}