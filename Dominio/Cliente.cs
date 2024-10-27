using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public Persona persona { get; set; }
        public int Dni { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Telefono { get; set; } ///Crear Clase Telefonos
        public string Direccion { get; set; } ///ClaseDireccion
        public bool Activo { get; set; }

    }
}
