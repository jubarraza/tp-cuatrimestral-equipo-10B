using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias.Admin
{
    public partial class GestionarEmpleado : System.Web.UI.Page
    {
        public void HabilitarCampos(bool habilitar)
        {          
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            ddlTipoUsuario.Enabled = habilitar;
            txtFechaIngreso.Enabled = habilitar;
            txtUserPassword.Enabled = habilitar;
            btnEliminar.Enabled = habilitar;            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {         
                txtLegajo.Enabled = false;
            
                if (!IsPostBack)
                {                
                    EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
                    long ultimoLegajo = empleadoNegocio.ObtenerUltimoLegajo();
                    txtLegajo.Text = ultimoLegajo.ToString();
                    TipoUsuarioNegocio tipoNegocio = new TipoUsuarioNegocio();
                    List<TipoUsuario> lista = tipoNegocio.listar();              

                    ddlTipoUsuario.DataSource = lista;
                    ddlTipoUsuario.DataValueField = "IdTipoUsuario";
                    ddlTipoUsuario.DataTextField = "Tipo";
                    ddlTipoUsuario.DataBind();
                }
                string legajo = Request.QueryString["Legajo"] != null ? Request.QueryString["Legajo"].ToString() : "";
                if (legajo != "" && !IsPostBack)
                {
                    btnAceptar.Text = "Guardar";
                    btnAceptar.CssClass = "btn btn-primary me-md-2";
                    EmpleadoNegocio negocio = new EmpleadoNegocio();
                    Empleado seleccionado = negocio.listar(legajo)[0];
                    Session.Add("empleadoSeleccionado", seleccionado);
                    txtNombre.Text = seleccionado.persona.Nombre;
                    txtApellido.Text = seleccionado.persona.Apellido;
                    txtEmail.Text = seleccionado.persona.Email;
                    txtLegajo.Text = seleccionado.Legajo.ToString();
                    ddlTipoUsuario.SelectedValue = seleccionado.tipoUsuario.Tipo.ToString();
                    txtFechaIngreso.Text = seleccionado.FechaIngreso.ToString("yyyy-MM-dd");
                    txtUserPassword.Text = seleccionado.UserPassword;
                    bool activo = seleccionado.Activo;
                    if(activo)
                    {
                        rbActivo.Checked = activo;
                    }
                    else
                    {
                        rbInactivo.Checked = !activo;
                    }
                    HabilitarCampos(activo);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try 
            { 
                EmpleadoNegocio negocio = new EmpleadoNegocio();
                Empleado nuevo = new Empleado();
                nuevo.persona = new Persona();
                nuevo.persona.Nombre = txtNombre.Text;
                nuevo.persona.Apellido = txtApellido.Text;
                nuevo.persona.Email = txtEmail.Text;
                nuevo.tipoUsuario = new TipoUsuario();
                nuevo.tipoUsuario.IdTipoUsuario = int.Parse(ddlTipoUsuario.SelectedValue);
                nuevo.FechaIngreso = DateTime.Parse(txtFechaIngreso.Text);
                nuevo.UserPassword = txtUserPassword.Text;
                if (rbActivo.Checked || rbInactivo.Checked)
                {
                    nuevo.Activo = rbActivo.Checked;
                    lblError.Visible = false;
                }
                else
                {
                    lblError.Visible = true;
                    return;
                }

                if (Request.QueryString["Legajo"] != null)
                {
                    nuevo.Legajo = int.Parse(Request.QueryString["Legajo"]);
                    negocio.Modificar(nuevo);
                }
                else
                {
                    negocio.Agregar(nuevo);
                }           
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }

            Response.Redirect("~/Admin/Empleados.aspx");

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Empleados.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EmpleadoNegocio negocio = new EmpleadoNegocio();
                long legajo = long.Parse(Request.QueryString["Legajo"]);
                negocio.Eliminar(legajo);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }

            Response.Redirect("~/Admin/Empleados.aspx");

        }

        protected void rbActivo_CheckedChanged(object sender, EventArgs e)
        {
            bool habilitar = rbActivo.Checked;
            HabilitarCampos(habilitar);       
        }

    }
}