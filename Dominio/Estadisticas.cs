using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Estadisticas
    {
        /// <summary>
        /// Constructor de Estadísticas de Usuario
        /// </summary>
        /// <param name="categoria">categoria a la que pertenece la estadistica</param>
        /// <param name="pp">partidos perdidos</param>
        /// <param name="pg">partidos ganados</param>
        /// <param name="puntos">puntaje total en esa categoria</param>
        public Estadisticas(Categoria categoria, int pp, int pg, int puntos)
        {
            this.categoria = categoria; this.pp = pp; this.pg = pg;
            this.puntaje = puntos;
        }

        Categoria categoria;
        int pp;
        int pg;
        int pj;
        int puntaje;

        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public int PP
        {
            get { return pp; }
            set { pp = value; }
        }

        public int PG
        {
            get { return pg; }
            set { pg = value; }
        }

        public int PJ
        {
            get { return pj; }
            set { pj = pg + pp; }
        }

        public int Puntaje
        {
            get { return puntaje; }
            set { puntaje = value; }
        }
    }
}
