<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="GestionarComentario.aspx.cs" Inherits="App_GestorIncidencias.GestionarComentario" %>

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

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtCodIncidencia" class="form-label">Ticket: </label>
                <asp:TextBox runat="server" ID="txtCodIncidencia" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Usuario: </label>
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtFecha" class="form-label" DataFormatString="{0:dd/MM/yyyy}">Fecha: </label>
                <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtComentario" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="TxtComenatario" CssClass="form-control" />
            </div>
        </div>
    </div>
     <br />
 <div class="mb-3">
     <asp:Button Text="Agregar" ID="btnActualizar"  OnClick="btnActualizar_Click" CssClass="btn btn-primary" runat="server" /> 
     <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-primary" OnClick="btnEliminar_Click" runat="server" /> 
     <a href="IncidenciaListar.aspx">Volver</a>
 </div>
</asp:Content>
