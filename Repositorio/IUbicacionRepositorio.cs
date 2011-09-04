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
        Pais ObtenerPais(int IdPais); 

        List<Provincia> ListarProvincias(Pais Pais);
        void AgregarProvincia(Provincia Provincia);
        Provincia ObetenerProvincia(int IdProvincia);

        List<Localidad> ListarLocalidades(Provincia Provincia);
        void AgregarLocalidad(Localidad Localidad);
        Localidad ObtenerLocalidad(int IdLocalidad);

        
    }
}
