using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios; 

public class DatosDetallePagoTransferencia :
    RepositorioDatosEntidadBase<DetallePagoTransferencia, CriterioBusquedaDetallePagoTransferencia>,
    IRepositorioDetallePagoTransferencia {
    public override string ComandoCantidad() {
        return "SELECT COUNT(id_detalle_pago_transferencia) FROM adv__detalle_pago_transferencia;";
    }

    public override string ComandoAdicionar(DetallePagoTransferencia objeto) {
        return
            $"INSERT INTO adv__detalle_pago_transferencia (id_venta, id_tarjeta, numero_confirmacion, numero_transaccion) " +
            $"VALUES ({objeto.IdVenta}, {objeto.IdTarjeta}, '{objeto.NumeroConfirmacion}', '{objeto.NumeroTransaccion}');";
    }

    public override string ComandoEditar(DetallePagoTransferencia objeto) {
        return
            $"UPDATE adv__detalle_pago_transferencia SET id_venta = {objeto.IdVenta}, id_tarjeta = {objeto.IdTarjeta}, " +
            $"numero_confirmacion = '{objeto.NumeroConfirmacion}', numero_transaccion = '{objeto.NumeroTransaccion}' " +
            $"WHERE id_detalle_pago_transferencia = {objeto.Id};";
    }

    public override string ComandoEliminar(long id) {
        return $"DELETE FROM adv__detalle_pago_transferencia WHERE id_detalle_pago_transferencia = {id};";
    }

    public override string ComandoObtener(CriterioBusquedaDetallePagoTransferencia criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case CriterioBusquedaDetallePagoTransferencia.Id:
                comando =
                    $"SELECT * FROM adv__detalle_pago_transferencia WHERE id_detalle_pago_transferencia = {dato};";
                break;
            case CriterioBusquedaDetallePagoTransferencia.IdVenta:
                comando = $"SELECT * FROM adv__detalle_pago_transferencia WHERE id_venta = {dato};";
                break;
            case CriterioBusquedaDetallePagoTransferencia.IdTarjeta:
                comando = $"SELECT * FROM adv__detalle_pago_transferencia WHERE id_tarjeta = {dato};";
                break;
            default:
                comando = "SELECT * FROM adv__detalle_pago_transferencia;";
                break;
        }

        return comando;
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT COUNT(1) FROM adv__detalle_pago_transferencia WHERE id_detalle_pago_transferencia = {dato};";
    }

    public override DetallePagoTransferencia MapearEntidad(MySqlDataReader lectorDatos) {
        return new DetallePagoTransferencia(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_detalle_pago_transferencia")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_venta")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_tarjeta")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("numero_confirmacion")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("numero_transaccion"))
        );
    }
}