using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas {
    public interface IVistaTuplaCaja : IVistaTupla {
        string Id { get; set; }        
        string FechaApertura { get; set; }
        string SaldoInicial { get; set; }
        string SaldoActual { get; set; }
        string FechaCierre { get; set; }
        int Estado { get; set; }
        string NombreUsuario { get; set; }
    }
}
