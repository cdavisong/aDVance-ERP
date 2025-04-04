using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Contacto.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores; 

public class PresentadorRegistroContacto : PresentadorRegistroBase<IVistaRegistroContacto, Contacto, DatosContacto,
    CriterioBusquedaContacto> {
    private TelefonoContacto _fijo;
    private TelefonoContacto _movil;

    public PresentadorRegistroContacto(IVistaRegistroContacto vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Contacto objeto) {
        Vista.Nombre = objeto.Nombre;
        Vista.TelefonoMovil = UtilesTelefonoContacto.ObtenerTelefonoContacto(objeto.Id, true) ?? string.Empty;
        Vista.TelefonoFijo = UtilesTelefonoContacto.ObtenerTelefonoContacto(objeto.Id, false) ?? string.Empty;
        Vista.CorreoElectronico = objeto.DireccionCorreoElectronico;
        Vista.Direccion = objeto.Direccion;
        Vista.Notas = objeto.Notas;
        Vista.ModoEdicionDatos = true;

        Objeto = objeto;
    }

    protected override async Task<Contacto?> ObtenerObjetoDesdeVista() {
        return new Contacto(Objeto?.Id ?? 0,
            Vista.Nombre,
            Vista.CorreoElectronico,
            Vista.Direccion,
            Vista.Notas
        );
    }

    /// <summary>
    ///     Registro o actualización de teléfonos para el contacto.
    /// </summary>
    protected override void RegistroAuxiliar() {
        var datosTelefonoContacto = new DatosTelefonoContacto();
        var telefonos = new List<TelefonoContacto>();

        // Teléfono móvil
        if (!string.IsNullOrEmpty(Vista.TelefonoMovil))
            telefonos.Add(new TelefonoContacto(
                _movil?.Id ?? 0,
                "+53",
                Vista.TelefonoMovil,
                CategoriaTelefonoContacto.Movil,
                Objeto?.Id ?? 0
            ));
        else if (Vista.ModoEdicionDatos && _movil.Id != 0)
            datosTelefonoContacto.Eliminar(_movil.Id);

        // Teléfono fijo
        if (!string.IsNullOrEmpty(Vista.TelefonoFijo))
            telefonos.Add(new TelefonoContacto(
                _fijo?.Id ?? 0,
                "+53",
                Vista.TelefonoFijo,
                CategoriaTelefonoContacto.Fijo,
                Objeto.Id
            ));
        else if (Vista.ModoEdicionDatos && _fijo.Id != 0)
            datosTelefonoContacto.Eliminar(_fijo.Id);

        foreach (var telefono in telefonos)
            if (Vista.ModoEdicionDatos && telefono.Id != 0)
                datosTelefonoContacto.Editar(telefono);
            else if (telefono.Id != 0)
                datosTelefonoContacto.Editar(telefono);
            else
                datosTelefonoContacto.Adicionar(telefono);
    }
}