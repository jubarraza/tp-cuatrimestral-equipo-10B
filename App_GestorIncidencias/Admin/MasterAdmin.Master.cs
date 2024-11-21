using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias
{
    public partial class MasterAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Helper.SessionActiva(Session["usuario"]))
            {
                Empleado aux = (Empleado)Session["usuario"];

                if(aux.tipoUsuario.IdTipoUsuario != 3)
                {
                    lblUser.Text = aux.persona.ToString();

                    if (!string.IsNullOrEmpty(aux.ImagenPerfil))
                    {
                        imgAvatar.ImageUrl = "~/Images/Perfiles/" + aux.ImagenPerfil;
                    }
                    else
                    {
                        imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
                    }
                }
                else
                {
                    Session.Add("error", "El usuario no posee permisos de Administrador.");
                    Response.Redirect("~/PageError.aspx", false);

                }
                
            }
            else
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }
    }
}