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
    public partial class Estados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    EstadoNegocio negocio = new EstadoNegocio();
                    Session.Add("listaEstados", negocio.listar());
                    gvEstados.DataSource = Session["listaEstados"];
                    gvEstados.DataBind();

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
            
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Estado> listaEstados = (List<Estado>)Session["listaEstados"];

                List<Estado> listaFiltrada = listaEstados.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));

                gvEstados.DataSource = listaFiltrada;
                gvEstados.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
            
        }
    }
}