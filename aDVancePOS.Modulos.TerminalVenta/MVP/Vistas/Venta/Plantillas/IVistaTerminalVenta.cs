using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta.Plantillas;

public interface IVistaTerminalVenta : IVistaRegistro {
    string? NombreAlmacen { get; set; }
    string? NombreArticulo { get; set; }
    List<string[]>? Articulos { get; }
    int Cantidad { get; set; }
    decimal Subtotal { get; set; }
    decimal Descuento { get; set; }
    decimal Total { get; set; }
    long IdTipoEntrega { get; set; }

    event EventHandler? ArticuloAgregado;
    event EventHandler? ArticuloEliminado;
    event EventHandler? EfectuarPago;
    event EventHandler? AsignarMensajeria;

    void CargarNombresAlmacenes(object[] nombresAlmacenes);
    void CargarNombresArticulos(string[] nombresArticulos);
}