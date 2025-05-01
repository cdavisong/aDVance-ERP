
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using System.Globalization;
using Telegram.Bot.Types;

namespace aDVanceERP.Desktop.MVP.Presentadores.Principal {
    public partial class PresentadorPrincipal {
        private Dictionary<string, List<int>> _mensajesChat = new Dictionary<string, List<int>>();
        private Dictionary<string, (string? Username, string? Password)> _registrosPendientes = new Dictionary<string, (string, string)>();

        private async void ProcesarMensajeBotTelegram(object? sender, MensajeTelegram mensaje) {
            if (string.IsNullOrWhiteSpace(mensaje.Texto))
                return;

            // Procesar comandos básicos
            var comando = mensaje.Texto.Trim().ToLower();

            // Determinar si es un comando (empieza con '/')
            bool esComando = comando.StartsWith("/");

            if (esComando) {
                await LimpiarChat(mensaje.IdChat);
            }

            // Registrar el mensaje del usuario
            if (mensaje.IdMensaje != 0) {
                await RegistrarMensaje(mensaje.IdChat, mensaje.IdMensaje);
            }

            switch (comando) {
                case "/start":
                    await ResponderMensaje(mensaje.IdChat,
                        "Bienvenido al bot de aDVanceERP\n\n" +
                        "Comandos disponibles:\n" +
                        "/login - Autenticarse\n" +
                        "/register - Registrar nuevo usuario\n" +
                        "/ventas - Ver ventas del día\n" +
                        "/ganancias - Ver ganancias del día\n" +
                        "/help - Mostrar ayuda");
                    break;

                case "/login":
                    await ProcesarComandoLogin(mensaje);
                    break;

                case "/register":
                case "/registro":
                    await ProcesarComandoRegistro(mensaje);
                    break;

                case "/ventas":
                    await MostrarVentasDelDia(mensaje.IdChat);
                    break;

                case "/ganancias":
                    await MostrarGananciasDelDia(mensaje.IdChat);
                    break;

                case "/reporteventas":
                case "/reporte":
                    await ProcesarComandoReporteVentas(mensaje);
                    break;

                case "/help":
                case "/ayuda":
                    await MostrarAyuda(mensaje.IdChat);
                    break;

                default:
                    await ProcesarMensajeDefault(mensaje);
                    break;
            }
        }

        private async Task RegistrarMensaje(string chatId, int mensajeId) {
            if (!_mensajesChat.ContainsKey(chatId)) {
                _mensajesChat[chatId] = new List<int>();
            }

            _mensajesChat[chatId].Add(mensajeId);
        }

        private async Task ProcesarComandoLogin(MensajeTelegram mensaje) {
            await ResponderMensaje(mensaje.IdChat,
                "Por favor ingrese su nombre de usuario y contraseña en el formato:\n\n" +
                "usuario:contraseña\n\n");
        }

        private async Task ProcesarComandoRegistro(MensajeTelegram mensaje) {
            // Verificar si ya hay un registro en progreso
            if (_registrosPendientes.ContainsKey(mensaje.IdChat)) {
                await ResponderMensaje(mensaje.IdChat,
                    "Ya tienes un registro en progreso. Por favor completa el proceso o envía /cancelar para empezar de nuevo.");
                return;
            }

            // Marcar este chat como en proceso de registro
            _registrosPendientes[mensaje.IdChat] = (null, null);

            await ResponderMensaje(mensaje.IdChat,
                "Registro de nuevo usuario:\n\n" +
                "Por favor ingresa el nombre de usuario y contraseña en el formato:\n\n" +
                "nuevousuario:contraseña\n\n" +
                "Requisitos:\n" +
                "- Usuario: mínimo 4 caracteres\n" +
                "- Contraseña: mínimo 8 caracteres\n\n" +
                "Envía /cancelar en cualquier momento para cancelar el registro.");
        }

        private async Task MostrarVentasDelDia(string chatId) {
            try {
                var fechaHoy = DateTime.Today;
                var cantArticulos = UtilesVenta.ObtenerTotalArticulosVendidosHoy();
                var ventasBrutas = UtilesVenta.ObtenerValorBrutoVentaDia(fechaHoy);

                await ResponderMensaje(chatId,
                    $"📊 Ventas brutas del día ({fechaHoy:dd/MM/yyyy})\n\n" +
                    $"Artículos: {cantArticulos} unidades\n\n" +
                    $"Total: $ {ventasBrutas:N}\n\n" +
                    "(Solo incluye ventas con pagos completos confirmados)");
            } catch (ExcepcionConexionServidorMySQL) {
                await ResponderMensaje(chatId,
                    "⚠️ No se pudo conectar con la base de datos. Intente nuevamente más tarde.");
            } catch (Exception ex) {
                await ResponderMensaje(chatId,
                    $"❌ Error al obtener las ventas: {ex.Message}");
            }
        }

