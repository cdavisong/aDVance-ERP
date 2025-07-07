using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Taller.Interfaces {
    public interface IVistaTuplaCostoProduccion : IVistaTupla {
        string Id { get; set; }
        string NombreProducto { get; set; }
        decimal CostoMateriaPrima { get; set; }
        decimal CostoManoObra { get; set; }
        decimal CostoIndirectoFabricacion { get; set; }
        decimal CostoTotal { get; set; }
        string FechaRegistro { get; set; }
        string? Observaciones { get; set; }
    }
}