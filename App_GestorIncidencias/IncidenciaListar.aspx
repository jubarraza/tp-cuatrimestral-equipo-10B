<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="IncidenciaListar.aspx.cs" Inherits="App_GestorIncidencias.IncidenciaListar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 4096px;
            height: 4096px;
            margin-top: 636px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid mt-5 border rounded pt-3">

        <div class="row justify-content-center">

            <div class="mb-3 col-4 col-sm-auto col-md-auto">
                <h1>Incidencias</h1>
            </div>

        </div>

        <div class="row">
            <div class="mb-3 col-4 col-sm-auto col-md-auto justify-content-start">
                <asp:Label Text="Buscar" runat="server" CssClass="" />
                <asp:TextBox TextMode="Search" ID="txtBuscar" runat="server" CssClass="form-control" AutoPostBack="true" />
            </div>
            <div class="mb-3 col-4 col-sm-auto col-md-auto justify-content-end ms-auto mt-4">
                <asp:Button Text="Agregar" ID="Button2" OnClick="btnAgregar_Click" CssClass="btn btn-primary" runat="server" />
            </div>

        </div>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row justify-content-center">

                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Id"
                        CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvIncidencias_SelectedIndexChanged">

                        <Columns>
                            <asp:BoundField HeaderText="Ticket" DataField="Id" />
                            <asp:BoundField HeaderText="Cliente" DataField="Cliente" />
                            <asp:BoundField HeaderText="Usuario" DataField="Usuario" />
                            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                            <asp:BoundField HeaderText="Estado" DataField="Estado" />
                            <asp:BoundField HeaderText="Prioridad" DataField="Prioridad" />
                            <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                            <asp:BoundField HeaderText="Fecha de Alta" DataField="FechaAlta" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField HeaderText="Fecha de Cierre" DataField="FechaCierre" />
                            <asp:BoundField HeaderText="Resolución" DataField="Resolucion" />
                            <asp:CommandField HeaderText="Ver" ShowSelectButton="true" InsertImageUrl="/Recursos/CallC.png" />
                        </Columns>
                    </asp:GridView>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
























    <asp:GridView ID="dgvIncidencias" runat="server" DataKeyNames="Id"
        CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvIncidencias_SelectedIndexChanged">

        <Columns>
            <asp:BoundField HeaderText="Ticket" DataField="Id" />
            <asp:BoundField HeaderText="Cliente" DataField="Cliente" />
            <asp:BoundField HeaderText="Usuario" DataField="Usuario" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Estado" DataField="Estado" />
            <asp:BoundField HeaderText="Prioridad" DataField="Prioridad" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
            <asp:BoundField HeaderText="Fecha de Alta" DataField="FechaAlta" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField HeaderText="Fecha de Cierre" DataField="FechaCierre" />
            <asp:BoundField HeaderText="Resolución" DataField="Resolucion" />
            <asp:CommandField HeaderText="Ver" ShowSelectButton="true" InsertImageUrl="/Recursos/CallC.png" />
        </Columns>
    </asp:GridView>

    <br />
    <div class="mb-3">
        <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" runat="server" />
    </div>



</asp:Content>
