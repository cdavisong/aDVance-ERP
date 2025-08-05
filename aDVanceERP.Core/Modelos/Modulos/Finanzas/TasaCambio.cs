namespace aDVanceERP.Core.Modelos.Modulos.Finanzas
{
    public class TasaCambio
    {
        public string? NombreDivisa { get; set; }
        public decimal Valor { get; set; }
        public DireccionCambioTasa Direccion { get; set; }
        public decimal MontoCambio { get; set; }
        public DateTime UltimaActualizacion { get; set; }

        private string ObtenerSimboloDireccion()
        {
            return Direccion switch
            {
                DireccionCambioTasa.Aumento => "↑",
                DireccionCambioTasa.Disminucion => "↓",
                _ => "→"
            };
        }

        public override string ToString()
        {
            return $"{NombreDivisa}: {Valor} {ObtenerSimboloDireccion()} {MontoCambio}";
        }
    }
}
