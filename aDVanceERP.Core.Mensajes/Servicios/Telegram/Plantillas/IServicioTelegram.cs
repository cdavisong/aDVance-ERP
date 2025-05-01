using aDVanceERP.Core.Mensajes.MVP.Modelos;

namespace aDVanceERP.Core.Mensajes.Servicios.Telegram.Plantillas {
    public interface IServicioTelegram {
        Task<bool> ConectarAsync();
        Task<MensajeTelegram> EnviarMensajeAsync(MensajeTelegram mensaje);
        Task<bool> EliminarMensajeAsync(string chatId, int messageId);
        void Desconectar();

        event EventHandler<MensajeTelegram>? MensajeRecibido;
    }
}
