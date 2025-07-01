<%@ Page Title="Management" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="management.aspx.cs" Inherits="GSrequest.management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
            .content {
                border: 0px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="MCD_ID" OnRowDataBound="GridView1_OnRowDataBound" OnRowEditing="GridView1_OnRowEditing" OnRowCancelingEdit="GridView1_OnRowCancelingEdit" OnRowUpdating="GridView1_OnRowUpdating" OnRowDeleting="GridView1_OnRowDeleting" EmptyDataText="No records has been added.">
        <Columns>
            <asp:TemplateField HeaderText="Item Id" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("MCD_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Article" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("ITEM_CODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Weight per Pallet" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("WEIGHT_PALLET") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("WEIGHT_PALLET") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Weight per Bag" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("WEIGHT_BAG") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("WEIGHT_BAG") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bags per Pallet" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("BAGS_PALLET") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("BAGS_PALLET") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Requirement" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("REQUIREMENT") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("REQUIREMENT") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Max Load Bag" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("MAX_LOAD_BAG") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("MAX_LOAD_BAG") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Equiv Hrs" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("EQUIV_HRS") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("EQUIV_HRS") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UOM" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("UOM") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("UOM") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Plant" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("PLANT") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>East</asp:ListItem>
                        <asp:ListItem>West</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Max Scan" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("MAX_SCAN") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Eval("MAX_SCAN") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Added By" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("ADDED_BY") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Added Date" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("SYS_DATE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Updated By" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("FULLNAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Updated Date" ItemStyle-Width="150">
                <ItemTemplate>
                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("UPDATED_DATE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
        <tr>
            <td style="width: 150px">Article:<br />
                <asp:TextBox ID="TextBox9" runat="server" Text="0" Width="70" />
            </td>
            <td style="width: 150px">Weight Pallet:<br />
                <asp:TextBox ID="TextBox10" runat="server" Text="0" Width="70" />
            </td>
            <td style="width: 150px">Weight Bag:<br />
                <asp:TextBox ID="TextBox11" runat="server" Text="0" Width="70" />
            </td>
            <td style="width: 150px">Bags Pallet:<br />
                <asp:TextBox ID="TextBox12" runat="server" Text="0" Width="70" />
            </td>
            <td style="width: 150px">Requirement:<br />
                <asp:TextBox ID="TextBox13" runat="server" Text="0" Width="70" />
            </td>
            <td style="width: 150px">Max Load Bag:<br />
                <asp:TextBox ID="TextBox14" runat="server" Text="0" Width="70" />
            </td>
            <td style="width: 150px">Equiv Hrs:<br />
                <asp:TextBox ID="TextBox15" runat="server" Text="0" Width="70" />
            </td>
            <td style="width: 150px">UOM:<br />
                <asp:TextBox ID="TextBox16" runat="server" Text="Kgs" Width="70" />
            </td>
            <td style="width: 150px;">Plant:<br />
                <asp:DropDownList ID="DropDownList2" runat="server" Height="40px">
                    <asp:ListItem>East</asp:ListItem>
                    <asp:ListItem>West</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 150px">Max Scan:<br />
                <asp:TextBox ID="TextBox17" runat="server" Text="0" Width="140" />
            </td>
            <td style="width: 100px">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_OnClick" />
            </td>
        </tr>
    </table>
</asp:Content>
