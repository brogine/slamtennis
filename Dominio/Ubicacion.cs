using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Ubicacion
    {
        public Ubicacion(Provincia provincia, Localidad localidad, string domicilio)
        {
            this.provincia = provincia; this.localidad = localidad;
            this.domicilio = domicilio;
        }

        Provincia provincia;
        Localidad localidad;
        string domicilio;

        public Provincia Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        public Localidad Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        public String Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }
    }
}
