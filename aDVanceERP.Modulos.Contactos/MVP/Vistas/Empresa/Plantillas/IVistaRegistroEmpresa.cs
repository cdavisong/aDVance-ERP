using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Empresa.Plantillas {
    public interface IVistaRegistroEmpresa : IVistaRegistro {
        Image? Logotipo { get; set; }
        string Nombre { get; set; }
        string TelefonoMovil { get; set; }
        string TelefonoFijo { get; set; }
        string CorreoElectronico { get; set; }
        string Direccion { get; set; }
    }
}
