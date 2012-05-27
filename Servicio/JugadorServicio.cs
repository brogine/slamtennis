using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dominio;
using Repositorio;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using Servicio.InterfacesUI;

namespace Servicio
{
    public class JugadorServicio : IJugadorServicio, IListadoJugadoresServicio, IListadoJugadoresCategoriaServicio
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

            Login nLogin = new Login(UI.Usuario, UI.Password, UI.Dni, UI.Estado);

            Bitmap newImage = null;
            if (UI.Foto != null)
            {
                newImage = new Bitmap(100, 100);
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(UI.Foto, new Rectangle(0, 0, 320, 240));
                }
            }

            if (UI.Tutor != "" && UI.RelacionTutor != "")
            {
                nJugador = new Jugador(UI.Dni, UI.Nombre, UI.Apellido, UI.FechaNac,
            	    Nacionalidad, UI.Sexo, UI.Tutor, UI.RelacionTutor,
                    nContacto, nUbicacion, UI.Estado, nLogin, newImage);
                if (nJugador.Edad >= 18)
                    throw new ServicioException("Error al agregar: El jugador es mayor de edad.");
            }
            else
            {
                nJugador = new Jugador(UI.Dni, UI.Nombre, UI.Apellido, UI.FechaNac,
                    Nacionalidad, UI.Sexo, nContacto, nUbicacion, UI.Estado, nLogin, newImage);
            }

            repoJugadores.Agregar(nJugador);
        }

        public bool Existe(int Dni)
        {
            return repoJugadores.Existe(Dni);
        }

        public bool ExisteCategoria(IJugadorUI UI)
        {
            ICategoriaRepositorio repoCategorias = new CategoriaRepositorio();
            Jugador nJugador = new Jugador();
            nJugador.FechaNac = UI.FechaNac;
            Categoria bCategoria = repoCategorias.ObtenerPorEdad(nJugador.Edad);
            if (bCategoria == null)
                return false;
            else
                return true;
        }

        public void Modificar(Servicio.InterfacesUI.IJugadorUI UI)
        {
        	Jugador bJugador = repoJugadores.Buscar(UI.Dni);
			bJugador.Apellido = UI.Apellido;
			bJugador.Contacto = new Contacto(UI.Telefono, UI.Celular, UI.Email);
			bJugador.Tutor = UI.Tutor;
			bJugador.Estado = UI.Estado;
			bJugador.FechaNac = UI.FechaNac;

            Bitmap newImage = null;
            if (UI.Foto != null)
            {
                newImage = new Bitmap(100, 100);
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(UI.Foto, new Rectangle(0, 0, 100, 100));
                }
                bJugador.Foto = bJugador.ImagenABytes(newImage);
            }

			bJugador.Login = new Login(UI.Usuario, UI.Password, UI.Dni, UI.Estado);
			IUbicacionRepositorio repoUbicacion = new UbicacionRepositorio();
			bJugador.Nacionalidad = repoUbicacion.ObtenerPais(UI.Nacionalidad);
			bJugador.Nombre = UI.Nombre;
			bJugador.RelacionTutor = UI.RelacionTutor;
			bJugador.Sexo = UI.Sexo;
			bJugador.Ubicacion = new Ubicacion(repoUbicacion.ObtenerLocalidad(UI.Localidad), UI.Domicilio);
			repoJugadores.Modificar(bJugador);

            ICategoriaRepositorio repoCategorias = new CategoriaRepositorio();
            Categoria bCategoria = repoCategorias.ObtenerPorEdad(bJugador.Edad);
            IEstadisticaRepositorio repoEstadisticas = new EstadisticaRepositorio();
            Estadisticas bEstadisticas = repoEstadisticas.Buscar(bJugador.Dni, bCategoria.Id);
            if (bEstadisticas == null)
            {
                bEstadisticas = new Estadisticas(bCategoria, 0,0,0,0,0,0, true);
                repoEstadisticas.Agregar(bJugador, bEstadisticas);
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        
        public void Buscar(Servicio.InterfacesUI.IJugadorUI UI)
		{
            if (this.Existe(UI.Dni))
            {
                Jugador bJugador = repoJugadores.Buscar(UI.Dni);
                UI.Dni = bJugador.Dni;
                UI.Apellido = bJugador.Apellido;
                UI.Estado = bJugador.Estado;
                UI.FechaNac = bJugador.FechaNac;
                UI.Edad = bJugador.Edad;
                UI.Nacionalidad = bJugador.Nacionalidad.IdPais;
                UI.Nombre = bJugador.Nombre;
                UI.Sexo = bJugador.Sexo;
                UI.Estado = bJugador.Estado;
                //Datos de Jugador Menor
                UI.Tutor = bJugador.Tutor;
                UI.RelacionTutor = bJugador.RelacionTutor;

                //Value Object Login
                UI.Usuario = bJugador.Login.Usuario;
                UI.Password = bJugador.Login.Password;

                //Value Object Ubicacion
                UI.Pais = bJugador.Ubicacion.Localidad.Provincia.Pais.IdPais;
                UI.Provincia = bJugador.Ubicacion.Localidad.Provincia.IdProvincia;
                UI.Localidad = bJugador.Ubicacion.Localidad.IdLocalidad;
                UI.Domicilio = bJugador.Ubicacion.Domicilio;

                //Value Object Contacto
                UI.Telefono = bJugador.Contacto.Telefono;
                UI.Celular = bJugador.Contacto.Celular;
                UI.Email = bJugador.Contacto.Email;
                if(bJugador.Foto != null)
                    UI.Foto = bJugador.BytesAImagen(bJugador.Foto);
            }
            else
                throw new ServicioException("El Jugador con Dni " + UI.Dni + " No existe");
		}

        public int PerteneceACategoria(int dni)
        {
            int retorno = 0;
            if (this.Existe(dni))
            {
                Categoria catjugador = repoJugadores.BuscarCategoria(dni);
                if (catjugador == null)
                {
                    throw new ServicioException("El Jugador no tiene asociada ninguna categoria.");
                }
                else
                {
                    retorno = catjugador.Id;
                }
            }
            else
            {
                throw new ServicioException("El Jugador con Dni " + dni + " No existe");
            }
            return retorno;
        }

        #endregion

        #region Miembros de IListadoJugadoresServicio

        public void Listar(IListadoJugadores UI)
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
                ListaUI.Add(Objeto);
            }
            UI.Listar = ListaUI;
        }

        #endregion

        #region Miembros de IListadoJugadoresCategoriaServicio

        public void ListarPorCategoria(Servicio.InterfacesUI.IListadoJugadoresCategoria UI)
        {
            List<Jugador> ListaJugadores = repoJugadores.ListarPorCategoria(UI.IdCategoria);
            DataTable TablaUI = new DataTable("Datos");
            TablaUI.Columns.Add("Dni");
            TablaUI.Columns.Add("NombreApellido");
            TablaUI.Columns.Add("PJ");
            TablaUI.Columns.Add("PG");
            TablaUI.Columns.Add("PP");
            TablaUI.Columns.Add("TJ");
            TablaUI.Columns.Add("TC");
            TablaUI.Columns.Add("Puntos");
            TablaUI.Columns.Add("Posicion");
            TablaUI.Columns.Add("Tipo");
            int i = 1;
            foreach (Jugador Jugador in ListaJugadores)
            {
                TablaUI.Rows.Add(Jugador.Dni, Jugador.Apellido + " " + Jugador.Nombre, Jugador.Estadisticas[0].PJ,
                    Jugador.Estadisticas[0].PG, Jugador.Estadisticas[0].PP, Jugador.Estadisticas[0].TorneosJugados,
                    Jugador.Estadisticas[0].TorneosCompletados, Jugador.Estadisticas[0].Puntaje, i, "Single");
                TablaUI.Rows.Add(Jugador.Dni, Jugador.Apellido + " " + Jugador.Nombre, Jugador.Estadisticas[0].PartidosJugadosDoble,
                    Jugador.Estadisticas[0].PartidosGanadosDoble, Jugador.Estadisticas[0].PartidosPerdidosDoble,
                    Jugador.Estadisticas[0].TorneosJugadosDoble, Jugador.Estadisticas[0].TorneosCompletadosDoble,
                    Jugador.Estadisticas[0].PuntajeDoble, i, "Dobles");
                i++;
            }
            UI.Listar = TablaUI;
        }

        #endregion
    }
}
