<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="App_GestorIncidencias.Admin.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1>Menu de administración de Empleados</h1>
        <asp:GridView ID="gvEmpleados" DataKeyNames="Legajo" OnSelectedIndexChanged="gvEmpleados_SelectedIndexChanged" CssClass="table table-striped table-hover" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="persona.Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="persona.Apellido" />
                <asp:BoundField HeaderText="Email" DataField="persona.Email" />
                <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                <asp:BoundField HeaderText="Tipo Usuario" DataField="tipoUsuario.Tipo" />
                <asp:BoundField HeaderText="Fecha Ingreso" DataField="FechaIngreso" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="👈" />
            </Columns>
        </asp:GridView>
    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
      <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success" runat="server" />
      <button type="button" class="btn btn-danger">Eliminar</button>
    </div>
        
    </div>
</asp:Content>
