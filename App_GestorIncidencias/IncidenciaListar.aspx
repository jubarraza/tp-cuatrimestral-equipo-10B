﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="IncidenciaListar.aspx.cs" Inherits="App_GestorIncidencias.IncidenciaListar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <asp:Label Text="Buscar Ticket" runat="server" CssClass="" />
                <asp:TextBox TextMode="Search" ID="txtBuscar" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" />
            </div>
            <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                <div class="mb-3">
                    <asp:CheckBox Text="Filtro Avanzado"
                        CssClass="" ID="chkAvanzado" runat="server" AutoPostBack="true" />
                </div>
            </div>
            <div class="mb-3 col-4 col-sm-auto col-md-auto justify-content-end ms-auto mt-4">
                <asp:Button Text="Agregar" ID="Button2" OnClick="btnAgregar_Click" CssClass="btn btn-primary" runat="server" />
            </div>

        </div>
        <%if (chkAvanzado.Checked)
            { %>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Busqueda por:" ID="lblBusquedapor" runat="server" />
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlBusquedapor" AutoPostBack="true" OnSelectedIndexChanged="ddlBusquedapor_SelectedIndexChanged">
                        <asp:ListItem Text="Todos" />
                        <asp:ListItem Text="DNI Cliente" />
                        <asp:ListItem Text="Legajo Usuario" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <br />
                    <asp:TextBox runat="server" ID="txtBusquedapor" CssClass="form-control" Enabled="false" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filtrar por" runat="server" />
                    <asp:DropDownList ID="ddlFiltrapor" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlFiltrapor_SelectedIndexChanged">
                        <asp:ListItem Text="Todos" />
                        <asp:ListItem Text="Estado" />
                        <asp:ListItem Text="Prioridad" />
                        <asp:ListItem Text="Tipo" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <br />
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control" Enabled="false">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Fecha desde:" ID="lblDesde" runat="server" />
                    <asp:TextBox runat="server" ID="txtFechaDesde" CssClass="form-control" TextMode="Date" />
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Fecha Hasta:" ID="lblHasta" runat="server" />
                    <asp:TextBox runat="server" ID="txtFechaHasta" CssClass="form-control" TextMode="Date"/>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />                  
                </div>
                <div class="mb-3">
                     <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-primary" ID="BtnLimpiar" OnClick="BtnLimpiar_Click" />
                </div>
            </div>
        </div>
    </div>
    <%} %>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row justify-content-center">

                <asp:GridView ID="dgvIncidencias" runat="server" DataKeyNames="Id"
                    CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvIncidencias_SelectedIndexChanged">

                    <Columns>
                        <asp:BoundField HeaderText="Ticket" DataField="Id" />
                        <asp:BoundField HeaderText="Cliente" DataField="Cliente" />
                        <asp:BoundField HeaderText="Usuario asignado" DataField="Empleado" />
                        <%--<asp:BoundField HeaderText="Descripción" DataField="Descripcion" />--%>
                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                        <asp:BoundField HeaderText="Prioridad" DataField="Prioridad" />
                        <asp:BoundField HeaderText="Tipo" DataField="Tipo.Nombre" />
                        <asp:BoundField HeaderText="Fecha de Alta" DataField="FechaAlta" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Fecha de Cierre" DataField="FechaCierre" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Resolución" DataField="Resolucion" />
                        <asp:CommandField HeaderText="Ver" ShowSelectButton="true" InsertImageUrl="/Recursos/CallC.png" />
                    </Columns>
                </asp:GridView>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
