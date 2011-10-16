using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Dominio
{
    public class Empleado : Persona
    {
    	public Empleado() {}
        public Empleado(int dni, string nombre, string apellido, DateTime fechanac, Pais nacionalidad, string sexo,
            bool estado, Ubicacion ubicacion, Contacto contacto, string puesto, Image foto)
        {
            this.Dni = dni; this.Nombre = nombre; this.Apellido = apellido; this.FechaNac = fechanac; 
            this.Nacionalidad = nacionalidad; this.Sexo = sexo; this.Estado = estado; this.Contacto = contacto; 
            this.Ubicacion = ubicacion; this.puesto = puesto;
            if (foto != null)
                this.Foto = ImagenABytes(foto);
        }

        string puesto;
       
        bool estado;

        public string Puesto
        {
            get { return puesto; }
            set { puesto = value; }
        }
        
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
