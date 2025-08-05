using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.Repositorios.Comun;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Repositorios.Modulos.Finanzas;

public class RepoUnidadMedida : RepoBase<UnidadMedida, FiltroBusquedaUnidadMedida> {
    public RepoUnidadMedida(string nombreTabla, string columnaId) : base(nombreTabla, columnaId) {
    }

    public override (string query, Dictionary<string, object> parametros) GenerarQueryObtener(FiltroBusquedaUnidadMedida filtroBusqueda, string criterio) {
        string? query;
        Dictionary<string, object> parametros = new();
                
        switch (filtroBusqueda) {
            case FiltroBusquedaUnidadMedida.Id:
                query = """
                    SELECT * 
                    FROM adv__unidad_medida 
                    WHERE id_unidad_medida = @Criterio;
                    """;
                parametros.Add("@Criterio", criterio);
                break;
            case FiltroBusquedaUnidadMedida.Nombre:
                query = """
                    SELECT * 
                    FROM adv__unidad_medida 
                    WHERE nombre LIKE @Criterio;
                    """;
                parametros.Add("@Criterio", $"%{criterio}%");
                break;
            case FiltroBusquedaUnidadMedida.Abreviatura:
                query = """
                    SELECT * 
                    FROM adv__unidad_medida 
                    WHERE abreviatura LIKE @Criterio;
                    """;
                parametros.Add("@Criterio", $"%{criterio}%");
                break;
            default:
                query = """
                    SELECT * 
                    FROM adv__unidad_medida;
                    """;
                break;
        }

        return (query, parametros);
    }

    public override UnidadMedida MapearEntidad(MySqlDataReader lectorDatos) {
        return new UnidadMedida(lectorDatos);
    }
}

