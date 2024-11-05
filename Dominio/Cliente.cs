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
        public long Dni { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Telefono telefono { get; set; } ///Crear Clase Telefonos
        public string Direccion { get; set; } ///ClaseDireccion
        public bool Activo { get; set; }

    }
}
