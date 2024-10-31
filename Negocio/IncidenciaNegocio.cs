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
        public List<Incidencia> listar(string id = "")
        {
            List<Incidencia> lista = new List<Incidencia>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select INC.codigo, INC.Cliente, INC.Usuario, INC.Descripcion,EST.Id AS IdEstado, EST.Nombre as Estado,PRIO.Id as IdPrioridad, PRIO.Nombre as Prioridad, INC.Tipo, INC.FechaAlta, INC.FechaCierre, INC.Resolucion from INCIDENCIAS as INC left join ESTADOS as est on INC.Estado = EST.Id left join PRIORIDADES as PRIO on INC.Prioridad = PRIO.Id";
                if(id != "")
                    consulta = consulta + "and INC.ID = " + id;
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidencia aux = new Incidencia();
                    aux.Id = (int)datos.Lector["codigo"];
                    aux.Cliente = (int)datos.Lector["Cliente"];
                    aux.Usuario = (int)datos.Lector["Usuario"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = new Estado();
                    aux.Estado.Id = (int)datos.Lector["IdEstado"];
                    aux.Estado.Nombre = (string)datos.Lector["Estado"];
                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.Id = (int)datos.Lector["IdPrioridad"];
                    aux.Prioridad.Nombre = (string)datos.Lector["Prioridad"];
                    aux.Tipo = (int)datos.Lector["Tipo"];
                    aux.FechaAlta = DateTime.Parse(datos.Lector["FechaAlta"].ToString());

                    if (!(datos.Lector["FechaCierre"] is DBNull))
                    {
                        aux.FechaCierre = DateTime.Parse(datos.Lector["FechaAlta"].ToString());
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

        public void AgregarIncidencia(Incidencia nueva)
        {   

            AccesoDatos datos   = new AccesoDatos();
            
            try
            {
                datos.setearConsulta("insert into INCIDENCIAS values (@Cliente, @Usuario, @Descripcion , @Estado, @Prioridad, @Tipo, @FechaAlta, null, null);");
                datos.setearParametro("@cliente", nueva.Cliente);
                datos.setearParametro("@Usuario", nueva.Usuario);
                datos.setearParametro("@Descripcion", nueva.Descripcion);
                datos.setearParametro("@Estado", nueva.Estado.Id);
                datos.setearParametro("@Prioridad", nueva.Prioridad.Id);
                datos.setearParametro("@Tipo", nueva.Tipo);
                datos.setearParametro("@FechaAlta", nueva.FechaAlta);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



    }
}
