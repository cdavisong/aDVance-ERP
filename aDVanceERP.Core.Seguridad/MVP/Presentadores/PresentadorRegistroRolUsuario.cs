using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Vistas.Permiso.Plantillas;
using aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores; 

public class PresentadorRegistroRolUsuario : PresentadorRegistroBase<IVistaRegistroRolUsuario, RolUsuario,
    RepoRolUsuario, FiltroBusquedaRolUsuario> {
    public PresentadorRegistroRolUsuario(IVistaRegistroRolUsuario vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(RolUsuario objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.NombreRolUsuario = objeto.Nombre;        

        var permisosRoles = UtilesRolUsuario.ObtenerPermisosDeRol(objeto.Id);

        foreach (var permisoRol in permisosRoles) 
            ((IVistaGestionPermisos)Vista).AdicionarPermisoRol(permisoRol);

        Entidad = objeto;
    }

    protected override RolUsuario? ObtenerEntidadDesdeVista() {
        return new RolUsuario(
            Vista.ModoEdicionDatos && Entidad != null ? Entidad.Id : 0,
            Vista.NombreRolUsuario
        );
    }
}