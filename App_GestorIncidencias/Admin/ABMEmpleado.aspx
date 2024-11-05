<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ABMEmpleado.aspx.cs" Inherits="App_GestorIncidencias.Admin.AgregarEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Ingrese los Datos del Empleado</h2>
        <div class="row">
        <form class="row g-3">
          <div class="col-md-6">
            <label for="lblNombre:" class="form-label">Nombre:</label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          <div class="col-md-6">
            <label for="lblApellido" class="form-label">Apellido:</label>
            <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>            
          </div>
          <div class="col-12 mt-2">
            <label for="lblEmail" class="form-label">Email:</label>
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
          </div>
          <div class="col-md-6 mt-2">
            <label for="lblLegajo" class="form-label">Legajo:</label>
            <asp:TextBox ID="txtLegajo" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          <div class="col-md-6 mt-2">
            <label for="ddlTipo" class="form-label">Tipo de Usuario: </label>
            <asp:DropDownList ID="ddlTipoUsuario" CssClass="form-select" runat="server"></asp:DropDownList>
          </div>
          <div class="col-md-6 mt-2">
            <label class="form-label">Fecha de Nacimiento:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="Date" />
          </div>
          <div class="col-md-6 mt-2">
            <label for="lblContraseña" class="form-label">Contraseña</label>
            <asp:TextBox ID="txtContraseña" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          <div class="col-md-6 mt-3">
            <div class="form-check form-check-inline">
                <asp:RadioButton ID="rbActivo" Text=" Activo" Checked="true" GroupName="Activo" runat="server" />
                <asp:RadioButton ID="rbInactivo" Text=" Inactivo" GroupName="Activo" runat="server" />
            </div>
          </div>
          <div class="col-12 mt-3">
            <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-success" runat="server" />
            <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" runat="server" />
          </div>
        </form>
       </div>
    </div>
</asp:Content>
