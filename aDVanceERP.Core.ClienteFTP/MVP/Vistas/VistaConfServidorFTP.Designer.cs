using Guna.UI2.WinForms;
using System.ComponentModel;

namespace aDVanceERP.Core.ClienteFTP.MVP.Vistas {
    partial class VistaConfServidorFTP {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaConfServidorFTP));
            layoutBase = new TableLayoutPanel();
            layoutDistribucion = new TableLayoutPanel();
            layoutContenedor = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            fieldTitulo = new Label();
            fieldCopyright = new Label();
            fieldServidor = new CuoreUI.Controls.cuiTextBox();
            fieldNombreUsuario = new CuoreUI.Controls.cuiTextBox();
            fieldPassword = new CuoreUI.Controls.cuiTextBox();
            btnAlmacenarConfiguracion = new CuoreUI.Controls.cuiButton();
            btnSalir = new CuoreUI.Controls.cuiButton();
            fieldInformacion = new CuoreUI.Controls.cuiLabel();
            layoutBase.SuspendLayout();
            layoutContenedor.SuspendLayout();
            layoutVista.SuspendLayout();
            SuspendLayout();
            // 
            // layoutBase
            // 
            layoutBase.ColumnCount = 1;
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutBase.Controls.Add(layoutDistribucion, 0, 0);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 1;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutBase.Size = new Size(440, 749);
            layoutBase.TabIndex = 0;
            // 
            // layoutDistribucion
            // 
            layoutDistribucion.ColumnCount = 1;
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutDistribucion.Dock = DockStyle.Fill;
            layoutDistribucion.Location = new Point(1, 1);
            layoutDistribucion.Margin = new Padding(1);
            layoutDistribucion.Name = "layoutDistribucion";
            layoutDistribucion.RowCount = 1;
            layoutDistribucion.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutDistribucion.Size = new Size(438, 747);
            layoutDistribucion.TabIndex = 0;
            // 
            // layoutContenedor
            // 
            layoutContenedor.BackColor = Color.WhiteSmoke;
            layoutContenedor.ColumnCount = 1;
            layoutContenedor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutContenedor.Controls.Add(layoutVista, 0, 0);
            layoutContenedor.Dock = DockStyle.Fill;
            layoutContenedor.Location = new Point(0, 0);
            layoutContenedor.Name = "layoutContenedor";
            layoutContenedor.RowCount = 1;
            layoutContenedor.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutContenedor.Size = new Size(440, 749);
            layoutContenedor.TabIndex = 3;
            // 
            // layoutVista
            // 
            layoutVista.BackColor = Color.White;
            layoutVista.ColumnCount = 3;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.Controls.Add(fieldTitulo, 1, 1);
            layoutVista.Controls.Add(fieldCopyright, 1, 14);
            layoutVista.Controls.Add(fieldServidor, 1, 4);
            layoutVista.Controls.Add(fieldNombreUsuario, 1, 6);
            layoutVista.Controls.Add(fieldPassword, 1, 8);
            layoutVista.Controls.Add(btnAlmacenarConfiguracion, 1, 10);
            layoutVista.Controls.Add(btnSalir, 1, 12);
            layoutVista.Controls.Add(fieldInformacion, 1, 2);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(1, 1);
            layoutVista.Margin = new Padding(1);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 16;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 22F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 78F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.Size = new Size(438, 747);
            layoutVista.TabIndex = 0;
            // 
            // fieldTitulo
            // 
            fieldTitulo.Dock = DockStyle.Fill;
            fieldTitulo.Font = new Font("Segoe UI", 24F);
            fieldTitulo.ForeColor = Color.Black;
            fieldTitulo.ImeMode = ImeMode.NoControl;
            fieldTitulo.Location = new Point(23, 20);
            fieldTitulo.Name = "fieldTitulo";
            fieldTitulo.Size = new Size(392, 80);
            fieldTitulo.TabIndex = 0;
            fieldTitulo.Text = "Servidor FTP";
            fieldTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldCopyright
            // 
            fieldCopyright.Dock = DockStyle.Fill;
            fieldCopyright.Font = new Font("Segoe UI", 9.75F);
            fieldCopyright.ForeColor = Color.DimGray;
            fieldCopyright.ImeMode = ImeMode.NoControl;
            fieldCopyright.Location = new Point(23, 646);
            fieldCopyright.Name = "fieldCopyright";
            fieldCopyright.Size = new Size(392, 80);
            fieldCopyright.TabIndex = 8;
            fieldCopyright.Text = "Copyright 2025©";
            fieldCopyright.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldServidor
            // 
            fieldServidor.BackgroundColor = Color.White;
            fieldServidor.BorderColor = Color.Gainsboro;
            fieldServidor.Content = "";
            fieldServidor.Dock = DockStyle.Fill;
            fieldServidor.FocusBackgroundColor = Color.White;
            fieldServidor.FocusBorderColor = Color.PeachPuff;
            fieldServidor.FocusImageTint = Color.White;
            fieldServidor.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            fieldServidor.ForeColor = Color.Gray;
            fieldServidor.Image = (Image) resources.GetObject("fieldServidor.Image");
            fieldServidor.ImageExpand = new Point(0, 0);
            fieldServidor.ImageOffset = new Point(0, 0);
            fieldServidor.Location = new Point(24, 244);
            fieldServidor.Margin = new Padding(4);
            fieldServidor.Multiline = false;
            fieldServidor.Name = "fieldServidor";
            fieldServidor.NormalImageTint = Color.White;
            fieldServidor.Padding = new Padding(50, 8, 50, 0);
            fieldServidor.PasswordChar = false;
            fieldServidor.PlaceholderColor = Color.DarkGray;
            fieldServidor.PlaceholderText = "Servidor";
            fieldServidor.Rounding = new Padding(8);
            fieldServidor.Size = new Size(390, 37);
            fieldServidor.TabIndex = 14;
            fieldServidor.TextOffset = new Size(30, 0);
            fieldServidor.UnderlinedStyle = true;
            // 
            // fieldNombreUsuario
            // 
            fieldNombreUsuario.BackgroundColor = Color.White;
            fieldNombreUsuario.BorderColor = Color.Gainsboro;
            fieldNombreUsuario.Content = "";
            fieldNombreUsuario.Dock = DockStyle.Fill;
            fieldNombreUsuario.FocusBackgroundColor = Color.White;
            fieldNombreUsuario.FocusBorderColor = Color.PeachPuff;
            fieldNombreUsuario.FocusImageTint = Color.White;
            fieldNombreUsuario.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            fieldNombreUsuario.ForeColor = Color.Gray;
            fieldNombreUsuario.Image = (Image) resources.GetObject("fieldNombreUsuario.Image");
            fieldNombreUsuario.ImageExpand = new Point(0, 0);
            fieldNombreUsuario.ImageOffset = new Point(0, 0);
            fieldNombreUsuario.Location = new Point(24, 299);
            fieldNombreUsuario.Margin = new Padding(4);
            fieldNombreUsuario.Multiline = false;
            fieldNombreUsuario.Name = "fieldNombreUsuario";
            fieldNombreUsuario.NormalImageTint = Color.White;
            fieldNombreUsuario.Padding = new Padding(50, 8, 50, 0);
            fieldNombreUsuario.PasswordChar = false;
            fieldNombreUsuario.PlaceholderColor = Color.DarkGray;
            fieldNombreUsuario.PlaceholderText = "Nombre de usuario";
            fieldNombreUsuario.Rounding = new Padding(8);
            fieldNombreUsuario.Size = new Size(390, 37);
            fieldNombreUsuario.TabIndex = 15;
            fieldNombreUsuario.TextOffset = new Size(30, 0);
            fieldNombreUsuario.UnderlinedStyle = true;
            // 
            // fieldPassword
            // 
            fieldPassword.BackgroundColor = Color.White;
            fieldPassword.BorderColor = Color.Gainsboro;
            fieldPassword.Content = "";
            fieldPassword.Dock = DockStyle.Fill;
            fieldPassword.FocusBackgroundColor = Color.White;
            fieldPassword.FocusBorderColor = Color.PeachPuff;
            fieldPassword.FocusImageTint = Color.White;
            fieldPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            fieldPassword.ForeColor = Color.Gray;
            fieldPassword.Image = (Image) resources.GetObject("fieldPassword.Image");
            fieldPassword.ImageExpand = new Point(0, 0);
            fieldPassword.ImageOffset = new Point(0, 0);
            fieldPassword.Location = new Point(24, 354);
            fieldPassword.Margin = new Padding(4);
            fieldPassword.Multiline = false;
            fieldPassword.Name = "fieldPassword";
            fieldPassword.NormalImageTint = Color.White;
            fieldPassword.Padding = new Padding(50, 8, 50, 0);
            fieldPassword.PasswordChar = false;
            fieldPassword.PlaceholderColor = Color.DarkGray;
            fieldPassword.PlaceholderText = "Contraseña";
            fieldPassword.Rounding = new Padding(8);
            fieldPassword.Size = new Size(390, 37);
            fieldPassword.TabIndex = 16;
            fieldPassword.TextOffset = new Size(30, 0);
            fieldPassword.UnderlinedStyle = true;
            // 
            // btnAlmacenarConfiguracion
            // 
            btnAlmacenarConfiguracion.CheckButton = false;
            btnAlmacenarConfiguracion.Checked = false;
            btnAlmacenarConfiguracion.CheckedBackground = Color.FromArgb(  255,   106,   0);
            btnAlmacenarConfiguracion.CheckedForeColor = Color.White;
            btnAlmacenarConfiguracion.CheckedImageTint = Color.White;
            btnAlmacenarConfiguracion.CheckedOutline = Color.FromArgb(  255,   106,   0);
            btnAlmacenarConfiguracion.Content = "Almacenar configuración";
            btnAlmacenarConfiguracion.DialogResult = DialogResult.None;
            btnAlmacenarConfiguracion.Dock = DockStyle.Fill;
            btnAlmacenarConfiguracion.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point,  0);
            btnAlmacenarConfiguracion.ForeColor = Color.Black;
            btnAlmacenarConfiguracion.HoverBackground = Color.White;
            btnAlmacenarConfiguracion.HoveredImageTint = Color.White;
            btnAlmacenarConfiguracion.HoverForeColor = Color.Black;
            btnAlmacenarConfiguracion.HoverOutline = Color.FromArgb(  32,   128,   128,   128);
            btnAlmacenarConfiguracion.Image = null;
            btnAlmacenarConfiguracion.ImageAutoCenter = true;
            btnAlmacenarConfiguracion.ImageExpand = new Point(0, 0);
            btnAlmacenarConfiguracion.ImageOffset = new Point(0, 0);
            btnAlmacenarConfiguracion.Location = new Point(23, 431);
            btnAlmacenarConfiguracion.Name = "btnAlmacenarConfiguracion";
            btnAlmacenarConfiguracion.NormalBackground = Color.PeachPuff;
            btnAlmacenarConfiguracion.NormalForeColor = Color.Black;
            btnAlmacenarConfiguracion.NormalImageTint = Color.White;
            btnAlmacenarConfiguracion.NormalOutline = Color.PeachPuff;
            btnAlmacenarConfiguracion.OutlineThickness = 1F;
            btnAlmacenarConfiguracion.PressedBackground = Color.WhiteSmoke;
            btnAlmacenarConfiguracion.PressedForeColor = Color.FromArgb(  32,   32,   32);
            btnAlmacenarConfiguracion.PressedImageTint = Color.White;
            btnAlmacenarConfiguracion.PressedOutline = Color.FromArgb(  64,   128,   128,   128);
            btnAlmacenarConfiguracion.Rounding = new Padding(16);
            btnAlmacenarConfiguracion.Size = new Size(392, 39);
            btnAlmacenarConfiguracion.TabIndex = 17;
            btnAlmacenarConfiguracion.TextAlignment = StringAlignment.Center;
            btnAlmacenarConfiguracion.TextOffset = new Point(0, 0);
            // 
            // btnSalir
            // 
            btnSalir.CheckButton = false;
            btnSalir.Checked = false;
            btnSalir.CheckedBackground = Color.FromArgb(  255,   106,   0);
            btnSalir.CheckedForeColor = Color.White;
            btnSalir.CheckedImageTint = Color.White;
            btnSalir.CheckedOutline = Color.FromArgb(  255,   106,   0);
            btnSalir.Content = "Salir";
            btnSalir.DialogResult = DialogResult.None;
            btnSalir.Dock = DockStyle.Fill;
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point,  0);
            btnSalir.ForeColor = Color.Gainsboro;
            btnSalir.HoverBackground = Color.PeachPuff;
            btnSalir.HoveredImageTint = Color.White;
            btnSalir.HoverForeColor = Color.Black;
            btnSalir.HoverOutline = Color.PeachPuff;
            btnSalir.Image = null;
            btnSalir.ImageAutoCenter = true;
            btnSalir.ImageExpand = new Point(0, 0);
            btnSalir.ImageOffset = new Point(0, 0);
            btnSalir.Location = new Point(23, 486);
            btnSalir.Name = "btnSalir";
            btnSalir.NormalBackground = Color.White;
            btnSalir.NormalForeColor = Color.Gainsboro;
            btnSalir.NormalImageTint = Color.White;
            btnSalir.NormalOutline = Color.Gainsboro;
            btnSalir.OutlineThickness = 1F;
            btnSalir.PressedBackground = Color.WhiteSmoke;
            btnSalir.PressedForeColor = Color.FromArgb(  32,   32,   32);
            btnSalir.PressedImageTint = Color.White;
            btnSalir.PressedOutline = Color.FromArgb(  64,   128,   128,   128);
            btnSalir.Rounding = new Padding(16);
            btnSalir.Size = new Size(392, 39);
            btnSalir.TabIndex = 18;
            btnSalir.TextAlignment = StringAlignment.Center;
            btnSalir.TextOffset = new Point(0, 0);
            // 
            // fieldInformacion
            // 
            fieldInformacion.Content = "Al\\ cambiar\\ la\\ configuración\\ de\\ la\\ aplicación\\ y\\ presionar\\ el\\ botón\\ de\\ almacenar\\ debe\\ tener\\ en\\ cuenta\\ que\\ la\\ aplicación\\ se\\ reiniciará\\ para\\ aplicar\\ los\\ cambios\\.";
            fieldInformacion.Dock = DockStyle.Fill;
            fieldInformacion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point,  0);
            fieldInformacion.HorizontalAlignment = StringAlignment.Near;
            fieldInformacion.Location = new Point(24, 103);
            fieldInformacion.Margin = new Padding(4, 3, 4, 3);
            fieldInformacion.Name = "fieldInformacion";
            fieldInformacion.Size = new Size(390, 114);
            fieldInformacion.TabIndex = 19;
            fieldInformacion.VerticalAlignment = StringAlignment.Near;
            // 
            // VistaConfServidorFTP
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(440, 749);
            Controls.Add(layoutContenedor);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaConfServidorFTP";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaConfiguracionBaseDatos";
            layoutBase.ResumeLayout(false);
            layoutContenedor.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutDistribucion;
        private TableLayoutPanel layoutContenedor;
        private TableLayoutPanel layoutVista;
        private Label fieldTitulo;
        private Label fieldCopyright;
        private CuoreUI.Controls.cuiTextBox fieldServidor;
        private CuoreUI.Controls.cuiTextBox fieldNombreUsuario;
        private CuoreUI.Controls.cuiTextBox fieldPassword;
        private CuoreUI.Controls.cuiButton btnAlmacenarConfiguracion;
        private CuoreUI.Controls.cuiButton btnSalir;
        private CuoreUI.Controls.cuiLabel fieldInformacion;
    }
}