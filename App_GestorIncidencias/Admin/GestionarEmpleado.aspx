<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="GestionarEmpleado.aspx.cs" Inherits="App_GestorIncidencias.Admin.GestionarEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;400;600&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">

    <script>
        function showModal() {
            var myModal = new bootstrap.Modal(document.getElementById('ModalConfirmacion'));
            myModal.show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <div class="container mt-5 border border-black rounded">
        <div class="row justify-content-center">
            <%if (Request.QueryString["Legajo"] != null)
                {%>
            <h2 class="mt-3 mb-3 text-center">Modifique los Datos del Empleado</h2>
            <% }
                else
                { %>
            <h2 class="mt-3 mb-3 text-center">Ingrese los Datos del Empleado</h2>
            <%}%>
        </div>


        <asp:UpdatePanel ID="UpDatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <form class="row g-2">
<%--                        <div class="col-md-4">
                         <asp:Image runat="server" ID="imgPerfil" CssClass="border border-5 ms-2 mb-4 rounded-5 shadow w-50 margenFoto" />
                        </div>--%>
                        <div class="col-md-6">
                            <label for="lblNombre:" class="form-label">Nombre/s:</label>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ErrorMessage="⛔ El campo Nombre es requerido" CssClass="text-danger" Display="Dynamic" />
                            <asp:RegularExpressionValidator ControlToValidate="txtNombre" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]{3,}$" ErrorMessage="⛔ El nombre debe tener al menos 3 letras y no contener números ni símbolos." CssClass="text-danger" Display="Dynamic" runat="server" />
                        </div>
                        <div class="col-md-6">
                            <label for="lblApellido" class="form-label">Apellido/s:</label>
                            <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido" ErrorMessage="⛔ El campo Apellido es requerido" CssClass="text-danger" Display="Dynamic" />
                            <asp:RegularExpressionValidator ControlToValidate="txtApellido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]{2,}$" ErrorMessage="⛔ El apellido debe tener al menos 2 letras y no contener números ni símbolos." CssClass="text-danger" Display="Dynamic" runat="server" />
                        </div>
                        <div class="col-12 mt-2">
                            <label for="lblEmail" class="form-label">Email:</label>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" MaxLength="80" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="⛔ El campo Email es requerido" CssClass="text-danger" Display="Dynamic" />
                            <asp:RegularExpressionValidator ControlToValidate="txtEmail" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ErrorMessage="⛔ Ingrese un formato de correo válido" CssClass="text-danger" Display="Dynamic" runat="server" />
                        </div>
                        <div class="col-md-6 mt-2">
                            <label for="lblLegajo" class="form-label">Legajo:</label>
                            <asp:TextBox ID="txtLegajo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mt-2">
                            <label for="ddlTipo" class="form-label">Tipo de Usuario: </label>
                            <asp:DropDownList ID="ddlTipoUsuario" CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md-6 mt-2">
                            <label class="form-label">Fecha de Ingreso:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaIngreso" TextMode="Date" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFechaIngreso" ErrorMessage="⛔ El campo Fecha de Ingreso es requerido" CssClass="text-danger" Display="Dynamic" />
                        </div>
                        <div class="col-md-6 mt-2">
                            <label for="lblUserPassword" class="form-label">Contraseña:</label>
                            <div class="modal-body">
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="txtUserPassword" CssClass="form-control" type="password" runat="server" MaxLength="20"></asp:TextBox>
                                    <button id="MostrarPassword" class="btn btn-primary" type="button" onclick="mostrarPassword()" causesvalidation="false"><span class="fa fa-eye-slash icon"></span></button>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserPassword" ErrorMessage="⛔ El campo Contraseña es requerido" CssClass="text-danger" Display="Dynamic" />
                                <asp:RegularExpressionValidator ControlToValidate="txtUserPassword" ValidationExpression="^(?=.*[A-ZÁÉÍÓÚÜÑ])(?=.*\d)[A-Za-zÁÉÍÓÚÜÑáéíóúüñ\d]{6,}$" ErrorMessage="⛔ La contraseña debe contener al menos 6 caracteres, incluir una letra mayúscula y un número. No se aceptan simbolos. " CssClass="text-danger" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                        <div class="col-md-6 mt-3">
                            <div class="form-check form-check-inline me-md-2">
                                <asp:RadioButton AutoPostBack="true" ID="rbActivo" Text=" Activo" OnCheckedChanged="rbActivo_CheckedChanged" GroupName="Activo" runat="server" />
                                <asp:RadioButton AutoPostBack="true" ID="rbInactivo" Text=" Inactivo" OnCheckedChanged="rbActivo_CheckedChanged" GroupName="Activo" runat="server" />
                                <asp:Label ID="lblSeleccion" Text="👈 Debe seleccionar una opción" CssClass="text-danger me-md-2" Visible="false" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6 mt-3">
                            <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" Text="Aceptar" CssClass="btn btn-success me-md-2" runat="server" />
                            <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" AutoPostBack="true" CausesValidation="false" CssClass="btn btn-secondary me-md-2" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-outline-danger me-md-2" runat="server" />
                            <div class=" mt-3 d-flex">
                                <asp:Label ID="lblEliminar" AutoPostBack="true" Text="⚠️ El empleado debe estar activo para su eliminación." CssClass="alert alert-info text-center" Visible="false" runat="server"></asp:Label>
                                <asp:Label ID="lblInactivo" AutoPostBack="true" Text="⚠️ No se puede Desactivar o Eliminar el empleado, por que contiene incidencias sin resolver." CssClass="alert alert-info text-center" Visible="false" runat="server"></asp:Label>
                            </div>
                        </div>

                    </form>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <!-- Modal Eliminacion-->
<div class="modal fade" id="ModalConfirmacion" tabindex="-1" aria-labelledby="ModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h1 class="modal-title fs-5" id="ModalLabel">⛔ Eliminar Empleado</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body text-center">
                <h6>¿Confirma la eliminación del empleado?</h6>
            </div>
            <div class="modal-footer">
                <asp:Button Text="Si ✔️" CssClass="btn btn-success" ID="btnEliminarConfirmado" OnClick="btnEliminarConfirmado_Click" runat="server" />
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">No ❌</button>                
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    function mostrarPassword() {
        var passwordField = document.getElementById('<%= txtUserPassword.ClientID %>');
        var icon = document.querySelector('#MostrarPassword .icon');
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
