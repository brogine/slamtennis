using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Cancha
    {
        public Cancha() { }

        public Cancha(int Id, Sede sede, TipoCancha tipoDeCancha, TipoSuperficie superficie, bool luz, int cantidad)
        {
            this.id = Id; this.sede = sede; this.cantidad = cantidad;
            this.tipoCancha = tipoDeCancha; this.superficie = superficie; this.luz = luz;
        }

        public Cancha(Sede sede, TipoCancha tipoDeCancha, TipoSuperficie superficie, bool luz, int cantidad)
        {
            this.sede = sede; this.cantidad = cantidad;
            this.tipoCancha = tipoDeCancha; this.superficie = superficie; this.luz = luz;
        }

        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        Sede sede;
        public Sede Sede
        {
            get { return sede; }
            set { sede = value; }
        }

        TipoCancha tipoCancha;
        public TipoCancha TipoCancha
        {
            get { return tipoCancha; }
            set { tipoCancha = value; }
        }

        TipoSuperficie superficie;
        public TipoSuperficie Superficie
        {
            get { return superficie; }
            set { superficie = value; }
        }

        bool luz;
        public bool Luz
        {
            get { return luz; }
            set { luz = value; }
        }

        int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
    }

    public enum TipoCancha : int
    {
        Singles = 0, Dobles = 1
    }

    public enum TipoSuperficie : int
    {
        PolvoLadrillo = 0, CespedVerde = 1, Dura = 2, Sintetica = 3
    }
}
