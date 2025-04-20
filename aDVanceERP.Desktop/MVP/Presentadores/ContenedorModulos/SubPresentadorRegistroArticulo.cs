using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroArticulo? _registroArticulo;

    private void InicializarVistaRegistroArticulo() {
        _registroArticulo = new PresentadorRegistroArticulo(new VistaRegistroArticulo());
        _registroArticulo.Vista.CargarRazonesSocialesProveedores(UtilesProveedor.ObtenerRazonesSocialesProveedores());
        _registroArticulo.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
        _registroArticulo.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroArticulo.Salir += async delegate {
            await _gestionArticulos?.RefrescarListaObjetos()!;
        };
    }

    private void MostrarVistaRegistroArticulo(object? sender, EventArgs e) {
        InicializarVistaRegistroArticulo();

        if (_registroArticulo == null) 
            return;

        MostrarVistaPanelTransparente(_registroArticulo.Vista);

        _registroArticulo.Vista.Mostrar();
        _registroArticulo.Dispose();
    }

    private void MostrarVistaEdicionArticulo(object? sender, EventArgs e) {
        InicializarVistaRegistroArticulo();

        if (sender is Articulo articulo) {
            if (_registroArticulo != null) {
                MostrarVistaPanelTransparente(_registroArticulo.Vista);

                _registroArticulo.PopularVistaDesdeObjeto(articulo);
                _registroArticulo.Vista.Mostrar();
            }
        }

        _registroArticulo?.Dispose();
    }
}