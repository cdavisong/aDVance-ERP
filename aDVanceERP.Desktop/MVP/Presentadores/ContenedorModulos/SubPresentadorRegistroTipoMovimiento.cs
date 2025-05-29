using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMovimiento;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroTipoMovimiento? _registroTipoMovimiento;

    private Task InicializarVistaRegistroTipoMovimiento() {
        _registroTipoMovimiento = new PresentadorRegistroTipoMovimiento(new VistaRegistroTipoMovimiento());
        _registroTipoMovimiento.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
        _registroTipoMovimiento.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroTipoMovimiento.DatosRegistradosActualizados += delegate {
            _registroMovimiento?.Vista.CargarTiposMovimientos(UtilesMovimiento.ObtenerNombresTiposMovimientos());
        };

        return Task.CompletedTask;
    }

    private async void MostrarVistaRegistroTipoMovimiento(object? sender, EventArgs e) {
        await InicializarVistaRegistroTipoMovimiento();

        _registroTipoMovimiento?.Vista.Mostrar();
        _registroTipoMovimiento?.Dispose();
    }

    private async void EliminarTipoMovimiento(object? sender, EventArgs e) {
        using (var tipoMovimiento = new DatosTipoMovimiento()) {
            if (sender is string nombreTipoMovimiento) {
                var idTipoMovimiento = UtilesMovimiento.ObtenerIdTipoMovimiento(nombreTipoMovimiento);

                if (idTipoMovimiento == 0)
                    return;

                await tipoMovimiento.EliminarAsync(idTipoMovimiento);
            }

            _registroMovimiento?.Vista.CargarTiposMovimientos(UtilesMovimiento.ObtenerNombresTiposMovimientos(Signo));
        }
    }
}