using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.Repositorios;

public class DatosTipoMovimiento : RepoEntidadBaseDatos<TipoMovimiento, FiltroBusquedaTipoMovimiento>,
    IRepositorioTipoMovimiento
{
    public override string ComandoCantidad()
    {
        return "SELECT COUNT(id_tipo_movimiento) FROM adv__tipo_movimiento;";
    }

    public override string ComandoAdicionar(TipoMovimiento objeto)
    {
        return $"INSERT INTO adv__tipo_movimiento (nombre, efecto) VALUES ('{objeto.Nombre}', '{(int)objeto.Efecto}');";
    }

    public override string ComandoEditar(TipoMovimiento objeto)
    {
        return
            $"UPDATE adv__tipo_movimiento SET nombre='{objeto.Nombre}', efecto='{(int)objeto.Efecto}' WHERE id_tipo_movimiento='{objeto.Id}';";
    }

    public override string ComandoEliminar(long id)
    {
        return $"DELETE FROM adv__tipo_movimiento WHERE id_tipo_movimiento='{id}';";
    }

    public override string ComandoObtener(FiltroBusquedaTipoMovimiento criterio, string dato)
    {
        string comando;

        switch (criterio)
        {
            case FiltroBusquedaTipoMovimiento.Id:
                comando = $"SELECT * FROM adv__tipo_movimiento WHERE id_tipo_movimiento='{dato}';";
                break;
            case FiltroBusquedaTipoMovimiento.Nombre:
                comando = $"SELECT * FROM adv__tipo_movimiento WHERE LOWER(nombre) LIKE LOWER('%{dato}%');";
                break;
            default:
                comando = "SELECT * FROM adv__tipo_movimiento;";
                break;
        }

        return comando;
    }

    public override TipoMovimiento MapearEntidadBaseDatos(MySqlDataReader lectorDatos)
    {
        return new TipoMovimiento(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_tipo_movimiento")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            (EfectoMovimiento)lectorDatos.GetInt32(lectorDatos.GetOrdinal("efecto"))
        );
    }

    public override string ComandoExiste(string dato)
    {
        return $"SELECT COUNT(1) FROM adv__tipo_movimiento WHERE id_tipo_movimiento='{dato}';";
    }
}