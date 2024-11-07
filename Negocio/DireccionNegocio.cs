using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                datos.setearConsulta("SELECT d.Id, d.Calle, d.Numero, d.Localidad, d.CodPostal, d.IdProvincia, d.NombreApellidoCliente FROM vw_listaDireccionYCliente d WHERE d.Activo = 1 ");
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
                    aux.NombreApellidoCliente = (string)datos.Lector["NombreApellidoCliente"];
                    aux.Activo = true;
                    
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
                datos.setearConsulta("SELECT Id, Calle, Numero, Localidad, CodPostal, IdProvincia, Provincia, VisibleProvincia, ActivoProvincia, IdPais, Pais, ActivoPais, Activo, IdPersona, NombreApellidoCliente FROM vw_listaDireccionYCliente d WHERE Activo = 1 AND Id = " + id);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.Id = (long)datos.Lector["Id"];
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Numero = (long)datos.Lector["Numero"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.CodPostal = (string)datos.Lector["CodPostal"];
                    aux.provincia = new Provincia();
                    aux.provincia.Id = (long)datos.Lector["IdProvincia"];
                    aux.provincia.Nombre = (string)datos.Lector["Provincia"];
                    aux.provincia.Visible = (bool)datos.Lector["VisibleProvincia"];
                    aux.provincia.Activo = (bool)datos.Lector["ActivoProvincia"];
                    aux.provincia.pais = new Pais();
                    aux.provincia.pais.Id = (long)datos.Lector["IdPais"];
                    aux.provincia.pais.Nombre = (string)datos.Lector["Pais"];
                    aux.provincia.pais.Activo = (bool)datos.Lector["ActivoPais"];
                    aux.NombreApellidoCliente = (string)datos.Lector["NombreApellidoCliente"];
                    aux.Activo = true;
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

        public int agregarDireccion(Direccion nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Direcciones (Calle, Numero, Localidad, CodPostal, IdProvincia, Activo) VALUES (@Calle, @Numero, @Localidad, @CP, @IdProvincia, 1); SELECT @@IDENTITY");
                datos.setearParametro("@Calle", nuevo.Calle);
                datos.setearParametro("@Numero", nuevo.Numero);
                datos.setearParametro("@Localidad", nuevo.Localidad);
                datos.setearParametro("@CP", nuevo.CodPostal);
                datos.setearParametro("@IdProvincia", nuevo.provincia.Id);


                return datos.EjecutarAccionScalar();

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
                datos.setearConsulta("UPDATE Direcciones SET Calle = @Calle, Numero = @Numero, Localidad = @Localidad, CodPostal = @CP, IdProvincia = @IdProvincia WHERE Id = " + nuevo.Id);
                datos.setearParametro("@Calle", nuevo.Calle);
                datos.setearParametro("@Numero", nuevo.Numero);
                datos.setearParametro("@Localidad", nuevo.Localidad);
                datos.setearParametro("@CP", nuevo.CodPostal);
                datos.setearParametro("@IdProvincia", nuevo.provincia.Id);


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
