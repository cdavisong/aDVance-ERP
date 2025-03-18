using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Pago.Plantillas;

using System.Globalization;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores {
    public class PresentadorRegistroPago : PresentadorRegistroBase<IVistaRegistroPago, Pago, DatosPago, CriterioBusquedaPago> {
        public PresentadorRegistroPago(IVistaRegistroPago vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Pago objeto) {
            Vista.Total = objeto.Monto;
            Vista.ModoEdicionDatos = true;

            var pagos = UtilesVenta.ObtenerPagosPorVenta(objeto.IdVenta);

            foreach (var pago in pagos) {
                var pagoSplit = pago.Split(':');
                ((IVistaGestionPagos) Vista).AdicionarPago(pagoSplit[0], float.Parse(pagoSplit[1], NumberStyles.Float, CultureInfo.CurrentCulture));
            }

            _objeto = objeto;
        }

        protected override async Task<Pago?> ObtenerObjetoDesdeVista() {
            throw new NotImplementedException();
        }
    }
}
