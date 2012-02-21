using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositorio;
using Dominio;

namespace Servicio
{
    public class SedesServicio : ISedesServicio , IListadoSedesServicio
    {
        ISedesRepositorio repoSedes;
        public SedesServicio()
        {
            repoSedes = new SedesRepositorio();
        }

        #region Miembros de ISedesServicio

        public void Agregar(Servicio.InterfacesUI.ISedesUI UI)
        {
            IClubRepositorio repoClubes = new ClubRepositorio();
            Club bClub = repoClubes.Buscar(UI.IdClub);

            Contacto bContacto = new Contacto(UI.Telefono, UI.Celular, UI.Email);

            IUbicacionRepositorio repoUbicacion = new UbicacionRepositorio();
            Ubicacion bUbicacion = new Ubicacion(repoUbicacion.ObtenerLocalidad(UI.IdLocalidad),
                UI.Direccion);

            Sede nSede = new Sede(bClub, bContacto, bUbicacion);
            repoSedes.Agregar(nSede);
        }

        public void Modificar(Servicio.InterfacesUI.ISedesUI UI)
        {
            Sede bSede = repoSedes.Buscar(UI.IdSede);

            IClubRepositorio repoClubes = new ClubRepositorio();
            bSede.Club = repoClubes.Buscar(UI.IdClub);

            bSede.Contacto.Telefono = UI.Telefono;
            bSede.Contacto.Celular = UI.Celular;
            bSede.Contacto.Email = UI.Email;

            IUbicacionRepositorio repoUbicacion = new UbicacionRepositorio();
            bSede.Ubicacion.Localidad = repoUbicacion.ObtenerLocalidad(UI.IdLocalidad);
            bSede.Ubicacion.Domicilio = UI.Direccion;

            repoSedes.Modificar(bSede);
        }

        public void Buscar(Servicio.InterfacesUI.ISedesUI UI)
        {
            Sede bSede = repoSedes.Buscar(UI.IdSede);

            UI.IdClub = bSede.Club.Id;

            UI.Telefono = bSede.Contacto.Telefono;
            UI.Celular = bSede.Contacto.Celular;
            UI.Email = bSede.Contacto.Email;

            UI.IdLocalidad = bSede.Ubicacion.Localidad.IdLocalidad;
            UI.Direccion = bSede.Ubicacion.Domicilio;
        }

        #endregion

        #region Miembros de IListadoSedesServicio

        public void Listar(Servicio.InterfacesUI.IListadoSedes UI)
        {
            List<Sede> ListaSedes = repoSedes.Listar(UI.IdClub);
            List<Object> ListaUI = new List<object> ();

            foreach(Sede Sede in ListaSedes)
            {
                Object objeto = new object();
                if (UI.IdClub > 0)
                {
                    if (Sede.Club.Id == UI.IdClub)
                    {
                        objeto = Sede.Id + "," + Sede.Club.Nombre + ",";
                        objeto += Sede.Ubicacion.Domicilio;
                        ListaUI.Add(objeto);
                    }
                }
                else
                {
                    objeto = Sede.Id + "," + Sede.Club.Nombre + ",";
                    objeto += Sede.Ubicacion.Domicilio + "," + Sede.Club.Id;
                    ListaUI.Add(objeto);
                }
            }

            UI.ListarSedes = ListaUI;
        }

        #endregion
    }
}
