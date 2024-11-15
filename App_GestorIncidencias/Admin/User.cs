using Dominio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace App_GestorIncidencias.Admin
{
    public class User
    {
         public int Legajo {  get; set; }

         public string Usuario { get; set; }

        public string Password { get; set; }   
        
        public TipoUsuario TipoUser { get; set; }

        public string Nombre { get; set; }

        public string Apelllido { get; set; }
    }
}