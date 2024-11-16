<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="App_GestorIncidencias.Admin.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

            <ContentTemplate>
                <div class="row">
                        

                    <form class="row g-3">
                        <div class="col-md-6">
                            <label for="lblNombre:" class="form-label">Nombre/s:</label>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ErrorMessage="⛔ El campo Nombre es requerido" CssClass="text-danger" Display="Dynamic" />
                        </div>
                        <div class="col-md-6">
                            <label for="lblApellido" class="form-label">Apellido/s:</label>
                            <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido" ErrorMessage="⛔ El campo Apellido es requerido" CssClass="text-danger" Display="Dynamic" />
                        </div>
                        <div class="col-12 mt-2">
                            <label for="lblEmail" class="form-label">Email:</label>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" Enabled="false"/>                         
                        </div>
                        <div class="col-md-6 mt-2">
                            <label for="lblLegajo" class="form-label">Legajo:</label>
                            <asp:TextBox ID="txtLegajo" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mt-2">
                            <label for="lblTipo" class="form-label">Tipo de Perfil: </label>
                            <asp:TextBox ID="txtTipoUsuario" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mt-2">
                            <label class="form-label">Fecha de Ingreso:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaIngreso" TextMode="Date" Enabled="false"/>                  
                        </div>
                        <div class="col-md-6 mt-2">
                            <label for="lblUserPassword" class="form-label">Contraseña:</label>
                            <asp:TextBox ID="txtUserPassword" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserPassword" ErrorMessage="⛔ El campo Contraseña es requerido" CssClass="text-danger" Display="Dynamic" />
                            <asp:RegularExpressionValidator ControlToValidate="txtUserPassword" ValidationExpression="^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,}$" ErrorMessage="⛔ La contraseña debe contener al menos 6 caracteres, incluir una letra mayúscula y un número" CssClass="text-danger" Display="Dynamic" runat="server" />
                        </div>
                        <div class="col-12 mt-3">
                            <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-success me-md-2" runat="server" />                           
                        </div>
                    </form>
                </div>
            </ContentTemplate>

              
    </div>



</asp:Content>
