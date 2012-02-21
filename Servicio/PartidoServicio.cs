using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio;
using Servicio.InterfacesUI;

namespace Servicio
{
    public enum Rondas: int
    { 
        Primera_Ronda = 0, Segunda_Ronda = 1, Cuartos_Final = 2, Semi_Final = 3, Final = 4 
    }
   public class PartidoServicio:IPartidoServicio,IListadoPartidoServicio
    {
               IInscripcionRepositorio InscRepo;
            ITorneoRepositorio TornRepo;
            IPartidoRepositorio PartidoRepo;

            public PartidoServicio()
            {
                 InscRepo = new InscripcionRepositorio();
                 TornRepo = new TorneoRepositorio();
                 PartidoRepo = new PartidoRepositorio();
            }
        #region Miembros de IPartidoServicio

        public void Agregar(IPartidoUI UI)
        {
            bool Est = UI.Estado;
            Inscripcion Equipo1 = InscRepo.Buscar(UI.IdEquipo1);
            Inscripcion Equipo2 = InscRepo.Buscar(UI.IdEquipo2);
            Torneo Torneo = TornRepo.Buscar(UI.IdTorneo);
            if (UI.IdEquipo2 == 0)
            {
                Est = false;
            }
            Partido Partido = new Partido(Torneo, Equipo1, Equipo2, UI.Fecha, UI.Resultado, UI.Ronda, Est);
            PartidoRepo.Agregar(Partido);
        }

        public void Modificar(IPartidoUI UI)
        {
           Partido Partido = PartidoRepo.Buscar(UI.IdPartido);
           Partido.Resultado = UI.Resultado;
           Partido.Fecha = UI.Fecha;
           Partido.Estado = UI.Estado;
           Partido.Ronda = UI.Ronda;
           PartidoRepo.Modificar(Partido);
           
        }

        public void Buscar(IPartidoUI UI)
        {
            Partido Partido = PartidoRepo.Buscar(UI.IdPartido);
            UI.Estado = Partido.Estado;
            UI.IdTorneo = Partido.Torneo.IdTorneo;
            UI.IdEquipo1 = Partido.Equipo1.IdInscripcion;
            UI.IdEquipo2 = Partido.Equipo2.IdInscripcion;
            UI.Fecha = Partido.Fecha;
            UI.Resultado = Partido.Resultado;
            Rondas ronda = (Rondas)Enum.Parse(typeof(Rondas), Partido.Ronda);
            UI.Ronda = Convert.ToString((int)ronda);
        }

        public bool Existe(int IdPartido)
        {
            return PartidoRepo.Existe(IdPartido);
        }
        #endregion



        #region Miembros de IListadoPartidoServicio

        public void Listar(IListadoPartidos UI)
        {

            List<Partido> Lista = PartidoRepo.Listar(UI.IdTorneo);
            List<Object> ListaObjeto = new List<object>();

            foreach (Partido Partido in Lista)
            {
                object Objeto = new object();
                Objeto = Partido.IdPartido + ",";
                if (Partido.Equipo1.Equipo.Jugador2 != null)
                {
                    Objeto += Partido.Equipo1.Equipo.Jugador1.Apellido + " - " + Partido.Equipo1.Equipo.Jugador2.Apellido + ",";
                }
                else
                {
                    Objeto += Partido.Equipo1.Equipo.Jugador1.Apellido + ",";
                }
                if (Partido.Equipo2 != null)
                {
                    if (Partido.Equipo2.Equipo.Jugador2 != null)
                    {
                        Objeto += Partido.Equipo2.Equipo.Jugador1.Apellido + " - " + Partido.Equipo2.Equipo.Jugador2.Apellido + ",";
                    }
                    else
                    {
                        Objeto += Partido.Equipo2.Equipo.Jugador1.Apellido + ",";
                    }
                }
                else
                {
                    Objeto += "BYE,";

                }
                
                Objeto += Partido.Fecha.ToShortDateString() + ",";
                Objeto += Partido.Ronda +",";
                Objeto += Partido.Resultado+",";
                Objeto += Partido.Estado.ToString();
                ListaObjeto.Add(Objeto);
            }
            UI.ListarPartidos = ListaObjeto;
        }

        #endregion
    }
}
