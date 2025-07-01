<%@ Page Title="Viewer" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="application.aspx.cs" Inherits="GSrequest.application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="scripts/FusionCharts.js"></script>
    <script type="text/javascript" src="scripts/jquery-1.11.3.min.js"></script>
    <link href="scripts/StyleSheet1.css" rel="stylesheet" />
    <style type="text/css">
        .content {
            border: 0px;
        }

        .div_menu {
            width: 1000px;
            /*height: 1000px;*/
            background-color: azure;
            box-shadow: 40px 40px 50px 20px #888888;
        }

        .div_content {
            margin: auto;
            position: absolute;
            left: 180px;
            padding: 10px;
            width: 1500px;
            border-radius: 20px;
            background-color: azure;
            box-shadow: 40px 40px 50px 20px #888888;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     
    <div class="div_menu">
        
        <fieldset>
            <legend>New Records Filter Parameters</legend>
            <div>
                <asp:Label ID="Label5" runat="server" Text="Machine Name:&nbsp;"></asp:Label>
                <asp:DropDownList ID="DropDownList2" Height="40px" runat="server" ><asp:ListItem Value ="WCL6">
                        WCL6
                    </asp:ListItem></asp:DropDownList>
                <asp:Label ID="Label6" runat="server" Text="&nbsp;Date:&nbsp;"></asp:Label><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBox3" DefaultView="Months"></ajaxToolkit:CalendarExtender>
                <asp:Label ID="Label7" runat="server" Text="&nbsp;Shift:&nbsp;"></asp:Label>
                <asp:DropDownList ID="DropDownList3"  Height="40px" runat="server">
                    <asp:ListItem Value="All">All</asp:ListItem>
                    <asp:ListItem Value="Day">Day</asp:ListItem>
                    <asp:ListItem Value="Swing">Swing</asp:ListItem>
                    <asp:ListItem Value="Night">Night</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="Button2" runat="server" Text="Dashboard Query" CssClass="redbtn" OnClick="Button2_Click" />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="Button4" runat="server" Text="Export to Excel" CssClass="redbtn" OnClick="Button4_Click" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Button2" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </fieldset>
        <fieldset>
            <legend>New Records Filter Parameters v2</legend>
            <div>
                <asp:Label ID="Label8" runat="server" Text="Column:&nbsp;"></asp:Label>
                <asp:DropDownList ID="DropDownList4" Height="40px" runat="server">
                    <asp:ListItem Value="IDNUM">EE No</asp:ListItem>
                    <asp:ListItem Value="FULLNAME">Last/First Name</asp:ListItem>
                    <asp:ListItem Value="MATERIAL_NO">Article</asp:ListItem>
                    <asp:ListItem Value="TAG_NO">Tag</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                <asp:Button ID="Button5" runat="server" CssClass="redbtn" Text="Search" OnClick="Button5_OnClick" />
            </div>
        </fieldset>
    </div>
    <br />
   
        
    
    <div class="div_content">
        &nbsp;
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="false" GridLines="None" Width="1500px">
            <Columns>
                <asp:BoundField HeaderText="Machine Name" DataField="MACHINE_NAME" SortExpression="MACHINE_NAME" />
                <asp:BoundField HeaderText="Employee No" DataField="IDNUM" SortExpression="IDNUM" />
                <asp:BoundField HeaderText="Employee Name" DataField="FULLNAME" SortExpression="FULLNAME" />
                <%--<asp:BoundField HeaderText="Department" DataField="DEPARTMENT" SortExpression="DEPARTMENT" />--%>
                <asp:BoundField HeaderText="Scanned Date" DataField="STARTDATESCAN" SortExpression="STARTDATESCAN" />
                <asp:BoundField HeaderText="Time Start" DataField="STARTSCAN" SortExpression="STARTSCAN" />
                <asp:BoundField HeaderText="Time Stop" DataField="STOPSCAN" SortExpression="STOPSCAN" />
                <asp:BoundField HeaderText="Chemical No." DataField="MATERIAL_NO" SortExpression="MATERIAL_NO" />
                <asp:BoundField HeaderText="Load Bags" DataField="LOADBAGS" SortExpression="LOADBAGS" />
                <asp:BoundField HeaderText="Load per Kilogram" DataField="LOADPERKG" SortExpression="LOADPERKG" />
                <asp:BoundField HeaderText="Accountable" DataField="ACCOUNTABILITY" SortExpression="ACCOUNTABILITY" />
                <asp:BoundField HeaderText="Tag No." DataField="TAG_NO" SortExpression="MACHINE_NAME" />
                <asp:BoundField HeaderText="Pallet Weight" DataField="WEIGHT" SortExpression="WEIGHT" />
                <asp:BoundField HeaderText="Remaining Pallet Weight" DataField="REM_WT_PALLET" SortExpression="REM_WT_PALLET" />
                <asp:BoundField HeaderText="Total Load Weight" DataField="TOT_ACT_WT" SortExpression="TOT_ACT_WT" />
                <asp:BoundField HeaderText="Total Bags per Pallet" DataField="TOTALBAGPERPALLET" SortExpression="TOTALBAGPERPALLET" />
                <asp:BoundField HeaderText="Expiration Date" DataField="EXPIRED_DATE" SortExpression="MACHINE_NAME" />
                <asp:BoundField HeaderText="System Date" DataField="SYS_DATE_TIME" SortExpression="SYS_DATE_TIME" />
            </Columns>
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
       
         <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
   
</asp:Content>
