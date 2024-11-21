<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="Estados.aspx.cs" Inherits="App_GestorIncidencias.Admin.Estados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mt-5 border border-black rounded pt-3 col-lg-5 col-xxl-6 col-sm-auto">

     <div class="row justify-content-center">

         <div class="mb-3 col-4 col-sm-auto col-md-auto">
             <h1>Estados de Incidencias</h1>
         </div>

     </div>

         <div class="row">
             <div class="mb-3 col-4 col-sm-auto col-md-auto justify-content-start">
                 <asp:Label Text="Buscar" runat="server" CssClass="" />
                 <asp:TextBox TextMode="Search" ID="txtBuscar" runat="server" CssClass="form-control" OnTextChanged="txtBuscar_TextChanged" AutoPostBack="true" />
             </div>
         </div>

     <div class="row justify-content-center">

         <div>
             <asp:GridView ID="gvEstados" runat="server" DataKeyNames="Id"
                 CssClass="table transparent-grid border-black" AutoGenerateColumns="false">
                 <Columns>
                     <asp:BoundField HeaderText="ID" DataField="Id" />
                     <asp:BoundField HeaderText="Prioridad" DataField="Nombre" />
                     <asp:CheckBoxField HeaderText="Estado Final" DataField="EstadoFinal" />
                     <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                 </Columns>


             </asp:GridView>
         </div>

     </div>
 </div>
</asp:Content>
