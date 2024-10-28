<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="App_GestorIncidencias.Admin.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1>Menu de administración de Clientes</h1>
        <asp:GridView ID="gvClientes" CssClass="table" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="persona.Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="persona.Apellido" />
                <asp:BoundField HeaderText="Email" DataField="persona.Email" />
                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                <asp:BoundField HeaderText="Fecha Nacimiento" DataField="FechaNacimiento" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false"/>
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            </Columns>
        </asp:GridView>
</asp:Content>
