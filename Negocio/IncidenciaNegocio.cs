﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocio
{
    public class IncidenciaNegocio
    {
        public List<Incidencia> listar()
        {
            List<Incidencia> lista = new List<Incidencia>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select codigo, Tipo, Descripcion, Estado, FechaAlta from INCIDENCIAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidencia aux = new Incidencia();
                    aux.Id = (int)datos.Lector["codigo"];
                    aux.Tipo = (int)datos.Lector["Tipo"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = (int)datos.Lector["Estado"];
                    //aux.FechaAlta = DateTime.Parse(datos.Lector["FechaAlta"].ToString());
                    //aux.FechaBaja = DateTime.Parse(datos.Lector["FechaBaja"].ToString());
                    //aux.Resolucion = (string)datos.Lector["Resolucion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
