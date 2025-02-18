using Guna.UI2.WinForms;

namespace Manigest.Desktop.MVP.Vistas.ContenedorModulos {
    partial class VistaContenedorModulos {
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaContenedorModulos));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutDistribucion = new TableLayoutPanel();
            layoutMenuLateral = new TableLayoutPanel();
            btnAyuda = new Guna2CircleButton();
            layoutModulos = new FlowLayoutPanel();
            btnInicio = new Guna2CircleButton();
            btnModuloEstadisticas = new Guna2CircleButton();
            btnModuloContactos = new Guna2CircleButton();
            btnModuloInventario = new Guna2CircleButton();
            btnModuloVentas = new Guna2CircleButton();
            contenedorVistas = new Panel();
            btnModuloFinanzas = new Guna2CircleButton();
            layoutBase.SuspendLayout();
            layoutDistribucion.SuspendLayout();
            layoutMenuLateral.SuspendLayout();
            layoutModulos.SuspendLayout();
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
            layoutBase.Size = new Size(1356, 608);
            layoutBase.TabIndex = 1;
            // 
            // layoutDistribucion
            // 
            layoutDistribucion.BackColor = Color.FromArgb(  248,   244,   242);
            layoutDistribucion.ColumnCount = 2;
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutDistribucion.Controls.Add(layoutMenuLateral, 0, 0);
            layoutDistribucion.Controls.Add(contenedorVistas, 1, 0);
            layoutDistribucion.Dock = DockStyle.Fill;
            layoutDistribucion.Location = new Point(0, 0);
            layoutDistribucion.Margin = new Padding(0);
            layoutDistribucion.Name = "layoutDistribucion";
            layoutDistribucion.RowCount = 1;
            layoutDistribucion.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutDistribucion.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutDistribucion.Size = new Size(1356, 608);
            layoutDistribucion.TabIndex = 0;
            // 
            // layoutMenuLateral
            // 
            layoutMenuLateral.BackColor = Color.FromArgb(  243,   243,   243);
            layoutMenuLateral.ColumnCount = 1;
            layoutMenuLateral.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutMenuLateral.Controls.Add(btnAyuda, 0, 1);
            layoutMenuLateral.Controls.Add(layoutModulos, 0, 0);
            layoutMenuLateral.Dock = DockStyle.Fill;
            layoutMenuLateral.Location = new Point(0, 0);
            layoutMenuLateral.Margin = new Padding(0);
            layoutMenuLateral.Name = "layoutMenuLateral";
            layoutMenuLateral.RowCount = 2;
            layoutMenuLateral.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutMenuLateral.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            layoutMenuLateral.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutMenuLateral.Size = new Size(50, 608);
            layoutMenuLateral.TabIndex = 0;
            // 
            // btnAyuda
            // 
            btnAyuda.BackColor = Color.FromArgb(  243,   243,   243);
            btnAyuda.CheckedState.FillColor = Color.FromArgb(  217,   211,   204);
            btnAyuda.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnAyuda.CustomImages.ImageSize = new Size(24, 24);
            btnAyuda.FillColor = Color.White;
            btnAyuda.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAyuda.ForeColor = Color.White;
            btnAyuda.ImageSize = new Size(24, 24);
            btnAyuda.Location = new Point(3, 561);
            btnAyuda.Name = "btnAyuda";
            btnAyuda.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnAyuda.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnAyuda.Size = new Size(44, 44);
            btnAyuda.TabIndex = 3;
            // 
            // layoutModulos
            // 
            layoutModulos.BackColor = Color.FromArgb(  243,   243,   243);
            layoutModulos.Controls.Add(btnInicio);
            layoutModulos.Controls.Add(btnModuloEstadisticas);
            layoutModulos.Controls.Add(btnModuloContactos);
            layoutModulos.Controls.Add(btnModuloFinanzas);
            layoutModulos.Controls.Add(btnModuloInventario);
            layoutModulos.Controls.Add(btnModuloVentas);
            layoutModulos.Dock = DockStyle.Top;
            layoutModulos.Location = new Point(0, 0);
            layoutModulos.Margin = new Padding(0);
            layoutModulos.Name = "layoutModulos";
            layoutModulos.Size = new Size(50, 508);
            layoutModulos.TabIndex = 0;
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.FromArgb(  243,   243,   243);
            btnInicio.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnInicio.CheckedState.FillColor = Color.FromArgb(  217,   211,   204);
            btnInicio.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnInicio.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnInicio.CustomImages.ImageSize = new Size(24, 24);
            btnInicio.FillColor = Color.FromArgb(  243,   243,   243);
            btnInicio.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnInicio.ForeColor = Color.White;
            btnInicio.ImageSize = new Size(24, 24);
            btnInicio.Location = new Point(3, 3);
            btnInicio.Name = "btnInicio";
            btnInicio.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnInicio.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnInicio.Size = new Size(44, 44);
            btnInicio.TabIndex = 0;
            // 
            // btnModuloEstadisticas
            // 
            btnModuloEstadisticas.BackColor = Color.FromArgb(  243,   243,   243);
            btnModuloEstadisticas.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnModuloEstadisticas.CheckedState.FillColor = Color.FromArgb(  217,   211,   204);
            btnModuloEstadisticas.CustomImages.Image = (Image) resources.GetObject("resource.Image1");
            btnModuloEstadisticas.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnModuloEstadisticas.CustomImages.ImageSize = new Size(24, 24);
            btnModuloEstadisticas.FillColor = Color.FromArgb(  243,   243,   243);
            btnModuloEstadisticas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnModuloEstadisticas.ForeColor = Color.White;
            btnModuloEstadisticas.ImageSize = new Size(24, 24);
            btnModuloEstadisticas.Location = new Point(3, 53);
            btnModuloEstadisticas.Name = "btnModuloEstadisticas";
            btnModuloEstadisticas.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnModuloEstadisticas.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnModuloEstadisticas.Size = new Size(44, 44);
            btnModuloEstadisticas.TabIndex = 1;
            // 
            // btnModuloContactos
            // 
            btnModuloContactos.BackColor = Color.FromArgb(  243,   243,   243);
            btnModuloContactos.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnModuloContactos.CheckedState.FillColor = Color.FromArgb(  217,   211,   204);
            btnModuloContactos.CustomImages.Image = (Image) resources.GetObject("resource.Image2");
            btnModuloContactos.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnModuloContactos.CustomImages.ImageSize = new Size(24, 24);
            btnModuloContactos.FillColor = Color.FromArgb(  243,   243,   243);
            btnModuloContactos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnModuloContactos.ForeColor = Color.White;
            btnModuloContactos.ImageSize = new Size(24, 24);
            btnModuloContactos.Location = new Point(3, 103);
            btnModuloContactos.Name = "btnModuloContactos";
            btnModuloContactos.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnModuloContactos.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnModuloContactos.Size = new Size(44, 44);
            btnModuloContactos.TabIndex = 3;
            // 
            // btnModuloInventario
            // 
            btnModuloInventario.BackColor = Color.FromArgb(  243,   243,   243);
            btnModuloInventario.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnModuloInventario.CheckedState.FillColor = Color.FromArgb(  217,   211,   204);
            btnModuloInventario.CustomImages.Image = (Image) resources.GetObject("resource.Image4");
            btnModuloInventario.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnModuloInventario.CustomImages.ImageSize = new Size(24, 24);
            btnModuloInventario.FillColor = Color.FromArgb(  243,   243,   243);
            btnModuloInventario.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnModuloInventario.ForeColor = Color.White;
            btnModuloInventario.ImageSize = new Size(24, 24);
            btnModuloInventario.Location = new Point(3, 203);
            btnModuloInventario.Name = "btnModuloInventario";
            btnModuloInventario.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnModuloInventario.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnModuloInventario.Size = new Size(44, 44);
            btnModuloInventario.TabIndex = 2;
            // 
            // btnModuloVentas
            // 
            btnModuloVentas.BackColor = Color.FromArgb(  243,   243,   243);
            btnModuloVentas.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnModuloVentas.CheckedState.FillColor = Color.FromArgb(  217,   211,   204);
            btnModuloVentas.CustomImages.Image = (Image) resources.GetObject("resource.Image5");
            btnModuloVentas.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnModuloVentas.CustomImages.ImageSize = new Size(24, 24);
            btnModuloVentas.FillColor = Color.FromArgb(  243,   243,   243);
            btnModuloVentas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnModuloVentas.ForeColor = Color.White;
            btnModuloVentas.ImageSize = new Size(24, 24);
            btnModuloVentas.Location = new Point(3, 253);
            btnModuloVentas.Name = "btnModuloVentas";
            btnModuloVentas.ShadowDecoration.CustomizableEdges = customizableEdges7;
            btnModuloVentas.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnModuloVentas.Size = new Size(44, 44);
            btnModuloVentas.TabIndex = 4;
            // 
            // contenedorVistas
            // 
            contenedorVistas.BackColor = Color.FromArgb(  248,   244,   242);
            contenedorVistas.Dock = DockStyle.Fill;
            contenedorVistas.Location = new Point(50, 0);
            contenedorVistas.Margin = new Padding(0);
            contenedorVistas.Name = "contenedorVistas";
            contenedorVistas.Size = new Size(1306, 608);
            contenedorVistas.TabIndex = 1;
            // 
            // btnModuloFinanzas
            // 
            btnModuloFinanzas.BackColor = Color.FromArgb(  243,   243,   243);
            btnModuloFinanzas.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnModuloFinanzas.CheckedState.FillColor = Color.FromArgb(  217,   211,   204);
            btnModuloFinanzas.CustomImages.Image = (Image) resources.GetObject("resource.Image3");
            btnModuloFinanzas.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnModuloFinanzas.CustomImages.ImageSize = new Size(24, 24);
            btnModuloFinanzas.FillColor = Color.FromArgb(  243,   243,   243);
            btnModuloFinanzas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnModuloFinanzas.ForeColor = Color.White;
            btnModuloFinanzas.ImageSize = new Size(24, 24);
            btnModuloFinanzas.Location = new Point(3, 153);
            btnModuloFinanzas.Name = "btnModuloFinanzas";
            btnModuloFinanzas.ShadowDecoration.CustomizableEdges = customizableEdges5;
            btnModuloFinanzas.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnModuloFinanzas.Size = new Size(44, 44);
            btnModuloFinanzas.TabIndex = 5;
            // 
            // VistaContenedorModulos
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(  250,   250,   250);
            ClientSize = new Size(1356, 608);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaContenedorModulos";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "FormularioFormatoBase1";
            layoutBase.ResumeLayout(false);
            layoutDistribucion.ResumeLayout(false);
            layoutMenuLateral.ResumeLayout(false);
            layoutModulos.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutDistribucion;
        private TableLayoutPanel layoutMenuLateral;
        private FlowLayoutPanel layoutModulos;
        private Panel contenedorVistas;
        private Guna2CircleButton btnInicio;
        private Guna2CircleButton btnModuloEstadisticas;
        private Guna2CircleButton btnModuloInventario;
        private Guna2CircleButton btnAyuda;
        private Guna2CircleButton btnModuloContactos;
        private Guna2CircleButton btnModuloVentas;
        private Guna2CircleButton btnModuloFinanzas;
    }
}