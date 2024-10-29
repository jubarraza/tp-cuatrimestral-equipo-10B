using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado
    {
        public Persona persona { get; set; }
        public int Legajo { get; set; }
        public string Contraseña { get; set; }
        public int TipoUsuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; }

    }
}
