<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PageError.aspx.cs" Inherits="App_GestorIncidencias.PageError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5 border border-dark-subtle rounded pt-3 col-lg-5 col-xxl-3 col-sm-auto">

        <div class="row justify-content-center">
            <asp:Label Text="⛔ Se ha producido un error" CssClass="form-title" runat="server" />
        </div>
        <div class="row justify-content-center">
            <asp:Label Text="Error" ID="txtError" runat="server" CssClass="form-label mb-3 col-4 col-sm-auto col-md-auto" />
        </div>
    </div>


</asp:Content>
