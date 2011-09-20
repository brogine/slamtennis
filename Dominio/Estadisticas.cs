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
        /// <param name="estado">estado de las jugador en esa categoría</param>
        public Estadisticas(Categoria categoria, int pp, int pg, int puntos, int tc, int tj, bool estado)
        {
            this.categoria = categoria; this.pp = pp; this.pg = pg;
            this.puntaje = puntos; this.estado = estado; this.tc = tc; this.tj = tj;
        }

        public Estadisticas(int dni, Categoria categoria, int pp, int pg, int puntos, int tc, int tj, bool estado)
        {
            this.dni = dni; this.categoria = categoria; this.pp = pp; this.pg = pg;
            this.puntaje = puntos; this.estado = estado; this.tc = tc; this.tj = tj;
        }

        int dni;
        Categoria categoria;
        int pp;
        int pg;
        int pj;
        int puntaje;
        int tj;
        int tc;
        bool estado;

        public int Dni{
        	get { return dni; } 
        	set { dni = value; }
        }
        
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

        public int TorneosJugados
        {
            get { return tj; }
            set { tj = value; }
        }

        public int TorneosCompletados
        {
            get { return tc; }
            set { tc = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
