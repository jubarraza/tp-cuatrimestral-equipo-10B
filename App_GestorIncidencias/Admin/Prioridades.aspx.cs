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
    }
}