using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;

namespace Servicio
{
    public class JugadorServicio : IJugadorServicio, IListadoJugadores
    {
        #region Miembros de IJugadorServicio

        public void Agregar(Servicio.InterfacesUI.IJugadorUI UI)
        {
            Jugador nJugador;
            Contacto nContacto;
            Ubicacion nUbicacion;

            nContacto = new Contacto(UI.Telefono, UI.Celular, UI.Email);
            //nUbicacion = new Ubicacion(UI.Localidad, UI.Domicilio);

            if (UI.DniTutor != null && UI.RelacionTutor != "")
            {
                //nJugador = new Jugador(UI.Dni, UI.Nombre, UI.Apellido, UI.FechaNac,
                //    UI.Nacionalidad, UI.Sexo, UI.DniTutor, UI.RelacionTutor, 
                //    nContacto, nUbicacion);
                //if (nJugador.Edad >= 18)
                //    throw new ServicioExeption("El jugador es mayor de edad.");
                //Llamar al repo
            }
            else
            {
                //nJugador = new Jugador(UI.Dni, UI.Nombre, UI.Apellido, UI.FechaNac,
                //    UI.Nacionalidad, UI.Sexo, nContacto, nUbicacion);
                //Llamar al repo
            }
        }

        public void Modificar(Servicio.InterfacesUI.IJugadorUI UI)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Miembros de IListadoJugadores

        public List<string> Listar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
