namespace Slam
{

    public enum TipoPersona : int
    {
        Jugador = 0, Empleado = 1, Arbitro = 2
    };

    public enum TipoTorneo : int 
    { 
        Single = 0, Doble = 1 
    };



    public enum EstadoTorneo : int { Abierto = 0, Cerrado = 1, Jugando = 2, Finalizado = 3, NoIniciado = 4, Cancelado =5}

    public enum TipoSuperficie : int
    {
        Ladrillo = 0, Cesped = 1, Dura = 2, Sintetica = 3
    }
}