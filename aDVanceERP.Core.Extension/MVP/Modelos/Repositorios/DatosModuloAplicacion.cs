using aDVanceERP.Core.Extension.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Extension.MVP.Modelos.Repositorios; 

internal class DatosModuloAplicacion : RepositorioDatosBase<ModuloAplicacion, FiltroBusquedaModuloAplicacion>,
    IRepositorioModuloAplicacion {
    public override string ComandoAdicionar(ModuloAplicacion objeto) {
        return $"INSERT INTO adv__modulo_aplicacion (nombre, version) VALUES ('{objeto.Nombre}', '{objeto.Version}');";
    }

    public override string ComandoCantidad() {
        return "SELECT COUNT(id_modulo_aplicacion) FROM adv__modulo_aplicacion;";
    }

    public override string ComandoEditar(ModuloAplicacion objeto) {
        return
            $"UPDATE adv__modulo_aplicacion SET nombre = '{objeto.Nombre}', version = {objeto.Version} WHERE id_modulo_aplicacion = {objeto.Id};";
    }

    public override string ComandoEliminar(long id) {
        return $"DELETE FROM adv__modulo_aplicacion WHERE id_modulo_aplicacion = {id};";
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT COUNT(1) FROM adv__modulo_aplicacion WHERE nombre = '{dato}';";
    }

    public override string ComandoObtener(FiltroBusquedaModuloAplicacion criterio, string dato) {
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

    public override ModuloAplicacion MapearEntidadBaseDatos(MySqlDataReader lectorDatos) {
        return new ModuloAplicacion(
            lectorDatos.GetInt64("id_modulo_aplicacion"),
            lectorDatos.GetString("nombre"),
            lectorDatos.GetString("version")
        );
    }
}