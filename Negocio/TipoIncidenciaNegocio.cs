using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoIncidenciaNegocio
    {
        public List<TipoIncidencia> listar()
        {
            List<TipoIncidencia> lista = new List<TipoIncidencia>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Nombre, Visible, Activo from TIPO_INCIDENCIA WHERE Activo = 1");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    TipoIncidencia aux = new TipoIncidencia();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Visible = (bool)datos.Lector["Visible"];
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

        public List<TipoIncidencia> listar(bool visible)
        {
            List<TipoIncidencia> lista = new List<TipoIncidencia>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Nombre, Visible, Activo from TIPO_INCIDENCIA WHERE Activo = 1 AND Visible = 1");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    TipoIncidencia aux = new TipoIncidencia();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Visible = (bool)datos.Lector["Visible"];
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

        public TipoIncidencia Buscar(int id)
        {
            TipoIncidenciaNegocio neg = new TipoIncidenciaNegocio();

            List<TipoIncidencia> lista = neg.listar();

            foreach (TipoIncidencia p in lista)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }

            return null;

        }

        public void Agregar(TipoIncidencia nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO TIPO_INCIDENCIA (Nombre, Visible, Activo) VALUES (@Nombre, @Visible, 1)");
                datos.setearParametro("@Nombre", nuevo.Nombre);
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

        public void Modificar(TipoIncidencia nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE TIPO_INCIDENCIA SET Nombre = @Nombre, Visible = @Visible WHERE Id = @Id");
                datos.setearParametro("@Id", nueva.Id);
                datos.setearParametro("@Nombre", nueva.Nombre);
                datos.setearParametro("@Visible", nueva.Visible);

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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE TIPO_INCIDENCIA SET Activo = 0 WHERE Id = @Id");
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
