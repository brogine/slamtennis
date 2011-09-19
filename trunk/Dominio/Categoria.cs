using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Categoria
    {
        int id;
        string nombre;
        int edadMin;
        int edadMax;
        bool estado;
        public Categoria(int idcategoria, string nombre, int edadmin, int edadmax, bool estado)
        {
            this.id = idcategoria;
            this.nombre = nombre;
            this.edadMin = edadmin;
            this.edadMax = edadmax;
            this.estado = estado;
        }

        public Categoria(string nombre, int edadmin, int edadmax, bool estado)
        {
            this.nombre = nombre;
            this.edadMin = edadmin;
            this.edadMax = edadmax;
            this.estado = estado;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int EdadMin
        {
            get { return edadMin; }
            set { edadMin = value; }
        }

        public int EdadMax
        {
            get { return edadMax; }
            set { edadMax = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
