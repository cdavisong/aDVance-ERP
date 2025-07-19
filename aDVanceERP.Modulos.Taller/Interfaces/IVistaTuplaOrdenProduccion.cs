using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Taller.Interfaces {
    public interface IVistaTuplaOrdenProduccion : IVistaTupla {
        string Id { get; set; }
        string NumeroOrden { get; set; }
        string FechaApertura { get; set; }
        string NombreProducto { get; set; }
        string CostoTotal { get; set; }
        int Estado { get; set; }
        string FechaCierre { get; set; }
        string Observaciones { get; set; }
    }
}