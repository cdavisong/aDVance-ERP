using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;
using aDVanceERP.Modulos.Inventario.Repositorios;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores; 

public class PresentadorGestionAlmacenes : PresentadorGestionBase<PresentadorTuplaAlmacen, IVistaGestionAlmacenes,
    IVistaTuplaAlmacen, Almacen, RepoAlmacen, FbAlmacen> {
    public PresentadorGestionAlmacenes(IVistaGestionAlmacenes vista) : base(vista) { }

    protected override PresentadorTuplaAlmacen ObtenerValoresTupla(Almacen objeto) {
        var presentadorTupla = new PresentadorTuplaAlmacen(new VistaTuplaAlmacen(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.Nombre = objeto.Nombre;
        presentadorTupla.Vista.Direccion = objeto.Direccion;
        presentadorTupla.Vista.Notas = objeto.Notas;
        presentadorTupla.Vista.DescargarProductos += OnDescargarProductos;

        return presentadorTupla;
    }

    private void OnDescargarProductos(object? sender, EventArgs e) {
        var id = sender as string;
        var success = UtilesAlmacen.ExportarProductosAlmacenToJsonFileAsync(long.Parse(id), $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\productos_almacen_{id}.json");

        if (success)
            CentroNotificaciones.Mostrar("Se ha exportado un archivo codificado hacia el escritorio con la lista de productos del almacén seleccionado satisfactoriamente");
    }
}