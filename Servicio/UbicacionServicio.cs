using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Repositorio;
using Dominio;

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

        public void AgregarPais(Servicio.InterfacesUI.IUbicacionUI ui)
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

        public void AgregarProvincia(Servicio.InterfacesUI.IUbicacionUI ui)
        {
            Provincia ProvinciaNueva = new Provincia(ui.NombreProvincia, ui.IdPais);
            UbicaRepo.AgregarProvincia(ProvinciaNueva);
        }

        public void ListarProvincias(IListadoProvincias ui)
        {
            Dictionary<int, string> ListaProvincias = new Dictionary<int, string>();
            List<Provincia> Lista = UbicaRepo.ListarProvincias(new Pais(ui.Pais));
            foreach (Provincia Prov in Lista)
            {
                ListaProvincias.Add(Prov.IdProvincia, Prov.Nombre);
            }
            ui.ListarProvincias = ListaProvincias;
        }

        #endregion

        #region Miembros de ILocalidadServicio

        public void AgregarLocalidad(Servicio.InterfacesUI.IUbicacionUI ui)
        {
            Localidad LocalidadNueva = new Localidad (
        }

        public void ListarLocalidades(IListadoLocalidades ui)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
