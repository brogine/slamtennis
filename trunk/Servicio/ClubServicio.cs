using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio;
using Dominio;

namespace Servicio
{
    public class ClubServicio : IClubServicio, IListadoClubServicio
    {
        IClubRepositorio ClubRepo;
        public ClubServicio()
        {
            ClubRepo = new ClubRepositorio();
        }

        #region Miembros de IClubServicio

        public void Agregar(Servicio.InterfacesUI.IClubUI UI)
        {
            try
            {
                Club nClub = new Club(UI.NombreClub, UI.Estado);
                ClubRepo.Agregar(nClub);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Modificar(Servicio.InterfacesUI.IClubUI UI)
        {
            throw new NotImplementedException();
        }

        public void Buscar(Servicio.InterfacesUI.IClubUI UI)
        {
            Club bClub = ClubRepo.Buscar(UI.IdClub);
            UI.Estado = bClub.Estado;
            UI.NombreClub = bClub.Nombre;
            if (bClub.Presidente != null)
            {
                UI.DniPresidente = bClub.Presidente.Dni;
                UI.NombrePresidente = bClub.Presidente.Apellido + " " + bClub.Presidente.Nombre;
            }
        }

        #endregion

        #region Miembros de IListadoClubServicio

        public void Listar(Servicio.InterfacesUI.IListadoClubes UI)
        {
            List<Club> ListaClubes = ClubRepo.Listar();
            List<Object> Lista = new List<object>();
            foreach (Club Club in ListaClubes)
            {
                object presidente = string.Empty;
                if(Club.Presidente == null)
                    presidente = "No está asignado";
                else
                    presidente = Club.Presidente.Apellido + " " + Club.Presidente.Nombre;
                Lista.Add(Club.Id + "," + Club.Nombre + "," + presidente + "," + Club.Estado);
            }
            UI.ListarClubes = Lista;
        }

        #endregion
    }
}
