using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Taller.Interfaces {
    public interface IVistaMenuTaller : IVistaMenu {
        event EventHandler? VerCostosProduccion;
    }
}