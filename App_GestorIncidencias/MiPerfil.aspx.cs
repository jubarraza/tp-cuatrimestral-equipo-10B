﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                    Empleado empleadoUser = (Empleado)Session["usuario"];
                    txtNombre.Text = empleadoUser.persona.Nombre.ToString();
                    txtApellido.Text = empleadoUser.persona.Apellido.ToString();
                    txtEmail.Text = empleadoUser.persona.Email.ToString();
                    txtLegajo.Text = empleadoUser.Legajo.ToString();
                    txtTipoUsuario.Text = empleadoUser.tipoUsuario.Tipo.ToString();
                    txtFechaIngreso.Text = empleadoUser.FechaIngreso.ToString("yyyy-MM-dd"); 
                    txtUserPassword.Text = empleadoUser.UserPassword.ToString();

                    if (!string.IsNullOrEmpty(empleadoUser.ImagenPerfil))
                    {
                        imgPerfil.ImageUrl = empleadoUser.ImagenPerfil;
                    }
                    else
                    {
                        imgPerfil.ImageUrl = "https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg";
                    }

                    deshabilitarCampos();
                }

            }          
            catch (Exception ex)
            {
                throw ex;
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
                string ruta = Server.MapPath("./Images/Perfiles/");
                inputImagen.PostedFile.SaveAs(ruta + "perfil-" + txtLegajo.Text + ".jpg");
            }
            catch (Exception ex)
            {

                Session.Add("error de guardado", ex.ToString());
                Response.Redirect("PageError.aspx");
            }
        }
    }
}