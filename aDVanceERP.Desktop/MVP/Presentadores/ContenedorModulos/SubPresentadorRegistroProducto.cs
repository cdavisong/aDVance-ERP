using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroProducto? _registroProducto;

    private void InicializarVistaRegistroProducto() {
        _registroProducto = new PresentadorRegistroProducto(new VistaRegistroProducto());
        _registroProducto.Vista.CargarRazonesSocialesProveedores(UtilesProveedor.ObtenerRazonesSocialesProveedores());
        _registroProducto.Vista.CargarDescripcionesUnidadesMedida(UtilesUnidadMedida.ObtenerDescripcionesUnidadesMedida());
        _registroProducto.Vista.CargarUnidadesMedida(UtilesUnidadMedida.ObtenerNombresUnidadesMedida());
        _registroProducto.Vista.CargarColores(UtilesColorProducto.ObtenerNombresColoresProductos());
        _registroProducto.Vista.CargarTiposProductos(UtilesTipoProducto.ObtenerNombresTiposProductos());
        _registroProducto.Vista.CargarDisenosProducto(UtilesDisenoProducto.ObtenerNombresDisenosProductos());
        _registroProducto.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes());
        _registroProducto.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
        _registroProducto.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroProducto.Vista.RegistrarUnidadMedida += MostrarVistaRegistroUnidadMedida;
        _registroProducto.Vista.RegistrarTipoProducto += MostrarVistaRegistroTipoProducto;
        _registroProducto.Vista.RegistrarDisenoProducto += MostrarVistaRegistroDisenoProducto;
        _registroProducto.Vista.EliminarUnidadMedida += EliminarUnidadMedida;
        _registroProducto.Vista.EliminarTipoProducto += EliminarTipoProducto;
        _registroProducto.Vista.EliminarDisenoProducto += EliminarDisenoProducto;
        _registroProducto.DatosRegistradosActualizados += async delegate {
            if (_gestionProductos == null)
                return;

            await _gestionProductos?.RefrescarListaObjetos()!;
        };
    }

    private void MostrarVistaRegistroProducto(object? sender, EventArgs e) {
        InicializarVistaRegistroProducto();

        if (_registroProducto == null) 
            return;

        MostrarVistaPanelTransparente(_registroProducto.Vista);

        _registroProducto.Vista.Mostrar();
        _registroProducto.Dispose();
    }

    private void MostrarVistaEdicionProducto(object? sender, EventArgs e) {
        InicializarVistaRegistroProducto();

        if (sender is Producto producto) {
            if (_registroProducto != null) {
                MostrarVistaPanelTransparente(_registroProducto.Vista);

                _registroProducto.PopularVistaDesdeObjeto(producto);
                _registroProducto.Vista.Mostrar();
            }
        }

        _registroProducto?.Dispose();
    }
}