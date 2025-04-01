using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero.Plantillas; 

public interface IVistaRegistroMensajero : IVistaRegistro {
    string Nombre { get; set; }
    string NombreContacto { get; set; }

    void CargarNombresContactos(object[] nombresContactos);
}