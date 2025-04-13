namespace Scanner_Test {
    public partial class Form1 : Form {
        private readonly WifiServer server;

        public Form1() {
            InitializeComponent();
            server = new WifiServer();
            server.DataReceived += Server_DataReceived;
            server.StatusChanged += Server_StatusChanged;
        }

        private void Form1_Load(object sender, EventArgs e) {
            txtLocalIp.Text = GetLocalIpAddress();
        }

        private async void btnStart_Click(object sender, EventArgs e) {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            try {
                await server.StartAsync();
            } catch (Exception ex) {
                MessageBox.Show($"Error al iniciar servidor: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void btnStop_Click(object sender, EventArgs e) {
            server.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void Server_DataReceived(string data) {
            Invoke((MethodInvoker) delegate {
                txtReceivedData.AppendText($"[{DateTime.Now:HH:mm:ss}] {data}{Environment.NewLine}");
            });
        }

        private void Server_StatusChanged(string status) {
            Invoke((MethodInvoker) delegate {
                lblStatus.Text = status;
            });
        }

        private string GetLocalIpAddress() {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in host.AddressList) {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                    return ip.ToString();
                }
            }
            return "No se encontró dirección IP";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            server.Stop();
        }
    }
}
