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

        public Cliente cliente { get; set; } 

        public Empleado Empleado { get; set; } 

        public string Descripcion { get; set; } 

        public Estado Estado { get; set; } 

        public Prioridad Prioridad { get; set; } 

        public TipoIncidencia Tipo { get; set; } 

        public DateTime FechaAlta { get; set; } 


        public DateTime? FechaCierre { get; set; } 

        public string Resolucion { get; set; } 

    }
}
