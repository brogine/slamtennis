using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Ubicacion
    {
        public Ubicacion(string provincia, string localidad, string domicilio)
        {
            this.provincia = provincia; this.localidad = localidad;
            this.domicilio = domicilio;
        }

        string provincia;
        string localidad;
        string domicilio;

        public String Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        public String Localidad
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
