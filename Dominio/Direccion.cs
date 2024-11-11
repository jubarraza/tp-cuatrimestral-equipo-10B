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
        public Pais pais { get; set; }
        public string NombreApellidoCliente { get; set; }

        public override string ToString()
        {
            string dire = Calle +", " + Numero + ", " + Localidad + ". " + provincia.Nombre + ", " + pais.Nombre ;
            return dire;
        }
    }




}
