using Negocio;
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
            if (!IsPostBack)
            {
                PrioridadNegocio negocio = new PrioridadNegocio();
                Session.Add("listaPrioridades", negocio.listar());
                gvPrioridades.DataSource = Session["listaPrioridades"];
                gvPrioridades.DataBind();

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
    }
}