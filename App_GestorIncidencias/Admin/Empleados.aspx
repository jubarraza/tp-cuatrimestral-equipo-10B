<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="App_GestorIncidencias.Admin.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1>Menu de administración de Empleados</h1>
        <asp:GridView ID="gvEmpleados" CssClass="table" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="persona.Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="persona.Apellido" />
                <asp:BoundField HeaderText="Email" DataField="persona.Email" />
                <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                <asp:BoundField HeaderText="TipoUsuario" DataField="TipoUsuario" />
                <asp:BoundField HeaderText="FechaIngreso" DataField="FechaIngreso" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            </Columns>
        </asp:GridView>
        
    </div>
</asp:Content>
