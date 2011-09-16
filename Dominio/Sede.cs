using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Sede
    {
        public Sede(int id, Club club, Contacto contacto, Ubicacion ubicacion)
        {
            this.id = id; this.club = club; this.contacto = contacto;
            this.ubicacion = ubicacion;
        }

        public Sede(Club club, Contacto contacto, Ubicacion ubicacion)
        {
            this.club = club; this.contacto = contacto;
            this.ubicacion = ubicacion;
        }

        int id;
        Club club;
        Contacto contacto;
        Ubicacion ubicacion;
        List<Cancha> canchas;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Club Club
        {
            get { return club; }
            set { club = value; }
        }

        public Contacto Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        public Ubicacion Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public List<Cancha> Canchas
        {
            get { return canchas; }
            set { canchas = value; }
        }

    }
}
