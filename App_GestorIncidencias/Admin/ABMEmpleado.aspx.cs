using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias.Admin
{
    public partial class ABMempleado : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            txtLegajo.Enabled = false;
            
            if (!IsPostBack)
            {                
                EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
                long ultimoLegajo = empleadoNegocio.obtenerUltimoLegajo();
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

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
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
            if (rbActivo.Checked)
            {
                nuevo.Activo = true;
            }
            else
            {
                nuevo.Activo = false;
            }

            if (Request.QueryString["Legajo"] != null)
            {
                nuevo.Legajo = int.Parse(Request.QueryString["Legajo"]);
                negocio.modificar(nuevo);
            }
            else
            {
                negocio.agregar(nuevo);
            }
            
            Response.Redirect("~/Admin/Empleados.aspx");

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Empleados.aspx");
        }
    }
}