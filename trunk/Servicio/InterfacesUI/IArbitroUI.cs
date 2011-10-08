using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Servicio.InterfacesUI
{
    public interface IArbitroUI
    {
        int Dni { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        DateTime FechaNac { get; set; }
        int Nacionalidad { get; set; }
        string Sexo { get; set; }
        string Badge { get; set; }
        int Nivel { get; set; }
       
        string Telefono { get; set; }
        string Celular { get; set; }
        string Email { get; set; }
        int Provincia { get; set; }
        int Localidad { get; set; }
        string Domicilio { get; set; }
        string Usuario { get; set; }
        string Password { get; set; }
        bool Estado { get; set; }
    }
}
