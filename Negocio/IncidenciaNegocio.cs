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
                datos.setearConsulta("select INC.codigo, INC.Cliente, INC.Usuario, INC.Descripcion, ESt.Nombre as Estado,Prio.Nombre as Prioridad, INC.Tipo, INC.FechaAlta, INC.FechaCierre, INC.Resolucion from INCIDENCIAS as INC left join ESTADOS as est on inc.Estado = est.Id\r\nleft join PRIORIDADES as Prio on INC.Prioridad = Prio.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidencia aux = new Incidencia();
                    aux.Id = (int)datos.Lector["codigo"];
                    aux.Cliente = (int)datos.Lector["Cliente"];
                    aux.Usuario = (int)datos.Lector["Usuario"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = (string)datos.Lector["Estado"];
                    aux.Prioridad = (string)datos.Lector["Prioridad"];
                    aux.Tipo = (int)datos.Lector["Tipo"];
                    DateTime date = DateTime.Parse(datos.Lector["FechaAlta"].ToString());
                    aux.FechaAlta = date.Date.ToString("d");

                    if (!(datos.Lector["FechaCierre"] is DBNull))
                    {
                        date = DateTime.Parse(datos.Lector["FechaCierre"].ToString());
                        aux.FechaCierre = date.Date.ToString("d");
                    }
                    else
                    {
                        aux.FechaCierre = " ";
                    }
                       

                    if (!(datos.Lector["Resolucion"] is DBNull))
                        aux.Resolucion = (string)datos.Lector["Resolucion"];
                    else
                        aux.Resolucion = "Pendiente";

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
