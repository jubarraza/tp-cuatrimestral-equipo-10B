using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class TelefonoNegocio
    {
        public List<Telefono> listar()
        {
            List<Telefono> lista = new List<Telefono>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select IdPersona, IdTelefono, NumeroTelefono from TELEFONOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Telefono aux = new Telefono();
                    aux.IdTelefono = (int)datos.Lector["IdTelefono"];
                    aux.NumeroTelefono = (long)datos.Lector["NumeroTelefono"];
                    aux.persona = new Persona();
                    aux.persona.Id = (long)datos.Lector["IdPersona"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Telefono> BuscarTelefonos(long id)
        {
            TelefonoNegocio telefonoNegocio = new TelefonoNegocio();
            List<Telefono> listaTelefonos = telefonoNegocio.listar();
            List<Telefono> listaXCliente = new List<Telefono>();

            foreach (Telefono tel in listaTelefonos)
            {
                if (tel.persona.Id == id)
                {
                    listaXCliente.Add(tel);
                }
            }

            if (listaXCliente.Count == 0)
            {
                return null;
            }
            else
            {
                return listaXCliente;
            }
        }
    }
}
