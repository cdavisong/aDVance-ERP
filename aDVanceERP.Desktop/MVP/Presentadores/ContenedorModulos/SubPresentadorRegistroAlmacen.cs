using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroAlmacen? _registroAlmacen;

    private void InicializarVistaRegistroAlmacen() {
        _registroAlmacen = new PresentadorRegistroAlmacen(new VistaRegistroAlmacen());
        _registroAlmacen.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
        _registroAlmacen.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroAlmacen.DatosRegistradosActualizados += delegate {
            if (_gestionAlmacenes == null)
                return;

            _gestionAlmacenes.ActualizarResultadosBusqueda();
        };

        Vista.Vistas?.Registrar("vistaRegistroAlmacen", 
            _registroAlmacen.Vista, 
            new Point(Vista.Dimensiones.Width - _registroAlmacen.Vista.Dimensiones.Width - 40, -10),
            _registroAlmacen.Vista.Dimensiones,
            "V");

        // Estado de habilitacion de la vista gestionable.
        //TODO: Implementar esto para todas las vistas de registro.
        var formRegistro = _registroAlmacen?.Vista as Form;

        if (formRegistro != null && _gestionAlmacenes != null)
            formRegistro.VisibleChanged += delegate {
                _gestionAlmacenes.Vista.Habilitada = !formRegistro.Visible;
            };
    }

    private void MostrarVistaRegistroAlmacen(object? sender, EventArgs e) {
        if (_registroAlmacen == null)
            return;

        _registroAlmacen.Vista.Restaurar();
        _registroAlmacen.Vista.Mostrar();
    }

    private void MostrarVistaEdicionAlmacen(object? sender, EventArgs e) {
        if (sender is Almacen almacen) {
            if (_registroAlmacen != null) {
                _registroAlmacen.PopularVistaDesdeObjeto(almacen);
                _registroAlmacen.Vista.Mostrar();
            }
        }
    }
}