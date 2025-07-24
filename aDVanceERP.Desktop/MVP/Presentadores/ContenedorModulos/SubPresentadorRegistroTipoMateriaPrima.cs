using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Inventario.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMateriaPrima;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroTipoMateriaPrima? _registroTipoMateriaPrima;

    private Task InicializarVistaRegistroTipoMateriaPrima() {
        _registroTipoMateriaPrima = new PresentadorRegistroTipoMateriaPrima(new VistaRegistroTipoMateriaPrima());
        _registroTipoMateriaPrima.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
        _registroTipoMateriaPrima.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroTipoMateriaPrima.DatosRegistradosActualizados += delegate {
            _registroProducto?.Vista.CargarTiposMateriaPrima(UtilesTipoMateriaPrima.ObtenerNombresTiposMateriasPrimas());
        };

        return Task.CompletedTask;
    }

    private async void MostrarVistaRegistroTipoMateriaPrima(object? sender, EventArgs e) {
        await InicializarVistaRegistroTipoMateriaPrima();

        _registroTipoMateriaPrima?.Vista.Mostrar();
        _registroTipoMateriaPrima?.Dispose();
    }

    private async void EliminarTipoMateriaPrima(object? sender, EventArgs e) {
        using (var tipoProducto = new DatosTipoMateriaPrima()) {
            if (sender is string nombreTipoMateriaPrima) {
                var idTipoMateriaPrima = await UtilesTipoMateriaPrima.ObtenerIdTipoMateriaPrima(nombreTipoMateriaPrima);

                if (idTipoMateriaPrima == 0)
                    return;

                await tipoProducto.EliminarAsync(idTipoMateriaPrima);
            }

            _registroProducto?.Vista.CargarTiposMateriaPrima(UtilesTipoMateriaPrima.ObtenerNombresTiposMateriasPrimas());
        }
    }
}
