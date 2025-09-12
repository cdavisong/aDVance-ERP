using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMateriaPrima.Plantillas;

public interface IVistaRegistroTipoMateriaPrima : IVistaRegistro {
    string Nombre { get; set; }
    string? Descripcion { get; set; }
}