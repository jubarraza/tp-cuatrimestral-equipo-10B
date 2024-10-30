using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace App_GestorIncidencias
{
    public partial class AgregarIncidencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            if(!IsPostBack)
            {
                try
                {
                    PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
                    List<Prioridad> list = prioridadNegocio.listar();
                    ddlPrioridad.DataSource = list;
                    ddlPrioridad.DataValueField = "Id";
                    ddlPrioridad.DataTextField = "Nombre";
                    ddlPrioridad.DataBind();
                }
                catch (Exception ex)
                {

                    Session.Add("Error al cargar DropDownList", ex);
                    throw;
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Incidencia incidencia = new Incidencia();
                IncidenciaNegocio negocio = new IncidenciaNegocio();
                incidencia.Cliente = int.Parse(txtCliente.Text);
                incidencia.Usuario = int.Parse(txtUsuario.Text);
                incidencia.Descripcion = TxtDescripcion.Text;
                incidencia.Estado = new Estado();
                incidencia.Estado.Id = 1;
                incidencia.Prioridad.Id = int.Parse(ddlPrioridad.SelectedValue);
                incidencia.Tipo = 2;
                incidencia.FechaAlta = DateTime.Now;
                negocio.AgregarIncidencia(incidencia);
                Response.Redirect("IncidenciaListar.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("PageError.aspx", ex);   
              
            }
        }
    }
}