<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="App_GestorIncidencias.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;600&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">

    <style>
        #EnlRecupero
        {
            display:flex;
            justify-content:flex-end;
        }
    </style>
    <script>
        function showModal() {
            var myModal = new bootstrap.Modal(document.getElementById('ModalConfirmacion'));
            myModal.show();
        }
    </script>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <div class="container mt-5 border rounded pt-3 col-lg-5 col-xxl-3 col-sm-auto">

        <div class="row justify-content-center">

            <div class="row justify-content-center">

                <%if (Session["usuario"] != null)
                    {%>
                <div class="mb-3 col-3 col-sm-auto col-md-auto">
                    <asp:Label Text="USUARIO" ID="lblUsuarioLogueado" runat="server" />
                </div>

                <div class="mb-3 btn-group">
                    <asp:Button Text="Ir a mi Perfil" runat="server" ID="btnPerfil" OnClick="btnPerfil_Click" CssClass="btn btn-primary card-img me-1" />
                    <asp:Button Text="Cerrar Sesion" runat="server" ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" CssClass="btn btn-danger card-img" />
                </div>
                <% }
                    else
                    { %>
                <div class="mb-3 col-4 col-sm-auto col-md-auto">
                    <h6>Inicio de sesión</h6>
                </div>
            </div>

            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" PlaceHolder="email@gmail.com" MaxLength="50" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="⛔ El campo Email es requerido" CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label for="lblPassword" class="form-label">Contraseña:</label>
                <div class="modal-body">
                    <div class="input-group mb-3">
                        <asp:TextBox CssClass="form-control" type="password" ID="txtPassword" placeholder="******" runat="server" MaxLength="50"></asp:TextBox>
                        <button id="btnMostrarPassword" class="btn btn-success" type="button" onclick="mostrarPassword()"><span class="fa fa-eye-slash icon"></span></button>
                    </div>
                </div>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ErrorMessage="⛔ El campo Contraseña es requerido" CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:Button Text="Ingresar" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click" CssClass="btn btn-success card-img" />
            </div>
            <div class="mb-3">
                <a href="RecuperoPassword.aspx" Id="EnlRecupero" cssclass="btn btn-success card-img">Recuperar contraseña</a>
            </div>
        </div>

    </div>

    <%}%>

            <!-- Modal -->
<div class="modal fade" id="ModalConfirmacion" tabindex="-1" aria-labelledby="ModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h1 class="modal-title fs-5" id="ModalLabel">⛔ Error de Inicio de Sesión</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <p>La contraseña o el usuario ingresado no coinciden con ningun usuario activo.</p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Aceptar</button>
            </div>
        </div>
    </div>
</div>


    <script type="text/javascript">

        function mostrarPassword() {
            var passwordField = document.getElementById('<%= txtPassword.ClientID %>');
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


