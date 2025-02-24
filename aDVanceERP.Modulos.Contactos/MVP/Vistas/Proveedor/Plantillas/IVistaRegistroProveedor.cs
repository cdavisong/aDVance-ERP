using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas {
    public interface IVistaRegistroProveedor : IVistaRegistro {
        string RazonSocial { get; set; }
        string NumeroIdentificacionTributaria { get; set; }
        string NombreRepresentante { get; set; }

        void CargarNombresContactos(string[] nombresContactos);
    }
}
