<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Provincias.aspx.cs" Inherits="App_GestorIncidencias.Admin.Provincias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img {
            width: 25px;
            height: 25px;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container mt-5 border border-black rounded pt-3 col-lg-5 col-xxl-6 col-sm-auto">

        <div class="row justify-content-center">

            <div class="mb-3 col-4 col-sm-auto col-md-auto">
                <h1>Provincias</h1>
            </div>

        </div>

        <div class="row">
            <div class="mb-3 col-4 col-sm-auto col-md-auto justify-content-start">
                <asp:Label Text="Buscar" runat="server" CssClass="" />
                <asp:TextBox TextMode="Search" ID="txtBuscar" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" />
            </div>
            <div class="mb-3 col-4 col-sm-auto col-md-auto justify-content-end ms-auto mt-4">
                <asp:Button Text="Agregar" CssClass="btn btn-success" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" />
            </div>
        </div>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row justify-content-center">

                    <div>
                        <asp:GridView ID="gvProvincias" runat="server" DataKeyNames="Id"
                            CssClass="table transparent-grid border-black" AutoGenerateColumns="false" OnSelectedIndexChanged="gvProvincias_SelectedIndexChanged" OnRowDeleting="gvProvincias_RowDeleting">
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="Id" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:TemplateField HeaderText="País">
                                    <ItemTemplate>
                                        <%# Negocio.Helper.ObtenerNombrePais(Eval("IdPais")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CheckBoxField HeaderText="Visible" DataField="Visible" ControlStyle-CssClass="ms-3" />
                                <asp:CommandField HeaderText="Editar" ControlStyle-CssClass="ms-2" ShowSelectButton="true" SelectText="<img src='https://cdn-icons-png.flaticon.com/512/32/32355.png' style='width:25px; height:25px;' alt='Editar'/>" />
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
                    <h1 class="modal-title fs-5" id="ModalLabel">⛔ Eliminar Provincia</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>¿Confirma que desea eliminar la Provincia?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button Text="Eliminar" CssClass="btn btn-danger" ID="btnEliminarConfirmado" runat="server" OnClick="btnEliminarConfirmado_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
