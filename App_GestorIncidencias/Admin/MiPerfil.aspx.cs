using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace App_GestorIncidencias.Admin
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Helper.SessionActiva(Session["usuario"]))
                Response.Redirect("Default.aspx", false);



        }
    }
}