<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="App_GestorIncidencias.Admin.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server" ></asp:ScriptManager>

    <div class="container mt-4">
    <h1>Menu de administración de Empleados</h1>
    <div class="mb-3 row">
        <div class="col-md-4 d-flex">
            <asp:TextBox ID="txtBuscar" CssClass="form-control me-md-2" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" placeholder="Buscar 🔍" runat="server"></asp:TextBox>
            <asp:Button ID="btnLimpiar" CssClass="btn-close" OnClick="btnLimpiar_Click" runat="server" />
        </div>
        <div class="col-md-8 d-flex justify-content-md-end">
          <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success" runat="server" />
        </div>   
    </div>

    <asp:UpdatePanel ID="UpDatePanel1" runat="server">
    <ContentTemplate>
    <div class="mb-3 row">
        <asp:GridView ID="gvEmpleados" DataKeyNames="Legajo" CssClass="table table-hover text-center" OnSelectedIndexChanged="gvEmpleados_SelectedIndexChanged"
            OnPageIndexChanging="gvEmpleados_PageIndexChanging" AllowPaging="true" PageSize="6" AutoGenerateColumns="false" runat="server">
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
