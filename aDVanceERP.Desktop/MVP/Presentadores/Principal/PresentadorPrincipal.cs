using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Desktop.MVP.Vistas.Principal;
using aDVanceERP.Desktop.MVP.Vistas.Principal.Plantillas;
using aDVanceERP.Modulos.CompraVenta;
using aDVanceERP.Modulos.Contactos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas;
using aDVanceERP.Modulos.Inventario;
using aDVanceERP.Modulos.Taller;

namespace aDVanceERP.Desktop.MVP.Presentadores.Principal;

public partial class PresentadorPrincipal {
    private Empresa? _empresa;

    public PresentadorPrincipal() {
        Vista = new VistaPrincipal();
        Vista.Mostrar();

        // Eventos
        Vista.SubMenuUsuario += MostrarVistaMenuUsuario;

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

        // Otros
        MostrarVistaContenedorSeguridad(this, EventArgs.Empty);
    }

    public IVistaPrincipal Vista { get; }

    public long IdEmpresa {
        get => _empresa?.Id ?? 0;
        set {
            if (_empresa != null)
                _empresa.Id = value;
        }
    }

    private void InicializarPermisosModulos() {
        try {
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloContactos.Nombre, ModuloContactos.Permisos);
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloFinanzas.Nombre, ModuloFinanzas.Permisos);
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloInventario.Nombre, ModuloInventario.Permisos);
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloTaller.Nombre, ModuloTaller.Permisos);
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloCompraventa.Nombre, ModuloCompraventa.Permisos);
        } catch (ExcepcionConexionServidorMySQL e) {
            CentroNotificaciones.Mostrar(e.Message, TipoNotificacion.Error);
        }
    }

    private void DisponerModulos(object? sender, EventArgs e) {
        if (_contenedorModulos == null)
            return;

        _contenedorModulos.Vista.Vistas?.Cerrar(true);
    }
}