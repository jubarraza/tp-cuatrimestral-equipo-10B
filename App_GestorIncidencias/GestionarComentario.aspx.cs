using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
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
            
            if (!IsPostBack)
            {

                try
                {
                    string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                    string Cod = Request.QueryString["Cod"] != null ? Request.QueryString["Cod"].ToString() : "";

                    if (id != "")
                    {
                        btnActualizar.Text = "Actualizar";
                        ComentarioNegocio negocio = new ComentarioNegocio();
                        Comentario comentario = (negocio.Listar(id, false)[0]);
                        txtCodIncidencia.Text = comentario.Cod_Incidencia.ToString();
                        txtUsuario.Text = comentario.Cod_Usuario.ToString();
                        txtFecha.Text = comentario.Fecha.ToString();
                        TxtComenatario.Text = comentario.ComentarioGestion.ToString();
                    }
                    else
                    {
                        if (Cod != "")
                        {
                            btnActualizar.Text = "Agregar Comentario";
                            ComentarioNegocio negocio = new ComentarioNegocio();
                            Comentario comentario = (negocio.Listar(Cod)[0]);
                            txtCodIncidencia.Text = comentario.Cod_Incidencia.ToString();
                            txtUsuario.Text = comentario.Cod_Usuario.ToString();
                            txtFecha.Text = DateTime.Now.ToString();
                            btnEliminar.Visible = false;
                        }
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
          


        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                string Cod = Request.QueryString["Cod"] != null ? Request.QueryString["Cod"].ToString() : "";
                ComentarioNegocio negocio = new ComentarioNegocio();
                Comentario comentario = new Comentario();

                if (id != "")
                {
                    comentario.id = int.Parse(id);
                    comentario.Cod_Incidencia = int.Parse(txtCodIncidencia.Text);
                    comentario.Cod_Usuario = int.Parse(txtUsuario.Text);
                    comentario.Fecha = DateTime.Parse(txtFecha.Text);
                    comentario.ComentarioGestion = TxtComenatario.Text;
                    negocio.Modificar(comentario);
                    Response.Redirect("IncidenciaListar.aspx", false);
                }
                else
                {
                    if (Cod != "")
                    {
                        comentario.Cod_Incidencia = int.Parse(Cod);
                        comentario.Cod_Usuario = int.Parse(txtUsuario.Text);
                        comentario.Fecha = DateTime.Parse(txtFecha.Text);
                        comentario.ComentarioGestion = TxtComenatario.Text;
                        negocio.Agregar(comentario);
                        Response.Redirect("IncidenciaListar.aspx", false);
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["Id"]);
                ComentarioNegocio negocio = new ComentarioNegocio();
                negocio.Eliminar(id);
                Response.Redirect("IncidenciaListar.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}