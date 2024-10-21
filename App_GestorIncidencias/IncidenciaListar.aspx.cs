using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias
{
    public partial class IncidenciaListar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                IncidenciaNegocio negocio = new IncidenciaNegocio();
                Session.Add("listaIncidencias", negocio.listar());
                dgvIncidencias.DataSource = Session["listaIncidencias"];
                dgvIncidencias.DataBind();

            }
        }
    }
}