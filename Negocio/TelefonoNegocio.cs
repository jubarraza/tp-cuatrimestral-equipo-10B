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

        public void agregarTelefono(Telefono nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Telefonos (NumeroTelefono, IdPersona) VALUES (@Numero, @IdPersona)");
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
    }
}
