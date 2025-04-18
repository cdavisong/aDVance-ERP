using aDVanceERP.Core.MVP.Modelos;

namespace aDVanceERP.Core.Utiles; 

public static class UtilesServidorScanner {
    public static readonly ServidorTCP Servidor = new();

    public static string ObtenerDireccionIpLocal() {
        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());

        foreach (var ip in host.AddressList) {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                return ip.ToString();
            }
        }

        return "No se encontró dirección IP";
    }
}