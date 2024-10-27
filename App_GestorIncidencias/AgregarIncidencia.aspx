<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="AgregarIncidencia.aspx.cs" Inherits="App_GestorIncidencias.AgregarIncidencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCliente" class="form-label">Cliente: </label>
                <asp:TextBox runat="server" ID="txCliente" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Usuario: </label>
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
            </div>           
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" runat="server" />
                <a href="IncidenciaListar.aspx">Cancelar</a> 
            </div>
        </div>


    </div>




</asp:Content>
