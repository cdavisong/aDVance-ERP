using aDVanceERP.Core.Documentos.Interfaces;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Modelos;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.Documentos.Almacen;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;
using aDVanceERP.Modulos.Inventario.Repositorios;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorGestionAlmacenes : PresentadorGestionBase<PresentadorTuplaAlmacen, IVistaGestionAlmacenes,
    IVistaTuplaAlmacen, Almacen, RepoAlmacen, FiltroBusquedaAlmacen> {
    private ControladorArchivosAndroid _androidFileManager;
    private DocInventarioAlmacen _docInventarioAlmacen;
    private bool _dispositivoConectado;

    public PresentadorGestionAlmacenes(IVistaGestionAlmacenes vista) : base(vista) {
        _androidFileManager = new ControladorArchivosAndroid(Application.StartupPath);
        _docInventarioAlmacen = new DocInventarioAlmacen();
    }

    protected override PresentadorTuplaAlmacen ObtenerValoresTupla(Almacen objeto) {
        var presentadorTupla = new PresentadorTuplaAlmacen(new VistaTuplaAlmacen(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.Nombre = objeto.Nombre;
        presentadorTupla.Vista.Direccion = objeto.Direccion;
        presentadorTupla.Vista.Notas = objeto.Notas;
        presentadorTupla.Vista.MostrarBotonExportarProductos = _dispositivoConectado;
        presentadorTupla.Vista.ExportarDocumentoInventario += OnExportarDocumento;
        presentadorTupla.Vista.DescargarProductos += OnDescargarProductos;

        return presentadorTupla;
    }

    public override void ActualizarResultadosBusqueda() {
        _dispositivoConectado = VerificarConexionDispositivo();

        base.ActualizarResultadosBusqueda();
    }

    private void OnExportarDocumento(object? sender, (int id, FormatoDocumento formato) e) {
        _docInventarioAlmacen.GenerarDocumentoConParametros(e.formato, e.id);
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
        
        if(_androidFileManager.PushFileToDevice(rutaArchivoProductos, "productos_almacen.json")) {
            CentroNotificaciones.Mostrar($"Productos del almacén {id} descargados correctamente", TipoNotificacion.Info);
        } else {
            CentroNotificaciones.Mostrar($"Error al descargar productos del almacén {id}", TipoNotificacion.Error);
        }

        // Limpiar archivo temporal
        try { File.Delete(rutaArchivoProductos); } catch { }
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