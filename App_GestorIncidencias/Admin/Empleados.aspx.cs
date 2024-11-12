using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace App_GestorIncidencias.Admin
{
    public partial class Usuarios : System.Web.UI.Page
    {
        public List<Empleado> listaEmpleados { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            listaEmpleados = negocio.listar();
            gvEmpleados.DataSource = listaEmpleados;
            gvEmpleados.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/GestionarEmpleado.aspx");
        }

        protected void gvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string legajoSeleccionado = gvEmpleados.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionarEmpleado.aspx?Legajo=" + legajoSeleccionado);
        }

    }
}