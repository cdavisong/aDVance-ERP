using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMovimiento.Plantillas; 

public interface IVistaRegistroTipoMovimiento : IVistaRegistro {
    string Nombre { get; set; }
    string Efecto { get; set; }
}