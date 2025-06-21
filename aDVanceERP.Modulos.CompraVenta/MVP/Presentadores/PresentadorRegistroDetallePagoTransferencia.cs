using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetallePagoTransferencia.Plantillas;
using aDVanceERP.Modulos.CompraVenta.Repositorios;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;

public class PresentadorRegistroDetallePagoTransferencia : PresentadorRegistroBase<
    IVistaRegistroDetallePagoTransferencia, DetallePagoTransferencia, DatosDetallePagoTransferencia,
    CriterioBusquedaDetallePagoTransferencia> {
    public PresentadorRegistroDetallePagoTransferencia(IVistaRegistroDetallePagoTransferencia vista) : base(vista) { }

    public override void PopularVistaDesdeEntidad(DetallePagoTransferencia objeto) {
        throw new NotImplementedException();
    }

    protected override bool DatosEntidadCorrectos() {
        var aliasOk = !string.IsNullOrEmpty(Vista.Alias);
        var numeroTelefonoOk = !string.IsNullOrEmpty(Vista.NumeroConfirmacion); ;
        var numeroTransaccionOk = !string.IsNullOrEmpty(Vista.NumeroTransaccion);

        if (!aliasOk)
            CentroNotificaciones.Mostrar("El campo de alias es obligatorio para registro de una transferencia bancaria, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        if (!numeroTelefonoOk)
            CentroNotificaciones.Mostrar("Debe especificar un número de teléfono de confirmación para la transferencia bancaria, el campo no puede estar vacío ni contener caracteres incorrectos", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        if (!numeroTransaccionOk)
            CentroNotificaciones.Mostrar("Debe especificar un número de transacción al recibir el SMS de confirmación para la transferencia bancaria, el campo no puede estar vacío", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

        return aliasOk && numeroTelefonoOk && numeroTransaccionOk;
    }

    protected override async Task<DetallePagoTransferencia?> ObtenerEntidadDesdeVista() {
        throw new NotImplementedException();
    }
}