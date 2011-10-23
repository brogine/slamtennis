using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Servicio.InterfacesUI;
using Dominio;
using Repositorio;

namespace Servicio
{
    class PuntosServicio:IPuntosServicio
    {

        #region Miembros de IPuntosServicio

        public void Agregar(IPuntosUI UI)
        {
            int IdTorneo = UI.IdTorneo;
            List<Puntos> Lista = new List<Puntos>();
            IPuntosRepositorio PuntosRepo = new PuntosRepositorio();

            if(UI.PrimeraRonda > 0)
            {
            Puntos PrimRonda = new Puntos(IdTorneo,"R1",UI.PrimeraRonda);
                Lista.Add(PrimRonda);
            }

            if (UI.SegundaRonda > 0)
            {
            Puntos SegRonda = new Puntos(IdTorneo,"R2",UI.SegundaRonda);
                Lista.Add(SegRonda);
            }

            if (UI.Campeon > 0)
            {
                Puntos TerRonda = new Puntos(IdTorneo, "Campeon", UI.Campeon);
                Lista.Add(TerRonda);
            }

            if (UI.CuartosFinal > 0)
            {
                Puntos Cuartos = new Puntos(IdTorneo, "CF", UI.CuartosFinal);
                Lista.Add(Cuartos);
            }

            if (UI.SemiFinal > 0)
            {
                Puntos Semi = new Puntos(IdTorneo, "SF", UI.SemiFinal);
                Lista.Add(Semi);
            }

            if (UI.Final > 0)
            {
                Puntos Final = new Puntos(IdTorneo, "F", UI.Final);
                Lista.Add(Final);
            }
            PuntosRepo.Agregar(Lista);
        }

        public void Modificar(IPuntosUI UI)
        {
            IPuntosRepositorio PuntosRepo = new PuntosRepositorio();
            List<Puntos> Lista = PuntosRepo.ListarPuntos(UI.IdTorneo);
            foreach (Puntos P in Lista)
            {
                if (P.Ronda == "R1")
                {
                    P.CantidadPuntos = UI.PrimeraRonda;
                }
                if (P.Ronda == "R2")
                {
                    P.CantidadPuntos = UI.SegundaRonda;
                }
                if (P.Ronda == "Campeon")
                {
                    P.CantidadPuntos = UI.Campeon;
                }
                if (P.Ronda == "CF")
                {
                    P.CantidadPuntos = UI.CuartosFinal;
                }
                if (P.Ronda == "SF")
                {
                    P.CantidadPuntos = UI.SemiFinal;
                }
                if (P.Ronda == "F")
                {
                    P.CantidadPuntos = UI.Final;
                }
                PuntosRepo.Modificar(Lista);
            }
        }

        public void Buscar(IPuntosUI UI)
        {
            IPuntosRepositorio PuntosRepo = new PuntosRepositorio();
            List<Puntos> Lista = PuntosRepo.ListarPuntos(UI.IdTorneo);
            ITorneoRepositorio TorneoRepo = new TorneoRepositorio();
            Torneo Torneo = TorneoRepo.Buscar(UI.IdTorneo);
            UI.Cupo = Torneo.Cupo;
            if (Lista.Count > 0)
            {
                foreach (Puntos P in Lista)
                {
                    if (P.Ronda == "R1")
                    {
                        UI.PrimeraRonda = P.CantidadPuntos;
                    }

                    if (P.Ronda == "R2")
                    {
                        UI.SegundaRonda = P.CantidadPuntos;
                    }
                    if (P.Ronda == "Campeon")
                    {
                        UI.Campeon = P.CantidadPuntos;
                    }
                    if (P.Ronda == "CF")
                    {
                        UI.CuartosFinal = P.CantidadPuntos;
                    }

                    if (P.Ronda == "SF")
                    {
                        UI.SemiFinal = P.CantidadPuntos;
                    }
 
                    if (P.Ronda == "F")
                    {
                        UI.Final = P.CantidadPuntos;
                    }


                }
            }
        }

        #endregion

        #region Miembros de IPuntosServicio


        public bool Existe(IPuntosUI UI)
        {
            IPuntosRepositorio PuntosRepo = new PuntosRepositorio();
            List<Puntos> Lista = PuntosRepo.ListarPuntos(UI.IdTorneo);
            if (Lista.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
