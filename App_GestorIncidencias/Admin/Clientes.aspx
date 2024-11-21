<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="App_GestorIncidencias.Admin.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function showModal() {
            var myModal = new bootstrap.Modal(document.getElementById('ModalConfirmacion'));
            myModal.show();
        }
    </script>
    <style>
        .margen {
            margin-top: 1.9rem !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container-fluid mt-5 border border-black rounded pt-3">

        <div class="row justify-content-center">

            <div class="mb-3 col-4 col-sm-auto col-md-auto">
                <h1>Administración de Clientes</h1>
            </div>

        </div>

        <div class="row">
            <div class="mb-3 col-4 col-sm-auto col-md-auto justify-content-start">
                <asp:Label Text="Buscar" runat="server" CssClass="form-label" />
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" Placeholder="🔍" />
            </div>
            <asp:Button ID="btnLimpiarFiltro" CssClass="btn-close margen" OnClick="btnLimpiarFiltro_Click" runat="server" />

            <div class="mb-3 col-4 col-sm-auto col-md-auto justify-content-end ms-auto mt-4">
                <asp:Button Text="Agregar" CssClass="btn btn-success" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" />
            </div>
        </div>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row col-md-4 col-sm-12 alert alert-warning ms-1" runat="server" id="areaErrorEliminar" visible="false">
                    <asp:Label Text="⛔ No se puede eliminar el cliente dado que posee reclamos activos." ID="lblEliminacionFallida" runat="server" CssClass="form-label col-11 col-md" />
                    <asp:Button ID="btnCerrarLbl" CssClass="btn-close" OnClick="btnCerrarLbl_Click" runat="server" />
                </div>

                <div class="row justify-content-center">
                    <div>
                        <asp:GridView ID="gvClientes" CssClass="table transparent-grid border-black" AutoGenerateColumns="false" runat="server" DataKeyNames="Dni" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged" OnRowDeleting="gvClientes_RowDeleting">
                            <Columns>
                                <asp:BoundField HeaderText="Nombre" DataField="persona.Nombre" />
                                <asp:BoundField HeaderText="Apellido" DataField="persona.Apellido" />
                                <asp:BoundField HeaderText="Email" DataField="persona.Email" />
                                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                                <asp:BoundField HeaderText="Direccion" DataField="direccion" />
                                <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                                <asp:CommandField HeaderText="Ver/Editar" ControlStyle-CssClass="ms-2" ShowSelectButton="true" SelectText="<img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT0iddqxTexq3TkjV6ajw_jIDTdtba7Dxuz-Q&s' style='width:25px; height:25px; ms-2;' alt='Editar'/>" />
                                <asp:CommandField HeaderText="Eliminar" ControlStyle-CssClass="ms-3" ShowDeleteButton="true" DeleteText="<img src='https://cdn-icons-png.flaticon.com/512/1214/1214594.png' style='width:25px; height:25px;' alt='Eliminar'/>" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="ModalConfirmacion" tabindex="-1" aria-labelledby="ModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="ModalLabel">⛔ Eliminar Cliente</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>¿Confirma que desea eliminar el Cliente?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button Text="Eliminar Cliente" CssClass="btn btn-danger" ID="btnEliminarConfirmado" OnClick="btnEliminarConfirmado_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
