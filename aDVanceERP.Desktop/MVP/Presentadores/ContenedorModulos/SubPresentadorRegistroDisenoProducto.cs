using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.DisenoProducto;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroDisenoProducto? _registroDisenoProducto;

    private Task InicializarVistaRegistroDisenoProducto() {
        _registroDisenoProducto = new PresentadorRegistroDisenoProducto(new VistaRegistroDisenoProducto());
        _registroDisenoProducto.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
        _registroDisenoProducto.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroDisenoProducto.DatosRegistradosActualizados += delegate {
            _registroProducto?.Vista.CargarDisenosProducto(UtilesDisenoProducto.ObtenerNombresDisenosProductos());
        };

        return Task.CompletedTask;
    }

    private async void MostrarVistaRegistroDisenoProducto(object? sender, EventArgs e) {
        await InicializarVistaRegistroDisenoProducto();

        _registroDisenoProducto?.Vista.Mostrar();
        _registroDisenoProducto?.Dispose();
    }

    private async void EliminarDisenoProducto(object? sender, EventArgs e) {
        using (var disenoProducto = new DatosDisenoProducto()) {
            if (sender is string nombreDisenoProducto) {
                var idDisenoProducto = await UtilesDisenoProducto.ObtenerIdDisenoProducto(nombreDisenoProducto);

                if (idDisenoProducto == 0)
                    return;

                await disenoProducto.EliminarAsync(idDisenoProducto);
            }

            _registroProducto?.Vista.CargarDisenosProducto(UtilesDisenoProducto.ObtenerNombresDisenosProductos());
        }
    }
}