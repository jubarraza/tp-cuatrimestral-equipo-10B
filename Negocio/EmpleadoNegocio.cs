using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class EmpleadoNegocio
    {
        public List<Empleado> listar()
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select P.Id, P.Nombre, P.Apellido, P.Email, E.Legajo, E.TipoUsuario," +
                    " E.FechaIngreso, E.Activo from PERSONAS as P inner join EMPLEADOS as E on E.IdPersona = P.Id;");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();
                    aux.persona = new Persona();
                    aux.persona.Id = (int)datos.Lector["Id"];
                    aux.persona.Nombre = (string)datos.Lector["Nombre"];
                    aux.persona.Apellido = (string)datos.Lector["Apellido"];
                    aux.persona.Email = (string)datos.Lector["Email"];
                    aux.Legajo = (int)datos.Lector["Legajo"];
                    aux.TipoUsuario = Convert.ToInt32(datos.Lector["TipoUsuario"]);
                    aux.FechaIngreso = (DateTime)datos.Lector["FechaIngreso"];
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

        public int obtenerUltimoLegajo()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select max(Legajo) from EMPLEADOS");
                datos.ejecutarLectura();
                int ultimoLegajo = 0;
                if (datos.Lector.Read())
                {
                    ultimoLegajo = datos.Lector.IsDBNull(0) ? 0 : datos.Lector.GetInt32(0);
                }

                return ultimoLegajo+1;

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
