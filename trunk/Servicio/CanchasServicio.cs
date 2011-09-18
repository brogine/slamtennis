using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio;

namespace Servicio
{
    public class CanchasServicio : ICanchasServicio, IListadoCanchasServicio
    {
        ICanchasRepositorio repoCanchas;
        public CanchasServicio()
        {
            repoCanchas = new CanchasRepositorio();
        }

        #region Miembros de ICanchasServicio

        public void Agregar(Servicio.InterfacesUI.ICanchasUI UI)
        {
            ISedesRepositorio repoSedes = new SedesRepositorio();
            Sede bSede = repoSedes.Buscar(UI.IdSede);
            Cancha nCancha = new Cancha(bSede, (TipoCancha)UI.TipoCancha, (TipoSuperficie)UI.Superficie, UI.Luz, UI.Cantidad);
            repoCanchas.Agregar(nCancha);
        }

        public void Modificar(Servicio.InterfacesUI.ICanchasUI UI)
        {
            Cancha bCancha = repoCanchas.Buscar(UI.IdCancha);
            bCancha.Cantidad = UI.Cantidad;
            bCancha.Luz = UI.Luz;
            bCancha.Superficie = (TipoSuperficie)UI.Superficie;
            bCancha.TipoCancha = (TipoCancha)UI.TipoCancha;
            repoCanchas.Modificar(bCancha);
        }

        public void Buscar(Servicio.InterfacesUI.ICanchasUI UI)
        {
            Cancha bCancha = repoCanchas.Buscar(UI.IdCancha);
            UI.IdSede = bCancha.Sede.Id;
            UI.Cantidad = bCancha.Cantidad;
            UI.Luz = bCancha.Luz;
            UI.Superficie = (int)bCancha.Superficie;
            UI.TipoCancha = (int)bCancha.TipoCancha;
        }

        #endregion

        #region Miembros de IListadoCanchasServicio

        public void Listar(Servicio.InterfacesUI.IListadoCanchas UI)
        {
            List<Cancha> ListaCanchas = repoCanchas.Listar(UI.IdSede);
            List<object> ListaUI = new List<object>();
            foreach (Cancha cancha in ListaCanchas)
            {
                ListaUI.Add(cancha.Id + "," + cancha.Superficie + "," + cancha.TipoCancha + "," + cancha.Luz + "," + cancha.Cantidad);
            }
            UI.ListaCanchas = ListaUI;
        }

        #endregion
    }
}
