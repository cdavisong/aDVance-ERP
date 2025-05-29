using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoProducto.Plantillas;

public interface IVistaRegistroTipoProducto : IVistaRegistro {
    string Nombre { get; set; }
    string? Descripcion { get; set; }
}