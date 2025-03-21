using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Caja.Plantillas {
    public interface IVIstaRegistroCaja : IVistaRegistro {
        string Numero { get; set; }
        decimal SaldoInicial { get; set; }
        string Notas { get; set; }
    }
}
