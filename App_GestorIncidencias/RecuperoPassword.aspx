﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="RecuperoPassword.aspx.cs" Inherits="App_GestorIncidencias.RecuperoPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <svg xmlns="http://www.w3.org/2000/svg" class="d-none">

  <symbol id="info-fill" viewBox="0 0 16 16">
    <path d="M8 16A8 8 0 1 0 8 0a8 8 0 0 0 0 16zm.93-9.412-1 4.705c-.07.34.029.533.304.533.194 0 .487-.07.686-.246l-.088.416c-.287.346-.92.598-1.465.598-.703 0-1.002-.422-.808-1.319l.738-3.468c.064-.293.006-.399-.287-.47l-.451-.081.082-.381 2.29-.287zM8 5.5a1 1 0 1 1 0-2 1 1 0 0 1 0 2z"/>
  </symbol>
  <symbol id="exclamation-triangle-fill" viewBox="0 0 16 16">
    <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
  </symbol>
</svg>

    <style>
        #ContenedorAlert
        {
            height:30px;

        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5 border rounded pt-3 col-lg-5 col-xxl-3 col-sm-auto">

        <div class="row justify-content-center">

            <div class="row justify-content-center">

                <div class="mb-3 col-4 col-sm-auto col-md-auto">
                    <h2>Recuperar contraseña</h2>
                </div>
            </div>

            <div class="mb-3">
                <label for="txtEmail" class="form-label">Ingrese su Email:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" PlaceHolder="email@gmail.com" MaxLength="50" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="⛔ El campo Email es requerido" CssClass="text-danger" Display="Dynamic" />
            </div>


            <div class="mb-3">
                <asp:Button Text="Enviar" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click" CssClass="btn btn-success card-img" />
            </div>
        </div>


    </div>
    <br />

  <div class="container col-xxl-3">

    <div class="alert alert-danger d-flex align-items-center" role="alert" id="ContenedorAlert">
  <svg class="bi flex-shrink-0 me-2" role="img" aria-label="Danger:" width="25px"><use href="#exclamation-triangle-fill"/></svg>
  <div>
    Mail incorrecto!!!
  </div>
</div>

 </div>

</asp:Content>
