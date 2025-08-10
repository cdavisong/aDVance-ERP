using System.Globalization;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas;
using aDVanceERP.Modulos.CompraVenta.Repositorios;

using Newtonsoft.Json;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores; 

public class PresentadorGestionVentas : PresentadorGestionBase<PresentadorTuplaVenta, IVistaGestionVentas,
    IVistaTuplaVenta, Venta, RepoVenta, FbVenta> {
    public PresentadorGestionVentas(IVistaGestionVentas vista) : base(vista) {
        vista.ConfirmarEntrega += OnConfirmarEntregaAriculos;
        vista.ConfirmarPagos += OnConfirmarPagos;
        vista.EditarDatos += delegate {
            Vista.HabilitarBtnConfirmarEntrega = false;
            Vista.HabilitarBtnConfirmarPagos = false;
        };
    }

    protected override PresentadorTuplaVenta ObtenerValoresTupla(Venta objeto) {
        var presentadorTupla = new PresentadorTuplaVenta(new VistaTuplaVenta(), objeto);
        var nombreCliente = UtilesCliente.ObtenerRazonSocialCliente(objeto.IdCliente) ?? string.Empty;

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.Fecha = objeto.Fecha.ToString("yyyy-MM-dd");
        presentadorTupla.Vista.NombreAlmacen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacen) ?? string.Empty;
        presentadorTupla.Vista.NombreCliente = string.IsNullOrEmpty(nombreCliente) ? "Anónimo" : nombreCliente;
        presentadorTupla.Vista.CantidadProductos = UtilesVenta.ObtenerCantidadProductosVenta(objeto.Id).ToString("N2", CultureInfo.InvariantCulture);
        presentadorTupla.Vista.MontoTotal = objeto.Total.ToString("N2", CultureInfo.InvariantCulture);
        presentadorTupla.Vista.EstadoEntrega = objeto.EstadoEntrega;

        var pagosVenta = UtilesVenta.ObtenerPagosPorVenta(objeto.Id);

        presentadorTupla.Vista.EstadoPago =
            pagosVenta.Count == 0 || pagosVenta.Any(p => !p.Split('|')[5].Equals("Confirmado"))
                ? "Pendiente"
                : "Confirmado";
        presentadorTupla.EntidadSeleccionada += CambiarVisibilidadBtnConfirmarEntrega;
        presentadorTupla.EntidadSeleccionada += CambiarVisibilidadBtnConfirmarPagos;
        presentadorTupla.EntidadDeseleccionada += CambiarVisibilidadBtnConfirmarEntrega;
        presentadorTupla.EntidadDeseleccionada += CambiarVisibilidadBtnConfirmarPagos;

        return presentadorTupla;
    }

    public override Task PopularTuplasDatosEntidades() {
        // Cambiar la visibilidad de los botones de confirmación
        Vista.HabilitarBtnConfirmarEntrega = false;
        Vista.HabilitarBtnConfirmarPagos = false;

        // Actualizar el valor bruto de las ventas al refrescar la lista de objetos.
        Vista.ActualizarValorBrutoVentas();

        return base.PopularTuplasDatosEntidades();
    }

    private void OnConfirmarEntregaAriculos(object? sender, EventArgs e) {
        foreach (var tupla in _tuplasObjetos)
            if (tupla.TuplaSeleccionada) {
                tupla.Entidad.EstadoEntrega = "Completada";

                // Editar la venta del producto
                RepoDatosEntidad.Actualizar(tupla.Entidad);

                // Actualizar el seguimiento de entrega
                using (var datosSeguimiento = new RepoSeguimientoEntrega()) {
                    var objetoSeguimiento = datosSeguimiento.Buscar(FbSeguimientoEntrega.IdVenta, tupla.Vista.Id).resultados.FirstOrDefault();

                    if (objetoSeguimiento != null) {
                        objetoSeguimiento.FechaEntrega = DateTime.Now;

                        datosSeguimiento.Actualizar(objetoSeguimiento);
                    }
                }

                break;
            }

        _ = PopularTuplasDatosEntidades();
    }

    private void OnConfirmarPagos(object? sender, EventArgs e) {
        // 1. Filtrar primero las tuplas seleccionadas para evitar procesamiento innecesario
        var tuplasSeleccionadas = _tuplasEntidades.Where(t => t.TuplaSeleccionada).ToList();

        if (!tuplasSeleccionadas.Any()) {
            Vista.HabilitarBtnConfirmarPagos = false;
            return;
        }

        // 2. Mover las instancias de DatosPago y DatosSeguimiento fuera del bucle
        using (var datosPago = new RepoPago())
        using (var datosSeguimiento = new RepoSeguimientoEntrega()) {
            foreach (var tupla in tuplasSeleccionadas) {
                var ventaId = long.Parse(tupla.Vista.Id);
                var montoTotal = decimal.Parse(tupla.Vista.MontoTotal, CultureInfo.InvariantCulture);
                var pagos = UtilesVenta.ObtenerPagosPorVenta(ventaId);
                var ahora = DateTime.Now;

                // 3. Procesar pagos
                if (pagos.Count == 0) {
                    // Crear nuevo pago
                    var nuevoPago = new Pago(
                        0,
                        ventaId,
                        "Efectivo",
                        montoTotal) {
                        Estado = "Confirmado",
                        FechaConfirmacion = ahora
                    };

                    datosPago.Insertar(nuevoPago);
                }
                else {
                    // Actualizar pagos existentes
                    foreach (var pago in pagos) {
                        var pagoSplit = pago.Split('|');
                        var pagoActualizado = new Pago(
                            long.Parse(pagoSplit[0]),
                            ventaId,
                            pagoSplit[2],
                            decimal.Parse(pagoSplit[3], CultureInfo.InvariantCulture)) {
                            Estado = "Confirmado",
                            FechaConfirmacion = ahora
                        };

                        datosPago.Actualizar(pagoActualizado);
                    }
                }

                // 4. Actualizar seguimiento de entrega (una sola vez por tupla)
                var objetoSeguimiento = datosSeguimiento.Buscar(
                    FbSeguimientoEntrega.IdVenta,
                    tupla.Vista.Id).resultados.FirstOrDefault();

                if (objetoSeguimiento != null) {
                    objetoSeguimiento.FechaPago = ahora;
                    // Nota: Corregí FechaEntrega a FechaPago para consistencia con el caso de pagos.Count == 0
                    datosSeguimiento.Actualizar(objetoSeguimiento);
                }
            }
        }

        Vista.HabilitarBtnConfirmarPagos = false;
        _ = PopularTuplasDatosEntidades();
    }

    private void CambiarVisibilidadBtnConfirmarEntrega(object? sender, EventArgs e) {
        if (_tuplasEntidades.Any(t => t.TuplaSeleccionada)) {
            foreach (var tupla in _tuplasEntidades)
                if (tupla.TuplaSeleccionada) {
                    if (!tupla.Entidad.EstadoEntrega.Equals("Completada")) {
                        Vista.HabilitarBtnConfirmarEntrega = true;
                    }
                    else {
                        Vista.HabilitarBtnConfirmarEntrega = false;
                        return;
                    }
                }
        }
        else {
            Vista.HabilitarBtnConfirmarEntrega = false;
        }
    }

    private void CambiarVisibilidadBtnConfirmarPagos(object? sender, EventArgs e) {
        if (_tuplasEntidades.Any(t => t.TuplaSeleccionada)) {
            foreach (var tupla in _tuplasEntidades)
                if (tupla.TuplaSeleccionada) {
                    if (!tupla.Vista.EstadoPago.Equals("Confirmado")) {
                        Vista.HabilitarBtnConfirmarPagos = true;
                    }
                    else {
                        Vista.HabilitarBtnConfirmarPagos = false;
                        return;
                    }
                }
        }
        else {
            Vista.HabilitarBtnConfirmarPagos = false;
        }
    }
}