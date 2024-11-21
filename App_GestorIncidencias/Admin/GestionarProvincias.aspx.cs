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
    public partial class GestionarProvincias : System.Web.UI.Page
    {
        public Provincia provinciaSeleccionada;
        public Pais paisSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtId.Enabled = false;

                if (!IsPostBack)
                {

                    PaisNegocio negocioPaises = new PaisNegocio();
                    ddlPaises.DataSource = negocioPaises.listarPaises();
                    ddlPaises.DataValueField = "Id";
                    ddlPaises.DataTextField = "Nombre";
                    ddlPaises.DataBind();

                    if (Request.QueryString["id"] != null)
                    {
                        ProvinciaNegocio negocio = new ProvinciaNegocio();
                        provinciaSeleccionada = negocio.buscarProvincia(long.Parse(Request.QueryString["id"]));

                        txtId.Text = provinciaSeleccionada.Id.ToString();
                        txtNombre.Text = provinciaSeleccionada.Nombre;
                        chkActiva.Checked = provinciaSeleccionada.Visible;
                        paisSeleccionado = negocioPaises.buscarPais(provinciaSeleccionada.IdPais);
                        ddlPaises.SelectedValue = paisSeleccionado.Id.ToString();
                        
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
                Provincia nueva = new Provincia();
                ProvinciaNegocio negocio = new ProvinciaNegocio();

                nueva.Nombre = txtNombre.Text;
                nueva.Visible = chkActiva.Checked;
                nueva.IdPais = long.Parse(ddlPaises.SelectedValue);
                nueva.Activo = true;

                if (Request.QueryString["id"] != null)
                {
                    nueva.Id = long.Parse(txtId.Text);
                    negocio.Modificar(nueva);
                }
                else
                {
                    negocio.Agregar(nueva);
                }

                Response.Redirect("Provincias.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Provincias.aspx", false);
        }
    }
}