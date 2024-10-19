using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoIncidencia
    {
        public int IdIncidencia { get; set; }
        public string Abierto { get; set; }
        public string Asignado { get; set; }
        public string Analisis { get; set; }
        public string Resuelto { get; set; }
        public string Cerrado { get; set; }

    }
}
