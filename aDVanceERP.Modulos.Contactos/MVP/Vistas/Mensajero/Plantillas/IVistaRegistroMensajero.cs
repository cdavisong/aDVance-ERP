using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero.Plantillas;

public interface IVistaRegistroMensajero : IVistaRegistro {
    string Nombre { get; set; }
    string TelefonoMovil { get; set; }
}