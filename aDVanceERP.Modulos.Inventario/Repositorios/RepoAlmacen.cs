using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.Repositorios;

public class RepoAlmacen : RepoEntidadBaseDatos<Almacen, FiltroBusquedaAlmacen>, IRepoAlmacen {
    public RepoAlmacen() : base("adv__almacen", "id_almacen") { }

    protected override string GenerarComandoAdicionar(Almacen objeto) {
        return $"INSERT INTO adv__almacen (nombre, direccion, autorizo_venta, notas) VALUES ('{objeto.Nombre}', '{objeto.Direccion}', '{(objeto.AutorizoVenta ? 1 : 0)}', '{objeto.Notas}');";
    }

    protected override string GenerarComandoEditar(Almacen objeto) {
        return $"UPDATE adv__almacen SET nombre='{objeto.Nombre}', direccion='{objeto.Direccion}', autorizo_venta='{(objeto.AutorizoVenta ? 1 : 0)}', notas='{objeto.Notas}' WHERE id_almacen={objeto.Id};";
    }

    protected override string GenerarComandoEliminar(long id) {
        return $"DELETE FROM adv__almacen WHERE id_almacen={id};";
    }

    protected override string GenerarComandoObtener(FiltroBusquedaAlmacen criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case FiltroBusquedaAlmacen.Id:
                comando = $"SELECT * FROM adv__almacen WHERE id_almacen={dato};";
                break;
            case FiltroBusquedaAlmacen.Nombre:
                comando = $"SELECT * FROM adv__almacen WHERE LOWER(nombre) LIKE LOWER('%{dato}%');";
                break;
            default:
                comando = "SELECT * FROM adv__almacen;";
                break;
        }

        return comando;
    }

    protected override Almacen MapearEntidad(MySqlDataReader lectorDatos) {
        return new Almacen(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("direccion")),
            lectorDatos.GetBoolean(lectorDatos.GetOrdinal("autorizo_venta")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("notas"))
        );
    }
}