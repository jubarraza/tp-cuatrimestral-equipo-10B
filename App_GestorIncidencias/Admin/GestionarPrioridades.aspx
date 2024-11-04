﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="GestionarPrioridades.aspx.cs" Inherits="App_GestorIncidencias.Admin.GestionarPrioridades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 border rounded pt-3 col-lg-5 col-xxl-3 col-sm-auto">

        <div class="row justify-content-center">

            <div class="row justify-content-center">

                <div class="mb-3 col-4 col-sm-auto col-md-auto">
                    <h2>Prioridad</h2>
                </div>
            </div>

            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" ReadOnly="true" MaxLength="50" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="50" />
            </div>

            <div class="mb-3">
                <div class="form-check form-switch form-control-lg ms-1">
                    <input class="form-check-input" type="checkbox" role="switch" id="chkActiva" checked runat="server">
                    <label class="form-check-label" for="chkActiva">Visible</label>
                </div>
            </div>

            <div class="mb-3 btn-group-lg btn">
                <asp:Button Text="Guardar" runat="server" CssClass="btn btn-success" ID="btnAceptar" OnClick="btnAceptar_Click"/>
                <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" ID="btnCancelar" OnClick="btnCancelar_Click"/>
            </div>
        </div>

    </div>

</asp:Content>
