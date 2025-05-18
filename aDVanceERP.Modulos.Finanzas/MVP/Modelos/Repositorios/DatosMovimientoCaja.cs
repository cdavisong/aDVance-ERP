using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Finanzas.MVP.Modelos.Repositorios {    
    public class DatosMovimientoCaja : RepositorioDatosBase<MovimientoCaja, CriterioBusquedaMovimientoCaja>, IRepositorioMovimientoCaja {
        // Implementar similar a la clase @DatosCaja
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_movimiento_caja) FROM adv__movimiento_caja;";
        }

        public override string ComandoAdicionar(MovimientoCaja objeto) {
            return $"""
                    INSERT INTO adv__movimiento_caja (fecha, monto, tipo, concepto, id_pago, id_usuario, observaciones)
                    VALUES (
                        {objeto.IdCaja},
                        '{objeto.Fecha:yyyy-MM-dd HH:mm:ss}',
                        {objeto.Monto},
                        '{objeto.Tipo}',
                        '{objeto.Concepto}',
                        {objeto.IdPago},
                        {objeto.IdUsuario},
                        '{objeto.Observaciones}'
                    );
                    """;
        }

        public override string ComandoEditar(MovimientoCaja objeto) {
            return $"""
                    UPDATE adv__movimiento_caja
                    SET
                        fecha='{objeto.Fecha:yyyy-MM-dd HH:mm:ss}',
                        monto={objeto.Monto},
                        tipo='{(int) objeto.Tipo}',
                        concepto='{objeto.Concepto}',
                        observaciones='{objeto.Observaciones}'
                    WHERE id_movimiento_caja={objeto.Id};
                    """;
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM adv__movimiento_caja WHERE id_movimiento_caja={id};";
        }

        public override string ComandoObtener(CriterioBusquedaMovimientoCaja criterio, string dato) {
            return criterio switch {
                CriterioBusquedaMovimientoCaja.Id => $"SELECT * FROM adv__movimiento_caja WHERE id_movimiento_caja={dato};",
                CriterioBusquedaMovimientoCaja.Fecha => $"SELECT * FROM adv__movimiento_caja WHERE DATE(fecha) = '{dato}';",
                CriterioBusquedaMovimientoCaja.Tipo => $"SELECT * FROM adv__movimiento_caja WHERE tipo='{dato}';",
                CriterioBusquedaMovimientoCaja.Concepto => $"SELECT * FROM adv__movimiento_caja WHERE concepto LIKE '%{dato}%';",
                _ => "SELECT * FROM adv__movimiento_caja;"
            };
        }

        public override MovimientoCaja ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new MovimientoCaja(
                lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_movimiento_caja")),
                lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_caja")),
                lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha")),
                lectorDatos.GetDecimal(lectorDatos.GetOrdinal("monto")),
                (TipoMovimientoCaja) Enum.Parse(typeof(EstadoCaja), lectorDatos.GetString(lectorDatos.GetOrdinal("tipo"))),
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
