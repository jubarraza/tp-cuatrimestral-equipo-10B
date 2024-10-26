<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="IncidenciaListar.aspx.cs" Inherits="App_GestorIncidencias.IncidenciaListar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:GridView ID="dgvIncidencias" runat="server" DataKeyNames="Id"
        CssClass="table" AutoGenerateColumns="false">

        <Columns>
            <asp:BoundField HeaderText="Ticket" DataField="Id" />
            <asp:BoundField HeaderText="Cliente" DataField="Cliente" />
            <asp:BoundField HeaderText="Usuario" DataField="Usuario" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Estado" DataField="Estado" />
            <asp:BoundField HeaderText="Prioridad" DataField="Prioridad" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
            <asp:BoundField HeaderText="Fecha de Alta" DataField="FechaAlta" />
          <%--< <asp:BoundField HeaderText="FechaBaja" DataField="Fecha de Baja" />
            <asp:BoundField HeaderText="Resolucion" DataField="Resolución" />--%>

        </Columns>


    </asp:GridView>

</asp:Content>
