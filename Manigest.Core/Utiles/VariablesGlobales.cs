namespace Manigest.Core.Utiles {
    public static class VariablesGlobales {
        public const int AlturaTuplaPredeterminada = 42;
        public static int TuplasMaximasContenedor = 0;
        public static int CoordenadaYUltimaTupla = 0;
        public const int AlturaBarraTituloPredeterminada = 51;

        public static string StringConexionBaseDatos { get; set; } = string.Empty;

        public static long ObtenerVariableIdNull(this object id) {
            var idString = id.ToString();

            return string.IsNullOrEmpty(idString) ? 0 : long.Parse(idString);
        }
    }
}
