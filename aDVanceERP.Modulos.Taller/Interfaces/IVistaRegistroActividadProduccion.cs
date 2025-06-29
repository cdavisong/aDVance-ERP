using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Taller.Interfaces {
    public interface IVistaRegistroActividadProduccion : IVistaRegistro {
        string Nombre { get; set; }
        string Descripcion { get; set; }
        decimal Costo { get; set; }
    }
}