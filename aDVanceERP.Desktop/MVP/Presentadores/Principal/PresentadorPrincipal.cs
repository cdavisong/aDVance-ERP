using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Servicios.Telegram;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Desktop.MVP.Vistas.Principal;
using aDVanceERP.Desktop.MVP.Vistas.Principal.Plantillas;
using aDVanceERP.Modulos.CompraVenta;
using aDVanceERP.Modulos.Contactos;
using aDVanceERP.Modulos.Finanzas;
using aDVanceERP.Modulos.Inventario;

namespace aDVanceERP.Desktop.MVP.Presentadores.Principal; 

public partial class PresentadorPrincipal {
    public PresentadorPrincipal() {
        Vista = new VistaPrincipal();

        // Eventos
        Vista.SubMenuUsuario += MostrarVistaMenuUsuario;
        Vista.Salir += DisponerModulos;

        #region Menu de usuario

        InicializarVistaMenuUsuario();

        #endregion

        #region Contenedores

        InicializarVistaContenedorSeguridad();
        InicializarVistaContenedorModulos();

        #endregion

        #region Seguridad de los módulos en la aplicación

        InicializarPermisosModulos();

        #endregion

        #region Característica : Servicio de Bot para administración de la aplicación en Telegram

        ServicioBotTelegram = new ServicioBotAdvanceErpTelegram();
        ServicioBotTelegram.MensajeRecibido += ProcesarMensajeBotTelegram;
        BotTelegramConectado = ServicioBotTelegram.ConectarAsync().Result;
        Vista.ServicioTelegramActivo = BotTelegramConectado;        

        #endregion

        // Otros
        MostrarVistaContenedorSeguridad(this, EventArgs.Empty);

        // Iniciar el servidor TCP
        UtilesServidorScanner.Servidor.IniciarAsync(9002);
    }

    public IVistaPrincipal Vista { get; }

    public ServicioBotAdvanceErpTelegram ServicioBotTelegram { get; }

    public bool BotTelegramConectado { get; }

    private void InicializarPermisosModulos() {
        try {
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloContactos.Nombre, ModuloContactos.Permisos);
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloFinanzas.Nombre, ModuloFinanzas.Permisos);
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloInventario.Nombre, ModuloInventario.Permisos);
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloCompraventa.Nombre, ModuloCompraventa.Permisos);
        }
        catch (ExcepcionConexionServidorMySQL e) {
            CentroNotificaciones.Mostrar(e.Message, TipoNotificacion.Error);
        }
    }

    private void DisponerModulos(object? sender, EventArgs e) {
        _contenedorModulos?.Vista.Vistas?.Cerrar(true);
    }
}