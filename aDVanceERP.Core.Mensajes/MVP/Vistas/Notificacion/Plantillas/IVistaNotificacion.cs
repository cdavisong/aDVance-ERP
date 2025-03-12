using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Mensajes.MVP.Vistas.Notificacion.Plantillas {
    public interface IVistaNotificacion : IVista {
        string? Mensaje { get; set; }

        bool EsError { get; set; }

        void ActualizarPosicionObjetivo(Point objetivo);
        void EstablecerPosicionObjetivo(Point objetivo);
    }
}
