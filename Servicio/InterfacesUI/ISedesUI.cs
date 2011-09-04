using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface ISedesUI
    {
        int IdSede { get; set; }

        int IdClub { get; set; }

        string Direccion { get; set; }

        int IdLocalidad { get; set; }

        string Telefono { get; set; }

        string Celular { get; set; }

        string Email { get; set; }
    }
}
