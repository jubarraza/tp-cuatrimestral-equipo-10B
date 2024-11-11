using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Provincia
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public bool Visible { get; set; }
        public bool Activo { get; set; }
        public long IdPais { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
