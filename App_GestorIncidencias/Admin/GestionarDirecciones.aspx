<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="GestionarDirecciones.aspx.cs" Inherits="App_GestorIncidencias.Admin.GestionarDirecciones" EnableEventValidation="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container mt-5 border rounded pt-3 col-lg-5 col-xxl-5 col-sm-auto">

        <div class="row justify-content-center">

            <div class="row justify-content-center">

                <div class="mb-2 col-4 col-sm-auto col-md-auto">
                    <h2>Direccion</h2>
                </div>
            </div>

            <div class="mb-3 col-3 me-auto">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" ReadOnly="true" MaxLength="50" Placeholder="#" />
            </div>

            <div class="mb-3">
                <label for="txtCalle" class="form-label">Calle</label>
                <asp:TextBox runat="server" ID="txtCalle" CssClass="form-control" MaxLength="70" Placeholder="Avenida Tortugas" />
            </div>

            <div class="mb-3">
                <label for="txtNumero" class="form-label">Numero</label>
                <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" MaxLength="13" Placeholder="123" />
            </div>

            <div class="mb-3">
                <label for="txtLocalidad" class="form-label">Localidad</label>
                <asp:TextBox runat="server" ID="txtLocalidad" CssClass="form-control" MaxLength="70" Placeholder="San Martin" />
            </div>

            <div class="mb-3">
                <label for="txtCP" class="form-label">Codigo Postal</label>
                <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" MaxLength="20" Placeholder="B1644" />
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="ddlProvincias" class="form-label">Provincia</label>
                        <asp:DropDownList runat="server" ID="ddlProvincias" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincias_SelectedIndexChanged"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label for="txtPais" class="form-label">Pais</label>
                        <asp:TextBox runat="server" ID="txtPais" CssClass="form-control" Enabled="false" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="mb-3">
                <asp:Label Text="Cliente" CssClass="form-label" ID="lblCliente" runat="server" />
                <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" ReadOnly="true"/>
            </div>


            <div class="mb-3 btn-group-lg btn">
                <asp:Button Text="Guardar" runat="server" CssClass="btn btn-success" ID="btnAceptar" OnClick="btnAceptar_Click" />
                <asp:Button Text="Cancelar" runat="server" CssClass="btn btn-secondary" ID="btnCancelar" OnClick="btnCancelar_Click" />
            </div>
        </div>

    </div>
</asp:Content>
