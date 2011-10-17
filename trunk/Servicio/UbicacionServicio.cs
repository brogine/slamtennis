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
            
            List<Pais> ListaTorneo = UbicaRepo.ListarPaises();
            List<Object> Lista = new List<object>();
            foreach (Pais Pais in ListaTorneo)
            {
                Lista.Add(Pais.IdPais + "," + Pais.Nombre);
            }

            ui.ListarPaises = Lista;
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
            UbicaRepo.ObtenerPais(ui.Pais);
            List<Provincia> ListaProvincia = UbicaRepo.ListarProvincias(UbicaRepo.ObtenerPais(ui.Pais));
            List<Object> Lista = new List<object>();
            foreach (Provincia Prov in ListaProvincia)
            {
                Lista.Add(Prov.IdProvincia + "," + Prov.Nombre);
            }

            ui.ListarProvincias = Lista;
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

            List<Localidad> ListaLocalidades = UbicaRepo.ListarLocalidades(UbicaRepo.ObetenerProvincia(ui.Provincia));
            List<Object> Lista = new List<object>();
            foreach (Localidad Loc in ListaLocalidades)
            {
                Lista.Add(Loc.IdLocalidad + "," + Loc.Nombre);
            }

            ui.ListarLocalidades = Lista;
        }

        public string ObtenerUbicacion(int IdLocalidad)
        {
            Localidad bLocalidad = UbicaRepo.ObtenerLocalidad(IdLocalidad);
            return bLocalidad.Provincia.Pais.IdPais + "," + bLocalidad.Provincia.IdProvincia;

        }

        #endregion
    }
}
