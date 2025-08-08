namespace aDVanceERP.Core.Interfaces;

public interface IEntidadBd {
    long Id { get; set; }

    #region CRUD querys :

    (string query, Dictionary<string, object> parametros) GenerarQueryUpdate();
    (string query, Dictionary<string, object> parametros) GenerarQueryInsert();
    (string query, Dictionary<string, object> parametros) GenerarQueryDelete();

    #endregion
}