namespace aDVanceERP.Modulos.Taller.Vistas.CostosProduccion {
    partial class VistaRegistroMateriaPrima {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaRegistroMateriaPrima));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutSubtotal = new TableLayoutPanel();
            symbolPeso = new Label();
            fieldCostoTotalMateriales = new Label();
            fieldTituloCostoTotalMateriales = new Label();
            fieldDescripcionMateriaPrima = new Label();
            layoutGestionMateriaPrima = new TableLayoutPanel();
            btnAdicionarMateriaPrima = new Guna.UI2.WinForms.Guna2Button();
            fieldCantidad = new Guna.UI2.WinForms.Guna2TextBox();
            fieldNombreProducto = new Guna.UI2.WinForms.Guna2TextBox();
            fieldTituloCategoriaProducto = new Label();
            contenedorVistas = new Panel();
            separador1 = new Guna.UI2.WinForms.Guna2Separator();
            layoutEncabezadosTabla = new TableLayoutPanel();
            fieldTituloCantidad = new Label();
            fieldTituloPrecio = new Label();
            fieldTituloMateriaPrima = new Label();
            layoutBase.SuspendLayout();
            layoutSubtotal.SuspendLayout();
            layoutGestionMateriaPrima.SuspendLayout();
            layoutEncabezadosTabla.SuspendLayout();
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
            layoutBase.Controls.Add(layoutSubtotal, 0, 6);
            layoutBase.Controls.Add(fieldDescripcionMateriaPrima, 0, 2);
            layoutBase.Controls.Add(layoutGestionMateriaPrima, 0, 1);
            layoutBase.Controls.Add(fieldTituloCategoriaProducto, 0, 0);
            layoutBase.Controls.Add(contenedorVistas, 0, 4);
            layoutBase.Controls.Add(separador1, 0, 5);
            layoutBase.Controls.Add(layoutEncabezadosTabla, 0, 3);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 7;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.Size = new Size(417, 470);
            layoutBase.TabIndex = 0;
            // 
            // layoutSubtotal
            // 
            layoutSubtotal.ColumnCount = 3;
            layoutSubtotal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutSubtotal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutSubtotal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutSubtotal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutSubtotal.Controls.Add(symbolPeso, 0, 0);
            layoutSubtotal.Controls.Add(fieldCostoTotalMateriales, 0, 0);
            layoutSubtotal.Controls.Add(fieldTituloCostoTotalMateriales, 0, 0);
            layoutSubtotal.Dock = DockStyle.Fill;
            layoutSubtotal.Location = new Point(0, 425);
            layoutSubtotal.Margin = new Padding(0);
            layoutSubtotal.Name = "layoutSubtotal";
            layoutSubtotal.RowCount = 1;
            layoutSubtotal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutSubtotal.Size = new Size(417, 45);
            layoutSubtotal.TabIndex = 24;
            // 
            // symbolPeso
            // 
            symbolPeso.Dock = DockStyle.Fill;
            symbolPeso.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            symbolPeso.ForeColor = Color.Black;
            symbolPeso.ImageAlign = ContentAlignment.MiddleLeft;
            symbolPeso.ImeMode = ImeMode.NoControl;
            symbolPeso.Location = new Point(400, 5);
            symbolPeso.Margin = new Padding(3, 5, 3, 3);
            symbolPeso.Name = "symbolPeso";
            symbolPeso.Size = new Size(14, 37);
            symbolPeso.TabIndex = 2;
            symbolPeso.Text = "$";
            symbolPeso.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldCostoTotalMateriales
            // 
            fieldCostoTotalMateriales.Dock = DockStyle.Fill;
            fieldCostoTotalMateriales.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldCostoTotalMateriales.ForeColor = Color.Black;
            fieldCostoTotalMateriales.ImageAlign = ContentAlignment.MiddleLeft;
            fieldCostoTotalMateriales.ImeMode = ImeMode.NoControl;
            fieldCostoTotalMateriales.Location = new Point(302, 5);
            fieldCostoTotalMateriales.Margin = new Padding(15, 5, 3, 3);
            fieldCostoTotalMateriales.Name = "fieldCostoTotalMateriales";
            fieldCostoTotalMateriales.Size = new Size(92, 37);
            fieldCostoTotalMateriales.TabIndex = 1;
            fieldCostoTotalMateriales.Text = "0.00";
            fieldCostoTotalMateriales.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldTituloCostoTotalMateriales
            // 
            fieldTituloCostoTotalMateriales.Dock = DockStyle.Fill;
            fieldTituloCostoTotalMateriales.Font = new Font("Segoe UI", 11.25F);
            fieldTituloCostoTotalMateriales.ForeColor = Color.DimGray;
            fieldTituloCostoTotalMateriales.Image = (Image) resources.GetObject("fieldTituloCostoTotalMateriales.Image");
            fieldTituloCostoTotalMateriales.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloCostoTotalMateriales.ImeMode = ImeMode.NoControl;
            fieldTituloCostoTotalMateriales.Location = new Point(15, 5);
            fieldTituloCostoTotalMateriales.Margin = new Padding(15, 5, 3, 3);
            fieldTituloCostoTotalMateriales.Name = "fieldTituloCostoTotalMateriales";
            fieldTituloCostoTotalMateriales.Size = new Size(269, 37);
            fieldTituloCostoTotalMateriales.TabIndex = 0;
            fieldTituloCostoTotalMateriales.Text = "      Costo total en materiales";
            fieldTituloCostoTotalMateriales.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldDescripcionMateriaPrima
            // 
            fieldDescripcionMateriaPrima.Dock = DockStyle.Fill;
            fieldDescripcionMateriaPrima.Font = new Font("Segoe UI", 11.25F);
            fieldDescripcionMateriaPrima.ForeColor = Color.Black;
            fieldDescripcionMateriaPrima.ImeMode = ImeMode.NoControl;
            fieldDescripcionMateriaPrima.Location = new Point(10, 85);
            fieldDescripcionMateriaPrima.Margin = new Padding(10, 5, 10, 1);
            fieldDescripcionMateriaPrima.Name = "fieldDescripcionMateriaPrima";
            fieldDescripcionMateriaPrima.Size = new Size(397, 66);
            fieldDescripcionMateriaPrima.TabIndex = 20;
            fieldDescripcionMateriaPrima.Text = "No ha descripción disponible para la materia prima seleccionada";
            // 
            // layoutGestionMateriaPrima
            // 
            layoutGestionMateriaPrima.ColumnCount = 3;
            layoutGestionMateriaPrima.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutGestionMateriaPrima.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            layoutGestionMateriaPrima.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutGestionMateriaPrima.Controls.Add(btnAdicionarMateriaPrima, 2, 0);
            layoutGestionMateriaPrima.Controls.Add(fieldCantidad, 1, 0);
            layoutGestionMateriaPrima.Controls.Add(fieldNombreProducto, 0, 0);
            layoutGestionMateriaPrima.Dock = DockStyle.Fill;
            layoutGestionMateriaPrima.Location = new Point(0, 35);
            layoutGestionMateriaPrima.Margin = new Padding(0);
            layoutGestionMateriaPrima.Name = "layoutGestionMateriaPrima";
            layoutGestionMateriaPrima.RowCount = 1;
            layoutGestionMateriaPrima.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutGestionMateriaPrima.Size = new Size(417, 45);
            layoutGestionMateriaPrima.TabIndex = 19;
            // 
            // btnAdicionarMateriaPrima
            // 
            btnAdicionarMateriaPrima.Animated = true;
            btnAdicionarMateriaPrima.BorderRadius = 18;
            btnAdicionarMateriaPrima.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnAdicionarMateriaPrima.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnAdicionarMateriaPrima.CustomizableEdges = customizableEdges1;
            btnAdicionarMateriaPrima.DialogResult = DialogResult.Cancel;
            btnAdicionarMateriaPrima.Dock = DockStyle.Fill;
            btnAdicionarMateriaPrima.Enabled = false;
            btnAdicionarMateriaPrima.FillColor = Color.PeachPuff;
            btnAdicionarMateriaPrima.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnAdicionarMateriaPrima.ForeColor = Color.White;
            btnAdicionarMateriaPrima.Location = new Point(372, 5);
            btnAdicionarMateriaPrima.Margin = new Padding(5);
            btnAdicionarMateriaPrima.Name = "btnAdicionarMateriaPrima";
            btnAdicionarMateriaPrima.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdicionarMateriaPrima.Size = new Size(40, 35);
            btnAdicionarMateriaPrima.TabIndex = 2;
            // 
            // fieldCantidad
            // 
            fieldCantidad.Animated = true;
            fieldCantidad.BorderColor = Color.Gainsboro;
            fieldCantidad.BorderRadius = 16;
            fieldCantidad.Cursor = Cursors.IBeam;
            fieldCantidad.CustomizableEdges = customizableEdges3;
            fieldCantidad.DefaultText = "";
            fieldCantidad.DisabledState.BorderColor = Color.Gainsboro;
            fieldCantidad.DisabledState.FillColor = Color.White;
            fieldCantidad.DisabledState.ForeColor = Color.DimGray;
            fieldCantidad.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldCantidad.Dock = DockStyle.Fill;
            fieldCantidad.FocusedState.BorderColor = Color.SandyBrown;
            fieldCantidad.Font = new Font("Segoe UI", 11.25F);
            fieldCantidad.ForeColor = Color.Black;
            fieldCantidad.HoverState.BorderColor = Color.SandyBrown;
            fieldCantidad.IconLeftOffset = new Point(10, 0);
            fieldCantidad.IconRight = (Image) resources.GetObject("fieldCantidad.IconRight");
            fieldCantidad.IconRightOffset = new Point(6, 0);
            fieldCantidad.IconRightSize = new Size(12, 12);
            fieldCantidad.Location = new Point(277, 5);
            fieldCantidad.Margin = new Padding(5);
            fieldCantidad.Name = "fieldCantidad";
            fieldCantidad.PasswordChar = '\0';
            fieldCantidad.PlaceholderForeColor = Color.DimGray;
            fieldCantidad.PlaceholderText = "Cant.";
            fieldCantidad.SelectedText = "";
            fieldCantidad.ShadowDecoration.CustomizableEdges = customizableEdges4;
            fieldCantidad.Size = new Size(85, 35);
            fieldCantidad.TabIndex = 1;
            fieldCantidad.TextAlign = HorizontalAlignment.Right;
            fieldCantidad.TextOffset = new Point(5, 0);
            // 
            // fieldNombreProducto
            // 
            fieldNombreProducto.Animated = true;
            fieldNombreProducto.BorderColor = Color.Gainsboro;
            fieldNombreProducto.BorderRadius = 16;
            fieldNombreProducto.Cursor = Cursors.IBeam;
            fieldNombreProducto.CustomizableEdges = customizableEdges5;
            fieldNombreProducto.DefaultText = "";
            fieldNombreProducto.DisabledState.BorderColor = Color.Gainsboro;
            fieldNombreProducto.DisabledState.FillColor = Color.White;
            fieldNombreProducto.DisabledState.ForeColor = Color.DimGray;
            fieldNombreProducto.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldNombreProducto.Dock = DockStyle.Fill;
            fieldNombreProducto.FocusedState.BorderColor = Color.SandyBrown;
            fieldNombreProducto.Font = new Font("Segoe UI", 11.25F);
            fieldNombreProducto.ForeColor = Color.Black;
            fieldNombreProducto.HoverState.BorderColor = Color.SandyBrown;
            fieldNombreProducto.IconLeft = (Image) resources.GetObject("fieldNombreProducto.IconLeft");
            fieldNombreProducto.IconLeftOffset = new Point(10, 0);
            fieldNombreProducto.Location = new Point(5, 5);
            fieldNombreProducto.Margin = new Padding(5);
            fieldNombreProducto.Name = "fieldNombreProducto";
            fieldNombreProducto.PasswordChar = '\0';
            fieldNombreProducto.PlaceholderForeColor = Color.DimGray;
            fieldNombreProducto.PlaceholderText = "Nombre";
            fieldNombreProducto.SelectedText = "";
            fieldNombreProducto.ShadowDecoration.CustomizableEdges = customizableEdges6;
            fieldNombreProducto.Size = new Size(262, 35);
            fieldNombreProducto.TabIndex = 0;
            fieldNombreProducto.TextOffset = new Point(5, 0);
            // 
            // fieldTituloCategoriaProducto
            // 
            fieldTituloCategoriaProducto.Dock = DockStyle.Fill;
            fieldTituloCategoriaProducto.Font = new Font("Segoe UI", 11.25F);
            fieldTituloCategoriaProducto.ForeColor = Color.DimGray;
            fieldTituloCategoriaProducto.Image = (Image) resources.GetObject("fieldTituloCategoriaProducto.Image");
            fieldTituloCategoriaProducto.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloCategoriaProducto.ImeMode = ImeMode.NoControl;
            fieldTituloCategoriaProducto.Location = new Point(15, 5);
            fieldTituloCategoriaProducto.Margin = new Padding(15, 5, 3, 3);
            fieldTituloCategoriaProducto.Name = "fieldTituloCategoriaProducto";
            fieldTituloCategoriaProducto.Size = new Size(399, 27);
            fieldTituloCategoriaProducto.TabIndex = 5;
            fieldTituloCategoriaProducto.Text = "      Materia prima directa :";
            fieldTituloCategoriaProducto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contenedorVistas
            // 
            contenedorVistas.Dock = DockStyle.Fill;
            contenedorVistas.Location = new Point(0, 197);
            contenedorVistas.Margin = new Padding(0);
            contenedorVistas.Name = "contenedorVistas";
            contenedorVistas.Size = new Size(417, 208);
            contenedorVistas.TabIndex = 11;
            // 
            // separador1
            // 
            separador1.Dock = DockStyle.Fill;
            separador1.FillColor = Color.FromArgb(  208,   197,   188);
            separador1.Location = new Point(3, 408);
            separador1.Name = "separador1";
            separador1.Size = new Size(411, 14);
            separador1.TabIndex = 23;
            // 
            // layoutEncabezadosTabla
            // 
            layoutEncabezadosTabla.BackColor = Color.WhiteSmoke;
            layoutEncabezadosTabla.ColumnCount = 5;
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutEncabezadosTabla.Controls.Add(fieldTituloCantidad, 2, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloPrecio, 1, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloMateriaPrima, 0, 0);
            layoutEncabezadosTabla.Dock = DockStyle.Fill;
            layoutEncabezadosTabla.Location = new Point(1, 153);
            layoutEncabezadosTabla.Margin = new Padding(1);
            layoutEncabezadosTabla.Name = "layoutEncabezadosTabla";
            layoutEncabezadosTabla.RowCount = 1;
            layoutEncabezadosTabla.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.Size = new Size(415, 43);
            layoutEncabezadosTabla.TabIndex = 22;
            // 
            // fieldTituloCantidad
            // 
            fieldTituloCantidad.Dock = DockStyle.Fill;
            fieldTituloCantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldTituloCantidad.ForeColor = Color.Black;
            fieldTituloCantidad.ImeMode = ImeMode.NoControl;
            fieldTituloCantidad.Location = new Point(306, 1);
            fieldTituloCantidad.Margin = new Padding(1);
            fieldTituloCantidad.Name = "fieldTituloCantidad";
            fieldTituloCantidad.Size = new Size(48, 41);
            fieldTituloCantidad.TabIndex = 2;
            fieldTituloCantidad.Text = "C";
            fieldTituloCantidad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloPrecio
            // 
            fieldTituloPrecio.Dock = DockStyle.Fill;
            fieldTituloPrecio.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldTituloPrecio.ForeColor = Color.Black;
            fieldTituloPrecio.ImeMode = ImeMode.NoControl;
            fieldTituloPrecio.Location = new Point(176, 1);
            fieldTituloPrecio.Margin = new Padding(1);
            fieldTituloPrecio.Name = "fieldTituloPrecio";
            fieldTituloPrecio.Size = new Size(128, 41);
            fieldTituloPrecio.TabIndex = 1;
            fieldTituloPrecio.Text = "Costo";
            fieldTituloPrecio.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloMateriaPrima
            // 
            fieldTituloMateriaPrima.Dock = DockStyle.Fill;
            fieldTituloMateriaPrima.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldTituloMateriaPrima.ForeColor = Color.Black;
            fieldTituloMateriaPrima.ImeMode = ImeMode.NoControl;
            fieldTituloMateriaPrima.Location = new Point(1, 1);
            fieldTituloMateriaPrima.Margin = new Padding(1);
            fieldTituloMateriaPrima.Name = "fieldTituloMateriaPrima";
            fieldTituloMateriaPrima.Size = new Size(173, 41);
            fieldTituloMateriaPrima.TabIndex = 0;
            fieldTituloMateriaPrima.Text = "Materia prima";
            fieldTituloMateriaPrima.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VistaRegistroMateriaPrima
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(417, 470);
            Controls.Add(layoutBase);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VistaRegistroMateriaPrima";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroProductoDatosGenerales";
            layoutBase.ResumeLayout(false);
            layoutSubtotal.ResumeLayout(false);
            layoutGestionMateriaPrima.ResumeLayout(false);
            layoutEncabezadosTabla.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private Label fieldTituloCategoriaProducto;
        private Panel contenedorVistas;
        private TableLayoutPanel layoutGestionMateriaPrima;
        private Guna.UI2.WinForms.Guna2Button btnAdicionarMateriaPrima;
        private Guna.UI2.WinForms.Guna2TextBox fieldCantidad;
        private Guna.UI2.WinForms.Guna2TextBox fieldNombreProducto;
        private Label fieldDescripcionMateriaPrima;
        private TableLayoutPanel layoutEncabezadosTabla;
        private Label fieldTituloCantidad;
        private Label fieldTituloPrecio;
        private Label fieldTituloMateriaPrima;
        private Guna.UI2.WinForms.Guna2Separator separador1;
        private TableLayoutPanel layoutSubtotal;
        private Label symbolPeso;
        private Label fieldCostoTotalMateriales;
        private Label fieldTituloCostoTotalMateriales;
    }
}