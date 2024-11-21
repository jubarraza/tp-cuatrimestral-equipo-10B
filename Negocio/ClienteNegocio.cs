using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select P.Id, P.Nombre, P.Apellido, P.Email, C.Dni, C.FechaNacimiento, C.IdDireccion, C.Activo from PERSONAS as P " +
                    "inner join CLIENTES as C on C.IdPersona = P.Id WHERE C.Activo = 1");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.persona = new Persona();
                    aux.persona.Id = int.Parse(datos.Lector["Id"].ToString());
                    aux.persona.Nombre = (string)datos.Lector["Nombre"];
                    aux.persona.Apellido = (string)datos.Lector["Apellido"];
                    aux.persona.Email = (string)datos.Lector["Email"];
                    aux.Dni = long.Parse(datos.Lector["Dni"].ToString());
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.direccion = new Direccion();
                    aux.direccion.Id = (long)datos.Lector["IdDireccion"];
                    DireccionNegocio direNegocio = new DireccionNegocio();
                    aux.direccion = direNegocio.buscarDireccion(aux.direccion.Id);
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

        public List<Cliente> listar(bool conInactivos)
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (conInactivos)
                {
                datos.setearConsulta("select P.Id, P.Nombre, P.Apellido, P.Email, C.Dni, C.FechaNacimiento, C.IdDireccion, C.Activo from PERSONAS as P " +
                    "inner join CLIENTES as C on C.IdPersona = P.Id");
                }
                else
                {
                    datos.setearConsulta("select P.Id, P.Nombre, P.Apellido, P.Email, C.Dni, C.FechaNacimiento, C.IdDireccion, C.Activo from PERSONAS as P " +
                    "inner join CLIENTES as C on C.IdPersona = P.Id WHERE C.Activo = 1");
                }
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.persona = new Persona();
                    aux.persona.Id = int.Parse(datos.Lector["Id"].ToString());
                    aux.persona.Nombre = (string)datos.Lector["Nombre"];
                    aux.persona.Apellido = (string)datos.Lector["Apellido"];
                    aux.persona.Email = (string)datos.Lector["Email"];
                    aux.Dni = long.Parse(datos.Lector["Dni"].ToString());
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.direccion = new Direccion();
                    aux.direccion.Id = (long)datos.Lector["IdDireccion"];
                    DireccionNegocio direNegocio = new DireccionNegocio();
                    aux.direccion = direNegocio.buscarDireccion(aux.direccion.Id);
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

        public Cliente BuscarCliente(long dni)
        {
            Cliente aux = new Cliente();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select P.Id, P.Nombre, P.Apellido, P.Email, C.Dni, C.FechaNacimiento, C.IdDireccion, C.Activo from PERSONAS as P " +
                    "inner join CLIENTES as C on C.IdPersona = P.Id WHERE C.Dni = " + dni);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    
                    aux.persona = new Persona();
                    aux.persona.Id = int.Parse(datos.Lector["Id"].ToString());
                    aux.persona.Nombre = (string)datos.Lector["Nombre"];
                    aux.persona.Apellido = (string)datos.Lector["Apellido"];
                    aux.persona.Email = (string)datos.Lector["Email"];
                    aux.Dni = long.Parse(datos.Lector["Dni"].ToString());
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];

                    aux.direccion = new Direccion();
                    DireccionNegocio direccionNegocio = new DireccionNegocio();
                    aux.direccion.Id = (long)datos.Lector["IdDireccion"];
                    aux.direccion = direccionNegocio.buscarDireccion(aux.direccion.Id);
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
        public void agregarCliente(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_RegistrarCliente");
                datos.setearParametro("@Nombre", nuevo.persona.Nombre);
                datos.setearParametro("@Apellido", nuevo.persona.Apellido);
                datos.setearParametro("@Email", nuevo.persona.Email);
                datos.setearParametro("@Dni", nuevo.Dni);
                datos.setearParametro("@FechaNac", nuevo.FechaNacimiento);
                datos.setearParametro("@Calle", nuevo.direccion.Calle);
                datos.setearParametro("@Numero", nuevo.direccion.Numero);
                datos.setearParametro("@Localidad", nuevo.direccion.Localidad);
                datos.setearParametro("@CodPostal", nuevo.direccion.CodPostal);
                datos.setearParametro("@IdProvincia", nuevo.direccion.provincia.Id);

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
        public void modificarCliente(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ModificarCliente");
                datos.setearParametro("@Nombre", nuevo.persona.Nombre);
                datos.setearParametro("@Apellido", nuevo.persona.Apellido);
                datos.setearParametro("@Email", nuevo.persona.Email);
                datos.setearParametro("@Dni", nuevo.Dni);
                datos.setearParametro("@FechaNac", nuevo.FechaNacimiento);
                datos.setearParametro("@IdDireccion", nuevo.direccion.Id);
                datos.setearParametro("@Activo", nuevo.Activo);
                datos.setearParametro("@Calle", nuevo.direccion.Calle);
                datos.setearParametro("@Numero", nuevo.direccion.Numero);
                datos.setearParametro("@Localidad", nuevo.direccion.Localidad);
                datos.setearParametro("@CodPostal", nuevo.direccion.CodPostal);
                datos.setearParametro("@IdProvincia", nuevo.direccion.provincia.Id);

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

        public void eliminarCliente(long dni)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Clientes SET Activo = 0 WHERE Dni = " + dni);


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
