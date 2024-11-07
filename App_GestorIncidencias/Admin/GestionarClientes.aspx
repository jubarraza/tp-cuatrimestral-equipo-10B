<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="GestionarClientes.aspx.cs" Inherits="App_GestorIncidencias.Admin.GestionarClientes" %>

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
            btnEliminar.onclick = function () {
                table.deleteRow(row.rowIndex);
            };
            cell2.appendChild(btnEliminar);


        }

        //Para eliminar cuando Editamos Cliente
        function eliminarFila(boton) {
            var fila = boton.parentNode.parentNode;
            fila.parentNode.removeChild(fila);
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

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container mt-5">
        <div class="row justify-content-center">

            <div class="mb-3 col-lg-5 col-md-5 col-sm-12">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="50" />
            </div>

            <div class="mb-3 col-lg-5 col-md-5 col-sm-12">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" MaxLength="50" />
            </div>

            <div class="mb-3 col-lg-2 col-md-2 col-sm-6">
                <label for="txtIdPersona" class="form-label">Id Persona</label>
                <asp:TextBox runat="server" ID="txtIdPersona" CssClass="form-control" MaxLength="10" Enabled="false" />
            </div>

            <div class="mb-3 col-lg-2 col-md-3 col-sm-6">
                <label for="txtDni" class="form-label">Dni</label>
                <asp:TextBox runat="server" ID="txtDni" CssClass="form-control" MaxLength="20" />
            </div>

            <div class="mb-3 col-lg-5 col-md-3 col-sm-12">
                <label for="txtFechaNac" class="form-label">Fecha Nacimiento</label>
                <asp:TextBox runat="server" ID="txtFechaNac" TextMode="Date" CssClass="form-control" />
            </div>

            <div class="mb-3 col-lg-5 col-md-6 col-sm-12">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" MaxLength="80" />
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row mb-3 d-flex">
                        <asp:Panel ID="pnlTelefonos" runat="server">
                            <asp:Table runat="server" ID="tblTelefonos" class="table">
                                <asp:TableHeaderRow>
                                    <asp:TableHeaderCell CssClass="form-label">Teléfono</asp:TableHeaderCell>
                                    <asp:TableHeaderCell></asp:TableHeaderCell>
                                </asp:TableHeaderRow>
                            </asp:Table>
                            <asp:Button ID="btnAgregarTelefono" runat="server" Text="Agregar Teléfono" OnClientClick="agregarTelefono(); return false;" CssClass="btn btn-primary mb-3" />
                        </asp:Panel>
                        <div class="mb-3">
                            <label for="ddlTelefonos" class="form-label">Telefonos</label>
                            <asp:DropDownList ID="ddlTelefonos" CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

        <div class="row mb-3">
            <div class="col-lg-2 col-md-3 col-sm-6">
                <label for="txtIdDireccion" class="form-label">Id Direccion</label>
                <asp:TextBox runat="server" ID="txtIdDireccion" CssClass="form-control" ReadOnly="true" Enabled="false" MaxLength="50" Placeholder="#" />
            </div>

            <div class="mb-3 col-lg-5 col-md-5 col-sm-12">
                <label for="txtCalle" class="form-label">Calle</label>
                <asp:TextBox runat="server" ID="txtCalle" CssClass="form-control" MaxLength="70" Placeholder="Avenida Tortugas" />
            </div>

            <div class="mb-3 col-lg-5 col-md-4 col-sm-12">
                <label for="txtNumero" class="form-label">Numero</label>
                <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" MaxLength="13" Placeholder="123" />
            </div>

            <div class="mb-3 col-lg-4 col-md-6 col-sm-12">
                <label for="txtLocalidad" class="form-label">Localidad</label>
                <asp:TextBox runat="server" ID="txtLocalidad" CssClass="form-control" MaxLength="70" Placeholder="San Martin" />
            </div>

            <div class="mb-3 col-lg-2 col-md-6 col-sm-6">
                <label for="txtCP" class="form-label">Codigo Postal</label>
                <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" MaxLength="20" Placeholder="B1644" />
            </div>
        </div>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row mb-3 d-flex align-items-center">
                    <div class="col-lg-6 col-md-6 col-sm-12">
                        <label for="ddlProvincias" class="form-label">Provincia</label>
                        <asp:DropDownList runat="server" ID="ddlProvincias" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
                    </div>

                    <div class="col-lg-6 col-md-6 col-sm-12">
                        <label for="txtPais" class="form-label">Pais</label>
                        <asp:TextBox runat="server" ID="txtPais" CssClass="form-control" Enabled="false" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>


        <!-- Botones centrados al final del formulario -->

        <div class="row mt-4">
            <div class="col text-center">
                <asp:Button Text="Guardar" ID="btnAceptar" CssClass="btn btn-primary me-2" runat="server" OnClick="btnAceptar_Click" />
                <asp:Button Text="Editar" ID="btnEditar" CssClass="btn btn-success me-2" runat="server" OnClick="btnEditar_Click" />
                <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-secondary" runat="server" OnClick="btnCancelar_Click" />
            </div>
        </div>
    </div>

    <!-- Modal -->
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
</asp:Content>
