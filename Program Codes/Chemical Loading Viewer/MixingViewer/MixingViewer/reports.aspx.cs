using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using InfoSoftGlobal;

namespace GSrequest
{
    public partial class reports : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["connectionMYSQL"].ConnectionString;
        public List<string> _material = new List<string>();
        List<int> _countPerMaterial = new List<int>();
        public DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                div_graph.Visible = false;
                _bindMachine();
            }
        }
        private void _bindMachine()
        {
            using (MySqlConnection con = new MySqlConnection(cs))
            {
                string cquery = "Select distinct(MACHINE_NAME) from output_tbl where MACHINE_NAME is not null";
                MySqlCommand cmd = new MySqlCommand(cquery, con);
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                DropDownList1.DataValueField = "MACHINE_NAME";
                DropDownList1.DataTextField = "MACHINE_NAME";
                DropDownList1.DataSource = rdr;
                DropDownList1.DataBind();
            }
            DropDownList1.Items.Insert(0, new ListItem("<Select Machine Name>", "0"));
            // int lastCountDDL = DropDownList1.Items.Count;
            DropDownList1.Items.Insert(1, new ListItem("All", "1"));
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txt_from.Text == string.Empty || txt_to.Text == string.Empty)
            {
                // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Date range cannot be blank')", true);
                lbl_msg.Text = "Date range cannot be blank";
            }
            else if (DropDownList1.SelectedValue == "0")
            {
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please select machine')", true);
                lbl_msg.Text = "Please select machine name";
            }
            //else if (ddl_shift.SelectedValue == "0")
            //{
            //    //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please select shift')", true);
            //    lbl_msg.Text = "Please select shift";
            //}
            else
            {
                var dt1 = Convert.ToDateTime(txt_from.Text);//.ToString("MM/dd/yyyy");
                var dt2 = Convert.ToDateTime(txt_to.Text);//.ToString("MM/dd/yyyy");
                if (dt1 > dt2)
                {
                    // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Start date is more recent than end date!')", true);
                    lbl_msg.Text = "Start date is more recent than end date!";
                }
                else
                {
                    clearMsg();

                    div_graph.Visible = true;
                    countMachine(txt_from.Text, txt_to.Text);
                    showGraph(
                  "<chart caption='Material_Count' canvasBaseDepth='5' anchorBorderThickness='3' anchorBorderColor='888888'  anchorRadius='5' PYAxisName='Actual Count'>");
                    //lbl_machine.Text = DropDownList1.SelectedItem.Text;
                    lbl_time.Text = DateTime.Now.ToString("MMM dd  yyyy HH:mm:ss tt");
                    lbl_from.Text = dt1.ToShortDateString();
                    lbl_to.Text = dt2.ToShortDateString();
                    //lbl_shift.Text = ddl_shift.SelectedItem.Text;
                    ////clearAll();
                }
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
                // for Article NAMES
                //for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                //{
                for (int col = 0; col < ds.Tables[0].Columns.Count; col++)
                {
                    string article = ds.Tables[0].Rows[0][col].ToString();
                    _data1.Append("<category label='" + article + "' />");
                    _data1.Append("<set value='" + ds.Tables[0].Rows[0][col] + "' />");
                    _data2.Append("<set value='" + ds.Tables[0].Rows[1][col] + "' />");
                }
                //}
                _data1.Append("</categories>");
                _data2.Append("</dataset>");
                _data2.Append("</chart>");

                _data1.Append(_data2);
                Literal1.Text = FusionCharts.RenderChart("Scripts/MSColumn3DLineDY.swf", "", _data1.ToString(), "", "100%", "400", false, true, true);
            }
        }

        int count = 0;
        int xcount = 0;
        public DataSet countMachine(string datefrom,string dateto)
        {
            DataTable dt = new DataTable();

            // NIGHT 
            string ND_from = txt_from.Text;
            string ND_to = txt_to.Text;
            string NT_from = "23:00:00";
            string NT_to = "23:59:59";

            //ALL machine -- ALL shift
            if (DropDownList1.SelectedValue == "1")
            {
                var Vmaterial = AllMaterial._distictMat_all(datefrom, dateto);
                _material = Vmaterial;
            }
            else if(DropDownList1.SelectedValue != "1")
            {
               // var Vmaterial = GSrequest.PerMaterial._distictPerMat_all(datefrom, dateto, DropDownList1.Text);
                //_material = Vmaterial;
            }
            //adding rows in dataTable
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

                //function for counting
                if (DropDownList1.SelectedValue == "1")
                {
                    xcount = AllMaterial._countAll(datefrom, dateto, material);
                    _countPerMaterial.Add(xcount);
                }
                else
                {
                    //count = PerMaterial._countPerMaterial(datefrom, dateto, material, DropDownList1.Text);
                    _countPerMaterial.Add(count);
                }
                dt.Rows[0][b] = Convert.ToString(material);
                dt.Rows[1][b] = _countPerMaterial[b].ToString();
                artNum++;
            }
            dt.TableName = "tbl_CountPerMaterial";
            ds.Tables.Add(dt);

            return ds;
        }
        private void clearMsg()
        {
            lbl_msg.Text = string.Empty;
        }
    }
}