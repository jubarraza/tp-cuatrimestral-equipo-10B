<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="App_GestorIncidencias.HomeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5 border border-black rounded pt-3 col-lg-5 col-xxl-6 col-sm-auto">

        <div class="row justify-content-center">

            <div class="row justify-content-center">

                <div class="mb-3 col-4 col-sm-auto col-md-auto">
                    <h1>Bienvenido al menu de administracion</h1>
                </div>
            </div>

            <div class="row mb-3 lead">
                <p class="form-label">En esta sección, usted tiene el control total sobre la configuración y gestión de la aplicación de reclamos. Aquí encontrará todas las herramientas necesarias para personalizar y administrar los distintos aspectos del sistema de manera eficiente.</p>
                <p class="form-label"><strong>¿Qué puede hacer desde aquí?</strong></p>
                <ul class="list-group">
                    <li class="form-label ms-5">Configurar usuarios y roles: Gestione los permisos y niveles de acceso según las necesidades de su equipo.</li>
                    <li class="form-label ms-5">Personalizar opciones del sistema: Ajuste parámetros clave de la aplicación para optimizar su funcionamiento.</li>
                    <li class="form-label ms-5">Gestionar categorías de reclamos: Organice y edite las categorías para una mejor clasificación y seguimiento de los reclamos.</li>
                </ul>
                <p class="form-label">Nuestra plataforma está diseñada para ofrecerle un entorno intuitivo y seguro, facilitando la administración de los reclamos y asegurando que cada cliente reciba la atención que merece.</p>
                <p class="form-label text-center"><strong>¡Comience a administrar y haga que su sistema de reclamos sea más eficiente que nunca!</strong></p>
            </div>

        </div>
    </div>

</asp:Content>
