﻿using Dominio;
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
                string consulta = "select P.Id, P.Nombre, P.Apellido, P.Email, E.Legajo, E.UserPassword, T.Tipo, E.FechaIngreso, E.Activo " +
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
                    aux.tipoUsuario.Tipo = (string)datos.Lector["Tipo"];
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

        public long obtenerUltimoLegajo()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select max(Legajo) from EMPLEADOS");
                datos.ejecutarLectura();
                long ultimoLegajo = 0;
                if (datos.Lector.Read())
                {
                    ultimoLegajo = datos.Lector.IsDBNull(0) ? 0 : datos.Lector.GetInt64(0);
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

        public void agregar(Empleado empleado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_AgregarEmpleado");
                datos.setearParametro("@Nombre", empleado.persona.Nombre);
                datos.setearParametro("@Apellido", empleado.persona.Apellido);
                datos.setearParametro("@Email", empleado.persona.Email);
                datos.setearParametro("@UserPassword", empleado.UserPassword);
                datos.setearParametro("@TipoUsuario", empleado.tipoUsuario);
                datos.setearParametro("@FechaIngreso", empleado.FechaIngreso);
                datos.setearParametro("@Activo", empleado.Activo);
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
