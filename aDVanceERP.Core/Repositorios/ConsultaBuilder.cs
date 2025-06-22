namespace aDVanceERP.Core.Repositorios {
    public class ConsultaBuilder {
        public string FromClause { get; private set; }
        public string WhereClause { get; private set; } = "1=1";
        public Dictionary<string, object> Parametros { get; } = new Dictionary<string, object>();
        public string Query => $"SELECT * FROM {FromClause} WHERE {WhereClause}";

        public ConsultaBuilder(string fromClause) {
            FromClause = fromClause;
        }

        public ConsultaBuilder AgregarJoin(string joinClause) {
            FromClause += " " + joinClause;
            return this;
        }

        public ConsultaBuilder AgregarWhere(string condicion, Dictionary<string, object>? parametros = null) {
            WhereClause += $" AND {condicion}";
            if (parametros != null) {
                foreach (var param in parametros) {
                    Parametros.Add(param.Key, param.Value);
                }
            }
            return this;
        }
    }
}