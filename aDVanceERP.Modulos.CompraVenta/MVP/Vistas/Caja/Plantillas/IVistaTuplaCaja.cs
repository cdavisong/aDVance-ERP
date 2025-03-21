using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Caja.Plantillas {

    public interface IVistaTuplaCaja : IVistaTupla {
        string Id { get; set; }        
        string Numero { get; set; }
        string FechaApertura { get; set; }
        string SaldoInicial { get; set; }
        string SaldoFinal { get; set; }
        string FechaHoraCierre { get; set; }
        string Notas { get; set; }
    }
}
