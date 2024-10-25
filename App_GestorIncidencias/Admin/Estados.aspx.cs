using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias.Admin
{
    public partial class Estados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EstadoNegocio negocio = new EstadoNegocio();
                Session.Add("listaEstados", negocio.listar());
                gvEstados.DataSource = Session["listaEstados"];
                gvEstados.DataBind();

            }
        }
    }
}