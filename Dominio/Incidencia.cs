using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Incidencia
    {
        public int Id { get; set; }

        public int Tipo { get; set; }

        public string Descripcion { get; set; }

        public int Estado { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime FechaBaja { get; set; }

        public string Resolucion { get; set; }


    }
}
