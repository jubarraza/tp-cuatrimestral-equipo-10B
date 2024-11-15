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
    </style>
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

            <div class="row flex-fill">
                <div class="col-md-2 mb-3 me-auto ms-0 col-sm-5">
                    <label for="txtId" class="form-label">Ticket</label>
                    <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                </div>

                <div class="mb-3 col-sm-7 col-md-4 me-auto">
                    <label for="ddlEstado" class="form-label">Estado: </label>
                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-select"></asp:DropDownList>
                </div>

                <div class="col-md-2 col-sm-6 mb-4">
                    <div class="btn-group-lg card gap-3 mb-3">
                        <asp:Button Text="Resolver" CssClass="btn btn-success" runat="server" />
                        <asp:Button Text="Cerrar" CssClass="btn btn-secondary" runat="server" />
                    </div>
                </div>
            </div>


            <div class="row flex">
                <div class="container col-3 border rounded p-2">
                   <%-- <asp:UpdatePanel runat="server">
                        <ContentTemplate>--%>

                            <div class="mb-3 me-auto">
                                <label for="txtDniCliente" class="form-label">Dni: </label>
                                <asp:TextBox runat="server" ID="txtDniCliente" CssClass="form-control" OnTextChanged="txtDniCliente_TextChanged" AutoPostBack="true" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDniCliente" ErrorMessage="⛔ El campo DNI es requerido" CssClass="text-danger" Display="Dynamic" />
                                <%--<asp:RegularExpressionValidator ControlToValidate="txtDni" ValidationExpression="^\d+$" ErrorMessage="⛔ Solo se aceptan numeros" EnableClientScript="true" CssClass="text-danger" Display="Dynamic" runat="server" />--%>
                                <asp:Label Text="⛔ Solo se aceptan numeros" runat="server" Visible="false" ID="lblValidacionNumero" />
                            </div>
                            <div class="mb-3 me-auto">
                                <label for="txtCliente" class="form-label">Cliente: </label>
                                <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" />
                            </div>
                            <div class="mb-3 me-auto">
                                <label for="txtTelefono" class="form-label">Telefono: </label>
                                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" />
                            </div>
                            <div class="mb-3 me-auto">
                                <label for="txtEmail" class="form-label">Email: </label>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                            </div>
                            <div class="mb-3 me-auto">
                                <label for="txtDireccion" class="form-label">Direccion: </label>
                                <asp:TextBox runat="server" ID="txtDireccion" TextMode="MultiLine" CssClass="form-control" />
                            </div>

                       <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>

                <div class="container col-5 p-2">

                    <div class="mb-3 me-auto ">
                        <label for="txtDescripcion" class="form-label">Descripción: </label>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="TxtDescripcion" CssClass="form-control alturaDesc" />
                    </div>

                </div>

                <div class="container col-3 p-2 border rounded mb-3">

                    <div class="mb-3 me-auto">
                        <label for="txtUsuario" class="form-label">Usuario: </label>
                        <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
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

                </div>

            </div>

        <div class="row mt-5">

            <div class="mb-3 btn-group-lg btn">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-success" runat="server" OnClick="btnAceptar_Click" />
                <a href="IncidenciaListar.aspx">Volver</a>
            </div>

        </div>


        </div>

        <div class="container">
            <div class="row justify-content-center mt-3 me-4">

                <div class="border rounded p-3">
                    <div class="row justify-content-start mt-1">
                        <div class="mb-2 col-4 col-sm-auto col-md-auto">
                            <h4>Comentarios</h4>
                        </div>
                    </div>

                    <asp:GridView ID="dgvComentarios" runat="server" OnSelectedIndexChanged="dgvComentarios_SelectedIndexChanged" DataKeyNames="Id" CssClass="table gridSelector" AutoGenerateColumns="false">

                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" />
                            <asp:BoundField HeaderText="Ticket" DataField="Cod_Incidencia" />
                            <asp:BoundField HeaderText="Comentario" DataField="ComentarioGestion" />
                            <asp:BoundField HeaderText="Fecha de Alta" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField HeaderText="Usuario" DataField="Cod_Usuario" />
                            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Ver🔍" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="mt-3 form-check-reverse">
                    <asp:Button Text="Nuevo Comentario" ID="BtnComentar" CssClass="btn btn-primary" runat="server" />
                </div>

            </div>
        </div>

    </div>
</asp:Content>

