using Guna.UI2.WinForms;

using System.ComponentModel;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Caja {
    partial class VistaRegistroCaja {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaRegistroCaja));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            layoutVista = new TableLayoutPanel();
            fieldIcono = new PictureBox();
            fieldSubtitulo = new Label();
            layoutTitulo = new TableLayoutPanel();
            btnCerrar = new Guna2Button();
            fieldTitulo = new Label();
            fieldNotas = new Guna2TextBox();
            layoutDatosCaja = new TableLayoutPanel();
            fieldNumeroCaja = new Guna2TextBox();
            fieldSaldoInicial = new Guna2TextBox();
            fieldTituloDatosApertura = new Label();
            layoutBotones = new TableLayoutPanel();
            btnSalir = new Guna2Button();
            btnRegistrar = new Guna2Button();
            layoutBase.SuspendLayout();
            layoutVista.SuspendLayout();
            ((ISupportInitialize) fieldIcono).BeginInit();
            layoutTitulo.SuspendLayout();
            layoutDatosCaja.SuspendLayout();
            layoutBotones.SuspendLayout();
            SuspendLayout();
            // 
            // formatoBase
            // 
            formatoBase.AnimateWindow = true;
            formatoBase.AnimationType = Guna2BorderlessForm.AnimateWindowType.AW_HOR_NEGATIVE;
            formatoBase.ContainerControl = this;
            formatoBase.DockIndicatorTransparencyValue = 0.6D;
            formatoBase.DragForm = false;
            formatoBase.HasFormShadow = false;
            formatoBase.TransparentWhileDrag = true;
            // 
            // layoutBase
            // 
            layoutBase.BackColor = Color.Gainsboro;
            layoutBase.ColumnCount = 2;
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutBase.Controls.Add(layoutVista, 1, 0);
            layoutBase.Controls.Add(layoutBotones, 1, 1);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 2;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            layoutBase.Size = new Size(500, 685);
            layoutBase.TabIndex = 2;
            // 
            // layoutVista
            // 
            layoutVista.BackColor = Color.White;
            layoutVista.ColumnCount = 4;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.Controls.Add(fieldIcono, 1, 1);
            layoutVista.Controls.Add(fieldSubtitulo, 2, 2);
            layoutVista.Controls.Add(layoutTitulo, 2, 1);
            layoutVista.Controls.Add(fieldNotas, 2, 7);
            layoutVista.Controls.Add(layoutDatosCaja, 2, 5);
            layoutVista.Controls.Add(fieldTituloDatosApertura, 2, 4);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(13, 0);
            layoutVista.Margin = new Padding(3, 0, 0, 0);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 10;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.Size = new Size(487, 620);
            layoutVista.TabIndex = 0;
            // 
            // fieldIcono
            // 
            fieldIcono.BackgroundImage = (Image) resources.GetObject("fieldIcono.BackgroundImage");
            fieldIcono.BackgroundImageLayout = ImageLayout.Center;
            fieldIcono.Dock = DockStyle.Fill;
            fieldIcono.Location = new Point(20, 26);
            fieldIcono.Margin = new Padding(0, 6, 0, 0);
            fieldIcono.Name = "fieldIcono";
            fieldIcono.Size = new Size(30, 39);
            fieldIcono.TabIndex = 0;
            fieldIcono.TabStop = false;
            // 
            // fieldSubtitulo
            // 
            fieldSubtitulo.Dock = DockStyle.Fill;
            fieldSubtitulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldSubtitulo.ForeColor = Color.Gray;
            fieldSubtitulo.ImeMode = ImeMode.NoControl;
            fieldSubtitulo.Location = new Point(55, 70);
            fieldSubtitulo.Margin = new Padding(5, 5, 1, 1);
            fieldSubtitulo.Name = "fieldSubtitulo";
            fieldSubtitulo.Size = new Size(411, 39);
            fieldSubtitulo.TabIndex = 0;
            fieldSubtitulo.Text = "Apertura";
            // 
            // layoutTitulo
            // 
            layoutTitulo.ColumnCount = 2;
            layoutTitulo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutTitulo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutTitulo.Controls.Add(btnCerrar, 1, 0);
            layoutTitulo.Controls.Add(fieldTitulo, 0, 0);
            layoutTitulo.Dock = DockStyle.Fill;
            layoutTitulo.Location = new Point(50, 20);
            layoutTitulo.Margin = new Padding(0);
            layoutTitulo.Name = "layoutTitulo";
            layoutTitulo.RowCount = 1;
            layoutTitulo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutTitulo.Size = new Size(417, 45);
            layoutTitulo.TabIndex = 14;
            // 
            // btnCerrar
            // 
            btnCerrar.Animated = true;
            btnCerrar.AutoRoundedCorners = true;
            btnCerrar.BorderColor = Color.Gray;
            btnCerrar.BorderRadius = 18;
            btnCerrar.CustomizableEdges = customizableEdges1;
            btnCerrar.Dock = DockStyle.Fill;
            btnCerrar.FillColor = Color.White;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.Black;
            btnCerrar.HoverState.FillColor = Color.White;
            btnCerrar.Image = (Image) resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(370, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnCerrar.Size = new Size(44, 39);
            btnCerrar.TabIndex = 1;
            // 
            // fieldTitulo
            // 
            fieldTitulo.Dock = DockStyle.Fill;
            fieldTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTitulo.ForeColor = Color.Black;
            fieldTitulo.ImeMode = ImeMode.NoControl;
            fieldTitulo.Location = new Point(3, 0);
            fieldTitulo.Name = "fieldTitulo";
            fieldTitulo.Size = new Size(361, 45);
            fieldTitulo.TabIndex = 0;
            fieldTitulo.Text = "Caja registradora";
            fieldTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldNotas
            // 
            fieldNotas.Animated = true;
            fieldNotas.BorderColor = Color.Gainsboro;
            fieldNotas.BorderRadius = 16;
            fieldNotas.Cursor = Cursors.IBeam;
            fieldNotas.CustomizableEdges = customizableEdges3;
            fieldNotas.DefaultText = "";
            fieldNotas.DisabledState.BorderColor = Color.White;
            fieldNotas.DisabledState.ForeColor = Color.DimGray;
            fieldNotas.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldNotas.Dock = DockStyle.Fill;
            fieldNotas.FocusedState.BorderColor = Color.SandyBrown;
            fieldNotas.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNotas.ForeColor = Color.Black;
            fieldNotas.HoverState.BorderColor = Color.SandyBrown;
            fieldNotas.IconLeft = (Image) resources.GetObject("fieldNotas.IconLeft");
            fieldNotas.IconLeftOffset = new Point(10, -11);
            fieldNotas.Location = new Point(55, 225);
            fieldNotas.Margin = new Padding(5);
            fieldNotas.Multiline = true;
            fieldNotas.Name = "fieldNotas";
            fieldNotas.PasswordChar = '\0';
            fieldNotas.PlaceholderForeColor = Color.DimGray;
            fieldNotas.PlaceholderText = "Notas adicionales";
            fieldNotas.SelectedText = "";
            fieldNotas.ShadowDecoration.CustomizableEdges = customizableEdges4;
            fieldNotas.Size = new Size(407, 62);
            fieldNotas.TabIndex = 22;
            fieldNotas.TextOffset = new Point(5, 0);
            // 
            // layoutDatosCaja
            // 
            layoutDatosCaja.ColumnCount = 2;
            layoutDatosCaja.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutDatosCaja.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutDatosCaja.Controls.Add(fieldNumeroCaja, 0, 0);
            layoutDatosCaja.Controls.Add(fieldSaldoInicial, 1, 0);
            layoutDatosCaja.Dock = DockStyle.Fill;
            layoutDatosCaja.Location = new Point(50, 165);
            layoutDatosCaja.Margin = new Padding(0);
            layoutDatosCaja.Name = "layoutDatosCaja";
            layoutDatosCaja.RowCount = 1;
            layoutDatosCaja.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutDatosCaja.Size = new Size(417, 45);
            layoutDatosCaja.TabIndex = 23;
            // 
            // fieldNumeroCaja
            // 
            fieldNumeroCaja.Animated = true;
            fieldNumeroCaja.BorderColor = Color.Gainsboro;
            fieldNumeroCaja.BorderRadius = 16;
            fieldNumeroCaja.Cursor = Cursors.IBeam;
            fieldNumeroCaja.CustomizableEdges = customizableEdges5;
            fieldNumeroCaja.DefaultText = "";
            fieldNumeroCaja.DisabledState.BorderColor = Color.White;
            fieldNumeroCaja.DisabledState.ForeColor = Color.DimGray;
            fieldNumeroCaja.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldNumeroCaja.Dock = DockStyle.Fill;
            fieldNumeroCaja.FocusedState.BorderColor = Color.SandyBrown;
            fieldNumeroCaja.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNumeroCaja.ForeColor = Color.Black;
            fieldNumeroCaja.HoverState.BorderColor = Color.SandyBrown;
            fieldNumeroCaja.IconLeft = (Image) resources.GetObject("fieldNumeroCaja.IconLeft");
            fieldNumeroCaja.IconLeftOffset = new Point(10, 0);
            fieldNumeroCaja.IconRightCursor = Cursors.Cross;
            fieldNumeroCaja.IconRightOffset = new Point(6, 0);
            fieldNumeroCaja.IconRightSize = new Size(12, 12);
            fieldNumeroCaja.Location = new Point(5, 5);
            fieldNumeroCaja.Margin = new Padding(5);
            fieldNumeroCaja.Name = "fieldNumeroCaja";
            fieldNumeroCaja.PasswordChar = '\0';
            fieldNumeroCaja.PlaceholderForeColor = Color.DimGray;
            fieldNumeroCaja.PlaceholderText = "Número o identificador de caja";
            fieldNumeroCaja.SelectedText = "";
            fieldNumeroCaja.ShadowDecoration.CustomizableEdges = customizableEdges6;
            fieldNumeroCaja.Size = new Size(287, 35);
            fieldNumeroCaja.TabIndex = 2;
            fieldNumeroCaja.TextOffset = new Point(5, 0);
            // 
            // fieldSaldoInicial
            // 
            fieldSaldoInicial.Animated = true;
            fieldSaldoInicial.BorderColor = Color.Gainsboro;
            fieldSaldoInicial.BorderRadius = 16;
            fieldSaldoInicial.Cursor = Cursors.IBeam;
            fieldSaldoInicial.CustomizableEdges = customizableEdges7;
            fieldSaldoInicial.DefaultText = "";
            fieldSaldoInicial.DisabledState.BorderColor = Color.White;
            fieldSaldoInicial.DisabledState.ForeColor = Color.DimGray;
            fieldSaldoInicial.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldSaldoInicial.Dock = DockStyle.Fill;
            fieldSaldoInicial.FocusedState.BorderColor = Color.SandyBrown;
            fieldSaldoInicial.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldSaldoInicial.ForeColor = Color.Black;
            fieldSaldoInicial.HoverState.BorderColor = Color.SandyBrown;
            fieldSaldoInicial.IconLeftOffset = new Point(10, 0);
            fieldSaldoInicial.IconRight = (Image) resources.GetObject("fieldSaldoInicial.IconRight");
            fieldSaldoInicial.IconRightOffset = new Point(6, 0);
            fieldSaldoInicial.IconRightSize = new Size(12, 12);
            fieldSaldoInicial.Location = new Point(302, 5);
            fieldSaldoInicial.Margin = new Padding(5);
            fieldSaldoInicial.Name = "fieldSaldoInicial";
            fieldSaldoInicial.PasswordChar = '\0';
            fieldSaldoInicial.PlaceholderForeColor = Color.DimGray;
            fieldSaldoInicial.PlaceholderText = "Saldo";
            fieldSaldoInicial.SelectedText = "";
            fieldSaldoInicial.ShadowDecoration.CustomizableEdges = customizableEdges8;
            fieldSaldoInicial.Size = new Size(110, 35);
            fieldSaldoInicial.TabIndex = 1;
            fieldSaldoInicial.TextAlign = HorizontalAlignment.Right;
            fieldSaldoInicial.TextOffset = new Point(5, 0);
            // 
            // fieldTituloDatosApertura
            // 
            fieldTituloDatosApertura.Dock = DockStyle.Fill;
            fieldTituloDatosApertura.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloDatosApertura.ForeColor = Color.DimGray;
            fieldTituloDatosApertura.Image = (Image) resources.GetObject("fieldTituloDatosApertura.Image");
            fieldTituloDatosApertura.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloDatosApertura.ImeMode = ImeMode.NoControl;
            fieldTituloDatosApertura.Location = new Point(65, 135);
            fieldTituloDatosApertura.Margin = new Padding(15, 5, 3, 3);
            fieldTituloDatosApertura.Name = "fieldTituloDatosApertura";
            fieldTituloDatosApertura.Size = new Size(399, 27);
            fieldTituloDatosApertura.TabIndex = 24;
            fieldTituloDatosApertura.Text = "      Datos de apertura de caja registradora :";
            fieldTituloDatosApertura.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutBotones
            // 
            layoutBotones.BackColor = Color.White;
            layoutBotones.ColumnCount = 4;
            layoutBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            layoutBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            layoutBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 22F));
            layoutBotones.Controls.Add(btnSalir, 2, 0);
            layoutBotones.Controls.Add(btnRegistrar, 1, 0);
            layoutBotones.Dock = DockStyle.Fill;
            layoutBotones.Location = new Point(13, 620);
            layoutBotones.Margin = new Padding(3, 0, 0, 0);
            layoutBotones.Name = "layoutBotones";
            layoutBotones.RowCount = 2;
            layoutBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBotones.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBotones.Size = new Size(487, 65);
            layoutBotones.TabIndex = 2;
            // 
            // btnSalir
            // 
            btnSalir.Animated = true;
            btnSalir.BorderColor = Color.Gainsboro;
            btnSalir.BorderRadius = 18;
            btnSalir.BorderThickness = 1;
            btnSalir.CustomizableEdges = customizableEdges9;
            btnSalir.Dock = DockStyle.Fill;
            btnSalir.FillColor = Color.White;
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.Gainsboro;
            btnSalir.HoverState.BorderColor = Color.PeachPuff;
            btnSalir.HoverState.FillColor = Color.PeachPuff;
            btnSalir.HoverState.ForeColor = Color.Black;
            btnSalir.Location = new Point(302, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSalir.Size = new Size(160, 39);
            btnSalir.TabIndex = 14;
            btnSalir.Text = "Salir";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Animated = true;
            btnRegistrar.BorderRadius = 18;
            btnRegistrar.CustomizableEdges = customizableEdges11;
            btnRegistrar.Dock = DockStyle.Fill;
            btnRegistrar.FillColor = Color.PeachPuff;
            btnRegistrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrar.ForeColor = Color.Black;
            btnRegistrar.Location = new Point(53, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnRegistrar.Size = new Size(243, 39);
            btnRegistrar.TabIndex = 15;
            btnRegistrar.Text = "Abrir caja registradora";
            // 
            // VistaRegistroCaja
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(500, 685);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaRegistroCaja";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroCaja";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ((ISupportInitialize) fieldIcono).EndInit();
            layoutTitulo.ResumeLayout(false);
            layoutDatosCaja.ResumeLayout(false);
            layoutBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutVista;
        private PictureBox fieldIcono;
        private Label fieldSubtitulo;
        private TableLayoutPanel layoutTitulo;
        private Guna2Button btnCerrar;
        private Label fieldTitulo;
        private TableLayoutPanel layoutBotones;
        private Guna2Button btnSalir;
        private Guna2Button btnRegistrar;
        private Guna2TextBox fieldNotas;
        private TableLayoutPanel layoutDatosCaja;
        private Guna2TextBox fieldSaldoInicial;
        private Guna2TextBox fieldNumeroCaja;
        private Label fieldTituloDatosApertura;
    }
}