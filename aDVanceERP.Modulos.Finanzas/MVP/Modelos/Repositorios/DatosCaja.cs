using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios {
    public class DatosCaja : RepositorioDatosBase<Caja, CriterioBusquedaCaja>, IRepositorioCaja {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_caja) FROM adv__caja;";
        }

        public override string ComandoAdicionar(Caja objeto) {
            return $"INSERT INTO adv__caja (fecha_apertura, saldo_inicial, saldo_actual, fecha_cierre, id_cuenta_usuario) VALUES ('{objeto.FechaApertura:yyyy-MM-dd HH:mm:ss}', {objeto.SaldoInicial}, {objeto.SaldoActual}, '{objeto.FechaCierre:yyyy-MM-dd HH:mm:ss}', {objeto.IdCuentaUsuario});";
        }

        public override string ComandoEditar(Caja objeto) {
            return $"UPDATE adv__caja SET estado={(int) objeto.Estado}, saldo_actual={objeto.SaldoActual}, fecha_cierre='{objeto.FechaCierre:yyyy-MM-dd HH:mm:ss}' WHERE id_caja={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM adv__caja WHERE id_caja={id};";
        }

        public override string ComandoObtener(CriterioBusquedaCaja criterio, string dato) {
            switch (criterio) {
                case CriterioBusquedaCaja.Id:
                    return $"SELECT * FROM adv__caja WHERE id_caja={dato};";
                case CriterioBusquedaCaja.FechaApertura:
                    return $"SELECT * FROM adv__caja WHERE DATE(fecha_apertura) = '{dato}';";
                case CriterioBusquedaCaja.FechaCierre:
                    return $"SELECT * FROM adv__caja WHERE DATE(fecha_cierre) = '{dato}';";
                default:
                    return "SELECT * FROM adv__caja;";
            }
        }

        public override Caja ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new Caja(
                lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_caja")),
                lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_apertura")),
                lectorDatos.GetDecimal(lectorDatos.GetOrdinal("saldo_inicial")),
                lectorDatos.GetDecimal(lectorDatos.GetOrdinal("saldo_actual")),
                lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_cierre")),
                lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_cuenta_usuario"))
            ) {
                Estado = (EstadoCaja) lectorDatos.GetInt32(lectorDatos.GetOrdinal("estado"))
            };
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT COUNT(1) FROM adv__caja WHERE id_caja={dato};";
        }
    }
}
