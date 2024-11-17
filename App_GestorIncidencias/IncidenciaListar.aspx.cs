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
            int ID; 

            try
            {
                if(txtBuscar.Text != "")
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
    }
}