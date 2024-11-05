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
            Session.Add("idEliminar", id);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModalScript", "showModal();", true);
        }

        protected void btnEliminarConfirmado_Click(object sender, EventArgs e)
        {

        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}