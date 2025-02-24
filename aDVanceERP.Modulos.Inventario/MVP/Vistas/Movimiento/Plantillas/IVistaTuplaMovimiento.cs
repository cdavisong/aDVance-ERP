using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas {
    public interface IVistaTuplaMovimiento : IVistaTupla {
        string Id { get; set; }
        string NombreArticulo { get; set; }
        string NombreAlmacenOrigen { get; set; }
        string NombreAlmacenDestino { get; set; }
        string CantidadMovida { get; set; }
        string Motivo { get; set; }
        string Fecha { get; set; }

        void ActualizarIconoStock(bool movPositivo);
    }
}
