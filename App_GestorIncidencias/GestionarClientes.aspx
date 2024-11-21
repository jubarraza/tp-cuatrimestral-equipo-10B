<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="GestionarClientes.aspx.cs" Inherits="App_GestorIncidencias.Admin.GestionarClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function agregarTelefono() {
            var table = document.getElementById('<%= tblTelefonos.ClientID %>');
            var row = table.insertRow(-1);
            var cell1 = row.insertCell(0);
            var cell2 = row.insertCell(1);

            // Crear un nuevo TextBox para el número de teléfono
            var txtTelefono = document.createElement("input");
            txtTelefono.type = "text";
            txtTelefono.name = "telefono[]";  // Usa un array para recolectar todos los valores en el backend
            cell1.appendChild(txtTelefono);

            // Botón para eliminar la fila
            var btnEliminar = document.createElement("input");
            btnEliminar.type = "button";
            btnEliminar.value = "Eliminar";
            btnEliminar.className = "btn btn-danger";
            btnEliminar.onclick = function () {
                table.deleteRow(row.rowIndex);
            };
            cell2.appendChild(btnEliminar);


        }
        //modal eliminacion
        function showModal() {
            var myModal = new bootstrap.Modal(document.getElementById('ModalConfirmacion'));
            myModal.show();
        }

        function guardarCommandArgument(numeroTelefono) {
            // Almacena el número en una variable oculta antes de mostrar el modal.
            document.getElementById('<%= hiddenTelefono.ClientID %>').value = numeroTelefono;

            // Muestra el modal.
            var myModal = new bootstrap.Modal(document.getElementById('ModalConfirmacion'));
            myModal.show();
        }

        function showModalEdicion() {
            var myModal = new bootstrap.Modal(document.getElementById('ModalConfirmacionEdicion'));
            myModal.show();
        }

        function cargarTelefonoModal(button) {
            // Capturar valores del botón
            var numeroTelefono = button.getAttribute('data-telefono');
            var idTelefono = button.getAttribute('data-idtelefono');

            // Asignar valores a los controles del modal
            document.getElementById('<%= txtTelefonoEditado.ClientID %>').value = numeroTelefono;
            document.getElementById('<%= hiddenTelefonoEdicion.ClientID %>').value = idTelefono;

            // Mostrar el modal
            var myModal = new bootstrap.Modal(document.getElementById('ModalConfirmacionEdicion'));
            myModal.show();
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container mt-5 border border-dark-subtle rounded">
        <div class="row justify-content-center">

            <div class="mb-4 mt-3 col-4 col-sm-auto col-md-auto">
                <h1>Formulario de Clientes</h1>
            </div>

        </div>
        <div class="row justify-content-center">

            <div class="mb-3 col-lg-5 col-md-5 col-sm-12">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="50" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre" ErrorMessage="⛔ El campo Nombre es requerido" CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator ControlToValidate="txtNombre" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]{3,}$" ErrorMessage="⛔ El nombre debe tener al menos 3 letras y no contener números ni símbolos." CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>

            <div class="mb-3 col-lg-5 col-md-5 col-sm-12">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" MaxLength="50" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellido" ErrorMessage="⛔ El campo Apellido es requerido" CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator ControlToValidate="txtApellido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]{2,}$" ErrorMessage="⛔ El apellido debe tener al menos 2 letras y no contener números ni símbolos." CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>

            <div class="mb-3 col-lg-2 col-md-2 col-sm-6">
                <label for="txtIdPersona" class="form-label">Id Persona</label>
                <asp:TextBox runat="server" ID="txtIdPersona" CssClass="form-control" MaxLength="10" Enabled="false" />
            </div>

            <div class="mb-3 col-lg-5 col-md-3 col-sm-12">
                <label for="txtFechaNac" class="form-label">Fecha Nacimiento</label>
                <asp:TextBox runat="server" ID="txtFechaNac" TextMode="Date" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFechaNac" ErrorMessage="⛔ El campo Fecha de Nacimiento es requerido" CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3 col-lg-5 col-md-6 col-sm-12">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" MaxLength="80" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="⛔ El campo Email es requerido" CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator ControlToValidate="txtEmail" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ErrorMessage="⛔ Ingrese un formato de correo válido" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>

            <div class="mb-3 col-lg-2 col-md-3 col-sm-6">
                <label for="txtDni" class="form-label">Dni</label>
                <asp:TextBox runat="server" ID="txtDni" CssClass="form-control" MaxLength="8" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDni" ErrorMessage="⛔ El campo DNI es requerido" CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator ControlToValidate="txtDni" ValidationExpression="^\d+$" ErrorMessage="⛔ Solo se aceptan numeros" EnableClientScript="true" CssClass="text-danger" Display="Dynamic" runat="server" />

            </div>

            <div class="container p-3 col-4" runat="server">
                <div class="row justify-content-center">
                    <asp:Button Text="Validar DNI" CssClass="btn mt-4 card-img-top btn-success" runat="server" ID="btnValidarDni" OnClick="btnValidarDni_Click" />
                </div>
            </div>


            <div class="container p-3 col-9" id="cont2" runat="server">
                <div class="row justify-content-center alert alert-warning" runat="server" id="boxAlerta">
                    <asp:Label Text="" runat="server" ID="lblValidacionDni" CssClass="form-label text-center p-1" />
                    <asp:Button Text="Editar Cliente" runat="server" ID="btnEditarClienteValidado" OnClick="btnEditarClienteValidado_Click" CssClass="btn btn-warning col-auto me-auto ms-auto" />
                </div>
            </div>

        </div>

        <div class="row">
            <%if (ocultarTelefonoYDireccion == false)
                { %>
            <asp:UpdatePanel runat="server" ID="updRepeater">
                <ContentTemplate>
                    <div class="row mb-3 d-flex justify-content-center">
                        <asp:Repeater ID="repRepetidor" runat="server" OnItemDataBound="repRepetidor_ItemDataBound">
                            <ItemTemplate>
                                <div class="mb-3 col-lg-3 col-md-4 col-sm-6">
                                    <asp:Label ID="lblTelefono" for="txtTelefono" class="form-label" runat="server" />
                                    <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" MaxLength="20" Text='<%#Eval("NumeroTelefono") %>' ReadOnly="true" />
                                    <div class="btn btn-group form-control">
                                        <asp:Button ID="btnEditarTel" runat="server" Text="Editar" CssClass="btn btn-outline-warning carousel-inner" CommandArgument='<%#Eval("IdTelefono") %>' CommandName="TelefonoId" OnClick="btnEditarTel_Click" OnClientClick="cargarTelefonoModal(this); return false;" data-telefono='<%# Eval("NumeroTelefono") %>' data-idtelefono='<%# Eval("IdTelefono") %>' />
                                        <asp:Button ID="btnEliminarTel" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger carousel-inner" CommandArgument='<%#Eval("IdTelefono") %>' CommandName="TelefonoId" OnClick="btnEliminarTel_Click" />
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="row mb-3 d-flex">
                <asp:Panel ID="pnlTelefonos" runat="server">
                    <asp:Table runat="server" ID="tblTelefonos" class="table">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell CssClass="form-label">Agregar Teléfono/s</asp:TableHeaderCell>
                            <asp:TableHeaderCell></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <asp:Button ID="btnAgregarTelefono" runat="server" Text="Agregar Teléfono" OnClientClick="agregarTelefono(); return false;" CssClass="btn btn-primary mb-3" />
                </asp:Panel>


            </div>


        <asp:UpdatePanel runat="server" ID="updDireccion">
            <ContentTemplate>

                <div class="row mb-3">
                    <div class="col-lg-2 col-md-3 col-sm-6">
                        <label for="txtIdDireccion" class="form-label">Id Direccion</label>
                        <asp:TextBox runat="server" ID="txtIdDireccion" CssClass="form-control" ReadOnly="true" Enabled="false" Placeholder="#" />
                    </div>

                    <div class="mb-3 col-lg-5 col-md-5 col-sm-12">
                        <label for="txtCalle" class="form-label">Calle</label>
                        <asp:TextBox runat="server" ID="txtCalle" CssClass="form-control" MaxLength="70" Placeholder="Avenida Tortugas" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCalle" ErrorMessage="⛔ El campo Calle es requerido" CssClass="text-danger" Display="Dynamic" ID="validatorCalle" />
                    </div>

                    <div class="mb-3 col-lg-5 col-md-4 col-sm-12">
                        <label for="txtNumero" class="form-label">Numero</label>
                        <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" MaxLength="13" Placeholder="123" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumero" ErrorMessage="⛔ El campo Numero es requerido. Solo acepta numeros." CssClass="text-danger" Display="Dynamic" ID="validatorNumero" />
                        <asp:RegularExpressionValidator ControlToValidate="txtNumero" ValidationExpression="^\d+$" ErrorMessage="⛔ Ingrese solo numeros" CssClass="text-danger" Display="Dynamic" runat="server" />
                    </div>

                    <div class="mb-3 col-lg-4 col-md-6 col-sm-12">
                        <label for="txtLocalidad" class="form-label">Localidad</label>
                        <asp:TextBox runat="server" ID="txtLocalidad" CssClass="form-control" MaxLength="70" Placeholder="San Martin" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLocalidad" ErrorMessage="⛔ El campo Localidad es requerido" CssClass="text-danger" Display="Dynamic" ID="validatorLocalidad" />
                    </div>

                    <div class="mb-3 col-lg-4 col-md-7 col-sm-6">
                        <label for="txtCP" class="form-label">Codigo Postal</label>
                        <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" MaxLength="20" Placeholder="B1644" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCP" ErrorMessage="⛔ El campo Codigo Postal es requerido" CssClass="text-danger" Display="Dynamic" ID="validatorCP" />
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server" ID="updProvincias">
            <ContentTemplate>
                <div class="row mb-3 d-flex align-items-center">
                    <div class="col-lg-6 col-md-6 col-sm-12">
                        <label for="ddlProvincias" class="form-label">Provincia</label>
                        <asp:DropDownList runat="server" ID="ddlProvincias" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincias_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="col-lg-6 col-md-6 col-sm-12">
                        <label for="txtPais" class="form-label">Pais</label>
                        <asp:TextBox runat="server" ID="txtPais" CssClass="form-control" Enabled="false" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <!-- Botones centrados al final del formulario -->

    <div class="row mt-4">
        <div class="col text-center">
            <asp:Button Text="Guardar" ID="btnAceptar" CssClass="btn btn-primary me-2" runat="server" OnClick="btnAceptar_Click" />
            <asp:Button Text="Editar" ID="btnEditar" CssClass="btn btn-success me-2" runat="server" OnClick="btnEditar_Click" />
            <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-secondary" runat="server" OnClick="btnCancelar_Click" />
        </div>
    </div>



    <% } %>
    </div>


    <!-- Modal Eliminacion-->
    <div class="modal fade" id="ModalConfirmacion" tabindex="-1" aria-labelledby="ModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="ModalLabel">⛔ Eliminar Telefono</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>¿Confirma que desea eliminar el Telefono?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button Text="Eliminar Telefono" CssClass="btn btn-danger" ID="btnEliminarConfirmado" OnClick="btnEliminarConfirmado_Click" runat="server" />
                    <asp:HiddenField ID="hiddenTelefono" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Edicion-->
    <div class="modal fade" id="ModalConfirmacionEdicion" tabindex="-1" aria-labelledby="ModalLabel2" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="ModalLabel2">✏ Editar Telefono</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="input-group mb-3">
                        <asp:TextBox CssClass="form-control" ID="txtTelefonoEditado" runat="server" MaxLength="50" Text='<%#Eval("NumeroTelefono") %>'></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button Text="Editar Telefono" CssClass="btn btn-danger" ID="btnEditarConfirmado" OnClick="btnEditarConfirmado_Click" runat="server" />
                    <asp:HiddenField ID="hiddenTelefonoEdicion" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
