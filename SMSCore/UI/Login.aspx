<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SMSCore.UI.Login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="sign-in-htm">
        <div class="group">
            <label for="user" class="label">Username</label>
            <%--<input id="user" type="text" class="input" />--%>
            <asp:TextBox ID="tbUserID" runat="server" CssClass="input"></asp:TextBox>
        </div>
        <div class="group">
            <label for="pass" class="label">Password</label>
            <%--<input id="Lpass" type="password" class="input" data-type="password" />--%>
            <asp:TextBox ID="tbPassword" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
        </div>
        <div class="group">
            <input id="check" type="checkbox" class="check" checked="checked" />
            <label for="check"><span class="icon"></span>&nbsp;Keep me Signed in</label>
        </div>
        <div class="group">
            <%--<input type="submit" class="button" value="Sign In" />--%>
            <asp:Button ID="btnLogin" runat="server" Text="Sign In" CssClass="button" OnClick="btnLogin_Click" />
        </div>
        <div class="hr">School Management System - by - PTSS</div>
        <div class="foot-lnk">
            <a class="ForgotPass" href="#forgot">Forgot Password?</a>
        </div>
    </div>

</asp:Content>
