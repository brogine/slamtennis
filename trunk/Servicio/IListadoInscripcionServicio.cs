using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;

namespace Servicio
{
    public interface IListadoInscripcionServicio
    {
        void ListarPorTorneo(IListadoInscripciones UI);
        void ListarActivas(IListadoInscripciones UI);
        void ListarPorPartido(IListadoInscripciones UI);
    }
}
