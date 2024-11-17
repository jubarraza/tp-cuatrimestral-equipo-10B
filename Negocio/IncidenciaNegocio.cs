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
                string consulta = "select INC.codigo, INC.DniCliente, INC.LegajoEmpleado, INC.Descripcion,est.Id AS IdEstado, est.Nombre as Estado,PRIO.Id as IdPrioridad, PRIO.Nombre as Prioridad, INC.IdTipoIncidencia, INC.FechaAlta, INC.FechaCierre, INC.Resolucion from INCIDENCIAS as INC left join ESTADOS as est on INC.Estado = est.Id left join PRIORIDADES as PRIO on INC.Prioridad = PRIO.Id";
                if(id != "")
                    consulta = consulta + " where INC.codigo = " + id;
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidencia aux = new Incidencia();
                    aux.Tipo = new TipoIncidencia();
                    TipoIncidenciaNegocio tipoNegocio = new TipoIncidenciaNegocio();

                    aux.Id = (int)datos.Lector["codigo"];
                    aux.cliente = new Cliente();
                    aux.cliente.Dni = (long)datos.Lector["DniCliente"];
                    ClienteNegocio clienteNeg = new ClienteNegocio();
                    aux.cliente = clienteNeg.BuscarCliente(aux.cliente.Dni);
                    aux.Empleado = new Empleado();
                    aux.Empleado.Legajo = (long)datos.Lector["LegajoEmpleado"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = new Estado();
                    aux.Estado.Id = (int)datos.Lector["IdEstado"];
                    aux.Estado.Nombre = (string)datos.Lector["Estado"];
                    aux.Prioridad = new Prioridad();
                    aux.Prioridad.Id = (int)datos.Lector["IdPrioridad"];
                    aux.Prioridad.Nombre = (string)datos.Lector["Prioridad"];
                    aux.Tipo.Id = (int)datos.Lector["IdTipoIncidencia"];
                    aux.Tipo = tipoNegocio.Buscar(aux.Tipo.Id);
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
                datos.setearConsulta("insert into INCIDENCIAS (DniCliente, LegajoEmpleado, Descripcion, Estado, Prioridad, IdTipoIncidencia, FechaAlta, FechaCierre, Resolucion) values (@Cliente, @LegajoEmpleado, @Descripcion , @Estado, @Prioridad, @Tipo, @FechaAlta, null, null);");
                datos.setearParametro("@Cliente", nueva.cliente.Dni);
                datos.setearParametro("@LegajoEmpleado", nueva.Empleado.Legajo);
                datos.setearParametro("@Descripcion", nueva.Descripcion);
                datos.setearParametro("@Estado", nueva.Estado.Id);
                datos.setearParametro("@Prioridad", nueva.Prioridad.Id);
                datos.setearParametro("@Tipo", nueva.Tipo.Id);
                datos.setearParametro("@FechaAlta", nueva.FechaAlta);
                datos.ejecutarAccion();
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


        public void ModificarIncidencia(Incidencia nueva)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update incidencias set DniCliente = @DniCliente, LegajoEmpleado = @LegajoEmpleado, Descripcion = @Descripcion, Estado = @Estado, Prioridad = @Prioridad, IdTipoIncidencia = @Tipo, FechaAlta = @FechaAlta where codigo = @Id");
                datos.setearParametro("@DniCliente", nueva.cliente.Dni);
                datos.setearParametro("@LegajoEmpleado", nueva.Empleado.Legajo);
                datos.setearParametro("@Descripcion", nueva.Descripcion);
                datos.setearParametro("@Estado", nueva.Estado.Id);
                datos.setearParametro("@Prioridad", nueva.Prioridad.Id);
                datos.setearParametro("@Tipo", nueva.Tipo.Id);
                datos.setearParametro("@FechaAlta", nueva.FechaAlta);
                datos.setearParametro("@Id", nueva.Id);
                datos.ejecutarAccion();
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
