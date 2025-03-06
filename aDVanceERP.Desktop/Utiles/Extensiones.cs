using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Desktop.Utiles {
    public static class Extensiones {
        public static void EstablecerCoordenadasVistaRegistro(this IVista vista, int anchoContenedorVistas) {
            vista.Coordenadas = new Point(
                anchoContenedorVistas - vista.Dimensiones.Width - 20,
                VariablesGlobales.AlturaBarraTituloPredeterminada
            );
        }

        public static void EstablecerDimensionesVistaRegistro(this IVista vista, int alturaContenedorVistas) {
            vista.Dimensiones = new Size(
                vista.Dimensiones.Width,
                alturaContenedorVistas
            );
        }
    }
}
