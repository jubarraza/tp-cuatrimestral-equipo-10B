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
    public partial class GestionarDirecciones : System.Web.UI.Page
    {
        public Direccion direSeleccionada;
        public Provincia provSeleccionada;
        public Pais paisSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled= false;
            lblCliente.Visible = false;
            txtCliente.Visible = false;

            try
            {
                if (!IsPostBack)
                {
                    ProvinciaNegocio negocio = new ProvinciaNegocio();
                    ddlProvincias.DataSource = negocio.listarProvincias(true);
                    ddlProvincias.DataValueField = "Id";
                    ddlProvincias.DataTextField = "Nombre";
                    ddlProvincias.DataBind();

                    long idProv = long.Parse(ddlProvincias.SelectedValue);
                    provSeleccionada = negocio.buscarProvincia(idProv);
                    PaisNegocio paisNegocio = new PaisNegocio();
                    paisSeleccionado = paisNegocio.buscarPais(provSeleccionada.IdPais);
                    txtPais.Text = paisSeleccionado.Nombre;


                    if (Request.QueryString["id"] != null)
                    {
                        DireccionNegocio direccionNegocio = new DireccionNegocio();
                        long idDire = long.Parse(Request.QueryString["id"]);
                        direSeleccionada = direccionNegocio.buscarDireccion(idDire);
                        txtId.Text = direSeleccionada.Id.ToString();
                        txtCalle.Text = direSeleccionada.Calle;
                        txtNumero.Text = direSeleccionada.Numero.ToString();
                        txtLocalidad.Text = direSeleccionada.Localidad;
                        txtCP.Text = direSeleccionada.CodPostal;
                        ddlProvincias.SelectedValue = direSeleccionada.provincia.Id.ToString();
                        txtPais.Text = direSeleccionada.pais.Nombre;
                        lblCliente.Visible = true;
                        txtCliente.Visible = true;
                        txtCliente.Text = direSeleccionada.NombreApellidoCliente;
                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }

            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Direcciones.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Direccion nueva = new Direccion();
                DireccionNegocio negocio = new DireccionNegocio();
                ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
                PaisNegocio paisNegocio = new PaisNegocio();

                nueva.Calle = txtCalle.Text;
                nueva.Numero = long.Parse(txtNumero.Text);
                nueva.Localidad = txtLocalidad.Text;
                nueva.CodPostal = txtCP.Text;
                nueva.provincia = new Provincia();
                nueva.provincia.Id = long.Parse(ddlProvincias.SelectedValue);
                nueva.provincia = provinciaNegocio.buscarProvincia(nueva.provincia.Id);
                nueva.pais = paisNegocio.buscarPais(nueva.provincia.IdPais);
                nueva.Activo = true;

                if (Request.QueryString["id"] != null)
                {
                    nueva.Id = long.Parse(txtId.Text);
                    negocio.modificarDireccion(nueva);
                }
                else
                {
                    negocio.agregarDireccion(nueva);
                }

                Response.Redirect("Direcciones.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
        }

        protected void ddlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ProvinciaNegocio negocio = new ProvinciaNegocio();
                PaisNegocio paisNegocio = new PaisNegocio();
                provSeleccionada = negocio.buscarProvincia(long.Parse(ddlProvincias.SelectedValue));
                paisSeleccionado = paisNegocio.buscarPais(provSeleccionada.IdPais);
                txtPais.Text = paisSeleccionado.Nombre;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            
        }
    }
}