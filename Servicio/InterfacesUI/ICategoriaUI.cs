using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Servicio.InterfacesUI
{
  public interface ICategoriaUI
    {
        int IdCategoria { get; set; }
        string Nombre { get; set; }
        int EdadMinima { get; set; }
        int EdadMaxima { get; set; }
        bool Estado { get; set; }
    }
}
