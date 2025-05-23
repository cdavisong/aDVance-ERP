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
        #region Campos y Propiedades
        private Dictionary<string, List<int>> _mensajesChat = new Dictionary<string, List<int>>();
        private Dictionary<string, (string? Username, string? Password)> _registrosPendientes = new Dictionary<string, (string?, string?)>();
        private Dictionary<string, DateTime?> _reportesPendientes = new Dictionary<string, DateTime?>();
        private Dictionary<string, string> _usuariosAutenticados = new Dictionary<string, string>();
        private Dictionary<string, int> _comandosActivos = new Dictionary<string, int>();
        private Dictionary<string, string> _identificacionPendiente = new Dictionary<string, string>();

        public static string? IdEmpresa { get; set; }
        #endregion

        #region Constantes y Enumeraciones
        private const int COMANDO_NINGUNO = 0;
        private const int COMANDO_LOGIN = 1;
        private const int COMANDO_REGISTRO = 2;
        private const int COMANDO_REPORTE_VENTAS = 3;
        private const int COMANDO_IDENTIFICACION_EMPRESA = 4;

        private enum EstadoChat {
            NoIdentificado,
            Identificado,
            Autenticado
        }
        #endregion

        #region Métodos Principales
        private async void ProcesarMensajeBotTelegram(object? sender, MensajeTelegram mensaje) {
            if (string.IsNullOrWhiteSpace(mensaje.Texto))
                return;

            // Verificar si hay un comando activo pendiente
            if (_comandosActivos.TryGetValue(mensaje.IdChat, out int comandoActivo) && !mensaje.Texto.StartsWith("/")) {
                await ProcesarComandoActivo(mensaje, comandoActivo);
                return;
            }

            // Validar identificación de empresa
            var estado = ValidarEstadoChat(mensaje);
            if (estado == EstadoChat.NoIdentificado) {
                await ProcesarIdentificacionEmpresa(mensaje);
                return;
            }

            // Validar autenticación para comandos protegidos
            if (RequiereAutenticacion(mensaje.Texto)) {
                if (estado != EstadoChat.Autenticado) {
                    await ResponderMensaje(mensaje.IdChat,
                        "🔒 Acceso restringido\n\n" +
                        "Debe autenticarse primero con /login");
                    return;
                }
            }

            // Procesar comando principal
            await ProcesarComandoSeguro(mensaje);
        }

        private EstadoChat ValidarEstadoChat(MensajeTelegram mensaje) {
            // Si el chat ya tiene un usuario autenticado
            if (_usuariosAutenticados.ContainsKey(mensaje.IdChat))
                return EstadoChat.Autenticado;

            // Verificar si el chat ya se identificó correctamente
            if (_identificacionPendiente.ContainsKey(mensaje.IdChat) && _identificacionPendiente[mensaje.IdChat] == IdEmpresa)
                return EstadoChat.Identificado;

            return EstadoChat.NoIdentificado;
        }

        private bool RequiereAutenticacion(string comando) {
            var comandosProtegidos = new[] { "/ventas", "/ganancias", "/reporteventas", "/resumen", "/nuevaventa", "/ventasdia", "/stock", "/productos" };
            return comandosProtegidos.Contains(comando.Trim().ToLower());
        }
        #endregion

        #region Gestión de Comandos
        private async Task ProcesarComandoSeguro(MensajeTelegram mensaje) {
            var comando = mensaje.Texto.Trim().ToLower();
            bool esComando = comando.StartsWith("/");

            if (esComando) {
                await LimpiarChat(mensaje.IdChat);
                _comandosActivos.Remove(mensaje.IdChat);
            }

            if (mensaje.IdMensaje != 0) {
                await RegistrarMensaje(mensaje.IdChat, mensaje.IdMensaje);
            }

            switch (comando) {
                case "/start":
                    await MostrarMensajeBienvenida(mensaje.IdChat);
                    break;

                case "/identificar":
                    await ProcesarComandoIdentificar(mensaje);
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
                    await ProcesarComandoReporteVentas(mensaje);
                    break;

                case "/help":
                case "/ayuda":
                    await MostrarAyuda(mensaje.IdChat);
                    break;

                case "/comandos":
                    await MostrarTodosComandos(mensaje.IdChat);
                    break;

                default:
                    await ProcesarMensajeDefault(mensaje);
                    break;
            }
        }

        private async Task ProcesarComandoActivo(MensajeTelegram mensaje, int comandoActivo) {
            switch (comandoActivo) {
                case COMANDO_IDENTIFICACION_EMPRESA:
                    await ProcesarIdentificacionEmpresa(mensaje);
                    break;

                case COMANDO_LOGIN:
                    if (mensaje.Texto.Contains(":")) {
                        await ProcesarYLimpiarCredenciales(mensaje);
                        _comandosActivos.Remove(mensaje.IdChat);
                    } else {
                        await ResponderMensaje(mensaje.IdChat,
                            "⚠️ Formato incorrecto\n\nUse: usuario:contraseña");
                    }
                    break;

                case COMANDO_REGISTRO:
                    if (_registrosPendientes.ContainsKey(mensaje.IdChat)) {
                        await ProcesarRegistroUsuario(mensaje);
                        _comandosActivos.Remove(mensaje.IdChat);
                    }
                    break;

                case COMANDO_REPORTE_VENTAS:
                    await ProcesarFechaReporte(mensaje);
                    if (!_reportesPendientes.ContainsKey(mensaje.IdChat)) {
                        _comandosActivos.Remove(mensaje.IdChat);
                    }
                    break;

                default:
                    await ResponderMensaje(mensaje.IdChat,
                        "❌ Comando no reconocido");
                    _comandosActivos.Remove(mensaje.IdChat);
                    break;
            }
        }
        #endregion

        #region Identificación y Autenticación
        
        private async Task ProcesarComandoIdentificar(MensajeTelegram mensaje) {
            _comandosActivos[mensaje.IdChat] = COMANDO_IDENTIFICACION_EMPRESA;

            await ResponderMensaje(mensaje.IdChat,
                "🏢 Identificación de Empresa\n\n" +
                "Por favor ingrese el ID de su empresa:");
        }

        private async Task ProcesarIdentificacionEmpresa(MensajeTelegram mensaje) {
            // Si no hay un comando activo, iniciar el proceso
            if (!_comandosActivos.ContainsKey(mensaje.IdChat)) {
                _comandosActivos[mensaje.IdChat] = COMANDO_IDENTIFICACION_EMPRESA;
                await ResponderMensaje(mensaje.IdChat,
                    "🏢 Identificación de Empresa\n\n" +
                    "Por favor ingrese el ID de su empresa:");
                return;
            }

            // Procesar el ID de empresa ingresado
            if (_comandosActivos[mensaje.IdChat] == COMANDO_IDENTIFICACION_EMPRESA) {
                var idEmpresaIngresado = mensaje.Texto.Trim();

                if (idEmpresaIngresado == IdEmpresa) {
                    _identificacionPendiente[mensaje.IdChat] = idEmpresaIngresado;
                    _comandosActivos.Remove(mensaje.IdChat);

                    await ResponderMensaje(mensaje.IdChat,
                        $"✅ Empresa identificada correctamente\n\n" +
                        $"Bienvenido a {_empresa?.Nombre ?? IdEmpresa}\n\n" +
                        "Ahora puede usar los comandos básicos.\n" +
                        "Para acceder a todas las funciones, use /login");
                } else {
                    await ResponderMensaje(mensaje.IdChat,
                        "❌ ID de empresa incorrecto\n\n" +
                        "El ID proporcionado no coincide con esta instancia.\n" +
                        "Por favor intente nuevamente o póngase en contacto con soporte.");
                    _comandosActivos.Remove(mensaje.IdChat);
                }
            }
        }

        private async Task ProcesarComandoLogin(MensajeTelegram mensaje) {
            _comandosActivos[mensaje.IdChat] = COMANDO_LOGIN;

            await ResponderMensaje(mensaje.IdChat,
                "🔐 Inicio de Sesión\n\n" +
                "Ingrese sus credenciales en el formato:\n\n" +
                "usuario:contraseña\n\n" +
                "⚠️ Este mensaje se autodestruirá por seguridad");
        }

        private async Task ProcesarComandoRegistro(MensajeTelegram mensaje) {
            if (_registrosPendientes.ContainsKey(mensaje.IdChat)) {
                await ResponderMensaje(mensaje.IdChat,
                    "⚠️ Ya tienes un registro en progreso.\n\n" +
                    "Completa el proceso o envía /cancelar");
                return;
            }

            _registrosPendientes[mensaje.IdChat] = (null, null);
            _comandosActivos[mensaje.IdChat] = COMANDO_REGISTRO;

            await ResponderMensaje(mensaje.IdChat,
                "📝 Registro de nuevo usuario\n\n" +
                "Ingresa tus datos en el formato:\n\n" +
                "nuevousuario:contraseña\n\n" +
                "📌 Requisitos:\n" +
                "- Usuario: mínimo 4 caracteres\n" +
                "- Contraseña: mínimo 8 caracteres\n\n" +
                "⚠️ Este mensaje se autodestruirá");
        }
        #endregion

        #region Comandos Protegidos
        private async Task MostrarVentasDelDia(string chatId) {
            if (!_identificacionPendiente.ContainsKey(chatId)) {
                await ResponderMensaje(chatId, "🔒 Primero debe identificar su empresa");
                return;
            }

            try {
                var fechaHoy = DateTime.Today;
                var cantProductos = UtilesVenta.ObtenerTotalProductosVendidosHoy();
                var ventasBrutas = UtilesVenta.ObtenerValorBrutoVentaDia(fechaHoy);

                await ResponderMensaje(chatId,
                    $"📊 Ventas del día ({fechaHoy:dd/MM/yyyy})\n" +
                    $"🏢 Empresa: {_empresa?.Nombre ?? IdEmpresa}\n\n" +
                    $"🛒 Productos vendidos: {cantProductos} unidades\n" +
                    $"💰 Total bruto: $ {ventasBrutas:N}\n\n" +
                    "(Solo ventas con pagos completos)");
            } catch (ExcepcionConexionServidorMySQL) {
                await ResponderMensaje(chatId,
                    "⚠️ Error de conexión\n\n" +
                    "No se pudo conectar con la base de datos.");
            } catch (Exception ex) {
                await ResponderMensaje(chatId,
                    $"❌ Error al obtener ventas: {ex.Message}");
            }
        }

        private async Task MostrarGananciasDelDia(string chatId) {
            if (!_identificacionPendiente.ContainsKey(chatId)) {
                await ResponderMensaje(chatId, "🔒 Primero debe identificar su empresa");
                return;
            }

            try {
                var fechaHoy = DateTime.Today;
                var ganancias = UtilesVenta.ObtenerValorGananciaDia(fechaHoy);

                await ResponderMensaje(chatId,
                    $"💰 Ganancias del día ({fechaHoy:dd/MM/yyyy})\n" +
                    $"🏢 Empresa: {_empresa?.Nombre ?? IdEmpresa}\n\n" +
                    $"📈 Total: $ {ganancias:N}\n\n" +
                    "(Calculado como: (precio venta - precio compra) × cantidad)");
            } catch (ExcepcionConexionServidorMySQL) {
                await ResponderMensaje(chatId,
                    "⚠️ Error de conexión\n\n" +
                    "No se pudo conectar con la base de datos.");
            } catch (Exception ex) {
                await ResponderMensaje(chatId,
                    $"❌ Error al obtener ganancias: {ex.Message}");
            }
        }

        private async Task ProcesarComandoReporteVentas(MensajeTelegram mensaje) {
            if (!_identificacionPendiente.ContainsKey(mensaje.IdChat)) {
                await ResponderMensaje(mensaje.IdChat, "🔒 Primero debe identificar su empresa");
                return;
            }

            if (!_usuariosAutenticados.ContainsKey(mensaje.IdChat)) {
                await ResponderMensaje(mensaje.IdChat,
                    "🔒 Acceso restringido\n\n" +
                    "Debe autenticarse primero con /login");
                return;
            }

            _comandosActivos[mensaje.IdChat] = COMANDO_REPORTE_VENTAS;

            await ResponderMensaje(mensaje.IdChat,
                "📅 Generar Reporte de Ventas\n\n" +
                "Ingrese la fecha en formato DD/MM/AAAA\n\n" +
                "Ejemplos:\n" +
                "15/08/2023 - Para un día específico\n" +
                "hoy - Para el día actual\n" +
                "ayer - Para el día anterior\n\n" +
                "Envía /cancelar para cancelar");
        }
        #endregion

        #region Generación de reporte de ventas
        private async Task ProcesarFechaReporte(MensajeTelegram mensaje) {
            try {
                DateTime fechaReporte;
                string texto = mensaje.Texto.Trim().ToLower();

                // Manejar comandos especiales primero
                if (texto == "/cancelar") {
                    await ResponderMensaje(mensaje.IdChat, "❌ Operación de reporte cancelada");
                    _reportesPendientes.Remove(mensaje.IdChat);
                    return;
                }

                // Procesar palabras clave
                if (texto == "hoy") {
                    fechaReporte = DateTime.Today;
                } else if (texto == "ayer") {
                    fechaReporte = DateTime.Today.AddDays(-1);
                } else {
                    // Intentar parsear la fecha en formato DD/MM/AAAA
                    if (!DateTime.TryParseExact(texto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaReporte)) {
                        await ResponderMensaje(mensaje.IdChat,
                            "⚠️ Formato de fecha incorrecto\n\n" +
                            "Por favor ingrese la fecha en formato DD/MM/AAAA\n\n" +
                            "Ejemplos válidos:\n" +
                            "• 15/08/2023\n" +
                            "• hoy - Para la fecha actual\n" +
                            "• ayer - Para el día anterior\n\n" +
                            "O envíe /cancelar para salir");
                        return;
                    }
                }

                // Validar que la fecha no sea futura
                if (fechaReporte > DateTime.Today) {
                    await ResponderMensaje(mensaje.IdChat,
                        "❌ Fecha inválida\n\n" +
                        "No se pueden generar reportes para fechas futuras.\n" +
                        "Por favor ingrese una fecha válida.");
                    return;
                }

                // Proceder con la generación del reporte
                await GenerarReporteVentas(mensaje.IdChat, fechaReporte);
                _reportesPendientes.Remove(mensaje.IdChat);
            } catch (Exception ex) {
                await ResponderMensaje(mensaje.IdChat,
                    $"❌ Error al procesar fecha\n\n" +
                    $"Detalles: {ex.Message}");
                _reportesPendientes.Remove(mensaje.IdChat);
            }
        }

        private async Task GenerarReporteVentas(string chatId, DateTime fechaReporte) {
            try {
                await ResponderMensaje(chatId, $"🔄 Generando reporte para el {fechaReporte:dd/MM/yyyy}...");

                var filas = new List<string[]>();
                using (var datosVentas = new DatosVenta()) {
                    var ventasFecha = datosVentas.Obtener(CriterioBusquedaVenta.Fecha, fechaReporte.ToString("yyyy-MM-dd"));

                    if (ventasFecha == null || !ventasFecha.Any()) {
                        await ResponderMensaje(chatId, $"ℹ️ No hay ventas registradas para el {fechaReporte:dd/MM/yyyy}");
                        return;
                    }

                    foreach (var venta in ventasFecha) {
                        using (var datosVentaProducto = new DatosDetalleVentaProducto()) {
                            var detalleVentaProducto = datosVentaProducto.Obtener(CriterioDetalleVentaProducto.IdVenta, venta.Id.ToString());

                            foreach (var ventaProducto in detalleVentaProducto) {
                                var fila = new string[6];
                                fila[0] = ventaProducto.Id.ToString();
                                fila[1] = UtilesProducto.ObtenerNombreProducto(ventaProducto.IdProducto).Result ?? "Producto desconocido";
                                fila[2] = "U"; // Unidad
                                fila[3] = ventaProducto.PrecioVentaFinal.ToString("N2", CultureInfo.InvariantCulture);
                                fila[4] = ventaProducto.Cantidad.ToString();
                                fila[5] = (ventaProducto.PrecioVentaFinal * ventaProducto.Cantidad).ToString("N2", CultureInfo.InvariantCulture);
                                filas.Add(fila);
                            }
                        }
                    }
                }

                // Generar el reporte PDF
                var nombreArchivo = $"ventas-productos-{fechaReporte:yyyy-MM-dd}.pdf";

                UtilesReportes.GenerarReporteVentas(fechaReporte, filas, IdEmpresa, mostrar: false);

                // Enviar el documento
                using (var pdfStream = File.OpenRead(nombreArchivo)) {
                    await EnviarDocumento(chatId, pdfStream, nombreArchivo);
                }

                await ResponderMensaje(chatId,
                    $"✅ Reporte generado con éxito\n\n" +
                    $"📅 Fecha: {fechaReporte:dd/MM/yyyy}\n" +
                    $"🏢 Empresa: {_empresa?.Nombre ?? IdEmpresa}\n" +
                    $"📊 Total de ventas: {filas.Count}\n\n" +
                    "El documento PDF ha sido enviado.");
            } catch (ExcepcionConexionServidorMySQL) {
                await ResponderMensaje(chatId,
                    "⚠️ Error de conexión\n\n" +
                    "No se pudo conectar con la base de datos.\n" +
                    "Por favor intente nuevamente más tarde.");
            } catch (Exception ex) {
                await ResponderMensaje(chatId,
                    $"❌ Error al generar reporte\n\n" +
                    $"Detalles: {ex.Message}");
            } finally {
                // Limpiar el archivo temporal si existe
                try {
                    var nombreArchivo = $"ventas-{IdEmpresa}-{DateTime.Today:yyyyMMdd}.pdf";
                    if (File.Exists(nombreArchivo)) {
                        File.Delete(nombreArchivo);
                    }
                } catch { /* Ignorar errores de limpieza */ }
            }
        }
        #endregion

        #region Mensajes y Ayuda
        private async Task MostrarMensajeBienvenida(string chatId) {
            await ResponderMensaje(chatId,
                "🤖 Bienvenido al Bot de aDVanceERP 🏢\n\n" +
                "📋 Comandos disponibles:\n\n" +

                "🔐 Autenticación:\n" +
                "/identificar - Identifica la empresa\n" +
                "/login - Iniciar sesión\n" +
                "/register - Registrarse\n\n" +

                "📊 Reportes financieros:\n" +
                "/ventas - Ventas del día\n" +
                "/ganancias - Ganancias del día\n" +
                "/reporteventas - Generar PDF de ventas\n\n" +

                "🆘 Ayuda:\n" +
                "/help - Mostrar ayuda básica\n" +
                "/comandos - Listar todos los comandos\n\n" +

                "📌 Ejemplo: Escribe /ventas para ver las ventas");
        }

        private async Task MostrarAyuda(string chatId) {
            await ResponderMensaje(chatId,
                "🆘 Ayuda - Comandos disponibles:\n\n" +
                "🔐 Autenticación:\n" +
                "/login - Iniciar sesión\n" +
                "/register - Registrarse\n\n" +
                "📌 Formato para credenciales:\n" +
                "usuario:contraseña\n\n" +
                "Escribe /comandos para ver la lista completa");
        }

        private async Task MostrarTodosComandos(string chatId) {
            await ResponderMensaje(chatId,
                "📋 Todos los comandos disponibles:\n\n" +
                "🔐 Autenticación:\n" +
                "/identificar - Identifica la empresa con su código de seguridad\n" +
                "/login - Iniciar sesión\n" +
                "/register - Registrarse\n\n" +

                "📊 Reportes:\n" +
                "/ventas - Ventas del día\n" +
                "/ganancias - Ganancias del día\n" +
                "/reporteventas - Generar PDF de ventas\n\n" +

                "🛒 Operaciones:\n" +
                "/nuevaventa - Crear nueva venta\n" +
                "/ventasdia - Listar ventas de hoy\n\n" +

                "📦 Inventario:\n" +
                "/stock - Consultar inventario\n" +
                "/productos - Listar productos\n\n" +

                "🆘 Ayuda:\n" +
                "/help - Mostrar ayuda\n" +
                "/comandos - Mostrar esta lista");
        }

        private async Task ProcesarMensajeDefault(MensajeTelegram mensaje) {
            await ResponderMensaje(mensaje.IdChat,
                "❓ Comando no reconocido\n\n" +
                "Escribe /help para ver los comandos disponibles");
        }
        #endregion

        #region Gestión de Usuarios
        private async Task ProcesarYLimpiarCredenciales(MensajeTelegram mensaje) {
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
                            await ResponderMensaje(mensaje.IdChat, "🔍 Usuario no encontrado");
                            return;
                        } else if (!usuarioEncontrado.Aprobado) {
                            await ResponderMensaje(mensaje.IdChat,
                                "🕒 Cuenta pendiente de aprobación\n\n" +
                                "Tu cuenta está siendo revisada por un administrador.\n" +
                                "Recibirás una notificación cuando sea aprobada.");
                            return;
                        }

                        if (UtilesPassword.VerificarPassword(password,
                            usuarioEncontrado.PasswordHash,
                            usuarioEncontrado.PasswordSalt)) {
                            _usuariosAutenticados[mensaje.IdChat] = usuarioEncontrado.Nombre;
                            await ResponderMensaje(mensaje.IdChat,
                                $"✅ Autenticación exitosa\n\n" +
                                $"Bienvenido, {usuarioEncontrado.Nombre}");
                        } else {
                            await ResponderMensaje(mensaje.IdChat, "❌ Contraseña incorrecta");
                        }
                    }
                } else {
                    await ResponderMensaje(mensaje.IdChat, "⚠️ Formato incorrecto\nUse: usuario:contraseña");
                }
            } catch (Exception ex) {
                await ResponderMensaje(mensaje.IdChat,
                    "❌ Error en autenticación\n\n" +
                    $"Detalles: {ex.Message}");
            } finally {
                if (esPosibleCredencial && mensaje.IdMensaje != 0) {
                    try {
                        await ServicioBotTelegram.EliminarMensajeAsync(mensaje.IdChat, mensaje.IdMensaje);
                    } catch {
                        await ResponderMensaje(mensaje.IdChat,
                            "⚠️ Advertencia de seguridad\n\n" +
                            "No pude borrar tu mensaje con credenciales. Por favor, bórralo manualmente.");
                    }
                }
            }
        }

        private async Task ProcesarRegistroUsuario(MensajeTelegram mensaje) {
            try {
                var partes = mensaje.Texto.Split(':');
                if (partes.Length != 2) {
                    await ResponderMensaje(mensaje.IdChat,
                        "⚠️ Formato incorrecto\nUse: nombreusuario:contraseña");
                    return;
                }

                var usuario = partes[0].Trim();
                var password = partes[1].Trim();

                if (usuario.Length < 4) {
                    await ResponderMensaje(mensaje.IdChat,
                        "❌ Nombre de usuario inválido\n" +
                        "Debe tener al menos 4 caracteres.");
                    return;
                }

                if (password.Length < 8) {
                    await ResponderMensaje(mensaje.IdChat,
                        "❌ Contraseña inválida\n" +
                        "Debe tener al menos 8 caracteres.");
                    return;
                }

                using (var datosUsuario = new DatosCuentaUsuario()) {
                    var usuarioExistente = (await datosUsuario.ObtenerAsync(
                        CriterioBusquedaCuentaUsuario.Nombre,
                        usuario,
                        out _)).FirstOrDefault();

                    if (usuarioExistente != null) {
                        await ResponderMensaje(mensaje.IdChat,
                            "❌ Usuario ya existe\n" +
                            "El nombre de usuario ya está en uso.");
                        return;
                    }

                    var passwordUsuario = UtilesPassword.HashPassword(password);
                    var nuevoUsuario = new CuentaUsuario(0, usuario, passwordUsuario.hash, passwordUsuario.salt, 0) {
                        Aprobado = false
                    };

                    datosUsuario.Adicionar(nuevoUsuario);

                    await ResponderMensaje(mensaje.IdChat,
                        $"✅ Registro exitoso\n\n" +
                        $"Usuario {usuario} creado correctamente.\n\n" +
                        "🕒 Tu cuenta está pendiente de aprobación.\n" +
                        "Recibirás una notificación cuando sea aprobada.");
                }
            } catch (Exception ex) {
                await ResponderMensaje(mensaje.IdChat,
                    "❌ Error en registro\n\n" +
                    $"Detalles: {ex.Message}");
            } finally {
                _registrosPendientes.Remove(mensaje.IdChat);

                if (mensaje.IdMensaje != 0) {
                    try {
                        await ServicioBotTelegram.EliminarMensajeAsync(mensaje.IdChat, mensaje.IdMensaje);
                    } catch {
                        await ResponderMensaje(mensaje.IdChat,
                            "⚠️ Advertencia de seguridad\n\n" +
                            "No pude borrar tu mensaje con credenciales. Por favor, bórralo manualmente.");
                    }
                }
            }
        }
        #endregion

        #region Utilidades del Chat
        private async Task RegistrarMensaje(string chatId, int mensajeId) {
            if (!_mensajesChat.ContainsKey(chatId)) {
                _mensajesChat[chatId] = new List<int>();
            }

            _mensajesChat[chatId].Add(mensajeId);
        }

        private async Task ResponderMensaje(string chatId, string mensaje) {
            if (!BotTelegramConectado)
                return;

            try {
                var mensajeTemporal = await ServicioBotTelegram.EnviarMensajeAsync(new MensajeTelegram {
                    IdChat = chatId,
                    Texto = "🔄 Procesando..."
                });

                var mensajeReal = await ServicioBotTelegram.EnviarMensajeAsync(new MensajeTelegram {
                    IdChat = chatId,
                    Texto = mensaje
                });

                await ServicioBotTelegram.EliminarMensajeAsync(chatId, mensajeTemporal.IdMensaje);
                await RegistrarMensaje(chatId, mensajeReal.IdMensaje);
            } catch (Exception ex) {
                Console.WriteLine($"Error al responder mensaje: {ex.Message}");
            }
        }

        private async Task LimpiarChat(string chatId) {
            if (!_mensajesChat.ContainsKey(chatId) || _mensajesChat[chatId].Count == 0)
                return;

            try {
                foreach (var mensajeId in _mensajesChat[chatId]) {
                    await ServicioBotTelegram.EliminarMensajeAsync(chatId, mensajeId);
                }

                _mensajesChat[chatId].Clear();
            } catch (Exception ex) {
                Console.WriteLine($"Error al limpiar chat: {ex.Message}");
            }
        }

        private async Task EnviarDocumento(string chatId, Stream documentoStream, string nombreArchivo) {
            if (!BotTelegramConectado) return;

            try {
                documentoStream.Position = 0;

                var inputFile = new InputFileStream(
                    content: documentoStream,
                    fileName: nombreArchivo
                );

                await ServicioBotTelegram.EnviarDocumentoAsync(
                    chatId: chatId,
                    documento: inputFile,
                    caption: $"📄 Reporte: {nombreArchivo}"
                );
            } catch (Exception ex) {
                Console.WriteLine($"Error al enviar documento: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region Métodos de Limpieza
        public void DesconectarBotTelegram() {
            if (ServicioBotTelegram != null) {
                ServicioBotTelegram.Desconectar();
                ServicioBotTelegram.Dispose();
            }
        }
        #endregion
    }
}