using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias.Admin
{
    public partial class GestionarClientes : System.Web.UI.Page
    {
        public Cliente clienteSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                btnEditarDireccion.Visible = false;

                if (!IsPostBack)
                {
                    btnEditar.Visible = false;

                    if (Request.QueryString["dni"] != null)
                    {
                        DeshabilitarCampos();
                        btnAceptar.Visible = false;
                        btnCancelar.Text = "Volver";
                        btnEditar.Visible = true;

                        ClienteNegocio clienteNegocio = new ClienteNegocio();
                        long dni = long.Parse(Request.QueryString["dni"]);
                        clienteSeleccionado = clienteNegocio.BuscarCliente(dni);

                        txtId.Text = clienteSeleccionado.persona.Id.ToString();
                        txtNombre.Text = clienteSeleccionado.persona.Nombre;
                        txtApellido.Text = clienteSeleccionado.persona.Apellido;
                        txtEmail.Text = clienteSeleccionado.persona.Email;
                        txtDni.Text = clienteSeleccionado.Dni.ToString();
                        txtFechaNac.Text = clienteSeleccionado.FechaNacimiento.ToString("yyyy-MM-dd");
                        txtDireccion.Text = clienteSeleccionado.direccion.ToString();

                        TelefonoNegocio negocioTel = new TelefonoNegocio();
                        List<Telefono> lista = negocioTel.BuscarTelefonos(clienteSeleccionado.persona.Id);
                        if (lista != null)
                        {
                            ddlTelefonos.DataSource = lista;
                            ddlTelefonos.DataValueField = "IdTelefono";
                            ddlTelefonos.DataTextField = "NumeroTelefono";
                            ddlTelefonos.DataBind();
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
        }

        public void DeshabilitarCampos()
        {
            txtId.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtEmail.Enabled = false;
            txtDni.Enabled = false;
            txtFechaNac.Enabled = false;
            txtDireccion.Enabled = false;
            btnEditarDireccion.Enabled = false;
            btnNuevaDireccion.Text = "Cambiar";
            btnNuevaDireccion.Enabled = false;
        }

        public void HabilitarCampos()
        {
            txtId.Enabled = false;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtEmail.Enabled = true;
            txtDni.Enabled = true;
            txtFechaNac.Enabled = true;
            txtDireccion.Enabled = false;
            ddlTelefonos.Enabled = true;
            btnEditarDireccion.Enabled = true;
            btnEditarDireccion.Visible = true;
            btnNuevaDireccion.Text = "Cambiar";
            btnNuevaDireccion.Enabled = true;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnAceptar.Visible = true;
            btnCancelar.Text = "Cancelar";
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx", false);
        }

        protected void btnEditarDireccion_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            long dni = long.Parse(Request.QueryString["dni"]);
            clienteSeleccionado = clienteNegocio.BuscarCliente(dni);
            Response.Redirect("GestionarDirecciones.aspx?dni=" + dni + "&id=" + clienteSeleccionado.direccion.Id);
        }

        protected void btnNuevaDireccion_Click(object sender, EventArgs e)
        {

        }
    }
}