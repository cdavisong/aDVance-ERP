namespace Scanner_Test {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            SuspendLayout();
            this.lblTitle = new Label();
            this.lblLocalIp = new Label();
            this.txtLocalIp = new TextBox();
            this.btnStart = new Button();
            this.btnStop = new Button();
            this.lblStatus = new Label();
            this.txtReceivedData = new TextBox();
            this.lblReceivedData = new Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Servidor de Escáner";

            // lblLocalIp
            this.lblLocalIp.AutoSize = true;
            this.lblLocalIp.Location = new System.Drawing.Point(13, 45);
            this.lblLocalIp.Name = "lblLocalIp";
            this.lblLocalIp.Size = new System.Drawing.Size(61, 13);
            this.lblLocalIp.TabIndex = 1;
            this.lblLocalIp.Text = "IP Local:";

            // txtLocalIp
            this.txtLocalIp.Location = new System.Drawing.Point(80, 42);
            this.txtLocalIp.Name = "txtLocalIp";
            this.txtLocalIp.ReadOnly = true;
            this.txtLocalIp.Size = new System.Drawing.Size(140, 20);
            this.txtLocalIp.TabIndex = 2;

            // btnStart
            this.btnStart.Location = new System.Drawing.Point(16, 75);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Iniciar Servidor";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // btnStop
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(122, 75);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 30);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Detener";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 120);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(96, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Estado: Inactivo";

            // lblReceivedData
            this.lblReceivedData.AutoSize = true;
            this.lblReceivedData.Location = new System.Drawing.Point(13, 150);
            this.lblReceivedData.Name = "lblReceivedData";
            this.lblReceivedData.Size = new System.Drawing.Size(94, 13);
            this.lblReceivedData.TabIndex = 6;
            this.lblReceivedData.Text = "Datos Recibidos:";

            // txtReceivedData
            this.txtReceivedData.Location = new System.Drawing.Point(16, 170);
            this.txtReceivedData.Multiline = true;
            this.txtReceivedData.Name = "txtReceivedData";
            this.txtReceivedData.ReadOnly = true;
            this.txtReceivedData.ScrollBars = ScrollBars.Vertical;
            this.txtReceivedData.Size = new System.Drawing.Size(350, 150);
            this.txtReceivedData.TabIndex = 7;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 341);
            this.Controls.Add(this.txtReceivedData);
            this.Controls.Add(this.lblReceivedData);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtLocalIp);
            this.Controls.Add(this.lblLocalIp);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Servidor de Escáner WiFi";
            this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblLocalIp;
        private TextBox txtLocalIp;
        private Button btnStart;
        private Button btnStop;
        private Label lblStatus;
        private TextBox txtReceivedData;
        private Label lblReceivedData;
    }
}
