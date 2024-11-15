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
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtCliente.Enabled = false;
            lblValidacionNumero.Visible = false;
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
                    List <TipoIncidencia> incidencias = tipoNegocio.listar(true);
                    ddlTipoIncidencia.DataSource = incidencias;
                    ddlTipoIncidencia.DataValueField = "Id";
                    ddlTipoIncidencia.DataTextField = "Nombre";
                    ddlTipoIncidencia.DataBind();



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
                        txtUsuario.Text = seleccion.Usuario.ToString();
                        TxtDescripcion.Text = seleccion.Descripcion.ToString();
                        ddlEstado.SelectedValue = seleccion.Estado.Id.ToString();
                        ddlPrioridad.SelectedValue = seleccion.Prioridad.Id.ToString();
                        ddlTipoIncidencia.SelectedValue = seleccion.Tipo.Id.ToString();
                        txtFechaReclamo.Text = seleccion.FechaAlta.ToString("yyyy-MM-dd");

                        ComentarioNegocio Cnegocio = new ComentarioNegocio();
                        dgvComentarios.DataSource = Cnegocio.Listar(id);
                        dgvComentarios.DataBind();


                        txtId.ReadOnly = true;
                    }
                    else
                    {
                        EstadoNegocio estado = new EstadoNegocio();
                        List<Estado> estados = estado.listar(1);
                        ddlEstado.DataSource = estados;
                        ddlEstado.DataValueField = "Id";
                        ddlEstado.DataTextField = "Nombre";
                        ddlEstado.DataBind();
                    }

                }

            }
            catch (Exception ex)
            {

                Session.Add("Error al cargar DropDownList", ex);
                throw;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Incidencia incidencia = new Incidencia();
                IncidenciaNegocio negocio = new IncidenciaNegocio();
                incidencia.cliente.Dni = long.Parse(txtDniCliente.Text);
                incidencia.Usuario = int.Parse(txtUsuario.Text);
                incidencia.Descripcion = TxtDescripcion.Text;
                incidencia.Estado = new Estado();
                incidencia.Estado.Id = 1;
                incidencia.Prioridad = new Prioridad();
                incidencia.Prioridad.Id = int.Parse(ddlPrioridad.SelectedValue);
                incidencia.Tipo = new TipoIncidencia();
                incidencia.Tipo.Id = int.Parse(ddlTipoIncidencia.SelectedValue);
                incidencia.FechaAlta = DateTime.Now;
                negocio.AgregarIncidencia(incidencia);
                Response.Redirect("IncidenciaListar.aspx", false);

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
                
                if (aux != null) 
                {
                    txtCliente.Text = aux.ToString();
                    txtEmail.Text = aux.persona.Email;
                    txtDireccion.Text = aux.direccion.ToString();
                }
                else
                {
                    //modal para ir a la creacion de cliente.
                }
            }
            else
            {
                lblValidacionNumero.Visible = true;
            }
        }
    }
}