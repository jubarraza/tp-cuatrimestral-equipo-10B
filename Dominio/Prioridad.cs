﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Prioridad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activa { get; set; }

        public override string ToString()
        {
            return Nombre.ToString(); 
        }
    }
}
