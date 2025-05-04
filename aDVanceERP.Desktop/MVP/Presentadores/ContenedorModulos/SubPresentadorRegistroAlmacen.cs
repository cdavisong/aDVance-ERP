using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroAlmacen? _registroAlmacen;

    private void InicializarVistaRegistroAlmacen() {
        _registroAlmacen = new PresentadorRegistroAlmacen(new VistaRegistroAlmacen());
        _registroAlmacen.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
        _registroAlmacen.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroAlmacen.DatosRegistradosActualizados += async delegate {
            if (_gestionAlmacenes == null)
                return;

            await _gestionAlmacenes.RefrescarListaObjetos();
        };
    }

    private void MostrarVistaRegistroAlmacen(object? sender, EventArgs e) {
        InicializarVistaRegistroAlmacen();

        if (_registroAlmacen == null) 
            return;

        MostrarVistaPanelTransparente(_registroAlmacen.Vista);

        _registroAlmacen.Vista.Mostrar();
        _registroAlmacen.Dispose();
    }

    private void MostrarVistaEdicionAlmacen(object? sender, EventArgs e) {
        InicializarVistaRegistroAlmacen();

        if (sender is Almacen almacen) {
            if (_registroAlmacen != null) {
                MostrarVistaPanelTransparente(_registroAlmacen.Vista);

                _registroAlmacen.PopularVistaDesdeObjeto(almacen);
                _registroAlmacen.Vista.Mostrar();
            }
        }

        _registroAlmacen?.Dispose();
    }
}