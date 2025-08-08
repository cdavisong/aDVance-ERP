using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero.Plantillas;

public interface IVistaRegistroMensajero : IVistaRegistroEdicion {
    string Nombre { get; set; }
    string TelefonoMovil { get; set; }
}