<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PageError.aspx.cs" Inherits="App_GestorIncidencias.PageError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5 border border-dark-subtle rounded pt-3 col-lg-5 col-xxl-3 col-sm-auto">

        <div class="row justify-content-center">

            <asp:Label Text="Error" ID="txtError" runat="server" CssClass="form-label mb-3 col-4 col-sm-auto col-md-auto" />

            <div class="row justify-content-center">
                <img src="https://miro.medium.com/v2/format:webp/0*ZjYSm_q36J4KChdn" class="img-fluid mb-4 mt-2" alt="Error">
            </div>

        </div>

    </div>


</asp:Content>
