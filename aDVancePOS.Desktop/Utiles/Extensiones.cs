using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles;

namespace aDVancePOS.Desktop.Utiles {
    public static class Extensiones {
        public static void EstablecerCoordenadasVistaRegistro(this IVista vista, int anchoContenedorVistas) {
            vista.Coordenadas = new Point(
                anchoContenedorVistas - vista.Dimensiones.Width,
                VariablesGlobales.AlturaBarraTituloPredeterminada
            );
        }

        public static void EstablecerDimensionesVistaRegistro(this IVista vista, int alturaContenedorVistas) {
            vista.Dimensiones = vista.Dimensiones with {
                Height = alturaContenedorVistas + VariablesGlobales.AlturaBarraPiePagina
            };
        }

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
