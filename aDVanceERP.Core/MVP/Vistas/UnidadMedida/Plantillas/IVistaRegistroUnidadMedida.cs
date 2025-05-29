using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Vistas.UnidadMedida.Plantillas {
    public interface IVistaRegistroUnidadMedida : IVistaRegistro {
        string Nombre { get; set; }
        string Abreviatura { get; set; }
        string? Descripcion { get; set; }
    }
}
