<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Prioridades.aspx.cs" Inherits="App_GestorIncidencias.Admin.Prioridades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style> 
        .img{
            width: 25px;
            height: 25px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 border rounded pt-3 col-lg-5 col-xxl-6 col-sm-auto">

        <div class="row justify-content-center">

            <div class="mb-3 col-4 col-sm-auto col-md-auto">
                <h1>Prioridades</h1>
            </div>

        </div>

        <div class="row justify-content-end">

            <div class="mb-3 col-4 col-sm-auto col-md-auto">
                <asp:Button Text="Agregar" CssClass="btn btn-success" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" />
            </div>

        </div>
        <div class="row justify-content-center">

            <div>
                <asp:GridView ID="gvPrioridades" runat="server" DataKeyNames="Id"
                    CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="gvPrioridades_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />
                        <asp:BoundField HeaderText="Prioridad" DataField="Nombre" />
                        <asp:CheckBoxField HeaderText="Activa" DataField="Activa" ControlStyle-CssClass="ms-3"/>
                        <asp:CommandField HeaderText="Editar" ControlStyle-CssClass="ms-2" ShowSelectButton="true" SelectText="<img src='https://cdn-icons-png.flaticon.com/512/32/32355.png' style='width:25px; height:25px;' alt='Editar'/>"/>
                    </Columns>


                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
