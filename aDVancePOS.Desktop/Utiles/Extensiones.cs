using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVancePOS.Desktop.Utiles {
    public static class Extensiones {
        public static void EstablecerCoordenadasVistaModal(this IVista vista, int anchoContenedorVistas) {
            vista.Coordenadas = new Point(
                anchoContenedorVistas / 2 - vista.Dimensiones.Width / 2,
                56
            );
        }

        public static void EstablecerDimensionesVistaModal(this IVista vista, Size dimensiones) {
            vista.Dimensiones = new Size(
                dimensiones.Width,
                dimensiones.Height
            );
        }
    }
}
