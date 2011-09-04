using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Repositorio;
using Dominio;
using Servicio.InterfacesUI;

namespace Servicio
{
    public class UbicacionServicio : IPaisServicio, IProvinciaServicio, ILocalidadServicio
    {
        IUbicacionRepositorio UbicaRepo;
        public UbicacionServicio()
        {
            UbicaRepo = new UbicacionRepositorio();
        }

        #region Miembros de IPaisServicio

        public void AgregarPais(IUbicacionUI ui)
        {
            Pais PaisNuevo = new Pais(ui.NombrePais);
            UbicaRepo.AgregarPais(PaisNuevo);
        }

        public void ListarPaises(IListadoPaises ui)
        {
            Dictionary<int,string> ListaPaises = new Dictionary<int,string>();
            List<Pais> Lista = UbicaRepo.ListarPaises();
            foreach (Pais Pais in Lista)
            {
                ListaPaises.Add(Pais.IdPais, Pais.Nombre);
            }
            ui.ListarPaises = ListaPaises;
        }

        #endregion

        #region Miembros de IProvinciaServicio

        public void AgregarProvincia(IUbicacionUI ui, IListadoProvincias uiPro)
        {
            Provincia ProvinciaNueva = new Provincia(ui.NombreProvincia, UbicaRepo.ObtenerPais(uiPro.Pais));
            UbicaRepo.AgregarProvincia(ProvinciaNueva);
        }

        public void ListarProvincias(IListadoProvincias ui)
        {
            Dictionary<int, string> ListaProvincias = new Dictionary<int, string>();
            List<Provincia> Lista = UbicaRepo.ListarProvincias(UbicaRepo.ObtenerPais(ui.Pais));
            foreach (Provincia Prov in Lista)
            {
                ListaProvincias.Add(Prov.IdProvincia, Prov.Nombre);
            }
            ui.ListarProvincias = ListaProvincias;
        }

        #endregion

        #region Miembros de ILocalidadServicio

        public void AgregarLocalidad(IUbicacionUI ui, IListadoLocalidades uiLoc)
        {
            Provincia bProvincia = UbicaRepo.ObetenerProvincia(uiLoc.Provincia);
            Localidad LocalidadNueva = new Localidad(bProvincia, ui.NombreLocalidad);
            UbicaRepo.AgregarLocalidad(LocalidadNueva);
        }

        public void ListarLocalidades(IListadoLocalidades ui)
        {
            Dictionary<int, string> ListaLocalidades = new Dictionary<int, string>();
            List<Localidad> Lista = UbicaRepo.ListarLocalidades(UbicaRepo.ObetenerProvincia(ui.Provincia));
            foreach (Localidad Loc in Lista)
            {
                ListaLocalidades.Add(Loc.IdLocalidad, Loc.Nombre);
            }
            ui.ListarLocalidades = ListaLocalidades;
        }

        #endregion
    }
}
