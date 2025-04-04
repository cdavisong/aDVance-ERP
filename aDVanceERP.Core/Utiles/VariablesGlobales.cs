namespace aDVanceERP.Core.Utiles; 

public static class VariablesGlobales {
    public const int AlturaTuplaPredeterminada = 42;
    public const int AlturaBarraTituloPredeterminada = 56;
    public static readonly Color ColorResaltadoTupla = Color.FromArgb(252, 225, 205);
    public static int CoordenadaYUltimaTupla = 0;

    public static string StringConexionBaseDatos { get; set; } = string.Empty;

    public static long ObtenerVariableIdNull(this object id) {
        var idString = id.ToString();

        return string.IsNullOrEmpty(idString) ? 0 : long.Parse(idString);
    }
}