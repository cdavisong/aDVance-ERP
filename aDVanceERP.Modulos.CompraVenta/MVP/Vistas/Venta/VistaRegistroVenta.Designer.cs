using Guna.UI2.WinForms;

using System.ComponentModel;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta {
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
            fieldIcono = new PictureBox();
            fieldSubtitulo = new Label();
            layoutTitulo = new TableLayoutPanel();
            btnCerrar = new Guna2Button();
            fieldTitulo = new Label();
            layoutGestionProductos = new TableLayoutPanel();
            btnAdicionarProducto = new Guna2Button();
            fieldCantidad = new Guna2TextBox();
            fieldNombreProducto = new Guna2TextBox();
            layoutPago = new TableLayoutPanel();
            symbolPeso = new Label();
            btnAsignarMensajeria = new Guna2Button();
            btnEfectuarPago = new Guna2Button();
            fieldTotalVenta = new Label();
            fieldTituloTotalVenta = new Label();
            layoutEncabezadosTabla = new TableLayoutPanel();
            fieldTituloCantidad = new Label();
            fieldTituloPrecio = new Label();
            fieldTituloProducto = new Label();
            contenedorVistas = new Panel();
            separador1 = new Guna2Separator();
            separador2 = new Guna2Separator();
            fieldTituloNombreAlmacen = new Label();
            fieldNombreAlmacen = new Guna2ComboBox();
            layoutBotones = new TableLayoutPanel();
            btnSalir = new Guna2Button();
            btnRegistrar = new Guna2Button();
            layoutBase.SuspendLayout();
            layoutVista.SuspendLayout();
            ((ISupportInitialize) fieldIcono).BeginInit();
            layoutTitulo.SuspendLayout();
            layoutGestionProductos.SuspendLayout();
            layoutPago.SuspendLayout();
            layoutEncabezadosTabla.SuspendLayout();
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
            layoutBase.TabIndex = 0;
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
            layoutVista.Controls.Add(layoutGestionProductos, 2, 7);
            layoutVista.Controls.Add(layoutPago, 2, 12);
            layoutVista.Controls.Add(layoutEncabezadosTabla, 2, 9);
            layoutVista.Controls.Add(contenedorVistas, 2, 10);
            layoutVista.Controls.Add(separador1, 2, 6);
            layoutVista.Controls.Add(separador2, 2, 11);
            layoutVista.Controls.Add(fieldTituloNombreAlmacen, 2, 4);
            layoutVista.Controls.Add(fieldNombreAlmacen, 2, 5);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(13, 0);
            layoutVista.Margin = new Padding(3, 0, 0, 0);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 14;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
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
            fieldTitulo.Text = "Venta";
            fieldTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutGestionProductos
            // 
            layoutGestionProductos.ColumnCount = 3;
            layoutGestionProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutGestionProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            layoutGestionProductos.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutGestionProductos.Controls.Add(btnAdicionarProducto, 2, 0);
            layoutGestionProductos.Controls.Add(fieldCantidad, 1, 0);
            layoutGestionProductos.Controls.Add(fieldNombreProducto, 0, 0);
            layoutGestionProductos.Dock = DockStyle.Fill;
            layoutGestionProductos.Location = new Point(50, 230);
            layoutGestionProductos.Margin = new Padding(0);
            layoutGestionProductos.Name = "layoutGestionProductos";
            layoutGestionProductos.RowCount = 1;
            layoutGestionProductos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutGestionProductos.Size = new Size(417, 45);
            layoutGestionProductos.TabIndex = 4;
            // 
            // btnAdicionarProducto
            // 
            btnAdicionarProducto.Animated = true;
            btnAdicionarProducto.BorderRadius = 18;
            btnAdicionarProducto.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnAdicionarProducto.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnAdicionarProducto.CustomizableEdges = customizableEdges3;
            btnAdicionarProducto.DialogResult = DialogResult.Cancel;
            btnAdicionarProducto.Dock = DockStyle.Fill;
            btnAdicionarProducto.Enabled = false;
            btnAdicionarProducto.FillColor = Color.PeachPuff;
            btnAdicionarProducto.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdicionarProducto.ForeColor = Color.White;
            btnAdicionarProducto.Location = new Point(372, 5);
            btnAdicionarProducto.Margin = new Padding(5);
            btnAdicionarProducto.Name = "btnAdicionarProducto";
            btnAdicionarProducto.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnAdicionarProducto.Size = new Size(40, 35);
            btnAdicionarProducto.TabIndex = 2;
            // 
            // fieldCantidad
            // 
            fieldCantidad.Animated = true;
            fieldCantidad.BorderColor = Color.Gainsboro;
            fieldCantidad.BorderRadius = 16;
            fieldCantidad.Cursor = Cursors.IBeam;
            fieldCantidad.CustomizableEdges = customizableEdges5;
            fieldCantidad.DefaultText = "";
            fieldCantidad.DisabledState.BorderColor = Color.Gainsboro;
            fieldCantidad.DisabledState.FillColor = Color.White;
            fieldCantidad.DisabledState.ForeColor = Color.DimGray;
            fieldCantidad.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldCantidad.Dock = DockStyle.Fill;
            fieldCantidad.FocusedState.BorderColor = Color.SandyBrown;
            fieldCantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            fieldCantidad.ShadowDecoration.CustomizableEdges = customizableEdges6;
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
            fieldNombreProducto.CustomizableEdges = customizableEdges7;
            fieldNombreProducto.DefaultText = "";
            fieldNombreProducto.DisabledState.BorderColor = Color.Gainsboro;
            fieldNombreProducto.DisabledState.FillColor = Color.White;
            fieldNombreProducto.DisabledState.ForeColor = Color.DimGray;
            fieldNombreProducto.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldNombreProducto.Dock = DockStyle.Fill;
            fieldNombreProducto.FocusedState.BorderColor = Color.SandyBrown;
            fieldNombreProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreProducto.ForeColor = Color.Black;
            fieldNombreProducto.HoverState.BorderColor = Color.SandyBrown;
            fieldNombreProducto.IconLeft = (Image) resources.GetObject("fieldNombreProducto.IconLeft");
            fieldNombreProducto.IconLeftOffset = new Point(10, 0);
            fieldNombreProducto.Location = new Point(5, 5);
            fieldNombreProducto.Margin = new Padding(5);
            fieldNombreProducto.Name = "fieldNombreProducto";
            fieldNombreProducto.PasswordChar = '\0';
            fieldNombreProducto.PlaceholderForeColor = Color.DimGray;
            fieldNombreProducto.PlaceholderText = "Nombre del producto";
            fieldNombreProducto.SelectedText = "";
            fieldNombreProducto.ShadowDecoration.CustomizableEdges = customizableEdges8;
            fieldNombreProducto.Size = new Size(262, 35);
            fieldNombreProducto.TabIndex = 0;
            fieldNombreProducto.TextOffset = new Point(5, 0);
            // 
            // layoutPago
            // 
            layoutPago.ColumnCount = 5;
            layoutPago.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPago.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutPago.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutPago.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutPago.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutPago.Controls.Add(symbolPeso, 2, 0);
            layoutPago.Controls.Add(btnAsignarMensajeria, 4, 0);
            layoutPago.Controls.Add(btnEfectuarPago, 3, 0);
            layoutPago.Controls.Add(fieldTotalVenta, 1, 0);
            layoutPago.Controls.Add(fieldTituloTotalVenta, 0, 0);
            layoutPago.Dock = DockStyle.Fill;
            layoutPago.Location = new Point(50, 555);
            layoutPago.Margin = new Padding(0);
            layoutPago.Name = "layoutPago";
            layoutPago.RowCount = 1;
            layoutPago.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutPago.Size = new Size(417, 45);
            layoutPago.TabIndex = 7;
            // 
            // symbolPeso
            // 
            symbolPeso.Dock = DockStyle.Fill;
            symbolPeso.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            symbolPeso.ForeColor = Color.Black;
            symbolPeso.ImageAlign = ContentAlignment.MiddleLeft;
            symbolPeso.ImeMode = ImeMode.NoControl;
            symbolPeso.Location = new Point(300, 5);
            symbolPeso.Margin = new Padding(3, 5, 3, 3);
            symbolPeso.Name = "symbolPeso";
            symbolPeso.Size = new Size(14, 37);
            symbolPeso.TabIndex = 4;
            symbolPeso.Text = "$";
            symbolPeso.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAsignarMensajería
            // 
            btnAsignarMensajeria.Animated = true;
            btnAsignarMensajeria.BorderRadius = 18;
            btnAsignarMensajeria.CustomImages.Image = (Image) resources.GetObject("resource.Image1");
            btnAsignarMensajeria.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnAsignarMensajeria.CustomizableEdges = customizableEdges9;
            btnAsignarMensajeria.DialogResult = DialogResult.Cancel;
            btnAsignarMensajeria.Dock = DockStyle.Fill;
            btnAsignarMensajeria.Enabled = false;
            btnAsignarMensajeria.FillColor = Color.PeachPuff;
            btnAsignarMensajeria.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAsignarMensajeria.ForeColor = Color.White;
            btnAsignarMensajeria.Location = new Point(370, 3);
            btnAsignarMensajeria.Name = "btnAsignarMensajería";
            btnAsignarMensajeria.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnAsignarMensajeria.Size = new Size(44, 39);
            btnAsignarMensajeria.TabIndex = 3;
            // 
            // btnEfectuarPago
            // 
            btnEfectuarPago.Animated = true;
            btnEfectuarPago.BorderRadius = 18;
            btnEfectuarPago.CustomImages.Image = (Image) resources.GetObject("resource.Image2");
            btnEfectuarPago.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEfectuarPago.CustomizableEdges = customizableEdges11;
            btnEfectuarPago.DialogResult = DialogResult.Cancel;
            btnEfectuarPago.Dock = DockStyle.Fill;
            btnEfectuarPago.Enabled = false;
            btnEfectuarPago.FillColor = Color.PeachPuff;
            btnEfectuarPago.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnEfectuarPago.ForeColor = Color.White;
            btnEfectuarPago.Location = new Point(320, 3);
            btnEfectuarPago.Name = "btnEfectuarPago";
            btnEfectuarPago.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnEfectuarPago.Size = new Size(44, 39);
            btnEfectuarPago.TabIndex = 2;
            // 
            // fieldTotalVenta
            // 
            fieldTotalVenta.Dock = DockStyle.Fill;
            fieldTotalVenta.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTotalVenta.ForeColor = Color.Black;
            fieldTotalVenta.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTotalVenta.ImeMode = ImeMode.NoControl;
            fieldTotalVenta.Location = new Point(202, 5);
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
            fieldTituloTotalVenta.ForeColor = Color.DimGray;
            fieldTituloTotalVenta.Image = (Image) resources.GetObject("fieldTituloTotalVenta.Image");
            fieldTituloTotalVenta.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloTotalVenta.ImeMode = ImeMode.NoControl;
            fieldTituloTotalVenta.Location = new Point(15, 5);
            fieldTituloTotalVenta.Margin = new Padding(15, 5, 3, 3);
            fieldTituloTotalVenta.Name = "fieldTituloTotalVenta";
            fieldTituloTotalVenta.Size = new Size(169, 37);
            fieldTituloTotalVenta.TabIndex = 0;
            fieldTituloTotalVenta.Text = "      Precio total";
            fieldTituloTotalVenta.TextAlign = ContentAlignment.MiddleLeft;
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
            layoutEncabezadosTabla.Controls.Add(fieldTituloProducto, 0, 0);
            layoutEncabezadosTabla.Dock = DockStyle.Fill;
            layoutEncabezadosTabla.Location = new Point(51, 286);
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
            // fieldTituloProducto
            // 
            fieldTituloProducto.Dock = DockStyle.Fill;
            fieldTituloProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloProducto.ForeColor = Color.Black;
            fieldTituloProducto.ImeMode = ImeMode.NoControl;
            fieldTituloProducto.Location = new Point(1, 1);
            fieldTituloProducto.Margin = new Padding(1);
            fieldTituloProducto.Name = "fieldTituloProducto";
            fieldTituloProducto.Size = new Size(173, 41);
            fieldTituloProducto.TabIndex = 0;
            fieldTituloProducto.Text = "Producto";
            fieldTituloProducto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contenedorVistas
            // 
            contenedorVistas.AutoScroll = true;
            contenedorVistas.Dock = DockStyle.Fill;
            contenedorVistas.Location = new Point(50, 330);
            contenedorVistas.Margin = new Padding(0);
            contenedorVistas.Name = "contenedorVistas";
            contenedorVistas.Size = new Size(417, 205);
            contenedorVistas.TabIndex = 5;
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
            // separador2
            // 
            separador2.Dock = DockStyle.Fill;
            separador2.FillColor = Color.Gainsboro;
            separador2.Location = new Point(53, 538);
            separador2.Name = "separador2";
            separador2.Size = new Size(411, 14);
            separador2.TabIndex = 6;
            // 
            // fieldTituloNombreAlmacen
            // 
            fieldTituloNombreAlmacen.Dock = DockStyle.Fill;
            fieldTituloNombreAlmacen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloNombreAlmacen.ForeColor = Color.DimGray;
            fieldTituloNombreAlmacen.Image = (Image) resources.GetObject("fieldTituloNombreAlmacen.Image");
            fieldTituloNombreAlmacen.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloNombreAlmacen.ImeMode = ImeMode.NoControl;
            fieldTituloNombreAlmacen.Location = new Point(65, 135);
            fieldTituloNombreAlmacen.Margin = new Padding(15, 5, 3, 3);
            fieldTituloNombreAlmacen.Name = "fieldTituloNombreAlmacen";
            fieldTituloNombreAlmacen.Size = new Size(399, 27);
            fieldTituloNombreAlmacen.TabIndex = 1;
            fieldTituloNombreAlmacen.Text = "      Almacén de ventas :";
            fieldTituloNombreAlmacen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldNombreAlmacen
            // 
            fieldNombreAlmacen.Animated = true;
            fieldNombreAlmacen.BackColor = Color.Transparent;
            fieldNombreAlmacen.BorderColor = Color.Gainsboro;
            fieldNombreAlmacen.BorderRadius = 16;
            fieldNombreAlmacen.CustomizableEdges = customizableEdges13;
            fieldNombreAlmacen.Dock = DockStyle.Fill;
            fieldNombreAlmacen.DrawMode = DrawMode.OwnerDrawFixed;
            fieldNombreAlmacen.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldNombreAlmacen.FocusedColor = Color.SandyBrown;
            fieldNombreAlmacen.FocusedState.BorderColor = Color.SandyBrown;
            fieldNombreAlmacen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreAlmacen.ForeColor = Color.Black;
            fieldNombreAlmacen.ItemHeight = 29;
            fieldNombreAlmacen.Location = new Point(55, 170);
            fieldNombreAlmacen.Margin = new Padding(5);
            fieldNombreAlmacen.Name = "fieldNombreAlmacen";
            fieldNombreAlmacen.ShadowDecoration.CustomizableEdges = customizableEdges14;
            fieldNombreAlmacen.Size = new Size(407, 35);
            fieldNombreAlmacen.TabIndex = 2;
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
            btnSalir.BorderColor = Color.Gainsboro;
            btnSalir.BorderRadius = 18;
            btnSalir.BorderThickness = 1;
            btnSalir.CustomizableEdges = customizableEdges15;
            btnSalir.Dock = DockStyle.Fill;
            btnSalir.FillColor = Color.White;
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.FromArgb(  208,   197,   188);
            btnSalir.HoverState.BorderColor = Color.SandyBrown;
            btnSalir.HoverState.FillColor = Color.FromArgb(  208,   197,   188);
            btnSalir.HoverState.ForeColor = Color.Black;
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
            btnRegistrar.FillColor = Color.PeachPuff;
            btnRegistrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrar.ForeColor = Color.Black;
            btnRegistrar.Location = new Point(53, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnRegistrar.Size = new Size(243, 39);
            btnRegistrar.TabIndex = 0;
            btnRegistrar.Text = "Registrar venta";
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
        private TableLayoutPanel layoutGestionProductos;
        private Guna2Button btnAdicionarProducto;
        private Label fieldTituloNombreAlmacen;
        private TableLayoutPanel layoutPago;
        private Guna2Button btnEfectuarPago;
        private Label fieldTituloTotalVenta;
        private Label fieldTotalVenta;
        private Label symbolPeso;
        private TableLayoutPanel layoutEncabezadosTabla;
        private Label fieldTituloProducto;
        private Label fieldTituloCantidad;
        private Label fieldTituloPrecio;
        private Panel contenedorVistas;
        private Guna2TextBox fieldCantidad;
        private Guna2Separator separador1;
        private Guna2TextBox fieldNombreProducto;
        private Guna2Separator separador2;
        private Guna2Button btnAsignarMensajeria;
    }
}