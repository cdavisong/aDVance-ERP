using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas {
    public interface IVistaTuplaCliente : IVistaTupla {
        string Id { get; set; }
        string Numero { get; set; }
        string RazonSocial { get; set; }
        string NombreContacto { get; set; }
    }
}
