using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorGestionAlmacenes? _gestionAlmacenes;

    private void InicializarVistaGestionAlmacenes() {
        _gestionAlmacenes = new PresentadorGestionAlmacenes(new VistaGestionAlmacenes());
        _gestionAlmacenes.EditarEntidad += MostrarVistaEdicionAlmacen;
        _gestionAlmacenes.Vista.RegistrarDatos += MostrarVistaRegistroAlmacen;

        Vista.Vistas?.Registrar("vistaGestionAlmacenes", _gestionAlmacenes.Vista);
    }

    private void MostrarVistaGestionAlmacenes(object? sender, EventArgs e) {
        if (_gestionAlmacenes?.Vista == null)
            return;

        _gestionAlmacenes.Vista.CargarCriteriosBusqueda(UtilesBusquedaAlmacen.FbAlmacen);
        _gestionAlmacenes.Vista.Restaurar();
        _gestionAlmacenes.Vista.Mostrar();
    }
}