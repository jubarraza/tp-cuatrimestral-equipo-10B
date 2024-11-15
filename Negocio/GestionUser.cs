using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class GestionUser
    {
        public string loguear(string email, string Password)
        {
            AccesoDatos datos = new AccesoDatos();
            string legajo = "";
            try
            {
                datos.setearConsulta("select Legajo from EMPLEADOS as Emp left join PERSONAS as Per on Emp.IdPersona = Per.Id where Per.Email like @User and Emp.UserPassword like @Password");
                datos.setearParametro("@User", email);
                datos.setearParametro("@Password", Password);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    legajo = datos.Lector["Legajo"].ToString();

                    return legajo;

                }
                return legajo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error de logueo", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
