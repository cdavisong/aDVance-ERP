using Guna.UI2.WinForms;

using System.ComponentModel;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Almacen {
    partial class VistaRegistroAlmacen {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaRegistroAlmacen));
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
            fieldNombre = new Guna2TextBox();
            layoutTitulo = new TableLayoutPanel();
            btnCerrar = new Guna2Button();
            fieldTitulo = new Label();
            fieldDireccion = new Guna2TextBox();
            fieldNotas = new Guna2TextBox();
            layoutBotones = new TableLayoutPanel();
            btnSalir = new Guna2Button();
            btnRegistrar = new Guna2Button();
            layoutBase.SuspendLayout();
            layoutVista.SuspendLayout();
            ((ISupportInitialize) fieldIcono).BeginInit();
            layoutTitulo.SuspendLayout();
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
            layoutBase.BackColor = Color.FromArgb(  217,   211,   204);
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
            layoutVista.BackColor = Color.FromArgb(  248,   244,   242);
            layoutVista.ColumnCount = 4;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.Controls.Add(fieldIcono, 1, 1);
            layoutVista.Controls.Add(fieldSubtitulo, 2, 2);
            layoutVista.Controls.Add(fieldNombre, 2, 4);
            layoutVista.Controls.Add(layoutTitulo, 2, 1);
            layoutVista.Controls.Add(fieldDireccion, 2, 6);
            layoutVista.Controls.Add(fieldNotas, 2, 8);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(13, 0);
            layoutVista.Margin = new Padding(3, 0, 0, 0);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 11;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
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
            fieldSubtitulo.Text = "Registro";
            // 
            // fieldNombre
            // 
            fieldNombre.Animated = true;
            fieldNombre.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldNombre.BorderRadius = 16;
            fieldNombre.Cursor = Cursors.IBeam;
            fieldNombre.CustomizableEdges = customizableEdges1;
            fieldNombre.DefaultText = "";
            fieldNombre.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldNombre.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldNombre.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldNombre.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldNombre.Dock = DockStyle.Fill;
            fieldNombre.FillColor = Color.FromArgb(  254,   254,   253);
            fieldNombre.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldNombre.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombre.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldNombre.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldNombre.IconLeft = (Image) resources.GetObject("fieldNombre.IconLeft");
            fieldNombre.IconLeftOffset = new Point(10, 0);
            fieldNombre.Location = new Point(55, 135);
            fieldNombre.Margin = new Padding(5);
            fieldNombre.Name = "fieldNombre";
            fieldNombre.PasswordChar = '\0';
            fieldNombre.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldNombre.PlaceholderText = "Nombre";
            fieldNombre.SelectedText = "";
            fieldNombre.ShadowDecoration.CustomizableEdges = customizableEdges2;
            fieldNombre.Size = new Size(407, 35);
            fieldNombre.TabIndex = 1;
            fieldNombre.TextOffset = new Point(5, 0);
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
            btnCerrar.CustomizableEdges = customizableEdges3;
            btnCerrar.Dock = DockStyle.Fill;
            btnCerrar.FillColor = Color.FromArgb(  250,   250,   250);
            btnCerrar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.Black;
            btnCerrar.HoverState.FillColor = Color.FromArgb(  250,   250,   250);
            btnCerrar.Image = (Image) resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(370, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.ShadowDecoration.CustomizableEdges = customizableEdges4;
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
            fieldTitulo.Text = "Almacén";
            fieldTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldDireccion
            // 
            fieldDireccion.Animated = true;
            fieldDireccion.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldDireccion.BorderRadius = 16;
            fieldDireccion.Cursor = Cursors.IBeam;
            fieldDireccion.CustomizableEdges = customizableEdges5;
            fieldDireccion.DefaultText = "";
            fieldDireccion.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldDireccion.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldDireccion.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldDireccion.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldDireccion.Dock = DockStyle.Fill;
            fieldDireccion.FillColor = Color.FromArgb(  254,   254,   253);
            fieldDireccion.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldDireccion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldDireccion.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldDireccion.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldDireccion.IconLeft = (Image) resources.GetObject("fieldDireccion.IconLeft");
            fieldDireccion.IconLeftOffset = new Point(10, -11);
            fieldDireccion.Location = new Point(55, 190);
            fieldDireccion.Margin = new Padding(5);
            fieldDireccion.Multiline = true;
            fieldDireccion.Name = "fieldDireccion";
            fieldDireccion.PasswordChar = '\0';
            fieldDireccion.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldDireccion.PlaceholderText = "Dirección";
            fieldDireccion.SelectedText = "";
            fieldDireccion.ShadowDecoration.CustomizableEdges = customizableEdges6;
            fieldDireccion.Size = new Size(407, 62);
            fieldDireccion.TabIndex = 22;
            fieldDireccion.TextOffset = new Point(5, 0);
            // 
            // fieldNotas
            // 
            fieldNotas.Animated = true;
            fieldNotas.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldNotas.BorderRadius = 16;
            fieldNotas.Cursor = Cursors.IBeam;
            fieldNotas.CustomizableEdges = customizableEdges7;
            fieldNotas.DefaultText = "";
            fieldNotas.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldNotas.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldNotas.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldNotas.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldNotas.Dock = DockStyle.Fill;
            fieldNotas.FillColor = Color.FromArgb(  254,   254,   253);
            fieldNotas.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldNotas.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNotas.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldNotas.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldNotas.IconLeft = (Image) resources.GetObject("fieldNotas.IconLeft");
            fieldNotas.IconLeftOffset = new Point(10, -11);
            fieldNotas.Location = new Point(55, 272);
            fieldNotas.Margin = new Padding(5);
            fieldNotas.Multiline = true;
            fieldNotas.Name = "fieldNotas";
            fieldNotas.PasswordChar = '\0';
            fieldNotas.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldNotas.PlaceholderText = "Notas";
            fieldNotas.SelectedText = "";
            fieldNotas.ShadowDecoration.CustomizableEdges = customizableEdges8;
            fieldNotas.Size = new Size(407, 62);
            fieldNotas.TabIndex = 23;
            fieldNotas.TextOffset = new Point(5, 0);
            // 
            // layoutBotones
            // 
            layoutBotones.BackColor = Color.FromArgb(  248,   244,   242);
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
            layoutBotones.TabIndex = 3;
            // 
            // btnSalir
            // 
            btnSalir.Animated = true;
            btnSalir.BorderColor = Color.FromArgb(  217,   211,   204);
            btnSalir.BorderRadius = 18;
            btnSalir.BorderThickness = 1;
            btnSalir.CustomizableEdges = customizableEdges9;
            btnSalir.Dock = DockStyle.Fill;
            btnSalir.FillColor = Color.FromArgb(  254,   254,   253);
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.FromArgb(  217,   211,   204);
            btnSalir.HoverState.BorderColor = Color.FromArgb(  217,   211,   204);
            btnSalir.HoverState.FillColor = Color.FromArgb(  217,   211,   204);
            btnSalir.HoverState.ForeColor = Color.FromArgb(  40,   37,   35);
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
            btnRegistrar.FillColor = Color.FromArgb(  217,   211,   204);
            btnRegistrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrar.ForeColor = Color.FromArgb(  40,   37,   35);
            btnRegistrar.Location = new Point(53, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnRegistrar.Size = new Size(243, 39);
            btnRegistrar.TabIndex = 15;
            btnRegistrar.Text = "Registrar almacén";
            // 
            // VistaRegistroAlmacen
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(500, 685);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaRegistroAlmacen";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroAlmacen";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ((ISupportInitialize) fieldIcono).EndInit();
            layoutTitulo.ResumeLayout(false);
            layoutBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutVista;
        private PictureBox fieldIcono;
        private Label fieldSubtitulo;
        private Guna2TextBox fieldNombre;
        private TableLayoutPanel layoutTitulo;
        private Guna2Button btnCerrar;
        private Label fieldTitulo;
        private TableLayoutPanel layoutBotones;
        private Guna2Button btnSalir;
        private Guna2Button btnRegistrar;
        private Guna2TextBox fieldDireccion;
        private Guna2TextBox fieldNotas;
    }
}