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
                datos.setearConsulta("SELECT d.Id, d.Calle, d.Numero, d.Localidad, d.CodPostal, p.Nombre as Provincia, p2.Nombre as Pais, d.DniCliente, d.Activo from DIRECCIONES d INNER JOIN PROVINCIAS p ON d.IdProvincia = p.Id INNER JOIN PAISES p2 ON p.IdPais = p2.Id WHERE d.Activo = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Direccion aux = new Direccion();
                    aux.Id = (long)datos.Lector["Id"];
                    aux.Calle = (string)datos.Lector["Calle"];
                    aux.Numero = (long)datos.Lector["Numero"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.CodPostal = (string)datos.Lector["CodPostal"];
                    aux.Provincia = (string)datos.Lector["Provincia"];
                    aux.Pais = (string)datos.Lector["Pais"];
                    ClienteNegocio clienteNegocio = new ClienteNegocio();
                    long dni = (long)datos.Lector["DniCliente"];
                    aux.Usuario = clienteNegocio.BuscarCliente(dni);
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
    }
}
