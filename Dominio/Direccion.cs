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
        public Provincia provincia { get; set; }
        public string NombreApellidoCliente { get; set; }
        public bool Activo { get; set; }

        public override string ToString()
        {
            provincia.pais = new Pais();
            string dire = Calle +", " + Numero + ", " + Localidad + ". " + provincia.Nombre + ", " + provincia.pais.Nombre ;
            return dire;
        }
    }




}
