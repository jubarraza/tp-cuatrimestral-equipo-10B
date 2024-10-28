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
                datos.setearConsulta("select P.Id, P.Nombre, P.Apellido, P.Email, C.Dni, C.Contraseña," +
                    "C.FechaNacimiento, C.Telefono, C.Direccion, C.Activo from PERSONAS as P inner join CLIENTES as C on C.IdPersona = P.Id;");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.persona = new Persona();
                    aux.persona.Id = (int)datos.Lector["Id"];
                    aux.persona.Nombre = (string)datos.Lector["Nombre"];
                    aux.persona.Apellido = (string)datos.Lector["Apellido"];
                    aux.persona.Email = (string)datos.Lector["Email"];
                    aux.Dni = (int)datos.Lector["Dni"];
                    aux.Contraseña = (string)datos.Lector["Contraseña"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.Telefono = (long)datos.Lector["Telefono"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
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
