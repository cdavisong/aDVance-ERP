using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Taller.Modelos;

using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Repositorios {
    public class RepoActividadProduccion : RepositorioDatosBase<ActividadProduccion, CriterioBusquedaActividadProduccion> {
        public override string ComandoCantidad() {
            return """
                SELECT COUNT(id_actividad_produccion) 
                FROM adv__actividad_produccion
                WHERE activo = 1;
                """;
        }

        public override string ComandoAdicionar(ActividadProduccion objeto) {
            return $"""
                INSERT INTO adv__actividad_produccion (
                    nombre,
                    tipo_costo,
                    costo,
                    descripcion,
                    activo
                )
                VALUES (
                    '{objeto.Nombre}',
                    '{objeto.TipoCosto}',
                    {objeto.Costo.ToString(CultureInfo.InvariantCulture)},
                    '{objeto.Descripcion?.Replace("'", "''") ?? string.Empty}',
                    1
                );
                """;
        }

        public override string ComandoEditar(ActividadProduccion objeto) {
            return $"""
                UPDATE adv__actividad_produccion
                SET
                    nombre = '{objeto.Nombre}',
                    tipo_costo = '{objeto.TipoCosto}',
                    costo = {objeto.Costo.ToString(CultureInfo.InvariantCulture)},
                    descripcion = '{objeto.Descripcion?.Replace("'", "''") ?? string.Empty}',
                    activo = {(objeto.Activo ? 1 : 0)}
                WHERE id_actividad_produccion = {objeto.Id};
                """;
        }

        public override string ComandoEliminar(long id) {
            return $"""
                -- Marcamos como inactivo en lugar de eliminar
                UPDATE adv__actividad_produccion
                SET activo = 0
                WHERE id_actividad_produccion = {id};
                """;
        }

        public override string ComandoObtener(CriterioBusquedaActividadProduccion criterio, string dato) {
            var baseQuery = "SELECT * FROM adv__actividad_produccion WHERE activo = 1";

            return criterio switch {
                CriterioBusquedaActividadProduccion.Todas => $"{baseQuery};",
                CriterioBusquedaActividadProduccion.Id => $"{baseQuery} AND id_actividad_produccion = {dato};",
                CriterioBusquedaActividadProduccion.Nombre => $"{baseQuery} AND nombre LIKE '%{dato}%';",
                CriterioBusquedaActividadProduccion.TipoCosto => $"{baseQuery} AND tipo_costo = '{dato}';",
                CriterioBusquedaActividadProduccion.Estado => $"{baseQuery} AND activo = {(dato == "Activo" ? 1 : 0)};",
                _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
            };
        }

        public override ActividadProduccion ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new ActividadProduccion {
                Id = lectorDatos.GetInt64("id_actividad_produccion"),
                Nombre = lectorDatos.GetString("nombre"),
                TipoCosto = (TipoCostoActividad) Enum.Parse(
                    typeof(TipoCostoActividad),
                    lectorDatos.GetString("tipo_costo")),
                Costo = lectorDatos.GetDecimal("costo"),
                Descripcion = lectorDatos.IsDBNull(lectorDatos.GetOrdinal("descripcion")) ?
                    null : lectorDatos.GetString("descripcion"),
                Activo = lectorDatos.GetBoolean("activo")
            };
        }

        public override string ComandoExiste(string dato) {
            return $"""
                SELECT COUNT(1) 
                FROM adv__actividad_produccion 
                WHERE nombre = '{dato}' AND activo = 1;
                """;
        }
    }
}