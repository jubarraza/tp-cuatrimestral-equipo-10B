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
            try
            {
                if (Helper.SessionActiva(Session["usuario"]))
                {
                    Empleado aux = (Empleado)Session["usuario"];
                    int contEstadoAbierto = 0;
                    int contEstadoAsignado = 0;
                    int contEstadoEnAnalisis = 0;
                    int contEstadoResuelto = 0;

                    lblTitulo.Text = "🏠 Inicio de " + aux.persona.Nombre + " " + aux.persona.Apellido;

                    IncidenciaNegocio incidenciaNegocio = new IncidenciaNegocio();
                    List<Incidencia> lista = incidenciaNegocio.listarIncidenciasDeOperador(aux.Legajo);

                    foreach (Incidencia inc in lista)
                    {
                        if (inc.Estado.Id == 1)
                        {
                            contEstadoAbierto++;
                        }
                        if (inc.Estado.Id == 2)
                        {
                            contEstadoAsignado++;
                        }
                        if (inc.Estado.Id == 3)
                        {
                            contEstadoEnAnalisis++;
                        }
                        if (inc.Estado.Id == 4)
                        {
                            contEstadoResuelto++;
                        }
                    }

                    lblAbierto.Text = contEstadoAbierto.ToString();
                    lblAsignado.Text = contEstadoAsignado.ToString();
                    lblEnAnalisis.Text = contEstadoEnAnalisis.ToString();
                    lblResuelto.Text = contEstadoResuelto.ToString();

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
            try
            {
                GestionUser gestionUser = new GestionUser();
                string leg = gestionUser.loguear(txtEmail.Text, txtPassword.Text);
                if (leg != "")
                {
                    Empleado empleadoUser = (empleadoNegocio.listar(leg)[0]);
                    Session.Add("usuario", empleadoUser);
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showModalScript", "var modal = new bootstrap.Modal(document.getElementById('ModalConfirmacion')); modal.show();", true);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
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
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }

        protected void btnAbierto_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncidenciaListar.aspx?estado=abierto", false);
        }

        protected void btnAsignado_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncidenciaListar.aspx?estado=asignado", false);
        }

        protected void btnEnAnalisis_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncidenciaListar.aspx?estado=enAnalisis", false);
        }

        protected void btnResuelto_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncidenciaListar.aspx?estado=resuelto", false);
        }
    }
}