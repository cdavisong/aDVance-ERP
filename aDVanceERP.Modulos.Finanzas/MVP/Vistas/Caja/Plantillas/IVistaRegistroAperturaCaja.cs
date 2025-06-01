using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas {
    public interface IVistaRegistroAperturaCaja : IVistaRegistro {
        DateTime Fecha { get; set; }
        decimal SaldoInicial { get; set; }
    }
}
