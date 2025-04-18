using System.Net.Sockets;
using System.Text;

namespace aDVanceSCANNER.MVP.Modelos;

public class ClienteTCP : IDisposable {
    private readonly ConfiguracionRed _configuracionRed;

    private TcpClient? _clienteTcp;
    private NetworkStream? _hiloRed;

    public ClienteTCP() {
        _configuracionRed = new ConfiguracionRed();
    }

    public ClienteTCP(ConfiguracionRed configuracionRed) {
        _configuracionRed = configuracionRed;
    }

    public bool EstablecerDireccionIp(string direccionIP) {
        return _configuracionRed.EstablecerDireccionIp(direccionIP);
    }

    public bool EstablecerPuerto(int puerto) {
        return _configuracionRed.EstablecerPuerto(puerto);
    }

    public string Conectar() {
        try {
            // Cerrar la conexión existente
            if (_clienteTcp != null) {
                _hiloRed?.Close();
                _clienteTcp?.Close();
            }

            // Crear una nueva conexión
            if (_configuracionRed.DireccionIP == null)
                return "La dirección IP especificada no es válida o no existe";

            _clienteTcp = new TcpClient();
            _clienteTcp.Connect(_configuracionRed.DireccionIP, _configuracionRed.Puerto);
            _hiloRed = _clienteTcp.GetStream();
            
            return $"Conectado a {_configuracionRed.DireccionIP}";
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public string Enviar(string datos) {
        if (_hiloRed?.CanWrite != true) 
            return "No hay conexión de red activa";

        var bytesDatos = Encoding.UTF8.GetBytes(datos + Environment.NewLine);
            
        _hiloRed.Write(bytesDatos, 0, bytesDatos.Length);
            
        return "Datos enviados";
    }
    
    public void Dispose() {
        _clienteTcp?.Dispose();
        _hiloRed?.Dispose();
    }
}