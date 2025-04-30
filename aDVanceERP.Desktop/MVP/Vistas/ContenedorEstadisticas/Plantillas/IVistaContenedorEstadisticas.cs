using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles.Datos;

namespace aDVanceERP.Desktop.MVP.Vistas.ContenedorEstadisticas.Plantillas; 

public interface IVistaContenedorEstadisticas : IVista {
    int CantidadArticulosRegistrados { get; set; }
    decimal MontoInversionArticulos { get; set; }
    int CantidadArticulosVendidos { get; set; }
    decimal MontoVentaArticulosVendidos { get; set; }
    decimal MontoGananciaTotalNegocio { get; set; }
    decimal MontoGananciaAcumuladaDia { get; set; }
    DatosEstadisticosVentas DatosEstadisticosVentas { get; set; }
    DateTime FechaEstadisticasVentas { get; }

    event EventHandler? MostrarVistaGestionArticulos;
    event EventHandler? MostrarVistaGestionVentas;
    event EventHandler? FechaEstadsticasModificada;
}