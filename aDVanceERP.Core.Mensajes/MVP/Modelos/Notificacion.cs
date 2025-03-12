namespace aDVanceERP.Core.Mensajes.MVP.Modelos {
    public class Notificacion {
        public Notificacion() {
        }

        public Notificacion(string mensaje, bool esError) {
            Mensaje = mensaje;
            EsError = esError;
        }

        public string? Mensaje {  get; set; }

        public int Duracion { 
            get {
                var tiempoBase = 3000;
                var tiempoExtra = Mensaje.Length * 50; // 50 milisegundos extra por caracter

                return tiempoBase + tiempoExtra;
            }
        }

        public bool EsError { get; set; }
    }
}
