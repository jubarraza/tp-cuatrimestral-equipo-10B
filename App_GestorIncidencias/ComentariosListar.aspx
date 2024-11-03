<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ComentariosListar.aspx.cs" Inherits="App_GestorIncidencias.ComentariosListar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <style type="text/css">
       .auto-style1 {
           width: 4096px;
           height: 4096px;
           margin-top: 636px;
       }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <br />


    <asp:GridView ID="dgvComentarios" runat="server" DataKeyNames="Id"
        CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvComentarios_SelectedIndexChanged" >

        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="Ticket" DataField="Cod_Incidencia" />          
            <asp:BoundField HeaderText="Comentario" DataField="ComentarioGestion" />
            <asp:BoundField HeaderText="Fecha de Alta" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}"/>  
            <asp:BoundField HeaderText="Usuario" DataField="Cod_Usuario" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>

    <br />
    <div class="mb-3">
        <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" runat="server" />
    </div>


</asp:Content>
