using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorGestionProductos? _gestionProductos;

    private async void InicializarVistaGestionProductos() {
        _gestionProductos = new PresentadorGestionProductos(new VistaGestionProductos());
        _gestionProductos.MovimientoPositivoStock += MostrarVistaRegistroMovimiento;
        _gestionProductos.MovimientoNegativoStock += MostrarVistaRegistroMovimiento;
        _gestionProductos.EditarEntidad += MostrarVistaEdicionProducto;
        _gestionProductos.Vista.RegistrarDatos += MostrarVistaRegistroProducto;

        if (Vista.Vistas != null)
            await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionProductos", _gestionProductos.Vista));
    }

    private async void MostrarVistaGestionProductos(object? sender, EventArgs e) {
        if (_gestionProductos?.Vista == null)
            return;

        _gestionProductos.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes());
        _gestionProductos.Vista.CargarCriteriosBusqueda(UtilesBusquedaProducto.FbProducto);
        _gestionProductos.Vista.Restaurar();
        _gestionProductos.Vista.Mostrar();

        await _gestionProductos.PopularTuplasDatosEntidades()!;
    }
}