using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Modulos.Taller.Interfaces
{
    public interface IVistaMenuTaller : IVistaMenu {
        event EventHandler? VerOrdenesProduccion;
    }
}