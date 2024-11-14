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
            Session.Add("ListaEmpleados", negocio.listar());
            gvEmpleados.DataSource = Session["ListaEmpleados"];             
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

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Empleado> listaEmpleados = (List<Empleado>)Session["ListaEmpleados"];
            List<Empleado> listaFiltrada = listaEmpleados.FindAll(x => x.persona.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper())
            || x.persona.Apellido.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            gvEmpleados.DataSource = listaFiltrada;
            gvEmpleados.DataBind();

        }

        protected void gvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmpleados.PageIndex = e.NewPageIndex;
            gvEmpleados.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;
        }
    }
}