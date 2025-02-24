using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.QR.Plantillas {
    public interface IVistaQR : IVista {
        Image? QR { get; set; }

        void CargarCodigoQR(string datos);
    }
}
