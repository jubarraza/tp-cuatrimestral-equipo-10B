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
    public partial class GestionarPaises : System.Web.UI.Page
    {
        public Pais paisSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtId.Enabled = false;

                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        PaisNegocio paisNegocio = new PaisNegocio();

                        paisSeleccionado = paisNegocio.buscarPais(long.Parse(Request.QueryString["id"]));

                        txtId.Text = paisSeleccionado.Id.ToString();
                        txtNombre.Text = paisSeleccionado.Nombre;
                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pais nueva = new Pais();
                PaisNegocio paisNegocio = new PaisNegocio();

                nueva.Nombre = txtNombre.Text;
                nueva.Activo = true;

                if (Request.QueryString["id"] != null)
                {
                    nueva.Id = long.Parse(txtId.Text);
                    paisNegocio.Modificar(nueva);
                }
                else
                {
                    paisNegocio.Agregar(nueva);
                }

                Response.Redirect("Paises.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                //redireccionar a una pantalla de error
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Paises.aspx", false);
        }
    }
}