using aDVanceERP.Core.Extension.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Repositorios.BD;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Extension.MVP.Modelos.Repositorios;

internal class RepoModuloAplicacion : RepoEntidadBaseDatos<ModuloAplicacion, FiltroBusquedaModuloAplicacion>, IRepoModuloAplicacion {
    public RepoModuloAplicacion() : base("adv__modulo_aplicacion", "id_modulo_aplicacion") { }

    protected override string GenerarComandoAdicionar(ModuloAplicacion objeto) {
        return $"INSERT INTO adv__modulo_aplicacion (nombre, version) VALUES ('{objeto.Nombre}', '{objeto.Version}');";
    }

    protected override string GenerarComandoEditar(ModuloAplicacion objeto) {
        return
            $"UPDATE adv__modulo_aplicacion SET nombre = '{objeto.Nombre}', version = {objeto.Version} WHERE id_modulo_aplicacion = {objeto.Id};";
    }

    protected override string GenerarComandoEliminar(long id) {
        return $"DELETE FROM adv__modulo_aplicacion WHERE id_modulo_aplicacion = {id};";
    }

    protected override string GenerarComandoObtener(FiltroBusquedaModuloAplicacion criterio, string dato) {
        string comando;
        switch (criterio) {
            case FiltroBusquedaModuloAplicacion.Id:
                comando = $"SELECT * FROM adv__modulo_aplicacion WHERE id_modulo_aplicacion = {dato};";
                break;
            case FiltroBusquedaModuloAplicacion.Nombre:
                comando = $"SELECT * FROM adv__modulo_aplicacion WHERE LOWER(nombre) LIKE LOWER('%{dato}%');";
                break;
            default:
                comando = "SELECT * FROM adv__modulo_aplicacion;";
                break;
        }

        return comando;
    }

    protected override ModuloAplicacion MapearEntidad(MySqlDataReader lectorDatos) {
        return new ModuloAplicacion(
            lectorDatos.GetInt64("id_modulo_aplicacion"),
            lectorDatos.GetString("nombre"),
            lectorDatos.GetString("version")
        );
    }
}