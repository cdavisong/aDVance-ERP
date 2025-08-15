using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores; 

public class PresentadorGestionCuentasUsuarios : PresentadorGestionBase<PresentadorTuplaCuentaUsuario,
    IVistaGestionCuentasUsuarios, IVistaTuplaCuentaUsuario, CuentaUsuario, DatosCuentaUsuario,
    FiltroBusquedaCuentaUsuario> {
    public PresentadorGestionCuentasUsuarios(IVistaGestionCuentasUsuarios vista) : base(vista) {
        vista.AprobarSolicitudCuenta += OnAprobarSolicitudCuentaUsuario;
        vista.EditarDatos += OnEditarDatos;
    }

    protected override PresentadorTuplaCuentaUsuario ObtenerValoresTupla(CuentaUsuario objeto) {
        var presentadorTupla = new PresentadorTuplaCuentaUsuario(new VistaTuplaCuentaUsuario(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.NombreUsuario = objeto.Nombre;
        presentadorTupla.Vista.NombreRolUsuario = UtilesRolUsuario.ObtenerNombreRolUsuario(objeto.IdRolUsuario);
        presentadorTupla.Vista.EstadoCuentaUsuario = objeto.Aprobado ? "Activa" : "Esperando aprobación";
        presentadorTupla.ObjetoSeleccionado += OnCambioSeleccionObjeto;
        presentadorTupla.ObjetoDeseleccionado += OnCambioSeleccionObjeto;

        return presentadorTupla;
    }

    private void OnAprobarSolicitudCuentaUsuario(object? sender, EventArgs e) {
        var usuariosRol0 = 0;

        foreach (var tupla in _tuplasObjetos)
            if (tupla.TuplaSeleccionada) {
                if (tupla.Objeto.IdRolUsuario != 0) {
                    tupla.Objeto.Aprobado = true;

                    // Editar la cuenta de usuario
                    DatosObjeto.Editar(tupla.Objeto);
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

        RefrescarListaObjetos();
    }

    private void OnEditarDatos(object? sender, EventArgs e) {
        Vista.HabilitarBtnAprobacionSolicitudCuenta = false;
    }

    private void OnCambioSeleccionObjeto(object? sender, EventArgs e) {
        if (_tuplasObjetos.Any(t => t.TuplaSeleccionada)) {
            foreach (var tupla in _tuplasObjetos)
                if (tupla.TuplaSeleccionada) {
                    if (!tupla.Objeto.Aprobado) {
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

    protected override void Dispose(bool disposing) {
        Vista.AprobarSolicitudCuenta -= OnAprobarSolicitudCuentaUsuario;
        Vista.EditarDatos -= OnEditarDatos;

        base.Dispose(disposing);
    }
}