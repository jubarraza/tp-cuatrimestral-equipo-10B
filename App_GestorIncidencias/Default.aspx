<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="App_GestorIncidencias.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;600&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                                    <h2>Inicio de sesión</h2>
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
                                    <asp:TextBox cssclass="form-control" type="password" ID="txtPassword" placeholder="******" runat="server" MaxLength="50"></asp:TextBox>                   
                                    <button id="btnMostrarPassword" class="btn btn-primary" type="button" onclick="mostrarPassword()"> <span class="fa fa-eye-slash icon"></span> </button>
                                  </div>
                                 </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ErrorMessage="⛔ El campo Contraseña es requerido" CssClass="text-danger" Display="Dynamic" />
                                 <asp:RegularExpressionValidator ControlToValidate="txtPassword" ValidationExpression="^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,}$" ErrorMessage="⛔ La contraseña debe contener al menos 6 caracteres, incluir una letra mayúscula y un número" CssClass="text-danger" Display="Dynamic" runat="server" />
                            </div>

                            <div class="mb-3">
                                <asp:Button Text="Ingresar" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click" CssClass="btn btn-success card-img" />
                            </div>
                        </div>

                    </div>

                  <%}%>

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
        }    }
</script>

    </asp:Content>


