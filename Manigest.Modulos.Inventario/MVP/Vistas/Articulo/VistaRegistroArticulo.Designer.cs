using Guna.UI2.WinForms;

using System.ComponentModel;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Articulo {
    partial class VistaRegistroArticulo {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaRegistroArticulo));
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            fieldIcono = new PictureBox();
            fieldSubtitulo = new Label();
            layoutTitulo = new TableLayoutPanel();
            btnCerrar = new Guna2Button();
            fieldTitulo = new Label();
            layoutPrecios = new TableLayoutPanel();
            fieldPrecioCesion = new Guna2TextBox();
            fieldPrecioAdquisicion = new Guna2TextBox();
            fieldDescripcion = new Guna2TextBox();
            layoutStock = new TableLayoutPanel();
            fieldPedidoMinimo = new Guna2TextBox();
            fieldStockMinimo = new Guna2TextBox();
            fieldTituloNombreProveedor = new Label();
            fieldNombreProveedor = new Guna2ComboBox();
            fieldCodigo = new Guna2TextBox();
            fieldNombre = new Guna2TextBox();
            layoutBotones = new TableLayoutPanel();
            btnSalir = new Guna2Button();
            btnRegistrar = new Guna2Button();
            layoutBase.SuspendLayout();
            layoutVista.SuspendLayout();
            ((ISupportInitialize) fieldIcono).BeginInit();
            layoutTitulo.SuspendLayout();
            layoutPrecios.SuspendLayout();
            layoutStock.SuspendLayout();
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
            layoutVista.Controls.Add(fieldIcono, 1, 1);
            layoutVista.Controls.Add(fieldSubtitulo, 2, 2);
            layoutVista.Controls.Add(layoutTitulo, 2, 1);
            layoutVista.Controls.Add(layoutPrecios, 2, 13);
            layoutVista.Controls.Add(fieldDescripcion, 2, 8);
            layoutVista.Controls.Add(layoutStock, 2, 15);
            layoutVista.Controls.Add(fieldTituloNombreProveedor, 2, 10);
            layoutVista.Controls.Add(fieldNombreProveedor, 2, 11);
            layoutVista.Controls.Add(fieldCodigo, 2, 6);
            layoutVista.Controls.Add(fieldNombre, 2, 4);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(13, 0);
            layoutVista.Margin = new Padding(3, 0, 0, 0);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 18;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
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
            layoutTitulo.TabIndex = 8;
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
            fieldTitulo.Text = "Artículo";
            fieldTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutPrecios
            // 
            layoutPrecios.ColumnCount = 2;
            layoutPrecios.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutPrecios.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutPrecios.Controls.Add(fieldPrecioCesion, 0, 0);
            layoutPrecios.Controls.Add(fieldPrecioAdquisicion, 0, 0);
            layoutPrecios.Dock = DockStyle.Fill;
            layoutPrecios.Location = new Point(50, 410);
            layoutPrecios.Margin = new Padding(0);
            layoutPrecios.Name = "layoutPrecios";
            layoutPrecios.RowCount = 1;
            layoutPrecios.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutPrecios.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutPrecios.Size = new Size(417, 45);
            layoutPrecios.TabIndex = 6;
            // 
            // fieldPrecioCesion
            // 
            fieldPrecioCesion.Animated = true;
            fieldPrecioCesion.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldPrecioCesion.BorderRadius = 16;
            fieldPrecioCesion.Cursor = Cursors.IBeam;
            fieldPrecioCesion.CustomizableEdges = customizableEdges3;
            fieldPrecioCesion.DefaultText = "";
            fieldPrecioCesion.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldPrecioCesion.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldPrecioCesion.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldPrecioCesion.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldPrecioCesion.Dock = DockStyle.Fill;
            fieldPrecioCesion.FillColor = Color.FromArgb(  254,   254,   253);
            fieldPrecioCesion.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldPrecioCesion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldPrecioCesion.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldPrecioCesion.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldPrecioCesion.IconLeft = (Image) resources.GetObject("fieldPrecioCesion.IconLeft");
            fieldPrecioCesion.IconLeftOffset = new Point(10, 0);
            fieldPrecioCesion.IconRight = (Image) resources.GetObject("fieldPrecioCesion.IconRight");
            fieldPrecioCesion.IconRightOffset = new Point(6, 0);
            fieldPrecioCesion.IconRightSize = new Size(12, 12);
            fieldPrecioCesion.Location = new Point(213, 5);
            fieldPrecioCesion.Margin = new Padding(5);
            fieldPrecioCesion.Name = "fieldPrecioCesion";
            fieldPrecioCesion.PasswordChar = '\0';
            fieldPrecioCesion.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldPrecioCesion.PlaceholderText = "P. Cesión";
            fieldPrecioCesion.SelectedText = "";
            fieldPrecioCesion.ShadowDecoration.CustomizableEdges = customizableEdges4;
            fieldPrecioCesion.Size = new Size(199, 35);
            fieldPrecioCesion.TabIndex = 1;
            fieldPrecioCesion.TextAlign = HorizontalAlignment.Right;
            fieldPrecioCesion.TextOffset = new Point(5, 0);
            // 
            // fieldPrecioAdquisicion
            // 
            fieldPrecioAdquisicion.Animated = true;
            fieldPrecioAdquisicion.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldPrecioAdquisicion.BorderRadius = 16;
            fieldPrecioAdquisicion.Cursor = Cursors.IBeam;
            fieldPrecioAdquisicion.CustomizableEdges = customizableEdges5;
            fieldPrecioAdquisicion.DefaultText = "";
            fieldPrecioAdquisicion.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldPrecioAdquisicion.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldPrecioAdquisicion.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldPrecioAdquisicion.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldPrecioAdquisicion.Dock = DockStyle.Fill;
            fieldPrecioAdquisicion.FillColor = Color.FromArgb(  254,   254,   253);
            fieldPrecioAdquisicion.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldPrecioAdquisicion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldPrecioAdquisicion.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldPrecioAdquisicion.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldPrecioAdquisicion.IconLeft = (Image) resources.GetObject("fieldPrecioAdquisicion.IconLeft");
            fieldPrecioAdquisicion.IconLeftOffset = new Point(10, 0);
            fieldPrecioAdquisicion.IconRight = (Image) resources.GetObject("fieldPrecioAdquisicion.IconRight");
            fieldPrecioAdquisicion.IconRightOffset = new Point(6, 0);
            fieldPrecioAdquisicion.IconRightSize = new Size(12, 12);
            fieldPrecioAdquisicion.Location = new Point(5, 5);
            fieldPrecioAdquisicion.Margin = new Padding(5);
            fieldPrecioAdquisicion.Name = "fieldPrecioAdquisicion";
            fieldPrecioAdquisicion.PasswordChar = '\0';
            fieldPrecioAdquisicion.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldPrecioAdquisicion.PlaceholderText = "P. Adquisición";
            fieldPrecioAdquisicion.SelectedText = "";
            fieldPrecioAdquisicion.ShadowDecoration.CustomizableEdges = customizableEdges6;
            fieldPrecioAdquisicion.Size = new Size(198, 35);
            fieldPrecioAdquisicion.TabIndex = 0;
            fieldPrecioAdquisicion.TextAlign = HorizontalAlignment.Right;
            fieldPrecioAdquisicion.TextOffset = new Point(5, 0);
            // 
            // fieldDescripcion
            // 
            fieldDescripcion.Animated = true;
            fieldDescripcion.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldDescripcion.BorderRadius = 16;
            fieldDescripcion.Cursor = Cursors.IBeam;
            fieldDescripcion.CustomizableEdges = customizableEdges7;
            fieldDescripcion.DefaultText = "";
            fieldDescripcion.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldDescripcion.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldDescripcion.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldDescripcion.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldDescripcion.Dock = DockStyle.Fill;
            fieldDescripcion.FillColor = Color.FromArgb(  254,   254,   253);
            fieldDescripcion.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldDescripcion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldDescripcion.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldDescripcion.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldDescripcion.IconLeft = (Image) resources.GetObject("fieldDescripcion.IconLeft");
            fieldDescripcion.IconLeftOffset = new Point(10, -11);
            fieldDescripcion.Location = new Point(55, 245);
            fieldDescripcion.Margin = new Padding(5);
            fieldDescripcion.Multiline = true;
            fieldDescripcion.Name = "fieldDescripcion";
            fieldDescripcion.PasswordChar = '\0';
            fieldDescripcion.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldDescripcion.PlaceholderText = "Descripción";
            fieldDescripcion.SelectedText = "";
            fieldDescripcion.ShadowDecoration.CustomizableEdges = customizableEdges8;
            fieldDescripcion.Size = new Size(407, 60);
            fieldDescripcion.TabIndex = 3;
            fieldDescripcion.TextOffset = new Point(5, 0);
            // 
            // layoutStock
            // 
            layoutStock.ColumnCount = 2;
            layoutStock.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutStock.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutStock.Controls.Add(fieldPedidoMinimo, 1, 0);
            layoutStock.Controls.Add(fieldStockMinimo, 0, 0);
            layoutStock.Dock = DockStyle.Fill;
            layoutStock.Location = new Point(50, 465);
            layoutStock.Margin = new Padding(0);
            layoutStock.Name = "layoutStock";
            layoutStock.RowCount = 1;
            layoutStock.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutStock.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutStock.Size = new Size(417, 45);
            layoutStock.TabIndex = 7;
            // 
            // fieldPedidoMinimo
            // 
            fieldPedidoMinimo.Animated = true;
            fieldPedidoMinimo.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldPedidoMinimo.BorderRadius = 16;
            fieldPedidoMinimo.Cursor = Cursors.IBeam;
            fieldPedidoMinimo.CustomizableEdges = customizableEdges9;
            fieldPedidoMinimo.DefaultText = "";
            fieldPedidoMinimo.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldPedidoMinimo.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldPedidoMinimo.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldPedidoMinimo.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldPedidoMinimo.Dock = DockStyle.Fill;
            fieldPedidoMinimo.FillColor = Color.FromArgb(  254,   254,   253);
            fieldPedidoMinimo.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldPedidoMinimo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldPedidoMinimo.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldPedidoMinimo.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldPedidoMinimo.IconLeft = (Image) resources.GetObject("fieldPedidoMinimo.IconLeft");
            fieldPedidoMinimo.IconLeftOffset = new Point(10, 0);
            fieldPedidoMinimo.IconRight = (Image) resources.GetObject("fieldPedidoMinimo.IconRight");
            fieldPedidoMinimo.IconRightOffset = new Point(6, 0);
            fieldPedidoMinimo.IconRightSize = new Size(12, 12);
            fieldPedidoMinimo.Location = new Point(213, 5);
            fieldPedidoMinimo.Margin = new Padding(5);
            fieldPedidoMinimo.Name = "fieldPedidoMinimo";
            fieldPedidoMinimo.PasswordChar = '\0';
            fieldPedidoMinimo.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldPedidoMinimo.PlaceholderText = "Pedido mínimo";
            fieldPedidoMinimo.SelectedText = "";
            fieldPedidoMinimo.ShadowDecoration.CustomizableEdges = customizableEdges10;
            fieldPedidoMinimo.Size = new Size(199, 35);
            fieldPedidoMinimo.TabIndex = 1;
            fieldPedidoMinimo.TextAlign = HorizontalAlignment.Right;
            fieldPedidoMinimo.TextOffset = new Point(5, 0);
            // 
            // fieldStockMinimo
            // 
            fieldStockMinimo.Animated = true;
            fieldStockMinimo.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldStockMinimo.BorderRadius = 16;
            fieldStockMinimo.Cursor = Cursors.IBeam;
            fieldStockMinimo.CustomizableEdges = customizableEdges11;
            fieldStockMinimo.DefaultText = "";
            fieldStockMinimo.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldStockMinimo.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldStockMinimo.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldStockMinimo.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldStockMinimo.Dock = DockStyle.Fill;
            fieldStockMinimo.FillColor = Color.FromArgb(  254,   254,   253);
            fieldStockMinimo.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldStockMinimo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldStockMinimo.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldStockMinimo.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldStockMinimo.IconLeft = (Image) resources.GetObject("fieldStockMinimo.IconLeft");
            fieldStockMinimo.IconLeftOffset = new Point(10, 0);
            fieldStockMinimo.IconRight = (Image) resources.GetObject("fieldStockMinimo.IconRight");
            fieldStockMinimo.IconRightOffset = new Point(6, 0);
            fieldStockMinimo.IconRightSize = new Size(12, 12);
            fieldStockMinimo.Location = new Point(5, 5);
            fieldStockMinimo.Margin = new Padding(5);
            fieldStockMinimo.Name = "fieldStockMinimo";
            fieldStockMinimo.PasswordChar = '\0';
            fieldStockMinimo.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldStockMinimo.PlaceholderText = "Stock mínimo";
            fieldStockMinimo.SelectedText = "";
            fieldStockMinimo.ShadowDecoration.CustomizableEdges = customizableEdges12;
            fieldStockMinimo.Size = new Size(198, 35);
            fieldStockMinimo.TabIndex = 0;
            fieldStockMinimo.TextAlign = HorizontalAlignment.Right;
            fieldStockMinimo.TextOffset = new Point(5, 0);
            // 
            // fieldTituloNombreProveedor
            // 
            fieldTituloNombreProveedor.Dock = DockStyle.Fill;
            fieldTituloNombreProveedor.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloNombreProveedor.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldTituloNombreProveedor.Image = (Image) resources.GetObject("fieldTituloNombreProveedor.Image");
            fieldTituloNombreProveedor.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloNombreProveedor.ImeMode = ImeMode.NoControl;
            fieldTituloNombreProveedor.Location = new Point(65, 325);
            fieldTituloNombreProveedor.Margin = new Padding(15, 5, 3, 3);
            fieldTituloNombreProveedor.Name = "fieldTituloNombreProveedor";
            fieldTituloNombreProveedor.Size = new Size(399, 27);
            fieldTituloNombreProveedor.TabIndex = 4;
            fieldTituloNombreProveedor.Text = "      Proveedor :";
            fieldTituloNombreProveedor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldNombreProveedor
            // 
            fieldNombreProveedor.Animated = true;
            fieldNombreProveedor.BackColor = Color.Transparent;
            fieldNombreProveedor.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldNombreProveedor.BorderRadius = 16;
            fieldNombreProveedor.CustomizableEdges = customizableEdges13;
            fieldNombreProveedor.Dock = DockStyle.Fill;
            fieldNombreProveedor.DrawMode = DrawMode.OwnerDrawFixed;
            fieldNombreProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldNombreProveedor.FillColor = Color.FromArgb(  254,   254,   253);
            fieldNombreProveedor.FocusedColor = Color.FromArgb(  2,   52,   107);
            fieldNombreProveedor.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldNombreProveedor.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreProveedor.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldNombreProveedor.ItemHeight = 29;
            fieldNombreProveedor.Location = new Point(55, 360);
            fieldNombreProveedor.Margin = new Padding(5);
            fieldNombreProveedor.Name = "fieldNombreProveedor";
            fieldNombreProveedor.ShadowDecoration.CustomizableEdges = customizableEdges14;
            fieldNombreProveedor.Size = new Size(407, 35);
            fieldNombreProveedor.TabIndex = 5;
            fieldNombreProveedor.TextOffset = new Point(10, 0);
            // 
            // fieldCodigo
            // 
            fieldCodigo.Animated = true;
            fieldCodigo.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldCodigo.BorderRadius = 16;
            fieldCodigo.Cursor = Cursors.IBeam;
            fieldCodigo.CustomizableEdges = customizableEdges15;
            fieldCodigo.DefaultText = "";
            fieldCodigo.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldCodigo.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldCodigo.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldCodigo.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldCodigo.Dock = DockStyle.Fill;
            fieldCodigo.FillColor = Color.FromArgb(  254,   254,   253);
            fieldCodigo.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldCodigo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldCodigo.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldCodigo.HoverState.BorderColor = Color.FromArgb(  94,   148,   255);
            fieldCodigo.IconLeft = (Image) resources.GetObject("fieldCodigo.IconLeft");
            fieldCodigo.IconLeftOffset = new Point(10, 0);
            fieldCodigo.Location = new Point(55, 190);
            fieldCodigo.Margin = new Padding(5);
            fieldCodigo.Name = "fieldCodigo";
            fieldCodigo.PasswordChar = '\0';
            fieldCodigo.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldCodigo.PlaceholderText = "Código";
            fieldCodigo.SelectedText = "";
            fieldCodigo.ShadowDecoration.CustomizableEdges = customizableEdges16;
            fieldCodigo.Size = new Size(407, 35);
            fieldCodigo.TabIndex = 2;
            fieldCodigo.TextOffset = new Point(5, 0);
            // 
            // fieldNombre
            // 
            fieldNombre.Animated = true;
            fieldNombre.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldNombre.BorderRadius = 16;
            fieldNombre.Cursor = Cursors.IBeam;
            fieldNombre.CustomizableEdges = customizableEdges17;
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
            fieldNombre.PlaceholderText = "Nombre o identificador";
            fieldNombre.SelectedText = "";
            fieldNombre.ShadowDecoration.CustomizableEdges = customizableEdges18;
            fieldNombre.Size = new Size(407, 35);
            fieldNombre.TabIndex = 1;
            fieldNombre.TextOffset = new Point(5, 0);
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
            layoutBotones.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.Animated = true;
            btnSalir.BorderColor = Color.FromArgb(  217,   211,   204);
            btnSalir.BorderRadius = 18;
            btnSalir.BorderThickness = 1;
            btnSalir.CustomizableEdges = customizableEdges19;
            btnSalir.Dock = DockStyle.Fill;
            btnSalir.FillColor = Color.FromArgb(  254,   254,   253);
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.FromArgb(  217,   211,   204);
            btnSalir.HoverState.BorderColor = Color.FromArgb(  217,   211,   204);
            btnSalir.HoverState.FillColor = Color.FromArgb(  217,   211,   204);
            btnSalir.HoverState.ForeColor = Color.FromArgb(  40,   37,   35);
            btnSalir.Location = new Point(302, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnSalir.Size = new Size(160, 39);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Animated = true;
            btnRegistrar.BorderRadius = 18;
            btnRegistrar.CustomizableEdges = customizableEdges21;
            btnRegistrar.Dock = DockStyle.Fill;
            btnRegistrar.FillColor = Color.FromArgb(  217,   211,   204);
            btnRegistrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrar.ForeColor = Color.FromArgb(  40,   37,   35);
            btnRegistrar.Location = new Point(53, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnRegistrar.Size = new Size(243, 39);
            btnRegistrar.TabIndex = 0;
            btnRegistrar.Text = "Registrar artículo";
            // 
            // VistaRegistroArticulo
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(500, 685);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaRegistroArticulo";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroArticulo";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ((ISupportInitialize) fieldIcono).EndInit();
            layoutTitulo.ResumeLayout(false);
            layoutPrecios.ResumeLayout(false);
            layoutStock.ResumeLayout(false);
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
        private Guna2TextBox fieldCodigo;
        private TableLayoutPanel layoutBotones;
        private Guna2Button btnSalir;
        private Guna2Button btnRegistrar;
        private Label fieldTituloNombreProveedor;
        private Guna2ComboBox fieldNombreProveedor;
        private TableLayoutPanel layoutPrecios;
        private Guna2TextBox fieldPrecioCesion;
        private Guna2TextBox fieldPrecioAdquisicion;
        private TableLayoutPanel layoutStock;
        private Guna2TextBox fieldStockMinimo;
        private Guna2TextBox fieldPedidoMinimo;
        private Guna2TextBox fieldDescripcion;
    }
}