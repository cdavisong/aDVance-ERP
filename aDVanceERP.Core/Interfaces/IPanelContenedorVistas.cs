using aDVanceERP.Core.Modelos.Comun;

namespace aDVanceERP.Core.Interfaces;

public interface IPanelContenedorVistas : IDisposable {
    Size Dimensiones { get; set; }
    bool Habilitar { get; set; }


    IDictionary<string, IVista> Vistas { get; }
    
    void AdicionarVista(IVista vista);
    void AdicionarVista(IVista vista, Point coordenadas, Size dimensiones, TipoRedimensionadoVista tipoRedimensionado);
    IVista ObtenerVista(string nombre);
    void MostrarVista(string nombre);
    void OcultarVista(string nombre);
    void OcultarVistas();
    void RestaurarVista(string nombre);
    void CerrarVista(string nombre);
    void CerrarVistas();
}
