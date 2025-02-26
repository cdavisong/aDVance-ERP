
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios {
    public class DatosRolUsuario : RepositorioDatosBase<RolUsuario, CriterioBusquedaRolUsuario>, IRepositorioRolUsuario {
        public override string ComandoAdicionar(RolUsuario objeto) {
            throw new NotImplementedException();
        }

        public override string ComandoCantidad() {
            throw new NotImplementedException();
        }

        public override string ComandoEditar(RolUsuario objeto) {
            throw new NotImplementedException();
        }

        public override string ComandoEliminar(long id) {
            throw new NotImplementedException();
        }

        public override string ComandoExiste(string dato) {
            throw new NotImplementedException();
        }

        public override string ComandoObtener(CriterioBusquedaRolUsuario criterio, string dato) {
            throw new NotImplementedException();
        }

        public override RolUsuario ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            throw new NotImplementedException();
        }
    }
}
