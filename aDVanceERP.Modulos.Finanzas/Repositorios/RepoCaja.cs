using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Globalization;
using System.Text;

namespace aDVanceERP.Modulos.Finanzas.Repositorios {
    public class RepoCaja : RepositorioDatosEntidadBase<Caja, FbCaja> {
        public RepoCaja() : base("adv__caja", "id_caja") { }

        public override string[] FiltrosBusqueda => UtilesBusquedaCaja.FbCaja;

        protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(Caja entidad) {
            var query = $"""
                INSERT INTO {NombreTabla} (
                    fecha_apertura,
                    saldo_inicial,
                    saldo_actual,
                    fecha_cierre,
                    estado,
                    id_cuenta_usuario
                )
                VALUES (
                    @fecha_apertura,
                    @saldo_inicial,
                    @saldo_actual,
                    @fecha_cierre,
                    @estado,
                    @id_cuenta_usuario
                );
                """;

            var parametros = new Dictionary<string, object>
            {
                { "@fecha_apertura", entidad.FechaApertura },
                { "@saldo_inicial", entidad.SaldoInicial },
                { "@saldo_actual", entidad.SaldoActual },
                { "@fecha_cierre", entidad.FechaCierre },
                { "@estado", entidad.Estado.ToString() },
                { "@id_cuenta_usuario", entidad.IdCuentaUsuario }
            };

            return (query, parametros);
        }

        protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(Caja entidad) {
            var query = $"""
                UPDATE {NombreTabla}
                SET
                    estado = @estado,
                    saldo_actual = @saldo_actual,
                    fecha_cierre = @fecha_cierre
                WHERE {ColumnaId} = @id;
                """;

            var parametros = new Dictionary<string, object>
            {
                { "@estado", entidad.Estado.ToString() },
                { "@saldo_actual", entidad.SaldoActual },
                { "@fecha_cierre", entidad.FechaCierre },
                { "@id", entidad.Id }
            };

            return (query, parametros);
        }

        protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbCaja filtroBusqueda, string? datosComplementarios) {
            var whereClause = new StringBuilder();
            var parametros = new Dictionary<string, object>();

            switch (filtroBusqueda) {
                case FbCaja.Id:
                    whereClause.Append($"{ColumnaId} = @id");
                    parametros.Add("@id", datosComplementarios);
                    break;
                case FbCaja.FechaApertura:
                    whereClause.Append("DATE(fecha_apertura) = @fecha_apertura");
                    parametros.Add("@fecha_apertura", datosComplementarios);
                    break;
                case FbCaja.Estado:
                    whereClause.Append("estado = @estado");
                    parametros.Add("@estado", datosComplementarios);
                    break;
                case FbCaja.FechaCierre:
                    whereClause.Append("DATE(fecha_cierre) = @fecha_cierre");
                    parametros.Add("@fecha_cierre", datosComplementarios);
                    break;
                default:
                    whereClause.Append("1=1");
                    break;
            }

            return (whereClause.ToString(), parametros);
        }

        protected override Caja MapearEntidad(MySqlDataReader lectorDatos) {
            return new Caja(
                lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_caja")),
                lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_apertura")),
                lectorDatos.GetDecimal(lectorDatos.GetOrdinal("saldo_inicial")),
                lectorDatos.GetDecimal(lectorDatos.GetOrdinal("saldo_actual")),
                lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_cierre")),
                lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_cuenta_usuario"))
            ) {
                Estado = (EstadoCaja) Enum.Parse(typeof(EstadoCaja), lectorDatos.GetString(lectorDatos.GetOrdinal("estado")))
            };
        }

        // Eliminar movimientos de caja relacionados antes de eliminar la caja
        public override void Eliminar(Caja entidad, MySqlConnection? conexionBd = null) {
            var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());

            using (var transaccion = conexion.BeginTransaction()) {
                try {
                    var parametros = new Dictionary<string, object> { { "@id", entidad.Id } };

                    // 1. Eliminar movimientos de caja relacionados
                    var queryMov = @"DELETE FROM adv__movimiento_caja WHERE id_caja = @id;";
                    EjecutarComandoNoQuery(conexion, queryMov, parametros, transaccion);

                    // 2. Eliminar la caja
                    base.Eliminar(entidad, conexion);

                    transaccion.Commit();
                } catch {
                    transaccion.Rollback();
                    throw;
                } finally {
                    conexion.Close();
                }
            }
        }
    }
}
