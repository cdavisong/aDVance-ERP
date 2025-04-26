using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas; 

public interface IVistaTuplaProveedor : IVistaTupla {
    string Id { get; set; }
    string RazonSocial { get; set; }
    string NumeroIdentificacionTributaria { get; set; }
    string Telefonos { get; set; }
    string Direccion { get; set; }
    string NombreRepresentante { get; set; }
}