using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias.Admin
{
    public partial class Prioridades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PrioridadNegocio negocio = new PrioridadNegocio();
                    Session.Add("listaPrioridades", negocio.listar());
                    gvPrioridades.DataSource = Session["listaPrioridades"];
                    gvPrioridades.DataBind();

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarPrioridades.aspx", false);
        }

        protected void gvPrioridades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvPrioridades.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionarPrioridades.aspx?id=" + id);

        }

        protected void gvPrioridades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = gvPrioridades.DataKeys[e.RowIndex].Value.ToString();
                Session.Add("idPrioridadEliminar", id);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModalScript", "showModal();", true);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            
        }

        protected void btnEliminarConfirmado_Click(object sender, EventArgs e)
        {
            try
            {
                PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
                int id = int.Parse(Session["idPrioridadEliminar"].ToString());
                prioridadNegocio.Eliminar(id);
                Response.Redirect("Prioridades.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Prioridad> listaPrioridades = (List<Prioridad>)Session["listaPrioridades"];

                List<Prioridad> listaFiltrada = listaPrioridades.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));

                gvPrioridades.DataSource = listaFiltrada;
                gvPrioridades.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            
        }
    }
}