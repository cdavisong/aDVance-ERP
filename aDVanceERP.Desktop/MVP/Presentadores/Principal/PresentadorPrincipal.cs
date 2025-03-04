using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Desktop.MVP.Vistas.Principal;
using aDVanceERP.Desktop.MVP.Vistas.Principal.Plantillas;
using aDVanceERP.Modulos.Contactos;
using aDVanceERP.Modulos.Finanzas;
using aDVanceERP.Modulos.Inventario;
using aDVanceERP.Modulos.Ventas;

namespace aDVanceERP.Desktop.MVP.Presentadores.Principal {
    public partial class PresentadorPrincipal {
        public PresentadorPrincipal() {
            Vista = new VistaPrincipal();

            // Eventos
            //Vista.SubMenuUsuario += MostrarSubMenuUsuario;
            Vista.Salir += DisponerModulos;

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

        private void InicializarPermisosModulos() {
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloContactos.Nombre, ModuloContactos.Permisos);
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloFinanzas.Nombre, ModuloFinanzas.Permisos);
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloInventario.Nombre, ModuloInventario.Permisos);
            UtilesSeguridadModulosAplicacion.InicializarPermisosModulo(ModuloVentas.Nombre, ModuloVentas.Permisos);
        }

        private void DisponerModulos(object? sender, EventArgs e) {
            _contenedorModulos?.Vista.Vistas?.Cerrar(true);
        }
    }
}
