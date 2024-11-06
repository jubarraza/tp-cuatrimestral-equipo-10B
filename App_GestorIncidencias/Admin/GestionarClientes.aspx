<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="GestionarClientes.aspx.cs" Inherits="App_GestorIncidencias.Admin.GestionarClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .margen {
            margin-top: 1.98rem !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container mt-5">
        <div class="row justify-content-center">

            <!-- Columna izquierda -->
            <div class="col-lg-5 col-md-6 col-sm-12">

                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="50" />
                </div>

                <div class="row mb-3">
                    <div class="col-6">
                        <label for="txtId" class="form-label">Id</label>
                        <asp:TextBox runat="server" ID="txtId" CssClass="form-control" MaxLength="10" Enabled="false" />
                    </div>
                    <div class="col-6">
                        <label for="txtDni" class="form-label">Dni</label>
                        <asp:TextBox runat="server" ID="txtDni" CssClass="form-control" MaxLength="20" />
                    </div>
                </div>

                <div class="mb-3">
                    <label for="txtFechaNac" class="form-label">Fecha Nacimiento</label>
                    <asp:TextBox runat="server" ID="txtFechaNac" TextMode="Date" CssClass="form-control" />
                </div>


            </div>

            <!-- Columna derecha -->
            <div class="col-lg-5 col-md-6 col-sm-12">

                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" MaxLength="50" />
                </div>

                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" MaxLength="80" />
                </div>

                <div class="mb-3">
                    <label for="ddlTelefonos" class="form-label">Telefonos</label>
                    <asp:DropDownList ID="ddlTelefonos" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>

            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-lg-8 col-md-10 col-sm-10">
                <div class="mb-3">
                    <label for="txtDireccion" class="form-label">Direccion</label>
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" Enabled="false" />
                </div>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-1">
                <div class="mb-3">
                    <asp:Button Text="Editar" runat="server" ID="btnEditarDireccion" CssClass="btn btn-primary margen form-control-plaintext" OnClick="btnEditarDireccion_Click" />
                </div>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-1">
                <div class="mb-3">
                    <asp:Button Text="Agregar" runat="server" ID="btnNuevaDireccion" CssClass="btn btn-success margen form-control-plaintext" OnClick="btnNuevaDireccion_Click" />
                </div>
            </div>

        </div>
        <!-- Botones centrados al final del formulario -->

        <div class="row mt-4">
            <div class="col text-center">
                <asp:Button Text="Guardar" ID="btnAceptar" CssClass="btn btn-primary me-2" runat="server" OnClick="btnAceptar_Click" />
                <asp:Button Text="Editar" ID="btnEditar" CssClass="btn btn-success me-2" runat="server" OnClick="btnEditar_Click" />
                <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-secondary" runat="server" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
