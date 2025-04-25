using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Mensajeria.Plantillas;

public interface IVistaRegistroMensajeria : IVistaRegistro {
    long IdVenta { get; set; }
    string? NombreCliente { get; }
    string? TelefonosCliente { get; }
    string? NombreMensajero { get; set; }
    string? TipoEntrega { get; set; }
    string DescripcionTipoEntrega { get; set; }
    string? Direccion { get; set; }
    string? Observaciones { get; set; }
    string ResumenEntrega { get; set; }

    void CargarNombresMensajeros(object[] nombresMensajeros);
    void CargarTiposEntrega();
    void PopularDatosCliente(string? nombreCliente);
    void PopularArticulosVenta(List<string[]>? datosArticulos);
}