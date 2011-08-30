using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Repositorio.Conexiones;

namespace Repositorio
{
    class JugadorRepositorio:IJugadorRepositorio,IMapeador<Jugador>
    {
        Conexion Conex;
        string ConsultaSql;
        public JugadorRepositorio()
        {
            Conex = new Conexion();
        }
        #region Miembros de IJugadorRepositorio

        public void Agregar(Jugador Jugador)
        {
         
        }

        #endregion

        #region Miembros de IMapeador<Jugador>

        public Jugador Mapear(System.Data.DataRow Fila)
        {
            Jugador nJugador = null;

            if (Fila != null)
            {
                //Agregate Root

                int Dni = (Fila.IsNull("Dni") == true ? 0 : Convert.ToInt32(Fila["Dni"]));
                string Nombre = (Fila.IsNull("Nombre") == true ? string.Empty : Convert.ToString(Fila["Nombre"]));
                string Apellido = (Fila.IsNull("Apellido") == true ? string.Empty : Convert.ToString(Fila["Apellido"]));
                DateTime FechaNac = (Fila.IsNull("FechaNacimiento") == true ? DateTime.Now : Convert.ToDateTime(Fila["FechaNacimiento"]));
                string Nacionalidad = (Fila.IsNull("Nacionalidad") == true ? string.Empty : Convert.ToString(Fila["Nacionalidad"]));
                string Sexo = (Fila.IsNull("Sexo")==true?string.Empty:Convert.ToString(Fila["Sexo"]));
                bool Estado = (Fila.IsNull("Sexo")==true?false:Convert.ToBoolean(Fila["Estado"]));
                //Value Object Contacto

                string Telefono = (Fila.IsNull("Telefono") == true ? string.Empty : Convert.ToString(Fila["Telefono"]));
                string Celular = (Fila.IsNull("Celular") == true ? string.Empty : Convert.ToString(Fila["Celular"]));
                string Email = (Fila.IsNull("Email") == true ? string.Empty : Convert.ToString(Fila["Email"]));
                
                // Value Object Domicilio

                string Provincia = (Fila.IsNull("Provincia")== true?string.Empty:Convert.ToString(Fila["Provincia"]));
                string Localidad = (Fila.IsNull("Localidad") == true ? string.Empty : Convert.ToString(Fila["Localidad"]));
                string Domicilio = (Fila.IsNull("Domicilio") == true ? string.Empty : Convert.ToString(Fila["Domicilio"]));

                if (nJugador.Edad < 18)
                { 
                    int DniTutor = (Fila.IsNull("DniTutor")==true?0:Convert.ToInt32(Fila["DniTutor"]));
                    string Relacion = (Fila.IsNull("Relacion") == true ? string.Empty : Convert.ToString(Fila["Relacion"]));
                }
                
            }
                     
                return nJugador;
        }

        #endregion
    }
}
