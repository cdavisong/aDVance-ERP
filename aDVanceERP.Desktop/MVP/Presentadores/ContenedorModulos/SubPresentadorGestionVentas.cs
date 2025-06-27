using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta;

using Newtonsoft.Json;

using System.Globalization;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorGestionVentas? _gestionVentas;

    private async void InicializarVistaGestionVentas() {
        _gestionVentas = new PresentadorGestionVentas(new VistaGestionVentas());
        _gestionVentas.EditarObjeto += OnMostrarVistaEdicionVentaProducto;
        _gestionVentas.Vista.RegistrarDatos += OnMostrarVistaRegistroVentaProducto;
        _gestionVentas.Vista.ImportarVentasArchivo += OnImportarVentasArchivo;

        if (Vista.Vistas != null)
            await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionVentas", _gestionVentas.Vista));
    }

    private async void MostrarVistaGestionVentas(object? sender, EventArgs e) {
        if (_gestionVentas?.Vista == null)
            return;

        _gestionVentas.Vista.CargarCriteriosBusqueda(UtilesBusquedaVenta.CriterioBusquedaVenta);
        _gestionVentas.Vista.Restaurar();
        _gestionVentas.Vista.Mostrar();

        await _gestionVentas.RefrescarListaObjetos();
    }

    private void OnImportarVentasArchivo(object? sender, string ventas) {
        var ventasJson = JsonConvert.DeserializeObject<List<VentaJson>>(ventas);

        if (ventasJson == null)
            return;

        //TODO: Mejorar la velocidad de la operación con una conexion unica 
        //var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString());

        foreach (var ventaJson in ventasJson) {
            var idAlmacen = 0L;

            foreach (var productoVendidoJson in ventaJson.Productos) {
                if (idAlmacen == 0)
                    idAlmacen = UtilesAlmacen.ObtenerIdAlmacen(productoVendidoJson.Producto.nombre_almacen).Result;

                var tuplaProducto = new string[] {
                    productoVendidoJson.Producto.id_producto.ToString(),
                    productoVendidoJson.Producto.nombre,
                    productoVendidoJson.Producto.precio_compra_base.ToString("N2", CultureInfo.InvariantCulture),
                    productoVendidoJson.Producto.precio_venta_base.ToString("N2", CultureInfo.InvariantCulture),
                    productoVendidoJson.Cantidad.ToString(),
                    idAlmacen.ToString()
                };

                if (tuplaProducto ==  null) 
                    continue;

                ProductosVenta?.Add(tuplaProducto);
            }

            using (var repoVentas = new DatosVenta()) {
                ventaJson.IdVenta = repoVentas.Adicionar(new Venta(0,
                    ventaJson.Fecha,
                    idAlmacen,
                    0,
                    UtilesEntrega.ObtenerIdTipoEntrega("Presencial").Result,
                    "",
                    "Completada",
                    (decimal) ventaJson.Total
                    ));
            }

            var pago = new Pago(0,
               ventaJson.IdVenta,
               ventaJson.MetodoPago,
               (decimal)ventaJson.Total);


            using (var repoPagos = new DatosPago()) {
                pago.Id = repoPagos.Adicionar(pago);
            }

            RegistrarDetallesVentaProducto();
            ActualizarSeguimientoEntrega(ventaJson.IdVenta);
            ActualizarMovimientoCaja([pago]);

            ProductosVenta?.Clear();
        }

        _gestionVentas?.RefrescarListaObjetos();
    }
}

internal class ProductoJson {
    public int id_producto { get; set; }
    public string codigo { get; set; }
    public string nombre { get; set; }
    public string categoria { get; set; }
    public decimal precio_compra_base { get; set; }
    public decimal precio_venta_base { get; set; }
    public int stock { get; set; }
    public string nombre_almacen { get; set; }
    public string unidad_medida { get; set; }
    public string abreviatura_medida { get; set; }
}

internal class ProductoVendidoJson {
    public ProductoJson Producto { get; set; }
    public int Cantidad { get; set; }
}

internal class VentaJson {
    public long IdVenta { get; set; }
    public DateTime Fecha { get; set; }
    public List<ProductoVendidoJson> Productos { get; set; }
    public double Total { get; set; }
    public string MetodoPago { get; set; } // "Efectivo" o "Transferencia"
}