<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="App_GestorIncidencias.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;600&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">

    <style>
        #EnlRecupero {
            display: flex;
            justify-content: flex-end;
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



    <%if (Session["usuario"] != null)
        {%>
    <div class="container mt-5 border border-dark-subtle rounded pt-3">

        <div class="row justify-content-center">

            <div class="row justify-content-center">


                <div class="container mt-4">
                    <!-- Fila del título -->
                    <div class="row">
                        <div class="col-12">
                            <asp:Label Text="Inicio de XXX" ID="lblTitulo" runat="server" CssClass="display-5 fw-bold"></asp:Label>
                        </div>
                    </div>

                    <!-- Fila de las cajas -->
                    <div class="row mt-4">
                        <!-- Caja: Abierto -->
                        <div class="col-md-3">
                            <div class="card alert alert-primary text-center border-primary">
                                <div class="card-header fw-bold">Abierto</div>
                                <div class="card-body">
                                    <asp:Label ID="lblAbierto" runat="server" CssClass="display-6 fw-bold d-block mb-3"></asp:Label>
                                    <asp:Button ID="btnAbierto" runat="server" CssClass="btn btn-primary" Text="Ver detalles" OnClick="btnAbierto_Click" />
                                </div>
                            </div>
                        </div>

                        <!-- Caja: Asignado -->
                        <div class="col-md-3">
                            <div class="card alert alert-secondary text-center border-secondary">
                                <div class="card-header fw-bold">Asignado</div>
                                <div class="card-body">
                                    <asp:Label
                                        ID="lblAsignado" runat="server" CssClass="display-6 fw-bold d-block mb-3"></asp:Label>
                                    <asp:Button ID="btnAsignado" runat="server" CssClass="btn btn-secondary" Text="Ver detalles" OnClick="btnAsignado_Click" />
                                </div>
                            </div>
                        </div>

                        <!-- Caja: En Análisis -->
                        <div class="col-md-3">
                            <div class="card alert alert-warning text-center border-warning">
                                <div class="card-header fw-bold">En Análisis</div>
                                <div class="card-body">
                                    <asp:Label ID="lblEnAnalisis" runat="server" CssClass="display-6 fw-bold d-block mb-3"></asp:Label>
                                    <asp:Button ID="btnEnAnalisis" runat="server" CssClass="btn btn-warning" Text="Ver detalles" OnClick="btnEnAnalisis_Click" />
                                </div>
                            </div>
                        </div>

                        <!-- Caja: Resuelto -->
                        <div class="col-md-3">
                            <div class="card alert alert-success text-center border-success">
                                <div class="card-header fw-bold">Resuelto</div>
                                <div class="card-body">
                                    <asp:Label ID="lblResuelto" runat="server" CssClass="display-6 fw-bold d-block mb-3"></asp:Label>
                                    <asp:Button ID="btnResuelto" runat="server" CssClass="btn btn-success" Text="Ver detalles" OnClick="btnResuelto_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="mb-3 btn-group">
                    <asp:Button Text="Ir a mi Perfil" runat="server" ID="btnPerfil" OnClick="btnPerfil_Click" CssClass="btn btn-primary card-img me-1" />
                    <asp:Button Text="Cerrar Sesion" runat="server" ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" CssClass="btn btn-danger card-img" />
                </div>

            </div>

        </div>
    </div>
    <% }
        else
        { %>
    <div class="border border-dark-subtle col-3 container mt-5 pt-3 rounded">
        <div class="row justify-content-center">
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
            <a href="RecuperoPassword.aspx" id="EnlRecupero" cssclass="btn btn-success card-img">Recuperar contraseña</a>
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


