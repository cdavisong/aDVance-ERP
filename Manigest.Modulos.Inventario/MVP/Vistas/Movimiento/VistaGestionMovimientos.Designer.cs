using Guna.UI2.WinForms;

using System.ComponentModel;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Movimiento {
    partial class VistaGestionMovimientos {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaGestionMovimientos));
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutVista = new TableLayoutPanel();
            layoutAlmacenReportes = new TableLayoutPanel();
            layoutOpcionesReporte = new TableLayoutPanel();
            btnImprimirReporte = new Guna2Button();
            fieldFechaFinal = new Guna2DateTimePicker();
            fieldFormatoReporte = new Guna2ComboBox();
            fieldFechaInicio = new Guna2DateTimePicker();
            fieldNombreAlmacenOrigen = new Guna2ComboBox();
            layoutEncabezadosTabla = new TableLayoutPanel();
            fieldTituloNombreArticulo = new Label();
            fieldTituloFecha = new Label();
            fieldTituloMotivo = new Label();
            fieldTitulaCantidadMovida = new Label();
            fieldTituloAlmacenDestino = new Label();
            fieldTituloAlmacenOrigen = new Label();
            fieldTituloId = new Label();
            layoutTitulo = new TableLayoutPanel();
            btnCerrar = new Guna2Button();
            fieldTitulo = new Label();
            layoutDistribucionMenu = new TableLayoutPanel();
            fieldDatoBusqueda = new Guna2TextBox();
            layoutBotones = new FlowLayoutPanel();
            btnRegistrarProveedor = new Guna2Button();
            fieldIcono = new PictureBox();
            fieldSubtitulo = new Label();
            contenedorVistas = new Panel();
            layoutControlesTabla = new TableLayoutPanel();
            btnPaginaAnterior = new Guna2Button();
            btnPrimeraPagina = new Guna2Button();
            btnPaginaSiguiente = new Guna2Button();
            btnUltimaPagina = new Guna2Button();
            btnSincronizarDatos = new Guna2Button();
            fieldPaginaActual = new Label();
            fieldPaginasTotales = new Label();
            layoutTituloAlmacenReporte = new TableLayoutPanel();
            fieldTituloNombreAlmacenOrigen = new Label();
            fieldTituloNombreAlmacenDestino = new Label();
            layoutVista.SuspendLayout();
            layoutAlmacenReportes.SuspendLayout();
            layoutOpcionesReporte.SuspendLayout();
            layoutEncabezadosTabla.SuspendLayout();
            layoutTitulo.SuspendLayout();
            layoutDistribucionMenu.SuspendLayout();
            layoutBotones.SuspendLayout();
            ((ISupportInitialize) fieldIcono).BeginInit();
            layoutControlesTabla.SuspendLayout();
            layoutTituloAlmacenReporte.SuspendLayout();
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
            layoutVista.BackColor = Color.FromArgb(  248,   244,   242);
            layoutVista.ColumnCount = 4;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.Controls.Add(layoutAlmacenReportes, 2, 4);
            layoutVista.Controls.Add(layoutEncabezadosTabla, 2, 8);
            layoutVista.Controls.Add(layoutTitulo, 2, 0);
            layoutVista.Controls.Add(layoutDistribucionMenu, 2, 6);
            layoutVista.Controls.Add(fieldIcono, 1, 0);
            layoutVista.Controls.Add(fieldSubtitulo, 2, 1);
            layoutVista.Controls.Add(contenedorVistas, 2, 10);
            layoutVista.Controls.Add(layoutControlesTabla, 2, 11);
            layoutVista.Controls.Add(layoutTituloAlmacenReporte, 2, 3);
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
            // layoutAlmacenReportes
            // 
            layoutAlmacenReportes.ColumnCount = 2;
            layoutAlmacenReportes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            layoutAlmacenReportes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutAlmacenReportes.Controls.Add(layoutOpcionesReporte, 0, 0);
            layoutAlmacenReportes.Controls.Add(fieldNombreAlmacenOrigen, 0, 0);
            layoutAlmacenReportes.Dock = DockStyle.Fill;
            layoutAlmacenReportes.Location = new Point(50, 145);
            layoutAlmacenReportes.Margin = new Padding(0);
            layoutAlmacenReportes.Name = "layoutAlmacenReportes";
            layoutAlmacenReportes.RowCount = 1;
            layoutAlmacenReportes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutAlmacenReportes.Size = new Size(1286, 45);
            layoutAlmacenReportes.TabIndex = 33;
            // 
            // layoutOpcionesReporte
            // 
            layoutOpcionesReporte.ColumnCount = 5;
            layoutOpcionesReporte.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            layoutOpcionesReporte.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            layoutOpcionesReporte.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            layoutOpcionesReporte.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutOpcionesReporte.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutOpcionesReporte.Controls.Add(btnImprimirReporte, 4, 0);
            layoutOpcionesReporte.Controls.Add(fieldFechaFinal, 2, 0);
            layoutOpcionesReporte.Controls.Add(fieldFormatoReporte, 0, 0);
            layoutOpcionesReporte.Controls.Add(fieldFechaInicio, 1, 0);
            layoutOpcionesReporte.Dock = DockStyle.Fill;
            layoutOpcionesReporte.Location = new Point(320, 0);
            layoutOpcionesReporte.Margin = new Padding(0);
            layoutOpcionesReporte.Name = "layoutOpcionesReporte";
            layoutOpcionesReporte.RowCount = 1;
            layoutOpcionesReporte.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutOpcionesReporte.Size = new Size(966, 45);
            layoutOpcionesReporte.TabIndex = 27;
            // 
            // btnImprimirReporte
            // 
            btnImprimirReporte.Animated = true;
            btnImprimirReporte.BorderColor = Color.FromArgb(  217,   211,   204);
            btnImprimirReporte.BorderRadius = 16;
            btnImprimirReporte.BorderThickness = 1;
            btnImprimirReporte.CustomImages.HoveredImage = (Image) resources.GetObject("resource.HoveredImage");
            btnImprimirReporte.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnImprimirReporte.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnImprimirReporte.CustomizableEdges = customizableEdges1;
            btnImprimirReporte.Dock = DockStyle.Fill;
            btnImprimirReporte.FillColor = Color.FromArgb(  250,   250,   250);
            btnImprimirReporte.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnImprimirReporte.ForeColor = Color.White;
            btnImprimirReporte.HoverState.BorderColor = Color.FromArgb(  217,   211,   204);
            btnImprimirReporte.HoverState.FillColor = Color.FromArgb(  217,   211,   204);
            btnImprimirReporte.Location = new Point(929, 6);
            btnImprimirReporte.Margin = new Padding(3, 6, 3, 6);
            btnImprimirReporte.Name = "btnImprimirReporte";
            btnImprimirReporte.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnImprimirReporte.Size = new Size(34, 33);
            btnImprimirReporte.TabIndex = 10;
            // 
            // fieldFechaFinal
            // 
            fieldFechaFinal.Animated = true;
            fieldFechaFinal.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldFechaFinal.BorderRadius = 16;
            fieldFechaFinal.BorderThickness = 1;
            fieldFechaFinal.Checked = true;
            fieldFechaFinal.CheckedState.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldFechaFinal.CheckedState.FillColor = Color.FromArgb(  254,   254,   253);
            fieldFechaFinal.CheckedState.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldFechaFinal.CustomizableEdges = customizableEdges3;
            fieldFechaFinal.Dock = DockStyle.Fill;
            fieldFechaFinal.FillColor = Color.FromArgb(  254,   254,   253);
            fieldFechaFinal.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldFechaFinal.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldFechaFinal.Format = DateTimePickerFormat.Long;
            fieldFechaFinal.Location = new Point(555, 5);
            fieldFechaFinal.Margin = new Padding(5);
            fieldFechaFinal.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            fieldFechaFinal.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            fieldFechaFinal.Name = "fieldFechaFinal";
            fieldFechaFinal.ShadowDecoration.CustomizableEdges = customizableEdges4;
            fieldFechaFinal.Size = new Size(240, 35);
            fieldFechaFinal.TabIndex = 6;
            fieldFechaFinal.Value = new DateTime(2022, 11, 24, 0, 0, 0, 0);
            // 
            // fieldFormatoReporte
            // 
            fieldFormatoReporte.Animated = true;
            fieldFormatoReporte.BackColor = Color.Transparent;
            fieldFormatoReporte.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldFormatoReporte.BorderRadius = 16;
            fieldFormatoReporte.CustomizableEdges = customizableEdges5;
            fieldFormatoReporte.Dock = DockStyle.Fill;
            fieldFormatoReporte.DrawMode = DrawMode.OwnerDrawFixed;
            fieldFormatoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldFormatoReporte.FillColor = Color.FromArgb(  254,   254,   253);
            fieldFormatoReporte.FocusedColor = Color.FromArgb(  217,   211,   204);
            fieldFormatoReporte.FocusedState.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldFormatoReporte.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldFormatoReporte.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldFormatoReporte.ItemHeight = 28;
            fieldFormatoReporte.Items.AddRange(new object[] { "PDF" });
            fieldFormatoReporte.Location = new Point(5, 5);
            fieldFormatoReporte.Margin = new Padding(5);
            fieldFormatoReporte.Name = "fieldFormatoReporte";
            fieldFormatoReporte.ShadowDecoration.CustomizableEdges = customizableEdges6;
            fieldFormatoReporte.Size = new Size(290, 34);
            fieldFormatoReporte.StartIndex = 0;
            fieldFormatoReporte.TabIndex = 4;
            fieldFormatoReporte.TextOffset = new Point(5, 0);
            // 
            // fieldFechaInicio
            // 
            fieldFechaInicio.Animated = true;
            fieldFechaInicio.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldFechaInicio.BorderRadius = 16;
            fieldFechaInicio.BorderThickness = 1;
            fieldFechaInicio.Checked = true;
            fieldFechaInicio.CheckedState.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldFechaInicio.CheckedState.FillColor = Color.FromArgb(  254,   254,   253);
            fieldFechaInicio.CheckedState.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldFechaInicio.CustomizableEdges = customizableEdges7;
            fieldFechaInicio.Dock = DockStyle.Fill;
            fieldFechaInicio.FillColor = Color.FromArgb(  254,   254,   253);
            fieldFechaInicio.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldFechaInicio.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldFechaInicio.Format = DateTimePickerFormat.Long;
            fieldFechaInicio.Location = new Point(305, 5);
            fieldFechaInicio.Margin = new Padding(5);
            fieldFechaInicio.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            fieldFechaInicio.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            fieldFechaInicio.Name = "fieldFechaInicio";
            fieldFechaInicio.ShadowDecoration.CustomizableEdges = customizableEdges8;
            fieldFechaInicio.Size = new Size(240, 35);
            fieldFechaInicio.TabIndex = 5;
            fieldFechaInicio.Value = new DateTime(2022, 11, 24, 0, 0, 0, 0);
            // 
            // fieldNombreAlmacenOrigen
            // 
            fieldNombreAlmacenOrigen.Animated = true;
            fieldNombreAlmacenOrigen.BackColor = Color.Transparent;
            fieldNombreAlmacenOrigen.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldNombreAlmacenOrigen.BorderRadius = 16;
            fieldNombreAlmacenOrigen.CustomizableEdges = customizableEdges9;
            fieldNombreAlmacenOrigen.Dock = DockStyle.Fill;
            fieldNombreAlmacenOrigen.DrawMode = DrawMode.OwnerDrawFixed;
            fieldNombreAlmacenOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldNombreAlmacenOrigen.FillColor = Color.FromArgb(  254,   254,   253);
            fieldNombreAlmacenOrigen.FocusedColor = Color.FromArgb(  217,   211,   204);
            fieldNombreAlmacenOrigen.FocusedState.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldNombreAlmacenOrigen.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreAlmacenOrigen.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldNombreAlmacenOrigen.ItemHeight = 29;
            fieldNombreAlmacenOrigen.Location = new Point(5, 5);
            fieldNombreAlmacenOrigen.Margin = new Padding(5);
            fieldNombreAlmacenOrigen.Name = "fieldNombreAlmacenOrigen";
            fieldNombreAlmacenOrigen.ShadowDecoration.CustomizableEdges = customizableEdges10;
            fieldNombreAlmacenOrigen.Size = new Size(310, 35);
            fieldNombreAlmacenOrigen.TabIndex = 26;
            fieldNombreAlmacenOrigen.TextOffset = new Point(10, 0);
            // 
            // layoutEncabezadosTabla
            // 
            layoutEncabezadosTabla.BackColor = Color.FromArgb(  243,   243,   243);
            layoutEncabezadosTabla.ColumnCount = 12;
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.Controls.Add(fieldTituloNombreArticulo, 0, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloFecha, 7, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloMotivo, 6, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTitulaCantidadMovida, 5, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloAlmacenDestino, 4, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloAlmacenOrigen, 2, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloId, 0, 0);
            layoutEncabezadosTabla.Dock = DockStyle.Fill;
            layoutEncabezadosTabla.Location = new Point(50, 265);
            layoutEncabezadosTabla.Margin = new Padding(0, 0, 0, 2);
            layoutEncabezadosTabla.Name = "layoutEncabezadosTabla";
            layoutEncabezadosTabla.RowCount = 1;
            layoutEncabezadosTabla.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.Size = new Size(1286, 58);
            layoutEncabezadosTabla.TabIndex = 19;
            // 
            // fieldTituloNombreArticulo
            // 
            fieldTituloNombreArticulo.Dock = DockStyle.Fill;
            fieldTituloNombreArticulo.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloNombreArticulo.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldTituloNombreArticulo.ImeMode = ImeMode.NoControl;
            fieldTituloNombreArticulo.Location = new Point(61, 1);
            fieldTituloNombreArticulo.Margin = new Padding(1);
            fieldTituloNombreArticulo.Name = "fieldTituloNombreArticulo";
            fieldTituloNombreArticulo.Size = new Size(218, 56);
            fieldTituloNombreArticulo.TabIndex = 16;
            fieldTituloNombreArticulo.Text = "Artículo";
            fieldTituloNombreArticulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloFecha
            // 
            fieldTituloFecha.Dock = DockStyle.Fill;
            fieldTituloFecha.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloFecha.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldTituloFecha.ImeMode = ImeMode.NoControl;
            fieldTituloFecha.Location = new Point(891, 1);
            fieldTituloFecha.Margin = new Padding(1);
            fieldTituloFecha.Name = "fieldTituloFecha";
            fieldTituloFecha.Size = new Size(118, 56);
            fieldTituloFecha.TabIndex = 15;
            fieldTituloFecha.Text = "Fecha";
            fieldTituloFecha.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloMotivo
            // 
            fieldTituloMotivo.Dock = DockStyle.Fill;
            fieldTituloMotivo.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloMotivo.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldTituloMotivo.ImeMode = ImeMode.NoControl;
            fieldTituloMotivo.Location = new Point(671, 1);
            fieldTituloMotivo.Margin = new Padding(1);
            fieldTituloMotivo.Name = "fieldTituloMotivo";
            fieldTituloMotivo.Size = new Size(218, 56);
            fieldTituloMotivo.TabIndex = 15;
            fieldTituloMotivo.Text = "Motivo";
            fieldTituloMotivo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTitulaCantidadMovida
            // 
            fieldTitulaCantidadMovida.Dock = DockStyle.Fill;
            fieldTitulaCantidadMovida.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTitulaCantidadMovida.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldTitulaCantidadMovida.ImeMode = ImeMode.NoControl;
            fieldTitulaCantidadMovida.Location = new Point(561, 1);
            fieldTitulaCantidadMovida.Margin = new Padding(1);
            fieldTitulaCantidadMovida.Name = "fieldTitulaCantidadMovida";
            fieldTitulaCantidadMovida.Size = new Size(108, 56);
            fieldTitulaCantidadMovida.TabIndex = 15;
            fieldTitulaCantidadMovida.Text = "Cantidad\r\nmovida";
            fieldTitulaCantidadMovida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloAlmacenDestino
            // 
            fieldTituloAlmacenDestino.Dock = DockStyle.Fill;
            fieldTituloAlmacenDestino.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloAlmacenDestino.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldTituloAlmacenDestino.ImeMode = ImeMode.NoControl;
            fieldTituloAlmacenDestino.Location = new Point(441, 1);
            fieldTituloAlmacenDestino.Margin = new Padding(1);
            fieldTituloAlmacenDestino.Name = "fieldTituloAlmacenDestino";
            fieldTituloAlmacenDestino.Size = new Size(118, 56);
            fieldTituloAlmacenDestino.TabIndex = 15;
            fieldTituloAlmacenDestino.Text = "Almacén destino";
            fieldTituloAlmacenDestino.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloAlmacenOrigen
            // 
            fieldTituloAlmacenOrigen.Dock = DockStyle.Fill;
            fieldTituloAlmacenOrigen.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloAlmacenOrigen.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldTituloAlmacenOrigen.ImeMode = ImeMode.NoControl;
            fieldTituloAlmacenOrigen.Location = new Point(281, 1);
            fieldTituloAlmacenOrigen.Margin = new Padding(1);
            fieldTituloAlmacenOrigen.Name = "fieldTituloAlmacenOrigen";
            fieldTituloAlmacenOrigen.Size = new Size(118, 56);
            fieldTituloAlmacenOrigen.TabIndex = 15;
            fieldTituloAlmacenOrigen.Text = "Almacén origen";
            fieldTituloAlmacenOrigen.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloId
            // 
            fieldTituloId.Dock = DockStyle.Fill;
            fieldTituloId.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloId.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldTituloId.ImeMode = ImeMode.NoControl;
            fieldTituloId.Location = new Point(1, 1);
            fieldTituloId.Margin = new Padding(1);
            fieldTituloId.Name = "fieldTituloId";
            fieldTituloId.Size = new Size(58, 56);
            fieldTituloId.TabIndex = 14;
            fieldTituloId.Text = "Id";
            fieldTituloId.TextAlign = ContentAlignment.MiddleCenter;
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
            btnCerrar.CustomizableEdges = customizableEdges11;
            btnCerrar.Dock = DockStyle.Fill;
            btnCerrar.FillColor = Color.FromArgb(  248,   244,   242);
            btnCerrar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.Black;
            btnCerrar.HoverState.FillColor = Color.FromArgb(  250,   250,   250);
            btnCerrar.Image = (Image) resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(1239, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnCerrar.Size = new Size(44, 39);
            btnCerrar.TabIndex = 8;
            // 
            // fieldTitulo
            // 
            fieldTitulo.Dock = DockStyle.Fill;
            fieldTitulo.Font = new Font("Microsoft PhagsPa", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTitulo.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldTitulo.ImeMode = ImeMode.NoControl;
            fieldTitulo.Location = new Point(3, 0);
            fieldTitulo.Name = "fieldTitulo";
            fieldTitulo.Size = new Size(1230, 45);
            fieldTitulo.TabIndex = 3;
            fieldTitulo.Text = "Gestión de movimientos";
            fieldTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutDistribucionMenu
            // 
            layoutDistribucionMenu.ColumnCount = 2;
            layoutDistribucionMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutDistribucionMenu.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 356F));
            layoutDistribucionMenu.Controls.Add(fieldDatoBusqueda, 1, 0);
            layoutDistribucionMenu.Controls.Add(layoutBotones, 0, 0);
            layoutDistribucionMenu.Dock = DockStyle.Fill;
            layoutDistribucionMenu.Location = new Point(50, 210);
            layoutDistribucionMenu.Margin = new Padding(0);
            layoutDistribucionMenu.Name = "layoutDistribucionMenu";
            layoutDistribucionMenu.RowCount = 1;
            layoutDistribucionMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutDistribucionMenu.Size = new Size(1286, 45);
            layoutDistribucionMenu.TabIndex = 4;
            // 
            // fieldDatoBusqueda
            // 
            fieldDatoBusqueda.Animated = true;
            fieldDatoBusqueda.BackColor = Color.FromArgb(  254,   254,   253);
            fieldDatoBusqueda.BorderColor = Color.FromArgb(  217,   211,   204);
            fieldDatoBusqueda.BorderRadius = 18;
            fieldDatoBusqueda.Cursor = Cursors.IBeam;
            fieldDatoBusqueda.CustomizableEdges = customizableEdges13;
            fieldDatoBusqueda.DefaultText = "";
            fieldDatoBusqueda.DisabledState.BorderColor = Color.FromArgb(  208,   208,   208);
            fieldDatoBusqueda.DisabledState.FillColor = Color.FromArgb(  226,   226,   226);
            fieldDatoBusqueda.DisabledState.ForeColor = Color.FromArgb(  138,   138,   138);
            fieldDatoBusqueda.DisabledState.PlaceholderForeColor = Color.FromArgb(  138,   138,   138);
            fieldDatoBusqueda.Dock = DockStyle.Fill;
            fieldDatoBusqueda.FillColor = Color.FromArgb(  254,   254,   253);
            fieldDatoBusqueda.FocusedState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldDatoBusqueda.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldDatoBusqueda.ForeColor = Color.FromArgb(  28,   28,   28);
            fieldDatoBusqueda.HoverState.BorderColor = Color.FromArgb(  2,   52,   107);
            fieldDatoBusqueda.IconLeft = (Image) resources.GetObject("fieldDatoBusqueda.IconLeft");
            fieldDatoBusqueda.IconLeftOffset = new Point(10, 1);
            fieldDatoBusqueda.IconRightOffset = new Point(10, 0);
            fieldDatoBusqueda.Location = new Point(933, 5);
            fieldDatoBusqueda.Margin = new Padding(3, 5, 3, 5);
            fieldDatoBusqueda.Name = "fieldDatoBusqueda";
            fieldDatoBusqueda.PasswordChar = '\0';
            fieldDatoBusqueda.PlaceholderForeColor = Color.FromArgb(  115,   109,   106);
            fieldDatoBusqueda.PlaceholderText = "Buscar movimientos";
            fieldDatoBusqueda.SelectedText = "";
            fieldDatoBusqueda.ShadowDecoration.CustomizableEdges = customizableEdges14;
            fieldDatoBusqueda.Size = new Size(350, 35);
            fieldDatoBusqueda.TabIndex = 8;
            fieldDatoBusqueda.TextOffset = new Point(5, 0);
            // 
            // layoutBotones
            // 
            layoutBotones.BackColor = Color.FromArgb(  248,   244,   242);
            layoutBotones.Controls.Add(btnRegistrarProveedor);
            layoutBotones.Dock = DockStyle.Fill;
            layoutBotones.Location = new Point(0, 0);
            layoutBotones.Margin = new Padding(0);
            layoutBotones.Name = "layoutBotones";
            layoutBotones.Size = new Size(930, 45);
            layoutBotones.TabIndex = 3;
            // 
            // btnRegistrarProveedor
            // 
            btnRegistrarProveedor.Animated = true;
            btnRegistrarProveedor.BackColor = Color.FromArgb(  248,   244,   242);
            btnRegistrarProveedor.BorderRadius = 18;
            btnRegistrarProveedor.CustomizableEdges = customizableEdges15;
            btnRegistrarProveedor.FillColor = Color.FromArgb(  217,   211,   204);
            btnRegistrarProveedor.Font = new Font("Microsoft PhagsPa", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrarProveedor.ForeColor = Color.FromArgb(  40,   37,   35);
            btnRegistrarProveedor.Image = (Image) resources.GetObject("btnRegistrarProveedor.Image");
            btnRegistrarProveedor.ImageOffset = new Point(-5, 0);
            btnRegistrarProveedor.Location = new Point(3, 3);
            btnRegistrarProveedor.Margin = new Padding(3, 3, 1, 3);
            btnRegistrarProveedor.Name = "btnRegistrarProveedor";
            btnRegistrarProveedor.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnRegistrarProveedor.Size = new Size(320, 39);
            btnRegistrarProveedor.TabIndex = 7;
            btnRegistrarProveedor.Text = "Registrar un movimiento";
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
            fieldSubtitulo.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldSubtitulo.ForeColor = Color.Gray;
            fieldSubtitulo.ImeMode = ImeMode.NoControl;
            fieldSubtitulo.Location = new Point(55, 50);
            fieldSubtitulo.Margin = new Padding(5, 5, 1, 1);
            fieldSubtitulo.Name = "fieldSubtitulo";
            fieldSubtitulo.Size = new Size(1280, 39);
            fieldSubtitulo.TabIndex = 2;
            fieldSubtitulo.Text = "Registro, edición, eliminación, búsqueda de movimientos de almacenes.";
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
            // layoutControlesTabla
            // 
            layoutControlesTabla.BackColor = Color.FromArgb(  243,   243,   243);
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
            // btnPaginaAnterior
            // 
            btnPaginaAnterior.Animated = true;
            btnPaginaAnterior.BackColor = Color.FromArgb(  243,   243,   243);
            btnPaginaAnterior.CheckedState.BorderColor = Color.WhiteSmoke;
            btnPaginaAnterior.CheckedState.FillColor = Color.WhiteSmoke;
            btnPaginaAnterior.CustomImages.Image = (Image) resources.GetObject("resource.Image1");
            btnPaginaAnterior.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnPaginaAnterior.CustomImages.ImageSize = new Size(24, 24);
            btnPaginaAnterior.CustomizableEdges = customizableEdges17;
            btnPaginaAnterior.Dock = DockStyle.Fill;
            btnPaginaAnterior.FillColor = Color.FromArgb(  243,   243,   243);
            btnPaginaAnterior.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnPaginaAnterior.ForeColor = Color.White;
            btnPaginaAnterior.HoverState.BorderColor = Color.FromArgb(  243,   243,   243);
            btnPaginaAnterior.HoverState.FillColor = Color.FromArgb(  243,   243,   243);
            btnPaginaAnterior.ImageSize = new Size(24, 24);
            btnPaginaAnterior.Location = new Point(36, 1);
            btnPaginaAnterior.Margin = new Padding(1);
            btnPaginaAnterior.Name = "btnPaginaAnterior";
            btnPaginaAnterior.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnPaginaAnterior.Size = new Size(33, 33);
            btnPaginaAnterior.TabIndex = 1;
            // 
            // btnPrimeraPagina
            // 
            btnPrimeraPagina.Animated = true;
            btnPrimeraPagina.BackColor = Color.FromArgb(  243,   243,   243);
            btnPrimeraPagina.CheckedState.BorderColor = Color.WhiteSmoke;
            btnPrimeraPagina.CheckedState.FillColor = Color.WhiteSmoke;
            btnPrimeraPagina.CustomImages.Image = (Image) resources.GetObject("resource.Image2");
            btnPrimeraPagina.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnPrimeraPagina.CustomImages.ImageSize = new Size(24, 24);
            btnPrimeraPagina.CustomizableEdges = customizableEdges19;
            btnPrimeraPagina.Dock = DockStyle.Fill;
            btnPrimeraPagina.FillColor = Color.FromArgb(  243,   243,   243);
            btnPrimeraPagina.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrimeraPagina.ForeColor = Color.White;
            btnPrimeraPagina.HoverState.BorderColor = Color.FromArgb(  243,   243,   243);
            btnPrimeraPagina.HoverState.FillColor = Color.FromArgb(  243,   243,   243);
            btnPrimeraPagina.ImageSize = new Size(24, 24);
            btnPrimeraPagina.Location = new Point(1, 1);
            btnPrimeraPagina.Margin = new Padding(1);
            btnPrimeraPagina.Name = "btnPrimeraPagina";
            btnPrimeraPagina.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnPrimeraPagina.Size = new Size(33, 33);
            btnPrimeraPagina.TabIndex = 0;
            // 
            // btnPaginaSiguiente
            // 
            btnPaginaSiguiente.Animated = true;
            btnPaginaSiguiente.BackColor = Color.FromArgb(  243,   243,   243);
            btnPaginaSiguiente.CheckedState.BorderColor = Color.WhiteSmoke;
            btnPaginaSiguiente.CheckedState.FillColor = Color.WhiteSmoke;
            btnPaginaSiguiente.CustomImages.Image = (Image) resources.GetObject("resource.Image3");
            btnPaginaSiguiente.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnPaginaSiguiente.CustomImages.ImageSize = new Size(24, 24);
            btnPaginaSiguiente.CustomizableEdges = customizableEdges21;
            btnPaginaSiguiente.Dock = DockStyle.Fill;
            btnPaginaSiguiente.FillColor = Color.FromArgb(  243,   243,   243);
            btnPaginaSiguiente.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnPaginaSiguiente.ForeColor = Color.White;
            btnPaginaSiguiente.HoverState.BorderColor = Color.FromArgb(  243,   243,   243);
            btnPaginaSiguiente.HoverState.FillColor = Color.FromArgb(  243,   243,   243);
            btnPaginaSiguiente.ImageSize = new Size(24, 24);
            btnPaginaSiguiente.Location = new Point(311, 1);
            btnPaginaSiguiente.Margin = new Padding(1);
            btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            btnPaginaSiguiente.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnPaginaSiguiente.Size = new Size(33, 33);
            btnPaginaSiguiente.TabIndex = 2;
            // 
            // btnUltimaPagina
            // 
            btnUltimaPagina.Animated = true;
            btnUltimaPagina.BackColor = Color.FromArgb(  243,   243,   243);
            btnUltimaPagina.CheckedState.BorderColor = Color.WhiteSmoke;
            btnUltimaPagina.CheckedState.FillColor = Color.WhiteSmoke;
            btnUltimaPagina.CustomImages.Image = (Image) resources.GetObject("resource.Image4");
            btnUltimaPagina.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnUltimaPagina.CustomImages.ImageSize = new Size(24, 24);
            btnUltimaPagina.CustomizableEdges = customizableEdges23;
            btnUltimaPagina.Dock = DockStyle.Fill;
            btnUltimaPagina.FillColor = Color.FromArgb(  243,   243,   243);
            btnUltimaPagina.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnUltimaPagina.ForeColor = Color.White;
            btnUltimaPagina.HoverState.BorderColor = Color.FromArgb(  243,   243,   243);
            btnUltimaPagina.HoverState.FillColor = Color.FromArgb(  243,   243,   243);
            btnUltimaPagina.ImageSize = new Size(24, 24);
            btnUltimaPagina.Location = new Point(346, 1);
            btnUltimaPagina.Margin = new Padding(1);
            btnUltimaPagina.Name = "btnUltimaPagina";
            btnUltimaPagina.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnUltimaPagina.Size = new Size(33, 33);
            btnUltimaPagina.TabIndex = 3;
            // 
            // btnSincronizarDatos
            // 
            btnSincronizarDatos.Animated = true;
            btnSincronizarDatos.BackColor = Color.FromArgb(  243,   243,   243);
            btnSincronizarDatos.CheckedState.BorderColor = Color.WhiteSmoke;
            btnSincronizarDatos.CheckedState.FillColor = Color.WhiteSmoke;
            btnSincronizarDatos.CustomImages.Image = (Image) resources.GetObject("resource.Image5");
            btnSincronizarDatos.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnSincronizarDatos.CustomImages.ImageSize = new Size(24, 24);
            btnSincronizarDatos.CustomizableEdges = customizableEdges25;
            btnSincronizarDatos.Dock = DockStyle.Fill;
            btnSincronizarDatos.FillColor = Color.FromArgb(  243,   243,   243);
            btnSincronizarDatos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSincronizarDatos.ForeColor = Color.White;
            btnSincronizarDatos.HoverState.BorderColor = Color.FromArgb(  243,   243,   243);
            btnSincronizarDatos.HoverState.FillColor = Color.FromArgb(  243,   243,   243);
            btnSincronizarDatos.ImageSize = new Size(24, 24);
            btnSincronizarDatos.Location = new Point(391, 1);
            btnSincronizarDatos.Margin = new Padding(1);
            btnSincronizarDatos.Name = "btnSincronizarDatos";
            btnSincronizarDatos.ShadowDecoration.CustomizableEdges = customizableEdges26;
            btnSincronizarDatos.Size = new Size(33, 33);
            btnSincronizarDatos.TabIndex = 4;
            // 
            // fieldPaginaActual
            // 
            fieldPaginaActual.Dock = DockStyle.Fill;
            fieldPaginaActual.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldPaginaActual.ForeColor = Color.FromArgb(  40,   37,   35);
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
            fieldPaginasTotales.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
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
            // layoutTituloAlmacenReporte
            // 
            layoutTituloAlmacenReporte.ColumnCount = 2;
            layoutTituloAlmacenReporte.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            layoutTituloAlmacenReporte.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutTituloAlmacenReporte.Controls.Add(fieldTituloNombreAlmacenOrigen, 0, 0);
            layoutTituloAlmacenReporte.Controls.Add(fieldTituloNombreAlmacenDestino, 1, 0);
            layoutTituloAlmacenReporte.Dock = DockStyle.Fill;
            layoutTituloAlmacenReporte.Location = new Point(50, 110);
            layoutTituloAlmacenReporte.Margin = new Padding(0);
            layoutTituloAlmacenReporte.Name = "layoutTituloAlmacenReporte";
            layoutTituloAlmacenReporte.RowCount = 1;
            layoutTituloAlmacenReporte.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutTituloAlmacenReporte.Size = new Size(1286, 35);
            layoutTituloAlmacenReporte.TabIndex = 32;
            // 
            // fieldTituloNombreAlmacenOrigen
            // 
            fieldTituloNombreAlmacenOrigen.Dock = DockStyle.Fill;
            fieldTituloNombreAlmacenOrigen.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloNombreAlmacenOrigen.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldTituloNombreAlmacenOrigen.Image = (Image) resources.GetObject("fieldTituloNombreAlmacenOrigen.Image");
            fieldTituloNombreAlmacenOrigen.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloNombreAlmacenOrigen.ImeMode = ImeMode.NoControl;
            fieldTituloNombreAlmacenOrigen.Location = new Point(15, 5);
            fieldTituloNombreAlmacenOrigen.Margin = new Padding(15, 5, 3, 3);
            fieldTituloNombreAlmacenOrigen.Name = "fieldTituloNombreAlmacenOrigen";
            fieldTituloNombreAlmacenOrigen.Size = new Size(302, 27);
            fieldTituloNombreAlmacenOrigen.TabIndex = 24;
            fieldTituloNombreAlmacenOrigen.Text = "      Almacén de origen :";
            fieldTituloNombreAlmacenOrigen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldTituloNombreAlmacenDestino
            // 
            fieldTituloNombreAlmacenDestino.Dock = DockStyle.Fill;
            fieldTituloNombreAlmacenDestino.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloNombreAlmacenDestino.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldTituloNombreAlmacenDestino.Image = (Image) resources.GetObject("fieldTituloNombreAlmacenDestino.Image");
            fieldTituloNombreAlmacenDestino.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloNombreAlmacenDestino.ImeMode = ImeMode.NoControl;
            fieldTituloNombreAlmacenDestino.Location = new Point(335, 5);
            fieldTituloNombreAlmacenDestino.Margin = new Padding(15, 5, 3, 3);
            fieldTituloNombreAlmacenDestino.Name = "fieldTituloNombreAlmacenDestino";
            fieldTituloNombreAlmacenDestino.Size = new Size(948, 27);
            fieldTituloNombreAlmacenDestino.TabIndex = 25;
            fieldTituloNombreAlmacenDestino.Text = "      Reporte :";
            fieldTituloNombreAlmacenDestino.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VistaGestionMovimientos
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1356, 608);
            Controls.Add(layoutVista);
            Font = new Font("Microsoft PhagsPa", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaGestionMovimientos";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistGestionProveedor";
            layoutVista.ResumeLayout(false);
            layoutAlmacenReportes.ResumeLayout(false);
            layoutOpcionesReporte.ResumeLayout(false);
            layoutEncabezadosTabla.ResumeLayout(false);
            layoutTitulo.ResumeLayout(false);
            layoutDistribucionMenu.ResumeLayout(false);
            layoutBotones.ResumeLayout(false);
            ((ISupportInitialize) fieldIcono).EndInit();
            layoutControlesTabla.ResumeLayout(false);
            layoutTituloAlmacenReporte.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutVista;
        private TableLayoutPanel layoutTitulo;
        private Guna2Button btnCerrar;
        private Label fieldTitulo;
        private TableLayoutPanel layoutDistribucionMenu;
        private Guna2TextBox fieldDatoBusqueda;
        private FlowLayoutPanel layoutBotones;
        private Guna2Button btnRegistrarProveedor;
        private PictureBox fieldIcono;
        private Label fieldSubtitulo;
        private Label fieldTituloId;
        private Panel contenedorVistas;
        private TableLayoutPanel layoutControlesTabla;
        private Guna2Button btnPaginaAnterior;
        private Guna2Button btnPrimeraPagina;
        private Guna2Button btnPaginaSiguiente;
        private Guna2Button btnUltimaPagina;
        private Guna2Button btnSincronizarDatos;
        private Label fieldPaginaActual;
        private Label fieldPaginasTotales;
        private TableLayoutPanel layoutEncabezadosTabla;
        private Label fieldTituloAlmacenOrigen;
        private Label fieldTituloFecha;
        private Label fieldTituloMotivo;
        private Label fieldTitulaCantidadMovida;
        private Label fieldTituloAlmacenDestino;
        private TableLayoutPanel layoutAlmacenReportes;
        private TableLayoutPanel layoutTituloAlmacenReporte;
        private Label fieldTituloNombreAlmacenOrigen;
        private Label fieldTituloNombreAlmacenDestino;
        private Guna2ComboBox fieldNombreAlmacenOrigen;
        private TableLayoutPanel layoutOpcionesReporte;
        private Guna2DateTimePicker fieldFechaFinal;
        private Guna2ComboBox fieldFormatoReporte;
        private Guna2DateTimePicker fieldFechaInicio;
        private Guna2Button btnImprimirReporte;
        private Label fieldTituloNombreArticulo;
    }
}