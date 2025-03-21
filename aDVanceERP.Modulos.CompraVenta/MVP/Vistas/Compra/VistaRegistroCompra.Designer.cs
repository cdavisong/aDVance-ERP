using Guna.UI2.WinForms;

using System.ComponentModel;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra {
    partial class VistaRegistroCompra {
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaRegistroCompra));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutBotones = new TableLayoutPanel();
            btnSalir = new Guna2Button();
            btnRegistrar = new Guna2Button();
            layoutVista = new TableLayoutPanel();
            fieldTituloGestionArticulos = new Label();
            fieldIcono = new PictureBox();
            fieldSubtitulo = new Label();
            layoutTitulo = new TableLayoutPanel();
            btnCerrar = new Guna2Button();
            fieldTitulo = new Label();
            layoutGestionProductos = new TableLayoutPanel();
            fieldNombreArticulo = new Guna2TextBox();
            btnAdicionarArticulo = new Guna2Button();
            fieldCantidadArticulos = new Guna2TextBox();
            layoutMontoCompra = new TableLayoutPanel();
            symbolPeso = new Label();
            fieldTotalCompra = new Label();
            fieldTituloTotalCompra = new Label();
            separador1 = new Guna2Separator();
            layoutTituloClienteAlmacen = new TableLayoutPanel();
            fieldTituloNombreProveedor = new Label();
            fieldTituloNombreAlmacen = new Label();
            layoutClienteAlmacen = new TableLayoutPanel();
            fieldNombreProveedor = new Guna2ComboBox();
            fieldNombreAlmacen = new Guna2ComboBox();
            separador2 = new Guna2Separator();
            guna2Separator1 = new Guna2Separator();
            layoutPrecioUnitario = new TableLayoutPanel();
            symbolPeso1 = new Label();
            fieldPrecioUnitario = new Label();
            fieldTituloPrecioUnitario = new Label();
            layoutCantidad = new TableLayoutPanel();
            symbolUnidad1 = new Label();
            fieldCantidad = new Label();
            fieldTituloCantidad = new Label();
            layoutBase.SuspendLayout();
            layoutBotones.SuspendLayout();
            layoutVista.SuspendLayout();
            ((ISupportInitialize) fieldIcono).BeginInit();
            layoutTitulo.SuspendLayout();
            layoutGestionProductos.SuspendLayout();
            layoutMontoCompra.SuspendLayout();
            layoutTituloClienteAlmacen.SuspendLayout();
            layoutClienteAlmacen.SuspendLayout();
            layoutPrecioUnitario.SuspendLayout();
            layoutCantidad.SuspendLayout();
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
            layoutBase.Controls.Add(layoutBotones, 1, 1);
            layoutBase.Controls.Add(layoutVista, 1, 0);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 2;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            layoutBase.Size = new Size(500, 685);
            layoutBase.TabIndex = 0;
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
            layoutBotones.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.Animated = true;
            btnSalir.BorderColor = Color.Gainsboro;
            btnSalir.BorderRadius = 18;
            btnSalir.BorderThickness = 1;
            btnSalir.CustomizableEdges = customizableEdges1;
            btnSalir.Dock = DockStyle.Fill;
            btnSalir.FillColor = Color.White;
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.Gainsboro;
            btnSalir.HoverState.BorderColor = Color.PeachPuff;
            btnSalir.HoverState.FillColor = Color.PeachPuff;
            btnSalir.HoverState.ForeColor = Color.Black;
            btnSalir.Location = new Point(302, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSalir.Size = new Size(160, 39);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Animated = true;
            btnRegistrar.BorderRadius = 18;
            btnRegistrar.CustomizableEdges = customizableEdges3;
            btnRegistrar.Dock = DockStyle.Fill;
            btnRegistrar.Enabled = false;
            btnRegistrar.FillColor = Color.PeachPuff;
            btnRegistrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrar.ForeColor = Color.Black;
            btnRegistrar.Location = new Point(53, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnRegistrar.Size = new Size(243, 39);
            btnRegistrar.TabIndex = 0;
            btnRegistrar.Text = "Registrar compra";
            // 
            // layoutVista
            // 
            layoutVista.BackColor = Color.White;
            layoutVista.ColumnCount = 4;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.Controls.Add(fieldTituloGestionArticulos, 2, 7);
            layoutVista.Controls.Add(fieldIcono, 1, 1);
            layoutVista.Controls.Add(fieldSubtitulo, 2, 2);
            layoutVista.Controls.Add(layoutTitulo, 2, 1);
            layoutVista.Controls.Add(layoutGestionProductos, 2, 8);
            layoutVista.Controls.Add(layoutMontoCompra, 2, 14);
            layoutVista.Controls.Add(separador1, 2, 6);
            layoutVista.Controls.Add(layoutTituloClienteAlmacen, 2, 4);
            layoutVista.Controls.Add(layoutClienteAlmacen, 2, 5);
            layoutVista.Controls.Add(separador2, 2, 9);
            layoutVista.Controls.Add(guna2Separator1, 2, 13);
            layoutVista.Controls.Add(layoutPrecioUnitario, 2, 10);
            layoutVista.Controls.Add(layoutCantidad, 2, 11);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(13, 0);
            layoutVista.Margin = new Padding(3, 0, 0, 0);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 15;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.Size = new Size(487, 620);
            layoutVista.TabIndex = 3;
            // 
            // fieldTituloGestionArticulos
            // 
            fieldTituloGestionArticulos.Dock = DockStyle.Fill;
            fieldTituloGestionArticulos.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloGestionArticulos.ForeColor = Color.DimGray;
            fieldTituloGestionArticulos.Image = (Image) resources.GetObject("fieldTituloGestionArticulos.Image");
            fieldTituloGestionArticulos.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloGestionArticulos.ImeMode = ImeMode.NoControl;
            fieldTituloGestionArticulos.Location = new Point(65, 235);
            fieldTituloGestionArticulos.Margin = new Padding(15, 5, 3, 3);
            fieldTituloGestionArticulos.Name = "fieldTituloGestionArticulos";
            fieldTituloGestionArticulos.Size = new Size(399, 27);
            fieldTituloGestionArticulos.TabIndex = 4;
            fieldTituloGestionArticulos.Text = "      Gestión para la compra de artículos";
            fieldTituloGestionArticulos.TextAlign = ContentAlignment.MiddleLeft;
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
            fieldSubtitulo.ForeColor = Color.DimGray;
            fieldSubtitulo.ImeMode = ImeMode.NoControl;
            fieldSubtitulo.Location = new Point(55, 70);
            fieldSubtitulo.Margin = new Padding(5, 5, 1, 1);
            fieldSubtitulo.Name = "fieldSubtitulo";
            fieldSubtitulo.Size = new Size(411, 39);
            fieldSubtitulo.TabIndex = 0;
            fieldSubtitulo.Text = "Registro";
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
            btnCerrar.CustomizableEdges = customizableEdges5;
            btnCerrar.Dock = DockStyle.Fill;
            btnCerrar.FillColor = Color.White;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.Black;
            btnCerrar.HoverState.FillColor = Color.White;
            btnCerrar.Image = (Image) resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(370, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.ShadowDecoration.CustomizableEdges = customizableEdges6;
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
            fieldTitulo.Text = "Compra";
            fieldTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutGestionProductos
            // 
            layoutGestionProductos.ColumnCount = 3;
            layoutGestionProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutGestionProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutGestionProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            layoutGestionProductos.Controls.Add(fieldNombreArticulo, 0, 0);
            layoutGestionProductos.Controls.Add(btnAdicionarArticulo, 1, 0);
            layoutGestionProductos.Controls.Add(fieldCantidadArticulos, 2, 0);
            layoutGestionProductos.Dock = DockStyle.Fill;
            layoutGestionProductos.Location = new Point(50, 265);
            layoutGestionProductos.Margin = new Padding(0);
            layoutGestionProductos.Name = "layoutGestionProductos";
            layoutGestionProductos.RowCount = 1;
            layoutGestionProductos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutGestionProductos.Size = new Size(417, 45);
            layoutGestionProductos.TabIndex = 5;
            // 
            // fieldNombreArticulo
            // 
            fieldNombreArticulo.Animated = true;
            fieldNombreArticulo.BorderColor = Color.Gainsboro;
            fieldNombreArticulo.BorderRadius = 16;
            fieldNombreArticulo.Cursor = Cursors.IBeam;
            fieldNombreArticulo.CustomizableEdges = customizableEdges7;
            fieldNombreArticulo.DefaultText = "";
            fieldNombreArticulo.DisabledState.BorderColor = Color.White;
            fieldNombreArticulo.DisabledState.ForeColor = Color.DimGray;
            fieldNombreArticulo.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldNombreArticulo.Dock = DockStyle.Fill;
            fieldNombreArticulo.FocusedState.BorderColor = Color.SandyBrown;
            fieldNombreArticulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreArticulo.ForeColor = Color.Black;
            fieldNombreArticulo.HoverState.BorderColor = Color.SandyBrown;
            fieldNombreArticulo.IconLeft = (Image) resources.GetObject("fieldNombreArticulo.IconLeft");
            fieldNombreArticulo.IconLeftOffset = new Point(10, 0);
            fieldNombreArticulo.IconRightCursor = Cursors.Cross;
            fieldNombreArticulo.IconRightOffset = new Point(6, 0);
            fieldNombreArticulo.IconRightSize = new Size(12, 12);
            fieldNombreArticulo.Location = new Point(5, 5);
            fieldNombreArticulo.Margin = new Padding(5);
            fieldNombreArticulo.Name = "fieldNombreArticulo";
            fieldNombreArticulo.PasswordChar = '\0';
            fieldNombreArticulo.PlaceholderForeColor = Color.DimGray;
            fieldNombreArticulo.PlaceholderText = "Nombre del artículo";
            fieldNombreArticulo.SelectedText = "";
            fieldNombreArticulo.ShadowDecoration.CustomizableEdges = customizableEdges8;
            fieldNombreArticulo.Size = new Size(262, 35);
            fieldNombreArticulo.TabIndex = 0;
            fieldNombreArticulo.TextOffset = new Point(5, 0);
            // 
            // btnAdicionarArticulo
            // 
            btnAdicionarArticulo.Animated = true;
            btnAdicionarArticulo.BorderRadius = 18;
            btnAdicionarArticulo.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnAdicionarArticulo.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnAdicionarArticulo.CustomizableEdges = customizableEdges9;
            btnAdicionarArticulo.DialogResult = DialogResult.Cancel;
            btnAdicionarArticulo.Dock = DockStyle.Fill;
            btnAdicionarArticulo.FillColor = Color.PeachPuff;
            btnAdicionarArticulo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdicionarArticulo.ForeColor = Color.White;
            btnAdicionarArticulo.Location = new Point(277, 5);
            btnAdicionarArticulo.Margin = new Padding(5);
            btnAdicionarArticulo.Name = "btnAdicionarArticulo";
            btnAdicionarArticulo.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnAdicionarArticulo.Size = new Size(40, 35);
            btnAdicionarArticulo.TabIndex = 1;
            // 
            // fieldCantidadArticulos
            // 
            fieldCantidadArticulos.Animated = true;
            fieldCantidadArticulos.BorderColor = Color.Gainsboro;
            fieldCantidadArticulos.BorderRadius = 16;
            fieldCantidadArticulos.Cursor = Cursors.IBeam;
            fieldCantidadArticulos.CustomizableEdges = customizableEdges11;
            fieldCantidadArticulos.DefaultText = "";
            fieldCantidadArticulos.DisabledState.BorderColor = Color.Gainsboro;
            fieldCantidadArticulos.DisabledState.FillColor = Color.White;
            fieldCantidadArticulos.DisabledState.ForeColor = Color.DimGray;
            fieldCantidadArticulos.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldCantidadArticulos.Dock = DockStyle.Fill;
            fieldCantidadArticulos.FocusedState.BorderColor = Color.SandyBrown;
            fieldCantidadArticulos.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldCantidadArticulos.ForeColor = Color.Black;
            fieldCantidadArticulos.HoverState.BorderColor = Color.SandyBrown;
            fieldCantidadArticulos.IconLeftOffset = new Point(10, 0);
            fieldCantidadArticulos.IconRight = (Image) resources.GetObject("fieldCantidadArticulos.IconRight");
            fieldCantidadArticulos.IconRightOffset = new Point(6, 0);
            fieldCantidadArticulos.IconRightSize = new Size(12, 12);
            fieldCantidadArticulos.Location = new Point(327, 5);
            fieldCantidadArticulos.Margin = new Padding(5);
            fieldCantidadArticulos.Name = "fieldCantidadArticulos";
            fieldCantidadArticulos.PasswordChar = '\0';
            fieldCantidadArticulos.PlaceholderForeColor = Color.DimGray;
            fieldCantidadArticulos.PlaceholderText = "Cant.";
            fieldCantidadArticulos.SelectedText = "";
            fieldCantidadArticulos.ShadowDecoration.CustomizableEdges = customizableEdges12;
            fieldCantidadArticulos.Size = new Size(85, 35);
            fieldCantidadArticulos.TabIndex = 2;
            fieldCantidadArticulos.TextAlign = HorizontalAlignment.Right;
            fieldCantidadArticulos.TextOffset = new Point(5, 0);
            // 
            // layoutMontoCompra
            // 
            layoutMontoCompra.ColumnCount = 3;
            layoutMontoCompra.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutMontoCompra.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutMontoCompra.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutMontoCompra.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutMontoCompra.Controls.Add(symbolPeso, 0, 0);
            layoutMontoCompra.Controls.Add(fieldTotalCompra, 0, 0);
            layoutMontoCompra.Controls.Add(fieldTituloTotalCompra, 0, 0);
            layoutMontoCompra.Dock = DockStyle.Fill;
            layoutMontoCompra.Location = new Point(50, 575);
            layoutMontoCompra.Margin = new Padding(0);
            layoutMontoCompra.Name = "layoutMontoCompra";
            layoutMontoCompra.RowCount = 1;
            layoutMontoCompra.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutMontoCompra.Size = new Size(417, 45);
            layoutMontoCompra.TabIndex = 7;
            // 
            // symbolPeso
            // 
            symbolPeso.Dock = DockStyle.Fill;
            symbolPeso.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
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
            // fieldTotalCompra
            // 
            fieldTotalCompra.Dock = DockStyle.Fill;
            fieldTotalCompra.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTotalCompra.ForeColor = Color.Black;
            fieldTotalCompra.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTotalCompra.ImeMode = ImeMode.NoControl;
            fieldTotalCompra.Location = new Point(302, 5);
            fieldTotalCompra.Margin = new Padding(15, 5, 3, 3);
            fieldTotalCompra.Name = "fieldTotalCompra";
            fieldTotalCompra.Size = new Size(92, 37);
            fieldTotalCompra.TabIndex = 1;
            fieldTotalCompra.Text = "0.00";
            fieldTotalCompra.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldTituloTotalCompra
            // 
            fieldTituloTotalCompra.Dock = DockStyle.Fill;
            fieldTituloTotalCompra.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloTotalCompra.ForeColor = Color.DimGray;
            fieldTituloTotalCompra.Image = (Image) resources.GetObject("fieldTituloTotalCompra.Image");
            fieldTituloTotalCompra.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloTotalCompra.ImeMode = ImeMode.NoControl;
            fieldTituloTotalCompra.Location = new Point(15, 5);
            fieldTituloTotalCompra.Margin = new Padding(15, 5, 3, 3);
            fieldTituloTotalCompra.Name = "fieldTituloTotalCompra";
            fieldTituloTotalCompra.Size = new Size(269, 37);
            fieldTituloTotalCompra.TabIndex = 0;
            fieldTituloTotalCompra.Text = "      Monto total de la compra";
            fieldTituloTotalCompra.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // separador1
            // 
            separador1.Dock = DockStyle.Fill;
            separador1.FillColor = Color.FromArgb(  208,   197,   188);
            separador1.Location = new Point(53, 213);
            separador1.Name = "separador1";
            separador1.Size = new Size(411, 14);
            separador1.TabIndex = 3;
            // 
            // layoutTituloClienteAlmacen
            // 
            layoutTituloClienteAlmacen.ColumnCount = 2;
            layoutTituloClienteAlmacen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutTituloClienteAlmacen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutTituloClienteAlmacen.Controls.Add(fieldTituloNombreProveedor, 0, 0);
            layoutTituloClienteAlmacen.Controls.Add(fieldTituloNombreAlmacen, 1, 0);
            layoutTituloClienteAlmacen.Location = new Point(50, 130);
            layoutTituloClienteAlmacen.Margin = new Padding(0);
            layoutTituloClienteAlmacen.Name = "layoutTituloClienteAlmacen";
            layoutTituloClienteAlmacen.RowCount = 1;
            layoutTituloClienteAlmacen.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutTituloClienteAlmacen.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutTituloClienteAlmacen.Size = new Size(417, 35);
            layoutTituloClienteAlmacen.TabIndex = 1;
            // 
            // fieldTituloNombreProveedor
            // 
            fieldTituloNombreProveedor.Dock = DockStyle.Fill;
            fieldTituloNombreProveedor.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloNombreProveedor.ForeColor = Color.DimGray;
            fieldTituloNombreProveedor.Image = (Image) resources.GetObject("fieldTituloNombreProveedor.Image");
            fieldTituloNombreProveedor.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloNombreProveedor.ImeMode = ImeMode.NoControl;
            fieldTituloNombreProveedor.Location = new Point(15, 5);
            fieldTituloNombreProveedor.Margin = new Padding(15, 5, 3, 3);
            fieldTituloNombreProveedor.Name = "fieldTituloNombreProveedor";
            fieldTituloNombreProveedor.Size = new Size(190, 27);
            fieldTituloNombreProveedor.TabIndex = 0;
            fieldTituloNombreProveedor.Text = "      Proveedor :";
            fieldTituloNombreProveedor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldTituloNombreAlmacen
            // 
            fieldTituloNombreAlmacen.Dock = DockStyle.Fill;
            fieldTituloNombreAlmacen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloNombreAlmacen.ForeColor = Color.DimGray;
            fieldTituloNombreAlmacen.Image = (Image) resources.GetObject("fieldTituloNombreAlmacen.Image");
            fieldTituloNombreAlmacen.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloNombreAlmacen.ImeMode = ImeMode.NoControl;
            fieldTituloNombreAlmacen.Location = new Point(223, 5);
            fieldTituloNombreAlmacen.Margin = new Padding(15, 5, 3, 3);
            fieldTituloNombreAlmacen.Name = "fieldTituloNombreAlmacen";
            fieldTituloNombreAlmacen.Size = new Size(191, 27);
            fieldTituloNombreAlmacen.TabIndex = 1;
            fieldTituloNombreAlmacen.Text = "      Almacén :";
            fieldTituloNombreAlmacen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutClienteAlmacen
            // 
            layoutClienteAlmacen.ColumnCount = 2;
            layoutClienteAlmacen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutClienteAlmacen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutClienteAlmacen.Controls.Add(fieldNombreProveedor, 0, 0);
            layoutClienteAlmacen.Controls.Add(fieldNombreAlmacen, 1, 0);
            layoutClienteAlmacen.Dock = DockStyle.Fill;
            layoutClienteAlmacen.Location = new Point(50, 165);
            layoutClienteAlmacen.Margin = new Padding(0);
            layoutClienteAlmacen.Name = "layoutClienteAlmacen";
            layoutClienteAlmacen.RowCount = 1;
            layoutClienteAlmacen.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutClienteAlmacen.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutClienteAlmacen.Size = new Size(417, 45);
            layoutClienteAlmacen.TabIndex = 2;
            // 
            // fieldNombreProveedor
            // 
            fieldNombreProveedor.Animated = true;
            fieldNombreProveedor.BackColor = Color.Transparent;
            fieldNombreProveedor.BorderColor = Color.Gainsboro;
            fieldNombreProveedor.BorderRadius = 16;
            fieldNombreProveedor.CustomizableEdges = customizableEdges13;
            fieldNombreProveedor.Dock = DockStyle.Fill;
            fieldNombreProveedor.DrawMode = DrawMode.OwnerDrawFixed;
            fieldNombreProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldNombreProveedor.FocusedColor = Color.SandyBrown;
            fieldNombreProveedor.FocusedState.BorderColor = Color.SandyBrown;
            fieldNombreProveedor.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreProveedor.ForeColor = Color.Black;
            fieldNombreProveedor.ItemHeight = 29;
            fieldNombreProveedor.Location = new Point(5, 5);
            fieldNombreProveedor.Margin = new Padding(5);
            fieldNombreProveedor.Name = "fieldNombreProveedor";
            fieldNombreProveedor.ShadowDecoration.CustomizableEdges = customizableEdges14;
            fieldNombreProveedor.Size = new Size(198, 35);
            fieldNombreProveedor.TabIndex = 0;
            fieldNombreProveedor.TextOffset = new Point(10, 0);
            // 
            // fieldNombreAlmacen
            // 
            fieldNombreAlmacen.Animated = true;
            fieldNombreAlmacen.BackColor = Color.Transparent;
            fieldNombreAlmacen.BorderColor = Color.Gainsboro;
            fieldNombreAlmacen.BorderRadius = 16;
            fieldNombreAlmacen.CustomizableEdges = customizableEdges15;
            fieldNombreAlmacen.Dock = DockStyle.Fill;
            fieldNombreAlmacen.DrawMode = DrawMode.OwnerDrawFixed;
            fieldNombreAlmacen.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldNombreAlmacen.FocusedColor = Color.SandyBrown;
            fieldNombreAlmacen.FocusedState.BorderColor = Color.SandyBrown;
            fieldNombreAlmacen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreAlmacen.ForeColor = Color.Black;
            fieldNombreAlmacen.ItemHeight = 29;
            fieldNombreAlmacen.Location = new Point(213, 5);
            fieldNombreAlmacen.Margin = new Padding(5);
            fieldNombreAlmacen.Name = "fieldNombreAlmacen";
            fieldNombreAlmacen.ShadowDecoration.CustomizableEdges = customizableEdges16;
            fieldNombreAlmacen.Size = new Size(199, 35);
            fieldNombreAlmacen.TabIndex = 1;
            fieldNombreAlmacen.TextOffset = new Point(10, 0);
            // 
            // separador2
            // 
            separador2.Dock = DockStyle.Fill;
            separador2.FillColor = Color.Gainsboro;
            separador2.Location = new Point(53, 313);
            separador2.Name = "separador2";
            separador2.Size = new Size(411, 14);
            separador2.TabIndex = 6;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Dock = DockStyle.Fill;
            guna2Separator1.FillColor = Color.Gainsboro;
            guna2Separator1.Location = new Point(53, 558);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(411, 14);
            guna2Separator1.TabIndex = 15;
            // 
            // layoutPrecioUnitario
            // 
            layoutPrecioUnitario.ColumnCount = 3;
            layoutPrecioUnitario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPrecioUnitario.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutPrecioUnitario.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutPrecioUnitario.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutPrecioUnitario.Controls.Add(symbolPeso1, 0, 0);
            layoutPrecioUnitario.Controls.Add(fieldPrecioUnitario, 0, 0);
            layoutPrecioUnitario.Controls.Add(fieldTituloPrecioUnitario, 0, 0);
            layoutPrecioUnitario.Dock = DockStyle.Fill;
            layoutPrecioUnitario.Location = new Point(50, 330);
            layoutPrecioUnitario.Margin = new Padding(0);
            layoutPrecioUnitario.Name = "layoutPrecioUnitario";
            layoutPrecioUnitario.RowCount = 1;
            layoutPrecioUnitario.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutPrecioUnitario.Size = new Size(417, 35);
            layoutPrecioUnitario.TabIndex = 19;
            // 
            // symbolPeso1
            // 
            symbolPeso1.Dock = DockStyle.Fill;
            symbolPeso1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            symbolPeso1.ForeColor = Color.Black;
            symbolPeso1.ImageAlign = ContentAlignment.MiddleLeft;
            symbolPeso1.ImeMode = ImeMode.NoControl;
            symbolPeso1.Location = new Point(400, 5);
            symbolPeso1.Margin = new Padding(3, 5, 3, 3);
            symbolPeso1.Name = "symbolPeso1";
            symbolPeso1.Size = new Size(14, 27);
            symbolPeso1.TabIndex = 2;
            symbolPeso1.Text = "$";
            symbolPeso1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldPrecioUnitario
            // 
            fieldPrecioUnitario.Dock = DockStyle.Fill;
            fieldPrecioUnitario.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldPrecioUnitario.ForeColor = Color.Black;
            fieldPrecioUnitario.ImageAlign = ContentAlignment.MiddleLeft;
            fieldPrecioUnitario.ImeMode = ImeMode.NoControl;
            fieldPrecioUnitario.Location = new Point(302, 5);
            fieldPrecioUnitario.Margin = new Padding(15, 5, 3, 3);
            fieldPrecioUnitario.Name = "fieldPrecioUnitario";
            fieldPrecioUnitario.Size = new Size(92, 27);
            fieldPrecioUnitario.TabIndex = 1;
            fieldPrecioUnitario.Text = "0.00";
            fieldPrecioUnitario.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldTituloPrecioUnitario
            // 
            fieldTituloPrecioUnitario.Dock = DockStyle.Fill;
            fieldTituloPrecioUnitario.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloPrecioUnitario.ForeColor = Color.DimGray;
            fieldTituloPrecioUnitario.Image = (Image) resources.GetObject("fieldTituloPrecioUnitario.Image");
            fieldTituloPrecioUnitario.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloPrecioUnitario.ImeMode = ImeMode.NoControl;
            fieldTituloPrecioUnitario.Location = new Point(15, 5);
            fieldTituloPrecioUnitario.Margin = new Padding(15, 5, 3, 3);
            fieldTituloPrecioUnitario.Name = "fieldTituloPrecioUnitario";
            fieldTituloPrecioUnitario.Size = new Size(269, 27);
            fieldTituloPrecioUnitario.TabIndex = 0;
            fieldTituloPrecioUnitario.Text = "      Precio unitario del artículo";
            fieldTituloPrecioUnitario.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutCantidad
            // 
            layoutCantidad.ColumnCount = 3;
            layoutCantidad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutCantidad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutCantidad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutCantidad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutCantidad.Controls.Add(symbolUnidad1, 0, 0);
            layoutCantidad.Controls.Add(fieldCantidad, 0, 0);
            layoutCantidad.Controls.Add(fieldTituloCantidad, 0, 0);
            layoutCantidad.Dock = DockStyle.Fill;
            layoutCantidad.Location = new Point(50, 365);
            layoutCantidad.Margin = new Padding(0);
            layoutCantidad.Name = "layoutCantidad";
            layoutCantidad.RowCount = 1;
            layoutCantidad.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutCantidad.Size = new Size(417, 35);
            layoutCantidad.TabIndex = 21;
            // 
            // symbolUnidad1
            // 
            symbolUnidad1.Dock = DockStyle.Fill;
            symbolUnidad1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            symbolUnidad1.ForeColor = Color.Black;
            symbolUnidad1.ImageAlign = ContentAlignment.MiddleLeft;
            symbolUnidad1.ImeMode = ImeMode.NoControl;
            symbolUnidad1.Location = new Point(400, 5);
            symbolUnidad1.Margin = new Padding(3, 5, 3, 3);
            symbolUnidad1.Name = "symbolUnidad1";
            symbolUnidad1.Size = new Size(14, 27);
            symbolUnidad1.TabIndex = 2;
            symbolUnidad1.Text = "U";
            symbolUnidad1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldCantidad
            // 
            fieldCantidad.Dock = DockStyle.Fill;
            fieldCantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldCantidad.ForeColor = Color.Black;
            fieldCantidad.ImageAlign = ContentAlignment.MiddleLeft;
            fieldCantidad.ImeMode = ImeMode.NoControl;
            fieldCantidad.Location = new Point(302, 5);
            fieldCantidad.Margin = new Padding(15, 5, 3, 3);
            fieldCantidad.Name = "fieldCantidad";
            fieldCantidad.Size = new Size(92, 27);
            fieldCantidad.TabIndex = 1;
            fieldCantidad.Text = "0";
            fieldCantidad.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldTituloCantidad
            // 
            fieldTituloCantidad.Dock = DockStyle.Fill;
            fieldTituloCantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloCantidad.ForeColor = Color.DimGray;
            fieldTituloCantidad.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloCantidad.ImeMode = ImeMode.NoControl;
            fieldTituloCantidad.Location = new Point(15, 5);
            fieldTituloCantidad.Margin = new Padding(15, 5, 3, 3);
            fieldTituloCantidad.Name = "fieldTituloCantidad";
            fieldTituloCantidad.Size = new Size(269, 27);
            fieldTituloCantidad.TabIndex = 0;
            fieldTituloCantidad.Text = "      Cantidad de artículos";
            fieldTituloCantidad.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VistaRegistroCompra
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(500, 685);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaRegistroCompra";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroCompra";
            layoutBase.ResumeLayout(false);
            layoutBotones.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ((ISupportInitialize) fieldIcono).EndInit();
            layoutTitulo.ResumeLayout(false);
            layoutGestionProductos.ResumeLayout(false);
            layoutMontoCompra.ResumeLayout(false);
            layoutTituloClienteAlmacen.ResumeLayout(false);
            layoutClienteAlmacen.ResumeLayout(false);
            layoutPrecioUnitario.ResumeLayout(false);
            layoutCantidad.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutBotones;
        private Guna2Button btnSalir;
        private Guna2Button btnRegistrar;
        private TableLayoutPanel layoutVista;
        private Label fieldTituloGestionArticulos;
        private PictureBox fieldIcono;
        private Label fieldSubtitulo;
        private TableLayoutPanel layoutTitulo;
        private Guna2Button btnCerrar;
        private Label fieldTitulo;
        private TableLayoutPanel layoutGestionProductos;
        private Guna2Button btnAdicionarArticulo;
        private TableLayoutPanel layoutMontoCompra;
        private Label symbolPeso;
        private Label fieldTotalCompra;
        private Label fieldTituloTotalCompra;
        private Guna2Separator separador1;
        private TableLayoutPanel layoutTituloClienteAlmacen;
        private Label fieldTituloNombreProveedor;
        private Label fieldTituloNombreAlmacen;
        private TableLayoutPanel layoutClienteAlmacen;
        private Guna2ComboBox fieldNombreProveedor;
        private Guna2ComboBox fieldNombreAlmacen;
        private Guna2Separator separador2;
        private Guna2TextBox fieldNombreArticulo;
        private Guna2TextBox fieldCantidadArticulos;
        private Guna2Separator guna2Separator1;
        private TableLayoutPanel layoutPrecioUnitario;
        private Label symbolPeso1;
        private Label fieldPrecioUnitario;
        private Label fieldTituloPrecioUnitario;
        private TableLayoutPanel layoutCantidad;
        private Label symbolUnidad1;
        private Label fieldCantidad;
        private Label fieldTituloCantidad;
    }
}