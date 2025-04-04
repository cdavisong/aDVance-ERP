using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Mensajeria.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores; 

public class PresentadorRegistroMensajeria : PresentadorRegistroBase<IVistaRegistroMensajeria, SeguimientoEntrega, DatosSeguimientoEntrega, CriterioBusquedaSeguimientoEntrega> {
    public PresentadorRegistroMensajeria(IVistaRegistroMensajeria vista) : base(vista) { }
    public override async void PopularVistaDesdeObjeto(SeguimientoEntrega objeto) {
        Vista.NombreMensajero = await UtilesMensajero.ObtenerNombreMensajero(objeto.IdMensajero);

        using (var datosVenta = new DatosVenta()) {
            var venta = datosVenta.Obtener(CriterioBusquedaVenta.Id, objeto.IdVenta.ToString()).FirstOrDefault();

            if (venta == null) 
                return;

            Vista.TipoEntrega = await UtilesMensajero.ObtenerNombreTipoEntrega(venta.IdTipoEntrega);
            Vista.Direccion = venta.DireccionEntrega;
        }

        Objeto = objeto;
    }

    protected override Task<SeguimientoEntrega?> ObtenerObjetoDesdeVista() {
        throw new NotImplementedException();
    }
}