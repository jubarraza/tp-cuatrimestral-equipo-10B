using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace App_GestorIncidencias
{
    public partial class RecuperoPassword : System.Web.UI.Page
    {   
       public bool band1 = false;
       public bool band2 = false;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                band1 = true;
                EmpleadoNegocio negocio = new EmpleadoNegocio();
                string Pass = negocio.DevolverPassword(txtEmail.Text);
                if (Pass != "")
                {
                    EnviarCorreoRecuperacion(txtEmail.Text, Pass);
                    band2 = false;
                }
                else
                {
                    band2 = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        private void EnviarCorreoRecuperacion(string mailDestinatario, string password)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("soporte10bstore@gmail.com");
                correo.To.Add(mailDestinatario);
                correo.Subject = "Gestor de Reclamos 10bStore - Recuperacion de contraseña";
                correo.Body = $@"
                            <html>
                            <body>
                                <h2>Ha solicitado la recuperacion de su contraseña</h2>
                                <p> Se ha recibido una solicitud de recuperacion de contraseña para el usuario {mailDestinatario}</p>
                                <p>La contraseña registrada es: <strong>{password}</strong>.</p>
                                <hr/>
                                <p><small>Este es un mensaje automático, por favor no responda a este correo.</small></p>
                            </body>
                            </html>";
                correo.IsBodyHtml = true;

                // Enviar el correo usando la configuración del web.config
                SmtpClient smtp = new SmtpClient();
                smtp.Send(correo);
                Console.WriteLine("Correo enviado a " + mailDestinatario);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }
    }

    
}