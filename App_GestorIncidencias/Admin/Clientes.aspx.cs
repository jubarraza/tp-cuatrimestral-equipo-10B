using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_GestorIncidencias.Admin
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ClienteNegocio negocio = new ClienteNegocio();
                    List<Cliente> lista = negocio.listar(true);
                    Session.Add("listaClientes", lista);
                    gvClientes.DataSource = lista;
                    gvClientes.DataBind();

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dni = gvClientes.SelectedDataKey.Value.ToString();
            Response.Redirect("~/Admin/GestionarClientesAdmin.aspx?dni=" + dni);
        }

        protected void gvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string dni = gvClientes.DataKeys[e.RowIndex].Value.ToString();
                Session.Add("idClienteEliminar", dni);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModalScript", "showModal();", true);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void btnEliminarConfirmado_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                long dni = long.Parse(Session["idClienteEliminar"].ToString());

                IncidenciaNegocio incidenciaNegocio = new IncidenciaNegocio();
                List<Incidencia> lista = incidenciaNegocio.listarIncidenciasDeCliente(dni);
                if (lista != null && lista.Count > 0)
                {
                    foreach (var incidencia in lista)
                    {
                        if (!(incidencia.Estado.EstadoFinal))
                        {
                            areaErrorEliminar.Visible = true;
                            return;
                        }
                    }
                }
                             
                clienteNegocio.eliminarCliente(dni);
                Response.Redirect("Clientes.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/GestionarClientesAdmin.aspx", false);
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Cliente> listaClientes = (List<Cliente>)Session["listaClientes"];

                List<Cliente> listaFiltrada = listaClientes.FindAll(x => x.persona.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()) || x.persona.Apellido.ToUpper().Contains(txtBuscar.Text.ToUpper()));

                gvClientes.DataSource = listaFiltrada;
                gvClientes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                txtBuscar.Text = string.Empty;
                gvClientes.DataSource = Session["listaClientes"];
                gvClientes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("~/PageError.aspx", false);
            }
        }

        protected void btnCerrarLbl_Click(object sender, EventArgs e)
        {
            areaErrorEliminar.Visible = false;
        }
    }
}