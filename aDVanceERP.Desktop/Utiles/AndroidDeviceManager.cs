namespace aDVanceERP.Desktop.Utiles {
    public class AndroidDeviceManager {
        public event Action<string> OnDeviceConnected;
        public event Action OnDeviceDisconnected;

        private ShellObject _currentDevice;
        private string _currentDeviceId;

        public void StartMonitoring() {
            // Verificar dispositivos ya conectados
            CheckConnectedDevices();

            // Configurar el watcher de dispositivos (se implementaría con WMI si es necesario)
        }

        public List<string> GetAndroidDevices() {
            var devices = new List<string>();

            try {
                // Obtener todos los dispositivos MTP conectados
                var mtpDevices = ShellObject.GetDeviceObjects();

                foreach (var device in mtpDevices) {
                    if (IsAndroidDevice(device)) {
                        string deviceName = device.Name;
                        devices.Add(deviceName);

                        // Opcional: almacenar el primer dispositivo encontrado
                        if (_currentDevice == null) {
                            _currentDevice = device;
                            _currentDeviceId = device.Properties.System.DeviceInterface.PrinterName.Value?.ToString();
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error al listar dispositivos: {ex.Message}");
            }

            return devices;
        }

        private bool IsAndroidDevice(ShellObject device) {
            try {
                // Verificar varias propiedades que identifican dispositivos Android
                string deviceName = device.Name;
                string deviceType = device.Properties.System.Devices.DeviceDescription.Value?.ToString();

                return deviceName.Contains("Android", StringComparison.OrdinalIgnoreCase) ||
                       (deviceType?.Contains("MTP", StringComparison.OrdinalIgnoreCase) ?? false) ||
                       device.Properties.System.DeviceInterface.FriendlyName.Value?.ToString()?
                           .Contains("Android", StringComparison.OrdinalIgnoreCase) ?? false;
            } catch {
                return false;
            }
        }

        public bool ConnectToDevice(string deviceName) {
            try {
                var devices = ShellObject.GetDeviceObjects();
                _currentDevice = devices.FirstOrDefault(d => d.Name.Equals(deviceName, StringComparison.OrdinalIgnoreCase));

                if (_currentDevice != null) {
                    _currentDeviceId = _currentDevice.Properties.System.DeviceInterface.PrinterName.Value?.ToString();
                    OnDeviceConnected?.Invoke(deviceName);
                    return true;
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error al conectar al dispositivo: {ex.Message}");
            }

            return false;
        }

        public List<string> GetAndroidMediaFolders() {
            var folders = new List<string>();

            if (_currentDevice == null) {
                Console.WriteLine("Ningún dispositivo conectado");
                return folders;
            }

            try {
                // Navegar por el sistema de archivos del dispositivo
                var storage = _currentDevice.GetChild("Internal shared storage") ??
                              _currentDevice.GetChild("Almacenamiento interno") ??
                              _currentDevice.GetChild("Card");

                if (storage != null) {
                    var androidFolder = storage.GetChild("Android");
                    if (androidFolder != null) {
                        var mediaFolder = androidFolder.GetChild("media");
                        if (mediaFolder != null) {
                            // Listar todos los directorios dentro de Android/media
                            foreach (var appFolder in mediaFolder.GetChildren()) {
                                folders.Add(appFolder.Name);
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error al acceder al almacenamiento: {ex.Message}");
            }

            return folders;
        }

        public bool CopyFileToDevice(string localFilePath, string appFolderName) {
            if (_currentDevice == null || string.IsNullOrEmpty(_currentDeviceId)) {
                Console.WriteLine("Dispositivo no conectado");
                return false;
            }

            try {
                var storage = _currentDevice.GetChild("Internal shared storage") ??
                              _currentDevice.GetChild("Almacenamiento interno");

                if (storage == null) return false;

                var androidFolder = storage.GetChild("Android");
                var mediaFolder = androidFolder?.GetChild("media");
                var targetFolder = mediaFolder?.GetChild(appFolderName);

                if (targetFolder == null) {
                    // Crear el directorio si no existe
                    using (var newFolder = mediaFolder.CreateShellFolder(appFolderName)) {
                        targetFolder = newFolder;
                    }
                }

                if (targetFolder != null) {
                    string fileName = Path.GetFileName(localFilePath);
                    using (var targetFile = targetFolder.CreateShellFile(fileName))
                    using (var fileStream = File.OpenRead(localFilePath)) {
                        targetFile.WriteStream(fileStream);
                    }

                    return true;
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error al copiar archivo: {ex.Message}");
            }

            return false;
        }

        public void Disconnect() {
            _currentDevice?.Dispose();
            _currentDevice = null;
            _currentDeviceId = null;
            OnDeviceDisconnected?.Invoke();
        }
    }
}