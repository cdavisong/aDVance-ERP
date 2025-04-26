using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas; 

public interface IVistaRegistroCliente : IVistaRegistro {    
    string? RazonSocial { get; set; }
    string? Numero { get; set; }
    string TelefonoMovil { get; set; }
    string TelefonoFijo { get; set; }
    string Direccion { get; set; }
}