using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class TelefonoNegocio
    {
        public List<Telefono> listar()
        {
            List<Telefono> lista = new List<Telefono>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select IdPersona, IdTelefono, NumeroTelefono from TELEFONOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Telefono aux = new Telefono();
                    aux.IdTelefono = (int)datos.Lector["IdTelefono"];
                    aux.NumeroTelefono = (long)datos.Lector["NumeroTelefono"];
                    aux.persona = new Persona();
                    aux.persona.Id = (long)datos.Lector["IdPersona"];

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

        public List<Telefono> BuscarTelefonos(long id)
        {
            TelefonoNegocio telefonoNegocio = new TelefonoNegocio();
            List<Telefono> listaTelefonos = telefonoNegocio.listar();
            List<Telefono> listaXCliente = new List<Telefono>();

            foreach (Telefono tel in listaTelefonos)
            {
                if (tel.persona.Id == id)
                {
                    listaXCliente.Add(tel);
                }
            }

            if (listaXCliente.Count == 0)
            {
                return null;
            }
            else
            {
                return listaXCliente;
            }
        }

        public Telefono buscarTelefono(int id)
        {
            try
            {
                TelefonoNegocio telefonoNegocio = new TelefonoNegocio();
                List<Telefono> listaTelefonos = telefonoNegocio.listar();

                foreach (Telefono tel in listaTelefonos)
                {
                    if (tel.IdTelefono == id)
                    {
                        return tel;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        public void agregarTelefono(Telefono nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Telefonos (NumeroTelefono, IdPersona) VALUES (@NumeroTelefono, @IdPersona)");
                datos.setearParametro("@NumeroTelefono", nuevo.NumeroTelefono);
                datos.setearParametro("@IdPersona", nuevo.persona.Id);


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

        public void eliminarTelefono(long numero, long idPersona)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE Telefonos WHERE NumeroTelefono = @NumeroTelefono AND  IdPersona = @IdPersona");
                datos.setearParametro("@NumeroTelefono", numero);
                datos.setearParametro("@IdPersona", idPersona);


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

        public void eliminarTelefono(int idTelefono)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE Telefonos WHERE IdTelefono = @IdTelefono");
                datos.setearParametro("@IdTelefono", idTelefono);


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

        public void editarTelefono(Telefono tel)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE TELEFONOS SET NumeroTelefono = @NumTelefono WHERE IdTelefono = @IdTelefono AND IdPersona = @IdPersona");
                datos.setearParametro("@NumTelefono", tel.NumeroTelefono);
                datos.setearParametro("@IdTelefono", tel.IdTelefono);
                datos.setearParametro("@IdPersona", tel.persona.Id);
           

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
