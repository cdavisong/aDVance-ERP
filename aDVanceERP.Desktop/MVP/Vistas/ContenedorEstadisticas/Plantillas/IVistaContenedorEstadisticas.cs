using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Desktop.MVP.Vistas.ContenedorEstadisticas.Plantillas {
    public interface IVistaContenedorEstadisticas : IVista {
        int CantidadArticulosRegistrados { get; set; }
        decimal MontoInversionArticulos { get; set; }
        int CantidadArticulosVendidos { get; set; }
        decimal MontoVentaArticulosVendidos { get; set; }
        decimal MontoGananciaTotalNegocio { get; set; }

        event EventHandler? MostrarVistaGestionArticulos;
        event EventHandler? MostrarVistaGestionVentas;
    }
}
