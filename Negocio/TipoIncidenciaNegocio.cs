using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoIncidenciaNegocio
    {
        public List<TipoIncidencia> listar()
        {
            List<TipoIncidencia> lista = new List<TipoIncidencia>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Nombre, Visible, Activo from TIPO_INCIDENCIA WHERE Activo = 1");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    TipoIncidencia aux = new TipoIncidencia();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Visible = (bool)datos.Lector["Visible"];
                    aux.Activo = (bool)datos.Lector["Activo"];

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

        public TipoIncidencia Buscar(int id)
        {
            TipoIncidenciaNegocio neg = new TipoIncidenciaNegocio();

            List<TipoIncidencia> lista = neg.listar();

            foreach (TipoIncidencia p in lista)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }

            return null;

        }
    }
}
