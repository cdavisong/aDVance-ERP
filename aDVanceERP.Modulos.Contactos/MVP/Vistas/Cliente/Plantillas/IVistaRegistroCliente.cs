using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas {
    public interface IVistaRegistroCliente : IVistaRegistro {
        string? Numero { get; set; }
        string? RazonSocial { get; set; }
        string NombreContacto { get; set; }

        void CargarNombresContactos(object[] nombresContactos);
    }
}
