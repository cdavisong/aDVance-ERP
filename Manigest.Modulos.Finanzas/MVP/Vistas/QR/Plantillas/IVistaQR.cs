using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Finanzas.MVP.Vistas.QR.Plantillas {
    public interface IVistaQR : IVista {
        Image? QR { get; set; }

        void CargarCodigoQR(string datos);
    }
}
