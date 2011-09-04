using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Ubicacion
    {
        public Ubicacion(Localidad localidad, string domicilio)
        {
            this.localidad = localidad; this.domicilio = domicilio;
        }

        Localidad localidad;
        string domicilio;

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
