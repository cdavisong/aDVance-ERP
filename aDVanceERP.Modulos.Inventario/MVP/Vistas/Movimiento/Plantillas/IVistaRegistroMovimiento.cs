using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas; 

public interface IVistaRegistroMovimiento : IVistaRegistro {
    string NombreProducto { get; set; }
    string? NombreAlmacenOrigen { get; set; }
    string? NombreAlmacenDestino { get; set; }
    DateTime Fecha { get; set; }
    float CantidadMovida { get; set; }
    string TipoMovimiento { get; set; }


    event EventHandler? RegistrarTipoMovimiento;
    event EventHandler? EliminarTipoMovimiento;

    void CargarNombresProductos(string[] nombresProductos);
    void CargarNombresAlmacenes(object[] nombresAlmacenes);
    void CargarTiposMovimientos(object[] tiposMovimientos);
    void ActualizarCamposAlmacenes();
}