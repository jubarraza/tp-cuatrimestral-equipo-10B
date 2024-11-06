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
    public partial class GestionarComentario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodIncidencia.Enabled = false;
            txtUsuario.Enabled = false;
            txtFecha.Enabled = false;

            try
            {
                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                if(id != "")
                {
                    ComentarioNegocio negocio = new ComentarioNegocio();
                    Comentario comentario = (negocio.Listar(id)[0]);
                    txtCodIncidencia.Text = comentario.Cod_Incidencia.ToString();
                    txtUsuario.Text = comentario.Cod_Usuario.ToString();
                    txtFecha.Text = comentario.Fecha.ToString();
                    TxtComenatario.Text = comentario.ComentarioGestion.ToString();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

      
    }
}