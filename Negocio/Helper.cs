using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Helper
    {
        public static bool validarSoloNumeros(string texto)
        {
            foreach (char N in texto)
            {
                if (char.IsLetter(N))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool validarEmail(string email)
        {
            string formato;
            formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]w+)*";
            if (Regex.Replace(email, formato, string.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ObtenerNombrePais(object idPais)
        {
            string nombre;
            PaisNegocio paisNegocio = new PaisNegocio();
            Pais aux = new Pais();
            long id = long.Parse(idPais.ToString());

            aux = paisNegocio.buscarPais(id);
            nombre = aux.Nombre;

            return nombre;
        }

        public static bool SessionActiva(Object user)
        {
            Empleado empleadoUser = user != null ? (Empleado)user : null;
            if (empleadoUser != null)
            {
                return true;
            }
            return false;
        }

        public static int consultaTipoUsuario(Object user)
        {
            Empleado empleadoUser = user != null ? (Empleado)user : null;
            return empleadoUser.tipoUsuario.IdTipoUsuario;
        }
    }
}
