using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Globalization;
using System.Text;

namespace aDVanceERP.Modulos.Finanzas.Repositorios {    
public class RepoMovimientoCaja : RepositorioDatosEntidadBase<MovimientoCaja, FbMovimientoCaja> {
        public RepoMovimientoCaja() : base("adv__movimiento_caja", "id_movimiento_caja") { }

        public override string[] FiltrosBusqueda => UtilesBusquedaMovimientoCaja.FbMovimientoCaja;

        protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(MovimientoCaja entidad) {
            var query = $"""
            INSERT INTO {NombreTabla} (
                id_caja,
                fecha,
                monto,
                tipo,
                concepto,
                id_pago,
                id_usuario,
                observaciones
            )
            VALUES (
                @id_caja,
                @fecha,
                @monto,
                @tipo,
                @concepto,
                @id_pago,
                @id_usuario,
                @observaciones
            );
            """;

            var parametros = new Dictionary<string, object>
            {
            { "@id_caja", entidad.IdCaja },
            { "@fecha", entidad.Fecha },
            { "@monto", entidad.Monto },
            { "@tipo", entidad.Tipo.ToString() },
            { "@concepto", entidad.Concepto ?? string.Empty },
            { "@id_pago", entidad.IdPago },
            { "@id_usuario", entidad.IdUsuario },
            { "@observaciones", entidad.Observaciones ?? string.Empty }
        };

            return (query, parametros);
        }

        protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(MovimientoCaja entidad) {
            var query = $"""
            UPDATE {NombreTabla}
            SET
                fecha = @fecha,
                monto = @monto,
                tipo = @tipo,
                concepto = @concepto,
                observaciones = @observaciones
            WHERE {ColumnaId} = @id;
            """;

            var parametros = new Dictionary<string, object>
            {
            { "@fecha", entidad.Fecha },
            { "@monto", entidad.Monto },
            { "@tipo", entidad.Tipo.ToString() },
            { "@concepto", entidad.Concepto ?? string.Empty },
            { "@observaciones", entidad.Observaciones ?? string.Empty },
            { "@id", entidad.Id }
        };

            return (query, parametros);
        }

        protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbMovimientoCaja filtroBusqueda, string? datosComplementarios) {
            var whereClause = new StringBuilder();
            var parametros = new Dictionary<string, object>();

            switch (filtroBusqueda) {
                case FbMovimientoCaja.Id:
                    whereClause.Append($"{ColumnaId} = @id");
                    parametros.Add("@id", datosComplementarios);
                    break;
                case FbMovimientoCaja.IdPago:
                    whereClause.Append("id_pago = @id_pago");
                    parametros.Add("@id_pago", datosComplementarios);
                    break;
                case FbMovimientoCaja.IdCaja:
                    whereClause.Append("id_caja = @id_caja");
                    parametros.Add("@id_caja", datosComplementarios);
                    break;
                case FbMovimientoCaja.Fecha:
                    whereClause.Append("DATE(fecha) = @fecha");
                    parametros.Add("@fecha", datosComplementarios);
                    break;
                case FbMovimientoCaja.Tipo:
                    whereClause.Append("tipo = @tipo");
                    parametros.Add("@tipo", datosComplementarios);
                    break;
                case FbMovimientoCaja.Concepto:
                    whereClause.Append("concepto LIKE @concepto");
                    parametros.Add("@concepto", $"%{datosComplementarios}%");
                    break;
                default:
                    whereClause.Append("1=1");
                    break;
            }

            return (whereClause.ToString(), parametros);
        }

        protected override MovimientoCaja MapearEntidad(MySqlDataReader lectorDatos) {
            return new MovimientoCaja(
                lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_movimiento_caja")),
                lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_caja")),
                lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha")),
                lectorDatos.GetDecimal(lectorDatos.GetOrdinal("monto")),
                (TipoMovimientoCaja) Enum.Parse(typeof(TipoMovimientoCaja), lectorDatos.GetString(lectorDatos.GetOrdinal("tipo"))),
                lectorDatos.IsDBNull(lectorDatos.GetOrdinal("concepto")) ? null : lectorDatos.GetString(lectorDatos.GetOrdinal("concepto")),
                lectorDatos.IsDBNull(lectorDatos.GetOrdinal("id_pago")) ? 0 : lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_pago")),
                lectorDatos.IsDBNull(lectorDatos.GetOrdinal("id_usuario")) ? 0 : lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_usuario")),
                lectorDatos.IsDBNull(lectorDatos.GetOrdinal("observaciones")) ? null : lectorDatos.GetString(lectorDatos.GetOrdinal("observaciones"))
            );
        }
    }
}
