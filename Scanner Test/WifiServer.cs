using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Scanner_Test; 

public class WifiServer {
    private TcpListener listener;
    private TcpClient client;
    private NetworkStream stream;
    private readonly int port;
    private CancellationTokenSource cts;

    public event Action<string> DataReceived;
    public event Action<string> StatusChanged;

    public bool IsRunning { get; private set; }

    public WifiServer(int port = 8080) {
        this.port = port;
    }

    public async Task StartAsync() {
        if (IsRunning) return;

        cts = new CancellationTokenSource();
        listener = new TcpListener(IPAddress.Any, port);

        try {
            listener.Start();
            IsRunning = true;
            OnStatusChanged($"Servidor iniciado en puerto {port}");

            while (!cts.Token.IsCancellationRequested) {
                try {
                    client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                    stream = client.GetStream();

                    var clientIp = ((IPEndPoint) client.Client.RemoteEndPoint).Address.ToString();
                    OnStatusChanged($"Cliente conectado: {clientIp}");

                    using (var reader = new StreamReader(stream, Encoding.UTF8)) {
                        while (!cts.Token.IsCancellationRequested && client.Connected) {
                            var data = await reader.ReadLineAsync();
                            if (data != null) {
                                OnDataReceived(data);
                            } else {
                                break; // Cliente desconectado
                            }
                        }
                    }
                } catch (OperationCanceledException) {
                    // Servidor detenido
                } catch (Exception ex) {
                    OnStatusChanged($"Error: {ex.Message}");
                } finally {
                    DisconnectClient();
                }
            }
        } finally {
            Stop();
        }
    }

    public void Stop() {
        if (!IsRunning) return;

        cts?.Cancel();
        listener?.Stop();
        DisconnectClient();

        IsRunning = false;
        OnStatusChanged("Servidor detenido");
    }

    private void DisconnectClient() {
        try {
            stream?.Close();
            client?.Close();
        } catch { } finally {
            stream = null;
            client = null;
        }
    }

    protected virtual void OnDataReceived(string data) {
        DataReceived?.Invoke(data);
    }

    protected virtual void OnStatusChanged(string status) {
        StatusChanged?.Invoke(status);
    }
}