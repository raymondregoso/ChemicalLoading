using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EDI_Authentication;

namespace MixingViewer
{
    public partial class main : System.Web.UI.Page
    {
        List<string> _validemp = new List<string>{"YPH-0065","YPH-0032","YPH-1044","YPH-3497"}; 
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "Viewer")
            {
                EmployeeAuthentication employeeAuthentication = new EmployeeAuthentication(UserTxt.Text,PassTxt.Text.ToUpper());
                if (employeeAuthentication.HasRows == true)
                {
                    Dictionary<string,string> employeeInfo = new Dictionary<string, string>();
                    employeeInfo = employeeAuthentication.EmployeeInfo;

                    Session["Login"] = employeeInfo["LAST_NAME"] + ", " + employeeInfo["FIRST_NAME"] + " " + employeeInfo["MID_NAME"].Substring(0,1) + ".";
                    Session["ID"] = employeeInfo["EMP_NUMBER"];
                    Response.Redirect("application.aspx");
                }
                else
                {
                    Label3.Visible = true;
                    Label3.Text = "Invalid Username or Password";
                }
            }
            else
            {
                EmployeeAuthentication employeeAuthentication = new EmployeeAuthentication(UserTxt.Text, PassTxt.Text.ToUpper());
                if (employeeAuthentication.HasRows == true)
                {
                    Dictionary<string, string> employeeInfo = new Dictionary<string, string>();
                    employeeInfo = employeeAuthentication.EmployeeInfo;

                    Session["Login"] = employeeInfo["LAST_NAME"] + ", " + employeeInfo["FIRST_NAME"] + " " + employeeInfo["MID_NAME"].Substring(0, 1) + ".";
                    Session["ID"] = employeeInfo["EMP_NUMBER"];
                    if (_validemp.Contains(Session["ID"].ToString()))
                    {
                        Response.Redirect("management.aspx");
                    }
                    else
                    {
                        Label3.Visible = true;
                        Label3.Text = "Your Not Authorize to Access this Page! Thanks";
                    }
                }
                else
                {
                    Label3.Visible = true;
                    Label3.Text = "Invalid Username or Password";
                }
            }
        }
        protected void CloseImgBtn_Click(object sender, ImageClickEventArgs e)
        {
            UserTxt.Text = "";
            PassTxt.Text = "";
            Session["sign"] = null;
        }
    }
}