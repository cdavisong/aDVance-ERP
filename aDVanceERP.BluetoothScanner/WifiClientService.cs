using System.Net.Sockets;
using System.Text;

namespace aDVanceERP.BluetoothScanner; 

public class WifiClientService {
    private TcpClient tcpClient;
    private NetworkStream networkStream;
    private const int PORT = 8080;

    public async Task<bool> ConnectToServer(string serverIp) {
        try {
            tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(serverIp, PORT).WaitAsync(TimeSpan.FromSeconds(5));

            networkStream = tcpClient.GetStream();
            return true;
        } catch (Exception ex) {
            System.Diagnostics.Debug.WriteLine($"Error de conexión: {ex.Message}");
            return false;
        }
    }

    public async Task SendData(string data) {
        try {
            if (networkStream?.CanWrite == true) {
                byte[] buffer = Encoding.UTF8.GetBytes(data + "\n");
                await networkStream.WriteAsync(buffer, 0, buffer.Length);
            }
        } catch (Exception ex) {
            System.Diagnostics.Debug.WriteLine($"Error al enviar: {ex.Message}");
        }
    }

    public void Disconnect() {
        try {
            networkStream?.Close();
            tcpClient?.Close();
        } catch { }
    }
}