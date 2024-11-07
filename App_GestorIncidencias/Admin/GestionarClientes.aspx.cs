using Dominio;
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
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    hiddenTelefono.Value = "";
                    btnEditar.Visible = false;
                    ProvinciaNegocio negocio = new ProvinciaNegocio();
                    ddlProvincias.DataSource = negocio.listarProvincias(true);
                    ddlProvincias.DataValueField = "Id";
                    ddlProvincias.DataTextField = "Nombre";
                    ddlProvincias.DataBind();

                    long idProv = long.Parse(ddlProvincias.SelectedValue);
                    Provincia prov = negocio.buscarProvincia(idProv);
                    txtPais.Text = prov.pais.Nombre;

                    ddlTelefonos.Visible = false;

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
                        ddlProvincias.SelectedValue = direSeleccionada.provincia.Nombre;
                        txtPais.Text = direSeleccionada.provincia.pais.Nombre;

                        pnlTelefonos.Visible = true;
                        

                        TelefonoNegocio negocioTel = new TelefonoNegocio();
                        List<Telefono> lista = negocioTel.BuscarTelefonos(clienteSeleccionado.persona.Id);
                        if (lista != null)
                        {
                            armarListaPanel(lista);

                            pnlTelefonos.Enabled = false;
                        }

                    }
                }
                else
                {
                    if (hiddenTelefono.Value == "-1")
                    {
                        //limpiar el campo
                        hiddenTelefono.Value = string.Empty;

                        TelefonoNegocio negocioTel = new TelefonoNegocio();
                        List<Telefono> lista = negocioTel.BuscarTelefonos(long.Parse(Session["idPersona"].ToString()));

                        if (lista != null)
                        {
                            armarListaPanel(lista);

                            pnlTelefonos.Enabled = false;
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
            txtDni.ReadOnly = true;
            txtFechaNac.ReadOnly = true;
            txtIdDireccion.ReadOnly = true;
            txtCalle.ReadOnly = true;
            txtNumero.ReadOnly = true;
            txtLocalidad.ReadOnly = true;
            txtCP.ReadOnly = true;
            ddlProvincias.Enabled = false;
            txtPais.ReadOnly = true;
            pnlTelefonos.Enabled = false;

        }

        public void HabilitarCampos()
        {
            txtNombre.ReadOnly = false;
            txtApellido.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDni.ReadOnly = false;
            txtFechaNac.ReadOnly = false;
            txtIdDireccion.ReadOnly = false;
            txtCalle.ReadOnly = false;
            txtNumero.ReadOnly = false;
            txtLocalidad.ReadOnly = false;
            txtCP.ReadOnly = false;
            pnlTelefonos.Visible = true;
            txtPais.ReadOnly = false;
            pnlTelefonos.Enabled = true;

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

            cargarPanelTelefonos();
            btnEditar.Visible = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //Cliente cliente = new Cliente();
            //ClienteNegocio clienteNegocio = new ClienteNegocio();
            //ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            //DireccionNegocio direccionNegocio = new DireccionNegocio();
            //TelefonoNegocio telefonoNegocio = new TelefonoNegocio();


            ////cliente
            //cliente.persona = new Persona();
            //cliente.persona.Nombre = txtNombre.Text;
            //cliente.persona.Apellido = txtApellido.Text;
            //cliente.persona.Email = txtEmail.Text;
            //cliente.Dni = long.Parse(txtDni.Text);
            //cliente.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);

            ////direccion

            //cliente.direccion = new Direccion();
            //cliente.direccion.Calle = txtCalle.Text;
            //cliente.direccion.Numero = long.Parse(txtNumero.Text);
            //cliente.direccion.Localidad = txtLocalidad.Text;
            //cliente.direccion.CodPostal = txtCP.Text;

            //cliente.direccion.provincia = new Provincia();
            //cliente.direccion.provincia = provinciaNegocio.buscarProvincia(long.Parse(ddlProvincias.SelectedValue));
            //cliente.direccion.Activo = true;
            

            //if (Request.QueryString["dni"] != null)
            //{
            //    //cliente.persona.Id = long.Parse(txtIdPersona.Text);
            //    //GuardarTelefonos(cliente.persona.Id);
            //    //cliente.direccion.Id = long.Parse(txtIdDireccion.Text);
            //    //direccionNegocio.modificarDireccion(cliente.direccion);
            //    //clienteNegocio.modificarCliente(cliente);

            //}
            //else
            //{
                
            //    int idDireccion = direccionNegocio.agregarDireccion(cliente.direccion);
            //    long idDire = (long)idDireccion;
            //    Direccion direauxiliar = new Direccion();
            //    direauxiliar = direccionNegocio.buscarDireccion(idDire);
            //    int idClienteCreado = clienteNegocio.agregarCliente(cliente);
            //    GuardarTelefonos(cliente.persona.Id);
            //    Response.Redirect("Clientes.aspx", false);

            //}
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx", false);
        }

        protected void GuardarTelefonos(long idPersona)
        {
            List<long> telefonos = new List<long>();
            foreach (string key in Request.Form.Keys)
            {
                if (key.Contains("telefono"))
                {
                    if (long.TryParse(Request.Form[key], out long numeroTelefono))
                    {
                        telefonos.Add(numeroTelefono);
                    }
                }
            }


            if(telefonos.Count > 0)
            {
                Telefono telefono = new Telefono();
                TelefonoNegocio telefonoNegocio = new TelefonoNegocio();

                foreach (long nro in telefonos)
                {
                    telefono.persona.Id = idPersona;
                    telefono.NumeroTelefono = nro;

                    telefonoNegocio.agregarTelefono(telefono);

                }
            }
        }

        protected void btnEliminarConfirmado_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hiddenTelefono.Value))
            {
                long numeroTelefono = long.Parse(hiddenTelefono.Value);

                long idPersona = long.Parse(Session["idPersona"].ToString());

                TelefonoNegocio negocio = new TelefonoNegocio();
                negocio.eliminarTelefono(numeroTelefono, idPersona);

                List<Telefono> lista = negocio.BuscarTelefonos(idPersona);
                if (lista != null)
                {
                    armarListaPanel(lista);

                    pnlTelefonos.Enabled = false;
                }

            }

        }
    }
}