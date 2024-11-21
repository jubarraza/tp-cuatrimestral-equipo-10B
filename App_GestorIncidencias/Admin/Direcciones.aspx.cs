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
            try
            {
                if (!IsPostBack)
                {
                    DireccionNegocio negocio = new DireccionNegocio();
                    Session.Add("listaDirecciones", negocio.listar());
                    gvDirecciones.DataSource = Session["listaDirecciones"];
                    gvDirecciones.DataBind();

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
            
        }

        protected void gvDirecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvDirecciones.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionarDirecciones.aspx?id=" + id);
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Direccion> listaDirecciones = (List<Direccion>)Session["listaDirecciones"];

                List<Direccion> listaFiltrada = listaDirecciones.FindAll(x => x.NombreApellidoCliente.ToUpper().Contains(txtBuscar.Text.ToUpper()));

                gvDirecciones.DataSource = listaFiltrada;
                gvDirecciones.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("PageError.aspx", false);
            }
            
        }
    }
}