using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoProducto;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroTipoProducto? _registroTipoProducto;

    private Task InicializarVistaRegistroTipoProducto() {
        _registroTipoProducto = new PresentadorRegistroTipoProducto(new VistaRegistroTipoProducto());
        _registroTipoProducto.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
        _registroTipoProducto.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroTipoProducto.DatosRegistradosActualizados += delegate {
            _registroProducto?.Vista.CargarTiposProductos(UtilesTipoProducto.ObtenerNombresTiposProductos());
        };

        return Task.CompletedTask;
    }

    private async void MostrarVistaRegistroTipoProducto(object? sender, EventArgs e) {
        await InicializarVistaRegistroTipoProducto();

        _registroTipoProducto?.Vista.Mostrar();
        _registroTipoProducto?.Dispose();
    }

    private async void EliminarTipoProducto(object? sender, EventArgs e) {
        using (var tipoProducto = new DatosTipoProducto()) {
            if (sender is string nombreTipoProducto) {
                var idTipoProducto = await UtilesTipoProducto.ObtenerIdTipoProducto(nombreTipoProducto);

                if (idTipoProducto == 0)
                    return;

                await tipoProducto.EliminarAsync(idTipoProducto);
            }

            _registroProducto?.Vista.CargarTiposProductos(UtilesTipoProducto.ObtenerNombresTiposProductos());
        }
    }
}