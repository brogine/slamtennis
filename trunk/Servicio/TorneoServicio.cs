using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;
using Dominio;

namespace Servicio
{
    public class TorneoServicio:ITorneoServicio,IListadoTorneoServicio
    {
        #region Miembros de ITorneoServicio

        public void Agregar(ITorneoUI UI)
        {
            throw new NotImplementedException();
        }

        public void Modificar(ITorneoUI UI)
        {
            throw new NotImplementedException();
        }

        public void Buscar(int IdTorneo)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Miembros de IListadoTorneoServicio

        public void ListarTorneos(IListadoTorneos UI)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
