<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="GestionarIncidencia.aspx.cs" Inherits="App_GestorIncidencias.GestionarIncidencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .alturaDesc {
            height: 350px;
        }

        .gridSelector a {
            text-decoration: none;
            color: black;
        }

            .gridSelector a:hover {
                text-decoration: underline;
                color: blue;
            }

        .boton {
            margin-top: 2.0rem !important;
        }
    </style>
    <script type="text/javascript">
        function showModal() {
            var myModal = new bootstrap.Modal(document.getElementById('ModalConfirmacion'));
            myModal.show();
        }
        function showModalResolucion() {
            var myModal = new bootstrap.Modal(document.getElementById('ModalResolucion'), {
                keyboard: false
            });
            myModal.show();
        }
        function showModalCierre() {
            var myModal = new bootstrap.Modal(document.getElementById('ModalCierre'), {
                keyboard: false
            });
            myModal.show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

    <div class="p-4 mt-2">

        <div class="row justify-content-center">

            <div class="row">
                <div class="mb-4 col-4 col-sm-auto col-md-auto">
                    <h2>Incidencia</h2>
                </div>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
            <div class="row flex-fill">
                <div class="col-md-2 mb-3 me-auto ms-0 col-sm-5">
                    <label for="txtId" class="form-label">Ticket</label>
                    <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                </div>

                <div class="mb-3 col-sm-7 col-md-4 me-auto">
                    <label for="ddlEstado" class="form-label">Estado: </label>
                    <asp:DropDownList runat="server" ID="ddlEstado" Enabled="false" CssClass="form-control text-center alert alert-warning"></asp:DropDownList>
                </div>

                <div class="col-md-2 col-sm-6 mb-4">
                    <div class="btn-group-lg card gap-3 mb-3" id="botonesCierre" runat="server">
                        <asp:Button Text="Resolver" CssClass="btn btn-success" runat="server" ID="btnResolverIncidencia" OnClientClick="showModalResolucion(); return false;" />
                        <asp:Button Text="Cerrar" CssClass="btn btn-secondary" runat="server" ID="btnCerrarIncidencia" OnClientClick="showModalCierre(); return false;" />
                    </div>
                </div>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="row flex">
                <div class="container col-3 border border-dark-subtle rounded p-2">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="mb-3 me-auto col-8">
                                    <label for="txtDniCliente" class="form-label">Dni Cliente: </label>
                                    <asp:TextBox runat="server" ID="txtDniCliente" CssClass="form-control" OnTextChanged="txtDniCliente_TextChanged" AutoPostBack="true" />
                                    <asp:Label Text="⛔ El campo DNI es requerido" runat="server" Visible="false" ID="lblValidacionDniRequerido" CssClass="text-danger" />
                                    <asp:Label Text="⛔ Solo se aceptan numeros" runat="server" Visible="false" ID="lblValidacionNumero" CssClass="text-danger" />
                                </div>

                                <div class="mb-3 me-auto col-4">
                                    <asp:Button Text="Cambiar" runat="server" ID="btnCambiarCliente" OnClick="btnCambiarCliente_Click" CssClass="btn btn-warning boton form-control text-center" />
                                </div>
                            </div>

                            <div class="mb-3 me-auto">
                                <label for="txtCliente" class="form-label">Nombre Completo: </label>
                                <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" />
                            </div>
                            <div class="mb-3 me-auto">
                                <asp:Repeater ID="repRepetidor" runat="server" OnItemDataBound="repRepetidor_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="mb-3">
                                            <asp:Label ID="lblTelefono" for="txtTelefono" class="form-label" runat="server" />
                                            <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" MaxLength="20" Text='<%#Eval("NumeroTelefono") %>' ReadOnly="true" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="mb-3 me-auto">
                                <label for="txtEmail" class="form-label">Email: </label>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                            </div>
                            <div class="mb-3 me-auto">
                                <label for="txtDireccion" class="form-label">Direccion: </label>
                                <asp:TextBox runat="server" ID="txtDireccion" TextMode="MultiLine" CssClass="form-control" />
                            </div>
                            <div class="mb-3 me-auto">
                                <asp:Button Text="Editar Cliente Actual" runat="server" CssClass="btn btn-outline-primary" ID="btnEditarCliente" OnClick="btnEditarCliente_Click" />
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="container col-5 p-2">
                    <div class="mb-3 me-auto ">
                        <label for="txtDescripcion" class="form-label">Descripción: </label>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="TxtDescripcion" CssClass="form-control alturaDesc" MaxLength="1000" />
                        <asp:Label Text="⛔ El campo Descripción es requerido" runat="server" Visible="false" ID="lblValidacionDescripcion" CssClass="text-danger" />
                    </div>

                </div>

                <div class="container col-3 p-2 border border-dark-subtle rounded mb-3">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="mb-3 me-auto">
                                <label for="txtLegajoEmpleado" class="form-label">Usuario asignado: </label>
                                <asp:DropDownList runat="server" ID="ddlUsuario" CssClass="form-select"></asp:DropDownList>
                            </div>
                            <div class="mb-3 me-auto">
                                <asp:Button Text="Reasignar" ID="btnReasignar" CssClass="btn btn-warning" Visible="false" OnClick="btnReasignar_Click" runat="server" />
                                <asp:Button Text="Guardar" ID="btnGuardarIncidencia" CssClass="btn btn-success" Visible="false" OnClick="btnGuardarIncidencia_Click" runat="server" />
                                <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-secondary" Visible="false" OnClick="btnCancelar_Click" runat="server" />
                            </div>

                            <div class="mb-3 me-auto">
                                <label for="ddlTipoIncidencia" class="form-label">Tipo Incidencia: </label>
                                <asp:DropDownList runat="server" ID="ddlTipoIncidencia" CssClass="form-select"></asp:DropDownList>
                            </div>

                            <div class="mb-3 me-auto">
                                <label for="ddlPrioridad" class="form-label">Prioridad: </label>
                                <asp:DropDownList runat="server" ID="ddlPrioridad" CssClass="form-select"></asp:DropDownList>
                            </div>

                            <div class="mb-3 me-auto">
                                <label for="txtFechaReclamo" class="form-label">Fecha Reclamo: </label>
                                <asp:TextBox runat="server" ID="txtFechaReclamo" TextMode="Date" CssClass="form-control" />
                            </div>


                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>

            <div class="row mt-5">
                <div class="mb-3 btn-group-lg btn">
                    <asp:Button Text="Guardar" ID="btnAceptar" CssClass="btn btn-success" runat="server" OnClick="btnAceptar_Click" />
                    <asp:Button Text="Editar" ID="btnEditar" CssClass="btn btn-warning" runat="server" OnClick="btnEditar_Click" />
                    <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-secondary" runat="server" OnClick="btnVolver_Click" />
                </div>
            </div>

        </div>

        <div class="container" id="contComentarios" runat="server">
            <div class="row justify-content-center mt-3 me-4">

                <div class="border rounded p-3">
                    <div class="row justify-content-start mt-1">
                        <div class="mb-2 col-4 col-sm-auto col-md-auto">
                            <h4>Comentarios</h4>
                        </div>
                    </div>

                    <asp:GridView ID="dgvComentarios" runat="server" OnSelectedIndexChanged="dgvComentarios_SelectedIndexChanged" DataKeyNames="Id" CssClass="table gridSelector transparent-grid border-dark-subtle" AutoGenerateColumns="false">

                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" />
                            <asp:BoundField HeaderText="Ticket" DataField="Cod_Incidencia" />
                            <asp:BoundField HeaderText="Comentario" DataField="ComentarioGestion" />
                            <asp:BoundField HeaderText="Fecha de Alta" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField HeaderText="Usuario" DataField="Usuario" />
                            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Ver🔍" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="mt-3 form-check-reverse">
                    <asp:Button Text="Nuevo Comentario" ID="BtnComentar" CssClass="btn btn-primary" runat="server" OnClick="BtnComentar_Click" />
                </div>

            </div>
        </div>

    </div>

 <!-- Modal Resolucion -->
<div class="modal fade" id="ModalResolucion" data-bs-backdrop="static" tabindex="-1" aria-labelledby="ModalLabelResolucion" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="lblModalResolucion">Resolución! 👏</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
          <div class="mb-3">
            <label for="message-text" class="col-form-label">Comentario:</label>
            <asp:TextBox ID="txtComentarioResolucion" TextMode="MultiLine" CssClass="form-control" MaxLength="100" runat="server" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtComentarioResolucion" ErrorMessage="⛔ El campo Resolucion es requerido" CssClass="text-danger" ValidationGroup="ResolucionValidation" Display="Dynamic" />
          </div>
      </div>
      <div class="modal-footer">
        <asp:Button ID="btnGuardarResolucion" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardarResolucion_Click" runat="server" />
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>        
      </div>
    </div>
  </div>
</div>

 <!-- Modal Cierre -->
<div class="modal fade" id="ModalCierre" data-bs-backdrop="static" tabindex="-1" aria-labelledby="ModalLabelCierre" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="lblModalCierre">Cierre! 🔒</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
          <div class="mb-3">
            <label for="message-text" class="col-form-label">Comentario:</label>
            <asp:TextBox ID="txtComentarioCierre" TextMode="MultiLine" CssClass="form-control" MaxLength="100" runat="server" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtComentarioCierre" ErrorMessage="⛔ El campo Detalle es requerido" CssClass="text-danger" ValidationGroup="CierreValidation" Display="Dynamic" />
          </div>
      </div>
      <div class="modal-footer">
        <asp:Button ID="btnGuardarCierre" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardarCierre_Click" runat="server" />
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>          
      </div>
    </div>
  </div>
</div>

    <!-- Modal-->
    <div class="modal fade" id="ModalConfirmacion" tabindex="-1" aria-labelledby="ModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="ModalLabel">⚠ Cliente inexistente</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>El DNI ingresado no se encuentra generado como cliente.</p>
                    <p>¿Desea crear un nuevo cliente?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button Text="Crear nuevo cliente" CssClass="btn btn-danger" ID="btnNuevoCliente" OnClick="btnNuevoCliente_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

