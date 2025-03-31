using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta;

using System.Globalization;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores {
    public class PresentadorGestionVentas : PresentadorGestionBase<PresentadorTuplaVenta, IVistaGestionVentas, IVistaTuplaVenta, Venta, DatosVenta, CriterioBusquedaVenta> {
        public PresentadorGestionVentas(IVistaGestionVentas vista) : base(vista) {
        }

        protected override PresentadorTuplaVenta ObtenerValoresTupla(Venta objeto) {
            var presentadorTupla = new PresentadorTuplaVenta(new VistaTuplaVenta(), objeto);
            var nombreCliente = UtilesCliente.ObtenerRazonSocialCliente(objeto.IdCliente) ?? string.Empty;

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.Fecha = objeto.Fecha.ToString("yyyy-MM-dd");
            presentadorTupla.Vista.NombreAlmacen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacen) ?? string.Empty;
            presentadorTupla.Vista.NombreCliente = string.IsNullOrEmpty(nombreCliente) ? "Anónimo" : nombreCliente;
            presentadorTupla.Vista.CantidadProductos = UtilesVenta.ObtenerCantidadProductosVenta(objeto.Id).ToString();
            presentadorTupla.Vista.MontoTotal = objeto.Total.ToString("N2", CultureInfo.InvariantCulture);

            return presentadorTupla;
        }

        public override Task RefrescarListaObjetos() {
            // Actualizar el valor bruto de las ventas al refrescar la lista de objetos.
            Vista.ActualizarValorBrutoVentas();

            return base.RefrescarListaObjetos();
        }
    }
}
