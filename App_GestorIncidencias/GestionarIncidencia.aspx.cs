using System;
using System.Collections.Generic;
using System.Linq;
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
            txtId.Enabled = false;
            deshabilitarCamposCliente();

            try
            {
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
                        txtId.Text = id;
                        txtDniCliente.Text = seleccion.cliente.Dni.ToString();
                        txtCliente.Text = seleccion.cliente.ToString();
                        Session.Add("IdPersona", seleccion.cliente.persona.Id);
                        CargarTelefonos();
                        txtEmail.Text = seleccion.cliente.persona.Email;
                        txtDireccion.Text = seleccion.cliente.direccion.ToString();

                        deshabilitarCamposIncidencia();
                        
                        txtLegajoEmpleado.Text = seleccion.Empleado.Legajo.ToString();
                        TxtDescripcion.Text = seleccion.Descripcion.ToString();
                        ddlEstado.SelectedValue = seleccion.Estado.Id.ToString();
                        ddlPrioridad.SelectedValue = seleccion.Prioridad.Id.ToString();
                        ddlTipoIncidencia.SelectedValue = seleccion.Tipo.Id.ToString();
                        txtFechaReclamo.Text = seleccion.FechaAlta.ToString("yyyy-MM-dd");

                        ComentarioNegocio Cnegocio = new ComentarioNegocio();
                        dgvComentarios.DataSource = Cnegocio.Listar(id);
                        dgvComentarios.DataBind();

                        contComentarios.Visible = true;
                        txtId.ReadOnly = true;

                        botonesCierre.Visible = true;
                    }
                    else
                    {
                        EstadoNegocio estado = new EstadoNegocio();
                        List<Estado> estados = estado.listar(1);
                        ddlEstado.DataSource = estados;
                        ddlEstado.DataValueField = "Id";
                        ddlEstado.DataTextField = "Nombre";
                        ddlEstado.DataBind();

                        if(Request.QueryString["dni"] != null)
                        {
                            cargarClienteEditado();
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                Session.Add("Error al cargar DropDownList", ex);
                throw;
            }
        }

        protected void deshabilitarCamposIncidencia()
        {
            btnEditar.Visible = true;
            btnAceptar.Visible = false;
            btnCambiarCliente.Visible = false;
            btnEditarCliente.Visible = false;
            TxtDescripcion.ReadOnly = true;
            txtLegajoEmpleado.ReadOnly = true;
            ddlTipoIncidencia.Enabled = false;
            ddlPrioridad.Enabled = false;
            txtFechaReclamo.ReadOnly = true;
            
        }

        protected void habilitarCamposIncidencia()
        {
            btnEditar.Visible = false;
            btnAceptar.Visible = true;
            TxtDescripcion.ReadOnly = false;
            txtLegajoEmpleado.ReadOnly = false;
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

        protected bool validarCamposObligatorios()
        {
            bool bandera = true;

            if (string.IsNullOrEmpty(TxtDescripcion.Text))
            {
                lblValidacionDescripcion.Visible = true;
                bandera = false;
            }
            if (string.IsNullOrEmpty(txtLegajoEmpleado.Text))
            {
                lblValidacionUsuario.Visible = true;
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
                    incidencia.Empleado.Legajo = long.Parse(txtLegajoEmpleado.Text);
                    incidencia.Descripcion = TxtDescripcion.Text;
                    incidencia.Estado = new Estado();
                    incidencia.Estado.Id = 1;
                    incidencia.Prioridad = new Prioridad();
                    incidencia.Prioridad.Id = int.Parse(ddlPrioridad.SelectedValue);
                    incidencia.Tipo = new TipoIncidencia();
                    incidencia.Tipo.Id = int.Parse(ddlTipoIncidencia.SelectedValue);
                    incidencia.FechaAlta = DateTime.Now;

                    if (Request.QueryString["Id"] != null)
                    {

                        incidencia.Id = int.Parse(Request.QueryString["Id"]);
                        negocio.ModificarIncidencia(incidencia);
                    }
                    else
                    {
                        negocio.AgregarIncidencia(incidencia);
                    }

                    Response.Redirect("IncidenciaListar.aspx", false);
                }
                else
                {
                    habilitarCamposIncidencia();
                    
                }

            }
            catch (Exception ex)
            {
                Session.Add("PageError.aspx", ex);

            }
        }

        protected void dgvComentarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvComentarios.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionarComentario.aspx?Id=" + Id);
        }

        protected void BtnComentar_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
            Response.Redirect("GestionarComentario.aspx?cod=" + id);
        }

        protected void txtDniCliente_TextChanged(object sender, EventArgs e)
        {
            if (Helper.validarSoloNumeros(txtDniCliente.Text))
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente aux = clienteNegocio.BuscarCliente(long.Parse(txtDniCliente.Text));

                if (aux.Dni != 0)
                {
                    Session.Add("IdPersona", aux.persona.Id);
                    txtCliente.Text = aux.ToString();
                    txtEmail.Text = aux.persona.Email;
                    txtDireccion.Text = aux.direccion.ToString();
                    CargarTelefonos();
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
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
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
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }

        }

        protected void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                Response.Redirect("~/Admin/GestionarClientes.aspx?dni=" + txtDniCliente.Text + "&from=incidencia&idIncidencia=" + id.ToString(), false);
            }
            else
            {
                Response.Redirect("~/Admin/GestionarClientes.aspx?dni=" + txtDniCliente.Text + "&from=incidencia", false);
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

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            habilitarCamposCliente();
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
                Response.Redirect("~/Admin/GestionarClientes.aspx?from=incidencia&idIncidencia=" + id.ToString() + "&newDni=" + txtDniCliente.Text, false);
            }
            else
            {
                Response.Redirect("~/Admin/GestionarClientes.aspx?from=incidencia&newDni=" + txtDniCliente.Text, false);
            }
            
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarCamposIncidencia();
            btnEditar.Visible = false;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncidenciaListar.aspx", false);
        }
    }
}