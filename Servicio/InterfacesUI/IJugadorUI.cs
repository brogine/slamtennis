using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Servicio.InterfacesUI
{
    public interface IJugadorUI
    {
        int Dni { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        DateTime FechaNac { get; set; }
        List<String> DatosPorCategoria { get; } //Nombre de Categoria, pg, pp, pj, puntos
        string Nacionalidad { get; set; }
        string Sexo { get; set; }
        int DniTutor { get; set; }
        string RelacionTutor { get; set; }
        int Telefono { get; set; }
        int Celular { get; set; }
        string Email { get; set; }
        string Provincia { get; set; }
        string Localidad { get; set; }
        string Domicilio { get; set; }
    }
}
