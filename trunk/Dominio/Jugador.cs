using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Jugador : Persona
    {
        #region Constructores
        /// <summary>
        /// Constructor para un Jugador mayor de edad sin historial
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNac"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="sexo"></param>
        public Jugador(int dni, string nombre, string apellido, DateTime fechaNac, 
            string nacionalidad, string sexo, Contacto contacto, Ubicacion ubicacion)
        {

        }

        /// <summary>
        /// Constructor para un Jugador mayor con historial
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNac"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="sexo"></param>
        /// <param name="partidosGanados"></param>
        /// <param name="partidosPerdidos"></param>
        /// <param name="partidosJugados"></param>
        public Jugador(int dni, string nombre, string apellido, DateTime fechaNac,
            string nacionalidad, string sexo, int partidosGanados, int partidosPerdidos,
            int partidosJugados, Contacto contacto, Ubicacion ubicacion)
        {

        }

        /// <summary>
        /// Constructor para un Jugador menor de edad sin historial
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNac"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="sexo"></param>
        /// <param name="dniTutor"></param>
        /// <param name="relacionTutor"></param>
        public Jugador(int dni, string nombre, string apellido, DateTime fechaNac,
            string nacionalidad, string sexo, int dniTutor, string relacionTutor,
            Contacto contacto, Ubicacion ubicacion)
        {

        }

        /// <summary>
        /// Constructor para un Jugador menor de edad con historial
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNac"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="sexo"></param>
        /// <param name="dniTutor"></param>
        /// <param name="relacionTutor"></param>
        /// <param name="partidosGanados"></param>
        /// <param name="partidosPerdidos"></param>
        /// <param name="partidosJugados"></param>
        public Jugador(int dni, string nombre, string apellido, DateTime fechaNac,
            string nacionalidad, string sexo, int dniTutor, string relacionTutor,
            int partidosGanados, int partidosPerdidos, int partidosJugados, 
            Contacto contacto, Ubicacion ubicacion)
        {

        }
        #endregion

        int dniTutor;
        string relacionTutor;
        List<Categoria> categoria;
        int pp;
        int pg;
        int pj;
        //Datos de partidos por categorias
    }
}
