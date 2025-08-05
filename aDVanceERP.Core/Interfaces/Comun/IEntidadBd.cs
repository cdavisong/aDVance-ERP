namespace aDVanceERP.Core.Interfaces.Comun;

public interface IEntidadBd {
    long Id { get; set; }

    #region CRUD querys :

    (string query, Dictionary<string, object> parametros) GenerarQueryUpdate();
    (string query, Dictionary<string, object> parametros) GenerarQueryInsert();
    (string query, Dictionary<string, object> parametros) GenerarQueryDelete();

    #endregion
}