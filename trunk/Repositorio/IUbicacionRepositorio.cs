using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Repositorio
{
   public interface IUbicacionRepositorio
    {
        List<Pais> ListarPaises();
        void AgregarPais(Pais Pais);

        List<Provincia> ListarProvincias(Pais Pais);
        void AgregarProvincia(Provincia Provincia);

        List<Localidad> ListarLocalidades(Provincia Provincia);
        void AgregarLocalidad(Localidad Localidad);

        int BuscarIdPais(string Nombre);
        int BuscarIdProvincia(string Nombre, int IdPais);
        int BuscarIdLocalidad(string Nombre, int IdProvincia);

    }
}
