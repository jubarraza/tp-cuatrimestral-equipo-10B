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
            if (!IsPostBack)
            {
                TipoIncidenciaNegocio negocio = new TipoIncidenciaNegocio();
                Session.Add("listaTipoIncidencia", negocio.listar());
                gvTipoIncidencias.DataSource = Session["listaTipoIncidencia"];
                gvTipoIncidencias.DataBind();
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<TipoIncidencia> listaTipoIncidencia = (List<TipoIncidencia>)Session["listaTipoIncidencia"];

            List<TipoIncidencia> listaFiltrada = listaTipoIncidencia.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));

            gvTipoIncidencias.DataSource = listaFiltrada;
            gvTipoIncidencias.DataBind();
        }

        protected void gvTipoIncidencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvTipoIncidencias.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionarTipoIncidencia.aspx?id=" + id);
        }

        protected void gvTipoIncidencias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gvTipoIncidencias.DataKeys[e.RowIndex].Value.ToString();
            Session.Add("idTipoIncidenciaEliminar", id);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModalScript", "showModal();", true);
        }

        protected void btnEliminarConfirmado_Click(object sender, EventArgs e)
        {
            TipoIncidenciaNegocio negocio = new TipoIncidenciaNegocio();
            int id = int.Parse(Session["idTipoIncidenciaEliminar"].ToString());
            //negocio.Eliminar(id);
            Response.Redirect("TiposIncidencias.aspx", false);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarTipoIncidencia.aspx", false);
        }
    }
}