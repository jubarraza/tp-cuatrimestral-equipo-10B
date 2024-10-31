using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EstadoNegocio
    {
        public List<Estado> listar(int id = 0)
        {
            List<Estado> lista = new List<Estado>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta;
                if (id != 0)
                {
                    consulta = "select Id, Nombre, EstadoFinal, Activo from ESTADOS where id = " + id;
                }
                else
                {
                    consulta = "select Id, Nombre, EstadoFinal, Activo from ESTADOS";
                }


                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Estado aux = new Estado();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.EstadoFinal = (bool)datos.Lector["EstadoFinal"];
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



    }
}
