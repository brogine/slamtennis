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
    }
}
