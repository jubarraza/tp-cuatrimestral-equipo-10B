<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="GestionarIncidencia.aspx.cs" Inherits="App_GestorIncidencias.GestionarIncidencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .alturaDesc {
            height: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

    <div class="container mt-5">

        <div class="row justify-content-center">

            <div class="row justify-content-center">

                <div class="mb-2 col-4 col-sm-auto col-md-auto">
                    <h2>Incidencia</h2>
                </div>


                <div class="mb-3 me-auto">
                    <label for="txtId" class="form-label">Ticket</label>
                    <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                </div>
                <div class="mb-3 me-auto">
                    <label for="txtCliente" class="form-label">Cliente: </label>
                    <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" />
                </div>
                <div class="mb-3 me-auto">
                    <label for="txtUsuario" class="form-label">Usuario: </label>
                    <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
                </div>
                <div class="mb-3 me-auto ">
                    <label for="txtDescripcion" class="form-label">Descripción: </label>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="TxtDescripcion" CssClass="form-control alturaDesc" />
                </div>
                <div class="mb-3 me-auto">
                    <label for="ddlPrioridad" class="form-label">Prioridad: </label>
                    <asp:DropDownList runat="server" ID="ddlPrioridad" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-3 me-auto">
                    <label for="ddlEstado" class="form-label">Estado: </label>
                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-select"></asp:DropDownList>
                </div>


                <div class="mb-3 btn-group-lg btn">
                    <asp:Button Text="Modificar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-success" runat="server" />
                    <asp:Button Text="Nuevo Comentario" ID="BtnComentar" OnClick="BtnComentar_Click" CssClass="btn btn-primary" runat="server" />
                    <a href="IncidenciaListar.aspx">Volver</a>
                </div>


            </div>
            <div class="row justify-content-start mt-4">
                <div class="mb-2 col-4 col-sm-auto col-md-auto">
                    <h4>Comentarios</h4>
                </div>
            </div>
            <div class="row justify-content-center mt-5 me-4">

                <div class="border rounded p-5">
                    <asp:GridView ID="dgvComentarios" runat="server" OnSelectedIndexChanged="dgvComentarios_SelectedIndexChanged" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false">

                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" />
                            <asp:BoundField HeaderText="Ticket" DataField="Cod_Incidencia" />
                            <asp:BoundField HeaderText="Comentario" DataField="ComentarioGestion" />
                            <asp:BoundField HeaderText="Fecha de Alta" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField HeaderText="Usuario" DataField="Cod_Usuario" />
                            <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
