using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio;

namespace Servicio
{
    class AfiliacionServicio:IAfiliacionServicio,IListadoAfiliacionServicio
    {

        #region Miembros de IAfiliacionServicio

        public void Agregar(Servicio.InterfacesUI.IAfiliacionUI UI)
        {
            IAfiliacionRepositorio AfilRepo = new AfiliacionRepositorio();
            IJugadorRepositorio JugaRepo = new JugadorRepositorio();
            IClubRepositorio ClubRepo = new ClubRepositorio();

            Club ClubAfil = ClubRepo.Buscar(UI.IdClub);
            Jugador JugaAfil = JugaRepo.Buscar(UI.Dni);
            Afiliacion NuevaAfil = new Afiliacion(ClubAfil, JugaAfil, DateTime.Today, UI.Estado);
          
            
        }

        public void Modificar(Servicio.InterfacesUI.IAfiliacionUI UI)
        {
            IAfiliacionRepositorio AfilRepo = new AfiliacionRepositorio();
            Afiliacion ModAfil = AfilRepo.Buscar(UI.Dni, UI.IdClub);
            ModAfil.Estado = UI.Estado;
            ModAfil.FechaBaja = UI.FechaBaja;
            AfilRepo.Modificar(ModAfil);
        }

        public void Buscar(Servicio.InterfacesUI.IAfiliacionUI UI)
        {
            IAfiliacionRepositorio AfilRepo = new AfiliacionRepositorio();
            Afiliacion Afil = AfilRepo.Buscar(UI.Dni, UI.IdClub);
            UI.NombreClub = Afil.Club.Nombre;
            UI.NombreJugador = Afil.Jugador.Apellido + " " + Afil.Jugador.Apellido;
            UI.Estado = Afil.Estado;
            UI.FechaAlta = Afil.FechaAlta;
            UI.FechaBaja = Afil.FechaBaja;
        }

        #endregion



        #region Miembros de IListadoAfiliacionServicio

        public void Listar(Servicio.InterfacesUI.IlistadoAfiliaciones UI)
        {
            IAfiliacionRepositorio AfilRepo = new AfiliacionRepositorio();
            IClubRepositorio ClubRepo = new ClubRepositorio();

            List<Afiliacion> ListaAfili = AfilRepo.Listar(ClubRepo.Buscar(UI.IdClub));
            List<Object> ListaObjeto = new List<object>();

            foreach (Afiliacion Afiliacion in ListaAfili)
            {
                object Objeto = new object();
                Objeto = Afiliacion.Jugador.Dni + " , ";
                Objeto += Afiliacion.Jugador.Apellido + " " + Afiliacion.Jugador.Nombre+" , ";
                Objeto += Afiliacion.FechaAlta.ToShortDateString();
                
            }
            UI.ListaAfiliaciones = ListaObjeto;
            
        }

        #endregion
    }
}
