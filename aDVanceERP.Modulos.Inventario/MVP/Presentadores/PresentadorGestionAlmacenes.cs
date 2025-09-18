using aDVanceERP.Core.Controladores;
using aDVanceERP.Core.Documentos.Interfaces;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.Presentadores.Comun;
using aDVanceERP.Core.Repositorios.Modulos.Inventario;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.Documentos.Almacen;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

using ClosedXML.Excel;

using MySql.Data.MySqlClient;

using System.Data;
using System.Globalization;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorGestionAlmacenes : PresentadorVistaGestion<PresentadorTuplaAlmacen, IVistaGestionAlmacenes,
    IVistaTuplaAlmacen, Almacen, RepoAlmacen, FiltroBusquedaAlmacen> {
    private ControladorArchivosAndroid _androidFileManager;
    private DocInventarioAlmacen _docInventarioAlmacen;
    private bool _dispositivoConectado;

    public PresentadorGestionAlmacenes(IVistaGestionAlmacenes vista) : base(vista) {
        _androidFileManager = new ControladorArchivosAndroid(Application.StartupPath);
        _docInventarioAlmacen = new DocInventarioAlmacen();

        vista.ImportarInventarioVersat += OnImportarInventarioVersat;
        vista.ExportarDocumentoInventario += OnExportarDocumentoInventarioAlmacenes;
    }

    protected override PresentadorTuplaAlmacen ObtenerValoresTupla(Almacen entidad) {
        var presentadorTupla = new PresentadorTuplaAlmacen(new VistaTuplaAlmacen(), entidad);

        presentadorTupla.Vista.Id = entidad.Id.ToString();
        presentadorTupla.Vista.NombreAlmacen = entidad.Nombre;
        presentadorTupla.Vista.Direccion = entidad.Direccion;
        presentadorTupla.Vista.Descripcion = entidad.Descripcion;
        presentadorTupla.Vista.MostrarBotonExportarProductos = _dispositivoConectado;
        presentadorTupla.Vista.ExportarDocumentoInventario += OnExportarDocumentoInventarioAlmacen;
        presentadorTupla.Vista.DescargarProductos += OnDescargarProductos;

        return presentadorTupla;
    }

    public override void ActualizarResultadosBusqueda() {
        _dispositivoConectado = VerificarConexionDispositivo();

        base.ActualizarResultadosBusqueda();
    }

    private void OnImportarInventarioVersat(object? sender, string rutaArchivo) {
        var idAlmacen = TuplasSeleccionadas.FirstOrDefault()?.Entidad.Id ?? 0;

        if (idAlmacen != 0) {
            var resultado = ImportarDesdeExcel(rutaArchivo, idAlmacen);

            CentroNotificaciones.Mostrar($"Se ha importado el archivo correctamente. Se han actualizado {resultado.registrosProcesados} registros.");
        } else
            CentroNotificaciones.Mostrar($"Debe seleccionar un almacén de destino para la importación de datos. De click sobre un almacén de la lista y presione nuevamente el botón de importar", TipoNotificacion.Advertencia);
    }

    private void OnExportarDocumentoInventarioAlmacen(object? sender, (int id, FormatoDocumento formato) e) {
        _docInventarioAlmacen.GenerarDocumentoConParametros(e.formato, e.id);
    }

    private void OnExportarDocumentoInventarioAlmacenes(object? sender, FormatoDocumento e) {
        _docInventarioAlmacen.GenerarDocumento(true, e);
    }

    private void OnDescargarProductos(object? sender, EventArgs e) {
        var existeDirectorio = false;

        try {
            // Verificar conexión del dispositivo
            if (!VerificarConexionDispositivo()) {
                CentroNotificaciones.Mostrar("Conecte un dispositivo Android con depuración USB activada", TipoNotificacion.Advertencia);
            } else {
                existeDirectorio = _androidFileManager.EnsureDirectoryExists();

                if (!existeDirectorio) {
                    CentroNotificaciones.Mostrar("No se pudo crear el directorio en el dispositivo Android", TipoNotificacion.Error);
                    return;
                }
            }
        } catch (Exception ex) {
            MessageBox.Show(ex.Message);
        }

        var id = sender as string;

        if (string.IsNullOrEmpty(id)) {
            CentroNotificaciones.Mostrar("ID del almacén no proporcionado", TipoNotificacion.Error);
            return;
        }

        var productos = UtilesAlmacen.ObtenerProductosAlmacenJson(long.Parse(id));
        var rutaArchivoProductos = Path.Combine(Application.StartupPath, "productos_almacen.json");

        using (var fileStream = new FileStream(rutaArchivoProductos, FileMode.Create))
        using (var writer = new StreamWriter(fileStream)) {
            writer.Write(productos);
        }

        if (_androidFileManager.PushFileToDevice(rutaArchivoProductos, "productos_almacen.json")) {
            CentroNotificaciones.Mostrar($"Productos del almacén {id} descargados correctamente", TipoNotificacion.Info);
        } else {
            CentroNotificaciones.Mostrar($"Error al descargar productos del almacén {id}", TipoNotificacion.Error);
        }

        // Limpiar archivo temporal
        try { File.Delete(rutaArchivoProductos); } catch { }
    }

    public (bool exito, string mensaje, int registrosProcesados) ImportarDesdeExcel(string rutaArchivo, long idAlmacen) {
        try {
            // 1. Leer archivo Excel con ClosedXML
            var datosInventario = LeerExcel(rutaArchivo);

            if (datosInventario == null || datosInventario.Rows.Count == 0)
                return (false, "El archivo Excel no contiene datos válidos.", 0);

            // 2. Procesar datos
            try {
                int registrosProcesados = 0;

                foreach (DataRow fila in datosInventario.Rows) {
                    // Procesar cada fila del inventario
                    if (ProcesarFilaInventario(fila, idAlmacen))
                        registrosProcesados++;
                }

                return (true, $"Importación completada exitosamente. {registrosProcesados} registros procesados.", registrosProcesados);
            } catch (Exception ex) {
                return (false, $"Error durante la importación: {ex.Message}", 0);
            }
        } catch (Exception ex) {
            return (false, $"Error general: {ex.Message}", 0);
        }
    }

    private bool ProcesarFilaInventario(DataRow fila, long idAlmacen) {
        try {
            // Extraer datos de la fila
            string codigo = fila["Código"]?.ToString();
            string descripcion = fila["Descripción"]?.ToString();

            if (!decimal.TryParse(fila["cantidad"]?.ToString(), out decimal cantidad))
                cantidad = 0;

            if (!decimal.TryParse(fila["Precio"]?.ToString(), out decimal precio))
                precio = 0;

            // 1. Obtener el producto 
            var producto = RepoProducto.Instancia.Buscar(FiltroBusquedaProducto.Codigo, codigo).resultados.FirstOrDefault();
                       
            if (producto != null) {
                // Editar nombre y precio del producto o costo unitario segun categoria
                if (!string.IsNullOrEmpty(descripcion))
                    producto.Nombre = descripcion;
                if (producto.Categoria == CategoriaProducto.ProductoTerminado)
                    producto.CostoProduccionUnitario = precio;
                else producto.PrecioCompra = precio;

                RepoProducto.Instancia.Editar(producto);

                // Editar la descripción de producto
                var detalleProducto = RepoDetalleProducto.Instancia.Buscar(FiltroBusquedaDetalleProducto.Id, producto.Id.ToString()).resultados.First();

                detalleProducto.Descripcion = descripcion;

                RepoDetalleProducto.Instancia.Editar(detalleProducto);

                // Modificar datos de inventario del producto
                var inventario = RepoInventario.Instancia.Buscar(FiltroBusquedaInventario.IdProducto, producto.Id.ToString()).resultados.FirstOrDefault(i => i.IdAlmacen.Equals(idAlmacen));

                inventario.Cantidad = cantidad;
                inventario.CostoPromedio = precio;
                inventario.ValorTotal = precio * cantidad;

                return true;
            }

            return false;
        } catch (Exception ex) {
            throw new Exception($"Error al procesar fila: {ex.Message}");
        }
    }

    private DataTable LeerExcel(string rutaArchivo) {
        try {
            // Usar ClosedXML para leer el archivo Excel
            using (var workbook = new XLWorkbook(rutaArchivo)) {
                // Obtener la primera hoja de cálculo
                var worksheet = workbook.Worksheet(1);

                if (worksheet == null)
                    return null;

                DataTable dt = new DataTable();

                // Obtener el rango usado
                var range = worksheet.RangeUsed();

                // Leer encabezados (primera fila)
                foreach (var cell in range.Row(1).Cells()) {
                    string nombreColumna = cell.GetString().Trim();
                    if (!string.IsNullOrEmpty(nombreColumna))
                        dt.Columns.Add(nombreColumna);
                }

                // Leer filas de datos (omitir la primera fila que son los encabezados)
                foreach (var row in range.Rows().Skip(1)) {
                    DataRow dr = dt.NewRow();

                    for (int i = 0; i < dt.Columns.Count; i++) {
                        if (i < row.CellCount()) {
                            var cell = row.Cell(i + 1);
                            dr[i] = cell.GetString(); // GetString maneja valores nulos correctamente
                        }
                    }

                    dt.Rows.Add(dr);
                }

                return dt;
            }
        } catch (Exception ex) {
            throw new Exception($"Error al leer el archivo Excel: {ex.Message}");
        }
    }

    public bool VerificarConexionDispositivo() {
        var conexionOk = true;

        try {
            // Verificar conexión del dispositivo
            if (!_androidFileManager.CheckDeviceConnection())
                conexionOk = false;
        } catch (Exception ex) {
            CentroNotificaciones.Mostrar($"Error al verificar conexión del dispositivo: {ex.Message}", TipoNotificacion.Error);
        }

        return conexionOk;
    }
}