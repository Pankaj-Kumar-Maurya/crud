<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrationform.aspx.cs" Inherits="registration.registrationform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                <td>Name :</td>
                <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                    </tr>
                <tr>
                <td>Blood Group</td>
                <td><asp:RadioButtonList ID="rblbg" runat="server" RepeatColumns="4">
                    <asp:ListItem Text="AB" Value="1"></asp:ListItem>
                    <asp:ListItem Text="A" Value="2"></asp:ListItem>
                    <asp:ListItem Text="B" Value="3"></asp:ListItem>
                    <asp:ListItem Text="O" Value="4"></asp:ListItem>

                    </asp:RadioButtonList></td>
                    </tr>
                <tr>
                <td>Qulification :</td>
                <td><asp:DropDownList ID="ddlqli" runat="server">
                    <%--<asp:ListItem Text="--Select" Value="0"></asp:ListItem>
                     <asp:ListItem Text="BCA" Value="1"></asp:ListItem>
                    <asp:ListItem Text="MCA" Value="2"></asp:ListItem>
                    <asp:ListItem Text="B.Tech" Value="3"></asp:ListItem>--%>
                    
                    </asp:DropDownList></td>
                    </tr>
                <tr>
                <td>Country </td>
                <td><asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true">
                   <%--<asp:ListItem Text="--Select" Value="0"></asp:ListItem>
                     <asp:ListItem Text="India" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Japan" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Russia" Value="3"></asp:ListItem>--%>

                    </asp:DropDownList></td>
                    </tr>
                <tr>
                    <td>State </td>
                    <td><asp:DropDownList ID="ddlstate" runat="server">

                        </asp:DropDownList></td>
                </tr>
                <tr>
                <td></td>
                <td><asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" /></td>
                    </tr>
                <tr>
                    <td></td>
                    <td><asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" OnRowCommand="grid_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Form Id">
                                <ItemTemplate>
                                    <%#Eval("id") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Form Name">
                                <ItemTemplate>
                                    <%#Eval("name") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Blood Group">
                                <ItemTemplate>
                                    <%#Eval("bloodgroup").ToString()=="1"?"AB":Eval("bloodgroup").ToString()=="2"?"A":Eval("bloodgroup").ToString()=="3"?"B":"O" %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Qulification">
                                <ItemTemplate>
                                    <%#Eval("qname") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Country">
                                <ItemTemplate>
                                    <%#Eval("cname") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <%#Eval("sname") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="A" CommandArgument='<%#Eval("id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField >
                                <ItemTemplate>
                                    <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        </asp:GridView></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
