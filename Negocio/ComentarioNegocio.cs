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

        
        public List<Comentario> Listar(string Cod_Inc = "")
        {
            List<Comentario> comentarios = new List<Comentario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
              string consulta = "select com.id, com.Cod_Incidencia, com.Comentario, com.Fecha, com.IdUsuario from COMENTARIOS as com";
              if (Cod_Inc != "")
                   consulta = consulta + " where com.Cod_Incidencia = " + Cod_Inc;
               datos.setearConsulta(consulta);
               datos.ejecutarLectura();
               while (datos.Lector.Read())
                {
                    Comentario Aux = new Comentario();
                    Aux.id = (int)datos.Lector["Id"];
                    Aux.Cod_Incidencia = (int)datos.Lector["Cod_Incidencia"];
                    Aux.ComentarioGestion = (string)datos.Lector["Comentario"];
                    Aux.Fecha = DateTime.Parse(datos.Lector["Fecha"].ToString());
                    Aux.Cod_Usuario = (int)datos.Lector["IdUsuario"];
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







    }
}
