using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.MVP.Vistas.UnidadMedida;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroUnidadMedida? _registroUnidadMedida;

    private Task InicializarVistaRegistroUnidadMedida() {
        _registroUnidadMedida = new PresentadorRegistroUnidadMedida(new VistaRegistroUnidadMedida());
        _registroUnidadMedida.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
        _registroUnidadMedida.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroUnidadMedida.DatosRegistradosActualizados += delegate {
            _registroProducto?.Vista.CargarUnidadesMedida(UtilesUnidadMedida.ObtenerNombresUnidadesMedida());
        };

        return Task.CompletedTask;
    }

    private async void MostrarVistaRegistroUnidadMedida(object? sender, EventArgs e) {
        await InicializarVistaRegistroUnidadMedida();

        _registroUnidadMedida?.Vista.Mostrar();
        _registroUnidadMedida?.Dispose();
    }

    private async void EliminarUnidadMedida(object? sender, EventArgs e) {
        using (var unidadMedida = new DatosUnidadMedida()) {
            if (sender is string nombreUnidadMedida) {
                var idUnidadMedida = await UtilesUnidadMedida.ObtenerIdUnidadMedida(nombreUnidadMedida);

                if (idUnidadMedida == 0)
                    return;

                await unidadMedida.EliminarAsync(idUnidadMedida);
            }

            _registroProducto?.Vista.CargarUnidadesMedida(UtilesUnidadMedida.ObtenerNombresUnidadesMedida());
        }
    }
}