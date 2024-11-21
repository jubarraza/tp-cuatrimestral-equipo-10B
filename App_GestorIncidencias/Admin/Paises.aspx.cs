using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias.Admin
{
    public partial class Paises : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    PaisNegocio negocio = new PaisNegocio();
                    Session.Add("listaPaises", negocio.listarPaises());
                    gvPaises.DataSource = Session["listaPaises"];
                    gvPaises.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Pais> listaPaises = (List<Pais>)Session["listaPaises"];

                List<Pais> listaFiltrada = listaPaises.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));

                gvPaises.DataSource = listaFiltrada;
                gvPaises.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarPaises.aspx", false);
        }

        protected void gvPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvPaises.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionarPaises.aspx?id=" + id);
        }

        protected void gvPaises_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = gvPaises.DataKeys[e.RowIndex].Value.ToString();
                Session.Add("idPaisEliminar", id);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModalScript", "showModal();", true);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            
        }

        protected void btnEliminarConfirmado_Click(object sender, EventArgs e)
        {
            try
            {
                PaisNegocio negocio = new PaisNegocio();
                int id = int.Parse(Session["idPaisEliminar"].ToString());
                negocio.Eliminar(id);
                Response.Redirect("Paises.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            
        }
    }
}