using Guna.UI2.WinForms;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Menu {
    partial class VistaMenuInventario {
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaMenuInventario));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutDistribucion = new TableLayoutPanel();
            btnAlmacenes = new Guna2Button();
            fieldTitulo = new Label();
            panelRelleno = new Panel();
            btnArticulos = new Guna2Button();
            btnMovimientos = new Guna2Button();
            layoutBase.SuspendLayout();
            layoutDistribucion.SuspendLayout();
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
            layoutBase.BackColor = Color.FromArgb(  204,   204,   204);
            layoutBase.ColumnCount = 1;
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutBase.Controls.Add(layoutDistribucion, 0, 0);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 1;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutBase.Size = new Size(994, 50);
            layoutBase.TabIndex = 0;
            // 
            // layoutDistribucion
            // 
            layoutDistribucion.ColumnCount = 5;
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutDistribucion.Controls.Add(btnMovimientos, 2, 0);
            layoutDistribucion.Controls.Add(btnAlmacenes, 3, 0);
            layoutDistribucion.Controls.Add(fieldTitulo, 0, 0);
            layoutDistribucion.Controls.Add(panelRelleno, 4, 0);
            layoutDistribucion.Controls.Add(btnArticulos, 1, 0);
            layoutDistribucion.Dock = DockStyle.Fill;
            layoutDistribucion.Location = new Point(0, 0);
            layoutDistribucion.Margin = new Padding(0);
            layoutDistribucion.Name = "layoutDistribucion";
            layoutDistribucion.RowCount = 1;
            layoutDistribucion.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutDistribucion.Size = new Size(994, 50);
            layoutDistribucion.TabIndex = 0;
            // 
            // btnAlmacenes
            // 
            btnAlmacenes.Animated = true;
            btnAlmacenes.BackColor = Color.FromArgb(  248,   244,   242);
            btnAlmacenes.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnAlmacenes.CheckedState.FillColor = Color.FromArgb(  248,   244,   242);
            btnAlmacenes.CheckedState.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAlmacenes.CustomImages.CheckedImage = (Image) resources.GetObject("resource.CheckedImage1");
            btnAlmacenes.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnAlmacenes.CustomImages.ImageOffset = new Point(0, 30);
            btnAlmacenes.CustomImages.ImageSize = new Size(131, 8);
            btnAlmacenes.CustomizableEdges = customizableEdges3;
            btnAlmacenes.Dock = DockStyle.Fill;
            btnAlmacenes.FillColor = Color.FromArgb(  248,   244,   242);
            btnAlmacenes.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAlmacenes.ForeColor = Color.FromArgb(  40,   37,   35);
            btnAlmacenes.Location = new Point(440, 0);
            btnAlmacenes.Margin = new Padding(0);
            btnAlmacenes.Name = "btnAlmacenes";
            btnAlmacenes.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAlmacenes.Size = new Size(160, 50);
            btnAlmacenes.TabIndex = 7;
            btnAlmacenes.Text = "Almacenes";
            // 
            // fieldTitulo
            // 
            fieldTitulo.BackColor = Color.FromArgb(  248,   244,   242);
            fieldTitulo.Dock = DockStyle.Fill;
            fieldTitulo.Font = new Font("Microsoft PhagsPa", 12F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTitulo.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldTitulo.ImeMode = ImeMode.NoControl;
            fieldTitulo.Location = new Point(0, 0);
            fieldTitulo.Margin = new Padding(0);
            fieldTitulo.Name = "fieldTitulo";
            fieldTitulo.Size = new Size(120, 50);
            fieldTitulo.TabIndex = 4;
            fieldTitulo.Text = "Inventario";
            fieldTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelRelleno
            // 
            panelRelleno.BackColor = Color.FromArgb(  248,   244,   242);
            panelRelleno.Dock = DockStyle.Fill;
            panelRelleno.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            panelRelleno.Location = new Point(600, 0);
            panelRelleno.Margin = new Padding(0);
            panelRelleno.Name = "panelRelleno";
            panelRelleno.Size = new Size(394, 50);
            panelRelleno.TabIndex = 0;
            // 
            // btnArticulos
            // 
            btnArticulos.Animated = true;
            btnArticulos.BackColor = Color.FromArgb(  248,   244,   242);
            btnArticulos.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnArticulos.CheckedState.FillColor = Color.FromArgb(  248,   244,   242);
            btnArticulos.CheckedState.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnArticulos.CustomImages.CheckedImage = (Image) resources.GetObject("resource.CheckedImage2");
            btnArticulos.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnArticulos.CustomImages.ImageOffset = new Point(0, 30);
            btnArticulos.CustomImages.ImageSize = new Size(131, 8);
            btnArticulos.CustomizableEdges = customizableEdges5;
            btnArticulos.Dock = DockStyle.Fill;
            btnArticulos.FillColor = Color.FromArgb(  248,   244,   242);
            btnArticulos.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnArticulos.ForeColor = Color.FromArgb(  40,   37,   35);
            btnArticulos.Location = new Point(120, 0);
            btnArticulos.Margin = new Padding(0);
            btnArticulos.Name = "btnArticulos";
            btnArticulos.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnArticulos.Size = new Size(160, 50);
            btnArticulos.TabIndex = 9;
            btnArticulos.Text = "Articulos";
            // 
            // btnMovimientos
            // 
            btnMovimientos.Animated = true;
            btnMovimientos.BackColor = Color.FromArgb(  248,   244,   242);
            btnMovimientos.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnMovimientos.CheckedState.FillColor = Color.FromArgb(  248,   244,   242);
            btnMovimientos.CheckedState.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnMovimientos.CustomImages.CheckedImage = (Image) resources.GetObject("resource.CheckedImage");
            btnMovimientos.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnMovimientos.CustomImages.ImageOffset = new Point(0, 30);
            btnMovimientos.CustomImages.ImageSize = new Size(131, 8);
            btnMovimientos.CustomizableEdges = customizableEdges1;
            btnMovimientos.Dock = DockStyle.Fill;
            btnMovimientos.FillColor = Color.FromArgb(  248,   244,   242);
            btnMovimientos.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnMovimientos.ForeColor = Color.FromArgb(  40,   37,   35);
            btnMovimientos.Location = new Point(280, 0);
            btnMovimientos.Margin = new Padding(0);
            btnMovimientos.Name = "btnMovimientos";
            btnMovimientos.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnMovimientos.Size = new Size(160, 50);
            btnMovimientos.TabIndex = 8;
            btnMovimientos.Text = "Movimientos";
            // 
            // VistaMenuInventario
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(  204,   204,   204);
            ClientSize = new Size(994, 50);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaMenuInventario";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaMenu";
            layoutBase.ResumeLayout(false);
            layoutDistribucion.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutDistribucion;
        private Panel panelRelleno;
        private Label fieldTitulo;
        private Guna2Button btnAlmacenes;
        private Guna2Button btnArticulos;
        private Guna2Button btnMovimientos;
    }
}