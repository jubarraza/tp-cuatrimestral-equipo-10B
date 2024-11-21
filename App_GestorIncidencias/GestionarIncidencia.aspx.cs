using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace App_GestorIncidencias
{
    public partial class GestionarIncidencia : System.Web.UI.Page
    {
        public List<Telefono> listaTelefonos { get; set; }
        public int ContadorTelefonos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Helper.SessionActiva(Session["usuario"]))
                {
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    txtId.Enabled = false;
                    deshabilitarCamposCliente();
                    string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                    if (!IsPostBack)
                    {
                        PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
                        List<Prioridad> prioridades = prioridadNegocio.listar();
                        ddlPrioridad.DataSource = prioridades;
                        ddlPrioridad.DataValueField = "Id";
                        ddlPrioridad.DataTextField = "Nombre";
                        ddlPrioridad.DataBind();

                        TipoIncidenciaNegocio tipoNegocio = new TipoIncidenciaNegocio();
                        List<TipoIncidencia> incidencias = tipoNegocio.listar(true);
                        ddlTipoIncidencia.DataSource = incidencias;
                        ddlTipoIncidencia.DataValueField = "Id";
                        ddlTipoIncidencia.DataTextField = "Nombre";
                        ddlTipoIncidencia.DataBind();

                        EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
                        List<Empleado> empleados = empleadoNegocio.listar(true);
                        ddlUsuario.DataSource = empleados;
                        ddlUsuario.DataValueField = "Legajo";
                        ddlUsuario.DataTextField = "NombreCompleto";
                        ddlUsuario.DataBind();

                        Empleado user = (Empleado)Session["usuario"];
                        ddlUsuario.SelectedValue = user.Legajo.ToString();
                        ddlUsuario.Enabled = false;

                        int tipoUsuario = Helper.consultaTipoUsuario(user);
                        if (tipoUsuario != 3)
                        {
                            btnReasignar.Visible = true;
                        }

                        txtFechaReclamo.Text = DateTime.Today.ToString("yyyy-MM-dd");
                        txtFechaReclamo.ReadOnly = true;

                        btnEditar.Visible = false;
                        btnEditarCliente.Visible = false;
                        contComentarios.Visible = false;

                        botonesCierre.Visible = false;


                        if (id != "")
                        {
                            IncidenciaNegocio negocio = new IncidenciaNegocio();
                            EstadoNegocio estado = new EstadoNegocio();
                            List<Estado> estados = estado.listar();
                            ddlEstado.DataSource = estados;
                            ddlEstado.DataValueField = "Id";
                            ddlEstado.DataTextField = "Nombre";
                            ddlEstado.DataBind();

                            Incidencia seleccion = (negocio.listar(id)[0]);

                            if (seleccion.Empleado.Legajo.ToString() == user.Legajo.ToString() || user.tipoUsuario.IdTipoUsuario != 3)
                            {
                                txtId.Text = id;
                                txtDniCliente.Enabled = false;
                                txtDniCliente.Text = seleccion.cliente.Dni.ToString();
                                txtCliente.Text = seleccion.cliente.ToString();
                                Session.Add("IdPersona", seleccion.cliente.persona.Id);
                                CargarTelefonos();
                                txtEmail.Text = seleccion.cliente.persona.Email;
                                txtDireccion.Text = seleccion.cliente.direccion.ToString();

                                deshabilitarCamposIncidencia();

                                ddlUsuario.SelectedValue = seleccion.Empleado.Legajo.ToString();
                                TxtDescripcion.Text = seleccion.Descripcion.ToString();
                                ddlEstado.SelectedValue = seleccion.Estado.Id.ToString();
                                ddlPrioridad.SelectedValue = seleccion.Prioridad.Id.ToString();
                                ddlTipoIncidencia.SelectedValue = seleccion.Tipo.Id.ToString();
                                txtFechaReclamo.Text = seleccion.FechaAlta.ToString("yyyy-MM-dd");
                                txtFechaReclamo.Enabled = false;

                                ComentarioNegocio Cnegocio = new ComentarioNegocio();
                                dgvComentarios.DataSource = Cnegocio.Listar(id);
                                dgvComentarios.DataBind();

                                contComentarios.Visible = true;
                                txtId.ReadOnly = true;

                                if (seleccion.Estado.Id == 4 || seleccion.Estado.Id == 5)
                                {
                                    botonesCierre.Visible = false;
                                    btnEditar.Visible = false;
                                    BtnComentar.Visible = false;
                                    btnReasignar.Visible = false;
                                }
                                else
                                {
                                    botonesCierre.Visible = true;
                                }

                                if (Request.QueryString["edited"] == 1.ToString())
                                {
                                    seleccion.Estado.Id = 3;
                                    ddlEstado.SelectedValue = seleccion.Estado.Id.ToString();
                                    negocio.ModificarIncidencia(seleccion);
                                }
                            }
                            else
                            {
                                Session.Add("error", "No posee permisos para poder visualizar la incidencia.");
                                Response.Redirect("~/PageError.aspx", false);
                            }
                        }
                        else
                        {
                            EstadoNegocio estado = new EstadoNegocio();
                            List<Estado> estados = estado.listar(1);
                            ddlEstado.DataSource = estados;
                            ddlEstado.DataValueField = "Id";
                            ddlEstado.DataTextField = "Nombre";
                            ddlEstado.DataBind();

                            if (Request.QueryString["dni"] != null)
                            {
                                cargarClienteEditado();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void deshabilitarCamposIncidencia()
        {
            btnEditar.Visible = true;
            btnAceptar.Visible = false;
            btnCambiarCliente.Visible = false;
            btnEditarCliente.Visible = false;
            TxtDescripcion.ReadOnly = true;
            ddlUsuario.Enabled = false;
            ddlTipoIncidencia.Enabled = false;
            ddlPrioridad.Enabled = false;
            txtFechaReclamo.ReadOnly = true;

        }

        protected void habilitarCamposIncidencia()
        {
            btnEditar.Visible = false;
            btnAceptar.Visible = true;
            TxtDescripcion.ReadOnly = false;
            ddlTipoIncidencia.Enabled = true;
            ddlPrioridad.Enabled = true;
            txtFechaReclamo.ReadOnly = false;
            if (string.IsNullOrEmpty(txtDniCliente.Text))
            {
                btnCambiarCliente.Visible = false;
                btnEditarCliente.Visible = false;
            }
            else
            {
                btnCambiarCliente.Visible = true;
                btnEditarCliente.Visible = true;
            }
        }

        protected void cargarClienteEditado()
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente aux = clienteNegocio.BuscarCliente(long.Parse(Request.QueryString["dni"]));

                Session.Add("IdPersona", aux.persona.Id);
                txtDniCliente.Text = aux.Dni.ToString();
                txtCliente.Text = aux.ToString();
                txtEmail.Text = aux.persona.Email;
                txtDireccion.Text = aux.direccion.ToString();
                CargarTelefonos();
                btnEditarCliente.Visible = true;
                btnCambiarCliente.Visible = true;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
            

        }

        protected bool validarCamposObligatorios()
        {
            bool bandera = true;

            if (string.IsNullOrEmpty(TxtDescripcion.Text))
            {
                lblValidacionDescripcion.Visible = true;
                bandera = false;
            }
            if (string.IsNullOrEmpty(txtDniCliente.Text))
            {
                lblValidacionDniRequerido.Visible = true;
                btnCambiarCliente.Visible = false;
                btnEditarCliente.Visible = false;
                bandera = false;

            }

            return bandera;

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCamposObligatorios())
                {
                    Incidencia incidencia = new Incidencia();
                    IncidenciaNegocio negocio = new IncidenciaNegocio();
                    incidencia.cliente = new Cliente();
                    incidencia.cliente.Dni = long.Parse(txtDniCliente.Text);
                    incidencia.Empleado = new Empleado();
                    incidencia.Empleado.Legajo = long.Parse(ddlUsuario.SelectedValue);
                    incidencia.Descripcion = TxtDescripcion.Text;
                    incidencia.Estado = new Estado();
                    incidencia.Prioridad = new Prioridad();
                    incidencia.Prioridad.Id = int.Parse(ddlPrioridad.SelectedValue);
                    incidencia.Tipo = new TipoIncidencia();
                    incidencia.Tipo.Id = int.Parse(ddlTipoIncidencia.SelectedValue);
                    incidencia.FechaAlta = DateTime.Now;

                    if (Request.QueryString["Id"] != null)
                    {

                        incidencia.Id = int.Parse(Request.QueryString["Id"]);
                        incidencia.Estado.Id = 3;
                        negocio.ModificarIncidencia(incidencia);
                    }
                    else
                    {
                        incidencia.Estado.Id = 1;
                        negocio.AgregarIncidencia(incidencia);
                        incidencia.Id = negocio.ObtenerUltimoIdIncidencia();
                        incidencia = negocio.buscarIncidencia(incidencia.Id);
                        EnviarCorreoCreacion(incidencia);
                    }

                    Response.Redirect("~/IncidenciaListar.aspx", false);
                }
                else
                {
                    habilitarCamposIncidencia();

                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);

            }
        }

        protected void dgvComentarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvComentarios.SelectedDataKey.Value.ToString();
            Response.Redirect("~/GestionarComentario.aspx?Id=" + Id);
        }

        protected void BtnComentar_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
            Response.Redirect("~/GestionarComentario.aspx?cod=" + id);
        }

        protected void txtDniCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Helper.validarSoloNumeros(txtDniCliente.Text))
                {
                    ClienteNegocio clienteNegocio = new ClienteNegocio();

                    if (string.IsNullOrWhiteSpace(txtDniCliente.Text))
                    {
                        lblValidacionDniRequerido.Visible = true;
                        return;
                    }

                    Cliente aux = clienteNegocio.BuscarCliente(long.Parse(txtDniCliente.Text));

                    if (aux.Dni != 0)
                    {
                        Session.Add("IdPersona", aux.persona.Id);
                        txtCliente.Text = aux.ToString();
                        txtEmail.Text = aux.persona.Email;
                        txtDireccion.Text = aux.direccion.ToString();
                        CargarTelefonos();
                        txtDniCliente.Enabled = false;
                        btnEditarCliente.Visible = true;
                        btnCambiarCliente.Visible = true;

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showModalScriptEl", "showModal();", true);
                    }
                }
                else
                {
                    lblValidacionNumero.Visible = true;
                    txtDniCliente.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
            
        }

        public void CargarTelefonos()
        {
            try
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
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }

        }

        protected void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                Response.Redirect("~/GestionarClientes.aspx?dni=" + txtDniCliente.Text + "&from=incidencia&idIncidencia=" + id.ToString(), false);
            }
            else
            {
                Response.Redirect("~/GestionarClientes.aspx?dni=" + txtDniCliente.Text + "&from=incidencia", false);
            }

        }

        protected void deshabilitarCamposCliente()
        {
            txtCliente.Enabled = false;
            lblValidacionNumero.Visible = false;
            btnEditarCliente.Visible = false;
            btnCambiarCliente.Visible = false;
            txtEmail.Enabled = false;
            txtDireccion.Enabled = false;
        }

        protected void habilitarCamposCliente()
        {
            txtCliente.ReadOnly = true;
            lblValidacionNumero.Visible = false;
            txtDniCliente.Enabled = true;
            txtEmail.ReadOnly = true;
            txtDireccion.ReadOnly = true;
        }

        protected void btnCambiarCliente_Click(object sender, EventArgs e)
        {
            txtDniCliente.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            habilitarCamposCliente();
        }

        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                Response.Redirect("~/GestionarClientes.aspx?from=incidencia&idIncidencia=" + id.ToString() + "&newDni=" + txtDniCliente.Text, false);
            }
            else
            {
                Response.Redirect("~/GestionarClientes.aspx?from=incidencia&newDni=" + txtDniCliente.Text, false);
            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarCamposIncidencia();
            btnEditar.Visible = false;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/IncidenciaListar.aspx", false);
        }

        protected void btnReasignar_Click(object sender, EventArgs e)
        {
            ddlUsuario.Enabled = true;
            btnReasignar.Enabled = false;
            btnGuardarIncidencia.Visible = true;
            btnCancelar.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ddlUsuario.Enabled = false;
            btnReasignar.Enabled = true;
            btnGuardarIncidencia.Visible = false;
            btnCancelar.Visible = false;
        }

        protected void btnGuardarIncidencia_Click(object sender, EventArgs e)
        {
            try
            {
                IncidenciaNegocio negocio = new IncidenciaNegocio();

                string id = Request.QueryString["Id"];
                if (id != null)
                {
                    Incidencia seleccion = (negocio.listar(id)[0]);
                    seleccion.Empleado.Legajo = long.Parse(ddlUsuario.SelectedValue);
                    seleccion.Estado.Id = 2;
                    negocio.ModificarIncidencia(seleccion);
                    ddlEstado.SelectedValue = seleccion.Estado.Id.ToString();
                }

                ddlUsuario.Enabled = false;
                btnReasignar.Enabled = true;
                btnGuardarIncidencia.Visible = false;
                btnCancelar.Visible = false;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        private void EnviarCorreoCreacion(Incidencia inc)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("soporte10bstore@gmail.com");
                correo.To.Add(inc.cliente.persona.Email);
                correo.Subject = $@"Soporte 10bStore - Confirmación de creacion de Reclamo #{inc.Id.ToString()}";
                correo.Body = $@"
                                    <html>
                                    <body>
                                        <h2>¡Gracias por contactarte con el Soporte de 10bStore!</h2>
                                        <p> Hola {inc.cliente.persona.Nombre} {inc.cliente.persona.Apellido},</p>
                                        <p>Le confirmamos que su reclamo ha quedado registrado correctamente con el numero <strong>#{inc.Id.ToString()}</strong>.</p>
                                        <p>Nuestro equipo se estará contactando con usted en cuanto tengamos novedades.</p>
                                        <hr/>
                                        <p><small>Este es un mensaje automático, por favor no responda a este correo.</small></p>
                                    </body>
                                    </html>";
                correo.IsBodyHtml = true;

                // Enviar el correo usando la configuración del web.config
                SmtpClient smtp = new SmtpClient();
                smtp.Send(correo);
                Console.WriteLine("Correo enviado a " + inc.cliente.persona.Email);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }

        private void EnviarCorreoCierre(Incidencia inc)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("soporte10bstore@gmail.com");
                correo.To.Add(inc.cliente.persona.Email);
                correo.Subject = $@"Soporte 10bStore - Confirmación de cierre de Reclamo #{inc.Id.ToString()}";
                correo.Body = $@"
                                    <html>
                                    <body>
                                        <h2>Confirmacion de cierre de Reclamo</h2>
                                        <p> Hola {inc.cliente.persona.Nombre} {inc.cliente.persona.Apellido},</p>
                                        <p>Le confirmamos que su reclamo se ha cerrado con el siguiente comentario:</p>
                                        <p><strong><em>{inc.Resolucion}</em></strong></p>
                                        <p>Si tiene algun inconveniente con la resolución por favor contactese nuevamente indicando el numero de Reclamo.</p>
                                        <p>Quedamos a disposicion ante cualquier consulta adicional.</p>
                                        <h4>Equipo de Soporte 10bStore</h4>
                                        <hr/>
                                        <p><small>Este es un mensaje automático, por favor no responda a este correo.</small></p>
                                    </body>
                                    </html>";
                correo.IsBodyHtml = true;

                // Enviar el correo usando la configuración del web.config
                SmtpClient smtp = new SmtpClient();
                smtp.Send(correo);
                Console.WriteLine("Correo enviado a " + inc.cliente.persona.Email);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }


        protected void btnGuardarResolucion_Click(object sender, EventArgs e)
        {
            try
            {
                Incidencia incidencia = new Incidencia();
                IncidenciaNegocio negocio = new IncidenciaNegocio();

                if (Request.QueryString["Id"] != null)
                {
                    string Id = Request.QueryString["Id"];
                    incidencia.Id = int.Parse(Id);

                    incidencia.cliente = new Cliente();
                    incidencia.cliente.Dni = long.Parse(txtDniCliente.Text);
                    incidencia.Empleado = new Empleado();
                    incidencia.Empleado.Legajo = long.Parse(ddlUsuario.SelectedValue);
                    incidencia.Descripcion = TxtDescripcion.Text;
                    incidencia.Estado = new Estado();
                    incidencia.Estado.Id = 4;
                    incidencia.Prioridad = new Prioridad();
                    incidencia.Prioridad.Id = int.Parse(ddlPrioridad.SelectedValue);
                    incidencia.Tipo = new TipoIncidencia();
                    incidencia.Tipo.Id = int.Parse(ddlTipoIncidencia.SelectedValue);
                    incidencia.FechaAlta = DateTime.Parse(txtFechaReclamo.Text);
                    incidencia.FechaCierre = DateTime.Now;
                    incidencia.Resolucion = txtComentarioResolucion.Text;

                    negocio.ModificarIncidencia(incidencia);
                    incidencia = negocio.buscarIncidencia(incidencia.Id);
                }
                ddlEstado.SelectedValue = incidencia.Estado.Id.ToString();
                botonesCierre.Visible = false;
                btnEditar.Visible = false;
                BtnComentar.Visible = false;
                btnReasignar.Visible = false;

                EnviarCorreoCierre(incidencia);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void btnGuardarCierre_Click(object sender, EventArgs e)
        {
            try
            {
                Incidencia incidencia = new Incidencia();
                IncidenciaNegocio negocio = new IncidenciaNegocio();

                if (Request.QueryString["Id"] != null)
                {
                    string Id = Request.QueryString["Id"];
                    incidencia.Id = int.Parse(Id);

                    incidencia.cliente = new Cliente();
                    incidencia.cliente.Dni = long.Parse(txtDniCliente.Text);
                    incidencia.Empleado = new Empleado();
                    incidencia.Empleado.Legajo = long.Parse(ddlUsuario.SelectedValue);
                    incidencia.Descripcion = TxtDescripcion.Text;
                    incidencia.Estado = new Estado();
                    incidencia.Estado.Id = 5;
                    incidencia.Prioridad = new Prioridad();
                    incidencia.Prioridad.Id = int.Parse(ddlPrioridad.SelectedValue);
                    incidencia.Tipo = new TipoIncidencia();
                    incidencia.Tipo.Id = int.Parse(ddlTipoIncidencia.SelectedValue);
                    incidencia.FechaAlta = DateTime.Parse(txtFechaReclamo.Text);
                    incidencia.FechaCierre = DateTime.Now;
                    incidencia.Resolucion = txtComentarioCierre.Text;

                    negocio.ModificarIncidencia(incidencia);
                    incidencia = negocio.buscarIncidencia(incidencia.Id);
                }
                ddlEstado.SelectedValue = incidencia.Estado.Id.ToString();
                botonesCierre.Visible = false;
                btnEditar.Visible = false;
                BtnComentar.Visible = false;
                btnReasignar.Visible = false;
                EnviarCorreoCierre(incidencia);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
            
        }
    }
}