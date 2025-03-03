using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores {
    public class PresentadorGestionCuentasUsuarios : PresentadorGestionBase<PresentadorTuplaCuentaUsuario, IVistaGestionCuentasUsuarios, IVistaTuplaCuentaUsuario, CuentaUsuario, DatosCuentaUsuario, CriterioBusquedaCuentaUsuario> {
        public PresentadorGestionCuentasUsuarios(IVistaGestionCuentasUsuarios vista) : base(vista) {
            vista.AprobarSolicitudCuenta += AprobarSolicitudCuentaUsuario;
            vista.EditarDatos += delegate { Vista.HabilitarBtnAprobacionSolicitudCuenta = false; };
        }
            
        protected override PresentadorTuplaCuentaUsuario ObtenerValoresTupla(CuentaUsuario objeto) {
            var presentadorTupla = new PresentadorTuplaCuentaUsuario(new VistaTuplaCuentaUsuario(), objeto);

            presentadorTupla.Vista.NombreUsuario = objeto.Nombre;
            presentadorTupla.Vista.NombreRolUsuario = UtilesRolUsuario.ObtenerNombreRolUsuario(objeto.IdRolUsuario);
            presentadorTupla.Vista.EstadoCuentaUsuario = objeto.Aprobado ? "Activa" : "Esperando aprobación";
            presentadorTupla.ObjetoSeleccionado += CambiarVisibilidadBtnAprobacionCuentasUsuarios;
            presentadorTupla.ObjetoDeseleccionado += CambiarVisibilidadBtnAprobacionCuentasUsuarios;

            return presentadorTupla;
        }

        private void AprobarSolicitudCuentaUsuario(object? sender, EventArgs e) {
            var usuariosRol0 = 0;

            foreach (var tupla in _tuplasObjetos) {
                if (tupla.TuplaSeleccionada) {
                    if (tupla.Objeto.IdRolUsuario != 0) {
                        tupla.Objeto.Aprobado = true;

                        // Editar la cuenta de usuario
                        DatosObjeto.Editar(tupla.Objeto);
                    } else
                        usuariosRol0++;
                    
                    break;
                }
            }

            if (usuariosRol0 > 0)
                return;
            //Vista.Mensaje.Mostrar($"{(usuariosRol0 == 1 ? "El usuario" : "Existen usuarios")} seleccionado{(usuariosRol0 == 1 ? "" : "s")} {(usuariosRol0 == 1 ? "no tiene" : "sin")} un rolUsuario asignado, por lo que no se puede aprobar la solicitud de cuenta. Por favor, edite el usuario para asignarle un rol.", TipoMensaje.Error);
                        
            RefrescarListaObjetos();
        }

        private void CambiarVisibilidadBtnAprobacionCuentasUsuarios(object? sender, EventArgs e) {
            if (_tuplasObjetos.Any(t => t.TuplaSeleccionada)) {
                foreach (var tupla in _tuplasObjetos) {
                    if (tupla.TuplaSeleccionada) {
                        if (!tupla.Objeto.Aprobado)
                            Vista.HabilitarBtnAprobacionSolicitudCuenta = true;
                        else {
                            Vista.HabilitarBtnAprobacionSolicitudCuenta = false;
                            return;
                        }
                    }
                }
            } else Vista.HabilitarBtnAprobacionSolicitudCuenta = false;
        }
    }
}
