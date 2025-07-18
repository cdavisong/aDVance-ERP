using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Taller.Interfaces {
    public interface IVistaRegistroOrdenProduccion : IVistaRegistro {
        string NumeroOrden { get; set; }
        DateTime FechaApertura { get; set; }
        string NombreProductoTerminado { get; set; }
        decimal Cantidad { get; set; }
        decimal MargenGanancia { get; set; }

        event EventHandler? MateriaPrimaEliminada;
        event EventHandler? ActividadProduccionEliminada;
        event EventHandler? GastoIndirectoEliminado;

        void CargarNombresProductosTerminados(string[] nombresProductosTerminados);
        void CargarNombresMateriasPrimas(string[] nombresMateriasPrimas);
        void CargarNombresActividadesProduccion(string[] nombresActividadesProduccion);
        void CargarConceptosGastosIndirectos(string[] conceptosGastosIndirectos);
        void AdicionarMateriaPrima(string nombre = "", decimal cantidad = 0m);
        void AdicionarActividadProduccion(string nombre = "", decimal cantidad = 0m);
        void AdicionarGastoIndirecto(string concepto = "", decimal cantidad = 0m);
    }
}