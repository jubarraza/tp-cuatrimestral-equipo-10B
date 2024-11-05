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
    public partial class AgregarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Legajo"] == null)
            {
                txtLegajo.Enabled = false;
                EmpleadoNegocio negocio = new EmpleadoNegocio();
                int ultimoLegajo = negocio.obtenerUltimoLegajo();
                txtLegajo.Text = ultimoLegajo.ToString();
                List<Empleado> lista = negocio.listar();

                ddlTipoUsuario.DataSource = lista;
                ddlTipoUsuario.DataValueField = "TipoUsuario";
                ddlTipoUsuario.DataTextField = "TipoUsuario";
                ddlTipoUsuario.DataBind();
            }
            else
            {
                int Legajo = int.Parse(Request.QueryString["Legajo"].ToString());
                txtLegajo.Enabled = false;
                List<Empleado> temporal = (List<Empleado>)Session["listaEmpleados"];
                Empleado seleccionado = temporal.Find(x => x.Legajo == Legajo);
                txtNombre.Text = seleccionado.persona.Nombre;
                txtApellido.Text = seleccionado.persona.Apellido;

                txtLegajo.Text = Legajo.ToString();

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
            nuevo.FechaIngreso = DateTime.Parse(txtFechaNacimiento.Text);
            nuevo.Contraseña = txtContraseña.Text;
            if (rbActivo.Checked)
            {
                nuevo.Activo = true;
            }
            else
            {
                nuevo.Activo = false;
            }
            
            List<Empleado> temporal = (List<Empleado>)Session["listaEmpleados"];
            temporal.Add(nuevo);

            negocio.agregar(nuevo);
            Response.Redirect("~/Admin/Empleados.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Empleados.aspx");
        }
    }
}