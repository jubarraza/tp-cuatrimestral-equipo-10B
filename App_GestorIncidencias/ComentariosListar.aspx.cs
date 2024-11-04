using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias
{
    public partial class ComentariosListar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ComentarioNegocio negocio = new ComentarioNegocio();
            dgvComentarios.DataSource = negocio.Listar();
            dgvComentarios.DataBind();
                
        }

        protected void dgvComentarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}