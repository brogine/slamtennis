using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Club
    {
        /// <summary>
        /// Constructor de nuevo Club sin Presidente
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="estado"></param>
        public Club(string nombre, bool estado)
        {
            this.nombre = nombre; this.estado = estado;
        }
        
        /// <summary>
        /// Constructor de nuevo Club con Presidente
        /// </summary>
        /// <param name="presidente"></param>
        /// <param name="nombre"></param>
        /// <param name="estado"></param>
        public Club(Empleado presidente, string nombre, bool estado)
        {
            this.presidente = presidente; this.nombre = nombre;
            this.estado = estado;
        }

        /// <summary>
        /// Constructor de Club con Presidente para búsquedas
        /// </summary>
        /// <param name="id"></param>
        /// <param name="presidente"></param>
        /// <param name="nombre"></param>
        /// <param name="estado"></param>
        public Club(int id, Empleado presidente, string nombre, bool estado)
        {
            this.id = id; this.presidente = presidente; this.nombre = nombre;
            this.estado = estado;
        }

        int id;
        Empleado presidente;
        string nombre;
        bool estado;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Empleado Presidente
        {
            get { return presidente; }
            set { presidente = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        
    }
}
