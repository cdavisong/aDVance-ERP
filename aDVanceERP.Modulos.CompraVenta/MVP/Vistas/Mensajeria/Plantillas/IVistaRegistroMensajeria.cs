using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Mensajeria.Plantillas; 

public interface IVistaRegistroMensajeria : IVistaRegistro {
    string? NombreMensajero { get; set; }
    string? TipoEntrega { get; set; }
    string DescripcionTipoEntrega { get; set; }
    string Direccion { get; set; }
    string ResumenEntrega { get; set; }
    List<string[]> DatosMensajeria { get; }

    void CargarNombresMensajeros(object[] nombresMensajeros);
    void CargarTiposEntrega(object[] tiposEntrega, string[] descripciones);
    void PopularDatosCliente(string[]? datosCliente);
    void PopularArticulosVenta(List<string[]>? datosArticulos);
}