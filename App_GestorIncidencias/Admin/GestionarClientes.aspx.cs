﻿using Dominio;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias.Admin
{
    public partial class GestionarClientes : System.Web.UI.Page
    {
        public Cliente clienteSeleccionado;

        public Provincia provSeleccionada;
        
        public Pais paisSeleccionado;
        public List<Telefono> listaTelefonos { get; set; }
        public int ContadorTelefonos {get; set;}
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    btnEditar.Visible = false;
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

                    if (Request.QueryString["dni"] != null)
                    {
                        DeshabilitarCampos();
                        btnAceptar.Visible = false;
                        btnCancelar.Text = "Volver";
                        btnEditar.Visible = true;

                        ClienteNegocio clienteNegocio = new ClienteNegocio();
                        long dni = long.Parse(Request.QueryString["dni"]);
                        clienteSeleccionado = clienteNegocio.BuscarCliente(dni);
                        Session.Add("idPersona", clienteSeleccionado.persona.Id);

                        txtIdPersona.Text = clienteSeleccionado.persona.Id.ToString();
                        txtNombre.Text = clienteSeleccionado.persona.Nombre;
                        txtApellido.Text = clienteSeleccionado.persona.Apellido;
                        txtEmail.Text = clienteSeleccionado.persona.Email;
                        txtDni.Text = clienteSeleccionado.Dni.ToString();
                        txtFechaNac.Text = clienteSeleccionado.FechaNacimiento.ToString("yyyy-MM-dd");

                        DireccionNegocio direccionNegocio = new DireccionNegocio();
                        Direccion direSeleccionada = new Direccion();
                        long idDire = clienteSeleccionado.direccion.Id;
                        direSeleccionada = direccionNegocio.buscarDireccion(idDire);
                        txtIdDireccion.Text = direSeleccionada.Id.ToString();
                        txtCalle.Text = direSeleccionada.Calle;
                        txtNumero.Text = direSeleccionada.Numero.ToString();
                        txtLocalidad.Text = direSeleccionada.Localidad;
                        txtCP.Text = direSeleccionada.CodPostal;
                        ddlProvincias.SelectedValue = direSeleccionada.provincia.Id.ToString();
                        txtPais.Text = direSeleccionada.pais.Nombre;

                        CargarTelefonos();

                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
        }

        private void AgregarTelefonoPanel(string numeroTelefono)
        {
            TableRow row = new TableRow();

            row.Attributes["data-id"] = numeroTelefono; // Atributo personalizado para identificar la fila
            row.EnableViewState = true;

            // Celda del número de teléfono
            TableCell cellTelefono = new TableCell();
            TextBox txtTelefono = new TextBox();
            txtTelefono.Text = numeroTelefono;
            txtTelefono.CssClass = "form-control";
            cellTelefono.Controls.Add(txtTelefono);

            // Celda del botón eliminar
            TableCell cellEliminar = new TableCell();
            Button btnEliminarTelefono = new Button();
            btnEliminarTelefono.Text = "Eliminar";
            btnEliminarTelefono.CssClass = "btn btn-danger";
            btnEliminarTelefono.CommandArgument = numeroTelefono;
            btnEliminarTelefono.OnClientClick = $"guardarCommandArgument('{numeroTelefono}'); return false;";
            cellEliminar.Controls.Add(btnEliminarTelefono);

            // Agregar las celdas a la fila
            row.Cells.Add(cellTelefono);
            row.Cells.Add(cellEliminar);

            // Agregar la fila a la tabla de teléfonos en el panel
            tblTelefonos.Rows.Add(row);
        }

        public void DeshabilitarCampos()
        {
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDni.Enabled = false;
            txtFechaNac.ReadOnly = true;
            txtIdDireccion.ReadOnly = true;
            txtCalle.ReadOnly = true;
            txtNumero.ReadOnly = true;
            txtLocalidad.ReadOnly = true;
            txtCP.ReadOnly = true;
            ddlProvincias.Enabled = false;
            txtPais.ReadOnly = true;
            pnlTelefonos.Enabled = false;
            pnlTelefonos.Visible = false;

        }

        public void HabilitarCampos()
        {
            txtNombre.ReadOnly = false;
            txtApellido.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtFechaNac.ReadOnly = false;
            txtIdDireccion.ReadOnly = false;
            txtCalle.ReadOnly = false;
            txtNumero.ReadOnly = false;
            txtLocalidad.ReadOnly = false;
            txtCP.ReadOnly = false;
            pnlTelefonos.Visible = true;
            txtPais.ReadOnly = false;
            pnlTelefonos.Enabled = true;
            ddlProvincias.Enabled = true;
        }

        public void cargarPanelTelefonos()
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            long dni = long.Parse(Request.QueryString["dni"]);
            clienteSeleccionado = clienteNegocio.BuscarCliente(dni);
            TelefonoNegocio negocioTel = new TelefonoNegocio();
            List<Telefono> lista = negocioTel.BuscarTelefonos(clienteSeleccionado.persona.Id);
            if (lista != null)
            {
                armarListaPanel(lista);
            }
        }

        protected void armarListaPanel(List<Telefono> lista)
        {
            List<string> telefonos = new List<string>();
            foreach (Telefono t in lista)
            {
                telefonos.Add(t.NumeroTelefono.ToString());
            }
            foreach (string telefono in telefonos)
            {
                AgregarTelefonoPanel(telefono);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnAceptar.Visible = true;
            btnCancelar.Text = "Cancelar";

            btnEditar.Visible = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            PaisNegocio paisNegocio = new PaisNegocio();
            DireccionNegocio direccionNegocio = new DireccionNegocio();
            TelefonoNegocio telefonoNegocio = new TelefonoNegocio();


            //cliente
            cliente.persona = new Persona();
            cliente.persona.Nombre = txtNombre.Text;
            cliente.persona.Apellido = txtApellido.Text;
            cliente.persona.Email = txtEmail.Text;
            cliente.Dni = long.Parse(txtDni.Text);
            cliente.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
            cliente.Activo = true;

            //direccion

            cliente.direccion = new Direccion();
            cliente.direccion.Calle = txtCalle.Text;
            cliente.direccion.Numero = long.Parse(txtNumero.Text);
            cliente.direccion.Localidad = txtLocalidad.Text;
            cliente.direccion.CodPostal = txtCP.Text;

            cliente.direccion.provincia = new Provincia();
            cliente.direccion.provincia = provinciaNegocio.buscarProvincia(long.Parse(ddlProvincias.SelectedValue));

            cliente.direccion.pais = new Pais();
            cliente.direccion.pais = paisNegocio.buscarPais(cliente.direccion.provincia.IdPais);


            if (Request.QueryString["dni"] != null)
            {
                cliente.persona.Id = long.Parse(txtIdPersona.Text);
                GuardarTelefonos(cliente.persona.Id);
                cliente.direccion.Id = long.Parse(txtIdDireccion.Text);
                clienteNegocio.modificarCliente(cliente);
            }
            else
            {

                clienteNegocio.agregarCliente(cliente);
                cliente = clienteNegocio.BuscarCliente(cliente.Dni);
                GuardarTelefonos(cliente.persona.Id);
            }
            Response.Redirect("Clientes.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx", false);
        }

        protected void GuardarTelefonos(long idPersona)
        {
            List<long> telefonos = new List<long>();

            // Recorre las claves del formulario para capturar el array de valores "telefono[]"
            string[] telefonosArray = Request.Form.GetValues("telefono[]");
            if (telefonosArray != null)
            {
                foreach (string telefonoStr in telefonosArray)
                {
                    if (long.TryParse(telefonoStr, out long numTelefono))
                    {
                        telefonos.Add(numTelefono);
                    }
                }
            }


            if (telefonos.Count > 0)
            {
                Telefono telefono = new Telefono();
                telefono.persona = new Persona();
                TelefonoNegocio telefonoNegocio = new TelefonoNegocio();

                foreach (long nro in telefonos)
                {
                    telefono.persona.Id = idPersona;
                    telefono.NumeroTelefono = nro;

                    telefonoNegocio.agregarTelefono(telefono);

                }
            }
        }

        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //  usamos como contador el indice del elemento actual
                int contador = e.Item.ItemIndex + 1;

                // Encuentra el control Label dentro del Repeater
                Label lblTelefono = (Label)e.Item.FindControl("lblTelefono");
                if (lblTelefono != null)
                {
                    lblTelefono.Text = $"Teléfono {contador}";
                }
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

        protected void btnEliminarTel_Click(object sender, EventArgs e)
        {
            Session.Add("idTelefonoAEliminar", ((Button)sender).CommandArgument);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModalScript", "showModal();", true);
        }

        protected void btnEliminarConfirmado_Click(object sender, EventArgs e)
        {
            try
            {
                TelefonoNegocio telefonoNegocio = new TelefonoNegocio();
                int idTelefono = int.Parse(Session["idTelefonoAEliminar"].ToString());
                telefonoNegocio.eliminarTelefono(idTelefono);
                CargarTelefonos();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
            

        }

        protected void btnEditarTel_Click(object sender, EventArgs e)
        {
            Button btnEditarTel = (Button)sender;
            int idTelefono = int.Parse(btnEditarTel.CommandArgument);
            Session.Add("idTelEditado", idTelefono);

            // Mostrar el modal.
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModalScript", "showModalEdicion();", true);

        }

        protected void btnEditarConfirmado_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTelefonoEditado.Text))
            {
                Telefono telAux = new Telefono();
                int idTel = int.Parse(hiddenTelefonoEdicion.Value);
                long nuevoNumero = long.Parse(txtTelefonoEditado.Text);

                telAux.IdTelefono = idTel;
                telAux.NumeroTelefono = nuevoNumero;
                telAux.persona = new Persona();
                telAux.persona.Id = long.Parse(Session["idPersona"].ToString());

                TelefonoNegocio telefonoNegocio = new TelefonoNegocio();
                telefonoNegocio.editarTelefono(telAux);

                CargarTelefonos();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "errorModal", "alert('Debe ingresar un telefono.');", true);
            }
        }

        public void CargarTelefonos()
        {
            TelefonoNegocio negocioTel = new TelefonoNegocio();
            listaTelefonos = negocioTel.BuscarTelefonos(int.Parse(Session["IdPersona"].ToString()));
            if (listaTelefonos != null)
            {
                ContadorTelefonos = listaTelefonos.Count;
                repRepetidor.Visible = true;
                repRepetidor.DataSource = listaTelefonos;
                repRepetidor.DataBind();
            }
            else
            {
                repRepetidor.DataSource = null;
                repRepetidor.DataBind();
            }
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {   
            if(!Helper.validarSoloNumeros(txtDni.Text))
            ScriptManager.RegisterStartupScript(this, this.GetType(), "errorModal", "alert('Campo DNI debe ingresar solo numeros.');", true);
        }
    }
}