using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas {
    public interface IVistaTuplaAlmacen : IVistaTupla {
        string Id { get; set; }
        string Nombre { get; set; }
        string Direccion { get; set; }
        string Notas { get; set; }
    }

}
