using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public enum TipoTorneo : int { Single = 0, Doble = 1};
    public enum EstadoTorneo : int { Abierto, Cerrado, Jugando, Finalizado, NoIniciado, Cancelado }
    public class Torneo
    {
        public Torneo(int IdTorneo,string Nombre,DateTime FechaInicio, DateTime FechaFin,DateTime FechaInicioInscripciones, DateTime FechaFinInscripciones,
            int Cupo, string Sexo,TipoTorneo Tipo,Club Club,Categoria Categoria,bool TipoInscripcion,TipoSuperficie Superficie,int Estado)
        {
            this.idtorneo=IdTorneo;
            this.Nombre= Nombre;
            this.fecfin=FechaFin;
            this.fecinicio= FechaInicio;
            this.fecinicioinsc = FechaInicioInscripciones;
            this.fecfininsc = FechaFinInscripciones;
            this.cupo=Cupo;
            this.sexo =Sexo;
            this.tipo=Tipo;
            this.club = Club;
            this.categoria = Categoria;
            this.tipoinscripcion =TipoInscripcion;
            this.superficie=Superficie;
            this.estado = Estado;
        }

        
        public Torneo(string Nombre,DateTime FechaInicio, DateTime FechaFin,DateTime FechaInicioInscripciones, DateTime FechaFinInscripciones,
            int Cupo, string Sexo,TipoTorneo Tipo,Club Club,Categoria Categoria,bool TipoInscripcion,TipoSuperficie Superficie,int Estado)
        {
            
            this.Nombre= Nombre;
            this.fecfin=FechaFin;
            this.fecinicio = FechaInicio;
            this.fecinicioinsc = FechaInicioInscripciones;
            this.fecfininsc = FechaFinInscripciones;
            this.cupo=Cupo;
            this.sexo =Sexo;
            this.tipo=Tipo;
            this.club = Club;
            this.categoria = Categoria;
            this.tipoinscripcion =TipoInscripcion;
            this.superficie=Superficie;
            this.estado = Estado;
        }

        
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
        int estado;
        List<Puntos> listapuntos;

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
            get { return fecinicioinsc; }
            set { fecinicioinsc = value; }
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
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public List<Puntos> ListaPuntos
        {
            get { return listapuntos; }
            set { listapuntos = value; }
        }
    }

}
