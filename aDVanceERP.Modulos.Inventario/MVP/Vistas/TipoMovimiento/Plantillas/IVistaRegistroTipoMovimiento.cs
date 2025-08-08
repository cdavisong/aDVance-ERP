using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMovimiento.Plantillas;

public interface IVistaRegistroTipoMovimiento : IVistaRegistroEdicion {
    string Nombre { get; set; }
    string Efecto { get; set; }
}