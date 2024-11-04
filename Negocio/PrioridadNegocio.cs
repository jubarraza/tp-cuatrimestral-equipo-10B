using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PrioridadNegocio
    {
        public List<Prioridad> listar()
        {
            List<Prioridad> lista = new List<Prioridad>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id, Nombre, Activa from PRIORIDADES");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Prioridad aux = new Prioridad();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Activa = (bool)datos.Lector["Activa"];

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

        public void Agregar(Prioridad nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Prioridades (Nombre, Activa) VALUES (@Nombre, @Activa)");
                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Activa", nuevo.Activa);

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

        public Prioridad Buscar(int id)
        {
            PrioridadNegocio neg = new PrioridadNegocio();

            List<Prioridad> lista = neg.listar();

            foreach (Prioridad p in lista)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }

            return null;

        }

        public void Modificar(Prioridad nueva)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Prioridades SET Nombre = @Nombre, Activa = @Activa WHERE Id = @Id");
                datos.setearParametro("@Id", nueva.Id);
                datos.setearParametro("@Nombre", nueva.Nombre);
                datos.setearParametro("@Activa", nueva.Activa);

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
