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
                    if(!IsPostBack)
                    {
                        Empleado empleadoUser = (Empleado)Session["usuario"];
                        txtNombre.Text = empleadoUser.persona.Nombre.ToString();
                        txtApellido.Text = empleadoUser.persona.Apellido.ToString();
                        txtEmail.Text = empleadoUser.persona.Email.ToString();
                        txtLegajo.Text = empleadoUser.Legajo.ToString();
                        txtTipoUsuario.Text = empleadoUser.tipoUsuario.Tipo.ToString();
                        txtFechaIngreso.Text = empleadoUser.FechaIngreso.ToString("yyyy-MM-dd");
                        txtUserPassword.Text = empleadoUser.UserPassword.ToString();
                        lblErrorImagen.Visible = false;


                        if (!string.IsNullOrEmpty(empleadoUser.ImagenPerfil))
                        {
                            imgPerfil.ImageUrl = "~/Images/Perfiles/" + empleadoUser.ImagenPerfil;
                        }
                        else
                        {
                            imgPerfil.ImageUrl = "https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg";
                        }

                        deshabilitarCampos();
                    }

                }

            }          
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
          
        }

        protected void deshabilitarCampos()
        {
            txtUserPassword.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            inputImagen.Disabled = true;
            btnEditar.Visible = true;
            btnGuardar.Visible = false;
        }

        protected void habilitarCampos()
        {
            btnEditar.Visible = false;
            btnGuardar.Visible = true;

            txtUserPassword.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            inputImagen.Disabled = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {   
                EmpleadoNegocio negocio = new EmpleadoNegocio();  
                Empleado empleadoUser = (Empleado)Session["usuario"];

                //pregunto si cargaron una nueva imagen y si tiene el tamaño adecuado
                if (inputImagen.PostedFile.FileName != "") 
                {
                    if (inputImagen.PostedFile.ContentLength < 15 * 1024 * 1024) // 15 MB
                    {
                        string ruta = Server.MapPath("./Images/Perfiles/");
                        inputImagen.PostedFile.SaveAs(ruta + "perfil-" + txtLegajo.Text + ".jpg");
                        empleadoUser.ImagenPerfil = "perfil-" + txtLegajo.Text + ".jpg";
                    }
                    else
                    {
                        lblErrorImagen.Visible = true;
                        return;
                    }
                }

                empleadoUser.UserPassword = txtUserPassword.Text;
                empleadoUser.persona.Nombre = txtNombre.Text;
                empleadoUser.persona.Apellido = txtApellido.Text;
                negocio.Modificar(empleadoUser);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/Perfiles/" + empleadoUser.ImagenPerfil;

                Response.Redirect("MiPerfil.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }
    }
}