using Guna.UI2.WinForms;

using System.ComponentModel;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento {
    partial class VistaRegistroMovimiento {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaRegistroMovimiento));
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
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            fieldIcono = new PictureBox();
            fieldSubtitulo = new Label();
            layoutTitulo = new TableLayoutPanel();
            btnCerrar = new Guna2Button();
            fieldTitulo = new Label();
            fieldNotas = new Guna2TextBox();
            fieldTituloNombreArticulo = new Label();
            fieldNombreArticulo = new Guna2ComboBox();
            layoutTituloMotivoCantidad = new TableLayoutPanel();
            fieldTituloMotivo = new Label();
            layoutTituloAlmacenes = new TableLayoutPanel();
            fieldTituloNombreAlmacenOrigen = new Label();
            fieldTituloNombreAlmacenDestino = new Label();
            layoutMotivoCantidad = new TableLayoutPanel();
            fieldCantidadMovida = new Guna2TextBox();
            layoutTipoMovimiento = new TableLayoutPanel();
            btnAdicionarTipoMovimiento = new Guna2Button();
            fieldTipoMovimiento = new Guna2ComboBox();
            layoutAlmacenes = new TableLayoutPanel();
            fieldNombreAlmacenOrigen = new Guna2ComboBox();
            fieldNombreAlmacenDestino = new Guna2ComboBox();
            layoutBotones = new TableLayoutPanel();
            btnSalir = new Guna2Button();
            btnRegistrar = new Guna2Button();
            layoutBase.SuspendLayout();
            layoutVista.SuspendLayout();
            ((ISupportInitialize) fieldIcono).BeginInit();
            layoutTitulo.SuspendLayout();
            layoutTituloMotivoCantidad.SuspendLayout();
            layoutTituloAlmacenes.SuspendLayout();
            layoutMotivoCantidad.SuspendLayout();
            layoutTipoMovimiento.SuspendLayout();
            layoutAlmacenes.SuspendLayout();
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
            layoutBase.TabIndex = 2;
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
            layoutVista.Controls.Add(fieldNotas, 2, 13);
            layoutVista.Controls.Add(fieldTituloNombreArticulo, 2, 4);
            layoutVista.Controls.Add(fieldNombreArticulo, 2, 5);
            layoutVista.Controls.Add(layoutTituloMotivoCantidad, 2, 7);
            layoutVista.Controls.Add(layoutTituloAlmacenes, 2, 10);
            layoutVista.Controls.Add(layoutMotivoCantidad, 2, 8);
            layoutVista.Controls.Add(layoutAlmacenes, 2, 11);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(13, 0);
            layoutVista.Margin = new Padding(3, 0, 0, 0);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 16;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
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
            fieldTitulo.Text = "Movimiento";
            fieldTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldNotas
            // 
            fieldNotas.Animated = true;
            fieldNotas.BorderColor = Color.Gainsboro;
            fieldNotas.BorderRadius = 16;
            fieldNotas.Cursor = Cursors.IBeam;
            fieldNotas.CustomizableEdges = customizableEdges3;
            fieldNotas.DefaultText = "";
            fieldNotas.DisabledState.BorderColor = Color.White;
            fieldNotas.DisabledState.ForeColor = Color.DimGray;
            fieldNotas.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldNotas.Dock = DockStyle.Fill;
            fieldNotas.FocusedState.BorderColor = Color.SandyBrown;
            fieldNotas.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNotas.ForeColor = Color.Black;
            fieldNotas.HoverState.BorderColor = Color.SandyBrown;
            fieldNotas.IconLeft = (Image) resources.GetObject("fieldNotas.IconLeft");
            fieldNotas.IconLeftOffset = new Point(10, -11);
            fieldNotas.Location = new Point(55, 405);
            fieldNotas.Margin = new Padding(5);
            fieldNotas.Multiline = true;
            fieldNotas.Name = "fieldNotas";
            fieldNotas.PasswordChar = '\0';
            fieldNotas.PlaceholderForeColor = Color.DimGray;
            fieldNotas.PlaceholderText = "Notas";
            fieldNotas.SelectedText = "";
            fieldNotas.ShadowDecoration.CustomizableEdges = customizableEdges4;
            fieldNotas.Size = new Size(407, 60);
            fieldNotas.TabIndex = 30;
            fieldNotas.TextOffset = new Point(5, 0);
            // 
            // fieldTituloNombreArticulo
            // 
            fieldTituloNombreArticulo.Dock = DockStyle.Fill;
            fieldTituloNombreArticulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloNombreArticulo.ForeColor = Color.DimGray;
            fieldTituloNombreArticulo.Image = (Image) resources.GetObject("fieldTituloNombreArticulo.Image");
            fieldTituloNombreArticulo.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloNombreArticulo.ImeMode = ImeMode.NoControl;
            fieldTituloNombreArticulo.Location = new Point(65, 135);
            fieldTituloNombreArticulo.Margin = new Padding(15, 5, 3, 3);
            fieldTituloNombreArticulo.Name = "fieldTituloNombreArticulo";
            fieldTituloNombreArticulo.Size = new Size(399, 27);
            fieldTituloNombreArticulo.TabIndex = 33;
            fieldTituloNombreArticulo.Text = "      Artículo :";
            fieldTituloNombreArticulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldNombreArticulo
            // 
            fieldNombreArticulo.Animated = true;
            fieldNombreArticulo.BackColor = Color.Transparent;
            fieldNombreArticulo.BorderColor = Color.Gainsboro;
            fieldNombreArticulo.BorderRadius = 16;
            fieldNombreArticulo.CustomizableEdges = customizableEdges5;
            fieldNombreArticulo.Dock = DockStyle.Fill;
            fieldNombreArticulo.DrawMode = DrawMode.OwnerDrawFixed;
            fieldNombreArticulo.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldNombreArticulo.FocusedColor = Color.SandyBrown;
            fieldNombreArticulo.FocusedState.BorderColor = Color.SandyBrown;
            fieldNombreArticulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreArticulo.ForeColor = Color.Black;
            fieldNombreArticulo.ItemHeight = 29;
            fieldNombreArticulo.Location = new Point(55, 170);
            fieldNombreArticulo.Margin = new Padding(5);
            fieldNombreArticulo.Name = "fieldNombreArticulo";
            fieldNombreArticulo.ShadowDecoration.CustomizableEdges = customizableEdges6;
            fieldNombreArticulo.Size = new Size(407, 35);
            fieldNombreArticulo.TabIndex = 34;
            fieldNombreArticulo.TextOffset = new Point(10, 0);
            // 
            // layoutTituloMotivoCantidad
            // 
            layoutTituloMotivoCantidad.ColumnCount = 2;
            layoutTituloMotivoCantidad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutTituloMotivoCantidad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutTituloMotivoCantidad.Controls.Add(fieldTituloMotivo, 0, 0);
            layoutTituloMotivoCantidad.Dock = DockStyle.Fill;
            layoutTituloMotivoCantidad.Location = new Point(50, 220);
            layoutTituloMotivoCantidad.Margin = new Padding(0);
            layoutTituloMotivoCantidad.Name = "layoutTituloMotivoCantidad";
            layoutTituloMotivoCantidad.RowCount = 1;
            layoutTituloMotivoCantidad.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutTituloMotivoCantidad.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutTituloMotivoCantidad.Size = new Size(417, 35);
            layoutTituloMotivoCantidad.TabIndex = 29;
            // 
            // fieldTituloMotivo
            // 
            fieldTituloMotivo.Dock = DockStyle.Fill;
            fieldTituloMotivo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloMotivo.ForeColor = Color.DimGray;
            fieldTituloMotivo.Image = (Image) resources.GetObject("fieldTituloMotivo.Image");
            fieldTituloMotivo.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloMotivo.ImeMode = ImeMode.NoControl;
            fieldTituloMotivo.Location = new Point(15, 5);
            fieldTituloMotivo.Margin = new Padding(15, 5, 3, 3);
            fieldTituloMotivo.Name = "fieldTituloMotivo";
            fieldTituloMotivo.Size = new Size(190, 27);
            fieldTituloMotivo.TabIndex = 31;
            fieldTituloMotivo.Text = "      Tipo de movimiento :";
            fieldTituloMotivo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutTituloAlmacenes
            // 
            layoutTituloAlmacenes.ColumnCount = 2;
            layoutTituloAlmacenes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutTituloAlmacenes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutTituloAlmacenes.Controls.Add(fieldTituloNombreAlmacenOrigen, 0, 0);
            layoutTituloAlmacenes.Controls.Add(fieldTituloNombreAlmacenDestino, 1, 0);
            layoutTituloAlmacenes.Dock = DockStyle.Fill;
            layoutTituloAlmacenes.Location = new Point(50, 310);
            layoutTituloAlmacenes.Margin = new Padding(0);
            layoutTituloAlmacenes.Name = "layoutTituloAlmacenes";
            layoutTituloAlmacenes.RowCount = 1;
            layoutTituloAlmacenes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutTituloAlmacenes.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutTituloAlmacenes.Size = new Size(417, 35);
            layoutTituloAlmacenes.TabIndex = 31;
            // 
            // fieldTituloNombreAlmacenOrigen
            // 
            fieldTituloNombreAlmacenOrigen.Dock = DockStyle.Fill;
            fieldTituloNombreAlmacenOrigen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloNombreAlmacenOrigen.ForeColor = Color.DimGray;
            fieldTituloNombreAlmacenOrigen.Image = (Image) resources.GetObject("fieldTituloNombreAlmacenOrigen.Image");
            fieldTituloNombreAlmacenOrigen.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloNombreAlmacenOrigen.ImeMode = ImeMode.NoControl;
            fieldTituloNombreAlmacenOrigen.Location = new Point(15, 5);
            fieldTituloNombreAlmacenOrigen.Margin = new Padding(15, 5, 3, 3);
            fieldTituloNombreAlmacenOrigen.Name = "fieldTituloNombreAlmacenOrigen";
            fieldTituloNombreAlmacenOrigen.Size = new Size(190, 27);
            fieldTituloNombreAlmacenOrigen.TabIndex = 24;
            fieldTituloNombreAlmacenOrigen.Text = "      Almacén de origen :";
            fieldTituloNombreAlmacenOrigen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldTituloNombreAlmacenDestino
            // 
            fieldTituloNombreAlmacenDestino.Dock = DockStyle.Fill;
            fieldTituloNombreAlmacenDestino.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloNombreAlmacenDestino.ForeColor = Color.DimGray;
            fieldTituloNombreAlmacenDestino.Image = (Image) resources.GetObject("fieldTituloNombreAlmacenDestino.Image");
            fieldTituloNombreAlmacenDestino.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloNombreAlmacenDestino.ImeMode = ImeMode.NoControl;
            fieldTituloNombreAlmacenDestino.Location = new Point(223, 5);
            fieldTituloNombreAlmacenDestino.Margin = new Padding(15, 5, 3, 3);
            fieldTituloNombreAlmacenDestino.Name = "fieldTituloNombreAlmacenDestino";
            fieldTituloNombreAlmacenDestino.Size = new Size(191, 27);
            fieldTituloNombreAlmacenDestino.TabIndex = 25;
            fieldTituloNombreAlmacenDestino.Text = "      Almacén destino :";
            fieldTituloNombreAlmacenDestino.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutMotivoCantidad
            // 
            layoutMotivoCantidad.ColumnCount = 2;
            layoutMotivoCantidad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutMotivoCantidad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutMotivoCantidad.Controls.Add(fieldCantidadMovida, 1, 0);
            layoutMotivoCantidad.Controls.Add(layoutTipoMovimiento, 0, 0);
            layoutMotivoCantidad.Dock = DockStyle.Fill;
            layoutMotivoCantidad.Location = new Point(50, 255);
            layoutMotivoCantidad.Margin = new Padding(0);
            layoutMotivoCantidad.Name = "layoutMotivoCantidad";
            layoutMotivoCantidad.RowCount = 1;
            layoutMotivoCantidad.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutMotivoCantidad.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutMotivoCantidad.Size = new Size(417, 45);
            layoutMotivoCantidad.TabIndex = 30;
            // 
            // fieldCantidadMovida
            // 
            fieldCantidadMovida.Animated = true;
            fieldCantidadMovida.BorderColor = Color.Gainsboro;
            fieldCantidadMovida.BorderRadius = 16;
            fieldCantidadMovida.Cursor = Cursors.IBeam;
            fieldCantidadMovida.CustomizableEdges = customizableEdges7;
            fieldCantidadMovida.DefaultText = "";
            fieldCantidadMovida.DisabledState.BorderColor = Color.White;
            fieldCantidadMovida.DisabledState.ForeColor = Color.DimGray;
            fieldCantidadMovida.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldCantidadMovida.Dock = DockStyle.Fill;
            fieldCantidadMovida.FocusedState.BorderColor = Color.SandyBrown;
            fieldCantidadMovida.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldCantidadMovida.ForeColor = Color.Black;
            fieldCantidadMovida.HoverState.BorderColor = Color.SandyBrown;
            fieldCantidadMovida.IconLeft = (Image) resources.GetObject("fieldCantidadMovida.IconLeft");
            fieldCantidadMovida.IconLeftOffset = new Point(10, 0);
            fieldCantidadMovida.IconRight = (Image) resources.GetObject("fieldCantidadMovida.IconRight");
            fieldCantidadMovida.IconRightOffset = new Point(6, 0);
            fieldCantidadMovida.IconRightSize = new Size(12, 12);
            fieldCantidadMovida.Location = new Point(213, 5);
            fieldCantidadMovida.Margin = new Padding(5);
            fieldCantidadMovida.Name = "fieldCantidadMovida";
            fieldCantidadMovida.PasswordChar = '\0';
            fieldCantidadMovida.PlaceholderForeColor = Color.DimGray;
            fieldCantidadMovida.PlaceholderText = "Cantidad movida";
            fieldCantidadMovida.SelectedText = "";
            fieldCantidadMovida.ShadowDecoration.CustomizableEdges = customizableEdges8;
            fieldCantidadMovida.Size = new Size(199, 35);
            fieldCantidadMovida.TabIndex = 3;
            fieldCantidadMovida.TextAlign = HorizontalAlignment.Right;
            fieldCantidadMovida.TextOffset = new Point(5, 0);
            // 
            // layoutTipoMovimiento
            // 
            layoutTipoMovimiento.ColumnCount = 2;
            layoutTipoMovimiento.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutTipoMovimiento.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutTipoMovimiento.Controls.Add(btnAdicionarTipoMovimiento, 1, 0);
            layoutTipoMovimiento.Controls.Add(fieldTipoMovimiento, 0, 0);
            layoutTipoMovimiento.Dock = DockStyle.Fill;
            layoutTipoMovimiento.Location = new Point(0, 0);
            layoutTipoMovimiento.Margin = new Padding(0);
            layoutTipoMovimiento.Name = "layoutTipoMovimiento";
            layoutTipoMovimiento.RowCount = 1;
            layoutTipoMovimiento.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutTipoMovimiento.Size = new Size(208, 45);
            layoutTipoMovimiento.TabIndex = 4;
            // 
            // btnAdicionarTipoMovimiento
            // 
            btnAdicionarTipoMovimiento.Animated = true;
            btnAdicionarTipoMovimiento.BorderRadius = 18;
            btnAdicionarTipoMovimiento.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnAdicionarTipoMovimiento.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnAdicionarTipoMovimiento.CustomizableEdges = customizableEdges9;
            btnAdicionarTipoMovimiento.DialogResult = DialogResult.Cancel;
            btnAdicionarTipoMovimiento.Dock = DockStyle.Fill;
            btnAdicionarTipoMovimiento.FillColor = Color.PeachPuff;
            btnAdicionarTipoMovimiento.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdicionarTipoMovimiento.ForeColor = Color.White;
            btnAdicionarTipoMovimiento.Location = new Point(161, 3);
            btnAdicionarTipoMovimiento.Name = "btnAdicionarTipoMovimiento";
            btnAdicionarTipoMovimiento.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnAdicionarTipoMovimiento.Size = new Size(44, 39);
            btnAdicionarTipoMovimiento.TabIndex = 33;
            // 
            // fieldTipoMovimiento
            // 
            fieldTipoMovimiento.Animated = true;
            fieldTipoMovimiento.BackColor = Color.Transparent;
            fieldTipoMovimiento.BorderColor = Color.Gainsboro;
            fieldTipoMovimiento.BorderRadius = 16;
            fieldTipoMovimiento.CustomizableEdges = customizableEdges11;
            fieldTipoMovimiento.Dock = DockStyle.Fill;
            fieldTipoMovimiento.DrawMode = DrawMode.OwnerDrawFixed;
            fieldTipoMovimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldTipoMovimiento.FocusedColor = Color.SandyBrown;
            fieldTipoMovimiento.FocusedState.BorderColor = Color.SandyBrown;
            fieldTipoMovimiento.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTipoMovimiento.ForeColor = Color.Black;
            fieldTipoMovimiento.ItemHeight = 29;
            fieldTipoMovimiento.Location = new Point(5, 5);
            fieldTipoMovimiento.Margin = new Padding(5);
            fieldTipoMovimiento.Name = "fieldTipoMovimiento";
            fieldTipoMovimiento.ShadowDecoration.CustomizableEdges = customizableEdges12;
            fieldTipoMovimiento.Size = new Size(148, 35);
            fieldTipoMovimiento.TabIndex = 32;
            fieldTipoMovimiento.TextOffset = new Point(10, 0);
            // 
            // layoutAlmacenes
            // 
            layoutAlmacenes.ColumnCount = 2;
            layoutAlmacenes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutAlmacenes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutAlmacenes.Controls.Add(fieldNombreAlmacenOrigen, 0, 0);
            layoutAlmacenes.Controls.Add(fieldNombreAlmacenDestino, 1, 0);
            layoutAlmacenes.Dock = DockStyle.Fill;
            layoutAlmacenes.Location = new Point(50, 345);
            layoutAlmacenes.Margin = new Padding(0);
            layoutAlmacenes.Name = "layoutAlmacenes";
            layoutAlmacenes.RowCount = 1;
            layoutAlmacenes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutAlmacenes.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutAlmacenes.Size = new Size(417, 45);
            layoutAlmacenes.TabIndex = 32;
            // 
            // fieldNombreAlmacenOrigen
            // 
            fieldNombreAlmacenOrigen.Animated = true;
            fieldNombreAlmacenOrigen.BackColor = Color.Transparent;
            fieldNombreAlmacenOrigen.BorderColor = Color.Gainsboro;
            fieldNombreAlmacenOrigen.BorderRadius = 16;
            fieldNombreAlmacenOrigen.CustomizableEdges = customizableEdges13;
            fieldNombreAlmacenOrigen.Dock = DockStyle.Fill;
            fieldNombreAlmacenOrigen.DrawMode = DrawMode.OwnerDrawFixed;
            fieldNombreAlmacenOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldNombreAlmacenOrigen.FocusedColor = Color.SandyBrown;
            fieldNombreAlmacenOrigen.FocusedState.BorderColor = Color.SandyBrown;
            fieldNombreAlmacenOrigen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreAlmacenOrigen.ForeColor = Color.Black;
            fieldNombreAlmacenOrigen.ItemHeight = 29;
            fieldNombreAlmacenOrigen.Location = new Point(5, 5);
            fieldNombreAlmacenOrigen.Margin = new Padding(5);
            fieldNombreAlmacenOrigen.Name = "fieldNombreAlmacenOrigen";
            fieldNombreAlmacenOrigen.ShadowDecoration.CustomizableEdges = customizableEdges14;
            fieldNombreAlmacenOrigen.Size = new Size(198, 35);
            fieldNombreAlmacenOrigen.TabIndex = 25;
            fieldNombreAlmacenOrigen.TextOffset = new Point(10, 0);
            // 
            // fieldNombreAlmacenDestino
            // 
            fieldNombreAlmacenDestino.Animated = true;
            fieldNombreAlmacenDestino.BackColor = Color.Transparent;
            fieldNombreAlmacenDestino.BorderColor = Color.Gainsboro;
            fieldNombreAlmacenDestino.BorderRadius = 16;
            fieldNombreAlmacenDestino.CustomizableEdges = customizableEdges15;
            fieldNombreAlmacenDestino.Dock = DockStyle.Fill;
            fieldNombreAlmacenDestino.DrawMode = DrawMode.OwnerDrawFixed;
            fieldNombreAlmacenDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldNombreAlmacenDestino.FocusedColor = Color.SandyBrown;
            fieldNombreAlmacenDestino.FocusedState.BorderColor = Color.SandyBrown;
            fieldNombreAlmacenDestino.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreAlmacenDestino.ForeColor = Color.Black;
            fieldNombreAlmacenDestino.ItemHeight = 29;
            fieldNombreAlmacenDestino.Location = new Point(213, 5);
            fieldNombreAlmacenDestino.Margin = new Padding(5);
            fieldNombreAlmacenDestino.Name = "fieldNombreAlmacenDestino";
            fieldNombreAlmacenDestino.ShadowDecoration.CustomizableEdges = customizableEdges16;
            fieldNombreAlmacenDestino.Size = new Size(199, 35);
            fieldNombreAlmacenDestino.TabIndex = 28;
            fieldNombreAlmacenDestino.TextOffset = new Point(10, 0);
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
            layoutBotones.TabIndex = 4;
            // 
            // btnSalir
            // 
            btnSalir.Animated = true;
            btnSalir.BorderColor = Color.Gainsboro;
            btnSalir.BorderRadius = 18;
            btnSalir.BorderThickness = 1;
            btnSalir.CustomizableEdges = customizableEdges17;
            btnSalir.Dock = DockStyle.Fill;
            btnSalir.FillColor = Color.White;
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.Gainsboro;
            btnSalir.HoverState.BorderColor = Color.PeachPuff;
            btnSalir.HoverState.FillColor = Color.PeachPuff;
            btnSalir.HoverState.ForeColor = Color.Black;
            btnSalir.Location = new Point(302, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnSalir.Size = new Size(160, 39);
            btnSalir.TabIndex = 14;
            btnSalir.Text = "Salir";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Animated = true;
            btnRegistrar.BorderRadius = 18;
            btnRegistrar.CustomizableEdges = customizableEdges19;
            btnRegistrar.Dock = DockStyle.Fill;
            btnRegistrar.FillColor = Color.PeachPuff;
            btnRegistrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrar.ForeColor = Color.Black;
            btnRegistrar.Location = new Point(53, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnRegistrar.Size = new Size(243, 39);
            btnRegistrar.TabIndex = 15;
            btnRegistrar.Text = "Registrar movimiento";
            // 
            // VistaRegistroMovimiento
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(500, 685);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaRegistroMovimiento";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroMovimiento";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ((ISupportInitialize) fieldIcono).EndInit();
            layoutTitulo.ResumeLayout(false);
            layoutTituloMotivoCantidad.ResumeLayout(false);
            layoutTituloAlmacenes.ResumeLayout(false);
            layoutMotivoCantidad.ResumeLayout(false);
            layoutTipoMovimiento.ResumeLayout(false);
            layoutAlmacenes.ResumeLayout(false);
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
        private Label fieldTituloNombreAlmacenOrigen;
        private Guna2ComboBox fieldNombreAlmacenOrigen;
        private TableLayoutPanel layoutBotones;
        private Guna2Button btnSalir;
        private Guna2Button btnRegistrar;
        private Label fieldTituloNombreAlmacenDestino;
        private Guna2ComboBox fieldNombreAlmacenDestino;
        private TableLayoutPanel layoutPrecios;
        private Guna2TextBox fieldPrecioCesion;
        private Guna2TextBox fieldPrecioAdquisicion;
        private TableLayoutPanel layoutTituloMotivoCantidad;
        private Guna2TextBox fieldCantidadMovida;
        private Guna2TextBox fieldStock;
        private Guna2TextBox fieldNotas;
        private Label fieldTituloMotivo;
        private TableLayoutPanel layoutMotivoCantidad;
        private TableLayoutPanel layoutTituloAlmacenes;
        private TableLayoutPanel layoutAlmacenes;
        private Label fieldTituloNombreArticulo;
        private Guna2ComboBox fieldNombreArticulo;
        private Guna2ComboBox fieldTipoMovimiento;
        private TableLayoutPanel layoutTipoMovimiento;
        private Guna2Button btnAdicionarTipoMovimiento;
    }
}