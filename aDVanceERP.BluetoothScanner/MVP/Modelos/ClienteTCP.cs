using System.Net.Sockets;
using System.Text;

namespace aDVanceSCANNER.MVP.Modelos;

public class ClienteTCP : IDisposable {
    private readonly ConfiguracionRed _configuracionRed;

    public ClienteTCP() {
        _configuracionRed = new ConfiguracionRed();
    }

    public TcpClient? Cliente { get; private set; }

    public NetworkStream? HiloRed { get; private set; }

    public bool Conectado {
        get => Cliente is { Connected: true };
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
            if (Cliente != null) {
                HiloRed?.Close();
                Cliente?.Close();
            }

            // Crear una nueva conexión
            if (_configuracionRed.DireccionIP == null)
                return "La dirección IP especificada no es válida o no existe";

            Cliente = new TcpClient();
            Cliente.Connect(_configuracionRed.DireccionIP, _configuracionRed.Puerto);
            HiloRed = Cliente.GetStream();
            
            return $"Conectado a {_configuracionRed.DireccionIP}";
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public string Enviar(string datos) {
        if (HiloRed?.CanWrite != true) 
            return "No hay conexión de red activa";

        var bytesDatos = Encoding.UTF8.GetBytes(datos + Environment.NewLine);
            
        HiloRed.Write(bytesDatos, 0, bytesDatos.Length);
            
        return "Datos enviados";
    }
    
    public void Dispose() {
        Cliente?.Dispose();
        HiloRed?.Dispose();
    }
}