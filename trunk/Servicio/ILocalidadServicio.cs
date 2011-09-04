using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface ILocalidadServicio
    {
        void AgregarLocalidad(IUbicacionUI ui, IListadoLocalidades uiLoc);

        void ListarLocalidades(IListadoLocalidades ui);

        string ObtenerUbicacion(int IdLocalidad);
    }
}
