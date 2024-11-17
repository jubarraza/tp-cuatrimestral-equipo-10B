﻿using Dominio;
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
        private string id;
        private string Cod;
        public bool band;
        protected void Page_Load(object sender, EventArgs e)
        {   
            

            id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
            Cod = Request.QueryString["Cod"] != null ? Request.QueryString["Cod"].ToString() : "";
            txtCodIncidencia.Enabled = false;
            txtLegajoEmpleado.Enabled = false;
            txtFecha.Enabled = false;
            TxtComentario.Enabled = false;
            band = true;


            if (!IsPostBack)
            {

                try
                {

                    if (id != "")
                    {   

                        btnModificar.Text = "Modificar";
                        ComentarioNegocio negocio2 = new ComentarioNegocio();
                        Comentario comentario2 = (negocio2.Listar(id, false)[0]);
                        txtCodIncidencia.Text = comentario2.Cod_Incidencia.ToString();
                        txtLegajoEmpleado.Text = comentario2.Usuario.ToString();
                        txtFecha.Text = comentario2.Fecha.ToString();
                        TxtComentario.Text = comentario2.ComentarioGestion.ToString();
                    }
                    else
                    {
                        if (Cod != "")
                        {                     
                            btnModificar.Text = "Agregar Comentario";
                            ComentarioNegocio negocio2 = new ComentarioNegocio();
                            txtCodIncidencia.Text = Cod;
                            Empleado user = (Empleado)Session["usuario"];
                            txtLegajoEmpleado.Text = user.ToString();
                            txtFecha.Text = DateTime.Now.ToString();
                            TxtComentario.Enabled = true;
                        }
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
          


        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ComentarioNegocio negocio = new ComentarioNegocio();
                Comentario comentario = new Comentario();

                if (id != "")
                {
                    band = false;
                    TxtComentario.Enabled = true;
                }
                else
                {
                    if (Cod != "")
                    {
                        comentario.Cod_Incidencia = int.Parse(Cod);
                        comentario.Usuario = (Empleado)Session["usuario"];
                        comentario.Fecha = DateTime.Parse(txtFecha.Text);
                        comentario.ComentarioGestion = TxtComentario.Text;
                        negocio.Agregar(comentario);
                        Response.Redirect("GestionarIncidencia.aspx?Id=" + Cod);
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Cod = txtCodIncidencia.Text;
            Response.Redirect("GestionarIncidencia.aspx?Id=" + Cod);
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            ComentarioNegocio negocio = new ComentarioNegocio();
            Comentario comentario = new Comentario();
            try
            {
                comentario.id = int.Parse(id);
                comentario.Cod_Incidencia = int.Parse(txtCodIncidencia.Text);
                comentario.Usuario = (Empleado)Session["usuario"];
                comentario.Fecha = DateTime.Parse(txtFecha.Text);
                comentario.ComentarioGestion = TxtComentario.Text;
                negocio.Modificar(comentario);
                Response.Redirect("GestionarIncidencia.aspx?Id=" + comentario.Cod_Incidencia);
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            string Id = Request.QueryString["Id"].ToString();
            Response.Redirect("GestionarComentario.aspx?Id=" + Id);
        }
    }
}