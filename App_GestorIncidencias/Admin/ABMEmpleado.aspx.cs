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
            string legajo = Request.QueryString["Legajo"] != null ? Request.QueryString["Legajo"].ToString() : "";
            if (!IsPostBack && legajo == "")
            {                
                EmpleadoNegocio negocio = new EmpleadoNegocio();
                long ultimoLegajo = negocio.obtenerUltimoLegajo();
                txtLegajo.Text = ultimoLegajo.ToString();
                List<Empleado> lista = negocio.listar();

                ddlTipoUsuario.DataSource = lista;
                ddlTipoUsuario.DataValueField = "TipoUsuario";
                ddlTipoUsuario.DataTextField = "TipoUsuario";
                ddlTipoUsuario.DataBind();
            }
            
            if (legajo != "" && !IsPostBack)
            {
                EmpleadoNegocio negocio = new EmpleadoNegocio();
                Empleado seleccionado = negocio.listar(legajo)[0];
                Session.Add("empleadoSeleccionado", seleccionado);
                txtNombre.Text = seleccionado.persona.Nombre;
                txtApellido.Text = seleccionado.persona.Apellido;
                txtEmail.Text = seleccionado.persona.Email;
                txtLegajo.Text = seleccionado.Legajo.ToString();
                ddlTipoUsuario.SelectedValue = seleccionado.TipoUsuario.ToString();
                txtFechaIngreso.Text = seleccionado.FechaIngreso.ToString();
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
            nuevo.TipoUsuario = int.Parse(ddlTipoUsuario.SelectedValue);
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

            negocio.agregar(nuevo);
            Response.Redirect("~/Admin/Empleados.aspx");

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Empleados.aspx");
        }
    }
}