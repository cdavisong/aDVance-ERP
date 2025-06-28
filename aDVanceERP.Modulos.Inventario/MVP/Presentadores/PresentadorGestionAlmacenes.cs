using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Modelos;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;
using aDVanceERP.Modulos.Inventario.Repositorios;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores; 

public class PresentadorGestionAlmacenes : PresentadorGestionBase<PresentadorTuplaAlmacen, IVistaGestionAlmacenes,
    IVistaTuplaAlmacen, Almacen, DatosAlmacen, CriterioBusquedaAlmacen> {
    private ControladorArchivosAndroid _androidFileManager;

    public PresentadorGestionAlmacenes(IVistaGestionAlmacenes vista) : base(vista) {
        _androidFileManager = new ControladorArchivosAndroid(Application.StartupPath);
    }

    protected override PresentadorTuplaAlmacen ObtenerValoresTupla(Almacen objeto) {
        var presentadorTupla = new PresentadorTuplaAlmacen(new VistaTuplaAlmacen(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.Nombre = objeto.Nombre;
        presentadorTupla.Vista.Direccion = objeto.Direccion;
        presentadorTupla.Vista.Notas = objeto.Notas;
        presentadorTupla.Vista.MostrarBotonExportarProductos = Vista.DispositivoConectado;
        presentadorTupla.Vista.DescargarProductos += OnDescargarProductos;

        return presentadorTupla;
    }

    private void OnDescargarProductos(object? sender, EventArgs e) {
        var existeDirectorio = false;

        try {
            // Verificar conexión del dispositivo
            if (!_androidFileManager.CheckDeviceConnection()) {
                CentroNotificaciones.Mostrar("Conecte un dispositivo Android con depuración USB activada", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);                
            } else {
                existeDirectorio = _androidFileManager.EnsureDirectoryExists();

                if (!existeDirectorio) {
                    CentroNotificaciones.Mostrar("No se pudo crear el directorio en el dispositivo Android", Core.Mensajes.MVP.Modelos.TipoNotificacion.Error);
                    return;
                }
            }
        } catch (Exception ex) {
            MessageBox.Show(ex.Message);
        }

        var id = sender as string;

        if (string.IsNullOrEmpty(id)) {
            CentroNotificaciones.Mostrar("ID del almacén no proporcionado", Core.Mensajes.MVP.Modelos.TipoNotificacion.Error);
            return;
        }

        var productos = UtilesAlmacen.ObtenerProductosAlmacenJson(long.Parse(id));
        var rutaArchivoProductos = Path.Combine(Application.StartupPath, "productos_almacen.json");

        using (var fileStream = new FileStream(rutaArchivoProductos, FileMode.Create))
            using (var writer = new StreamWriter(fileStream)) {
                writer.Write(productos);
            }
        
        if(_androidFileManager.PushFileToDevice(rutaArchivoProductos, "productos_almacen.json")) {
            CentroNotificaciones.Mostrar($"Productos del almacén {id} descargados correctamente", Core.Mensajes.MVP.Modelos.TipoNotificacion.Info);
        } else {
            CentroNotificaciones.Mostrar($"Error al descargar productos del almacén {id}", Core.Mensajes.MVP.Modelos.TipoNotificacion.Error);
        }

        // Limpiar archivo temporal
        try { File.Delete(rutaArchivoProductos); } catch { }
    }
}