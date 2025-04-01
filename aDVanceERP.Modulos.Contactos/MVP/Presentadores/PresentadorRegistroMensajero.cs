using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores; 

public class PresentadorRegistroMensajero : PresentadorRegistroBase<IVistaRegistroMensajero, Mensajero, DatosMensajero, CriterioBusquedaMensajero> {
    public PresentadorRegistroMensajero(IVistaRegistroMensajero vista) : base(vista) { }
    
    public override void PopularVistaDesdeObjeto(Mensajero objeto) {
        Vista.Nombre = objeto.Nombre;
        Vista.NombreContacto = UtilesContacto.ObtenerNombreContacto(objeto.IdContacto) ?? string.Empty;
        Vista.ModoEdicionDatos = true;

        Objeto = objeto;
    }

    protected override async Task<Mensajero?> ObtenerObjetoDesdeVista() {
        return new Mensajero(Objeto?.Id ?? 0,
                nombre: Vista.Nombre,
                activo: true,
                idContacto: await UtilesContacto.ObtenerIdContacto(Vista.NombreContacto)
            );
    }
}