        private async Task MostrarGananciasDelDia(string chatId) {
            try {
                var fechaHoy = DateTime.Today;
                var ganancias = UtilesVenta.ObtenerValorGananciaDia(fechaHoy);

                await ResponderMensaje(chatId,
                    $"💰 Ganancias del día ({fechaHoy:dd/MM/yyyy})\n\n" +
                    $"Total: $ {ganancias:N}\n\n" +
                    "(Calculado como: (precio venta - precio compra) * cantidad)");
            } catch (ExcepcionConexionServidorMySQL) {
                await ResponderMensaje(chatId,
                    "⚠️ No se pudo conectar con la base de datos. Intente nuevamente más tarde.");
            } catch (Exception ex) {
                await ResponderMensaje(chatId,
                    $"❌ Error al obtener las ganancias: {ex.Message}");
            }
        }

        private async Task ProcesarComandoReporteVentas(MensajeTelegram mensaje) {
            try {
                // Obtener la fecha (podría ser parámetro o usar hoy por defecto)
                DateTime fechaReporte;
                if (mensaje.Texto.Contains(" ")) {
                    var partes = mensaje.Texto.Split(' ');
                    if (!DateTime.TryParse(partes[1], out fechaReporte)) {
                        fechaReporte = DateTime.Today;
                    }
                } else {
                    fechaReporte = DateTime.Today;
                }

                // Mostrar mensaje de "Generando reporte..."
                await ResponderMensaje(mensaje.IdChat, "🔄 Generando reporte de ventas...");

                // Obtener los datos
                var filas = new List<string[]>();
                using (var datosVentas = new DatosVenta()) {
                    var ventasFecha = datosVentas.Obtener(CriterioBusquedaVenta.Fecha, fechaReporte.ToString("yyyy-MM-dd"));

                    foreach (var venta in ventasFecha) {
                        using (var datosVentaArticulo = new DatosDetalleVentaArticulo()) {
                            var detalleVentaArticulo = datosVentaArticulo.Obtener(CriterioDetalleVentaArticulo.IdVenta, venta.Id.ToString());

                            foreach (var ventaArticulo in detalleVentaArticulo) {
                                var fila = new string[6];
                                fila[0] = ventaArticulo.Id.ToString();
                                fila[1] = UtilesArticulo.ObtenerNombreArticulo(ventaArticulo.IdArticulo).Result ?? string.Empty;
                                fila[2] = "U";
                                fila[3] = ventaArticulo.PrecioVentaFinal.ToString("N", CultureInfo.InvariantCulture);
                                fila[4] = ventaArticulo.Cantidad.ToString();
                                fila[5] = (ventaArticulo.PrecioVentaFinal * ventaArticulo.Cantidad).ToString("N", CultureInfo.InvariantCulture);
                                filas.Add(fila);
                            }
                        }
                    }
                }

                UtilesReportes.GenerarReporteVentas(fechaReporte, filas, mostrar: false);
                
                var nombreArchivo = $"ventas-articulos-{fechaReporte:yyyy-MM-dd}.pdf";

                // Generar el PDF en memoria
                using (var pdfStream = File.OpenRead(nombreArchivo)) {
                    // Enviar el documento PDF
                    await EnviarDocumento(mensaje.IdChat, pdfStream, $"ReporteVentas_{fechaReporte:yyyyMMdd}.pdf");
                }

                await ResponderMensaje(mensaje.IdChat, "✅ Reporte generado y enviado correctamente");
            } catch (Exception ex) {
                await ResponderMensaje(mensaje.IdChat, $"❌ Error al generar el reporte: {ex.Message}");
            }
        }

