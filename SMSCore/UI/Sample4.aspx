<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Main4.Master" AutoEventWireup="true" CodeBehind="Sample4.aspx.cs" Inherits="SMSCore.UI.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="..\Content\Loader.css" />
    <link rel="stylesheet" type="text/css" href="..\Content\contentLayout.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="main">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="contentHeader">
                        <asp:Label ID="Label3" runat="server" Text=">> Sample Page"></asp:Label>
                    </div>
                    <div class="contentSubHeader">

                    </div>
                    <div class="contentMain">
                        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </div>
                    <%--<table>
                        <tr>
                            <td>
                                
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                    </table>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress id="updateProgress" runat="server">
                <ProgressTemplate>
                    <div class="loaderBackDrop">
                        <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="..\img\loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." class="loader" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
</asp:Content>
