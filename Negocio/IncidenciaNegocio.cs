using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocio
{
    public class IncidenciaNegocio
    {
        public List<Incidencia> listar()
        {
            List<Incidencia> lista = new List<Incidencia>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select INC.codigo, INC.Cliente, INC.Usuario, INC.Descripcion, INC.Estado, INC.Prioridad, INC.Tipo, INC.FechaAlta, INC.FechaCierre, INC.Resolucion from INCIDENCIAS as INC");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidencia aux = new Incidencia();
                    aux.Id = (int)datos.Lector["codigo"];
                    aux.Cliente = (int)datos.Lector["Cliente"];
                    aux.Usuario = (int)datos.Lector["Usuario"];                  
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = (int)datos.Lector["Estado"];
                    aux.Prioridad = (int)datos.Lector["Prioridad"];
                    aux.Tipo = (int)datos.Lector["Tipo"];
                    aux.FechaAlta = DateTime.Parse(datos.Lector["FechaAlta"].ToString());

                    //aux.FechaBaja = DateTime.Parse(datos.Lector["FechaBaja"].ToString());
                    //aux.Resolucion = (string)datos.Lector["Resolucion"];
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
