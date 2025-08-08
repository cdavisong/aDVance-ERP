using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Modulos.Taller.Interfaces
{
    public interface IVistaTuplaOrdenGastoIndirecto : IVistaTupla {
        string IdOrdenGastoIndirecto { get; set; }
        string ConceptoGasto { get; set; }
        string Monto { get; set; }
        string Cantidad { get; set; }

        event EventHandler? MontoGastoModificado;
    }
}