namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto {
    partial class VistaRegistroProductoP4 {
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaRegistroProductoP4));
            formatoBase = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutGestionProductos = new TableLayoutPanel();
            btnAdicionarActividad = new Guna.UI2.WinForms.Guna2Button();
            fieldCantidad = new Guna.UI2.WinForms.Guna2TextBox();
            fieldNombreActividad = new Guna.UI2.WinForms.Guna2TextBox();
            separador1 = new Guna.UI2.WinForms.Guna2Separator();
            fieldTituloManoObraProducto = new Label();
            layoutEncabezadosTabla = new TableLayoutPanel();
            fieldTituloCantidad = new Label();
            fieldTituloPrecio = new Label();
            fieldTituloActividad = new Label();
            contenedorVistas = new Panel();
            layoutMontoConsumo = new TableLayoutPanel();
            symbolPeso = new Label();
            fieldTotalManoObra = new Label();
            fieldTituloTotalCompra = new Label();
            layoutBase.SuspendLayout();
            layoutGestionProductos.SuspendLayout();
            layoutEncabezadosTabla.SuspendLayout();
            layoutMontoConsumo.SuspendLayout();
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
            layoutBase.Controls.Add(layoutGestionProductos, 0, 1);
            layoutBase.Controls.Add(separador1, 0, 5);
            layoutBase.Controls.Add(fieldTituloManoObraProducto, 0, 0);
            layoutBase.Controls.Add(layoutEncabezadosTabla, 0, 3);
            layoutBase.Controls.Add(contenedorVistas, 0, 4);
            layoutBase.Controls.Add(layoutMontoConsumo, 0, 6);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 7;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.Size = new Size(417, 470);
            layoutBase.TabIndex = 1;
            // 
            // layoutGestionProductos
            // 
            layoutGestionProductos.ColumnCount = 3;
            layoutGestionProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutGestionProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            layoutGestionProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutGestionProductos.Controls.Add(btnAdicionarActividad, 2, 0);
            layoutGestionProductos.Controls.Add(fieldCantidad, 1, 0);
            layoutGestionProductos.Controls.Add(fieldNombreActividad, 0, 0);
            layoutGestionProductos.Dock = DockStyle.Fill;
            layoutGestionProductos.Location = new Point(0, 35);
            layoutGestionProductos.Margin = new Padding(0);
            layoutGestionProductos.Name = "layoutGestionProductos";
            layoutGestionProductos.RowCount = 1;
            layoutGestionProductos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutGestionProductos.Size = new Size(417, 45);
            layoutGestionProductos.TabIndex = 19;
            // 
            // btnAdicionarActividad
            // 
            btnAdicionarActividad.Animated = true;
            btnAdicionarActividad.BorderRadius = 18;
            btnAdicionarActividad.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnAdicionarActividad.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnAdicionarActividad.CustomizableEdges = customizableEdges13;
            btnAdicionarActividad.DialogResult = DialogResult.Cancel;
            btnAdicionarActividad.Dock = DockStyle.Fill;
            btnAdicionarActividad.Enabled = false;
            btnAdicionarActividad.FillColor = Color.PeachPuff;
            btnAdicionarActividad.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnAdicionarActividad.ForeColor = Color.White;
            btnAdicionarActividad.Location = new Point(372, 5);
            btnAdicionarActividad.Margin = new Padding(5);
            btnAdicionarActividad.Name = "btnAdicionarActividad";
            btnAdicionarActividad.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnAdicionarActividad.Size = new Size(40, 35);
            btnAdicionarActividad.TabIndex = 2;
            // 
            // fieldCantidad
            // 
            fieldCantidad.Animated = true;
            fieldCantidad.BorderColor = Color.Gainsboro;
            fieldCantidad.BorderRadius = 16;
            fieldCantidad.Cursor = Cursors.IBeam;
            fieldCantidad.CustomizableEdges = customizableEdges15;
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
            fieldCantidad.ShadowDecoration.CustomizableEdges = customizableEdges16;
            fieldCantidad.Size = new Size(85, 35);
            fieldCantidad.TabIndex = 1;
            fieldCantidad.TextAlign = HorizontalAlignment.Right;
            fieldCantidad.TextOffset = new Point(5, 0);
            // 
            // fieldNombreActividad
            // 
            fieldNombreActividad.Animated = true;
            fieldNombreActividad.BorderColor = Color.Gainsboro;
            fieldNombreActividad.BorderRadius = 16;
            fieldNombreActividad.Cursor = Cursors.IBeam;
            fieldNombreActividad.CustomizableEdges = customizableEdges17;
            fieldNombreActividad.DefaultText = "";
            fieldNombreActividad.DisabledState.BorderColor = Color.Gainsboro;
            fieldNombreActividad.DisabledState.FillColor = Color.White;
            fieldNombreActividad.DisabledState.ForeColor = Color.DimGray;
            fieldNombreActividad.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldNombreActividad.Dock = DockStyle.Fill;
            fieldNombreActividad.FocusedState.BorderColor = Color.SandyBrown;
            fieldNombreActividad.Font = new Font("Segoe UI", 11.25F);
            fieldNombreActividad.ForeColor = Color.Black;
            fieldNombreActividad.HoverState.BorderColor = Color.SandyBrown;
            fieldNombreActividad.IconLeft = (Image) resources.GetObject("fieldNombreActividad.IconLeft");
            fieldNombreActividad.IconLeftOffset = new Point(10, 0);
            fieldNombreActividad.Location = new Point(5, 5);
            fieldNombreActividad.Margin = new Padding(5);
            fieldNombreActividad.Name = "fieldNombreActividad";
            fieldNombreActividad.PasswordChar = '\0';
            fieldNombreActividad.PlaceholderForeColor = Color.DimGray;
            fieldNombreActividad.PlaceholderText = "Nombre de la actividad";
            fieldNombreActividad.SelectedText = "";
            fieldNombreActividad.ShadowDecoration.CustomizableEdges = customizableEdges18;
            fieldNombreActividad.Size = new Size(262, 35);
            fieldNombreActividad.TabIndex = 0;
            fieldNombreActividad.TextOffset = new Point(5, 0);
            // 
            // separador1
            // 
            separador1.Dock = DockStyle.Fill;
            separador1.FillColor = Color.FromArgb(  208,   197,   188);
            separador1.Location = new Point(3, 408);
            separador1.Name = "separador1";
            separador1.Size = new Size(411, 14);
            separador1.TabIndex = 9;
            // 
            // fieldTituloManoObraProducto
            // 
            fieldTituloManoObraProducto.Dock = DockStyle.Fill;
            fieldTituloManoObraProducto.Font = new Font("Segoe UI", 11.25F);
            fieldTituloManoObraProducto.ForeColor = Color.DimGray;
            fieldTituloManoObraProducto.Image = (Image) resources.GetObject("fieldTituloManoObraProducto.Image");
            fieldTituloManoObraProducto.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloManoObraProducto.ImeMode = ImeMode.NoControl;
            fieldTituloManoObraProducto.Location = new Point(15, 5);
            fieldTituloManoObraProducto.Margin = new Padding(15, 5, 3, 3);
            fieldTituloManoObraProducto.Name = "fieldTituloManoObraProducto";
            fieldTituloManoObraProducto.Size = new Size(399, 27);
            fieldTituloManoObraProducto.TabIndex = 5;
            fieldTituloManoObraProducto.Text = "      Mano de obra empleada por actividad :";
            fieldTituloManoObraProducto.TextAlign = ContentAlignment.MiddleLeft;
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
            layoutEncabezadosTabla.Controls.Add(fieldTituloActividad, 0, 0);
            layoutEncabezadosTabla.Dock = DockStyle.Fill;
            layoutEncabezadosTabla.Location = new Point(1, 91);
            layoutEncabezadosTabla.Margin = new Padding(1);
            layoutEncabezadosTabla.Name = "layoutEncabezadosTabla";
            layoutEncabezadosTabla.RowCount = 1;
            layoutEncabezadosTabla.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.Size = new Size(415, 43);
            layoutEncabezadosTabla.TabIndex = 20;
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
            fieldTituloPrecio.Text = "Precio";
            fieldTituloPrecio.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloActividad
            // 
            fieldTituloActividad.Dock = DockStyle.Fill;
            fieldTituloActividad.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldTituloActividad.ForeColor = Color.Black;
            fieldTituloActividad.ImeMode = ImeMode.NoControl;
            fieldTituloActividad.Location = new Point(1, 1);
            fieldTituloActividad.Margin = new Padding(1);
            fieldTituloActividad.Name = "fieldTituloActividad";
            fieldTituloActividad.Size = new Size(173, 41);
            fieldTituloActividad.TabIndex = 0;
            fieldTituloActividad.Text = "Actividad";
            fieldTituloActividad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contenedorVistas
            // 
            contenedorVistas.AutoScroll = true;
            contenedorVistas.Dock = DockStyle.Fill;
            contenedorVistas.Location = new Point(0, 135);
            contenedorVistas.Margin = new Padding(0);
            contenedorVistas.Name = "contenedorVistas";
            contenedorVistas.Size = new Size(417, 270);
            contenedorVistas.TabIndex = 21;
            // 
            // layoutMontoConsumo
            // 
            layoutMontoConsumo.ColumnCount = 3;
            layoutMontoConsumo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutMontoConsumo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutMontoConsumo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutMontoConsumo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutMontoConsumo.Controls.Add(symbolPeso, 0, 0);
            layoutMontoConsumo.Controls.Add(fieldTotalManoObra, 0, 0);
            layoutMontoConsumo.Controls.Add(fieldTituloTotalCompra, 0, 0);
            layoutMontoConsumo.Dock = DockStyle.Fill;
            layoutMontoConsumo.Location = new Point(0, 425);
            layoutMontoConsumo.Margin = new Padding(0);
            layoutMontoConsumo.Name = "layoutMontoConsumo";
            layoutMontoConsumo.RowCount = 1;
            layoutMontoConsumo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutMontoConsumo.Size = new Size(417, 45);
            layoutMontoConsumo.TabIndex = 22;
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
            // fieldTotalManoObra
            // 
            fieldTotalManoObra.Dock = DockStyle.Fill;
            fieldTotalManoObra.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldTotalManoObra.ForeColor = Color.Black;
            fieldTotalManoObra.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTotalManoObra.ImeMode = ImeMode.NoControl;
            fieldTotalManoObra.Location = new Point(302, 5);
            fieldTotalManoObra.Margin = new Padding(15, 5, 3, 3);
            fieldTotalManoObra.Name = "fieldTotalManoObra";
            fieldTotalManoObra.Size = new Size(92, 37);
            fieldTotalManoObra.TabIndex = 1;
            fieldTotalManoObra.Text = "0.00";
            fieldTotalManoObra.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldTituloTotalCompra
            // 
            fieldTituloTotalCompra.Dock = DockStyle.Fill;
            fieldTituloTotalCompra.Font = new Font("Segoe UI", 11.25F);
            fieldTituloTotalCompra.ForeColor = Color.DimGray;
            fieldTituloTotalCompra.Image = (Image) resources.GetObject("fieldTituloTotalCompra.Image");
            fieldTituloTotalCompra.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloTotalCompra.ImeMode = ImeMode.NoControl;
            fieldTituloTotalCompra.Location = new Point(15, 5);
            fieldTituloTotalCompra.Margin = new Padding(15, 5, 3, 3);
            fieldTituloTotalCompra.Name = "fieldTituloTotalCompra";
            fieldTituloTotalCompra.Size = new Size(269, 37);
            fieldTituloTotalCompra.TabIndex = 0;
            fieldTituloTotalCompra.Text = "      Monto total en mano de obra";
            fieldTituloTotalCompra.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VistaRegistroProductoP4
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(417, 470);
            Controls.Add(layoutBase);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VistaRegistroProductoP4";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroProductoP4";
            layoutBase.ResumeLayout(false);
            layoutGestionProductos.ResumeLayout(false);
            layoutEncabezadosTabla.ResumeLayout(false);
            layoutMontoConsumo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutGestionProductos;
        private Guna.UI2.WinForms.Guna2Button btnAdicionarActividad;
        private Guna.UI2.WinForms.Guna2TextBox fieldCantidad;
        private Guna.UI2.WinForms.Guna2TextBox fieldNombreActividad;
        private Guna.UI2.WinForms.Guna2Separator separador1;
        private Label fieldTituloManoObraProducto;
        private TableLayoutPanel layoutEncabezadosTabla;
        private Label fieldTituloCantidad;
        private Label fieldTituloPrecio;
        private Label fieldTituloActividad;
        private Panel contenedorVistas;
        private TableLayoutPanel layoutMontoConsumo;
        private Label symbolPeso;
        private Label fieldTotalManoObra;
        private Label fieldTituloTotalCompra;
    }
}