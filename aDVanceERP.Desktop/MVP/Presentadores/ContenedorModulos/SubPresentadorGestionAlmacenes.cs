using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorGestionAlmacenes? _gestionAlmacenes;

    private void InicializarVistaGestionAlmacenes() {
        _gestionAlmacenes = new PresentadorGestionAlmacenes(new VistaGestionAlmacenes());
        _gestionAlmacenes.EditarObjeto += MostrarVistaEdicionAlmacen;
        _gestionAlmacenes.Vista.RegistrarDatos += MostrarVistaRegistroAlmacen;

        Vista.Vistas?.Registrar("vistaGestionAlmacenes", _gestionAlmacenes.Vista);
    }

    private void MostrarVistaGestionAlmacenes(object? sender, EventArgs e) {
        if (_gestionAlmacenes?.Vista == null)
            return;
                
        _gestionAlmacenes.Vista.Restaurar();
        _gestionAlmacenes.Vista.Mostrar();
        _gestionAlmacenes.Vista.CargarFiltrosBusqueda(UtilesBusquedaAlmacen.FiltroBusquedaAlmacen);
    }
}