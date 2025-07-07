using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Presentadores.CostosProduccion;
using aDVanceERP.Modulos.Taller.Vistas.CostosProduccion;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorGestionCostosProduccion? _gestionCostosProduccion;

    private async void InicializarVistaGestionCostosProduccion() {
        _gestionCostosProduccion = new PresentadorGestionCostosProduccion(new VistaGestionCostosProduccion());
        _gestionCostosProduccion.EditarObjeto += MostrarVistaEdicionCostoProduccion;
        _gestionCostosProduccion.Vista.RegistrarDatos += MostrarVistaRegistroCostoProduccion;

        if (Vista.Vistas != null)
            await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionCostosProduccion", _gestionCostosProduccion.Vista));
    }

    private async void MostrarVistaGestionCostosProduccion(object? sender, EventArgs e) {
        if (_gestionCostosProduccion?.Vista == null)
            return;

        _gestionCostosProduccion.Vista.CargarCriteriosBusqueda(UtilesBusquedaCostoProduccion.CriterioBusqueda);
        _gestionCostosProduccion.Vista.Restaurar();
        _gestionCostosProduccion.Vista.Mostrar();

        await _gestionCostosProduccion.RefrescarListaObjetos();
    }
}