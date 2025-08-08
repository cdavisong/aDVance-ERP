using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas
{
    public interface IVistaRegistroAperturaCaja : IVistaRegistroEdicion {
        DateTime Fecha { get; set; }
        decimal SaldoInicial { get; set; }
    }
}
