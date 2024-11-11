using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProvinciaNegocio
    {
        public List<Provincia> listarProvincias()
        {
            List<Provincia> lista = new List<Provincia>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Nombre, IdPais, Visible FROM PROVINCIAS WHERE Activo = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Provincia aux = new Provincia();
                    aux.Id = (long)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.IdPais = (long)datos.Lector["IdPais"];
                    aux.Visible = (bool)datos.Lector["Visible"];
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

        public List<Provincia> listarProvincias(bool visible)
        {
            List<Provincia> lista = new List<Provincia>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Nombre, IdPais FROM PROVINCIAS WHERE Activo = 1 AND Visible = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Provincia aux = new Provincia();
                    aux.Id = (long)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.IdPais = (long)datos.Lector["IdPais"];
                    aux.Visible = true;
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

        public Provincia buscarProvincia(long id)
        {
            AccesoDatos datos = new AccesoDatos();
            Provincia aux = new Provincia();
            try
            {
                datos.setearConsulta("SELECT IdProvincia, Provincia, Visible, IdPais, Activo FROM vw_ProvinciaYPais WHERE IdProvincia = " + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.Id = (long)datos.Lector["IdProvincia"];
                    aux.Nombre = (string)datos.Lector["Provincia"];
                    aux.Visible = (bool)datos.Lector["Visible"];
                    aux.Activo = true;
                    aux.IdPais = (long)datos.Lector["IdPais"];
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

        public void Agregar(Provincia nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Provincias (Nombre, IdPais, Visible, Activo) VALUES (@Nombre, @IdPais, @Visible, 1)");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@IdPais", nuevo.IdPais);
                datos.setearParametro("@Visible", nuevo.Visible);

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

        public void Modificar(Provincia nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Provincias SET Nombre = @Nombre, Visible = @Visible, IdPais = @IdPais WHERE Id = @Id");
                datos.setearParametro("@Id", nueva.Id);
                datos.setearParametro("@Nombre", nueva.Nombre);
                datos.setearParametro("@Visible", nueva.Visible);
                datos.setearParametro("@IdPais", nueva.IdPais);

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

        public void Eliminar(long id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Provincias SET Activo = 0 WHERE Id = @Id");
                datos.setearParametro("@Id", id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
