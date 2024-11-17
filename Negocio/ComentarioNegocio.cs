using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ComentarioNegocio
    {

        
        public List<Comentario> Listar(string valor = "", bool Todos = true)
        {
            List<Comentario> comentarios = new List<Comentario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
              string consulta = "select com.id, com.Cod_Incidencia, com.Comentario, com.Fecha, com.LegajoUsuario from COMENTARIOS as com";
              if (valor != "")
                {
                    if(Todos)
                    {
                        consulta = consulta + " where com.Cod_Incidencia = " + valor;
                    }
                    else
                    {
                        consulta = consulta + " where com.id = " + valor;
                    }
                }
                   
               datos.setearConsulta(consulta);
               datos.ejecutarLectura();
               while (datos.Lector.Read())
                {
                    Comentario Aux = new Comentario();
                    Aux.id = (int)datos.Lector["Id"];
                    Aux.Cod_Incidencia = (int)datos.Lector["Cod_Incidencia"];
                    Aux.ComentarioGestion = (string)datos.Lector["Comentario"];
                    Aux.Fecha = DateTime.Parse(datos.Lector["Fecha"].ToString());
                    Aux.Usuario = new Empleado();
                    Aux.Usuario.Legajo = (long)datos.Lector["LegajoUsuario"];
                    EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();
                    Aux.Usuario = empleadoNegocio.Buscar(Aux.Usuario.Legajo);
                    comentarios.Add(Aux);
                }

               return comentarios;
            }
            catch (Exception ex )
            {
                throw ex ;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void Agregar(Comentario comentario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into COMENTARIOS values (@Cod_incidencia, @comentario, @Fecha, @LegajoUsuario)");
                datos.setearParametro("@Cod_incidencia", comentario.Cod_Incidencia);
                datos.setearParametro("@Comentario", comentario.ComentarioGestion);
                datos.setearParametro("@Fecha", comentario.Fecha);
                datos.setearParametro("@LegajoUsuario", comentario.Usuario.Legajo);
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



        public void Modificar(Comentario comentario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update COMENTARIOS set Comentario = @Comentario where id = @id");
                datos.setearParametro("@Comentario", comentario.ComentarioGestion);
                datos.setearParametro("@id", comentario.id);
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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from COMENTARIOS where id=@id");
                datos.setearParametro("@id", id);
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
