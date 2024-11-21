<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Direcciones.aspx.cs" Inherits="App_GestorIncidencias.Admin.Direcciones" EnableEventValidation="true"%>

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
    
    <div class="container mt-5 border border-dark-subtle rounded pt-3 col-sm-auto">

        <div class="row justify-content-center">

            <div class="mb-3 col-4 col-sm-auto col-md-auto">
                <h1>Direcciones de Clientes</h1>
            </div>

        </div>

        <div class="row">
            <div class="mb-3 col-4 col-sm-auto col-md-auto justify-content-start">
                <asp:Label Text="Buscar por Cliente" runat="server" CssClass="" />
                <asp:TextBox TextMode="Search" ID="txtBuscar" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged"/>
            </div>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row justify-content-center">

                    <div>
                        <asp:GridView ID="gvDirecciones" runat="server" DataKeyNames="Id"
                            CssClass="table transparent-grid border-black" AutoGenerateColumns="false" OnSelectedIndexChanged="gvDirecciones_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField HeaderText="ID" DataField="Id"/>
                                <asp:BoundField HeaderText="Cliente" DataField="NombreApellidoCliente" />
                                <asp:BoundField HeaderText="Calle" DataField="Calle" />
                                <asp:BoundField HeaderText="Numero" DataField="Numero" />
                                <asp:BoundField HeaderText="Localidad" DataField="Localidad" />
                                <asp:BoundField HeaderText="CodPostal" DataField="CodPostal" />
                                <asp:BoundField HeaderText="Provincia" DataField="Provincia.Nombre" />
                                <asp:BoundField HeaderText="Pais" DataField="Pais.Nombre" />
                                <%--<asp:CommandField HeaderText="Editar" ControlStyle-CssClass="ms-2" ShowSelectButton="true" SelectText="<img src='https://cdn-icons-png.flaticon.com/512/32/32355.png' style='width:25px; height:25px;' alt='Editar'/>" />--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
