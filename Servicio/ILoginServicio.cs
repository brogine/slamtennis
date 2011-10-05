using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface ILoginServicio
    {
        void Agregar(ILoginUI ui);

        void Modificar(ILoginUI ui);

        void OlvidoPassword(string usuario);

        int Validar(ILoginUI ui);
    }
}
