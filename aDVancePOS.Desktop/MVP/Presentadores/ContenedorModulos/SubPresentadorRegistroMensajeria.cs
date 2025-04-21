using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Mensajeria;
using aDVancePOS.Desktop.Utiles;

namespace aDVancePOS.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroMensajeria? _registroMensajeria;

    private List<string[]> DatosMensajeria { get; set; } = new();

    private async void InicializarVistaRegistroMensajeria() {
        _registroMensajeria = new PresentadorRegistroMensajeria(new VistaRegistroMensajeria());
        _registroMensajeria.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
        _registroMensajeria.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroMensajeria.Vista.CargarNombresMensajeros(await UtilesMensajero.ObtenerNombresMensajeros());

        #region Cargar tipos y descripciones de tipos de entregas

        var tiposDescripciones = await UtilesMensajero.ObtenerNombreDescripcionTiposEntrega();
        var tipos = new List<object>();
        var descripciones = new List<string>();

        foreach (var item in tiposDescripciones) {
            var partes = item.Split(':');

            if (partes.Length < 2)
                continue;

            tipos.Add(partes[0].Trim()); // Nombre (puede ser cualquier objeto)
            descripciones.Add(partes[1].Trim()); // Descripción
        }

        _registroMensajeria.Vista.CargarTiposEntrega(tipos.ToArray(), descripciones.ToArray());

        #endregion

        _registroMensajeria.Salir += delegate { DatosMensajeria = _registroMensajeria.Vista.DatosMensajeria; };

        DatosMensajeria.Clear();
    }

    private void MostrarVistaRegistroMensajeria(object? sender, EventArgs e) {
        InicializarVistaRegistroMensajeria();

        if (sender is not object[] datos) {
            throw new ArgumentNullException(nameof(datos));
        }

        if (_registroMensajeria == null) 
            return;
        
        MostrarVistaPanelTransparente(_registroMensajeria.Vista);
        
        _registroMensajeria.Vista.PopularDatosCliente(datos[0] as string[]);
        _registroMensajeria.Vista.PopularArticulosVenta(datos[1] as List<string[]>);

        _registroMensajeria.Vista.Mostrar();
        _registroMensajeria.Dispose();
    }

    private void RegistrarSeguimientoEntrega() {
        if (DatosMensajeria.Count == 0)
            return;

        using (var datosSeguimientoEntrega = new DatosSeguimientoEntrega()) {
            var ultimoIdVenta = UtilesBD.ObtenerUltimoIdTabla("venta");
            var idMensajero = UtilesMensajero.ObtenerIdMensajero(DatosMensajeria.ElementAt(0)[0]).Result;

            datosSeguimientoEntrega.Adicionar(new SeguimientoEntrega(
                0,
                ultimoIdVenta,
                idMensajero,
                DateTime.Now,
                DateTime.MinValue,
                DateTime.MinValue,
                "No hay observaciones"
            ));
        }
    }
}