﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using System.Drawing;

namespace Servicio.InterfacesUI
{
    public interface IJugadorUI
    {
        int Dni { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        DateTime FechaNac { get; set; }
        int Nacionalidad { get; set; }
        string Sexo { get; set; }
        string Tutor { get; set; }
        int Edad { get; set; }
        string RelacionTutor { get; set; }
        string Telefono { get; set; }
        string Celular { get; set; }
        string Email { get; set; }
        int Pais { get; set; }
        int Provincia { get; set; }
        int Localidad { get; set; }
        string Domicilio { get; set; }
        string Usuario { get; set; }
        string Password { get; set; }
        bool Estado { get; set; }
    }
}
