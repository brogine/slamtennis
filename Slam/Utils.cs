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

    public enum EstadoTorneo : int { Abierto, Cerrado, Jugando, Finalizado, Terminado, Cancelado}

    public enum TipoSuperficie : int
    {
        Ladrillo = 0, Cesped = 1, Dura = 2, Sintetica = 3
    }
}