using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

public interface IVistaRegistroAlmacen : IVistaRegistro {
    string Nombre { get; set; }
    string Direccion { get; set; }
    bool AutorizoVenta { get; set; }
    string Descripcion { get; set; }
}