using Guna.UI2.WinForms;

using System.ComponentModel;

namespace Manigest.Modulos.Contactos.MVP.Vistas.Proveedor {
    partial class VistaGestionProveedor {
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaGestionProveedor));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges31 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges32 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutVista = new TableLayoutPanel();
            layoutTitulo = new TableLayoutPanel();
            btnCerrar = new Guna2Button();
            fieldTitulo = new Label();
            layoutDistribucionMenu = new TableLayoutPanel();
            fieldDatoBusqueda = new Guna2TextBox();
            layoutBotones = new FlowLayoutPanel();
            btnRegistrarProveedor = new Guna2Button();
            fieldIcono = new PictureBox();
            fieldSubtitulo = new Label();
            layoutEncabezadosTabla = new TableLayoutPanel();
            fieldTituloNumeroIdentificacionTributaria = new Label();
            fieldTituloId = new Label();
            fieldTituloNombreRepresentante = new Label();
            fieldTituloRazonSocial = new Label();
            contenedorVistas = new Panel();
            layoutControlesTabla = new TableLayoutPanel();
            btnPaginaAnterior = new Guna2Button();
            btnPrimeraPagina = new Guna2Button();
            btnPaginaSiguiente = new Guna2Button();
            btnUltimaPagina = new Guna2Button();
            btnSincronizarDatos = new Guna2Button();
            fieldPaginaActual = new Label();
            fieldPaginasTotales = new Label();
            layoutVista.SuspendLayout();
            layoutTitulo.SuspendLayout();
            layoutDistribucionMenu.SuspendLayout();
            layoutBotones.SuspendLayout();
            ((ISupportInitialize) fieldIcono).BeginInit();
            layoutEncabezadosTabla.SuspendLayout();
            layoutControlesTabla.SuspendLayout();
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
            layoutVista.Controls.Add(layoutTitulo, 2, 0);
            layoutVista.Controls.Add(layoutDistribucionMenu, 2, 3);
            layoutVista.Controls.Add(fieldIcono, 1, 0);
            layoutVista.Controls.Add(fieldSubtitulo, 2, 1);
            layoutVista.Controls.Add(layoutEncabezadosTabla, 2, 5);
            layoutVista.Controls.Add(contenedorVistas, 2, 7);
            layoutVista.Controls.Add(layoutControlesTabla, 2, 8);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(0, 0);
            layoutVista.Margin = new Padding(1);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 10;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
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
            btnCerrar.CustomizableEdges = customizableEdges17;
            btnCerrar.Dock = DockStyle.Fill;
            btnCerrar.FillColor = Color.FromArgb(  250,   250,   250);
            btnCerrar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.Black;
            btnCerrar.HoverState.FillColor = Color.FromArgb(  250,   250,   250);
            btnCerrar.Image = (Image) resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(1239, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnCerrar.Size = new Size(44, 39);
            btnCerrar.TabIndex = 8;
            // 
            // fieldTitulo
            // 
            fieldTitulo.Dock = DockStyle.Fill;
            fieldTitulo.Font = new Font("Microsoft PhagsPa", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTitulo.ForeColor = Color.Black;
            fieldTitulo.ImeMode = ImeMode.NoControl;
            fieldTitulo.Location = new Point(3, 0);
            fieldTitulo.Name = "fieldTitulo";
            fieldTitulo.Size = new Size(1230, 45);
            fieldTitulo.TabIndex = 3;
            fieldTitulo.Text = "Gestión de proveedores";
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
            layoutDistribucionMenu.Location = new Point(50, 110);
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
            fieldDatoBusqueda.CustomizableEdges = customizableEdges19;
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
            fieldDatoBusqueda.PlaceholderText = "Buscar proveedores";
            fieldDatoBusqueda.SelectedText = "";
            fieldDatoBusqueda.ShadowDecoration.CustomizableEdges = customizableEdges20;
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
            btnRegistrarProveedor.CustomizableEdges = customizableEdges21;
            btnRegistrarProveedor.FillColor = Color.FromArgb(  217,   211,   204);
            btnRegistrarProveedor.Font = new Font("Microsoft PhagsPa", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrarProveedor.ForeColor = Color.FromArgb(  40,   37,   35);
            btnRegistrarProveedor.Image = (Image) resources.GetObject("btnRegistrarProveedor.Image");
            btnRegistrarProveedor.ImageOffset = new Point(-5, 0);
            btnRegistrarProveedor.Location = new Point(3, 3);
            btnRegistrarProveedor.Margin = new Padding(3, 3, 1, 3);
            btnRegistrarProveedor.Name = "btnRegistrarProveedor";
            btnRegistrarProveedor.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnRegistrarProveedor.Size = new Size(320, 39);
            btnRegistrarProveedor.TabIndex = 7;
            btnRegistrarProveedor.Text = "Registrar un proveedor";
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
            fieldSubtitulo.Text = "Registro, edición, eliminación, búsqueda de clientes.";
            // 
            // layoutEncabezadosTabla
            // 
            layoutEncabezadosTabla.BackColor = Color.FromArgb(  243,   243,   243);
            layoutEncabezadosTabla.ColumnCount = 8;
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.Controls.Add(fieldTituloNumeroIdentificacionTributaria, 0, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloId, 0, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloNombreRepresentante, 3, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloRazonSocial, 2, 0);
            layoutEncabezadosTabla.Dock = DockStyle.Fill;
            layoutEncabezadosTabla.Location = new Point(51, 166);
            layoutEncabezadosTabla.Margin = new Padding(1);
            layoutEncabezadosTabla.Name = "layoutEncabezadosTabla";
            layoutEncabezadosTabla.RowCount = 1;
            layoutEncabezadosTabla.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.Size = new Size(1284, 58);
            layoutEncabezadosTabla.TabIndex = 11;
            // 
            // fieldTituloNumeroIdentificacionTributaria
            // 
            fieldTituloNumeroIdentificacionTributaria.Dock = DockStyle.Fill;
            fieldTituloNumeroIdentificacionTributaria.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloNumeroIdentificacionTributaria.ForeColor = Color.Black;
            fieldTituloNumeroIdentificacionTributaria.ImeMode = ImeMode.NoControl;
            fieldTituloNumeroIdentificacionTributaria.Location = new Point(61, 1);
            fieldTituloNumeroIdentificacionTributaria.Margin = new Padding(1);
            fieldTituloNumeroIdentificacionTributaria.Name = "fieldTituloNumeroIdentificacionTributaria";
            fieldTituloNumeroIdentificacionTributaria.Size = new Size(218, 56);
            fieldTituloNumeroIdentificacionTributaria.TabIndex = 15;
            fieldTituloNumeroIdentificacionTributaria.Text = "NIT";
            fieldTituloNumeroIdentificacionTributaria.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloId
            // 
            fieldTituloId.Dock = DockStyle.Fill;
            fieldTituloId.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
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
            // fieldTituloNombreRepresentante
            // 
            fieldTituloNombreRepresentante.Dock = DockStyle.Fill;
            fieldTituloNombreRepresentante.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloNombreRepresentante.ForeColor = Color.Black;
            fieldTituloNombreRepresentante.ImeMode = ImeMode.NoControl;
            fieldTituloNombreRepresentante.Location = new Point(581, 1);
            fieldTituloNombreRepresentante.Margin = new Padding(1);
            fieldTituloNombreRepresentante.Name = "fieldTituloNombreRepresentante";
            fieldTituloNombreRepresentante.Size = new Size(298, 56);
            fieldTituloNombreRepresentante.TabIndex = 10;
            fieldTituloNombreRepresentante.Text = "Nombre del representante";
            fieldTituloNombreRepresentante.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloRazonSocial
            // 
            fieldTituloRazonSocial.Dock = DockStyle.Fill;
            fieldTituloRazonSocial.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloRazonSocial.ForeColor = Color.Black;
            fieldTituloRazonSocial.ImeMode = ImeMode.NoControl;
            fieldTituloRazonSocial.Location = new Point(281, 1);
            fieldTituloRazonSocial.Margin = new Padding(1);
            fieldTituloRazonSocial.Name = "fieldTituloRazonSocial";
            fieldTituloRazonSocial.Size = new Size(298, 56);
            fieldTituloRazonSocial.TabIndex = 4;
            fieldTituloRazonSocial.Text = "Razón social";
            fieldTituloRazonSocial.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contenedorVistas
            // 
            contenedorVistas.Dock = DockStyle.Fill;
            contenedorVistas.Location = new Point(50, 235);
            contenedorVistas.Margin = new Padding(0);
            contenedorVistas.Name = "contenedorVistas";
            contenedorVistas.Size = new Size(1286, 318);
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
            btnPaginaAnterior.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnPaginaAnterior.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnPaginaAnterior.CustomImages.ImageSize = new Size(24, 24);
            btnPaginaAnterior.CustomizableEdges = customizableEdges23;
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
            btnPaginaAnterior.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnPaginaAnterior.Size = new Size(33, 33);
            btnPaginaAnterior.TabIndex = 1;
            // 
            // btnPrimeraPagina
            // 
            btnPrimeraPagina.Animated = true;
            btnPrimeraPagina.BackColor = Color.FromArgb(  243,   243,   243);
            btnPrimeraPagina.CheckedState.BorderColor = Color.WhiteSmoke;
            btnPrimeraPagina.CheckedState.FillColor = Color.WhiteSmoke;
            btnPrimeraPagina.CustomImages.Image = (Image) resources.GetObject("resource.Image1");
            btnPrimeraPagina.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnPrimeraPagina.CustomImages.ImageSize = new Size(24, 24);
            btnPrimeraPagina.CustomizableEdges = customizableEdges25;
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
            btnPrimeraPagina.ShadowDecoration.CustomizableEdges = customizableEdges26;
            btnPrimeraPagina.Size = new Size(33, 33);
            btnPrimeraPagina.TabIndex = 0;
            // 
            // btnPaginaSiguiente
            // 
            btnPaginaSiguiente.Animated = true;
            btnPaginaSiguiente.BackColor = Color.FromArgb(  243,   243,   243);
            btnPaginaSiguiente.CheckedState.BorderColor = Color.WhiteSmoke;
            btnPaginaSiguiente.CheckedState.FillColor = Color.WhiteSmoke;
            btnPaginaSiguiente.CustomImages.Image = (Image) resources.GetObject("resource.Image2");
            btnPaginaSiguiente.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnPaginaSiguiente.CustomImages.ImageSize = new Size(24, 24);
            btnPaginaSiguiente.CustomizableEdges = customizableEdges27;
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
            btnPaginaSiguiente.ShadowDecoration.CustomizableEdges = customizableEdges28;
            btnPaginaSiguiente.Size = new Size(33, 33);
            btnPaginaSiguiente.TabIndex = 2;
            // 
            // btnUltimaPagina
            // 
            btnUltimaPagina.Animated = true;
            btnUltimaPagina.BackColor = Color.FromArgb(  243,   243,   243);
            btnUltimaPagina.CheckedState.BorderColor = Color.WhiteSmoke;
            btnUltimaPagina.CheckedState.FillColor = Color.WhiteSmoke;
            btnUltimaPagina.CustomImages.Image = (Image) resources.GetObject("resource.Image3");
            btnUltimaPagina.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnUltimaPagina.CustomImages.ImageSize = new Size(24, 24);
            btnUltimaPagina.CustomizableEdges = customizableEdges29;
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
            btnUltimaPagina.ShadowDecoration.CustomizableEdges = customizableEdges30;
            btnUltimaPagina.Size = new Size(33, 33);
            btnUltimaPagina.TabIndex = 3;
            // 
            // btnSincronizarDatos
            // 
            btnSincronizarDatos.Animated = true;
            btnSincronizarDatos.BackColor = Color.FromArgb(  243,   243,   243);
            btnSincronizarDatos.CheckedState.BorderColor = Color.WhiteSmoke;
            btnSincronizarDatos.CheckedState.FillColor = Color.WhiteSmoke;
            btnSincronizarDatos.CustomImages.Image = (Image) resources.GetObject("resource.Image4");
            btnSincronizarDatos.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnSincronizarDatos.CustomImages.ImageSize = new Size(24, 24);
            btnSincronizarDatos.CustomizableEdges = customizableEdges31;
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
            btnSincronizarDatos.ShadowDecoration.CustomizableEdges = customizableEdges32;
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
            // VistGestionProveedor
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1356, 608);
            Controls.Add(layoutVista);
            Font = new Font("Microsoft PhagsPa", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistGestionProveedor";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistGestionProveedor";
            layoutVista.ResumeLayout(false);
            layoutTitulo.ResumeLayout(false);
            layoutDistribucionMenu.ResumeLayout(false);
            layoutBotones.ResumeLayout(false);
            ((ISupportInitialize) fieldIcono).EndInit();
            layoutEncabezadosTabla.ResumeLayout(false);
            layoutControlesTabla.ResumeLayout(false);
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
        private TableLayoutPanel layoutEncabezadosTabla;
        private Label fieldTituloNumeroIdentificacionTributaria;
        private Label fieldTituloId;
        private Label fieldTituloNombreRepresentante;
        private Panel contenedorVistas;
        private Label fieldTituloRazonSocial;
        private TableLayoutPanel layoutControlesTabla;
        private Guna2Button btnPaginaAnterior;
        private Guna2Button btnPrimeraPagina;
        private Guna2Button btnPaginaSiguiente;
        private Guna2Button btnUltimaPagina;
        private Guna2Button btnSincronizarDatos;
        private Label fieldPaginaActual;
        private Label fieldPaginasTotales;
    }
}