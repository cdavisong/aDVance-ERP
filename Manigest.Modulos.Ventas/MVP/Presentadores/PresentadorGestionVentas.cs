using Manigest.Core.MVP.Presentadores;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Ventas.MVP.Modelos;
using Manigest.Modulos.Ventas.MVP.Modelos.Repositorios;
using Manigest.Modulos.Ventas.MVP.Vistas.Venta;
using Manigest.Modulos.Ventas.MVP.Vistas.Venta.Plantillas;

using System.Globalization;

namespace Manigest.Modulos.Ventas.MVP.Presentadores {
    public class PresentadorGestionVentas : PresentadorGestionBase<PresentadorTuplaVenta, IVistaGestionVentas, IVistaTuplaVenta, Venta, DatosVenta, CriterioBusquedaVenta> {
        public PresentadorGestionVentas(IVistaGestionVentas vista) : base(vista) {
        }

        public override CriterioBusquedaVenta CriterioBusquedaObjeto { get; protected set; } = CriterioBusquedaVenta.Fecha;

        protected override PresentadorTuplaVenta ObtenerValoresTupla(Venta objeto) {
            var presentadorTupla = new PresentadorTuplaVenta(new VistaTuplaVenta(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.Fecha = objeto.Fecha.ToString("dd/MM/yyyy");
            presentadorTupla.Vista.NombreAlmacen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacen) ?? string.Empty;
            presentadorTupla.Vista.NombreCliente = UtilesCliente.ObtenerRazonSocialCliente(objeto.IdCliente) ?? string.Empty;
            presentadorTupla.Vista.CantidadProductos = UtilesVenta.ObtenerCantidadProductosVenta(objeto.Id).ToString();
            presentadorTupla.Vista.Total = objeto.Total.ToString("0.00", CultureInfo.CurrentCulture);

            return presentadorTupla;
        }
    }
}
