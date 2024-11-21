<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PageError.aspx.cs" Inherits="App_GestorIncidencias.PageError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .label-large {
            font-size: 1.5rem; /* Ajusta el tamaño según lo que necesites */
        }
        .label-medium {
    font-size: 1.3rem; /* Ajusta el tamaño según lo que necesites */
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5 border border-dark-subtle rounded pt-3 mb-4">

        <div class="justify-content-center row text-lg-center">
            <asp:Label Text="⛔ Se ha producido un error ⛔" CssClass="card-header fw-bold mb-4 label-large" runat="server" />
        </div>

        <div class="row justify-content-center alert alert-danger ms-1 me-1">
            <asp:Label Text="Error" ID="txtError" runat="server" CssClass="form-label mb-3 col-11 label-medium" />
        </div>
    </div>


</asp:Content>
