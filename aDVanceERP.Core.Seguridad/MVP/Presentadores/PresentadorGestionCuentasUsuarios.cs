using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas;
using aDVanceERP.Core.Seguridad.Repositorios;
using aDVanceERP.Core.Seguridad.Utiles;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores;

public class PresentadorGestionCuentasUsuarios : PresentadorGestionBase<PresentadorTuplaCuentaUsuario,
    IVistaGestionCuentasUsuarios, IVistaTuplaCuentaUsuario, CuentaUsuario, RepoCuentaUsuario,
    FbCuentaUsuario> {
    public PresentadorGestionCuentasUsuarios(IVistaGestionCuentasUsuarios vista) : base(vista) {
        vista.AprobarSolicitudCuenta += AprobarSolicitudCuentaUsuario;
        vista.EditarDatos += delegate { Vista.HabilitarBtnAprobacionSolicitudCuenta = false; };
    }

    protected override PresentadorTuplaCuentaUsuario ObtenerValoresTupla(CuentaUsuario objeto) {
        var presentadorTupla = new PresentadorTuplaCuentaUsuario(new VistaTuplaCuentaUsuario(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.NombreUsuario = objeto.Nombre;
        presentadorTupla.Vista.NombreRolUsuario = UtilesRolUsuario.ObtenerNombreRolUsuario(objeto.IdRolUsuario);
        presentadorTupla.Vista.EstadoCuentaUsuario = objeto.Aprobado ? "Activa" : "Esperando aprobación";
        presentadorTupla.EntidadSeleccionada += CambiarVisibilidadBtnAprobacionCuentasUsuarios;
        presentadorTupla.EntidadDeseleccionada += CambiarVisibilidadBtnAprobacionCuentasUsuarios;

        return presentadorTupla;
    }

    private void AprobarSolicitudCuentaUsuario(object? sender, EventArgs e) {
        var usuariosRol0 = 0;

        foreach (var tupla in _tuplasEntidades)
            if (tupla.TuplaSeleccionada) {
                if (tupla.Entidad.IdRolUsuario != 0) {
                    tupla.Entidad.Aprobado = true;

                    // Editar la cuenta de usuario
                    RepoDatosEntidad.Actualizar(tupla.Entidad);
                }
                else {
                    usuariosRol0++;
                }

                break;
            }

        if (usuariosRol0 > 0) {
            CentroNotificaciones.Mostrar(
                $"{(usuariosRol0 <= 1 ? "El usuario" : "Existen usuarios")} seleccionado{(usuariosRol0 == 1 ? "" : "s")} {(usuariosRol0 == 1 ? "no tiene" : "sin")} un rolUsuario asignado, por lo que no se puede aprobar la solicitud de cuenta. Por favor, edite el usuario para asignarle un rol.",
                TipoNotificacion.Advertencia);
            return;
        }

        Vista.HabilitarBtnAprobacionSolicitudCuenta = false;

        _ = PopularTuplasDatosEntidades();
    }

    private void CambiarVisibilidadBtnAprobacionCuentasUsuarios(object? sender, EventArgs e) {
        if (_tuplasEntidades.Any(t => t.TuplaSeleccionada)) {
            foreach (var tupla in _tuplasEntidades)
                if (tupla.TuplaSeleccionada) {
                    if (!tupla.Entidad.Aprobado) {
                        Vista.HabilitarBtnAprobacionSolicitudCuenta = true;
                    }
                    else {
                        Vista.HabilitarBtnAprobacionSolicitudCuenta = false;
                        return;
                    }
                }
        }
        else {
            Vista.HabilitarBtnAprobacionSolicitudCuenta = false;
        }
    }
}