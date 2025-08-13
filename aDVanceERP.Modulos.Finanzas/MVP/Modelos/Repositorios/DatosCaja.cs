using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

using System.Globalization;

namespace aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios {
    public class DatosCaja : RepositorioDatosBase<Caja, FiltroBusquedaCaja>, IRepositorioCaja {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_caja) FROM adv__caja;";
        }

        public override string ComandoAdicionar(Caja objeto) {
            return $"INSERT INTO adv__caja (fecha_apertura, saldo_inicial, saldo_actual, fecha_cierre, estado, id_cuenta_usuario) VALUES ('{objeto.FechaApertura:yyyy-MM-dd HH:mm:ss}', {objeto.SaldoInicial.ToString(CultureInfo.InvariantCulture)}, {objeto.SaldoActual.ToString(CultureInfo.InvariantCulture)}, '{objeto.FechaCierre:yyyy-MM-dd HH:mm:ss}', '{objeto.Estado}', {objeto.IdCuentaUsuario});";
        }

        public override string ComandoEditar(Caja objeto) {
            return $"UPDATE adv__caja SET estado='{objeto.Estado}', saldo_actual={objeto.SaldoActual.ToString(CultureInfo.InvariantCulture)}, fecha_cierre='{objeto.FechaCierre:yyyy-MM-dd HH:mm:ss}' WHERE id_caja={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $@"
                DELETE FROM adv__movimiento_caja WHERE id_caja={id};
                DELETE FROM adv__caja WHERE id_caja={id};
            ";
        }

        public override string ComandoObtener(FiltroBusquedaCaja criterio, string dato) {
            switch (criterio) {
                case FiltroBusquedaCaja.Id:
                    return $"SELECT * FROM adv__caja WHERE id_caja={dato};";
                case FiltroBusquedaCaja.FechaApertura:
                    return $"SELECT * FROM adv__caja WHERE DATE(fecha_apertura) = '{dato}';";
                case FiltroBusquedaCaja.Estado:
                    return $"SELECT * FROM adv__caja WHERE estado='{dato}';";
                case FiltroBusquedaCaja.FechaCierre:
                    return $"SELECT * FROM adv__caja WHERE DATE(fecha_cierre) = '{dato}';";
                default:
                    return "SELECT * FROM adv__caja;";
            }
        }

        public override Caja MapearEntidadBaseDatos(MySqlDataReader lectorDatos) {
            return new Caja(
                lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_caja")),
                lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_apertura")),
                lectorDatos.GetDecimal(lectorDatos.GetOrdinal("saldo_inicial")),
                lectorDatos.GetDecimal(lectorDatos.GetOrdinal("saldo_actual")),
                lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_cierre")),
                lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_cuenta_usuario"))
            ) {
                Estado = (EstadoCaja)Enum.Parse(typeof(EstadoCaja),
                lectorDatos.GetString(lectorDatos.GetOrdinal("estado"))),
            };
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT COUNT(1) FROM adv__caja WHERE id_caja={dato};";
        }
    }
}
