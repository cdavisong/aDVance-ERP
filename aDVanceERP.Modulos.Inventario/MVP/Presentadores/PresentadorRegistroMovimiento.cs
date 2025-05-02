using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores; 

public class PresentadorRegistroMovimiento : PresentadorRegistroBase<IVistaRegistroMovimiento, Movimiento,
    DatosMovimiento, CriterioBusquedaMovimiento> {
    private Movimiento? _movimiento;

    public PresentadorRegistroMovimiento(IVistaRegistroMovimiento vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Movimiento objeto) {
        Vista.NombreArticulo = UtilesArticulo.ObtenerNombreArticulo(objeto.IdArticulo).Result ?? string.Empty;
        Vista.NombreAlmacenOrigen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenOrigen) ?? string.Empty;
        Vista.NombreAlmacenDestino = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenDestino) ?? string.Empty;
        Vista.Fecha = objeto.Fecha;
        Vista.CantidadMovida = objeto.CantidadMovida;
        Vista.TipoMovimiento = UtilesMovimiento.ObtenerNombreTipoMovimiento(objeto.IdTipoMovimiento) ?? string.Empty;
        Vista.ModoEdicionDatos = true;

        Objeto = objeto;
    }

    protected override bool RegistroEdicionDatosAutorizado() {
        var nombreArticuloOk = !string.IsNullOrEmpty(Vista.NombreArticulo);
        var tipoMovimientoOk = !string.IsNullOrEmpty(Vista.TipoMovimiento);
        var noCompraventaOk = !(Vista.TipoMovimiento.Equals("Compra") || Vista.TipoMovimiento.Equals("Venta"));
        
        var efectoMovimiento = UtilesMovimiento.ObtenerEfectoTipoMovimiento(UtilesMovimiento.ObtenerIdTipoMovimiento(Vista.TipoMovimiento));

        if (!string.IsNullOrEmpty(efectoMovimiento)) {
            switch (efectoMovimiento) {
                case "Carga":
                    if (string.IsNullOrEmpty(Vista.NombreAlmacenDestino) || Vista.NombreAlmacenDestino.Equals("Ninguno")) {
                        CentroNotificaciones.Mostrar("Debe especificar un almacén de destino para la operación de carga solicitada", TipoNotificacion.Advertencia);
                        return false;
                    }
                    break;
                case "Descarga":
                    if (string.IsNullOrEmpty(Vista.NombreAlmacenOrigen) || Vista.NombreAlmacenOrigen.Equals("Ninguno")) {
                        CentroNotificaciones.Mostrar("Debe especificar un almacén de origen para la operación de descarga solicitada", TipoNotificacion.Advertencia);
                        return false;
                    }
                    break;
                case "Transferencia":
                    if (string.IsNullOrEmpty(Vista.NombreAlmacenOrigen) || string.IsNullOrEmpty(Vista.NombreAlmacenDestino) || Vista.NombreAlmacenOrigen.Equals("Ninguno") || Vista.NombreAlmacenDestino.Equals("Ninguno")) {
                        CentroNotificaciones.Mostrar("Debe especificar un almacén de origen y un destino para la operación de transferencia solicitada", TipoNotificacion.Advertencia);
                        return false;
                    }
                    break;
                default:
                    CentroNotificaciones.Mostrar("Efecto de movimiento desconocido", TipoNotificacion.Error);
                    return false;
            }
        }

        var fechaOk = Vista.Fecha >= DateTime.Today;
        var cantidadOk = Vista.CantidadMovida > 0;

        if (efectoMovimiento.Equals("Descarga") || efectoMovimiento.Equals("Transferencia")) {
            if (!string.IsNullOrEmpty(Vista.NombreAlmacenOrigen)) {
                var cantidadInicialOrigen = UtilesArticulo.ObtenerStockArticulo(Vista.NombreArticulo, Vista.NombreAlmacenOrigen).Result;

                if (cantidadInicialOrigen - Vista.CantidadMovida < 0) {
                    CentroNotificaciones.Mostrar($"No se puede mover una cantidad de artículos hacia el destino menor que la cantidad orígen ({cantidadInicialOrigen} unidades) en el almacén {Vista.NombreAlmacenOrigen}", TipoNotificacion.Advertencia);
                    return false;
                }
            }
        }

        if (!nombreArticuloOk)
            CentroNotificaciones.Mostrar("El campo de nombre para el artículo es obligatorio para el artículo, por favor, corrija los datos entrados", TipoNotificacion.Advertencia);
        if (!tipoMovimientoOk)
            CentroNotificaciones.Mostrar("Debe especificar un tipo de movimiento válido para el movimiento de artículos, por favor, corrija los datos entrados", TipoNotificacion.Advertencia);
        if (!noCompraventaOk)
            CentroNotificaciones.Mostrar("Las operaciones de compraventa no están permitidas directamente desde la sección de movimientos de inventario. Para registrar compras o ventas diríjase al módulo correspondiente", TipoNotificacion.Advertencia);
        if (!fechaOk)
            CentroNotificaciones.Mostrar("No se puede registrar un movimiento con una fecha inferior a la fecha del día de hoy", TipoNotificacion.Advertencia);
        if (!cantidadOk)
            CentroNotificaciones.Mostrar("La cantidad de artículos a mover en una operación de carga, descarga o transferencia debe ser mayor que 0, corrija los datos entrados", TipoNotificacion.Advertencia);


        return nombreArticuloOk && tipoMovimientoOk && noCompraventaOk && fechaOk && cantidadOk;
    }

    protected override async Task<Movimiento?> ObtenerObjetoDesdeVista() {
        _movimiento = new Movimiento(
            Objeto?.Id ?? 0,
            await UtilesArticulo.ObtenerIdArticulo(Vista.NombreArticulo),
            await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenOrigen),
            await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenDestino),
            Vista.Fecha,
            Vista.CantidadMovida,
            UtilesMovimiento.ObtenerIdTipoMovimiento(Vista.TipoMovimiento)
        );

        return _movimiento;
    }

    protected override void RegistroAuxiliar(long id) {
        if (_movimiento != null)
            UtilesMovimiento.ModificarStockArticuloAlmacen(_movimiento.IdArticulo, _movimiento.IdAlmacenOrigen,
                _movimiento.IdAlmacenDestino, _movimiento.CantidadMovida);
    }
}