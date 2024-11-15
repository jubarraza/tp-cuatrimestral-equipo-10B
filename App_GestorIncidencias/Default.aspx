<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="App_GestorIncidencias.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5 border rounded pt-3 col-lg-5 col-xxl-3 col-sm-auto">

        <div class="row justify-content-center">

            <div class="row justify-content-center">

                <div class="mb-3 col-4 col-sm-auto col-md-auto">
                    <h2>Inicio de sesión</h2>
                </div>
            </div>

            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" PlaceHolder="email@gmail.com" MaxLength="50" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="⛔ El campo Email es requerido" CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label for="txtPass" class="form-label">Contraseña:</label>
                <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" TextMode="Password" MaxLength="50" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPass" ErrorMessage="⛔ El campo Contraseña es requerido" CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:Button Text="Ingresar" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click" CssClass="btn btn-success card-img" />
            </div>
        </div>

    </div>



</asp:Content>



