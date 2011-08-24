using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface IProvinciaServicio
    {
        void AgregarProvincia(IUbicacionUI ui, IListadoProvincias uiPro);

        void ListarProvincias(IListadoProvincias ui, IListadoProvincias uiPro);
    }
}
