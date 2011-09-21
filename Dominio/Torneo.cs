using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    enum TipoTorneo {Single,Doble};
    public class Torneo
    {
        
        int idtorneo;
        string nombre;
        DateTime fecinicio;
        DateTime fecfin;
        DateTime fecinicioinsc;
        DateTime fecfininsc;
        int cupo;
        string sexo;
        TipoTorneo tipo;
        Club club;
        Categoria categoria;
        bool tipoinscripcion;
        TipoSuperficie superficie;
        bool estado;

        public int IdTorneo
        {
            get { return idtorneo; }
            set { idtorneo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public DateTime FechaInicio
        {
            get { return fecinicio; }
            set { fecinicio = value; }
        }
        public DateTime FechaFin
        {
            get { return fecfin; }
            set { fecfin = value; }
        }
        public DateTime FechaInicioInscripcion
        {
            get { return fecfininsc; }
            set { fecfininsc = value; }
        }
        public DateTime FechaFinInscripcion
        {
            get { return fecfininsc; }
            set { fecfininsc = value; }
        }
        public int Cupo
        {
            get { return cupo; }
            set { cupo = value; }
        }
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public TipoTorneo TipoTorneo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public Club Club
        {
            get { return club; }
            set { club = value; }
        }
        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }
        public bool TipoInscripcion
        {
            get { return tipoinscripcion; }
            set { tipoinscripcion = value; }
        }
        public TipoSuperficie Superficie
        {
            get { return superficie; }
            set { superficie = value; }
        }
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }

}
