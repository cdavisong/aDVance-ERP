using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Vistas.Pago.Plantillas {
    public interface IVistaGestionPagos : IVistaContenedor, IGestorDatos {
        void AdicionarPago(string metodoPago = "", float monto = -1f);
    }
}
