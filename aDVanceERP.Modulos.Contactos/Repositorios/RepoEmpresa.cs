using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Modulos.Contactos.Repositorios {
    public class RepoEmpresa : RepositorioDatosEntidadBase<Empresa, FbEmpresa> {
        public RepoEmpresa() : base("adv__empresa", "id_empresa") { }

        public override string[] FiltrosBusqueda => UtilesBusquedaEmpresa.FbEmpresa;

        protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(Empresa entidad) {
            var query = $"""
                    INSERT INTO {NombreTabla} (
                        nombre,
                        id_contacto,
                        logotipo
                    )
                    VALUES (
                        @nombre,
                        @id_contacto,
                        @logotipo
                    );
                    """;

            var parametros = new Dictionary<string, object>
            {
                { "@nombre", entidad.Nombre ?? string.Empty },
                { "@id_contacto", entidad.IdContacto },
                { "@logotipo", entidad.Logotipo != null ? entidad.ObtenerDatosDbLogotipo() : DBNull.Value }
            };

            return (query, parametros);
        }

        protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(Empresa entidad) {
            var query = $"""
                    UPDATE {NombreTabla}
                    SET
                        nombre = @nombre,
                        id_contacto = @id_contacto,
                        logotipo = @logotipo
                    WHERE {ColumnaId} = @id;
                    """;

            var parametros = new Dictionary<string, object>
            {
                    { "@nombre", entidad.Nombre ?? string.Empty },
                    { "@id_contacto", entidad.IdContacto },
                    { "@logotipo", entidad.Logotipo != null ? entidad.ObtenerDatosDbLogotipo() : DBNull.Value },
                    { "@id", entidad.Id }
                };

            return (query, parametros);
        }

        protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbEmpresa filtroBusqueda, string? datosComplementarios) {
            var whereClause = new StringBuilder();
            var parametros = new Dictionary<string, object>();

            switch (filtroBusqueda) {
                case FbEmpresa.Id:
                    whereClause.Append($"{ColumnaId} = @id");
                    parametros.Add("@id", datosComplementarios);
                    break;
                case FbEmpresa.Nombre:
                    whereClause.Append("LOWER(nombre) LIKE LOWER(@nombre)");
                    parametros.Add("@nombre", $"%{datosComplementarios}%");
                    break;
                default:
                    whereClause.Append("1=1");
                    break;
            }

            return (whereClause.ToString(), parametros);
        }

        protected override Empresa MapearEntidad(MySqlDataReader lectorDatos) {
            var id = lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_empresa"));
            var nombre = lectorDatos.GetString(lectorDatos.GetOrdinal("nombre"));
            var idContacto = lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_contacto"));
            Image? logotipo = null;
            int idxLogotipo = lectorDatos.GetOrdinal("logotipo");
            if (!lectorDatos.IsDBNull(idxLogotipo)) {
                var bytes = (byte[]) lectorDatos.GetValue(idxLogotipo);
                var empresa = new Empresa();
                empresa.EstablecerLogotipoDesdeBytes(bytes);
                logotipo = empresa.Logotipo;
            }
            return new Empresa(id, logotipo, nombre, idContacto);
        }
    }
}
