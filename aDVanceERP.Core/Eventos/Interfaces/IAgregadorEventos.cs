namespace aDVanceERP.Core.Eventos.Interfaces;

public interface IAgregadorEventos {
    void Suscribir<TEvento>(Action<TEvento> handler) where TEvento : EventoBase;
    void Desuscribir<TEvento>(Action<TEvento> handler) where TEvento : EventoBase;
    void Publicar<TEvento>(TEvento @event) where TEvento : EventoBase;

}
