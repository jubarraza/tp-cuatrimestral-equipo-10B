using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_GestorIncidencias.Admin;
using Dominio;
using Negocio;

namespace App_GestorIncidencias
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
      
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            AccesoDatos acceso = new AccesoDatos();
            EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
            try
            {
                GestionUser gestionUser = new GestionUser();
                string leg = gestionUser.loguear(txtEmail.Text, txtPass.Text);
                if (leg != "")
                {
                    Empleado empleadouser = (empleadoNegocio.listar(leg)[0]);
                    Session.Add("usuario", empleadouser);
                    Response.Redirect("~/MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "user o pass incorrectos");
                    Response.Redirect("PageError.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("PageError.aspx");
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }
    }
}