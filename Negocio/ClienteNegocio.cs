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
                datos.setearConsulta("select P.Id, P.Nombre, P.Apellido, P.Email, C.Dni, C.UserPassword, " +
                    "T.NumeroTelefono, C.FechaNacimiento, C.Direccion, C.Activo from PERSONAS as P " +
                    "inner join CLIENTES as C on C.IdPersona = P.Id left join TELEFONOS as T on T.IdPersona = C.IdPersona");
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
                    aux.Contraseña = (string)datos.Lector["UserPassword"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.telefono = new Telefono();
                    if (!(datos.Lector["NumeroTelefono"] is DBNull))
                        aux.telefono.NumeroTelefono = (long)datos.Lector["NumeroTelefono"];
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
