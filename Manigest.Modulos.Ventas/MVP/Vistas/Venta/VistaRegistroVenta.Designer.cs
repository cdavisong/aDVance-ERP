using Guna.UI2.WinForms;

using System.ComponentModel;

namespace Manigest.Modulos.Ventas.MVP.Vistas.Venta {
    partial class VistaRegistroVenta {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaRegistroVenta));
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            fieldTituloGestionArticulos = new Label();
            fieldIcono = new PictureBox();
            fieldSubtitulo = new Label();
            layoutTitulo = new TableLayoutPanel();
            btnCerrar = new Guna2Button();
            fieldTitulo = new Label();
            layoutGestionProductos = new TableLayoutPanel();
            btnAdicionarArticulo = new Guna2Button();
            fieldCantidad = new Guna2TextBox();
            fieldNombreArticulo = new Guna2TextBox();
            layoutPago = new TableLayoutPanel();
            symbolPeso = new Label();
            fieldTotalVenta = new Label();
            fieldTituloTotalVenta = new Label();
            btnEfectuarPago = new Guna2Button();
            layoutEncabezadosTabla = new TableLayoutPanel();
            fieldTituloCantidad = new Label();
            fieldTituloPrecio = new Label();
            fieldTituloArticulo = new Label();
            contenedorVistas = new Panel();
            separador1 = new Guna2Separator();
            layoutTituloClienteAlmacen = new TableLayoutPanel();
            fieldTituloNombreCliente = new Label();
            fieldTituloNombreAlmacen = new Label();
            layoutClienteAlmacen = new TableLayoutPanel();
            fieldNombreCliente = new Guna2ComboBox();
            fieldNombreAlmacen = new Guna2ComboBox();
            layoutBotones = new TableLayoutPanel();
            btnSalir = new Guna2Button();
            btnRegistrar = new Guna2Button();
            separador2 = new Guna2Separator();
            layoutBase.SuspendLayout();
            layoutVista.SuspendLayout();
            ((ISupportInitialize) fieldIcono).BeginInit();
            layoutTitulo.SuspendLayout();
            layoutGestionProductos.SuspendLayout();
            layoutPago.SuspendLayout();
            layoutEncabezadosTabla.SuspendLayout();
            layoutTituloClienteAlmacen.SuspendLayout();
            layoutClienteAlmacen.SuspendLayout();
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
            layoutBase.TabIndex = 0;
            // 
            // layoutVista
            // 
            layoutVista.BackColor = Color.FromArgb(  248,   244,   242);
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
            layoutVista.Controls.Add(layoutPago, 2, 13);
            layoutVista.Controls.Add(layoutEncabezadosTabla, 2, 10);
            layoutVista.Controls.Add(contenedorVistas, 2, 11);
            layoutVista.Controls.Add(separador1, 2, 6);
            layoutVista.Controls.Add(layoutTituloClienteAlmacen, 2, 4);
            layoutVista.Controls.Add(layoutClienteAlmacen, 2, 5);
            layoutVista.Controls.Add(separador2, 2, 12);
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
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.Size = new Size(487, 620);
            layoutVista.TabIndex = 0;
            // 
            // fieldTituloGestionArticulos
            // 
            fieldTituloGestionArticulos.Dock = DockStyle.Fill;
            fieldTituloGestionArticulos.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloGestionArticulos.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldTituloGestionArticulos.Image = (Image) resources.GetObject("fieldTituloGestionArticulos.Image");
            fieldTituloGestionArticulos.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloGestionArticulos.ImeMode = ImeMode.NoControl;
            fieldTituloGestionArticulos.Location = new Point(65, 235);
            fieldTituloGestionArticulos.Margin = new Padding(15, 5, 3, 3);
            fieldTituloGestionArticulos.Name = "fieldTituloGestionArticulos";
            fieldTituloGestionArticulos.Size = new Size(399, 27);
            fieldTituloGestionArticulos.TabIndex = 4;
            fieldTituloGestionArticulos.Text = "      Gestión para la venta de artículos :";
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
            fieldSubtitulo.ForeColor = Color.FromArgb(  115,   109,   106);
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
            btnCerrar.CustomizableEdges = customizableEdges1;
            btnCerrar.Dock = DockStyle.Fill;
            btnCerrar.FillColor = Color.FromArgb(  248,   244,   242);
            btnCerrar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.Black;
            btnCerrar.HoverState.FillColor = Color.FromArgb(  250,   250,   250);
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
            fieldTitulo.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldTitulo.ImeMode = ImeMode.NoControl;
            fieldTitulo.Location = new Point(3, 0);
            fieldTitulo.Name = "fieldTitulo";
            fieldTitulo.Size = new Size(361, 45);
            fieldTitulo.TabIndex = 0;
            fieldTitulo.Text = "Venta";
            fieldTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutGestionProductos
            // 
            layoutGestionProductos.ColumnCount = 3;
            layoutGestionProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutGestionProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            layoutGestionProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutGestionProductos.Controls.Add(btnAdicionarArticulo, 2, 0);
            layoutGestionProductos.Controls.Add(fieldCantidad, 1, 0);
            layoutGestionProductos.Controls.Add(fieldNombreArticulo, 0, 0);
            layoutGestionProductos.Dock = DockStyle.Fill;
            layoutGestionProductos.Location = new Point(50, 265);
            layoutGestionProductos.Margin = new Padding(0);
            layoutGestionProductos.Name = "layoutGestionProductos";
            layoutGestionProductos.RowCount = 1;
            layoutGestionProductos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutGestionProductos.Size = new Size(417, 45);
            layoutGestionProductos.TabIndex = 5;
            // 
            // btnAdicionarArticulo
            // 
            btnAdicionarArticulo.Animated = true;
            btnAdicionarArticulo.BorderRadius = 18;
            btnAdicionarArticulo.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnAdicionarArticulo.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnAdicionarArticulo.CustomizableEdges = customizableEdges3;
            btnAdicionarArticulo.DialogResult = DialogResult.Cancel;
            btnAdicionarArticulo.Dock = DockStyle.Fill;
            btnAdicionarArticulo.Enabled = false;
            btnAdicionarArticulo.FillColor = Color.FromArgb(  252,   225,   205);
            btnAdicionarArticulo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdicionarArticulo.ForeColor = Color.White;
            btnAdicionarArticulo.Location = new Point(370, 3);
            btnAdicionarArticulo.Name = "btnAdicionarArticulo";
            btnAdicionarArticulo.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAdicionarArticulo.Size = new Size(44, 39);
            btnAdicionarArticulo.TabIndex = 2;
            // 
            // fieldCantidad
            // 
            fieldCantidad.Animated = true;
            fieldCantidad.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldCantidad.BorderRadius = 16;
            fieldCantidad.Cursor = Cursors.IBeam;
            fieldCantidad.CustomizableEdges = customizableEdges5;
            fieldCantidad.DefaultText = "";
            fieldCantidad.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldCantidad.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldCantidad.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldCantidad.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldCantidad.Dock = DockStyle.Fill;
            fieldCantidad.FillColor = Color.FromArgb(  254,   254,   253);
            fieldCantidad.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldCantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldCantidad.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldCantidad.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldCantidad.IconLeftOffset = new Point(10, 0);
            fieldCantidad.IconRight = (Image) resources.GetObject("fieldCantidad.IconRight");
            fieldCantidad.IconRightOffset = new Point(6, 0);
            fieldCantidad.IconRightSize = new Size(12, 12);
            fieldCantidad.Location = new Point(277, 5);
            fieldCantidad.Margin = new Padding(5);
            fieldCantidad.Name = "fieldCantidad";
            fieldCantidad.PasswordChar = '\0';
            fieldCantidad.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldCantidad.PlaceholderText = "Cant.";
            fieldCantidad.SelectedText = "";
            fieldCantidad.ShadowDecoration.CustomizableEdges = customizableEdges6;
            fieldCantidad.Size = new Size(85, 35);
            fieldCantidad.TabIndex = 1;
            fieldCantidad.TextAlign = HorizontalAlignment.Right;
            fieldCantidad.TextOffset = new Point(5, 0);
            // 
            // fieldNombreArticulo
            // 
            fieldNombreArticulo.Animated = true;
            fieldNombreArticulo.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldNombreArticulo.BorderRadius = 16;
            fieldNombreArticulo.Cursor = Cursors.IBeam;
            fieldNombreArticulo.CustomizableEdges = customizableEdges7;
            fieldNombreArticulo.DefaultText = "";
            fieldNombreArticulo.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldNombreArticulo.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldNombreArticulo.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldNombreArticulo.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldNombreArticulo.Dock = DockStyle.Fill;
            fieldNombreArticulo.FillColor = Color.FromArgb(  254,   254,   253);
            fieldNombreArticulo.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldNombreArticulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreArticulo.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldNombreArticulo.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldNombreArticulo.IconLeft = (Image) resources.GetObject("fieldNombreArticulo.IconLeft");
            fieldNombreArticulo.IconLeftOffset = new Point(10, 0);
            fieldNombreArticulo.Location = new Point(5, 5);
            fieldNombreArticulo.Margin = new Padding(5);
            fieldNombreArticulo.Name = "fieldNombreArticulo";
            fieldNombreArticulo.PasswordChar = '\0';
            fieldNombreArticulo.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldNombreArticulo.PlaceholderText = "Nombre o identificador";
            fieldNombreArticulo.SelectedText = "";
            fieldNombreArticulo.ShadowDecoration.CustomizableEdges = customizableEdges8;
            fieldNombreArticulo.Size = new Size(262, 35);
            fieldNombreArticulo.TabIndex = 0;
            fieldNombreArticulo.TextOffset = new Point(5, 0);
            // 
            // layoutPago
            // 
            layoutPago.ColumnCount = 4;
            layoutPago.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPago.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutPago.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutPago.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutPago.Controls.Add(symbolPeso, 0, 0);
            layoutPago.Controls.Add(fieldTotalVenta, 0, 0);
            layoutPago.Controls.Add(fieldTituloTotalVenta, 0, 0);
            layoutPago.Controls.Add(btnEfectuarPago, 3, 0);
            layoutPago.Dock = DockStyle.Fill;
            layoutPago.Location = new Point(50, 555);
            layoutPago.Margin = new Padding(0);
            layoutPago.Name = "layoutPago";
            layoutPago.RowCount = 1;
            layoutPago.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutPago.Size = new Size(417, 45);
            layoutPago.TabIndex = 8;
            // 
            // symbolPeso
            // 
            symbolPeso.Dock = DockStyle.Fill;
            symbolPeso.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            symbolPeso.ForeColor = Color.Black;
            symbolPeso.ImageAlign = ContentAlignment.MiddleLeft;
            symbolPeso.ImeMode = ImeMode.NoControl;
            symbolPeso.Location = new Point(290, 5);
            symbolPeso.Margin = new Padding(3, 5, 3, 3);
            symbolPeso.Name = "symbolPeso";
            symbolPeso.Size = new Size(14, 37);
            symbolPeso.TabIndex = 2;
            symbolPeso.Text = "$";
            symbolPeso.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTotalVenta
            // 
            fieldTotalVenta.Dock = DockStyle.Fill;
            fieldTotalVenta.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTotalVenta.ForeColor = Color.Black;
            fieldTotalVenta.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTotalVenta.ImeMode = ImeMode.NoControl;
            fieldTotalVenta.Location = new Point(192, 5);
            fieldTotalVenta.Margin = new Padding(15, 5, 3, 3);
            fieldTotalVenta.Name = "fieldTotalVenta";
            fieldTotalVenta.Size = new Size(92, 37);
            fieldTotalVenta.TabIndex = 1;
            fieldTotalVenta.Text = "0";
            fieldTotalVenta.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldTituloTotalVenta
            // 
            fieldTituloTotalVenta.Dock = DockStyle.Fill;
            fieldTituloTotalVenta.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloTotalVenta.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldTituloTotalVenta.Image = (Image) resources.GetObject("fieldTituloTotalVenta.Image");
            fieldTituloTotalVenta.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloTotalVenta.ImeMode = ImeMode.NoControl;
            fieldTituloTotalVenta.Location = new Point(15, 5);
            fieldTituloTotalVenta.Margin = new Padding(15, 5, 3, 3);
            fieldTituloTotalVenta.Name = "fieldTituloTotalVenta";
            fieldTituloTotalVenta.Size = new Size(159, 37);
            fieldTituloTotalVenta.TabIndex = 0;
            fieldTituloTotalVenta.Text = "      Precio total :";
            fieldTituloTotalVenta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnEfectuarPago
            // 
            btnEfectuarPago.Animated = true;
            btnEfectuarPago.BorderRadius = 18;
            btnEfectuarPago.CustomImages.Image = (Image) resources.GetObject("resource.Image1");
            btnEfectuarPago.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEfectuarPago.CustomizableEdges = customizableEdges9;
            btnEfectuarPago.DialogResult = DialogResult.Cancel;
            btnEfectuarPago.Dock = DockStyle.Fill;
            btnEfectuarPago.Enabled = false;
            btnEfectuarPago.FillColor = Color.FromArgb(  252,   225,   205);
            btnEfectuarPago.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnEfectuarPago.ForeColor = Color.White;
            btnEfectuarPago.Location = new Point(310, 3);
            btnEfectuarPago.Name = "btnEfectuarPago";
            btnEfectuarPago.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnEfectuarPago.Size = new Size(104, 39);
            btnEfectuarPago.TabIndex = 3;
            // 
            // layoutEncabezadosTabla
            // 
            layoutEncabezadosTabla.BackColor = Color.FromArgb(  243,   243,   243);
            layoutEncabezadosTabla.ColumnCount = 5;
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutEncabezadosTabla.Controls.Add(fieldTituloCantidad, 2, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloPrecio, 1, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloArticulo, 0, 0);
            layoutEncabezadosTabla.Dock = DockStyle.Fill;
            layoutEncabezadosTabla.Location = new Point(51, 321);
            layoutEncabezadosTabla.Margin = new Padding(1);
            layoutEncabezadosTabla.Name = "layoutEncabezadosTabla";
            layoutEncabezadosTabla.RowCount = 1;
            layoutEncabezadosTabla.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.Size = new Size(415, 43);
            layoutEncabezadosTabla.TabIndex = 6;
            // 
            // fieldTituloCantidad
            // 
            fieldTituloCantidad.Dock = DockStyle.Fill;
            fieldTituloCantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
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
            fieldTituloPrecio.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
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
            // fieldTituloArticulo
            // 
            fieldTituloArticulo.Dock = DockStyle.Fill;
            fieldTituloArticulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloArticulo.ForeColor = Color.Black;
            fieldTituloArticulo.ImeMode = ImeMode.NoControl;
            fieldTituloArticulo.Location = new Point(1, 1);
            fieldTituloArticulo.Margin = new Padding(1);
            fieldTituloArticulo.Name = "fieldTituloArticulo";
            fieldTituloArticulo.Size = new Size(173, 41);
            fieldTituloArticulo.TabIndex = 0;
            fieldTituloArticulo.Text = "Artículo";
            fieldTituloArticulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contenedorVistas
            // 
            contenedorVistas.AutoScroll = true;
            contenedorVistas.Dock = DockStyle.Fill;
            contenedorVistas.Location = new Point(50, 365);
            contenedorVistas.Margin = new Padding(0);
            contenedorVistas.Name = "contenedorVistas";
            contenedorVistas.Size = new Size(417, 170);
            contenedorVistas.TabIndex = 7;
            // 
            // separador1
            // 
            separador1.Dock = DockStyle.Fill;
            separador1.FillColor = Color.FromArgb(  217,   211,   204);
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
            layoutTituloClienteAlmacen.Controls.Add(fieldTituloNombreCliente, 0, 0);
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
            // fieldTituloNombreCliente
            // 
            fieldTituloNombreCliente.Dock = DockStyle.Fill;
            fieldTituloNombreCliente.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloNombreCliente.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldTituloNombreCliente.Image = (Image) resources.GetObject("fieldTituloNombreCliente.Image");
            fieldTituloNombreCliente.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloNombreCliente.ImeMode = ImeMode.NoControl;
            fieldTituloNombreCliente.Location = new Point(15, 5);
            fieldTituloNombreCliente.Margin = new Padding(15, 5, 3, 3);
            fieldTituloNombreCliente.Name = "fieldTituloNombreCliente";
            fieldTituloNombreCliente.Size = new Size(190, 27);
            fieldTituloNombreCliente.TabIndex = 0;
            fieldTituloNombreCliente.Text = "      Cliente :";
            fieldTituloNombreCliente.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldTituloNombreAlmacen
            // 
            fieldTituloNombreAlmacen.Dock = DockStyle.Fill;
            fieldTituloNombreAlmacen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloNombreAlmacen.ForeColor = Color.FromArgb(  115,   109,   106);
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
            layoutClienteAlmacen.Controls.Add(fieldNombreCliente, 0, 0);
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
            // fieldNombreCliente
            // 
            fieldNombreCliente.Animated = true;
            fieldNombreCliente.BackColor = Color.Transparent;
            fieldNombreCliente.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldNombreCliente.BorderRadius = 16;
            fieldNombreCliente.CustomizableEdges = customizableEdges11;
            fieldNombreCliente.Dock = DockStyle.Fill;
            fieldNombreCliente.DrawMode = DrawMode.OwnerDrawFixed;
            fieldNombreCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldNombreCliente.FillColor = Color.FromArgb(  254,   254,   253);
            fieldNombreCliente.FocusedColor = Color.FromArgb(  2,   52,   107);
            fieldNombreCliente.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldNombreCliente.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreCliente.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldNombreCliente.ItemHeight = 29;
            fieldNombreCliente.Location = new Point(5, 5);
            fieldNombreCliente.Margin = new Padding(5);
            fieldNombreCliente.Name = "fieldNombreCliente";
            fieldNombreCliente.ShadowDecoration.CustomizableEdges = customizableEdges12;
            fieldNombreCliente.Size = new Size(198, 35);
            fieldNombreCliente.TabIndex = 0;
            fieldNombreCliente.TextOffset = new Point(10, 0);
            // 
            // fieldNombreAlmacen
            // 
            fieldNombreAlmacen.Animated = true;
            fieldNombreAlmacen.BackColor = Color.Transparent;
            fieldNombreAlmacen.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldNombreAlmacen.BorderRadius = 16;
            fieldNombreAlmacen.CustomizableEdges = customizableEdges13;
            fieldNombreAlmacen.Dock = DockStyle.Fill;
            fieldNombreAlmacen.DrawMode = DrawMode.OwnerDrawFixed;
            fieldNombreAlmacen.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldNombreAlmacen.FillColor = Color.FromArgb(  254,   254,   253);
            fieldNombreAlmacen.FocusedColor = Color.FromArgb(  2,   52,   107);
            fieldNombreAlmacen.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldNombreAlmacen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreAlmacen.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldNombreAlmacen.ItemHeight = 29;
            fieldNombreAlmacen.Location = new Point(213, 5);
            fieldNombreAlmacen.Margin = new Padding(5);
            fieldNombreAlmacen.Name = "fieldNombreAlmacen";
            fieldNombreAlmacen.ShadowDecoration.CustomizableEdges = customizableEdges14;
            fieldNombreAlmacen.Size = new Size(199, 35);
            fieldNombreAlmacen.TabIndex = 1;
            fieldNombreAlmacen.TextOffset = new Point(10, 0);
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
            layoutBotones.TabIndex = 1;
            // 
            // btnSalir
            // 
            btnSalir.Animated = true;
            btnSalir.BorderColor = Color.FromArgb(  217,   211,   204);
            btnSalir.BorderRadius = 18;
            btnSalir.BorderThickness = 1;
            btnSalir.CustomizableEdges = customizableEdges15;
            btnSalir.Dock = DockStyle.Fill;
            btnSalir.FillColor = Color.FromArgb(  254,   254,   253);
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.FromArgb(  217,   211,   204);
            btnSalir.HoverState.BorderColor = Color.FromArgb(  217,   211,   204);
            btnSalir.HoverState.FillColor = Color.FromArgb(  217,   211,   204);
            btnSalir.HoverState.ForeColor = Color.FromArgb(  40,   37,   35);
            btnSalir.Location = new Point(302, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnSalir.Size = new Size(160, 39);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Cancelar";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Animated = true;
            btnRegistrar.BorderRadius = 18;
            btnRegistrar.CustomizableEdges = customizableEdges17;
            btnRegistrar.Dock = DockStyle.Fill;
            btnRegistrar.Enabled = false;
            btnRegistrar.FillColor = Color.FromArgb(  217,   211,   204);
            btnRegistrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrar.ForeColor = Color.FromArgb(  40,   37,   35);
            btnRegistrar.Location = new Point(53, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnRegistrar.Size = new Size(243, 39);
            btnRegistrar.TabIndex = 0;
            btnRegistrar.Text = "Registrar venta";
            // 
            // separador2
            // 
            separador2.Dock = DockStyle.Fill;
            separador2.FillColor = Color.FromArgb(  217,   211,   204);
            separador2.Location = new Point(53, 538);
            separador2.Name = "separador2";
            separador2.Size = new Size(411, 14);
            separador2.TabIndex = 15;
            // 
            // VistaRegistroVenta
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(500, 685);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaRegistroVenta";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroVenta";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ((ISupportInitialize) fieldIcono).EndInit();
            layoutTitulo.ResumeLayout(false);
            layoutGestionProductos.ResumeLayout(false);
            layoutPago.ResumeLayout(false);
            layoutEncabezadosTabla.ResumeLayout(false);
            layoutTituloClienteAlmacen.ResumeLayout(false);
            layoutClienteAlmacen.ResumeLayout(false);
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
        private Guna2ComboBox fieldNombreAlmacen;
        private TableLayoutPanel layoutBotones;
        private Guna2Button btnSalir;
        private Guna2Button btnRegistrar;
        private TableLayoutPanel layoutTituloClienteAlmacen;
        private Label fieldTituloNombreCliente;
        private Guna2ComboBox fieldNombreCliente;
        private Label fieldTituloGestionArticulos;
        private TableLayoutPanel layoutGestionProductos;
        private Guna2Button btnAdicionarArticulo;
        private Label fieldTituloNombreAlmacen;
        private TableLayoutPanel layoutPago;
        private Guna2Button btnEfectuarPago;
        private Label fieldTituloTotalVenta;
        private Label fieldTotalVenta;
        private Label symbolPeso;
        private TableLayoutPanel layoutEncabezadosTabla;
        private Label fieldTituloArticulo;
        private Label fieldTituloCantidad;
        private Label fieldTituloPrecio;
        private Panel contenedorVistas;
        private Guna2TextBox fieldCantidad;
        private Guna2Separator separador1;
        private Guna2TextBox fieldNombreArticulo;
        private TableLayoutPanel layoutClienteAlmacen;
        private Guna2Separator separador2;
    }
}