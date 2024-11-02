﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias.Admin
{
    public partial class AgregarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtLegajo.Enabled = false;
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            int ultimoLegajo = negocio.obtenerUltimoLegajo();
            txtLegajo.Text = ultimoLegajo.ToString();

        }
    }
}