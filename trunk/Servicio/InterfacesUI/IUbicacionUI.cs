using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface IUbicacionUI
    {
        string NombrePais { get; }
        string NombreProvincia { get; }
        string NombreLocalidad { get; }
    }
}
