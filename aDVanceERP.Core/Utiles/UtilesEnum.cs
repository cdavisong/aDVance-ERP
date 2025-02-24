namespace aDVanceERP.Core.Utiles {
    public static class UtilesEnum {
        public static string ToVerboseString<C>(this C criterioBusqueda, string[] verbose) where C : Enum {
            int index = Convert.ToInt32(criterioBusqueda);
            if (index < 0 || index >= verbose.Length) {
                throw new ArgumentOutOfRangeException(nameof(criterioBusqueda), "El valor del criterio está fuera de los límites del array de descripciones.");
            }
            return verbose[index];
        }
    }
}
