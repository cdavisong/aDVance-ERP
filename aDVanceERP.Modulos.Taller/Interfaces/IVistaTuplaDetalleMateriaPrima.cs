using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Taller.Interfaces {
    internal interface IVistaTuplaDetalleMateriaPrima : IVistaTupla {
        string IdProducto { get; set; }
        string NombreProducto { get; set; }
        string PrecioUnitario { get; set; }
        string Cantidad { get; set; }

        event EventHandler? PrecioUnitarioModificado;
    }
}
