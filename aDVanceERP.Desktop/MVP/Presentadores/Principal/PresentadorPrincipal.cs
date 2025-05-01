using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Servicios.Telegram;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.MVP.Vistas.Principal;
using aDVanceERP.Desktop.MVP.Vistas.Principal.Plantillas;
using aDVanceERP.Modulos.CompraVenta;
using aDVanceERP.Modulos.Contactos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas;
using aDVanceERP.Modulos.Inventario;

namespace aDVanceERP.Desktop.MVP.Presentadores.Principal;

public partial class PresentadorPrincipal {
    private Empresa? _empresa;

    public PresentadorPrincipal() {
        Vista = new VistaPrincipal();
        Vista.Mostrar();

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

        // Verificar el registro de la empresa y mostrar la vista de Login
        using (var datosEmpresa = new DatosEmpresa()) {
            if (datosEmpresa.Cantidad() == 0)
                MostrarVistaRegistroEmpresa(this, EventArgs.Empty);
            else _isRegistroEmpresa = true;
        }

        if (_isRegistroEmpresa) {            
            MostrarVistaContenedorSeguridad(this, EventArgs.Empty);
            ActualizarDatosEmpresa();
        } else return;

        #region Característica : Servicio de Bot para administración de la aplicación en Telegram

        ServicioBotTelegram = new ServicioBotAdvanceErpTelegram();
        ServicioBotTelegram.MensajeRecibido += ProcesarMensajeBotTelegram;
        BotTelegramConectado = ServicioBotTelegram.ConectarAsync().Result;
        Vista.ServicioTelegramActivo = BotTelegramConectado;

        #endregion

        #region Característica : Servicio Scanner de códigos de barra y QR

        UtilesServidorScanner.Servidor.IniciarAsync(9002);

        #endregion
    }

    private void ActualizarDatosEmpresa() {
        using (var datosEmpresa = new DatosEmpresa()) {
            _empresa = datosEmpresa.Obtener().FirstOrDefault();

            if (_menuUsuario != null && _empresa != null) {
                _menuUsuario.Vista.LogotipoEmpresa = _empresa.Logotipo;
                _menuUsuario.Vista.NombreEmpresa = _empresa.Nombre;
                _menuUsuario.Vista.CorreoElectronico = UtilesContacto.ObtenerCorreoElectronicoContacto(_empresa.IdContacto);
            }
        }
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
        } catch (ExcepcionConexionServidorMySQL e) {
            CentroNotificaciones.Mostrar(e.Message, TipoNotificacion.Error);
        }
    }

    private void DisponerModulos(object? sender, EventArgs e) {
        _contenedorModulos?.Vista.Vistas?.Cerrar(true);
    }
}