        // Método para enviar documentos a través del bot
        private async Task EnviarDocumento(string chatId, Stream documentoStream, string nombreArchivo) {
            if (!BotTelegramConectado) return;

            try {
                // Rebobinar el stream por si acaso
                documentoStream.Position = 0;

                // Convertir a InputFileStream
                var inputFile = new InputFileStream(
                    content: documentoStream,
                    fileName: nombreArchivo
                );

                // Enviar el documento
                await ServicioBotTelegram.EnviarDocumentoAsync(
                    chatId: chatId,
                    documento: inputFile,
                    caption: $"Reporte: {nombreArchivo}"
                );
            } catch (Exception ex) {
                Console.WriteLine($"Error al enviar documento: {ex.Message}");
                throw;
            }
        }

        private async Task ProcesarMensajeDefault(MensajeTelegram mensaje) {
            // Verificar si es parte de un registro en progreso
            if (_registrosPendientes.ContainsKey(mensaje.IdChat)) {
                await ProcesarRegistroUsuario(mensaje);
                return;
            }

            // Verificar si es credenciales para login
            if (mensaje.Texto.Contains(":")) {
                await ProcesarYLimpiarCredenciales(mensaje);
                return;
            }

            await ResponderMensaje(mensaje.IdChat,
                "No reconozco ese comando. Envía /help para ver los comandos disponibles.");
        }

        private async Task ProcesarYLimpiarCredenciales(MensajeTelegram mensaje) {
            // Verificar si el mensaje podría contener credenciales
            bool esPosibleCredencial = mensaje.Texto.Contains(":") && mensaje.Texto.Trim().Split(':').Length == 2;

            try {
                if (esPosibleCredencial) {
                    var partes = mensaje.Texto.Split(':');
                    var usuario = partes[0].Trim();
                    var password = partes[1].Trim();

                    using (var datosUsuario = new DatosCuentaUsuario()) {
                        var usuarioEncontrado = (await datosUsuario.ObtenerAsync(
                            CriterioBusquedaCuentaUsuario.Nombre,
                            usuario,
                            out _)).FirstOrDefault();

                        if (usuarioEncontrado == null) {
                            await ResponderMensaje(mensaje.IdChat, "Usuario no encontrado");
                            return;
                        } else if (!usuarioEncontrado.Aprobado) {
                            await ResponderMensaje(mensaje.IdChat, 
                                "Tu cuenta ha sido registrada exitosamente. Sin embargo, para poder acceder y utilizar todas las funcionalidades, necesitarás esperar hasta que un administrador apruebe tu cuenta. Esto puede tomar un tiempo, así que te pedimos que tengas paciencia.\n\n" +
                                "Una vez que tu cuenta sea aprobada, recibirás una notificación y podrás comenzar a usar el sistema de inmediato.\n\n" +
                                "¡Gracias por tu comprensión y paciencia!");
                            return;
                        }

                        if (UtilesPassword.VerificarPassword(password,
                            usuarioEncontrado.PasswordHash,
                            usuarioEncontrado.PasswordSalt)) {

                            await ResponderMensaje(mensaje.IdChat, $"Autenticación exitosa. Bienvenido {usuarioEncontrado.Nombre}");
                        } else {
                            await ResponderMensaje(mensaje.IdChat, "Contraseña incorrecta");
                        }
                    }
                } else {
                    await ResponderMensaje(mensaje.IdChat, "Formato incorrecto. Use: usuario:contraseña");
                }
            } catch (Exception ex) {
                await ResponderMensaje(mensaje.IdChat, "Error al procesar la autenticación");
                // Loggear el error
            } finally {
                // Borrar el mensaje con credenciales después de procesarlo
                if (esPosibleCredencial && mensaje.IdMensaje != 0) {
                    try {
                        await ServicioBotTelegram.EliminarMensajeAsync(mensaje.IdChat, mensaje.IdMensaje);
                    } catch {
                        // Si falla el borrado, al menos informar al usuario
                        await ResponderMensaje(mensaje.IdChat, "No pude borrar tu mensaje con credenciales. Por favor, bórralo manualmente por seguridad.");
                    }
                }
            }
        }

