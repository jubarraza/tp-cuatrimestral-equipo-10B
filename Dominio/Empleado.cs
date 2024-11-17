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
        public long Legajo { get; set; }
        public string UserPassword { get; set; }
        public TipoUsuario tipoUsuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; }
        public string ImagenPerfil {  get; set; }

        public string NombreCompleto
        {
            get { return Legajo + " - " + persona.Nombre + " " + persona.Apellido; }
        }

        public override string ToString()
        {
            return Legajo + " - " +persona.Nombre + " " + persona.Apellido;
        }
    }

}
