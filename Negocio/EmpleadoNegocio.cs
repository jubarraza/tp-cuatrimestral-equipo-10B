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
        public List<Empleado> listar(string legajo = "")
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select P.Id, P.Nombre, P.Apellido, P.Email, E.Legajo, E.UserPassword, T.IdTipoUsuario, T.Tipo, E.FechaIngreso, E.Activo, E.ImagenPerfil " +
                  "from PERSONAS as P inner join EMPLEADOS as E on E.IdPersona = P.Id" +
                  " inner join TIPOS_USUARIOS as T on E.TipoUsuario = T.IdTipoUsuario ";

                if (!string.IsNullOrEmpty(legajo))
                {
                    consulta += " where E.Legajo = @Legajo";
                    datos.setearParametro("@Legajo", legajo);
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();
                    aux.persona = new Persona();
                    aux.persona.Id = long.Parse(datos.Lector["Id"].ToString());
                    aux.persona.Nombre = (string)datos.Lector["Nombre"];
                    aux.persona.Apellido = (string)datos.Lector["Apellido"];
                    aux.persona.Email = (string)datos.Lector["Email"];
                    aux.Legajo = long.Parse(datos.Lector["Legajo"].ToString());
                    aux.UserPassword = (string)datos.Lector["UserPassword"];
                    aux.tipoUsuario = new TipoUsuario();
                    aux.tipoUsuario.IdTipoUsuario = int.Parse(datos.Lector["IdTipoUsuario"].ToString());
                    aux.tipoUsuario.Tipo = (string)datos.Lector["Tipo"];
                    aux.FechaIngreso = (DateTime)datos.Lector["FechaIngreso"];
                    aux.ImagenPerfil = datos.Lector["ImagenPerfil"] is DBNull ? "" : (string)datos.Lector["ImagenPerfil"];
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

        public List<Empleado> listar(bool soloActivos)
        {
            List<Empleado> lista = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "";

                if (soloActivos)
                {
                    consulta = "select P.Id, P.Nombre, P.Apellido, P.Email, E.Legajo, E.UserPassword, T.IdTipoUsuario, T.Tipo, E.FechaIngreso, E.Activo, E.ImagenPerfil " +
                      "from PERSONAS as P inner join EMPLEADOS as E on E.IdPersona = P.Id inner join TIPOS_USUARIOS as T on E.TipoUsuario = T.IdTipoUsuario WHERE E.Activo = 1";
                }
                else
                {
                    consulta = "select P.Id, P.Nombre, P.Apellido, P.Email, E.Legajo, E.UserPassword, T.IdTipoUsuario, T.Tipo, E.FechaIngreso, E.Activo, E.ImagenPerfil " +
                      "from PERSONAS as P inner join EMPLEADOS as E on E.IdPersona = P.Id inner join TIPOS_USUARIOS as T on E.TipoUsuario = T.IdTipoUsuario WHERE E.Activo = 0";
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();
                    aux.persona = new Persona();
                    aux.persona.Id = long.Parse(datos.Lector["Id"].ToString());
                    aux.persona.Nombre = (string)datos.Lector["Nombre"];
                    aux.persona.Apellido = (string)datos.Lector["Apellido"];
                    aux.persona.Email = (string)datos.Lector["Email"];
                    aux.Legajo = long.Parse(datos.Lector["Legajo"].ToString());
                    aux.UserPassword = (string)datos.Lector["UserPassword"];
                    aux.tipoUsuario = new TipoUsuario();
                    aux.tipoUsuario.IdTipoUsuario = int.Parse(datos.Lector["IdTipoUsuario"].ToString());
                    aux.tipoUsuario.Tipo = (string)datos.Lector["Tipo"];
                    aux.FechaIngreso = (DateTime)datos.Lector["FechaIngreso"];
                    aux.ImagenPerfil = datos.Lector["ImagenPerfil"] is DBNull ? "" : (string)datos.Lector["ImagenPerfil"];
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

        public long ObtenerUltimoLegajo()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IDENT_CURRENT('EMPLEADOS')");
                datos.ejecutarLectura();
                long ultimoLegajo = 0;
                if (datos.Lector.Read())
                {
                    ultimoLegajo = datos.Lector.IsDBNull(0) ? 0 : Convert.ToInt64(datos.Lector.GetDecimal(0));
                }

                return ultimoLegajo + 1;

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

        public void Agregar(Empleado nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_AgregarEmpleado");
                datos.setearParametro("@Nombre", nuevo.persona.Nombre);
                datos.setearParametro("@Apellido", nuevo.persona.Apellido);
                datos.setearParametro("@Email", nuevo.persona.Email);
                datos.setearParametro("@UserPassword", nuevo.UserPassword);
                datos.setearParametro("@TipoUsuario", nuevo.tipoUsuario.IdTipoUsuario);
                datos.setearParametro("@FechaIngreso", nuevo.FechaIngreso);
                datos.setearParametro("@Activo", nuevo.Activo);
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

        public void Modificar(Empleado modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_ModificarEmpleado");
                datos.setearParametro("@Legajo", modificar.Legajo);
                datos.setearParametro("@Nombre", modificar.persona.Nombre);
                datos.setearParametro("@Apellido", modificar.persona.Apellido);
                datos.setearParametro("@Email", modificar.persona.Email);
                datos.setearParametro("@UserPassword", modificar.UserPassword);
                datos.setearParametro("@TipoUsuario", modificar.tipoUsuario.IdTipoUsuario);
                datos.setearParametro("@FechaIngreso", modificar.FechaIngreso);
                datos.setearParametro("@Activo", modificar.Activo);
                if (modificar.ImagenPerfil != null && modificar.ImagenPerfil.Length > 0)
                {
                    datos.setearParametro("@ImagenPerfil", modificar.ImagenPerfil);
                }
                else
                {
                    datos.setearParametro("@ImagenPerfil", DBNull.Value);
                }
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

        public void Eliminar(long legajo)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearProcedimiento("sp_EliminarEmpleado");
                datos.setearParametro("@Legajo", legajo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Empleado Buscar(long legajo)
        {
            Empleado aux = new Empleado();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select P.Id, P.Nombre, P.Apellido, P.Email, E.Legajo, E.UserPassword, T.IdTipoUsuario, T.Tipo, E.FechaIngreso, E.Activo, E.ImagenPerfil from PERSONAS as P inner join EMPLEADOS as E on E.IdPersona = P.Id inner join TIPOS_USUARIOS as T on E.TipoUsuario = T.IdTipoUsuario WHERE E.Legajo = " + legajo);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.persona = new Persona();
                    aux.persona.Id = long.Parse(datos.Lector["Id"].ToString());
                    aux.persona.Nombre = (string)datos.Lector["Nombre"];
                    aux.persona.Apellido = (string)datos.Lector["Apellido"];
                    aux.persona.Email = (string)datos.Lector["Email"];
                    aux.Legajo = long.Parse(datos.Lector["Legajo"].ToString());
                    aux.UserPassword = (string)datos.Lector["UserPassword"];
                    aux.tipoUsuario = new TipoUsuario();
                    aux.tipoUsuario.IdTipoUsuario = int.Parse(datos.Lector["IdTipoUsuario"].ToString());
                    aux.tipoUsuario.Tipo = (string)datos.Lector["Tipo"];
                    aux.FechaIngreso = (DateTime)datos.Lector["FechaIngreso"];
                    aux.ImagenPerfil = datos.Lector["ImagenPerfil"] is DBNull ? "" : (string)datos.Lector["ImagenPerfil"];
                    aux.Activo = (bool)datos.Lector["Activo"];

                }

                return aux;
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

        public string DevolverPassword(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string Pass = "";                
                datos.setearConsulta("select emp.UserPassword from EMPLEADOS as emp left join PERSONAS as per on emp.IdPersona = per.Id where per.Email like @email and emp.Activo = 1");
                datos.setearParametro("@email", email);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Pass = (string)datos.Lector["UserPassword"];
                }
                return Pass;
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
