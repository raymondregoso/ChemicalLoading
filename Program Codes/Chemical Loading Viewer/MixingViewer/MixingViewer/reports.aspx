<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reports.aspx.cs" Inherits="GSrequest.reports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="scripts/FusionCharts.js"></script>
    <link href="scripts/StyleSheet1.css" rel="stylesheet" />
    <script src="scripts/jquery-1.11.3.min.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             ShowTime();
             ShowDate();
         });
         function ShowTime() {
             var dt = new Date();
             document.getElementById("labelTime").innerHTML = dt.toLocaleTimeString();
             window.setTimeout("ShowTime()", 1000); // Here 1000(milliseconds) means one 1 Sec  
         }

         function ShowDate() {
             var today = new Date();
             today = today.toDateString();
             document.getElementById("labelDate").innerHTML = today;
         }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
        .auto-style2 {
            width: 200px;
        }
    </style>
</head>
<body style="background-color:#F5FFFA">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div  class="header">
            <div class="company_logo">
                <div class="page_title">
                    Mixing Viewer Dashboard
                     <div class="dateTime">
                         <asp:Label ID="labelDate" runat="server"></asp:Label>
                         <asp:Label ID="labelTime" runat="server"></asp:Label>
                     </div>

                </div>
            </div>
            <div class="red_border"></div>
        </div>

        <div>
            <div></div>


            <div style="text-align:center">
            <table class="TableStyle">
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>

                    <td>Please select Machine</td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2">Please select Date Range </td>
                </tr>

                <tr>
                    <td>From: </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txt_from" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_from" />

                    </td>
                </tr>

                <tr>
                    <td>To: </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txt_to" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_to" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="LOAD" OnClick="Button1_Click" CssClass="btn_blue" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style1">
                        <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Maroon"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
            </table>
            </div>


            <div id="div_graph" runat="server" style="text-align: center">
                <asp:Label ID="Label2" runat="server" CssClass="css_div_title"> TOTAL COUNT OF </asp:Label>
                <asp:Label ID="lbl_machine" runat="server" CssClass="css_machine">  </asp:Label>
                <asp:Label ID="Label4" runat="server" CssClass="css_div_title"> Machine </asp:Label>

                <asp:Label ID="Label5" runat="server" CssClass="css_div_title"> from </asp:Label>
                <asp:Label ID="lbl_from" runat="server" CssClass="css_div_title"></asp:Label>
                <asp:Label ID="Label6" runat="server" CssClass="css_div_title"> to </asp:Label>
                <asp:Label ID="lbl_to" runat="server" CssClass="css_div_title"></asp:Label><br />

                <%--<asp:Label ID="Label1" runat="server" CssClass="css_div_title"> SHIFT: </asp:Label>--%>
                <%--<asp:Label ID="lbl_shift" runat="server" CssClass="css_div_title">  </asp:Label>--%>
                <br />



            </div>

            <asp:Literal ID="Literal1" runat="server"></asp:Literal>

            <div style="text-align: center">
                <asp:Label ID="Label7" runat="server" CssClass="css_generated">NOTE: The graph is generated: </asp:Label><br />
                <asp:Label ID="lbl_time" runat="server" CssClass="css_generated">  </asp:Label><br />
            </div>

        </div>
    </form>
</body>
</html>
