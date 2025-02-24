using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Vistas.Pago.Plantillas {
    public interface IVistaRegistroPago : IVistaRegistro {
        string MetodoPago { get; set; }
        float Monto { get; set; }
        List<string[]> Pagos { get; }
        float Total { get; set; }
        float Suma { get; set; }
        float Pendiente { get; set; }
        float Devolucion { get; set; }

        event EventHandler? EfectuarTransferencia;
        event EventHandler? PagoAgregado;
        event EventHandler? PagoEliminado;

        void CargarMetodosPago();
    }
}
