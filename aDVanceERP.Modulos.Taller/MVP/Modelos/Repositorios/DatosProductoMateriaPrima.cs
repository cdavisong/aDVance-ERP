using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Taller.MVP.Modelos;
using aDVanceERP.Modulos.Taller.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Modulos.Taller.MVP.Modelos.Repositorios;

public class DatosProductoMateriaPrima : RepositorioDatosBase<ProductoMateriaPrima, CriterioBusquedaProductoMateriaPrima>, IRepositorioProductoMateriaPrima {
    public override string ComandoCantidad() {
        return """
            SELECT COUNT(id_producto_materia_prima) 
            FROM adv__producto_materia_prima;
            """;
    }

    public override string ComandoAdicionar(ProductoMateriaPrima objeto) {
        return $"""
            INSERT INTO adv__producto_materia_prima (
                id_producto,
                id_materia_prima,
                cantidad
            )
            VALUES (
                {objeto.IdProducto},
                {objeto.IdMateriaPrima},
                {objeto.Cantidad.ToString("0.00", CultureInfo.InvariantCulture)}
            );
            """;
    }

    public override string ComandoEditar(ProductoMateriaPrima objeto) {
        return $"""
            UPDATE adv__producto_materia_prima
            SET
                id_producto = {objeto.IdProducto},
                id_materia_prima = {objeto.IdMateriaPrima},
                cantidad = {objeto.Cantidad.ToString("0.00", CultureInfo.InvariantCulture)}
            WHERE id_producto_materia_prima = {objeto.Id};
            """;
    }

    public override string ComandoEliminar(long id) {
       return $"""
            DELETE FROM adv__producto_materia_prima 
            WHERE id_producto_materia_prima = {id};
            """;
    }

    public override string ComandoObtener(CriterioBusquedaProductoMateriaPrima criterio, string dato) {
        var comando = criterio switch {
            CriterioBusquedaProductoMateriaPrima.Todos => "SELECT * FROM adv__producto_materia_prima;",
            CriterioBusquedaProductoMateriaPrima.Id => $"SELECT * FROM adv__producto_materia_prima WHERE id_producto_materia_prima = {dato};",
            CriterioBusquedaProductoMateriaPrima.IdProducto => $"SELECT * FROM adv__producto_materia_prima WHERE id_producto = {dato};",
            CriterioBusquedaProductoMateriaPrima.IdMateriaPrima => $"SELECT * FROM adv__producto_materia_prima WHERE id_materia_prima = {dato};",
            _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
        };

        return comando;
    }

    public override ProductoMateriaPrima ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new ProductoMateriaPrima(
            id: lectorDatos.GetInt64("id_producto_materia_prima"),
            idProducto: lectorDatos.GetInt64("id_producto"),
            idMateriaPrima: lectorDatos.GetInt64("id_materia_prima"),
            cantidad: lectorDatos.GetFloat("cantidad")
        );
    }

    public override string ComandoExiste(string dato) {
        return $"""
            SELECT COUNT(1) 
            FROM adv__producto_materia_prima 
            WHERE id_producto_materia_prima = {dato};
            """;
    }
}