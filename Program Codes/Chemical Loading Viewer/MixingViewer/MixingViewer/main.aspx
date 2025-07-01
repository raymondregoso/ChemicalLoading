<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="MixingViewer.main" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .watermarked {
            background-color: #F0F8FF;
            color: gray;
        }

        .auto-style2 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table class="auto-style2">
        <tr>
            <td>
                <table class="auto-style2">
                    <tr>
                        <td>
                            <table class="auto-style2">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="Select to the following:"></asp:Label>
                                        <br />
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/arrow.gif" Width="35px" />
                                        <asp:DropDownList ID="DropDownList1" runat="server" Height="40px" Font-Size="Large" Font-Names="Tahoma">
                                            <asp:ListItem>Management</asp:ListItem>
                                            <asp:ListItem>Viewer</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="UserTxt" Display="Dynamic" ForeColor="Red" ValidationExpression="(^([0-9]*\d*\d{1}?\d*)$)">*</asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserTxt" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <span style="color: rgb(85, 85, 85); font-family: 'segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">Employee ID#:</span><asp:TextBox ID="UserTxt" runat="server" MaxLength="4" Height="28px" Width="170px"></asp:TextBox>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="UserTxt_TextBoxWatermarkExtender" runat="server" TargetControlID="UserTxt" WatermarkCssClass="watermarked" WatermarkText="(ex. 9999)">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                        <br />
                                        <asp:Label ID="Label3" runat="server" CssClass="error" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PassTxt" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <span style="color: rgba(85, 85, 85,1); font-family: 'segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">Password:</span><asp:TextBox ID="PassTxt" runat="server" TextMode="Password" Height="41px" Width="170px"></asp:TextBox>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="PassTxt_TextBoxWatermarkExtender" runat="server" TargetControlID="PassTxt" WatermarkCssClass="watermarked" WatermarkText="••••••">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                    </td>
                                    <td>
                                        <asp:Button ID="LoginBtn" runat="server" CssClass="redbtn" OnClick="LoginBtn_Click" Text="Login" />
                                    </td>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="Label4" runat="server" Font-Size="X-Large" ForeColor="Red" Text="Label" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="965" height="330">
        <param name="movie" value="http://erp/banner/banner.swf">
        <param name="quality" value="high">
        <embed src="http://erp/banner/banner.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="965" height="330">
    </object>

</asp:Content>
