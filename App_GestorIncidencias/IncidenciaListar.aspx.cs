﻿using App_GestorIncidencias.Admin;
using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias
{
    public partial class IncidenciaListar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (chkAvanzado.Checked)
            {
                cargaFiltroAvanzado();
                
            }
            else
            {
                txtBuscar.Enabled = true;
                ddlBusquedapor.SelectedIndex = 0;
                txtBusquedapor.Enabled = false;
                ddlFiltrapor.SelectedIndex = 0;
                ddlCategoria.Items.Clear();
                ddlCategoria.Enabled = false;
                txtFechaDesde.Text = "";
                txtFechaHasta.Text = "";
            }

            if (!IsPostBack)
            {
                if (Helper.SessionActiva(Session["usuario"]))
                {
                    Empleado user = (Empleado)Session["usuario"];
                    if (Helper.consultaTipoUsuario(user) == 3)
                    {
                        IncidenciaNegocio negocio = new IncidenciaNegocio();
                        Session.Add("listaIncidencias", negocio.listarIncidenciasDeOperador(user.Legajo));
                        dgvIncidencias.DataSource = Session["listaIncidencias"];
                        dgvIncidencias.DataBind();
                    }
                    else
                    {
                        IncidenciaNegocio negocio = new IncidenciaNegocio();
                        Session.Add("listaIncidencias", negocio.listar());
                        dgvIncidencias.DataSource = Session["listaIncidencias"];
                        dgvIncidencias.DataBind();
                    }

                }
                else
                {
                    Response.Redirect("~/Default.aspx", false);
                }

            }
        }

        protected void cargaFiltroAvanzado()
        {
            txtBuscar.Enabled = false;
            DateTime fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            if (txtFechaDesde.Text == "")
            {
                txtFechaDesde.Text = fecha.ToString("yyyy-MM-dd");
            }
            if (txtFechaHasta.Text == "")
            {
                fecha = fecha.AddMonths(1).AddDays(-1);
                txtFechaHasta.Text = fecha.ToString("yyyy-MM-dd");
            }
            if (ddlFiltrapor.SelectedValue.ToString() == "Todos")
            {
                ddlCategoria.Items.Clear();
                ddlCategoria.Enabled = false;
                ddlCategoria.Items.Add("");
            }
        }

        protected void dgvIncidencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvIncidencias.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionarIncidencia.aspx?Id=" + Id);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarIncidencia.aspx", false);
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Incidencia> incidencias = (List<Incidencia>)Session["listaIncidencias"];
            List<Incidencia> ListaFiltrada;

            try
            {
                if (txtBuscar.Text != "")
                {
                    ListaFiltrada = incidencias.FindAll(x => x.Id.ToString().Contains(txtBuscar.Text));
                    dgvIncidencias.DataSource = ListaFiltrada;
                    dgvIncidencias.DataBind();
                }
                else
                {
                    dgvIncidencias.DataSource = incidencias;
                    dgvIncidencias.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void ddlFiltrapor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlCategoria.Enabled = true;
                if (ddlFiltrapor.SelectedValue.ToString() == "Estado")
                {
                    EstadoNegocio estadodNegocio = new EstadoNegocio();
                    List<Estado> estados = estadodNegocio.listar();
                    ddlCategoria.DataSource = estados;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Nombre";
                    ddlCategoria.DataBind();

                }
                else if (ddlFiltrapor.SelectedValue.ToString() == "Prioridad")
                {
                    PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
                    List<Prioridad> prioridades = prioridadNegocio.listar();
                    ddlCategoria.DataSource = prioridades;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Nombre";
                    ddlCategoria.DataBind();
                }
                else if (ddlFiltrapor.SelectedValue.ToString() == "Tipo")
                {
                    TipoIncidenciaNegocio tipoNegocio = new TipoIncidenciaNegocio();
                    List<TipoIncidencia> incidencias = tipoNegocio.listar(true);
                    ddlCategoria.DataSource = incidencias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Nombre";
                    ddlCategoria.DataBind();

                }
                else
                {
                    ddlCategoria.Items.Clear();
                    ddlCategoria.Enabled = false;
                    ddlCategoria.Items.Add("");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                IncidenciaNegocio negocio = new IncidenciaNegocio();

                List<Incidencia> listaFiltrada = negocio.filtrar(ddlBusquedapor.SelectedItem.ToString(),
                    txtBusquedapor.Text, ddlFiltrapor.SelectedItem.ToString(),
                    ddlCategoria.SelectedItem.ToString(), txtFechaDesde.Text,
                    txtFechaHasta.Text
                    );

                dgvIncidencias.DataSource = listaFiltrada;
                dgvIncidencias.DataBind();

                if (listaFiltrada.Count == 0)
                {
                      lblSinResultados.Visible = true;
                }
                else
                {
                    lblSinResultados.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlBusquedapor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBusquedapor.SelectedItem.ToString() == "Todos")
            {
                txtBusquedapor.Enabled = false;
                txtBusquedapor.Text = "";
            }
            else if(ddlBusquedapor.SelectedItem.ToString() == "Legajo Usuario Asignado")
            {
                if (Helper.consultaTipoUsuario(Session["usuario"]) == 3)
                {
                    txtBusquedapor.Text = ((Empleado)Session["usuario"]).Legajo.ToString();
                    txtBusquedapor.Enabled = false;
                }
                else
                {
                    txtBusquedapor.Enabled = true;
                }
            }
            else
            {
                txtBusquedapor.Enabled = true;
            }

        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            ResetearFiltro();
            lblSinResultados.Visible = false;
            Empleado user = (Empleado)Session["usuario"];
            if (Helper.consultaTipoUsuario(user) == 3)
            {
                IncidenciaNegocio negocio = new IncidenciaNegocio();
                Session.Add("listaIncidencias", negocio.listarIncidenciasDeOperador(user.Legajo));
                dgvIncidencias.DataSource = Session["listaIncidencias"];
                dgvIncidencias.DataBind();
            }
            else
            {
                IncidenciaNegocio negocio = new IncidenciaNegocio();
                Session.Add("listaIncidencias", negocio.listar());
                dgvIncidencias.DataSource = Session["listaIncidencias"];
                dgvIncidencias.DataBind();
            }
        }


        private void ResetearFiltro()
        {
            txtBuscar.Enabled = true;
            txtBusquedapor.Text = "";
            ddlBusquedapor.SelectedIndex = 0;
            txtBusquedapor.Enabled = false;
            ddlFiltrapor.SelectedIndex = 0;
            ddlCategoria.Items.Clear();
            ddlCategoria.Enabled = false;
            txtBuscar.Enabled = false;
            DateTime fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtFechaDesde.Text = fecha.ToString("yyyy-MM-dd");
            fecha = fecha.AddMonths(1).AddDays(-1);
            txtFechaHasta.Text = fecha.ToString("yyyy-MM-dd");
        }
    }
}
