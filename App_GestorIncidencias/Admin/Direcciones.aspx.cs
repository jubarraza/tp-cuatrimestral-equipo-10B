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
    public partial class Direcciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DireccionNegocio negocio = new DireccionNegocio();
                Session.Add("listaDirecciones", negocio.listar());
                gvDirecciones.DataSource = Session["listaDirecciones"];
                gvDirecciones.DataBind();

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarDirecciones.aspx", false);
        }

        protected void gvDirecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvDirecciones.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionarDirecciones.aspx?id=" + id);
        }

        protected void gvDirecciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gvDirecciones.DataKeys[e.RowIndex].Value.ToString();
            Session.Add("idDireccionEliminar", id);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModalScript", "showModal();", true);
        }

        protected void btnEliminarConfirmado_Click(object sender, EventArgs e)
        {
            DireccionNegocio negocio = new DireccionNegocio();
            long id = long.Parse(Session["idDireccionEliminar"].ToString());
            negocio.eliminarDireccion(id);
            Response.Redirect("Direcciones.aspx", false);
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Direccion> listaDirecciones = (List<Direccion>)Session["listaDirecciones"];

            List<Direccion> listaFiltrada = listaDirecciones.FindAll(x => x.Calle.ToUpper().Contains(txtBuscar.Text.ToUpper()));

            gvDirecciones.DataSource = listaFiltrada;
            gvDirecciones.DataBind();
        }
    }
}