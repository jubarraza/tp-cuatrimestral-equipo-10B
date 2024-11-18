using App_GestorIncidencias.Admin;
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
    public partial class IncidenciaListar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
               
            if (!IsPostBack)
            {
                if (chkAvanzado.Checked)
                {
                    txtBuscar.Enabled = false;
                    ddlCategoria.Items.Clear();
                    ddlCategoria.Enabled = false;
                    ddlCategoria.Items.Add("");
                }
                else
                {
                    txtBuscar.Enabled = true;
                }
                IncidenciaNegocio negocio = new IncidenciaNegocio();
                Session.Add("listaIncidencias", negocio.listar());
                dgvIncidencias.DataSource = Session["listaIncidencias"];
                dgvIncidencias.DataBind();

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
            IncidenciaNegocio negocio = new IncidenciaNegocio();
            List<int> ListaId = new List<int>();

            ListaId = negocio.filtrar(ddlBusquedapor.SelectedItem.ToString(),
                txtBusquedapor.Text, ddlFiltrapor.SelectedItem.ToString(),
                ddlCategoria.SelectedItem.ToString()
                ); 
        }

        protected void ddlBusquedapor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBusquedapor.SelectedItem.ToString() == "Todos")
                txtBusquedapor.Enabled = false;
            else
                txtBusquedapor.Enabled = true;
        }
    }
}