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
            if (!IsPostBack)
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Session.Add("listaClientes", negocio.listar());
                gvClientes.DataSource = negocio.listar();
                gvClientes.DataBind();

            }
            
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dni = gvClientes.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionarClientes.aspx?dni=" + dni);
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
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
        }

        protected void btnEliminarConfirmado_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                long id = long.Parse(Session["idClienteEliminar"].ToString());
                clienteNegocio.eliminarCliente(id);
                Response.Redirect("Clientes.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarClientes.aspx", false);
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Cliente> listaClientes = (List<Cliente>)Session["listaClientes"];

                List<Cliente> listaFiltrada = listaClientes.FindAll(x => x.persona.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));

                gvClientes.DataSource = listaFiltrada;
                gvClientes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("../PageError.aspx", false);
            }
        }
    }
}