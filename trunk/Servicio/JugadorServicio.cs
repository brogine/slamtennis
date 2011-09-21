using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dominio;
using Repositorio;

namespace Servicio
{
    public class JugadorServicio : IJugadorServicio, IListadoJugadoresServicio
    {
    	IJugadorRepositorio repoJugadores;
    	public JugadorServicio()
    	{
    		repoJugadores = new JugadorRepositorio();
    	}
    	
        #region Miembros de IJugadorServicio

        public void Agregar(Servicio.InterfacesUI.IJugadorUI UI)
        {
           
            Jugador nJugador;
            Contacto nContacto;
            Ubicacion nUbicacion;
            
            nContacto = new Contacto(UI.Telefono, UI.Celular, UI.Email);
            IUbicacionRepositorio repoUbicacion = new UbicacionRepositorio();
            nUbicacion = new Ubicacion(repoUbicacion.ObtenerLocalidad(UI.Localidad), UI.Domicilio);
            Pais Nacionalidad = repoUbicacion.ObtenerPais(UI.Nacionalidad);

            Login nLogin = new Login(UI.Usuario, UI.Password, UI.Estado);

            if (UI.Tutor != "" && UI.RelacionTutor != "")
            {
                nJugador = new Jugador(UI.Dni, UI.Nombre, UI.Apellido, UI.FechaNac,
            	    Nacionalidad, UI.Sexo, UI.Tutor, UI.RelacionTutor,
                    nContacto, nUbicacion, UI.Estado, nLogin);
                if (nJugador.Edad >= 18)
                    throw new ServicioExeption("Error al agregar: El jugador es mayor de edad.");
            }
            else
            {
                nJugador = new Jugador(UI.Dni, UI.Nombre, UI.Apellido, UI.FechaNac,
                    Nacionalidad, UI.Sexo, nContacto, nUbicacion, UI.Estado, nLogin);
            }

            nJugador.Foto = nJugador.CopiarFoto(UI.Foto, UI.Dni);
            repoJugadores.Agregar(nJugador);
        }

        public bool Existe(int Dni)
        {
            return repoJugadores.Existe(Dni);
        }

        public void Modificar(Servicio.InterfacesUI.IJugadorUI UI)
        {
        	Jugador bJugador = repoJugadores.Buscar(UI.Dni);
			bJugador.Apellido = UI.Apellido;
			bJugador.Contacto = new Contacto(UI.Telefono, UI.Celular, UI.Email);
			bJugador.Tutor = UI.Tutor;
			bJugador.Estado = UI.Estado;
			bJugador.FechaNac = UI.FechaNac;
			bJugador.Login = new Login(UI.Usuario, UI.Password, UI.Estado);
			IUbicacionRepositorio repoUbicacion = new UbicacionRepositorio();
			bJugador.Nacionalidad = repoUbicacion.ObtenerPais(UI.Nacionalidad);
			bJugador.Nombre = UI.Nombre;
			bJugador.RelacionTutor = UI.RelacionTutor;
			bJugador.Sexo = UI.Sexo;
            bJugador.Foto = bJugador.CopiarFoto(UI.Foto, UI.Dni);
			bJugador.Ubicacion = new Ubicacion(repoUbicacion.ObtenerLocalidad(UI.Localidad), UI.Domicilio);
			repoJugadores.Modificar(bJugador);
            GC.Collect();
        }
        
        public void Buscar(Servicio.InterfacesUI.IJugadorUI UI)
		{
            if (this.Existe(UI.Dni))
            {
                Jugador bJugador = repoJugadores.Buscar(UI.Dni);
                UI.Dni = bJugador.Dni;
                UI.Apellido = bJugador.Apellido;
                UI.Celular = bJugador.Contacto.Celular;
                UI.Tutor = bJugador.Tutor;
                UI.Domicilio = bJugador.Ubicacion.Domicilio;
                UI.Email = bJugador.Contacto.Email;
                UI.Estado = bJugador.Estado;
                UI.FechaNac = bJugador.FechaNac;
                UI.Edad = bJugador.Edad;
                UI.Localidad = bJugador.Ubicacion.Localidad.IdLocalidad;
                UI.Nacionalidad = bJugador.Nacionalidad.IdPais;
                UI.Nombre = bJugador.Nombre;
                UI.Password = bJugador.Login.Password;
                UI.Provincia = bJugador.Ubicacion.Localidad.Provincia.IdProvincia;
                UI.RelacionTutor = bJugador.RelacionTutor;
                UI.Sexo = bJugador.Sexo;
                UI.Telefono = bJugador.Contacto.Telefono;
                UI.Usuario = bJugador.Login.Usuario;
                UI.Foto = bJugador.Foto;
            }
            else
                throw new ServicioExeption("El Jugador con Dni " + UI.Dni + " No existe");
		}

        #endregion

        #region Miembros de IListadoJugadoresServicio

        public void ListarJugadores(IListadoJugadores UI)
        {
            List<Jugador> ListaJuga= repoJugadores.Listar(UI.IdClub);
            List<object> ListaUI = new List<object>();
            IUbicacionRepositorio UbicaRepo = new UbicacionRepositorio();
            foreach (Jugador Jugador in ListaJuga)
            {
                object Objeto = new object();
                Objeto = Jugador.Dni + ",";
                Objeto += Jugador.Apellido + " " + Jugador.Nombre + ",";
                Objeto += Jugador.FechaNac.ToShortDateString() + ",";
                Objeto += Jugador.Nacionalidad.Nombre + ",";
                Objeto += Jugador.Sexo+",";
                Objeto += Jugador.Foto;
                ListaUI.Add(Objeto);
            }
            UI.Listar = ListaUI;
        }

        #endregion
        
    }
}
