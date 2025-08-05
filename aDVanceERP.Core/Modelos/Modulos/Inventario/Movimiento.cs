using aDVanceERP.Core.Interfaces.Comun;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Core.Modelos.Modulos.Inventario;

public class Movimiento : IEntidadBd {
    public Movimiento() { }

    public Movimiento(long id, long idProducto, long idAlmacenOrigen, long idAlmacenDestino, DateTime fecha,
        decimal cantidadMovida, long idTipoMovimiento) {
        Id = id;
        IdProducto = idProducto;
        IdAlmacenOrigen = idAlmacenOrigen;
        IdAlmacenDestino = idAlmacenDestino;
        Fecha = fecha;
        CantidadMovida = cantidadMovida;
        IdTipoMovimiento = idTipoMovimiento;
    }

    public Movimiento(MySqlDataReader reader) {
        Id = reader.GetInt32("id_movimiento");
        IdProducto = reader.GetInt32("id_producto");
        CostoUnitario = reader.GetDecimal("costo_unitario");
        CostoTotal = reader.GetDecimal("costo_total");
        IdAlmacenOrigen = reader.GetInt32("id_almacen_origen");
        IdAlmacenDestino = reader.GetInt32("id_almacen_destino");
        FechaCreacion = reader.GetDateTime("fecha_creacion");
        Estado = Enum.TryParse(reader.GetString("estado"), true, out EstadoMovimiento estado) ? estado : EstadoMovimiento.Pendiente;
        Fecha = reader.GetDateTime("fecha");
        SaldoInicial = reader.GetDecimal("saldo_inicial");
        CantidadMovida = reader.GetDecimal("cantidad_movida");
        SaldoFinal = reader.GetDecimal("saldo_final");
        IdTipoMovimiento = reader.GetInt32("id_tipo_movimiento");
        IdCuentaUsuario = reader.GetInt32("id_cuenta_usuario");
    }

    public long Id { get; set; }
    public long IdProducto { get; set; }
    public decimal CostoUnitario { get; set; }
    public decimal CostoTotal { get; set; }
    public long IdAlmacenOrigen { get; set; }
    public long IdAlmacenDestino { get; set; }
    public DateTime FechaCreacion { get; set; }
    public EstadoMovimiento Estado { get; set; }
    public DateTime Fecha { get; set; }
    public decimal SaldoInicial { get; set; }
    public decimal CantidadMovida { get; set; }
    public decimal SaldoFinal { get; set; }
    public long IdTipoMovimiento { get; set; }
    public long IdCuentaUsuario { get; set; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            UPDATE `adv__movimiento` 
            SET 
                id_movimiento = @Id 
                id_producto = @IdProducto, 
                costo_unitario = @CostoUnitario, 
                costo_total = @CostoTotal, 
                id_almacen_origen = @IdAlmacenOrigen, 
                id_almacen_destino = @IdAlmacenDestino, 
                fecha_creacion = @FechaCreacion, 
                estado = @Estado, 
                fecha = @Fecha, 
                saldo_inicial = @SaldoInicial,  
                cantidad_movida = @CantidadMovida,  
                saldo_final = @SaldoFinal, 
                id_tipo_movimiento = @IdTipoMovimiento, 
                id_cuenta_usuario = @IdCuentaUsuario 
            WHERE id_movimiento = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@IdProducto", IdProducto },
            { "@CostoUnitario", CostoUnitario.ToString("N2", CultureInfo.InvariantCulture) },
            { "@CostoTotal", CostoTotal.ToString("N2", CultureInfo.InvariantCulture) },
            { "@IdAlmacenOrigen", IdAlmacenOrigen },
            { "@IdAlmacenDestino", IdAlmacenDestino },
            { "@FechaCreacion", FechaCreacion.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) },
            { "@Estado", Estado.ToString() },
            { "@Fecha", Fecha.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) },
            { "@SaldoInicial", SaldoInicial.ToString("N2", CultureInfo.InvariantCulture) },
            { "@CantidadMovida", CantidadMovida.ToString("N2", CultureInfo.InvariantCulture) },
            { "@SaldoFinal", SaldoFinal.ToString("N2", CultureInfo.InvariantCulture) },
            { "@IdTipoMovimiento", IdTipoMovimiento },
            { "@IdCuentaUsuario", IdCuentaUsuario }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__movimiento` 
            VALUES ( 
                '',
                @IdProducto, 
                @CostoUnitario, 
                @CostoTotal, 
                @IdAlmacenOrigen, 
                @IdAlmacenDestino, 
                @FechaCreacion, 
                @Estado, 
                @Fecha, 
                @SaldoInicial, 
                @CantidadMovida, 
                @SaldoFinal, 
                @IdTipoMovimiento, 
                @IdCuentaUsuario
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@IdProducto", IdProducto },
            { "@CostoUnitario", CostoUnitario.ToString("N2", CultureInfo.InvariantCulture) },
            { "@CostoTotal", CostoTotal.ToString("N2", CultureInfo.InvariantCulture) },
            { "@IdAlmacenOrigen", IdAlmacenOrigen },
            { "@IdAlmacenDestino", IdAlmacenDestino },
            { "@FechaCreacion", FechaCreacion.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) },
            { "@Estado", Estado.ToString() },
            { "@Fecha", Fecha.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) },
            { "@SaldoInicial", SaldoInicial.ToString("N2", CultureInfo.InvariantCulture) },
            { "@CantidadMovida", CantidadMovida.ToString("N2", CultureInfo.InvariantCulture) },
            { "@SaldoFinal", SaldoFinal.ToString("N2", CultureInfo.InvariantCulture) },
            { "@IdTipoMovimiento", IdTipoMovimiento },
            { "@IdCuentaUsuario", IdCuentaUsuario }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            DELETE FROM `adv__movimiento` 
            WHERE id_movimiento = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum CriterioBusquedaMovimiento {
    Todos,
    Id,
    Producto,
    AlmacenOrigen,
    AlmacenDestino,
    Fecha,
    TipoMovimiento
}

public static class UtilesBusquedaMovimiento {
    public static object[] CriterioBusquedaMovimiento = {
        "Todos los movimientos",
        "Identificador de BD",
        "Nombre del producto",
        "Almacén de orígen",
        "Almacén de destino",
        "Fecha del movimiento",
        "Tipo de movimiento"
    };
}