using Guna.UI2.WinForms;

using System.ComponentModel;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto {
    partial class VistaGestionProductos {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaGestionProductos));
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
            layoutVista = new TableLayoutPanel();
            layoutSeparadores = new TableLayoutPanel();
            separador2 = new Guna2Separator();
            separador1 = new Guna2Separator();
            layoutHerramientas = new TableLayoutPanel();
            fieldNombreAlmacen = new Guna2ComboBox();
            fieldDatoBusqueda = new Guna2TextBox();
            fieldCriterioBusqueda = new Guna2ComboBox();
            layoutTituloHerramientas = new TableLayoutPanel();
            fieldTituloFiltroAlmacen = new Label();
            fieldTituloFiltrosBusqueda = new Label();
            panelBotonesGestion = new Panel();
            btnRegistrar = new Guna2Button();
            layoutControlesTabla = new TableLayoutPanel();
            layoutValorBrutoInversion = new TableLayoutPanel();
            label1 = new Label();
            fieldValorBrutoInversion = new Label();
            fieldTituloValorBrutoInversion = new Label();
            btnPaginaAnterior = new Guna2Button();
            btnPrimeraPagina = new Guna2Button();
            btnPaginaSiguiente = new Guna2Button();
            btnUltimaPagina = new Guna2Button();
            btnSincronizarDatos = new Guna2Button();
            fieldPaginaActual = new Label();
            fieldPaginasTotales = new Label();
            layoutTitulo = new TableLayoutPanel();
            btnCerrar = new Guna2Button();
            fieldTitulo = new Label();
            fieldIcono = new PictureBox();
            fieldSubtitulo = new Label();
            layoutEncabezadosTabla = new TableLayoutPanel();
            fieldTituloAlmacen = new Label();
            fieldTituloId = new Label();
            fieldTituloDescripcion = new Label();
            fieldTituloNombre = new Label();
            fieldTituloPrecioAdquisicion = new Label();
            fieldTituloPrecioCesion = new Label();
            fieldTituloStock = new Label();
            fieldTituloCodigo = new Label();
            contenedorVistas = new Panel();
            layoutVista.SuspendLayout();
            layoutSeparadores.SuspendLayout();
            layoutHerramientas.SuspendLayout();
            layoutTituloHerramientas.SuspendLayout();
            panelBotonesGestion.SuspendLayout();
            layoutControlesTabla.SuspendLayout();
            layoutValorBrutoInversion.SuspendLayout();
            layoutTitulo.SuspendLayout();
            ((ISupportInitialize) fieldIcono).BeginInit();
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
            // layoutVista
            // 
            layoutVista.BackColor = Color.White;
            layoutVista.ColumnCount = 4;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.Controls.Add(layoutSeparadores, 2, 5);
            layoutVista.Controls.Add(layoutHerramientas, 2, 4);
            layoutVista.Controls.Add(layoutTituloHerramientas, 2, 3);
            layoutVista.Controls.Add(panelBotonesGestion, 2, 6);
            layoutVista.Controls.Add(layoutControlesTabla, 2, 11);
            layoutVista.Controls.Add(layoutTitulo, 2, 0);
            layoutVista.Controls.Add(fieldIcono, 1, 0);
            layoutVista.Controls.Add(fieldSubtitulo, 2, 1);
            layoutVista.Controls.Add(layoutEncabezadosTabla, 2, 8);
            layoutVista.Controls.Add(contenedorVistas, 2, 10);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(0, 0);
            layoutVista.Margin = new Padding(1);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 13;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.Size = new Size(1356, 608);
            layoutVista.TabIndex = 4;
            // 
            // layoutSeparadores
            // 
            layoutSeparadores.ColumnCount = 2;
            layoutSeparadores.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutSeparadores.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutSeparadores.Controls.Add(separador2, 1, 0);
            layoutSeparadores.Controls.Add(separador1, 0, 0);
            layoutSeparadores.Dock = DockStyle.Fill;
            layoutSeparadores.Location = new Point(50, 190);
            layoutSeparadores.Margin = new Padding(0);
            layoutSeparadores.Name = "layoutSeparadores";
            layoutSeparadores.RowCount = 1;
            layoutSeparadores.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutSeparadores.Size = new Size(1286, 20);
            layoutSeparadores.TabIndex = 40;
            // 
            // separador2
            // 
            separador2.Dock = DockStyle.Fill;
            separador2.FillColor = Color.Gainsboro;
            separador2.Location = new Point(223, 3);
            separador2.Name = "separador2";
            separador2.Size = new Size(1060, 14);
            separador2.TabIndex = 39;
            // 
            // separador1
            // 
            separador1.Dock = DockStyle.Fill;
            separador1.FillColor = Color.Gainsboro;
            separador1.Location = new Point(3, 3);
            separador1.Name = "separador1";
            separador1.Size = new Size(214, 14);
            separador1.TabIndex = 38;
            // 
            // layoutHerramientas
            // 
            layoutHerramientas.ColumnCount = 4;
            layoutHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            layoutHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 330F));
            layoutHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutHerramientas.Controls.Add(fieldNombreAlmacen, 0, 0);
            layoutHerramientas.Controls.Add(fieldDatoBusqueda, 2, 0);
            layoutHerramientas.Controls.Add(fieldCriterioBusqueda, 1, 0);
            layoutHerramientas.Dock = DockStyle.Fill;
            layoutHerramientas.Location = new Point(50, 145);
            layoutHerramientas.Margin = new Padding(0);
            layoutHerramientas.Name = "layoutHerramientas";
            layoutHerramientas.RowCount = 1;
            layoutHerramientas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutHerramientas.Size = new Size(1286, 45);
            layoutHerramientas.TabIndex = 39;
            // 
            // fieldNombreAlmacen
            // 
            fieldNombreAlmacen.Animated = true;
            fieldNombreAlmacen.BackColor = Color.Transparent;
            fieldNombreAlmacen.BorderColor = Color.Gainsboro;
            fieldNombreAlmacen.BorderRadius = 16;
            fieldNombreAlmacen.CustomizableEdges = customizableEdges1;
            fieldNombreAlmacen.Dock = DockStyle.Fill;
            fieldNombreAlmacen.DrawMode = DrawMode.OwnerDrawFixed;
            fieldNombreAlmacen.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldNombreAlmacen.FocusedColor = Color.Gainsboro;
            fieldNombreAlmacen.FocusedState.BorderColor = Color.Gainsboro;
            fieldNombreAlmacen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreAlmacen.ForeColor = Color.Black;
            fieldNombreAlmacen.ItemHeight = 29;
            fieldNombreAlmacen.Location = new Point(5, 5);
            fieldNombreAlmacen.Margin = new Padding(5);
            fieldNombreAlmacen.Name = "fieldNombreAlmacen";
            fieldNombreAlmacen.ShadowDecoration.CustomizableEdges = customizableEdges2;
            fieldNombreAlmacen.Size = new Size(210, 35);
            fieldNombreAlmacen.TabIndex = 28;
            fieldNombreAlmacen.TextOffset = new Point(10, 0);
            // 
            // fieldDatoBusqueda
            // 
            fieldDatoBusqueda.Animated = true;
            fieldDatoBusqueda.BackColor = Color.FromArgb(  254,   254,   253);
            fieldDatoBusqueda.BorderColor = Color.Gainsboro;
            fieldDatoBusqueda.BorderRadius = 18;
            fieldDatoBusqueda.Cursor = Cursors.IBeam;
            fieldDatoBusqueda.CustomizableEdges = customizableEdges3;
            fieldDatoBusqueda.DefaultText = "";
            fieldDatoBusqueda.DisabledState.BorderColor = Color.White;
            fieldDatoBusqueda.DisabledState.ForeColor = Color.DimGray;
            fieldDatoBusqueda.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldDatoBusqueda.Dock = DockStyle.Fill;
            fieldDatoBusqueda.FocusedState.BorderColor = Color.SandyBrown;
            fieldDatoBusqueda.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldDatoBusqueda.ForeColor = Color.Black;
            fieldDatoBusqueda.HoverState.BorderColor = Color.SandyBrown;
            fieldDatoBusqueda.IconLeft = (Image) resources.GetObject("fieldDatoBusqueda.IconLeft");
            fieldDatoBusqueda.IconLeftOffset = new Point(10, 1);
            fieldDatoBusqueda.IconRightOffset = new Point(10, 0);
            fieldDatoBusqueda.Location = new Point(525, 5);
            fieldDatoBusqueda.Margin = new Padding(5);
            fieldDatoBusqueda.Name = "fieldDatoBusqueda";
            fieldDatoBusqueda.PasswordChar = '\0';
            fieldDatoBusqueda.PlaceholderForeColor = Color.DimGray;
            fieldDatoBusqueda.PlaceholderText = "Datos complementarios de búsqueda";
            fieldDatoBusqueda.SelectedText = "";
            fieldDatoBusqueda.ShadowDecoration.CustomizableEdges = customizableEdges4;
            fieldDatoBusqueda.Size = new Size(320, 35);
            fieldDatoBusqueda.TabIndex = 9;
            fieldDatoBusqueda.TextOffset = new Point(5, 0);
            fieldDatoBusqueda.Visible = false;
            // 
            // fieldCriterioBusqueda
            // 
            fieldCriterioBusqueda.Animated = true;
            fieldCriterioBusqueda.BackColor = Color.Transparent;
            fieldCriterioBusqueda.BorderColor = Color.Gainsboro;
            fieldCriterioBusqueda.BorderRadius = 16;
            fieldCriterioBusqueda.CustomizableEdges = customizableEdges5;
            fieldCriterioBusqueda.Dock = DockStyle.Fill;
            fieldCriterioBusqueda.DrawMode = DrawMode.OwnerDrawFixed;
            fieldCriterioBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldCriterioBusqueda.FocusedColor = Color.Gainsboro;
            fieldCriterioBusqueda.FocusedState.BorderColor = Color.Gainsboro;
            fieldCriterioBusqueda.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldCriterioBusqueda.ForeColor = Color.Black;
            fieldCriterioBusqueda.ItemHeight = 29;
            fieldCriterioBusqueda.Location = new Point(225, 5);
            fieldCriterioBusqueda.Margin = new Padding(5);
            fieldCriterioBusqueda.Name = "fieldCriterioBusqueda";
            fieldCriterioBusqueda.ShadowDecoration.CustomizableEdges = customizableEdges6;
            fieldCriterioBusqueda.Size = new Size(290, 35);
            fieldCriterioBusqueda.TabIndex = 27;
            fieldCriterioBusqueda.TextOffset = new Point(10, 0);
            // 
            // layoutTituloHerramientas
            // 
            layoutTituloHerramientas.ColumnCount = 4;
            layoutTituloHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutTituloHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            layoutTituloHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 330F));
            layoutTituloHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutTituloHerramientas.Controls.Add(fieldTituloFiltroAlmacen, 0, 0);
            layoutTituloHerramientas.Controls.Add(fieldTituloFiltrosBusqueda, 1, 0);
            layoutTituloHerramientas.Dock = DockStyle.Fill;
            layoutTituloHerramientas.Location = new Point(50, 110);
            layoutTituloHerramientas.Margin = new Padding(0);
            layoutTituloHerramientas.Name = "layoutTituloHerramientas";
            layoutTituloHerramientas.RowCount = 1;
            layoutTituloHerramientas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutTituloHerramientas.Size = new Size(1286, 35);
            layoutTituloHerramientas.TabIndex = 39;
            // 
            // fieldTituloFiltroAlmacen
            // 
            fieldTituloFiltroAlmacen.Dock = DockStyle.Fill;
            fieldTituloFiltroAlmacen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloFiltroAlmacen.ForeColor = Color.DimGray;
            fieldTituloFiltroAlmacen.Image = (Image) resources.GetObject("fieldTituloFiltroAlmacen.Image");
            fieldTituloFiltroAlmacen.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloFiltroAlmacen.ImeMode = ImeMode.NoControl;
            fieldTituloFiltroAlmacen.Location = new Point(15, 5);
            fieldTituloFiltroAlmacen.Margin = new Padding(15, 5, 3, 3);
            fieldTituloFiltroAlmacen.Name = "fieldTituloFiltroAlmacen";
            fieldTituloFiltroAlmacen.Size = new Size(202, 27);
            fieldTituloFiltroAlmacen.TabIndex = 25;
            fieldTituloFiltroAlmacen.Text = "      Almacén :";
            fieldTituloFiltroAlmacen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldTituloFiltrosBusqueda
            // 
            fieldTituloFiltrosBusqueda.Dock = DockStyle.Fill;
            fieldTituloFiltrosBusqueda.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloFiltrosBusqueda.ForeColor = Color.DimGray;
            fieldTituloFiltrosBusqueda.Image = (Image) resources.GetObject("fieldTituloFiltrosBusqueda.Image");
            fieldTituloFiltrosBusqueda.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloFiltrosBusqueda.ImeMode = ImeMode.NoControl;
            fieldTituloFiltrosBusqueda.Location = new Point(235, 5);
            fieldTituloFiltrosBusqueda.Margin = new Padding(15, 5, 3, 3);
            fieldTituloFiltrosBusqueda.Name = "fieldTituloFiltrosBusqueda";
            fieldTituloFiltrosBusqueda.Size = new Size(282, 27);
            fieldTituloFiltrosBusqueda.TabIndex = 24;
            fieldTituloFiltrosBusqueda.Text = "      Filtro de búsqueda :";
            fieldTituloFiltrosBusqueda.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelBotonesGestion
            // 
            panelBotonesGestion.Controls.Add(btnRegistrar);
            panelBotonesGestion.Dock = DockStyle.Fill;
            panelBotonesGestion.Location = new Point(50, 210);
            panelBotonesGestion.Margin = new Padding(0);
            panelBotonesGestion.Name = "panelBotonesGestion";
            panelBotonesGestion.Padding = new Padding(3);
            panelBotonesGestion.Size = new Size(1286, 45);
            panelBotonesGestion.TabIndex = 38;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Animated = true;
            btnRegistrar.BackColor = Color.White;
            btnRegistrar.BorderRadius = 18;
            btnRegistrar.CustomizableEdges = customizableEdges7;
            btnRegistrar.Dock = DockStyle.Left;
            btnRegistrar.FillColor = Color.PeachPuff;
            btnRegistrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrar.ForeColor = Color.Black;
            btnRegistrar.Image = (Image) resources.GetObject("btnRegistrar.Image");
            btnRegistrar.ImageOffset = new Point(-5, 0);
            btnRegistrar.Location = new Point(3, 3);
            btnRegistrar.Margin = new Padding(0);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnRegistrar.Size = new Size(320, 39);
            btnRegistrar.TabIndex = 7;
            btnRegistrar.Text = "Registrar un nuevo producto";
            // 
            // layoutControlesTabla
            // 
            layoutControlesTabla.BackColor = Color.WhiteSmoke;
            layoutControlesTabla.ColumnCount = 13;
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutControlesTabla.Controls.Add(layoutValorBrutoInversion, 12, 0);
            layoutControlesTabla.Controls.Add(btnPaginaAnterior, 1, 0);
            layoutControlesTabla.Controls.Add(btnPrimeraPagina, 0, 0);
            layoutControlesTabla.Controls.Add(btnPaginaSiguiente, 6, 0);
            layoutControlesTabla.Controls.Add(btnUltimaPagina, 7, 0);
            layoutControlesTabla.Controls.Add(btnSincronizarDatos, 9, 0);
            layoutControlesTabla.Controls.Add(fieldPaginaActual, 3, 0);
            layoutControlesTabla.Controls.Add(fieldPaginasTotales, 4, 0);
            layoutControlesTabla.Dock = DockStyle.Fill;
            layoutControlesTabla.Location = new Point(50, 553);
            layoutControlesTabla.Margin = new Padding(0);
            layoutControlesTabla.Name = "layoutControlesTabla";
            layoutControlesTabla.RowCount = 1;
            layoutControlesTabla.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutControlesTabla.Size = new Size(1286, 35);
            layoutControlesTabla.TabIndex = 17;
            // 
            // layoutValorBrutoInversion
            // 
            layoutValorBrutoInversion.ColumnCount = 3;
            layoutValorBrutoInversion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutValorBrutoInversion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            layoutValorBrutoInversion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutValorBrutoInversion.Controls.Add(label1, 0, 0);
            layoutValorBrutoInversion.Controls.Add(fieldValorBrutoInversion, 0, 0);
            layoutValorBrutoInversion.Controls.Add(fieldTituloValorBrutoInversion, 0, 0);
            layoutValorBrutoInversion.Dock = DockStyle.Right;
            layoutValorBrutoInversion.Location = new Point(884, 0);
            layoutValorBrutoInversion.Margin = new Padding(0);
            layoutValorBrutoInversion.Name = "layoutValorBrutoInversion";
            layoutValorBrutoInversion.RowCount = 1;
            layoutValorBrutoInversion.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutValorBrutoInversion.Size = new Size(402, 35);
            layoutValorBrutoInversion.TabIndex = 11;
            layoutValorBrutoInversion.Visible = false;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(385, 5);
            label1.Margin = new Padding(3, 5, 3, 3);
            label1.Name = "label1";
            label1.Size = new Size(14, 27);
            label1.TabIndex = 2;
            label1.Text = "$";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldValorBrutoInversion
            // 
            fieldValorBrutoInversion.Dock = DockStyle.Fill;
            fieldValorBrutoInversion.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldValorBrutoInversion.ForeColor = Color.Black;
            fieldValorBrutoInversion.ImageAlign = ContentAlignment.MiddleLeft;
            fieldValorBrutoInversion.ImeMode = ImeMode.NoControl;
            fieldValorBrutoInversion.Location = new Point(247, 5);
            fieldValorBrutoInversion.Margin = new Padding(15, 5, 3, 3);
            fieldValorBrutoInversion.Name = "fieldValorBrutoInversion";
            fieldValorBrutoInversion.Size = new Size(132, 27);
            fieldValorBrutoInversion.TabIndex = 1;
            fieldValorBrutoInversion.Text = "0";
            fieldValorBrutoInversion.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldTituloValorBrutoInversion
            // 
            fieldTituloValorBrutoInversion.Dock = DockStyle.Fill;
            fieldTituloValorBrutoInversion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloValorBrutoInversion.ForeColor = Color.DimGray;
            fieldTituloValorBrutoInversion.Image = (Image) resources.GetObject("fieldTituloValorBrutoInversion.Image");
            fieldTituloValorBrutoInversion.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloValorBrutoInversion.ImeMode = ImeMode.NoControl;
            fieldTituloValorBrutoInversion.Location = new Point(15, 5);
            fieldTituloValorBrutoInversion.Margin = new Padding(15, 5, 3, 3);
            fieldTituloValorBrutoInversion.Name = "fieldTituloValorBrutoInversion";
            fieldTituloValorBrutoInversion.Size = new Size(214, 27);
            fieldTituloValorBrutoInversion.TabIndex = 0;
            fieldTituloValorBrutoInversion.Text = "      Valor bruto de la inversión :";
            fieldTituloValorBrutoInversion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnPaginaAnterior
            // 
            btnPaginaAnterior.Animated = true;
            btnPaginaAnterior.BackColor = Color.WhiteSmoke;
            btnPaginaAnterior.CheckedState.BorderColor = Color.WhiteSmoke;
            btnPaginaAnterior.CheckedState.FillColor = Color.WhiteSmoke;
            btnPaginaAnterior.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnPaginaAnterior.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnPaginaAnterior.CustomImages.ImageSize = new Size(24, 24);
            btnPaginaAnterior.CustomizableEdges = customizableEdges9;
            btnPaginaAnterior.Dock = DockStyle.Fill;
            btnPaginaAnterior.FillColor = Color.WhiteSmoke;
            btnPaginaAnterior.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnPaginaAnterior.ForeColor = Color.White;
            btnPaginaAnterior.HoverState.BorderColor = Color.FromArgb(  245,   245,   245);
            btnPaginaAnterior.HoverState.FillColor = Color.WhiteSmoke;
            btnPaginaAnterior.ImageSize = new Size(24, 24);
            btnPaginaAnterior.Location = new Point(36, 1);
            btnPaginaAnterior.Margin = new Padding(1);
            btnPaginaAnterior.Name = "btnPaginaAnterior";
            btnPaginaAnterior.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnPaginaAnterior.Size = new Size(33, 33);
            btnPaginaAnterior.TabIndex = 1;
            // 
            // btnPrimeraPagina
            // 
            btnPrimeraPagina.Animated = true;
            btnPrimeraPagina.BackColor = Color.WhiteSmoke;
            btnPrimeraPagina.CheckedState.BorderColor = Color.WhiteSmoke;
            btnPrimeraPagina.CheckedState.FillColor = Color.WhiteSmoke;
            btnPrimeraPagina.CustomImages.Image = (Image) resources.GetObject("resource.Image1");
            btnPrimeraPagina.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnPrimeraPagina.CustomImages.ImageSize = new Size(24, 24);
            btnPrimeraPagina.CustomizableEdges = customizableEdges11;
            btnPrimeraPagina.Dock = DockStyle.Fill;
            btnPrimeraPagina.FillColor = Color.WhiteSmoke;
            btnPrimeraPagina.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrimeraPagina.ForeColor = Color.White;
            btnPrimeraPagina.HoverState.BorderColor = Color.FromArgb(  245,   245,   245);
            btnPrimeraPagina.HoverState.FillColor = Color.WhiteSmoke;
            btnPrimeraPagina.ImageSize = new Size(24, 24);
            btnPrimeraPagina.Location = new Point(1, 1);
            btnPrimeraPagina.Margin = new Padding(1);
            btnPrimeraPagina.Name = "btnPrimeraPagina";
            btnPrimeraPagina.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnPrimeraPagina.Size = new Size(33, 33);
            btnPrimeraPagina.TabIndex = 0;
            // 
            // btnPaginaSiguiente
            // 
            btnPaginaSiguiente.Animated = true;
            btnPaginaSiguiente.BackColor = Color.WhiteSmoke;
            btnPaginaSiguiente.CheckedState.BorderColor = Color.WhiteSmoke;
            btnPaginaSiguiente.CheckedState.FillColor = Color.WhiteSmoke;
            btnPaginaSiguiente.CustomImages.Image = (Image) resources.GetObject("resource.Image2");
            btnPaginaSiguiente.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnPaginaSiguiente.CustomImages.ImageSize = new Size(24, 24);
            btnPaginaSiguiente.CustomizableEdges = customizableEdges13;
            btnPaginaSiguiente.Dock = DockStyle.Fill;
            btnPaginaSiguiente.FillColor = Color.WhiteSmoke;
            btnPaginaSiguiente.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnPaginaSiguiente.ForeColor = Color.White;
            btnPaginaSiguiente.HoverState.BorderColor = Color.FromArgb(  245,   245,   245);
            btnPaginaSiguiente.HoverState.FillColor = Color.WhiteSmoke;
            btnPaginaSiguiente.ImageSize = new Size(24, 24);
            btnPaginaSiguiente.Location = new Point(311, 1);
            btnPaginaSiguiente.Margin = new Padding(1);
            btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            btnPaginaSiguiente.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnPaginaSiguiente.Size = new Size(33, 33);
            btnPaginaSiguiente.TabIndex = 2;
            // 
            // btnUltimaPagina
            // 
            btnUltimaPagina.Animated = true;
            btnUltimaPagina.BackColor = Color.WhiteSmoke;
            btnUltimaPagina.CheckedState.BorderColor = Color.WhiteSmoke;
            btnUltimaPagina.CheckedState.FillColor = Color.WhiteSmoke;
            btnUltimaPagina.CustomImages.Image = (Image) resources.GetObject("resource.Image3");
            btnUltimaPagina.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnUltimaPagina.CustomImages.ImageSize = new Size(24, 24);
            btnUltimaPagina.CustomizableEdges = customizableEdges15;
            btnUltimaPagina.Dock = DockStyle.Fill;
            btnUltimaPagina.FillColor = Color.WhiteSmoke;
            btnUltimaPagina.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnUltimaPagina.ForeColor = Color.White;
            btnUltimaPagina.HoverState.BorderColor = Color.FromArgb(  245,   245,   245);
            btnUltimaPagina.HoverState.FillColor = Color.WhiteSmoke;
            btnUltimaPagina.ImageSize = new Size(24, 24);
            btnUltimaPagina.Location = new Point(346, 1);
            btnUltimaPagina.Margin = new Padding(1);
            btnUltimaPagina.Name = "btnUltimaPagina";
            btnUltimaPagina.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnUltimaPagina.Size = new Size(33, 33);
            btnUltimaPagina.TabIndex = 3;
            // 
            // btnSincronizarDatos
            // 
            btnSincronizarDatos.Animated = true;
            btnSincronizarDatos.BackColor = Color.WhiteSmoke;
            btnSincronizarDatos.CheckedState.BorderColor = Color.WhiteSmoke;
            btnSincronizarDatos.CheckedState.FillColor = Color.WhiteSmoke;
            btnSincronizarDatos.CustomImages.Image = (Image) resources.GetObject("resource.Image4");
            btnSincronizarDatos.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnSincronizarDatos.CustomImages.ImageSize = new Size(24, 24);
            btnSincronizarDatos.CustomizableEdges = customizableEdges17;
            btnSincronizarDatos.Dock = DockStyle.Fill;
            btnSincronizarDatos.FillColor = Color.WhiteSmoke;
            btnSincronizarDatos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSincronizarDatos.ForeColor = Color.White;
            btnSincronizarDatos.HoverState.BorderColor = Color.FromArgb(  245,   245,   245);
            btnSincronizarDatos.HoverState.FillColor = Color.WhiteSmoke;
            btnSincronizarDatos.ImageSize = new Size(24, 24);
            btnSincronizarDatos.Location = new Point(391, 1);
            btnSincronizarDatos.Margin = new Padding(1);
            btnSincronizarDatos.Name = "btnSincronizarDatos";
            btnSincronizarDatos.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnSincronizarDatos.Size = new Size(33, 33);
            btnSincronizarDatos.TabIndex = 4;
            // 
            // fieldPaginaActual
            // 
            fieldPaginaActual.Dock = DockStyle.Fill;
            fieldPaginaActual.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldPaginaActual.ForeColor = Color.Black;
            fieldPaginaActual.ImeMode = ImeMode.NoControl;
            fieldPaginaActual.Location = new Point(81, 1);
            fieldPaginaActual.Margin = new Padding(1, 1, 0, 1);
            fieldPaginaActual.Name = "fieldPaginaActual";
            fieldPaginaActual.Size = new Size(119, 33);
            fieldPaginaActual.TabIndex = 5;
            fieldPaginaActual.Text = "Página 1";
            fieldPaginaActual.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldPaginasTotales
            // 
            fieldPaginasTotales.Dock = DockStyle.Fill;
            fieldPaginasTotales.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldPaginasTotales.ForeColor = Color.Black;
            fieldPaginasTotales.ImeMode = ImeMode.NoControl;
            fieldPaginasTotales.Location = new Point(200, 1);
            fieldPaginasTotales.Margin = new Padding(0, 1, 1, 1);
            fieldPaginasTotales.Name = "fieldPaginasTotales";
            fieldPaginasTotales.Size = new Size(99, 33);
            fieldPaginasTotales.TabIndex = 6;
            fieldPaginasTotales.Text = "de 1";
            fieldPaginasTotales.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutTitulo
            // 
            layoutTitulo.ColumnCount = 2;
            layoutTitulo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutTitulo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutTitulo.Controls.Add(btnCerrar, 1, 0);
            layoutTitulo.Controls.Add(fieldTitulo, 0, 0);
            layoutTitulo.Dock = DockStyle.Fill;
            layoutTitulo.Location = new Point(50, 0);
            layoutTitulo.Margin = new Padding(0);
            layoutTitulo.Name = "layoutTitulo";
            layoutTitulo.RowCount = 1;
            layoutTitulo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutTitulo.Size = new Size(1286, 45);
            layoutTitulo.TabIndex = 14;
            // 
            // btnCerrar
            // 
            btnCerrar.Animated = true;
            btnCerrar.AutoRoundedCorners = true;
            btnCerrar.BorderColor = Color.Gray;
            btnCerrar.BorderRadius = 18;
            btnCerrar.CustomizableEdges = customizableEdges19;
            btnCerrar.Dock = DockStyle.Fill;
            btnCerrar.FillColor = Color.White;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.Black;
            btnCerrar.HoverState.FillColor = Color.White;
            btnCerrar.Image = (Image) resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(1239, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnCerrar.Size = new Size(44, 39);
            btnCerrar.TabIndex = 8;
            // 
            // fieldTitulo
            // 
            fieldTitulo.Dock = DockStyle.Fill;
            fieldTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTitulo.ForeColor = Color.Black;
            fieldTitulo.ImeMode = ImeMode.NoControl;
            fieldTitulo.Location = new Point(3, 0);
            fieldTitulo.Name = "fieldTitulo";
            fieldTitulo.Size = new Size(1230, 45);
            fieldTitulo.TabIndex = 3;
            fieldTitulo.Text = "Gestión de productos";
            fieldTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldIcono
            // 
            fieldIcono.BackgroundImage = (Image) resources.GetObject("fieldIcono.BackgroundImage");
            fieldIcono.BackgroundImageLayout = ImageLayout.Center;
            fieldIcono.Dock = DockStyle.Fill;
            fieldIcono.Location = new Point(20, 6);
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
            fieldSubtitulo.ForeColor = Color.Gray;
            fieldSubtitulo.ImeMode = ImeMode.NoControl;
            fieldSubtitulo.Location = new Point(55, 50);
            fieldSubtitulo.Margin = new Padding(5, 5, 1, 1);
            fieldSubtitulo.Name = "fieldSubtitulo";
            fieldSubtitulo.Size = new Size(1280, 39);
            fieldSubtitulo.TabIndex = 2;
            fieldSubtitulo.Text = "Registro, edición, eliminación, búsqueda de productos.";
            // 
            // layoutEncabezadosTabla
            // 
            layoutEncabezadosTabla.BackColor = Color.WhiteSmoke;
            layoutEncabezadosTabla.ColumnCount = 13;
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 230F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.Controls.Add(fieldTituloAlmacen, 0, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloId, 0, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloDescripcion, 4, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloNombre, 3, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloPrecioAdquisicion, 5, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloPrecioCesion, 6, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloStock, 7, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloCodigo, 2, 0);
            layoutEncabezadosTabla.Dock = DockStyle.Fill;
            layoutEncabezadosTabla.Location = new Point(51, 266);
            layoutEncabezadosTabla.Margin = new Padding(1);
            layoutEncabezadosTabla.Name = "layoutEncabezadosTabla";
            layoutEncabezadosTabla.RowCount = 1;
            layoutEncabezadosTabla.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.Size = new Size(1284, 58);
            layoutEncabezadosTabla.TabIndex = 11;
            // 
            // fieldTituloAlmacen
            // 
            fieldTituloAlmacen.Dock = DockStyle.Fill;
            fieldTituloAlmacen.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloAlmacen.ForeColor = Color.Black;
            fieldTituloAlmacen.ImeMode = ImeMode.NoControl;
            fieldTituloAlmacen.Location = new Point(61, 1);
            fieldTituloAlmacen.Margin = new Padding(1);
            fieldTituloAlmacen.Name = "fieldTituloAlmacen";
            fieldTituloAlmacen.Size = new Size(118, 56);
            fieldTituloAlmacen.TabIndex = 20;
            fieldTituloAlmacen.Text = "Almacén";
            fieldTituloAlmacen.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloId
            // 
            fieldTituloId.Dock = DockStyle.Fill;
            fieldTituloId.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloId.ForeColor = Color.Black;
            fieldTituloId.ImeMode = ImeMode.NoControl;
            fieldTituloId.Location = new Point(1, 1);
            fieldTituloId.Margin = new Padding(1);
            fieldTituloId.Name = "fieldTituloId";
            fieldTituloId.Size = new Size(58, 56);
            fieldTituloId.TabIndex = 14;
            fieldTituloId.Text = "Id";
            fieldTituloId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloDescripcion
            // 
            fieldTituloDescripcion.Dock = DockStyle.Fill;
            fieldTituloDescripcion.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloDescripcion.ForeColor = Color.Black;
            fieldTituloDescripcion.ImeMode = ImeMode.NoControl;
            fieldTituloDescripcion.Location = new Point(521, 1);
            fieldTituloDescripcion.Margin = new Padding(1);
            fieldTituloDescripcion.Name = "fieldTituloDescripcion";
            fieldTituloDescripcion.Size = new Size(228, 56);
            fieldTituloDescripcion.TabIndex = 16;
            fieldTituloDescripcion.Text = "Descripción";
            fieldTituloDescripcion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloNombre
            // 
            fieldTituloNombre.Dock = DockStyle.Fill;
            fieldTituloNombre.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloNombre.ForeColor = Color.Black;
            fieldTituloNombre.ImeMode = ImeMode.NoControl;
            fieldTituloNombre.Location = new Point(301, 1);
            fieldTituloNombre.Margin = new Padding(1);
            fieldTituloNombre.Name = "fieldTituloNombre";
            fieldTituloNombre.Size = new Size(218, 56);
            fieldTituloNombre.TabIndex = 4;
            fieldTituloNombre.Text = "Nombre";
            fieldTituloNombre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloPrecioAdquisicion
            // 
            fieldTituloPrecioAdquisicion.Dock = DockStyle.Fill;
            fieldTituloPrecioAdquisicion.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloPrecioAdquisicion.ForeColor = Color.Black;
            fieldTituloPrecioAdquisicion.ImeMode = ImeMode.NoControl;
            fieldTituloPrecioAdquisicion.Location = new Point(751, 1);
            fieldTituloPrecioAdquisicion.Margin = new Padding(1);
            fieldTituloPrecioAdquisicion.Name = "fieldTituloPrecioAdquisicion";
            fieldTituloPrecioAdquisicion.Size = new Size(108, 56);
            fieldTituloPrecioAdquisicion.TabIndex = 17;
            fieldTituloPrecioAdquisicion.Text = "Precio de compra base";
            fieldTituloPrecioAdquisicion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloPrecioCesion
            // 
            fieldTituloPrecioCesion.Dock = DockStyle.Fill;
            fieldTituloPrecioCesion.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloPrecioCesion.ForeColor = Color.Black;
            fieldTituloPrecioCesion.ImeMode = ImeMode.NoControl;
            fieldTituloPrecioCesion.Location = new Point(861, 1);
            fieldTituloPrecioCesion.Margin = new Padding(1);
            fieldTituloPrecioCesion.Name = "fieldTituloPrecioCesion";
            fieldTituloPrecioCesion.Size = new Size(108, 56);
            fieldTituloPrecioCesion.TabIndex = 18;
            fieldTituloPrecioCesion.Text = "Precio de venta base";
            fieldTituloPrecioCesion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloStock
            // 
            fieldTituloStock.Dock = DockStyle.Fill;
            fieldTituloStock.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloStock.ForeColor = Color.Black;
            fieldTituloStock.ImeMode = ImeMode.NoControl;
            fieldTituloStock.Location = new Point(971, 1);
            fieldTituloStock.Margin = new Padding(1);
            fieldTituloStock.Name = "fieldTituloStock";
            fieldTituloStock.Size = new Size(108, 56);
            fieldTituloStock.TabIndex = 19;
            fieldTituloStock.Text = "Stock";
            fieldTituloStock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloCodigo
            // 
            fieldTituloCodigo.Dock = DockStyle.Fill;
            fieldTituloCodigo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloCodigo.ForeColor = Color.Black;
            fieldTituloCodigo.ImeMode = ImeMode.NoControl;
            fieldTituloCodigo.Location = new Point(181, 1);
            fieldTituloCodigo.Margin = new Padding(1);
            fieldTituloCodigo.Name = "fieldTituloCodigo";
            fieldTituloCodigo.Size = new Size(118, 56);
            fieldTituloCodigo.TabIndex = 15;
            fieldTituloCodigo.Text = "Código";
            fieldTituloCodigo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contenedorVistas
            // 
            contenedorVistas.Dock = DockStyle.Fill;
            contenedorVistas.Location = new Point(50, 335);
            contenedorVistas.Margin = new Padding(0);
            contenedorVistas.Name = "contenedorVistas";
            contenedorVistas.Size = new Size(1286, 218);
            contenedorVistas.TabIndex = 13;
            // 
            // VistaGestionProductos
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1356, 608);
            Controls.Add(layoutVista);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaGestionProductos";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistGestionProveedor";
            layoutVista.ResumeLayout(false);
            layoutSeparadores.ResumeLayout(false);
            layoutHerramientas.ResumeLayout(false);
            layoutTituloHerramientas.ResumeLayout(false);
            panelBotonesGestion.ResumeLayout(false);
            layoutControlesTabla.ResumeLayout(false);
            layoutValorBrutoInversion.ResumeLayout(false);
            layoutTitulo.ResumeLayout(false);
            ((ISupportInitialize) fieldIcono).EndInit();
            layoutEncabezadosTabla.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutVista;
        private TableLayoutPanel layoutTitulo;
        private Guna2Button btnCerrar;
        private Label fieldTitulo;
        private TableLayoutPanel layoutDistribucionMenu;
        private FlowLayoutPanel layoutBotones;
        private Guna2Button btnRegistrar;
        private PictureBox fieldIcono;
        private Label fieldSubtitulo;
        private TableLayoutPanel layoutEncabezadosTabla;
        private Label fieldTituloCodigo;
        private Label fieldTituloId;
        private Panel contenedorVistas;
        private Label fieldTituloNombre;
        private TableLayoutPanel layoutControlesTabla;
        private Guna2Button btnPaginaAnterior;
        private Guna2Button btnPrimeraPagina;
        private Guna2Button btnPaginaSiguiente;
        private Guna2Button btnUltimaPagina;
        private Guna2Button btnSincronizarDatos;
        private Label fieldPaginaActual;
        private Label fieldPaginasTotales;
        private Label fieldTituloDescripcion;
        private Label fieldTituloPrecioAdquisicion;
        private Label fieldTituloPrecioCesion;
        private Label fieldTituloStock;
        private Label fieldTituloAlmacen;
        private Panel panelBotonesGestion;
        private TableLayoutPanel layoutTituloHerramientas;
        private Label fieldTituloFiltroAlmacen;
        private Label fieldTituloFiltrosBusqueda;
        private TableLayoutPanel layoutHerramientas;
        private Guna2ComboBox fieldNombreAlmacen;
        private Guna2TextBox fieldDatoBusqueda;
        private Guna2ComboBox fieldCriterioBusqueda;
        private TableLayoutPanel layoutSeparadores;
        private Guna2Separator separador2;
        private Guna2Separator separador1;
        private TableLayoutPanel layoutValorBrutoInversion;
        private Label label1;
        private Label fieldValorBrutoInversion;
        private Label fieldTituloValorBrutoInversion;
    }
}