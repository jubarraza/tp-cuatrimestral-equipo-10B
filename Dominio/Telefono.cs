using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Telefono
    {
        public int IdTelefono { get; set; }
        public long NumeroTelefono { get; set; }
        public Persona persona { get; set; }
    }
}
