using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Taller.Interfaces {
    internal interface IVistaTuplaOrdenMateriaPrima : IVistaTupla {
        string IdOrdenMateriaPrima { get; set; }
        string NombreMateriaPrima { get; set; }
        string PrecioUnitario { get; set; }
        string Cantidad { get; set; }

        event EventHandler? PrecioUnitarioModificado;
    }
}
