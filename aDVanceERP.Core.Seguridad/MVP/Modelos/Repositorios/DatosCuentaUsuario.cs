using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios {
    public class DatosCuentaUsuario : RepositorioDatosBase<CuentaUsuario, CriterioBusquedaCuentaUsuario>, IRepositorioCuentaUsuario {
        public override string ComandoAdicionar(CuentaUsuario objeto) {
            throw new NotImplementedException();
        }

        public override string ComandoCantidad() {
            throw new NotImplementedException();
        }

        public override string ComandoEditar(CuentaUsuario objeto) {
            throw new NotImplementedException();
        }

        public override string ComandoEliminar(long id) {
            throw new NotImplementedException();
        }

        public override string ComandoExiste(string dato) {
            throw new NotImplementedException();
        }

        public override string ComandoObtener(CriterioBusquedaCuentaUsuario criterio, string dato) {
            throw new NotImplementedException();
        }

        public override CuentaUsuario ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            throw new NotImplementedException();
        }
    }
}
