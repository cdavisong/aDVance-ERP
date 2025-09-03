using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Repositorios.Modulos.Inventario;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorRegistroMovimiento : PresentadorRegistroBase<IVistaRegistroMovimiento, Movimiento,
    RepoMovimiento, FiltroBusquedaMovimiento> {

    public PresentadorRegistroMovimiento(IVistaRegistroMovimiento vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Movimiento objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.NombreProducto = UtilesProducto.ObtenerNombreProducto(objeto.IdProducto).Result ?? string.Empty;
        Vista.NombreAlmacenOrigen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenOrigen) ?? string.Empty;
        Vista.NombreAlmacenDestino = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenDestino) ?? string.Empty;
        Vista.Fecha = objeto.Fecha;
        Vista.CantidadMovida = objeto.CantidadMovida;
        Vista.TipoMovimiento = UtilesMovimiento.ObtenerNombreTipoMovimiento(objeto.IdTipoMovimiento) ?? string.Empty;

        Entidad = objeto;
    }

    protected override bool RegistroEdicionDatosAutorizado() {
        var nombreProductoOk = !string.IsNullOrEmpty(Vista.NombreProducto);
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

        var cantidadOk = Vista.CantidadMovida > 0;

        if (efectoMovimiento.Equals("Descarga") || efectoMovimiento.Equals("Transferencia")) {
            if (!string.IsNullOrEmpty(Vista.NombreAlmacenOrigen)) {
                var cantidadInicialOrigen = UtilesProducto.ObtenerStockProducto(Vista.NombreProducto, Vista.NombreAlmacenOrigen).Result;

                if (cantidadInicialOrigen - Vista.CantidadMovida < 0) {
                    CentroNotificaciones.Mostrar($"No se puede mover una cantidad de productos hacia el destino menor que la cantidad orígen ({cantidadInicialOrigen} unidades) en el almacén {Vista.NombreAlmacenOrigen}", TipoNotificacion.Advertencia);
                    return false;
                }
            }
        }

        if (!nombreProductoOk)
            CentroNotificaciones.Mostrar("El campo de nombre para el producto es obligatorio para el producto, por favor, corrija los datos entrados", TipoNotificacion.Advertencia);
        if (!tipoMovimientoOk)
            CentroNotificaciones.Mostrar("Debe especificar un tipo de movimiento válido para el movimiento de productos, por favor, corrija los datos entrados", TipoNotificacion.Advertencia);
        if (!noCompraventaOk)
            CentroNotificaciones.Mostrar("Las operaciones de compraventa no están permitidas directamente desde la sección de movimientos de inventario. Para registrar compras o ventas diríjase al módulo correspondiente", TipoNotificacion.Advertencia);
        if (!cantidadOk)
            CentroNotificaciones.Mostrar("La cantidad de productos a mover en una operación de carga, descarga o transferencia debe ser mayor que 0, corrija los datos entrados", TipoNotificacion.Advertencia);


        return nombreProductoOk && tipoMovimientoOk && noCompraventaOk && cantidadOk;
    }

    protected override void RegistroAuxiliar(RepoMovimiento datosMovimiento, long id) {
        var idProducto = UtilesProducto.ObtenerIdProducto(Vista.NombreProducto).Result;

        if (Entidad != null)
            UtilesMovimiento.ModificarInventario(
                idProducto,
                UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenOrigen).Result,
                UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenDestino).Result,
                Vista.CantidadMovida,
                UtilesProducto.ObtenerCostoUnitario(idProducto).Result);
    }

    protected override Movimiento? ObtenerEntidadDesdeVista() {
        return new Movimiento(
            Vista.ModoEdicionDatos && Entidad != null ? Entidad.Id : 0,
            UtilesProducto.ObtenerIdProducto(Vista.NombreProducto).Result,
            UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenOrigen).Result,
            UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenDestino).Result,
            Vista.Fecha,
            Vista.CantidadMovida,
            UtilesMovimiento.ObtenerIdTipoMovimiento(Vista.TipoMovimiento)
        );
    }
}