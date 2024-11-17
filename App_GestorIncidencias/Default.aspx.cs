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
            if (Helper.SessionActiva(Session["usuario"]))
            {
                Empleado aux = (Empleado)Session["usuario"];
                lblUsuarioLogueado.Text = "Usuario loguedo: <strong>" + aux.persona.ToString() + "</strong> - " + aux.persona.Email;
            }

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
                    Response.Redirect("~/IncidenciaListar.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o contraseña incorrectos");
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

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("usuario");
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("PageError.aspx", false);
            }
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }
    }
}