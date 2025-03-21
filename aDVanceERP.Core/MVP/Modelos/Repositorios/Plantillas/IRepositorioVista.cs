using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas {
    public interface IRepositorioVista {
        void Registrar(string nombre, IVista vista);
        void Registrar(string nombre, IVista vista, Point coordenadas, Size dimensiones, string modoRedimensionado = "HV");
        IVista? Obtener(string nombre);
        void Inicializar(string nombre = "");
        void Mostrar(string nombre);
        void Restaurar(string nombre);
        void OcultarVista(string nombre);
        void OcultarVistas();
        void CerrarVista(string nombre);
        void CerrarVistas();
    }
}