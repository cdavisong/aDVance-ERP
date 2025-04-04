using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios; 

public class DatosMovimiento : RepositorioDatosBase<Movimiento, CriterioBusquedaMovimiento>, IRepositorioMovimiento {
    public override string ComandoCantidad() {
        return "SELECT COUNT(id_movimiento) FROM adv__movimiento;";
    }

    public override string ComandoAdicionar(Movimiento objeto) {
        return $"""
                INSERT INTO adv__movimiento (
                    id_articulo,
                    id_almacen_origen,
                    id_almacen_destino,
                    fecha,
                    cantidad_movida,
                    id_tipo_movimiento
                )
                VALUES (
                    '{objeto.IdArticulo}',
                    '{objeto.IdAlmacenOrigen}',
                    '{objeto.IdAlmacenDestino}',
                    '{objeto.Fecha:yyyy-MM-dd HH:mm:ss}',
                    '{objeto.CantidadMovida}',
                    '{objeto.IdTipoMovimiento}'
                );
                """;
    }

    public override string ComandoEditar(Movimiento objeto) {
        return $"""
                UPDATE adv__movimiento
                SET
                    id_articulo='{objeto.IdArticulo}',
                    id_almacen_origen='{objeto.IdAlmacenOrigen}',
                    id_almacen_destino='{objeto.IdAlmacenDestino}',
                    fecha='{objeto.Fecha:yyyy-MM-dd HH:mm:ss}',
                    cantidad_movida='{objeto.CantidadMovida}',
                    id_tipo_movimiento='{objeto.IdTipoMovimiento}'
                WHERE id_movimiento='{objeto.Id}';
                """;
    }

    public override string ComandoEliminar(long id) {
        return $"DELETE FROM adv__movimiento WHERE id_movimiento='{id}';";
    }

    public override string ComandoObtener(CriterioBusquedaMovimiento criterio, string dato) {
        string? comando;

        switch (criterio) {
            case CriterioBusquedaMovimiento.Id:
                comando = $"SELECT * FROM adv__movimiento WHERE id_movimiento='{dato}';";
                break;
            case CriterioBusquedaMovimiento.Articulo:
                comando =
                    $"SELECT m.* FROM adv__movimiento m JOIN adv__articulo a ON m.id_articulo = a.id_articulo WHERE LOWER(a.nombre) LIKE LOWER('%{dato}%');";
                break;
            case CriterioBusquedaMovimiento.AlmacenOrigen:
                comando =
                    $"SELECT * FROM adv__movimiento m JOIN adv__almacen a ON m.id_almacen_origen = a.id_almacen WHERE LOWER(a.nombre) LIKE LOWER('%{dato}%');";
                break;
            case CriterioBusquedaMovimiento.AlmacenDestino:
                comando =
                    $"SELECT * FROM adv__movimiento m JOIN adv__almacen a ON m.id_almacen_destino = a.id_almacen WHERE LOWER(a.nombre) LIKE LOWER('%{dato}%');";
                break;
            case CriterioBusquedaMovimiento.Fecha:
                comando = $"SELECT * FROM adv__movimiento WHERE DATE(fecha)='{dato}';";
                break;
            case CriterioBusquedaMovimiento.TipoMovimiento:
                comando =
                    $"SELECT (id_articulo, id_almacen_origen, id_almacen_destino, cantidad_movida, id_tipo_movimiento, fecha) " +
                    $"FROM adv__movimiento m " +
                    $"JOIN adv__tipo_movimiento tm " +
                    $"ON m.id_tipo_movimiento = tm.id_tipo_movimiento " +
                    $"WHERE LOWER(tm.nombre) LIKE LOWER('%{dato}%');";
                break;
            default:
                comando = "SELECT * FROM adv__movimiento;";
                break;
        }

        return comando;
    }

    public override Movimiento ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new Movimiento(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_movimiento")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_articulo")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen_origen")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen_destino")),
            lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("cantidad_movida")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_tipo_movimiento"))
        );
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT COUNT(1) FROM adv__movimiento WHERE id_movimiento='{dato}';";
    }
}