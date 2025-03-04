using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Permiso.Plantillas {
    public interface IVistaGestionPermisos : IVistaContenedor, IGestorDatos {
        void AdicionarPermiso(string nombrePermiso = "");
    }
}
