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
    public partial class GestionarPrioridades : System.Web.UI.Page
    {
        public Prioridad PrioridadSeleccionada { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtId.Enabled = false;

                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
                        PrioridadSeleccionada = prioridadNegocio.Buscar(int.Parse(Request.QueryString["id"]));

                        
                        txtId.Text = PrioridadSeleccionada.Id.ToString();
                        txtNombre.Text = PrioridadSeleccionada.Nombre;
                        chkActiva.Checked = PrioridadSeleccionada.Visible;
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
                Prioridad nueva = new Prioridad();
                PrioridadNegocio prioridadNegocio = new PrioridadNegocio();

                nueva.Nombre = txtNombre.Text;
                nueva.Visible = chkActiva.Checked;
                nueva.Activo = true;

                if (Request.QueryString["id"] != null)
                {
                    nueva.Id = int.Parse(txtId.Text);
                    prioridadNegocio.Modificar(nueva);
                }
                else
                {
                    prioridadNegocio.Agregar(nueva);
                }

                Response.Redirect("Prioridades.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Prioridades.aspx", false);
        }

    }
}