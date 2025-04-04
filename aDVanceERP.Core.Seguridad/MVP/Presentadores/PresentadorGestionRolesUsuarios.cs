using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario;
using aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores; 

public class PresentadorGestionRolesUsuarios : PresentadorGestionBase<PresentadorTuplaRolUsuario,
    IVistaGestionRolesUsuarios, IVistaTuplaRolUsuario, RolUsuario, DatosRolUsuario, CriterioBusquedaRolUsuario> {
    public PresentadorGestionRolesUsuarios(IVistaGestionRolesUsuarios vista) : base(vista) { }

    protected override PresentadorTuplaRolUsuario ObtenerValoresTupla(RolUsuario objeto) {
        var presentadorTupla = new PresentadorTuplaRolUsuario(new VistaTuplaRolUsuario(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.NombreRolUsuario = objeto.Nombre;
        presentadorTupla.Vista.CantidadPermisos = objeto.Nombre?.Equals("Administrador") ?? false
            ? UtilesPermiso.ObtenerTotalPermisos().ToString()
            : UtilesRolUsuario.CantidadPermisosRol(objeto.Id).ToString();
        presentadorTupla.Vista.CantidadUsuarios = UtilesRolUsuario.CantidadUsuariosNombreRol(objeto.Nombre).ToString();

        return presentadorTupla;
    }
}