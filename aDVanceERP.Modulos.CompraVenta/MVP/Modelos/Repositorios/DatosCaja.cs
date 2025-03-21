using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

using System.Globalization;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios {

    public class DatosCaja : RepositorioDatosBase<Caja, CriterioBusquedaCaja>, IRepositorioCaja {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_caja) FROM adv__caja;";
        }

        public override string ComandoAdicionar(Caja objeto) {
            return $"INSERT INTO adv__caja (numero, saldo_inicial, fecha_apertura, notas) VALUES ({objeto.Numero}, {objeto.SaldoInicial.ToString(CultureInfo.InvariantCulture)}, '{objeto.FechaApertura:yyyy-MM-dd HH:mm:ss}', '{objeto.Notas}');";
        }

        public override string ComandoEditar(Caja objeto) {
            return $"UPDATE adv__caja SET numero={objeto.Numero}, saldo_inicial={objeto.SaldoInicial.ToString(CultureInfo.InvariantCulture)}, fecha_apertura='{objeto.FechaApertura:yyyy-MM-dd HH:mm:ss}', fecha_cierre='{(objeto.FechaCierre.HasValue ? objeto.FechaCierre.Value.ToString("yyyy-MM-dd HH:mm:ss") : "NULL")}', notas='{objeto.Notas}' WHERE id_caja={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM adv__caja WHERE id_caja={id};";
        }

        public override string ComandoObtener(CriterioBusquedaCaja criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaCaja.Id:
                    comando = $"SELECT * FROM adv__caja WHERE id_caja={dato};";
                    break;
                case CriterioBusquedaCaja.Numero:
                    comando = $"SELECT * FROM adv__caja WHERE numero={dato};";
                    break;
                case CriterioBusquedaCaja.FechaCierre:
                    comando = $"SELECT * FROM adv__caja WHERE DATE(fecha_cierre) = '{dato}';";
                    break;
                default:
                    comando = "SELECT * FROM adv__caja;";
                    break;
            }

            return comando;
        }

        public override Caja ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new Caja(
                id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_caja")),
                numero: lectorDatos.GetInt32(lectorDatos.GetOrdinal("numero")),
                saldoInicial: lectorDatos.GetDecimal(lectorDatos.GetOrdinal("saldo_inicial")),
                fechaApertura: lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_apertura")),
                fechaCierre: lectorDatos.IsDBNull(lectorDatos.GetOrdinal("fecha_cierre")) ? (DateTime?) null : lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_cierre"))
            ) { 
                Notas = lectorDatos.IsDBNull(lectorDatos.GetOrdinal("notas")) ? string.Empty : lectorDatos.GetString(lectorDatos.GetOrdinal("notas"))
            };
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT COUNT(1) FROM adv__caja WHERE id_caja = {dato};";
        }
    }
}
