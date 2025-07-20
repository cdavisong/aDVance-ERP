using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas;
using aDVanceERP.Modulos.Inventario.Repositorios;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorRegistroProducto : PresentadorRegistroBase<IVistaRegistroProducto, Producto, RepoProducto,
    FbProducto> {
    public PresentadorRegistroProducto(IVistaRegistroProducto vista) : base(vista) { }

    public override void PopularVistaDesdeEntidad(Producto objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.CategoriaProducto = objeto.Categoria;
        Vista.Nombre = objeto.Nombre ?? string.Empty;
        Vista.Codigo = objeto.Codigo ?? string.Empty;
        Vista.RazonSocialProveedor = UtilesProveedor.ObtenerRazonSocialProveedor(objeto.IdProveedor) ?? string.Empty;
        Vista.EsVendible = objeto.EsVendible;
        Vista.TipoMateriaPrima = UtilesTipoMateriaPrima.ObtenerNombreTipoMateriaPrima(objeto.IdTipoMateriaPrima) ?? string.Empty;

        using (var datos = new RepoDetalleProducto()) {
            var detalleProducto = datos.Buscar(FbDetalleProducto.Id, objeto.IdDetalleProducto.ToString()).resultados.FirstOrDefault();

            if (detalleProducto != null) {
                Vista.UnidadMedida = UtilesUnidadMedida.ObtenerNombreUnidadMedida(detalleProducto.IdUnidadMedida) ?? string.Empty;
                Vista.Descripcion = detalleProducto.Descripcion ?? "No hay una descripción disponible para el producto actual";
            }
        }

        Vista.CostoProduccionUnitario = objeto.CostoProduccionUnitario;
        Vista.PrecioCompra = objeto.PrecioCompra;
        Vista.PrecioVentaBase = objeto.PrecioVentaBase;
        Vista.ModoEdicionDatos = true;

        Entidad = objeto;
    }

    protected override bool DatosEntidadCorrectos() {
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre);
        var codigoOk = !string.IsNullOrEmpty(Vista.Codigo);
        var unidadMedidaOk = !string.IsNullOrEmpty(Vista.UnidadMedida);

        if (!nombreOk)
            CentroNotificaciones.Mostrar("El campo de nombre es obligatorio para el producto, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        if (!codigoOk)
            CentroNotificaciones.Mostrar("El campo de código es obligatorio para el producto, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        if (!unidadMedidaOk)
            CentroNotificaciones.Mostrar("El campo de unidad de medida es obligatorio para el producto, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

        return nombreOk && codigoOk && unidadMedidaOk;
    }

    protected override void RegistroAuxiliar(RepoProducto datosProducto, long id) {
        var detalleProducto = new DetalleProducto(Entidad?.IdDetalleProducto ?? 0,
            UtilesUnidadMedida.ObtenerIdUnidadMedida(Vista.UnidadMedida).Result,
            Vista.Descripcion ?? "No hay una descripción disponible para el producto actual"
        );

        // Registrar detalles del producto
        using (var datos = new RepoDetalleProducto()) {
            if (Vista.ModoEdicionDatos && Entidad?.IdDetalleProducto != 0)
                datos.Actualizar(detalleProducto);
            else if (Entidad?.IdDetalleProducto != 0)
                datos.Actualizar(detalleProducto);
            else {
                Entidad.IdDetalleProducto = datos.Insertar(detalleProducto);

                // Stock inicial del producto
                UtilesMovimiento.ModificarStockProductoAlmacen(
                    Entidad.Id,
                    0,
                    UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacen).Result,
                    Vista.StockInicial
                );
            }

            // Editar producto para modificar Id de los detalles
            datosProducto.Actualizar(Entidad);
        }
    }

    protected override Producto? ObtenerEntidadDesdeVista() {
        return new Producto(
            Entidad?.Id ?? 0,
            Vista.CategoriaProducto,
            Vista.Nombre,
            Vista.Codigo,
            Objeto?.IdDetalleProducto ?? 0,
            await UtilesProveedor.ObtenerIdProveedor(Vista.RazonSocialProveedor),
            await UtilesTipoMateriaPrima.ObtenerIdTipoMateriaPrima(Vista.TipoMateriaPrima),
            Vista.EsVendible,
            Vista.PrecioCompra,
            Vista.CostoProduccionUnitario,
            Vista.PrecioVentaBase
        );
    }
}