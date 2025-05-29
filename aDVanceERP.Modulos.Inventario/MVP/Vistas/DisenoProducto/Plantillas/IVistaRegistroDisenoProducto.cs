using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.DisenoProducto.Plantillas;

public interface IVistaRegistroDisenoProducto : IVistaRegistro {
    string Nombre { get; set; }
    string? Descripcion { get; set; }
}