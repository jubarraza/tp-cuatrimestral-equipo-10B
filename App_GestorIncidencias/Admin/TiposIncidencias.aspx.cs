using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias.Admin
{
    public partial class TiposIncidencias : System.Web.UI.Page
    {
        public object Nombre { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    TipoIncidenciaNegocio negocio = new TipoIncidenciaNegocio();
                    Session.Add("listaTipoIncidencia", negocio.listar());
                    gvTipoIncidencias.DataSource = Session["listaTipoIncidencia"];
                    gvTipoIncidencias.DataBind();
                }
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
                List<TipoIncidencia> listaTipoIncidencia = (List<TipoIncidencia>)Session["listaTipoIncidencia"];

                List<TipoIncidencia> listaFiltrada = listaTipoIncidencia.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));

                gvTipoIncidencias.DataSource = listaFiltrada;
                gvTipoIncidencias.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            
        }

        protected void gvTipoIncidencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvTipoIncidencias.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionarTipoIncidencia.aspx?id=" + id);
        }

        protected void gvTipoIncidencias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = gvTipoIncidencias.DataKeys[e.RowIndex].Value.ToString();
                Session.Add("idTipoIncidenciaEliminar", id);
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
                TipoIncidenciaNegocio negocio = new TipoIncidenciaNegocio();
                int id = int.Parse(Session["idTipoIncidenciaEliminar"].ToString());
                negocio.Eliminar(id);
                Response.Redirect("TiposIncidencias.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarTipoIncidencia.aspx", false);
        }
    }
}