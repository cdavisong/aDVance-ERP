using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas {
    public interface IVistaRegistroMovimiento : IVistaRegistro {
        string NombreArticulo { get; set; }
        string NombreAlmacenOrigen { get; set; }
        string NombreAlmacenDestino { get; set; }
        int CantidadInicialOrigen { get; set; }
        int CantidadMovida { get; set; }
        int CantidadFinalOrigen { get; }
        string Motivo { get; set; }
        DateTime Fecha { get; set; }

        void CargarNombresArticulos(string[] nombresArticulos);
        void CargarNombresAlmacenes(string[] nombresAlmacenes);
        void CargarMotivos(string[] motivos);
        void ActualizarCamposAlmacenes();
    }
}
