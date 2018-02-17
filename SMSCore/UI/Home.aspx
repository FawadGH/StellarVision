<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Main5.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SMSCore.UI.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="..\Content\Loader.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
      <h1>
        Abc Module
        <small>Module Description here</small>
      </h1>
      <ol class="breadcrumb">
          
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li> 
        <li><a href="#">Abc Module</a></li> 
        <li class="active">Abc Function</li>

          <%-- whole label will be a single link unless there is a work around for it, if there isn't i prefer the above idea--%>
         <%-- <li><a href="#"><asp:Label ID="Label1" runat="server" CssClass="fa fa-dashboard" Text=" Label > label > label"></asp:Label></a></li>--%>
           
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
      <!-- Default box -->
      <div class="box">
        <div class="box-header with-border">
          <h3 class="box-title">Abc Function</h3>

<%--          <div class="box-tools pull-right">
            <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
              <i class="fa fa-minus"></i></button>
            <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
              <i class="fa fa-times"></i></button>
          </div>--%>
        </div>
        <div class="box-body">

          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="contentSubHeader">

                    </div>
                    <div class="contentMain">
                        <asp:Button ID="btnTest1" runat="server" Text="Button" OnClick="btnTest1_Click" />
                        <asp:Button ID="btnTest2" runat="server" Text="Button" OnClick="btnTest2_Click" />
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </div>
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
        <!-- /.box-body -->
<%--        <div class="box-footer">
          Footer
        </div>--%>
        <!-- /.box-footer-->
      </div>
      <!-- /.box -->
    </section>
    <!-- /.content -->
</asp:Content>
