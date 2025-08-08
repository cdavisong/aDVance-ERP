using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

public interface IVistaRegistroAlmacen : IVistaRegistroEdicion {
    string Nombre { get; set; }
    string Direccion { get; set; }
    bool AutorizoVenta { get; set; }
    string Notas { get; set; }
}