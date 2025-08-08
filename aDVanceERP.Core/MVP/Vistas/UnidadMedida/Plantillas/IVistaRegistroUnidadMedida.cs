using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.MVP.Vistas.UnidadMedida.Plantillas
{
    public interface IVistaRegistroUnidadMedida : IVistaRegistroEdicion {
        string Nombre { get; set; }
        string Abreviatura { get; set; }
        string? Descripcion { get; set; }
    }
}
