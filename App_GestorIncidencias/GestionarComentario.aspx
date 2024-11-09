﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="GestionarComentario.aspx.cs" Inherits="App_GestorIncidencias.GestionarComentario" %>

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

    <div class="container mt-5 border rounded pt-3 col-lg-5 col-xxl-5 col-sm-auto">

        <div class="row justify-content-center">

            <div class="row justify-content-center">

                <div class="mb-2 col-4 col-sm-auto col-md-auto">
                    <h2>Comentario</h2>
                </div>


                <div class="mb-3 me-auto">
                    <label for="txtCodIncidencia" class="form-label">Ticket: </label>
                    <asp:TextBox runat="server" ID="txtCodIncidencia" CssClass="form-control" />
                </div>
                <div class="mb-3 me-auto">
                    <label for="txtUsuario" class="form-label">Usuario: </label>
                    <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
                </div>
                <div class="mb-3 me-auto">
                    <label for="txtFecha" class="form-label">Fecha: </label>
                    <asp:TextBox runat="server" ID="txtFecha" dataformatstring="{0:dd/MM/yyyy}" CssClass="form-control" />
                </div>
                <div class="mb-3 me-auto">
                    <label for="txtComentario" class="form-label">Descripción: </label>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="TxtComenatario" CssClass="form-control" />
                </div>

                <% if (band)
                    { %>

                <div class="mb-3 btn-group-lg btn">
                    <asp:Button Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-primary" runat="server"/>
                    <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-primary" OnClick="btnEliminar_Click" runat="server" OnClientClick="return confirm('¿Confirma la eliminación?')" />
                    <asp:Button Text="Cancelar" ID="Cancelar" OnClick="Cancelar_Click"  runat="server" />
                </div>

                <% }
                    else
                    { %>


                <div class="mb-3 btn-group-lg btn">
                <asp:Button Text="Aceptar" ID="BtnAceptar"  CssClass="btn btn-primary" OnClick="BtnAceptar_Click" runat="server" />
                <asp:Button Text="Volver" ID="BtnCancelar" OnClick="BtnCancelar_Click" runat="server" />
                </div>

                <% } %>

            </div>
        </div>
    </div>
</asp:Content>
