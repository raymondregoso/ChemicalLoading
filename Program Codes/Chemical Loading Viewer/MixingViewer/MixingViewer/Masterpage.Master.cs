using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{

     public partial class Masterpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Login"]!=null)
            {
                Panel1.Visible=true;
                Label2.Text = "Welcome! : "+Session["Login"] as string;
            }
            else
            {
                Panel1.Visible = false;
            }
            Label3.Text = String.Format("Today is: {0:ddd MMM dd,yyyy }", DateTime.Now);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["ID"] = null;
            Session["Login"] = null;
            Response.Redirect("main.aspx");
        }
    }
}