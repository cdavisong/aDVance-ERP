using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMateriaPrima.Plantillas;

public interface IVistaRegistroTipoMateriaPrima : IVistaRegistroEdicion {
    string Nombre { get; set; }
    string? Descripcion { get; set; }
}