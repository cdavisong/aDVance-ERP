namespace aDVanceERP.Modulos.Taller.Vistas.CostosProduccion {
    partial class VistaRegistroOtrosCostos {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaRegistroOtrosCostos));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            separador2 = new Guna.UI2.WinForms.Guna2Separator();
            fieldObservaciones = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            fieldTituloResumen = new Label();
            layoutMontoOtrosCostos = new TableLayoutPanel();
            fieldOtrosCostos = new Guna.UI2.WinForms.Guna2TextBox();
            fieldTituloOtrosCostos = new Label();
            layoutBase.SuspendLayout();
            layoutMontoOtrosCostos.SuspendLayout();
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
            layoutBase.BackColor = Color.White;
            layoutBase.ColumnCount = 1;
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutBase.Controls.Add(separador2, 0, 4);
            layoutBase.Controls.Add(fieldObservaciones, 0, 3);
            layoutBase.Controls.Add(label1, 0, 6);
            layoutBase.Controls.Add(fieldTituloResumen, 0, 5);
            layoutBase.Controls.Add(layoutMontoOtrosCostos, 0, 1);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 7;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBase.Size = new Size(417, 470);
            layoutBase.TabIndex = 0;
            // 
            // separador2
            // 
            separador2.Dock = DockStyle.Fill;
            separador2.FillColor = Color.FromArgb(  208,   197,   188);
            separador2.Location = new Point(3, 165);
            separador2.Name = "separador2";
            separador2.Size = new Size(411, 14);
            separador2.TabIndex = 40;
            // 
            // fieldObservaciones
            // 
            fieldObservaciones.Animated = true;
            fieldObservaciones.BorderColor = Color.Gainsboro;
            fieldObservaciones.BorderRadius = 16;
            fieldObservaciones.Cursor = Cursors.IBeam;
            fieldObservaciones.CustomizableEdges = customizableEdges1;
            fieldObservaciones.DefaultText = "";
            fieldObservaciones.DisabledState.BorderColor = Color.White;
            fieldObservaciones.DisabledState.ForeColor = Color.DimGray;
            fieldObservaciones.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldObservaciones.Dock = DockStyle.Fill;
            fieldObservaciones.FocusedState.BorderColor = Color.SandyBrown;
            fieldObservaciones.Font = new Font("Segoe UI", 11.25F);
            fieldObservaciones.ForeColor = Color.Black;
            fieldObservaciones.HoverState.BorderColor = Color.SandyBrown;
            fieldObservaciones.IconLeft = (Image) resources.GetObject("fieldObservaciones.IconLeft");
            fieldObservaciones.IconLeftOffset = new Point(10, -11);
            fieldObservaciones.Location = new Point(5, 95);
            fieldObservaciones.Margin = new Padding(5);
            fieldObservaciones.Multiline = true;
            fieldObservaciones.Name = "fieldObservaciones";
            fieldObservaciones.PasswordChar = '\0';
            fieldObservaciones.PlaceholderForeColor = Color.DimGray;
            fieldObservaciones.PlaceholderText = "Observaciones";
            fieldObservaciones.SelectedText = "";
            fieldObservaciones.ShadowDecoration.CustomizableEdges = customizableEdges2;
            fieldObservaciones.Size = new Size(407, 62);
            fieldObservaciones.TabIndex = 39;
            fieldObservaciones.TextOffset = new Point(5, 0);
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 11.25F);
            label1.ForeColor = Color.DimGray;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(15, 222);
            label1.Margin = new Padding(15, 5, 3, 3);
            label1.Name = "label1";
            label1.Size = new Size(399, 245);
            label1.TabIndex = 24;
            label1.Text = "...";
            // 
            // fieldTituloResumen
            // 
            fieldTituloResumen.Dock = DockStyle.Fill;
            fieldTituloResumen.Font = new Font("Segoe UI", 11.25F);
            fieldTituloResumen.ForeColor = Color.DimGray;
            fieldTituloResumen.Image = (Image) resources.GetObject("fieldTituloResumen.Image");
            fieldTituloResumen.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloResumen.ImeMode = ImeMode.NoControl;
            fieldTituloResumen.Location = new Point(15, 187);
            fieldTituloResumen.Margin = new Padding(15, 5, 3, 3);
            fieldTituloResumen.Name = "fieldTituloResumen";
            fieldTituloResumen.Size = new Size(399, 27);
            fieldTituloResumen.TabIndex = 23;
            fieldTituloResumen.Text = "      Resumen (CD) :";
            fieldTituloResumen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutMontoOtrosCostos
            // 
            layoutMontoOtrosCostos.ColumnCount = 2;
            layoutMontoOtrosCostos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutMontoOtrosCostos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutMontoOtrosCostos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutMontoOtrosCostos.Controls.Add(fieldOtrosCostos, 1, 0);
            layoutMontoOtrosCostos.Controls.Add(fieldTituloOtrosCostos, 0, 0);
            layoutMontoOtrosCostos.Dock = DockStyle.Fill;
            layoutMontoOtrosCostos.Location = new Point(0, 35);
            layoutMontoOtrosCostos.Margin = new Padding(0);
            layoutMontoOtrosCostos.Name = "layoutMontoOtrosCostos";
            layoutMontoOtrosCostos.RowCount = 1;
            layoutMontoOtrosCostos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutMontoOtrosCostos.Size = new Size(417, 45);
            layoutMontoOtrosCostos.TabIndex = 22;
            // 
            // fieldOtrosCostos
            // 
            fieldOtrosCostos.Animated = true;
            fieldOtrosCostos.AutoRoundedCorners = true;
            fieldOtrosCostos.BorderColor = Color.Gainsboro;
            fieldOtrosCostos.BorderRadius = 18;
            fieldOtrosCostos.Cursor = Cursors.IBeam;
            fieldOtrosCostos.CustomizableEdges = customizableEdges3;
            fieldOtrosCostos.DefaultText = "";
            fieldOtrosCostos.DisabledState.BorderColor = Color.White;
            fieldOtrosCostos.DisabledState.ForeColor = Color.DimGray;
            fieldOtrosCostos.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldOtrosCostos.Dock = DockStyle.Fill;
            fieldOtrosCostos.FocusedState.BorderColor = Color.SandyBrown;
            fieldOtrosCostos.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldOtrosCostos.ForeColor = Color.Black;
            fieldOtrosCostos.HoverState.BorderColor = Color.SandyBrown;
            fieldOtrosCostos.IconLeftOffset = new Point(10, 0);
            fieldOtrosCostos.IconRight = (Image) resources.GetObject("fieldOtrosCostos.IconRight");
            fieldOtrosCostos.IconRightOffset = new Point(6, 0);
            fieldOtrosCostos.IconRightSize = new Size(12, 12);
            fieldOtrosCostos.Location = new Point(290, 3);
            fieldOtrosCostos.Name = "fieldOtrosCostos";
            fieldOtrosCostos.PasswordChar = '\0';
            fieldOtrosCostos.PlaceholderForeColor = Color.DimGray;
            fieldOtrosCostos.PlaceholderText = "0.00";
            fieldOtrosCostos.SelectedText = "";
            fieldOtrosCostos.ShadowDecoration.CustomizableEdges = customizableEdges4;
            fieldOtrosCostos.Size = new Size(124, 39);
            fieldOtrosCostos.TabIndex = 6;
            fieldOtrosCostos.TextAlign = HorizontalAlignment.Right;
            fieldOtrosCostos.TextOffset = new Point(5, 0);
            // 
            // fieldTituloOtrosCostos
            // 
            fieldTituloOtrosCostos.Dock = DockStyle.Fill;
            fieldTituloOtrosCostos.Font = new Font("Segoe UI", 11.25F);
            fieldTituloOtrosCostos.ForeColor = Color.DimGray;
            fieldTituloOtrosCostos.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloOtrosCostos.ImeMode = ImeMode.NoControl;
            fieldTituloOtrosCostos.Location = new Point(15, 5);
            fieldTituloOtrosCostos.Margin = new Padding(15, 5, 3, 3);
            fieldTituloOtrosCostos.Name = "fieldTituloOtrosCostos";
            fieldTituloOtrosCostos.Size = new Size(269, 37);
            fieldTituloOtrosCostos.TabIndex = 0;
            fieldTituloOtrosCostos.Text = "  ●   Otros costos de producción";
            fieldTituloOtrosCostos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VistaRegistroOtrosCostos
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(417, 470);
            Controls.Add(layoutBase);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VistaRegistroOtrosCostos";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroProductoDatosGenerales";
            layoutBase.ResumeLayout(false);
            layoutMontoOtrosCostos.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private Guna.UI2.WinForms.Guna2ComboBox fieldCategoriaProducto;
        private Label fieldTituloOtrosCostos;
        private TableLayoutPanel layoutMontoOtrosCostos;
        private Guna.UI2.WinForms.Guna2TextBox fieldOtrosCostos;
        private Label fieldTituloOtrosCostos;
        private Label fieldTituloResumen;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox fieldObservaciones;
        private Guna.UI2.WinForms.Guna2Separator separador2;
    }
}