using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Pago.Plantillas;

public interface IVistaGestionPagos : IVistaContenedor, IGestorDatos {
    void AdicionarPago(long id, long idVenta, string metodoPago, decimal monto);
}