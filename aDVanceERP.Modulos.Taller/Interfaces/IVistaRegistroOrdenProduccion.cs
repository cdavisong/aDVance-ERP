using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Taller.Interfaces {
    public interface IVistaRegistroOrdenProduccion : IVistaRegistro {
        string NumeroOrden { get; set; }
        DateTime FechaApertura { get; set; }
        string NombreProductoTerminado { get; set; }
        decimal Cantidad { get; set; }
        decimal MargenGanancia { get; set; }


    }
}