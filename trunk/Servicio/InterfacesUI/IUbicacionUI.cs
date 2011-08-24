using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
    public interface IUbicacionUI
    {
        int IdPais { get; }
        string NombrePais { get; }
        int IdProvincia { get; }
        string NombreProvincia { get; }
        string NombreLocalidad { get; }
    }
}
