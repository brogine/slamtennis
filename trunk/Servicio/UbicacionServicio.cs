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
            Dictionary<int,string> ListaUI = new Dictionary<int,string>();
            List<Pais> Lista = UbicaRepo.ListarPaises();
            foreach (Pais P in Lista)
            {
                ListaUI.Add(P.IdPais, P.Nombre);
            }
            ui.ListarPaises = ListaUI;
        }

        #endregion

        #region Miembros de IProvinciaServicio

        public void AgregarProvincia(Servicio.InterfacesUI.IUbicacionUI ui)
        {
            throw new NotImplementedException();
        }

        public void ListarProvincias(IListadoProvincias ui)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Miembros de ILocalidadServicio

        public void AgregarLocalidad(Servicio.InterfacesUI.IUbicacionUI ui)
        {
            throw new NotImplementedException();
        }

        public void ListarLocalidades(IListadoLocalidades ui)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
