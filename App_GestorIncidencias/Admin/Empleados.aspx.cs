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
            try 
            {
                if (!IsPostBack)
                {
                    EmpleadoNegocio negocio = new EmpleadoNegocio();
                    Session.Add("ListaEmpleados", negocio.listar());
                    gvEmpleados.DataSource = Session["ListaEmpleados"];             
                    gvEmpleados.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/GestionarEmpleado.aspx", false);
        }

        protected void gvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string legajoSeleccionado = gvEmpleados.SelectedDataKey.Value.ToString();
                Response.Redirect("GestionarEmpleado.aspx?Legajo=" + legajoSeleccionado, false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Empleado> listaEmpleados = (List<Empleado>)Session["ListaEmpleados"];
                List<Empleado> listaFiltrada = listaEmpleados.FindAll(x => x.persona.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper())
                || x.persona.Apellido.ToUpper().Contains(txtBuscar.Text.ToUpper()));
                gvEmpleados.DataSource = listaFiltrada;
                gvEmpleados.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                txtBuscar.Text = string.Empty;
                gvEmpleados.DataSource = Session["ListaEmpleados"];
                gvEmpleados.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
            
        }
    }
}