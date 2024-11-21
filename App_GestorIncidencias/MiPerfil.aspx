<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="App_GestorIncidencias.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;600&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">

    <style>
        .margenFoto {
            margin-left: 3.7rem !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container mt-5">
        <div class="row justify-content-center">

            <!-- Columna izquierda -->
            <div class="col-lg-5 col-md-6 col-sm-12 justify-content-center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <asp:Image runat="server" ID="imgPerfil" CssClass="border border-5 mb-4 rounded-5 shadow w-75 margenFoto" />

                        <div class="mb-3 col-11 ms-3">
                            <label for="txtImagenPerfil" class="form-label">Cargar Imagen</label>
                            <input type="file" id="inputImagen" runat="server" class="form-control" />
                            <asp:Label Text="⛔La imagen no debe superar los 15 MB" ID="lblErrorImagen" CssClass="text-danger" runat="server" />
                        </div>
                    </ContentTemplate>
            </asp:UpdatePanel>
                    
            </div>

            <!-- Columna derecha -->
            <div class="col-lg-5 col-md-6 col-sm-12">
                <div class="row mb-3">
                    <div class="col-6">
                        <label for="lblLegajo" class="form-label">Legajo:</label>
                        <asp:TextBox ID="txtLegajo" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="col-6">
                        <label for="lblUserPassword" class="form-label">Contraseña:</label>
                        <div class="modal-body">
                          <div class="input-group mb-3">
                            <asp:TextBox cssclass="form-control" type="password" ID="txtUserPassword" runat="server" MaxLength="20"></asp:TextBox>                   
                            <button id="btnMostrarPassword" class="btn btn-success" type="button" onclick="mostrarPassword()"> <span class="fa fa-eye-slash icon"></span> </button>
                          </div>
                         </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserPassword" ErrorMessage="⛔ El campo Contraseña es requerido" CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ControlToValidate="txtUserPassword" ValidationExpression="^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,}$" ErrorMessage="⛔ La contraseña debe contener al menos 6 caracteres, incluir una letra mayúscula y un número" CssClass="text-danger" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <div class="mb-3">
                    <label for="lblEmail" class="form-label">Email:</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" Enabled="false" />
                </div>

                <div class="mb-3">
                    <label for="lblNombre:" class="form-label">Nombre/s:</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ErrorMessage="⛔ El campo Nombre es requerido" CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ControlToValidate="txtNombre" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]{3,}$" ErrorMessage="⛔ El nombre debe tener al menos 3 letras y no contener números ni símbolos." CssClass="text-danger" Display="Dynamic" runat="server" />
                </div>

                <div class="mb-3">
                    <label for="lblApellido" class="form-label">Apellido/s:</label>
                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido" ErrorMessage="⛔ El campo Apellido es requerido" CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ControlToValidate="txtApellido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]{2,}$" ErrorMessage="⛔ El apellido debe tener al menos 2 letras y no contener números ni símbolos." CssClass="text-danger" Display="Dynamic" runat="server" />
                </div>

                <div class="mb-3">
                    <label for="lblTipo" class="form-label">Rol de Usuario: </label>
                    <asp:TextBox ID="txtTipoUsuario" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label class="form-label">Fecha de Ingreso:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaIngreso" TextMode="Date" Enabled="false" />
                </div>

            </div>
        </div>

        <!-- Botones centrados al final del formulario -->
        <div class="row mt-4">
            <div class="col text-center">
                <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn btn-primary me-2" runat="server" OnClick="btnGuardar_Click" />
                <asp:Button Text="Editar" ID="btnEditar" CssClass="btn btn-success me-2" runat="server" OnClick="btnEditar_Click" CausesValidation="false" />
                <asp:Button Text="Volver" ID="btnCancelar" CssClass="btn btn-secondary" runat="server" OnClick="btnCancelar_Click" CausesValidation="false" />
            </div>
        </div>
    </div>

    <!-- Funcion MostrarPassword -->
<script type="text/javascript">
    function mostrarPassword() {
        var passwordField = document.getElementById('<%= txtUserPassword.ClientID %>'); 
        var icon = document.querySelector('#btnMostrarPassword .icon'); 
        if (passwordField.type === "password") {
            passwordField.type = "text"; 
            icon.classList.remove("fa-eye-slash"); 
            icon.classList.add("fa-eye");
        } else {
            passwordField.type = "password"; 
            icon.classList.remove("fa-eye");
            icon.classList.add("fa-eye-slash"); 
        }
    }
</script>

</asp:Content>
