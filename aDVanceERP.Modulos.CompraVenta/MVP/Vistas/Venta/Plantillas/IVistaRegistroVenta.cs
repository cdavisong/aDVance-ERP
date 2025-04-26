using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas; 

public interface IVistaRegistroVenta : IVistaRegistro {
    string? RazonSocialCliente { get; set; }
    string? NombreAlmacen { get; set; }
    string? NombreArticulo { get; set; }
    List<string[]>? Articulos { get; }
    int Cantidad { get; set; }
    decimal Total { get; set; }
    long IdTipoEntrega { get; set; }
    string? Direccion { get; set; }
    bool PagoEfectuado { get; set; }
    bool MensajeriaConfigurada { get; set; }
    string? TipoEntrega { get; set; }
    string? EstadoEntrega { get; set; }

    event EventHandler? AlturaContenedorTuplasModificada;
    event EventHandler? ArticuloAgregado;
    event EventHandler? ArticuloEliminado;
    event EventHandler? EfectuarPago;
    event EventHandler? AsignarMensajeria;

    void CargarNombresAlmacenes(object[] nombresAlmacenes);
    void CargarNombresArticulos(string[] nombresArticulos);
}