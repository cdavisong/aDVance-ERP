using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

using System.Globalization;

namespace aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios
{
    public class DatosMovimientoCaja : RepoEntidadBaseDatos<MovimientoCaja, FiltroBusquedaMovimientoCaja>, IRepositorioMovimientoCaja {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_movimiento_caja) FROM adv__movimiento_caja;";
        }

        public override string GenerarComandoInsertar(MovimientoCaja objeto) {
            return $"""
                    INSERT INTO adv__movimiento_caja (id_caja, fecha, monto, tipo, concepto, id_pago, id_usuario, observaciones)
                    VALUES (
                        {objeto.IdCaja},
                        '{objeto.Fecha:yyyy-MM-dd HH:mm:ss}',
                        {objeto.Monto.ToString(CultureInfo.InvariantCulture)},
                        '{objeto.Tipo}',
                        '{objeto.Concepto}',
                        {objeto.IdPago},
                        {objeto.IdUsuario},
                        '{objeto.Observaciones}'
                    );
                    """;
        }

        public override string GenerarComandoActualizar(MovimientoCaja objeto) {
            return $"""
                    UPDATE adv__movimiento_caja
                    SET
                        fecha='{objeto.Fecha:yyyy-MM-dd HH:mm:ss}',
                        monto={objeto.Monto.ToString(CultureInfo.InvariantCulture)},
                        tipo='{(int) objeto.Tipo}',
                        concepto='{objeto.Concepto}',
                        observaciones='{objeto.Observaciones}'
                    WHERE id_movimiento_caja={objeto.Id};
                    """;
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM adv__movimiento_caja WHERE id_movimiento_caja={id};";
        }

        public override string GenerarClausulaWhere(FiltroBusquedaMovimientoCaja criterio, string dato) {
            return criterio switch {
                FiltroBusquedaMovimientoCaja.Id => $"SELECT * FROM adv__movimiento_caja WHERE id_movimiento_caja={dato};",
                FiltroBusquedaMovimientoCaja.IdPago => $"SELECT * FROM adv__movimiento_caja WHERE id_pago={dato};",
                FiltroBusquedaMovimientoCaja.IdCaja => $"SELECT * FROM adv__movimiento_caja WHERE id_caja={dato};",
                FiltroBusquedaMovimientoCaja.Fecha => $"SELECT * FROM adv__movimiento_caja WHERE DATE(fecha) = '{dato}';",
                FiltroBusquedaMovimientoCaja.Tipo => $"SELECT * FROM adv__movimiento_caja WHERE tipo='{dato}';",
                FiltroBusquedaMovimientoCaja.Concepto => $"SELECT * FROM adv__movimiento_caja WHERE concepto LIKE '%{dato}%';",
                _ => "SELECT * FROM adv__movimiento_caja;"
            };
        }

        public override MovimientoCaja MapearEntidad(MySqlDataReader lectorDatos) {
            return new MovimientoCaja(
                lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_movimiento_caja")),
                lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_caja")),
                lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha")),
                lectorDatos.GetDecimal(lectorDatos.GetOrdinal("monto")),
                (TipoMovimientoCaja) Enum.Parse(typeof(TipoMovimientoCaja), lectorDatos.GetString(lectorDatos.GetOrdinal("tipo"))),
                lectorDatos.IsDBNull(lectorDatos.GetOrdinal("concepto")) ? null : lectorDatos.GetString(lectorDatos.GetOrdinal("concepto")),
                lectorDatos.IsDBNull(lectorDatos.GetOrdinal("id_pago")) ? 0 : lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_pago")),
                lectorDatos.IsDBNull(lectorDatos.GetOrdinal("id_usuario")) ? 0 : lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_usuario")),
                lectorDatos.IsDBNull(lectorDatos.GetOrdinal("observaciones")) ? null : lectorDatos.GetString(lectorDatos.GetOrdinal("observaciones"))
            );
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT COUNT(1) FROM adv__movimiento_caja WHERE id_movimiento_caja={dato};";
        }
    }
}
