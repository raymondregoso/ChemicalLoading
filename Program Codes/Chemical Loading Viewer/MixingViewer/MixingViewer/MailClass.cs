using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Net.Mail;


namespace GSrequest
{
    public static class MailClass
    {
        private const string style = @"<style>
                div,table{
                    font-family:Calibri;
                    font-size:14px;
                }
                table{
                    border:1px solid gray;
                    border-collapse:collapse;
                }
                td{
                    border:1px solid silver;
                    padding:2px 8px;
                }
                span{
                    font-size:12px;
                    font-style:italic;
                }
            </style>";
        public static string GetRecipient(string empno)
        {
            var email = "";
            using (var cn = new OracleConnection(ConfigurationManager.ConnectionStrings["YTPIConnection"].ToString()))
            {
                cn.Open();
                using (var cm = new OracleCommand { Connection = cn })
                {
                    cm.CommandText = "select * from barcodeapp.tbl_emp_email where emp_no = '" + empno + "' and lower(eaddress) like '%ytpi.com'";
                    using (var dr = cm.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            email = dr["eaddress"].ToString();
                        }
                    }
                }
            }
            return email;
        }

        public static string getGSmgr()
        {
            var email = "";
            using (var cn = new OracleConnection(ConfigurationManager.ConnectionStrings["YTPIConnection"].ToString()))
            {
                cn.Open();
                using (var cm = new OracleCommand { Connection = cn })
                {
                    cm.CommandText = @"select * from barcodeapp.tbl_emp_email where emp_no = (select emp_no from barcodeapp.hrd_employee1 where section_id= 'GS' and emp_rank = 'SH' and emp_status = 'A') and lower(eaddress) like '%ytpi.com'";
                    using (var dr = cm.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            email = dr["eaddress"].ToString();
                        }
                    }
                }
            }
            return email;
        }

        public static string NewMsg(string ctrl_no, string requestor, string type)
        {
            return msg(ctrl_no, requestor, type, "A new request was made and it needs your approval.");
        }

        public static string ApproveMngrMsg(string ctrl_no, string requestor, string type)
        {
            return msg(ctrl_no, requestor, type, "Your request was approved by your manager.");
        }

        public static string ApproveGSMngrMsg(string ctrl_no, string requestor, string type)
        {
            return msg(ctrl_no, requestor, type, "Your request was approved by the GS manager.");
        }

        public static string DenyMngrMsg(string ctrl_no, string requestor, string type)
        {
            return msg(ctrl_no, requestor, type, "Request has been denied by your manager.");
        }
        public static string DenyGSMngrMsg(string ctrl_no, string requestor, string type)
        {
            return msg(ctrl_no, requestor, type, "Request has been denied by GS manager.");
        }

        public static string AssignMsg(string ctrl_no, string requestor, string type)
        {
            return msg(ctrl_no, requestor, type, "A task has been assigned to you.");
        }
        public static string supplierApprove(string ctrl_no, string requestor, string itemdes, string itemquantity)
        {
            return msgsupplier(ctrl_no, requestor, itemdes, itemquantity, "Your request was approved by Supplier");
        }
        public static string supplierDeny(string ctrl_no, string requestor, string itemdes,string itemquantity)
        {
            return msgsupplier(ctrl_no, requestor, itemdes, itemquantity ,"Your request was denied by Supplier");
        }
        private static string msgsupplier(string ctrl_no, string requestor, string itemdes, string itemquantity, string msgsupplier)
        {
            var emailcontent = style + "<div><p>Dear Sir / Ma’am:</p>";
            emailcontent += "<p>" + msgsupplier + "</p>";
            emailcontent += "<table>";
            emailcontent += "<tr><td>Control No.</td><td>" + ctrl_no + "</td></tr>";
            emailcontent += "<tr><td>Requestor</td><td>" + requestor + "</td></tr>";
            emailcontent += "<tr><td>Item Description</td><td>" + itemdes + "</td></tr>";
            emailcontent += "<tr><td>Quantity</td><td>" + itemquantity + "</td></tr>";
            //emailcontent += "<tr><td>Details</td><td>" + txtdetails.Text + "</td></tr>";
            //emailcontent += "<tr><td>Purpose</td><td>" + txtpurpose.Text + "</td></tr>";
            emailcontent += "</table>";
            emailcontent +=
                "<p>Please login to PRGS ONLINE WORK REQUEST (http://10.79.1.170/prgs_request/) to view the request.</p>";
            emailcontent += "<p>Thank You.</p></div>";
            emailcontent += "<span>Note: This is an autogenerated email. Please don’t reply to this email.</span></div>";

            return emailcontent;
        }

        public static string RequestCompletedMsg(string ctrl_no, string requestor, string type)
        {
            return msg(ctrl_no, requestor, type, "Your request was completed.");
        }

        private static string msg(string ctrl_no, string requestor, string type, string msg)
        {
            var emailcontent = style + "<div><p>Dear Sir / Ma’am:</p>";
            emailcontent += "<p>"+msg+"</p>";
            emailcontent += "<table>";
            emailcontent += "<tr><td>Control No.</td><td>" + ctrl_no + "</td></tr>";
            emailcontent += "<tr><td>Requestor</td><td>" + requestor + "</td></tr>";
            emailcontent += "<tr><td>Type of Job</td><td>" + type + "</td></tr>";
            //emailcontent += "<tr><td>Details</td><td>" + txtdetails.Text + "</td></tr>";
            //emailcontent += "<tr><td>Purpose</td><td>" + txtpurpose.Text + "</td></tr>";
            emailcontent += "</table>";
            emailcontent +=
                "<p>Please login to PRGS ONLINE WORK REQUEST (http://10.79.1.170/prgs_request/) to view the request.</p>";
            emailcontent += "<p>Thank You.</p></div>";
            emailcontent += "<span>Note: This is an autogenerated email. Please don’t reply to this email.</span></div>";

            return emailcontent;
        }

        public static string promptsupplier(string ctrl_no, string requestor, string itemdes, string itemquantity)
        {
            return msgpromptsupplier(ctrl_no, requestor, itemdes, itemquantity, "The request of employee with Employee ID " + requestor + " was approved by GS manager");
        }
        private static string msgpromptsupplier(string ctrl_no, string requestor, string itemdes, string itemquantity, string msgsupplier)
        {
            var emailcontent = style + "<div><p>Dear Sir / Ma’am:</p>";
            emailcontent += "<p>" + msgsupplier + "</p>";
            emailcontent += "<table>";
            emailcontent += "<tr><td>Control No.</td><td>" + ctrl_no + "</td></tr>";
            emailcontent += "<tr><td>Requestor</td><td>" + requestor + "</td></tr>";
            emailcontent += "<tr><td>Item Description</td><td>" + itemdes + "</td></tr>";
            emailcontent += "<tr><td>Quantity</td><td>" + itemquantity + "</td></tr>";
            //emailcontent += "<tr><td>Details</td><td>" + txtdetails.Text + "</td></tr>";
            //emailcontent += "<tr><td>Purpose</td><td>" + txtpurpose.Text + "</td></tr>";
            emailcontent += "</table>";
            emailcontent +=
                "<p>Please login to PRGS ONLINE WORK REQUEST (http://10.79.1.170/prgs_request/) to view the request.</p>";
            emailcontent += "<p>Thank You.</p></div>";
            emailcontent += "<span>Note: This is an autogenerated email. Please don’t reply to this email.</span></div>";

            return emailcontent;
        }

        public static void sendMail(string msg, string _mailTo, string sender, string _decision)
        {
            try
            {
                var mail = new MailMessage { From = new MailAddress("PRGSAutoReply@ytpi.com") };
                mail.To.Add(_mailTo);                                   // _mailTo is your recipient ex. jaymor.lacuesta@ytpi.com
                if (sender != "") mail.CC.Add(sender);
                mail.Subject = "GS Request";                            // put your own email subject here      
                mail.Body = msg;                                        // put body or msg of email here
                mail.IsBodyHtml = true;
                var client = new SmtpClient
                {
                    Host = "10.79.28.115",
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential("testuser@ytpi.com", "1111111")
                };
                client.Send(mail);
            }
            catch (Exception ex)
            {
                //implement your own error handling
            }
        }

        //public static void sendMail(string msg, string _mailTo, string sender, string _decision)
        //{
        //}
    }
}