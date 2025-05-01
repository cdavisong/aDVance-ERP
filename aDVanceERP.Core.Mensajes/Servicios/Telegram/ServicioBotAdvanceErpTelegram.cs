using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Servicios.Telegram.Plantillas;

using System.Net;

using Telegram.Bot;
using Telegram.Bot.Types;

namespace aDVanceERP.Core.Mensajes.Servicios.Telegram {
    public class ServicioBotAdvanceErpTelegram : IServicioTelegram, IDisposable {
        private readonly string _token;
        private TelegramBotClient? _botCliente;
        private CancellationTokenSource? _cts;
        private int _ultimoIdActualizacion = 0;

        public ServicioBotAdvanceErpTelegram(string token = "8100761883:AAFDu86VnKAPhjhH6yep7ogLuKnEwoQBLII") {
            _token = token;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public event EventHandler<MensajeTelegram>? MensajeRecibido;

        public async Task<bool> ConectarAsync() {
            try {
                _botCliente = new TelegramBotClient(_token);
                _cts = new CancellationTokenSource();

                // Iniciar recepción de mensajes
                _ = Task.Run(() => RecibirMensajeAsync(_cts.Token));

                // Verificar conexión
                //var me = await _botCliente.GetMe();
                //return me != null;

                return true;
            } catch {
                return false;
            }
        }

        private async Task RecibirMensajeAsync(CancellationToken cancellationToken) {
            while (!cancellationToken.IsCancellationRequested) {
                try {
                    var updates = await _botCliente.GetUpdates(
                        offset: _ultimoIdActualizacion + 1,
                        cancellationToken: cancellationToken);

                    foreach (var update in updates) {
                        _ultimoIdActualizacion = update.Id;

                        if (update.Message != null) {
                            MensajeRecibido?.Invoke(this, new MensajeTelegram {
                                TelefonoMovilDestinatario = update.Message.Contact?.PhoneNumber,
                                IdChat = update.Message.Chat.Id.ToString(),
                                Texto = update.Message.Text ?? string.Empty,
                                TiempoEnvio = DateTime.Now,
                                IdMensaje = update.Message.Id
                            });
                        }
                    }
                } catch {
                    // Esperar antes de reintentar
                    await Task.Delay(5000, cancellationToken);
                }
            }
        }

        public async Task<MensajeTelegram> EnviarMensajeAsync(MensajeTelegram mensaje) {
            try {
                var mensajeEnviado = await _botCliente.SendMessage(
                    chatId: mensaje.IdChat,
                    text: mensaje.Texto);

                mensaje.FueEnviado = true;
                mensaje.IdMensaje = mensajeEnviado.MessageId;
                
                return mensaje;
            } catch {
                mensaje.FueEnviado = false;

                return mensaje;
            }
        }

        public async Task EnviarDocumentoAsync(string chatId, InputFileStream documento, string caption = "") {
            try {
                await _botCliente.SendDocument(
                    chatId: chatId,
                    document: documento,
                    caption: caption
                );
            } catch (Exception ex) {
                Console.WriteLine($"Error al enviar documento: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> EliminarMensajeAsync(string idChat, int idMensaje) {
            try {
                await _botCliente.DeleteMessage(
                    chatId: idChat,
                    messageId: idMensaje);
                return true;
            } catch {
                return false;
            }
        }

        public void Desconectar() {
            _cts?.Cancel();
        }

        public void Dispose() {
            Desconectar();

            _botCliente = null;
        }
    }
}
