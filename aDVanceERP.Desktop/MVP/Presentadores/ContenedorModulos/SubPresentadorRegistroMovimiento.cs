using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroMovimiento? _registroMovimiento;

    private string? Signo { get; set; }

    private async Task InicializarVistaRegistroMovimiento() {
        _registroMovimiento = new PresentadorRegistroMovimiento(new VistaRegistroMovimiento());
        _registroMovimiento.Vista.CargarNombresArticulos(await UtilesArticulo.ObtenerNombresArticulos());
        _registroMovimiento.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes());
        _registroMovimiento.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
        _registroMovimiento.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroMovimiento.Vista.RegistrarTipoMovimiento += MostrarVistaRegistroTipoMovimiento;
        _registroMovimiento.Vista.EliminarTipoMovimiento += EliminarTipoMovimiento;
        _registroMovimiento.Salir += async delegate { await _gestionMovimientos.RefrescarListaObjetos(); };
    }

    private async Task InicializarVistaRegistroMovimiento(string? signo, string? nombreAlmacen) {
        await InicializarVistaRegistroMovimiento();

        Signo = signo ?? string.Empty;

        if (_registroMovimiento != null) {
            if (string.IsNullOrEmpty(signo)) {
                _registroMovimiento.Vista.CargarTiposMovimientos(UtilesMovimiento.ObtenerNombresTiposMovimientos());
            }
            else {
                _registroMovimiento.Vista.CargarTiposMovimientos(
                    UtilesMovimiento.ObtenerNombresTiposMovimientos(signo));

                if (nombreAlmacen != null && !nombreAlmacen.Equals("-")) {
                    _registroMovimiento.Vista.NombreAlmacenOrigen = signo.Equals("-") ? nombreAlmacen : "Ninguno";
                    _registroMovimiento.Vista.NombreAlmacenDestino = signo.Equals("+") ? nombreAlmacen : "Ninguno";
                }
            }
        }
    }

    private async Task InicializarVistaRegistroMovimiento(string? signo, string? nombreAlmacen, Articulo? objeto) {
        await InicializarVistaRegistroMovimiento(signo, nombreAlmacen);

        Signo = signo ?? string.Empty;

        if (_registroMovimiento != null) _registroMovimiento.Vista.NombreArticulo = objeto?.Nombre ?? string.Empty;
    }

    private async void MostrarVistaRegistroMovimiento(object? sender, EventArgs e) {
        if (sender is object[] datosAlmacenArticulo)
            await InicializarVistaRegistroMovimiento(datosAlmacenArticulo[0].ToString(),
                datosAlmacenArticulo[1].ToString(), datosAlmacenArticulo[2] as Articulo);
        else
            await InicializarVistaRegistroMovimiento(string.Empty, string.Empty);

        if (_registroMovimiento == null) 
            return;

        MostrarVistaPanelTransparente(_registroMovimiento.Vista);

        _registroMovimiento.Vista.Mostrar();
        _registroMovimiento.Dispose();
    }

    private async void MostrarVistaEdicionMovimiento(object? sender, EventArgs e) {
        await InicializarVistaRegistroMovimiento(string.Empty, string.Empty);

        if (sender is Movimiento movimiento) {
            if (_registroMovimiento != null) {
                MostrarVistaPanelTransparente(_registroMovimiento.Vista);

                _registroMovimiento.PopularVistaDesdeObjeto(movimiento);
                _registroMovimiento.Vista.Mostrar();
            }
        }

        _registroMovimiento?.Dispose();
    }
}