        private async Task ProcesarRegistroUsuario(MensajeTelegram mensaje) {
            try {
                var partes = mensaje.Texto.Split(':');
                if (partes.Length != 2) {
                    await ResponderMensaje(mensaje.IdChat,
                        "Formato incorrecto. Usa: nombreusuario:contraseña");
                    return;
                }

                var usuario = partes[0].Trim();
                var password = partes[1].Trim();

                // Validaciones básicas
                if (usuario.Length < 4) {
                    await ResponderMensaje(mensaje.IdChat,
                        "El nombre de usuario debe tener al menos 4 caracteres.");
                    return;
                }

                if (password.Length < 8) {
                    await ResponderMensaje(mensaje.IdChat,
                        "La contraseña debe tener al menos 8 caracteres.");
                    return;
                }

                using (var datosUsuario = new DatosCuentaUsuario()) {
                    // Verificar si el usuario ya existe
                    var usuarioExistente = (await datosUsuario.ObtenerAsync(
                        CriterioBusquedaCuentaUsuario.Nombre,
                        usuario,
                        out _)).FirstOrDefault();

                    if (usuarioExistente != null) {
                        await ResponderMensaje(mensaje.IdChat,
                            "El nombre de usuario ya está en uso. Por favor elige otro.");
                        return;
                    }

                    // Crear el nuevo usuario
                    var passwordUsuario = UtilesPassword.HashPassword(password);
                    var nuevoUsuario = new CuentaUsuario(0, usuario, passwordUsuario.hash, passwordUsuario.salt, 0) {
                        Aprobado = false // Por defecto no aprobado hasta revisión
                    };

                    datosUsuario.Adicionar(nuevoUsuario);

                    await ResponderMensaje(mensaje.IdChat,
                        $"¡Registro exitoso! Usuario {usuario} creado correctamente.\n\n" +
                        "Tu cuenta está pendiente de aprobación por un administrador.\n" +
                        "Recibirás una notificación cuando sea aprobada.\n\n" +
                        "Gracias por registrarte.");
                }
            } catch (Exception ex) {
                await ResponderMensaje(mensaje.IdChat,
                    "Error durante el registro: " + ex.Message);
            } finally {
                // Limpiar el registro pendiente independientemente del resultado
                _registrosPendientes.Remove(mensaje.IdChat);

                // Borrar mensaje con credenciales
                if (mensaje.IdMensaje != 0) {
                    try {
                        await ServicioBotTelegram.EliminarMensajeAsync(mensaje.IdChat, mensaje.IdMensaje);
                    } catch {
                        await ResponderMensaje(mensaje.IdChat,
                            "No pude borrar tu mensaje con credenciales. Por favor, bórralo manualmente.");
                    }
                }
            }
        }

        private async Task MostrarAyuda(string chatId) {
            await ResponderMensaje(chatId,
                "Ayuda - Comandos disponibles:\n\n" +
                "/start - Mostrar bienvenida\n" +
                "/login - Iniciar sesión\n" +
                "/register - Registrar nuevo usuario\n" +
                "/help - Mostrar esta ayuda\n\n" +
                "Para autenticarte o registrarte, usa el formato:\n" +
                "usuario:contraseña");
        }

        private async Task ResponderMensaje(string chatId, string mensaje) {
            if (!BotTelegramConectado)
                return;

            try {
                // Mostrar mensaje "Procesando..." temporal
                var mensajeTemporal = await ServicioBotTelegram.EnviarMensajeAsync(new MensajeTelegram {
                    IdChat = chatId,
                    Texto = "🔄 Procesando..."
                });

                // Enviar mensaje real
                var mensajeReal = await ServicioBotTelegram.EnviarMensajeAsync(new MensajeTelegram {
                    IdChat = chatId,
                    Texto = mensaje
                });

                // Borrar mensaje temporal
                await ServicioBotTelegram.EliminarMensajeAsync(chatId, mensajeTemporal.IdMensaje);

                // Registrar mensaje real
                await RegistrarMensaje(chatId, mensajeReal.IdMensaje);
            } catch (Exception ex) {
                Console.WriteLine($"Error al responder mensaje: {ex.Message}");
            }
        }

        private async Task LimpiarChat(string chatId) {
            if (!_mensajesChat.ContainsKey(chatId) || _mensajesChat[chatId].Count == 0)
                return;

            try {
                // Borrar todos los mensajes registrados en este chat
                foreach (var mensajeId in _mensajesChat[chatId]) {
                    await ServicioBotTelegram.EliminarMensajeAsync(chatId, mensajeId);
                }

                _mensajesChat[chatId].Clear();
            } catch (Exception ex) {
                Console.WriteLine($"Error al limpiar chat: {ex.Message}");
            }
        }

        public void DesconectarBotTelegram() {
            if (ServicioBotTelegram != null) {
                ServicioBotTelegram.Desconectar();
                ServicioBotTelegram.Dispose();
            }
        }
    }
}
