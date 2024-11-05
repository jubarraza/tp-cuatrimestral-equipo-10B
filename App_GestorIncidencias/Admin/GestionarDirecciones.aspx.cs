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
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled= false;

            if (!IsPostBack)
            {
                DireccionNegocio negocio = new DireccionNegocio();
                ddlProvincias.DataSource = negocio.listarProvincias();
                ddlProvincias.DataValueField = "Id";
                ddlProvincias.DataTextField = "Nombre";
                ddlProvincias.DataBind();

                Provincia prov = negocio.buscarProvincia(long.Parse(ddlProvincias.SelectedValue));
                txtPais.Text = negocio.buscarNombrePais(prov);

                ClienteNegocio clienteNegocio = new ClienteNegocio();
                ddlClientes.DataSource = clienteNegocio.listar();
                ddlClientes.DataValueField = "Dni";
                ddlClientes.DataTextField = "persona";
                ddlClientes.DataBind();


                if (Request.QueryString["id"] != null)
                {
                    direSeleccionada = negocio.buscarDireccion(long.Parse(Request.QueryString["id"]));
                    txtId.Text = direSeleccionada.Id.ToString();
                    txtCalle.Text = direSeleccionada.Calle;
                    txtNumero.Text = direSeleccionada.Numero.ToString();
                    txtLocalidad.Text = direSeleccionada.Localidad;
                    txtCP.Text = direSeleccionada.CodPostal;
                    ddlProvincias.SelectedValue = direSeleccionada.provincia.Nombre;
                    txtPais.Text = direSeleccionada.Pais;
                    ddlClientes.SelectedValue = direSeleccionada.Usuario.Dni.ToString();
                }
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

                nueva.Calle = txtCalle.Text;
                nueva.Numero = long.Parse(txtNumero.Text);
                nueva.Localidad = txtLocalidad.Text;
                nueva.CodPostal = txtCP.Text;
                nueva.provincia = new Provincia();
                nueva.provincia.Id = long.Parse(ddlProvincias.SelectedValue);
                nueva.Usuario = new Dominio.Cliente();
                nueva.Usuario.Dni = long.Parse(ddlClientes.SelectedValue);
                nueva.Activo = true;

                if (Request.QueryString["id"] != null)
                {
                    nueva.Id = int.Parse(txtId.Text);
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
                //redireccionar a una pantalla de error
            }
        }

        protected void ddlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            DireccionNegocio negocio = new DireccionNegocio();
            Provincia prov = negocio.buscarProvincia(long.Parse(ddlProvincias.SelectedValue));

            txtPais.Text = negocio.buscarNombrePais(prov);
        }
    }
}