using Dominio;
using System;
using System.Collections.Generic;
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
                    //aux.direccion.cliente = new Cliente();
                    ClienteNegocio clienteNegocio = new ClienteNegocio();
                    //aux.direccion.cliente = clienteNegocio.BuscarCliente(aux.Dni);
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
                datos.setearConsulta("select P.Id, P.Nombre, P.Apellido, P.Email, C.Dni, " +
                    "T.NumeroTelefono, C.FechaNacimiento, C.IdDireccion, C.Activo from PERSONAS as P " +
                    "inner join CLIENTES as C on C.IdPersona = P.Id left join TELEFONOS as T on T.IdPersona = C.IdPersona WHERE C.Dni = " + dni);

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
                    aux.telefono = new Telefono();
                    if (!(datos.Lector["NumeroTelefono"] is DBNull))
                        aux.telefono.NumeroTelefono = (long)datos.Lector["NumeroTelefono"];
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
                datos.setearConsulta("INSERT INTO Clientes (IdPersona, Dni, FechaNacimiento, IdDireccion, Activo) VALUES (@IdPersona, @Dni, @FechaNac, @IdDireccion, 1)");
                datos.setearParametro("@IdPersona", nuevo.persona.Id);
                datos.setearParametro("@Dni", nuevo.Dni);
                datos.setearParametro("@FechaNac", nuevo.FechaNacimiento);
                datos.setearParametro("@IdDireccion", nuevo.direccion.Id);


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
                datos.setearConsulta("UPDATE Personas SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email WHERE Id = " + nuevo.persona.Id);
                datos.setearParametro("@Nombre", nuevo.persona.Nombre);
                datos.setearParametro("@Apellido", nuevo.persona.Apellido);
                datos.setearParametro("@Email", nuevo.persona.Email);
                datos.ejecutarAccion();



                datos.setearConsulta("UPDATE Clientes SET Dni = @Dni, FechaNacimiento = @FechaNac, IdDireccion = @IdDireccion WHERE Id = " + nuevo.persona.Id);
                datos.setearParametro("@Dni", nuevo.Dni);
                datos.setearParametro("@FechaNac", nuevo.FechaNacimiento);
                datos.setearParametro("@IdDireccion", nuevo.direccion.Id);


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
