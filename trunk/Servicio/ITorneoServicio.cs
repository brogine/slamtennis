using Servicio.InterfacesUI;

namespace Servicio
{
    public interface ITorneoServicio
    {
        int Agregar(ITorneoUI UI);

        void Modificar(ITorneoUI UI);

        void Buscar(ITorneoUI UI);

        void GetFechas(IFechasTorneoUI ui);

        int GetTipoTorneo(int IdTorneo);

        bool Existe(int IdTorneo);

    }
}
