using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        public long Id { get; set; }
        public string Calle { get; set; }
        public long Numero { get; set; }
        public string Localidad { get; set; }
        public string CodPostal { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public Cliente Usuario { get; set; }
        public bool Activo { get; set; }
    }
}
