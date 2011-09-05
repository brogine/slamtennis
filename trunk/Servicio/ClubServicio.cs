﻿using System;
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
            try {
            	Club nClub;
            	if(UI.DniPresidente > 0)
            	{
            		IEmpleadoRepositorio repoEmpleados = new EmpleadoRepositorio();
            		nClub = new Club(repoEmpleados.Buscar(UI.DniPresidente), 
            		                 UI.NombreClub, UI.Estado);
            	}
            	else
                	nClub = new Club(UI.NombreClub, UI.Estado);
                ClubRepo.Agregar(nClub);
            }
            catch (Exception ex) {
                throw new ServicioExeption(ex.Message, ex);
            }
        }

        public void Modificar(Servicio.InterfacesUI.IClubUI UI)
        {
            try {
        		Club mClub = ClubRepo.Buscar(UI.IdClub);
        		mClub.Estado = UI.Estado;
        		mClub.Nombre = UI.NombreClub;
        		IEmpleadoRepositorio repoEmpleados = new EmpleadoRepositorio();
        		mClub.Presidente = repoEmpleados.Buscar(UI.DniPresidente);
        		ClubRepo.Modificar(mClub);
            } catch (Exception ex) {
            	throw new ServicioExeption(ex.Message, ex);
            }
        }

        public void Buscar(Servicio.InterfacesUI.IClubUI UI)
        {
        	try {
        		 Club bClub = ClubRepo.Buscar(UI.IdClub);
	            UI.Estado = bClub.Estado;
	            UI.NombreClub = bClub.Nombre;
	            if (bClub.Presidente != null)
	            {
	                UI.DniPresidente = bClub.Presidente.Dni;
	                UI.NombrePresidente = bClub.Presidente.Apellido + " " + bClub.Presidente.Nombre;
	            }
        	} catch (Exception ex) {
            	throw new ServicioExeption(ex.Message, ex);
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
