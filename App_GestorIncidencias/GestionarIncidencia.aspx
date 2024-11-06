﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="GestionarIncidencia.aspx.cs" Inherits="App_GestorIncidencias.GestionarIncidencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Ticket</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCliente" class="form-label">Cliente: </label>
                <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Usuario: </label>
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="TxtDescripcion" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlPrioridad" class="form-label">Prioridad: </label>
                <asp:DropDownList runat="server" ID="ddlPrioridad" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlEstado" class="form-label">Estado: </label>
                <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" runat="server" />
                <a href="IncidenciaListar.aspx">Cancelar</a>
            </div>
        </div>


    </div>
    <br />

    <div>
    <asp:GridView ID="dgvComentarios" runat="server" OnSelectedIndexChanged="dgvComentarios_SelectedIndexChanged" DataKeyNames="Cod_Incidencia" CssClass="table" AutoGenerateColumns="false">

        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="Ticket" DataField="Cod_Incidencia" />
            <asp:BoundField HeaderText="Comentario" DataField="ComentarioGestion" />
            <asp:BoundField HeaderText="Fecha de Alta" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField HeaderText="Usuario" DataField="Cod_Usuario" />
            <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>

    <br />
    </div>




</asp:Content>
