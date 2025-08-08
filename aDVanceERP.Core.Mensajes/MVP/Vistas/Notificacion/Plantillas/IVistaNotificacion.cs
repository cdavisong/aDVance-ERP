using aDVanceERP.Core.Interfaces;
using aDVanceERP.Core.Mensajes.MVP.Modelos;

namespace aDVanceERP.Core.Mensajes.MVP.Vistas.Notificacion.Plantillas;

public interface IVistaNotificacion : IVista {
    string? Mensaje { get; set; }

    TipoNotificacion Tipo { get; set; }

    void ActualizarPosicionObjetivo(Point objetivo);
    void EstablecerPosicionObjetivo(Point objetivo);
}