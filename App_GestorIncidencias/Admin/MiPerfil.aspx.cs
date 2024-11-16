using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace App_GestorIncidencias.Admin
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!Helper.SessionActiva(Session["usuario"]))
                { 
                    Response.Redirect("/Default.aspx", false); 
                }                   
                else
                {
                    Empleado empleadoUser = (Empleado)Session["usuario"];
                    txtNombre.Text = empleadoUser.persona.Nombre.ToString();
                    txtApellido.Text = empleadoUser.persona.Apellido.ToString();
                    txtEmail.Text = empleadoUser.persona.Email.ToString();
                    txtLegajo.Text = empleadoUser.Legajo.ToString();
                    txtTipoUsuario.Text = empleadoUser.tipoUsuario.Tipo.ToString();
                    txtFechaIngreso.Text = empleadoUser.FechaIngreso.ToString("yyyy-MM-dd"); 
                    txtUserPassword.Text = empleadoUser.UserPassword.ToString();
                }

            }          
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
    }
}