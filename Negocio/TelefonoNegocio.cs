using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                datos.ejecutarAccion();
                while (datos.Lector.Read())
                {
                    Telefono aux = new Telefono();
                    aux.IdTelefono = (int)datos.Lector["IdTelefono"];
                    aux.NumeroTelefono = (long)datos.Lector["NumeroTelefono"];

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
    }
}
