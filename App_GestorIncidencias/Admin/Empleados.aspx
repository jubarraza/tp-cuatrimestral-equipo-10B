<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="App_GestorIncidencias.Admin.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .margen {
            margin-top: 1.9rem !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <div class="container-fluid mt-5 border border-black rounded pt-3">

        <div class="row justify-content-center">

            <div class="mb-3 col-4 col-sm-auto col-md-auto">
                <h1>Administración de Empleados</h1>
            </div>

        </div>

        <div class="row flex">
            <div class="mb-3 col-4 mt-4 col-sm-auto col-md-auto justify-content-start">
                <asp:TextBox ID="txtBuscar" CssClass="form-control me-md-2" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" placeholder="Buscar 🔍" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnLimpiar" CssClass="btn-close margen" OnClick="btnLimpiar_Click" runat="server" />

            <div class="mb-3 col-4 col-sm-auto col-md-auto justify-content-end ms-auto mt-4">
                <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success" runat="server" />
            </div>
        </div>

        <asp:UpdatePanel ID="UpDatePanel1" runat="server">
            <ContentTemplate>
                <div class="row justify-content-center">
                    <asp:GridView ID="gvEmpleados" DataKeyNames="Legajo" CssClass="table table-hover text-center transparent-grid border-black" OnSelectedIndexChanged="gvEmpleados_SelectedIndexChanged"
                       AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre/s" DataField="persona.Nombre" />
                            <asp:BoundField HeaderText="Apellido/s" DataField="persona.Apellido" />
                            <asp:BoundField HeaderText="Email" DataField="persona.Email" />
                            <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                            <asp:BoundField HeaderText="Tipo Usuario" DataField="tipoUsuario.Tipo" />
                            <asp:BoundField HeaderText="Fecha Ingreso" DataField="FechaIngreso" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                            <asp:CommandField HeaderText="Editar" ControlStyle-CssClass="ms-2" ShowSelectButton="true" SelectText="<img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT0iddqxTexq3TkjV6ajw_jIDTdtba7Dxuz-Q&s' style='width:25px; height:25px; ms-2;' alt='Editar'/>" />
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
