using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Taller.Modelos;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Taller.Repositorios;

public class RepoCostoProduccion : RepositorioDatosBase<CostoProduccion, FiltroBusquedaCostoProduccion> {
    public override string ComandoCantidad() {
        return """
            SELECT COUNT(id_costo_produccion) 
            FROM adv__costo_produccion;
            """;
    }

    public override string ComandoAdicionar(CostoProduccion objeto) {
        return $"""
            INSERT INTO adv__costo_produccion (
                id_producto,
                costo_materia_prima,
                costo_mano_obra,
                costo_indirecto_fabricacion,
                costo_total,
                fecha_registro,
                observaciones
            )
            VALUES (
                {objeto.IdProducto},
                {objeto.CostoMateriaPrima},
                {objeto.CostoManoObra},
                {objeto.CostoIndirectoFabricacion},
                {objeto.CostoTotal},
                '{objeto.FechaRegistro:yyyy-MM-dd HH:mm:ss}',
                {(objeto.Observaciones != null ? $"'{MySqlHelper.EscapeString(objeto.Observaciones)}'" : "NULL")}
            );
            """;
    }

    public override string ComandoEditar(CostoProduccion objeto) {
        return $"""
            UPDATE adv__costo_produccion
            SET
                id_producto = {objeto.IdProducto},
                costo_materia_prima = {objeto.CostoMateriaPrima},
                costo_mano_obra = {objeto.CostoManoObra},
                costo_indirecto_fabricacion = {objeto.CostoIndirectoFabricacion},
                costo_total = {objeto.CostoTotal},
                fecha_registro = '{objeto.FechaRegistro:yyyy-MM-dd HH:mm:ss}',
                observaciones = {(objeto.Observaciones != null ? $"'{MySqlHelper.EscapeString(objeto.Observaciones)}'" : "NULL")}
            WHERE id_costo_produccion = {objeto.Id};
            """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
            DELETE FROM adv__costo_produccion 
            WHERE id_costo_produccion = {id};
            """;
    }

    public override string ComandoObtener(FiltroBusquedaCostoProduccion criterio, string dato) {
        var comando = criterio switch {
            FiltroBusquedaCostoProduccion.Todos => "SELECT * FROM adv__costo_produccion;",
            FiltroBusquedaCostoProduccion.Id => $"SELECT * FROM adv__costo_produccion WHERE id_costo_produccion = {dato};",
            FiltroBusquedaCostoProduccion.IdProducto => $"SELECT * FROM adv__costo_produccion WHERE id_producto = {dato};",
            FiltroBusquedaCostoProduccion.Fecha => $"SELECT * FROM adv__costo_produccion WHERE DATE(fecha_registro) = '{MySqlHelper.EscapeString(dato)}';",
            _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
        };

        return comando;
    }

    public override CostoProduccion ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new CostoProduccion(
            lectorDatos.GetInt64("id_costo_produccion"),
            lectorDatos.GetInt64("id_producto"),
            lectorDatos.GetDecimal("costo_materia_prima"),
            lectorDatos.GetDecimal("costo_mano_obra"),
            lectorDatos.GetDecimal("costo_indirecto_fabricacion"),
            lectorDatos.GetDecimal("costo_total"),
            lectorDatos.IsDBNull(lectorDatos.GetOrdinal("observaciones")) ? null : lectorDatos.GetString("observaciones")
        ) {
            FechaRegistro = lectorDatos.GetDateTime("fecha_registro")
        };
    }

    public override string ComandoExiste(string dato) {
        return $"""
            SELECT COUNT(1) 
            FROM adv__costo_produccion 
            WHERE id_costo_produccion = {dato};
            """;
    }
}