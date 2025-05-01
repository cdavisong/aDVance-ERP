using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Servicios.Telegram;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Desktop.MVP.Vistas.ContenedorModulos.Plantillas;
using aDVanceERP.Desktop.MVP.Vistas.Principal.Plantillas;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos : PresentadorBase<IVistaContenedorModulos> {
    public PresentadorContenedorModulos(IVistaPrincipal vistaPrincipal, IVistaContenedorModulos vista) : base(vista) {
        VistaPrincipal = vistaPrincipal;

        // Eventos
        Vista.MostrarVistaEstadisticas += MostrarVistaContenedorEstadisticas;
        Vista.MostrarMenuContactos += MostrarVistaMenuContacto;
        Vista.MostrarMenuFinanzas += MostrarVistaMenuFinanzas;
        Vista.MostrarMenuInventario += MostrarVistaMenuInventario;
        Vista.MostrarMenuVentas += MostrarVistaMenuVentas;
        Vista.MostrarMenuSeguridad += MostrarVistaMenuSeguridad;

        #region Vista : Estadísticas

        InicializarVistaContenedorEstadisticas();

        #endregion

        #region Módulo : Contactos

        InicializarVistaMenuContacto();
        InicializarVistaGestionProveedores();
        InicializarVistaGestionMensajeros();
        InicializarVistaGestionClientes();
        InicializarVistaGestionContactos();

        #endregion

        #region Módulo : Finanzas

        InicializarVistaMenuFinanzas();
        InicializarVistaGestionCuentasBancarias();

        #endregion

        #region Módulo : Inventario

        InicializarVistaMenuInventario();
        InicializarVistaGestionArticulos();
        InicializarVistaGestionMovimientos();
        InicializarVistaGestionAlmacenes();

        #endregion

        #region Módulo : Compraventa

        InicializarVistaMenuCompraventas();
        InicializarVistaGestionCompras();
        InicializarVistaGestionVentas();

        #endregion

        #region Módulo : Seguridad

        InicializarVistaMenuSeguridad();
        InicializarVistaGestionCuentasUsuarios();
        InicializarVistaGestionRolesUsuarios();

        #endregion

        #region Característica : Servicio de Bot para administración de la aplicación en Telegram

        ServicioBotTelegram = new ServicioBotAdvanceErpTelegram();
        ServicioBotTelegram.MensajeRecibido += ProcesarMensajeBotTelegram;
        BotTelegramConectado = ServicioBotTelegram.ConectarAsync().Result;

        #endregion
    }

    private IVistaPrincipal VistaPrincipal { get; }

    public ServicioBotAdvanceErpTelegram ServicioBotTelegram { get; }

    public bool BotTelegramConectado { get; }
}