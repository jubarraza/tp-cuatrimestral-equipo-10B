using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Comentario
    {

        public int id {  get; set; }
        
        public int Cod_Incidencia {  get; set; }

        public string ComentarioGestion {  get; set; }

        public DateTime Fecha { get; set; }

        public Empleado Usuario {  get; set; }

    }
}
