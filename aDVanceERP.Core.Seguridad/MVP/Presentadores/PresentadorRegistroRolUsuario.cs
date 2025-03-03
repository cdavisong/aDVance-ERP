using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores {
    public class PresentadorRegistroRolUsuario : PresentadorRegistroBase<IVistaRegistroRolUsuario, RolUsuario, DatosRolUsuario, CriterioBusquedaRolUsuario> {
        public PresentadorRegistroRolUsuario(IVistaRegistroRolUsuario vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(RolUsuario objeto) {
            Vista.NombreRolUsuario = objeto.Nombre;
            Vista.NivelAcceso = objeto.NivelAcceso;
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override RolUsuario? ObtenerObjetoDesdeVista() {
            return new RolUsuario(_objeto?.Id ?? 0,
                nombre: Vista.NombreRolUsuario,
                nivelAcceso: Vista.NivelAcceso
                );
        }
    }
}
