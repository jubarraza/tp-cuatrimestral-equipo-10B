<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Prioridades.aspx.cs" Inherits="App_GestorIncidencias.Admin.Prioridades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <asp:Button Text="Agregar" CssClass="btn btn-success" runat="server" />
                <asp:Button Text="Editar" CssClass="btn btn-warning" runat="server" />
                <asp:Button Text="Eliminar" CssClass="btn btn-danger" runat="server" />
            </div>

        </div>
        <div class="row justify-content-center">

            <div>
                <asp:GridView ID="gvPrioridades" runat="server" DataKeyNames="Id"
                    CssClass="table" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="Id" />
                        <asp:BoundField HeaderText="Prioridad" DataField="Nombre" />
                    </Columns>


                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
