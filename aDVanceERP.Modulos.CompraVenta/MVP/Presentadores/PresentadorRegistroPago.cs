using System.Globalization;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Pago.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores; 

public class
    PresentadorRegistroPago : PresentadorRegistroBase<IVistaRegistroPago, Pago, DatosPago, CriterioBusquedaPago> {
    public PresentadorRegistroPago(IVistaRegistroPago vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Pago objeto) {
        Vista.Total = objeto.Monto;
        Vista.ModoEdicionDatos = true;

        var pagos = UtilesVenta.ObtenerPagosPorVenta(objeto.IdVenta);

        foreach (var pago in pagos) {
            var pagoSplit = pago.Split(':');
            ((IVistaGestionPagos)Vista).AdicionarPago(pagoSplit[0],
                decimal.TryParse(pagoSplit[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var monto)
                    ? monto
                    : 0.00m);
        }

        Objeto = objeto;
    }

    protected override Task<Pago?> ObtenerObjetoDesdeVista() {
        throw new NotImplementedException();
    }
}