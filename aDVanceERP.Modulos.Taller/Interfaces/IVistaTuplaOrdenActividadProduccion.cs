using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Modulos.Taller.Interfaces
{
    public interface IVistaTuplaOrdenActividadProduccion : IVistaTupla {
        string IdOrdenActividadProduccion { get; set; }
        string NombreActividadProduccion { get; set; }
        string CostoActividad { get; set; }
        string Cantidad { get; set; }

        event EventHandler? CostoActividadModificado;
    }
}