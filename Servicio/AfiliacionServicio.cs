using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio;
using Servicio.InterfacesUI;

namespace Servicio
{
    public class AfiliacionServicio : IAfiliacionServicio, IListadoAfiliacionServicio
    {
        IAfiliacionRepositorio AfilRepo;

        public AfiliacionServicio()
        {
            AfilRepo = new AfiliacionRepositorio();
        }

        #region Miembros de IAfiliacionServicio

        public void Agregar(Servicio.InterfacesUI.IAfiliacionUI UI)
        {
            IJugadorRepositorio JugaRepo = new JugadorRepositorio();
            IClubRepositorio ClubRepo = new ClubRepositorio();

            Club ClubAfil = ClubRepo.Buscar(UI.IdClub);
            Jugador JugaAfil = JugaRepo.Buscar(UI.Dni);
            Afiliacion NuevaAfil = new Afiliacion(ClubAfil, JugaAfil, DateTime.Today, UI.Estado);
            AfilRepo.Agregar(NuevaAfil);
        }

        public void Modificar(Servicio.InterfacesUI.IAfiliacionUI UI)
        {
            Afiliacion ModAfil = AfilRepo.Buscar(UI.Dni, UI.IdClub);
            ModAfil.FechaBaja = DateTime.Today;
            ModAfil.Estado = UI.Estado;
            AfilRepo.Modificar(ModAfil);
        }

        public void Buscar(Servicio.InterfacesUI.IAfiliacionUI UI)
        {
            Afiliacion Afiliacion = AfilRepo.Buscar(UI.Dni, UI.IdClub);
            UI.Estado = Afiliacion.Estado;
        }

        public bool Existe(IAfiliacionUI UI)
        {
            return AfilRepo.Existe(UI.Dni, UI.IdClub);
        }

        #endregion

        #region Miembros de IListadoAfiliacionServicio

        public void Listar(Servicio.InterfacesUI.IlistadoAfiliaciones UI)
        {
            IClubRepositorio ClubRepo = new ClubRepositorio();

            List<Afiliacion> ListaAfili = AfilRepo.Listar(ClubRepo.Buscar(UI.IdClub));
            List<Object> ListaObjeto = new List<object>();

            foreach (Afiliacion Afiliacion in ListaAfili)
            {
                object Objeto = new object();
                Objeto = Afiliacion.Jugador.Dni + " , ";
                Objeto += Afiliacion.Jugador.Apellido + " " + Afiliacion.Jugador.Nombre+" , ";
                Objeto += Afiliacion.FechaAlta.ToShortDateString();
                ListaObjeto.Add(Objeto);
            }
            UI.ListaAfiliaciones = ListaObjeto;
            
        }

        #endregion
    }
}
