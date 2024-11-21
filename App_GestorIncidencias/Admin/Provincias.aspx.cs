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
    public partial class Provincias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ProvinciaNegocio negocio = new ProvinciaNegocio();
                    Session.Add("listaProvincias", negocio.listarProvincias());
                    gvProvincias.DataSource = Session["listaProvincias"];
                    gvProvincias.DataBind();
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
                List<Provincia> listaProvincias = (List<Provincia>)Session["listaProvincias"];

                List<Provincia> listaFiltrada = listaProvincias.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));

                gvProvincias.DataSource = listaFiltrada;
                gvProvincias.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            
        }

        

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarProvincias.aspx", false);
        }

        protected void gvProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvProvincias.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionarProvincias.aspx?id=" + id);
        }

        protected void gvProvincias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = gvProvincias.DataKeys[e.RowIndex].Value.ToString();
                Session.Add("idProvinciaEliminar", id);
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
                ProvinciaNegocio negocio = new ProvinciaNegocio();
                long id = long.Parse(Session["idProvinciaEliminar"].ToString());
                negocio.Eliminar(id);
                Response.Redirect("Provincias.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            
        }
    }
}