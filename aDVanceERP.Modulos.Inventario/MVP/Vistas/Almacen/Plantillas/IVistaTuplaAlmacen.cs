using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas; 

public interface IVistaTuplaAlmacen : IVistaTupla {
    string Id { get; set; }
    string Nombre { get; set; }
    string Direccion { get; set; }
    string Notas { get; set; }
    bool MostrarBotonExportarProductos { get; set; }

    event EventHandler? DescargarProductos;
}