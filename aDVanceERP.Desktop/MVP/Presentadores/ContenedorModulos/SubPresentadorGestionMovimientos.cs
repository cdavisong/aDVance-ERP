using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorGestionMovimientos? _gestionMovimientos;

    private async void InicializarVistaGestionMovimientos() {
        _gestionMovimientos = new PresentadorGestionMovimientos(new VistaGestionMovimientos());
        _gestionMovimientos.EditarObjeto += MostrarVistaEdicionMovimiento;
        _gestionMovimientos.Vista.RegistrarDatos += MostrarVistaRegistroMovimiento;

        if (Vista.Vistas != null)
            await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionMovimientos", _gestionMovimientos.Vista));
    }

    private async void MostrarVistaGestionMovimientos(object? sender, EventArgs e) {
        if (_gestionMovimientos?.Vista == null)
            return;

        _gestionMovimientos.Vista.CargarCriteriosBusqueda(UtilesBusquedaMovimiento.CriterioBusquedaMovimiento);
        _gestionMovimientos.Vista.Restaurar();
        _gestionMovimientos.Vista.Mostrar();

        await _gestionMovimientos.RefrescarListaObjetos();
    }
}