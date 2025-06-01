using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores; 

public class PresentadorRegistroProducto : PresentadorRegistroBase<IVistaRegistroProducto, Producto, DatosProducto,
    CriterioBusquedaProducto> {
    public PresentadorRegistroProducto(IVistaRegistroProducto vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Producto objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.CategoriaProducto = objeto.Categoria;
        Vista.Nombre = objeto.Nombre ?? string.Empty;
        Vista.Codigo = objeto.Codigo ?? string.Empty;
        Vista.RazonSocialProveedor = UtilesProveedor.ObtenerRazonSocialProveedor(objeto.IdProveedor) ?? string.Empty;
        Vista.EsVendible = objeto.EsVendible;

        using (var datos = new DatosDetalleProducto()) {
            var detalleProducto = datos.Obtener(CriterioBusquedaDetalleProducto.Id, objeto.IdDetalleProducto.ToString()).FirstOrDefault();

            if (detalleProducto != null) {
                Vista.Descripcion = detalleProducto.Descripcion ?? "No hay una descripción disponible para el producto actual";
                Vista.UnidadMedida = UtilesUnidadMedida.ObtenerNombreUnidadMedida(detalleProducto.IdUnidadMedida) ?? string.Empty;
                Vista.ColorPrimario = UtilesColorProducto.ObtenerNombreColorProducto(detalleProducto.IdColorProductoPrimario) ?? string.Empty;
                Vista.ColorSecundario = UtilesColorProducto.ObtenerNombreColorProducto(detalleProducto.IdColorProductoSecundario) ?? string.Empty;
                Vista.Tipo = UtilesTipoProducto.ObtenerNombreTipoProducto(detalleProducto.IdTipoProducto) ?? string.Empty;
                Vista.Diseno = UtilesDisenoProducto.ObtenerNombreDisenoProducto(detalleProducto.IdDisenoProducto) ?? string.Empty;
            }
        }
        
        Vista.PrecioCompraBase = objeto.PrecioCompraBase;
        Vista.PrecioVentaBase = objeto.PrecioVentaBase;
        Vista.ModoEdicionDatos = true;

        Objeto = objeto;
    }

    protected override bool RegistroEdicionDatosAutorizado() {
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre);
        var unidadMedidaOk = !string.IsNullOrEmpty(Vista.UnidadMedida);
        var precioCompraOk =
            (Vista.CategoriaProducto == CategoriaProducto.ProductoTerminado && Vista.PrecioCompraBase == 0) ||
            (Vista.CategoriaProducto != CategoriaProducto.ProductoTerminado && Vista.PrecioCompraBase > 0);
        var precioVentaOk = 
            (Vista.CategoriaProducto == CategoriaProducto.MateriaPrima && Vista.EsVendible && Vista.PrecioVentaBase > 0) ||
            (Vista.CategoriaProducto == CategoriaProducto.MateriaPrima && !Vista.EsVendible && Vista.PrecioVentaBase == 0) ||
            (Vista.CategoriaProducto != CategoriaProducto.MateriaPrima && Vista.PrecioVentaBase > 0);
        
        if (!nombreOk)
            CentroNotificaciones.Mostrar("El campo de nombre es obligatorio para el producto, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        if (!unidadMedidaOk)
            CentroNotificaciones.Mostrar("El campo de unidad de medida es obligatorio para el producto, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        if (!precioCompraOk)
            CentroNotificaciones.Mostrar("Debe especificar un monto válido para el precio de compra, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        if (!precioVentaOk)
            CentroNotificaciones.Mostrar("Debe especificar un monto válido para el precio de venta, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

        return nombreOk && unidadMedidaOk && precioCompraOk && precioVentaOk;
    }

    protected override void RegistroAuxiliar(DatosProducto datosProducto, long id) {
        var idColorPrimario = UtilesColorProducto.ObtenerIdColorProducto(Vista.ColorPrimario).Result;
        var idColorSecundario = UtilesColorProducto.ObtenerIdColorProducto(Vista.ColorSecundario).Result;

        // Registrar colores del producto si no existen
        using (var datos = new DatosColorProducto()) {
            if (!string.IsNullOrEmpty(Vista.ColorPrimario) && idColorPrimario == 0)
                idColorPrimario = datos.Adicionar(new ColorProducto(0, Vista.ColorPrimario, 0));
            if (!string.IsNullOrEmpty(Vista.ColorSecundario) && idColorSecundario == 0)
                idColorSecundario = datos.Adicionar(new ColorProducto(0, Vista.ColorSecundario, 0));
        }

        var detalleProducto = new DetalleProducto(Objeto?.IdDetalleProducto ?? 0,
            UtilesUnidadMedida.ObtenerIdUnidadMedida(Vista.UnidadMedida).Result,
            idColorPrimario,
            idColorSecundario,
            UtilesTipoProducto.ObtenerIdTipoProducto(Vista.Tipo).Result,
            UtilesDisenoProducto.ObtenerIdDisenoProducto(Vista.Diseno).Result,
            Vista.Descripcion ?? "No hay una descripción disponible para el producto actual"
        );

        // Registrar detalles del producto
        using (var datos = new DatosDetalleProducto()) {
            if (Vista.ModoEdicionDatos && Objeto?.IdDetalleProducto != 0)
                datos.Editar(detalleProducto);
            else if (Objeto?.IdDetalleProducto != 0)
                datos.Editar(detalleProducto);
            else {
                Objeto.IdDetalleProducto = datos.Adicionar(detalleProducto);

                // Stock inicial del producto
                UtilesMovimiento.ModificarStockProductoAlmacen(
                    Objeto.Id,
                    0,
                    UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacen).Result,
                    Vista.StockInicial
                );
            }

            // Editar producto para modificar Id de los detalles
            datosProducto.Editar(Objeto);
        }
    }

    protected override async Task<Producto?> ObtenerObjetoDesdeVista() {
        return new Producto(
            Objeto?.Id ?? 0,
            Vista.CategoriaProducto,
            Vista.Nombre,
            Vista.Codigo,
            Objeto?.IdDetalleProducto ?? 0,
            await UtilesProveedor.ObtenerIdProveedor(Vista.RazonSocialProveedor),
            Vista.EsVendible,
            Vista.PrecioCompraBase,
            Vista.PrecioVentaBase
        );
    }
}