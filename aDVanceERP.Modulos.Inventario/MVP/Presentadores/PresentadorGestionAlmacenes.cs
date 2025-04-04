using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores; 

public class PresentadorGestionAlmacenes : PresentadorGestionBase<PresentadorTuplaAlmacen, IVistaGestionAlmacenes,
    IVistaTuplaAlmacen, Almacen, DatosAlmacen, CriterioBusquedaAlmacen> {
    public PresentadorGestionAlmacenes(IVistaGestionAlmacenes vista) : base(vista) { }

    protected override PresentadorTuplaAlmacen ObtenerValoresTupla(Almacen objeto) {
        var presentadorTupla = new PresentadorTuplaAlmacen(new VistaTuplaAlmacen(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.Nombre = objeto.Nombre;
        presentadorTupla.Vista.Direccion = objeto.Direccion;
        presentadorTupla.Vista.Notas = objeto.Notas;

        return presentadorTupla;
    }
}