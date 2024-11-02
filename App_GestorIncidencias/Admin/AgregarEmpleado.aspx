<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AgregarEmpleado.aspx.cs" Inherits="App_GestorIncidencias.Admin.AgregarEmpleado" %>
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
            <input type="email" class="form-control" id="inputEmail4">
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
            <input class="form-check-input" type="radio" name="flexRadioDefault" id="chkActivo" checked>
            <label class="form-check-label" for="gridCheck">Activo</label>            
            <input class="form-check-input" type="radio" name="flexRadioDefault" id="chkInactivo">
            <label class="form-check-label" for="gridCheck">Inactivo</label>
          </div>
          <div class="col-12 mt-3">
            <button type="button" class="btn btn-success">Aceptar</button>
            <button type="button" class="btn btn-danger">Cancelar</button>
          </div>
        </form>
       </div>
    </div>
</asp:Content>
