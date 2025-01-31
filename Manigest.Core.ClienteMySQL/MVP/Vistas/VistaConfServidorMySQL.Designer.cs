using Guna.UI2.WinForms;

using System.ComponentModel;

namespace Manigest.Core.ClienteMySQL.MVP.Vistas {
    partial class VistaConfServidorMySQL {
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
            components = new Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaConfServidorMySQL));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutDistribucion = new TableLayoutPanel();
            layoutContenedor = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            btnAlmacenarConfiguracion = new Guna2Button();
            fieldTitulo = new Label();
            fieldCopyright = new Label();
            fieldPassword = new Guna2TextBox();
            fieldNombreUsuario = new Guna2TextBox();
            fieldServidor = new Guna2TextBox();
            fieldBaseDatos = new Guna2TextBox();
            fieldMensaje = new Guna2HtmlLabel();
            btnSalir = new Guna2Button();
            layoutBase.SuspendLayout();
            layoutContenedor.SuspendLayout();
            layoutVista.SuspendLayout();
            SuspendLayout();
            // 
            // formatoBase
            // 
            formatoBase.ContainerControl = this;
            formatoBase.DockIndicatorTransparencyValue = 0.6D;
            formatoBase.DragForm = false;
            formatoBase.HasFormShadow = false;
            formatoBase.TransparentWhileDrag = true;
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
            layoutBase.Size = new Size(440, 768);
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
            layoutDistribucion.Size = new Size(438, 766);
            layoutDistribucion.TabIndex = 0;
            // 
            // layoutContenedor
            // 
            layoutContenedor.BackColor = Color.FromArgb(  204,   204,   204);
            layoutContenedor.ColumnCount = 1;
            layoutContenedor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutContenedor.Controls.Add(layoutVista, 0, 0);
            layoutContenedor.Dock = DockStyle.Fill;
            layoutContenedor.Location = new Point(0, 0);
            layoutContenedor.Name = "layoutContenedor";
            layoutContenedor.RowCount = 1;
            layoutContenedor.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutContenedor.Size = new Size(440, 768);
            layoutContenedor.TabIndex = 3;
            // 
            // layoutVista
            // 
            layoutVista.BackColor = Color.FromArgb(  248,   244,   242);
            layoutVista.ColumnCount = 3;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.Controls.Add(btnAlmacenarConfiguracion, 1, 12);
            layoutVista.Controls.Add(fieldTitulo, 1, 1);
            layoutVista.Controls.Add(fieldCopyright, 1, 16);
            layoutVista.Controls.Add(fieldPassword, 1, 10);
            layoutVista.Controls.Add(fieldNombreUsuario, 1, 8);
            layoutVista.Controls.Add(fieldServidor, 1, 4);
            layoutVista.Controls.Add(fieldBaseDatos, 1, 6);
            layoutVista.Controls.Add(fieldMensaje, 1, 2);
            layoutVista.Controls.Add(btnSalir, 1, 14);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(1, 1);
            layoutVista.Margin = new Padding(1);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 18;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
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
            layoutVista.Size = new Size(438, 766);
            layoutVista.TabIndex = 0;
            // 
            // btnAlmacenarConfiguracion
            // 
            btnAlmacenarConfiguracion.Animated = true;
            btnAlmacenarConfiguracion.BorderRadius = 18;
            btnAlmacenarConfiguracion.CustomizableEdges = customizableEdges1;
            btnAlmacenarConfiguracion.Dock = DockStyle.Fill;
            btnAlmacenarConfiguracion.FillColor = Color.FromArgb(  217,   211,   204);
            btnAlmacenarConfiguracion.Font = new Font("Microsoft PhagsPa", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAlmacenarConfiguracion.ForeColor = Color.FromArgb(  40,   37,   35);
            btnAlmacenarConfiguracion.Location = new Point(23, 478);
            btnAlmacenarConfiguracion.Name = "btnAlmacenarConfiguracion";
            btnAlmacenarConfiguracion.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAlmacenarConfiguracion.Size = new Size(392, 39);
            btnAlmacenarConfiguracion.TabIndex = 6;
            btnAlmacenarConfiguracion.Text = "Almacenar la configuración";
            // 
            // fieldTitulo
            // 
            fieldTitulo.Dock = DockStyle.Fill;
            fieldTitulo.Font = new Font("Microsoft PhagsPa", 24F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTitulo.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldTitulo.ImeMode = ImeMode.NoControl;
            fieldTitulo.Location = new Point(23, 20);
            fieldTitulo.Name = "fieldTitulo";
            fieldTitulo.Size = new Size(392, 80);
            fieldTitulo.TabIndex = 0;
            fieldTitulo.Text = "Servidor MySQL";
            fieldTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldCopyright
            // 
            fieldCopyright.Dock = DockStyle.Fill;
            fieldCopyright.Font = new Font("Microsoft PhagsPa", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            fieldCopyright.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldCopyright.ImeMode = ImeMode.NoControl;
            fieldCopyright.Location = new Point(23, 665);
            fieldCopyright.Name = "fieldCopyright";
            fieldCopyright.Size = new Size(392, 80);
            fieldCopyright.TabIndex = 8;
            fieldCopyright.Text = "Copyright 2025©";
            fieldCopyright.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldPassword
            // 
            fieldPassword.Animated = true;
            fieldPassword.BackColor = Color.FromArgb(  254,   254,   253);
            fieldPassword.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldPassword.BorderRadius = 16;
            fieldPassword.Cursor = Cursors.IBeam;
            fieldPassword.CustomizableEdges = customizableEdges3;
            fieldPassword.DefaultText = "";
            fieldPassword.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldPassword.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldPassword.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldPassword.Dock = DockStyle.Fill;
            fieldPassword.FillColor = Color.FromArgb(  254,   254,   253);
            fieldPassword.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldPassword.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldPassword.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldPassword.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldPassword.IconLeft = (Image) resources.GetObject("fieldPassword.IconLeft");
            fieldPassword.IconLeftOffset = new Point(10, 0);
            fieldPassword.Location = new Point(25, 410);
            fieldPassword.Margin = new Padding(5);
            fieldPassword.Name = "fieldPassword";
            fieldPassword.PasswordChar = '●';
            fieldPassword.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldPassword.PlaceholderText = "Contraseña";
            fieldPassword.SelectedText = "";
            fieldPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            fieldPassword.Size = new Size(388, 35);
            fieldPassword.TabIndex = 3;
            fieldPassword.TextOffset = new Point(5, 0);
            fieldPassword.UseSystemPasswordChar = true;
            // 
            // fieldNombreUsuario
            // 
            fieldNombreUsuario.Animated = true;
            fieldNombreUsuario.BackColor = Color.FromArgb(  254,   254,   253);
            fieldNombreUsuario.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldNombreUsuario.BorderRadius = 16;
            fieldNombreUsuario.Cursor = Cursors.IBeam;
            fieldNombreUsuario.CustomizableEdges = customizableEdges5;
            fieldNombreUsuario.DefaultText = "";
            fieldNombreUsuario.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldNombreUsuario.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldNombreUsuario.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldNombreUsuario.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldNombreUsuario.Dock = DockStyle.Fill;
            fieldNombreUsuario.FillColor = Color.FromArgb(  254,   254,   253);
            fieldNombreUsuario.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldNombreUsuario.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreUsuario.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldNombreUsuario.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldNombreUsuario.IconLeft = (Image) resources.GetObject("fieldNombreUsuario.IconLeft");
            fieldNombreUsuario.IconLeftOffset = new Point(10, 0);
            fieldNombreUsuario.Location = new Point(25, 355);
            fieldNombreUsuario.Margin = new Padding(5);
            fieldNombreUsuario.Name = "fieldNombreUsuario";
            fieldNombreUsuario.PasswordChar = '\0';
            fieldNombreUsuario.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldNombreUsuario.PlaceholderText = "Nombre de usuario";
            fieldNombreUsuario.SelectedText = "";
            fieldNombreUsuario.ShadowDecoration.CustomizableEdges = customizableEdges6;
            fieldNombreUsuario.Size = new Size(388, 35);
            fieldNombreUsuario.TabIndex = 2;
            fieldNombreUsuario.TextOffset = new Point(5, 0);
            // 
            // fieldServidor
            // 
            fieldServidor.Animated = true;
            fieldServidor.BackColor = Color.FromArgb(  254,   254,   253);
            fieldServidor.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldServidor.BorderRadius = 16;
            fieldServidor.Cursor = Cursors.IBeam;
            fieldServidor.CustomizableEdges = customizableEdges7;
            fieldServidor.DefaultText = "";
            fieldServidor.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldServidor.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldServidor.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldServidor.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldServidor.Dock = DockStyle.Fill;
            fieldServidor.FillColor = Color.FromArgb(  254,   254,   253);
            fieldServidor.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldServidor.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldServidor.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldServidor.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldServidor.IconLeft = (Image) resources.GetObject("fieldServidor.IconLeft");
            fieldServidor.IconLeftOffset = new Point(10, 0);
            fieldServidor.Location = new Point(25, 245);
            fieldServidor.Margin = new Padding(5);
            fieldServidor.Name = "fieldServidor";
            fieldServidor.PasswordChar = '\0';
            fieldServidor.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldServidor.PlaceholderText = "Servidor";
            fieldServidor.SelectedText = "";
            fieldServidor.ShadowDecoration.CustomizableEdges = customizableEdges8;
            fieldServidor.Size = new Size(388, 35);
            fieldServidor.TabIndex = 9;
            fieldServidor.TextOffset = new Point(5, 0);
            // 
            // fieldBaseDatos
            // 
            fieldBaseDatos.Animated = true;
            fieldBaseDatos.BackColor = Color.FromArgb(  254,   254,   253);
            fieldBaseDatos.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldBaseDatos.BorderRadius = 16;
            fieldBaseDatos.Cursor = Cursors.IBeam;
            fieldBaseDatos.CustomizableEdges = customizableEdges9;
            fieldBaseDatos.DefaultText = "";
            fieldBaseDatos.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldBaseDatos.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldBaseDatos.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldBaseDatos.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldBaseDatos.Dock = DockStyle.Fill;
            fieldBaseDatos.FillColor = Color.FromArgb(  254,   254,   253);
            fieldBaseDatos.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldBaseDatos.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldBaseDatos.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldBaseDatos.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldBaseDatos.IconLeft = (Image) resources.GetObject("fieldBaseDatos.IconLeft");
            fieldBaseDatos.IconLeftOffset = new Point(10, 0);
            fieldBaseDatos.Location = new Point(25, 300);
            fieldBaseDatos.Margin = new Padding(5);
            fieldBaseDatos.Name = "fieldBaseDatos";
            fieldBaseDatos.PasswordChar = '\0';
            fieldBaseDatos.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldBaseDatos.PlaceholderText = "Base de datos";
            fieldBaseDatos.SelectedText = "";
            fieldBaseDatos.ShadowDecoration.CustomizableEdges = customizableEdges10;
            fieldBaseDatos.Size = new Size(388, 35);
            fieldBaseDatos.TabIndex = 10;
            fieldBaseDatos.TextOffset = new Point(5, 0);
            // 
            // fieldMensaje
            // 
            fieldMensaje.AutoSize = false;
            fieldMensaje.BackColor = Color.FromArgb(  248,   244,   242);
            fieldMensaje.Dock = DockStyle.Fill;
            fieldMensaje.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldMensaje.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldMensaje.Location = new Point(23, 103);
            fieldMensaje.Name = "fieldMensaje";
            fieldMensaje.Size = new Size(392, 114);
            fieldMensaje.TabIndex = 12;
            fieldMensaje.Text = "Al cambiar la configuración de la aplicación y presionar el botón de almacenar debe tener en cuenta que la aplicación se reiniciará para aplicar los cambios.";
            // 
            // btnSalir
            // 
            btnSalir.Animated = true;
            btnSalir.BorderColor = Color.FromArgb(  217,   211,   204);
            btnSalir.BorderRadius = 18;
            btnSalir.BorderThickness = 1;
            btnSalir.CustomizableEdges = customizableEdges11;
            btnSalir.Dock = DockStyle.Fill;
            btnSalir.FillColor = Color.FromArgb(  254,   254,   253);
            btnSalir.Font = new Font("Microsoft PhagsPa", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.FromArgb(  217,   211,   204);
            btnSalir.HoverState.BorderColor = Color.FromArgb(  217,   211,   204);
            btnSalir.HoverState.FillColor = Color.FromArgb(  217,   211,   204);
            btnSalir.HoverState.ForeColor = Color.FromArgb(  40,   37,   35);
            btnSalir.Location = new Point(23, 533);
            btnSalir.Name = "btnSalir";
            btnSalir.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnSalir.Size = new Size(392, 39);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "Salir";
            // 
            // VistaConfServidorMySQL
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(440, 768);
            Controls.Add(layoutContenedor);
            Controls.Add(layoutBase);
            Font = new Font("Microsoft PhagsPa", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaConfServidorMySQL";
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

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutDistribucion;
        private TableLayoutPanel layoutContenedor;
        private TableLayoutPanel layoutVista;
        private Guna2TextBox fieldNombreUsuario;
        private Guna2TextBox fieldPassword;
        private Label fieldTitulo;
        private Label fieldCopyright;
        private Guna2Button btnAlmacenarConfiguracion;
        private Guna2TextBox fieldServidor;
        private Guna2TextBox fieldBaseDatos;
        private Guna2HtmlLabel fieldMensaje;
        private Guna2Button btnSalir;
    }
}