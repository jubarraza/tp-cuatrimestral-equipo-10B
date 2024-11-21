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
    public partial class GestionarTipoIncidencia : System.Web.UI.Page
    {
        public TipoIncidencia TipoIncSeleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                txtId.Enabled = false;

                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        TipoIncidenciaNegocio negocio = new TipoIncidenciaNegocio();
                        TipoIncSeleccionado = new TipoIncidencia();
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        TipoIncSeleccionado = negocio.Buscar(id);

                        txtId.Text = TipoIncSeleccionado.Id.ToString();
                        txtNombre.Text = TipoIncSeleccionado.Nombre;
                        chkActiva.Checked = TipoIncSeleccionado.Visible;
                    }
                }


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoIncidencia nueva = new TipoIncidencia();
                TipoIncidenciaNegocio negocio = new TipoIncidenciaNegocio();

                nueva.Nombre = txtNombre.Text;
                nueva.Visible = chkActiva.Checked;
                nueva.Activo = true;

                if (Request.QueryString["id"] != null)
                {
                    nueva.Id = int.Parse(txtId.Text);
                    negocio.Modificar(nueva);
                }
                else
                {
                    negocio.Agregar(nueva);
                }

                Response.Redirect("TiposIncidencias.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("TiposIncidencias.aspx", false);
        }
    }
}