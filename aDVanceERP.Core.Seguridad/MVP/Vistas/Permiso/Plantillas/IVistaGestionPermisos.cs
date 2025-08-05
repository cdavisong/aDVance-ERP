using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Permiso.Plantillas;

public interface IVistaGestionPermisos : IVistaContenedor, IGestorDatos {
    void AdicionarPermisoRol(string nombrePermiso = "");
}