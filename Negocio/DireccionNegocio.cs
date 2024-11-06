using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DireccionNegocio
    {
        public List<Direccion> listar()
        {
            List<Direccion> lista = new List<Direccion>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT d.Id, d.Calle, d.Numero, d.Localidad, d.CodPostal, p.Id as IdProvincia, p2.Id as IdPais, d.DniCliente, d.Activo from DIRECCIONES d INNER JOIN PROVINCIAS p ON d.IdProvincia = p.Id INNER JOIN PAISES p2 ON p.IdPais = p2.Id WHERE d.Activo = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Direccion aux = new Direccion();
                    aux.Id = (long)datos.Lector["Id"];
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Numero = (long)datos.Lector["Numero"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.CodPostal = (string)datos.Lector["CodPostal"];
                    aux.provincia = new Provincia();
                    ProvinciaNegocio negocioProv = new ProvinciaNegocio();
                    aux.provincia.Id = (long)datos.Lector["IdProvincia"];
                    aux.provincia = negocioProv.buscarProvincia(aux.provincia.Id);
                    aux.provincia.pais = new Pais();
                    PaisNegocio negocioPais = new PaisNegocio();
                    aux.provincia.pais.Id = (long)datos.Lector["IdPais"];
                    aux.provincia.pais = negocioPais.buscarPais(aux.provincia);
                    ClienteNegocio clienteNegocio = new ClienteNegocio();
                    long dni = (long)datos.Lector["DniCliente"];
                    aux.cliente = clienteNegocio.BuscarCliente(dni);
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

        public Direccion buscarDireccion(long id)
        {
            AccesoDatos datos = new AccesoDatos();
            Direccion aux = new Direccion();
            try
            {
                datos.setearConsulta("SELECT d.Id, d.Calle, d.Numero, d.Localidad, d.CodPostal, p.Id as IdProvincia, p2.Id as IdPais, d.DniCliente, d.Activo from DIRECCIONES d INNER JOIN PROVINCIAS p ON d.IdProvincia = p.Id INNER JOIN PAISES p2 ON p.IdPais = p2.Id WHERE d.Activo = 1 AND d.Id = " + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.Id = (long)datos.Lector["Id"];
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Numero = (long)datos.Lector["Numero"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.CodPostal = (string)datos.Lector["CodPostal"];
                    aux.provincia = new Provincia();
                    ProvinciaNegocio negocioProv = new ProvinciaNegocio();
                    aux.provincia.Id = (long)datos.Lector["IdProvincia"];
                    aux.provincia = negocioProv.buscarProvincia(aux.provincia.Id);
                    aux.provincia.pais = new Pais();
                    PaisNegocio negocioPais = new PaisNegocio();
                    aux.provincia.pais.Id = (long)datos.Lector["IdPais"];
                    aux.provincia.pais = negocioPais.buscarPais(aux.provincia);
                    aux.cliente = new Cliente();
                    aux.cliente.Dni = (long)datos.Lector["DniCliente"];
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

        public void agregarDireccion(Direccion nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Direcciones (Calle, Numero, Localidad, CodPostal, IdProvincia, DniCliente, Activo) VALUES (@Calle, @Numero, @Localidad, @CP, @IdProvincia, @DniCliente, 1)");
                datos.setearParametro("@Calle", nuevo.Calle);
                datos.setearParametro("@Numero", nuevo.Numero);
                datos.setearParametro("@Localidad", nuevo.Localidad);
                datos.setearParametro("@CP", nuevo.CodPostal);
                datos.setearParametro("@IdProvincia", nuevo.provincia.Id);
                datos.setearParametro("@DniCliente", nuevo.cliente.Dni);


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

        public void modificarDireccion(Direccion nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Direcciones SET Calle = @Calle, Numero = @Numero, Localidad = @Localidad, CodPostal = @CP, IdProvincia = @IdProvincia, DniCliente = @DniCliente WHERE Id = " + nuevo.Id);
                datos.setearParametro("@Calle", nuevo.Calle);
                datos.setearParametro("@Numero", nuevo.Numero);
                datos.setearParametro("@Localidad", nuevo.Localidad);
                datos.setearParametro("@CP", nuevo.CodPostal);
                datos.setearParametro("@IdProvincia", nuevo.provincia.Id);
                datos.setearParametro("@DniCliente", nuevo.cliente.Dni);


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

        public void eliminarDireccion(long id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Direcciones SET Activo = 0 WHERE Id = " + id);

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
