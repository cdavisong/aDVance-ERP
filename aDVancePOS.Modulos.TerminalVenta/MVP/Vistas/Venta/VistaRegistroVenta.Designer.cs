using Guna.UI2.WinForms;

using System.ComponentModel;

namespace aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta {
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaRegistroVenta));
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
            formatoBase = new Guna2BorderlessForm(components);
            layoutVista = new TableLayoutPanel();
            layoutHerramientas = new TableLayoutPanel();
            fieldDatoBusqueda = new Guna2TextBox();
            fieldCriterioBusqueda = new Guna2ComboBox();
            layoutTituloHerramientas = new TableLayoutPanel();
            fieldTituloFiltrosBusqueda = new Label();
            separador1 = new Guna2Separator();
            layoutDistribución1 = new TableLayoutPanel();
            layoutDistribucionControlesVenta = new TableLayoutPanel();
            layoutBotonesVenta = new TableLayoutPanel();
            btnCantidadArticulo = new Guna2Button();
            btnNuevaVenta = new Guna2Button();
            btnEliminarArticulo = new Guna2Button();
            btnBuscarArticulo = new Guna2Button();
            layoutMetodosPago = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            layoutEncabezadosTabla = new TableLayoutPanel();
            fieldTituloId = new Label();
            fieldTituloTotalArticulo = new Label();
            fieldTituloNombreArticulo = new Label();
            fieldTituloCantidadArticulo = new Label();
            fieldTituloPrecioArticulo = new Label();
            layoutVista.SuspendLayout();
            layoutHerramientas.SuspendLayout();
            layoutTituloHerramientas.SuspendLayout();
            layoutDistribución1.SuspendLayout();
            layoutDistribucionControlesVenta.SuspendLayout();
            layoutBotonesVenta.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            layoutVista.ColumnCount = 3;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.Controls.Add(layoutHerramientas, 1, 1);
            layoutVista.Controls.Add(layoutTituloHerramientas, 1, 0);
            layoutVista.Controls.Add(separador1, 1, 2);
            layoutVista.Controls.Add(layoutDistribución1, 1, 3);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(0, 0);
            layoutVista.Margin = new Padding(1);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 5;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.Size = new Size(1356, 608);
            layoutVista.TabIndex = 4;
            // 
            // layoutHerramientas
            // 
            layoutHerramientas.ColumnCount = 2;
            layoutHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            layoutHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutHerramientas.Controls.Add(fieldDatoBusqueda, 1, 0);
            layoutHerramientas.Controls.Add(fieldCriterioBusqueda, 0, 0);
            layoutHerramientas.Dock = DockStyle.Fill;
            layoutHerramientas.Location = new Point(20, 35);
            layoutHerramientas.Margin = new Padding(0);
            layoutHerramientas.Name = "layoutHerramientas";
            layoutHerramientas.RowCount = 1;
            layoutHerramientas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutHerramientas.Size = new Size(1316, 45);
            layoutHerramientas.TabIndex = 38;
            // 
            // fieldDatoBusqueda
            // 
            fieldDatoBusqueda.Animated = true;
            fieldDatoBusqueda.BackColor = Color.FromArgb(  254,   254,   253);
            fieldDatoBusqueda.BorderColor = Color.Gainsboro;
            fieldDatoBusqueda.BorderRadius = 18;
            fieldDatoBusqueda.Cursor = Cursors.IBeam;
            fieldDatoBusqueda.CustomizableEdges = customizableEdges1;
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
            fieldDatoBusqueda.Location = new Point(305, 5);
            fieldDatoBusqueda.Margin = new Padding(5);
            fieldDatoBusqueda.Name = "fieldDatoBusqueda";
            fieldDatoBusqueda.PasswordChar = '\0';
            fieldDatoBusqueda.PlaceholderForeColor = Color.DimGray;
            fieldDatoBusqueda.PlaceholderText = "Datos complementarios de búsqueda";
            fieldDatoBusqueda.SelectedText = "";
            fieldDatoBusqueda.ShadowDecoration.CustomizableEdges = customizableEdges2;
            fieldDatoBusqueda.Size = new Size(1006, 35);
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
            fieldCriterioBusqueda.CustomizableEdges = customizableEdges3;
            fieldCriterioBusqueda.Dock = DockStyle.Fill;
            fieldCriterioBusqueda.DrawMode = DrawMode.OwnerDrawFixed;
            fieldCriterioBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldCriterioBusqueda.FocusedColor = Color.Gainsboro;
            fieldCriterioBusqueda.FocusedState.BorderColor = Color.Gainsboro;
            fieldCriterioBusqueda.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldCriterioBusqueda.ForeColor = Color.Black;
            fieldCriterioBusqueda.ItemHeight = 29;
            fieldCriterioBusqueda.Location = new Point(5, 5);
            fieldCriterioBusqueda.Margin = new Padding(5);
            fieldCriterioBusqueda.Name = "fieldCriterioBusqueda";
            fieldCriterioBusqueda.ShadowDecoration.CustomizableEdges = customizableEdges4;
            fieldCriterioBusqueda.Size = new Size(290, 35);
            fieldCriterioBusqueda.TabIndex = 27;
            fieldCriterioBusqueda.TextOffset = new Point(10, 0);
            // 
            // layoutTituloHerramientas
            // 
            layoutTituloHerramientas.ColumnCount = 2;
            layoutTituloHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            layoutTituloHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutTituloHerramientas.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutTituloHerramientas.Controls.Add(fieldTituloFiltrosBusqueda, 0, 0);
            layoutTituloHerramientas.Dock = DockStyle.Fill;
            layoutTituloHerramientas.Location = new Point(20, 0);
            layoutTituloHerramientas.Margin = new Padding(0);
            layoutTituloHerramientas.Name = "layoutTituloHerramientas";
            layoutTituloHerramientas.RowCount = 1;
            layoutTituloHerramientas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutTituloHerramientas.Size = new Size(1316, 35);
            layoutTituloHerramientas.TabIndex = 37;
            // 
            // fieldTituloFiltrosBusqueda
            // 
            fieldTituloFiltrosBusqueda.Dock = DockStyle.Fill;
            fieldTituloFiltrosBusqueda.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTituloFiltrosBusqueda.ForeColor = Color.DimGray;
            fieldTituloFiltrosBusqueda.Image = (Image) resources.GetObject("fieldTituloFiltrosBusqueda.Image");
            fieldTituloFiltrosBusqueda.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloFiltrosBusqueda.ImeMode = ImeMode.NoControl;
            fieldTituloFiltrosBusqueda.Location = new Point(15, 5);
            fieldTituloFiltrosBusqueda.Margin = new Padding(15, 5, 3, 3);
            fieldTituloFiltrosBusqueda.Name = "fieldTituloFiltrosBusqueda";
            fieldTituloFiltrosBusqueda.Size = new Size(282, 27);
            fieldTituloFiltrosBusqueda.TabIndex = 24;
            fieldTituloFiltrosBusqueda.Text = "      Filtro de búsqueda de artículos";
            fieldTituloFiltrosBusqueda.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // separador1
            // 
            separador1.Dock = DockStyle.Fill;
            separador1.FillColor = Color.Gainsboro;
            separador1.Location = new Point(23, 83);
            separador1.Name = "separador1";
            separador1.Size = new Size(1310, 14);
            separador1.TabIndex = 36;
            // 
            // layoutDistribución1
            // 
            layoutDistribución1.ColumnCount = 2;
            layoutDistribución1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            layoutDistribución1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            layoutDistribución1.Controls.Add(layoutDistribucionControlesVenta, 1, 0);
            layoutDistribución1.Controls.Add(tableLayoutPanel1, 0, 0);
            layoutDistribución1.Dock = DockStyle.Fill;
            layoutDistribución1.Location = new Point(20, 100);
            layoutDistribución1.Margin = new Padding(0);
            layoutDistribución1.Name = "layoutDistribución1";
            layoutDistribución1.RowCount = 1;
            layoutDistribución1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutDistribución1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutDistribución1.Size = new Size(1316, 488);
            layoutDistribución1.TabIndex = 39;
            // 
            // layoutDistribucionControlesVenta
            // 
            layoutDistribucionControlesVenta.BackColor = Color.WhiteSmoke;
            layoutDistribucionControlesVenta.ColumnCount = 1;
            layoutDistribucionControlesVenta.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutDistribucionControlesVenta.Controls.Add(layoutBotonesVenta, 0, 0);
            layoutDistribucionControlesVenta.Controls.Add(layoutMetodosPago, 0, 1);
            layoutDistribucionControlesVenta.Dock = DockStyle.Fill;
            layoutDistribucionControlesVenta.Location = new Point(924, 3);
            layoutDistribucionControlesVenta.Name = "layoutDistribucionControlesVenta";
            layoutDistribucionControlesVenta.RowCount = 6;
            layoutDistribucionControlesVenta.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            layoutDistribucionControlesVenta.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutDistribucionControlesVenta.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            layoutDistribucionControlesVenta.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            layoutDistribucionControlesVenta.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            layoutDistribucionControlesVenta.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            layoutDistribucionControlesVenta.Size = new Size(389, 482);
            layoutDistribucionControlesVenta.TabIndex = 0;
            // 
            // layoutBotonesVenta
            // 
            layoutBotonesVenta.ColumnCount = 4;
            layoutBotonesVenta.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            layoutBotonesVenta.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            layoutBotonesVenta.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            layoutBotonesVenta.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            layoutBotonesVenta.Controls.Add(btnCantidadArticulo, 0, 0);
            layoutBotonesVenta.Controls.Add(btnNuevaVenta, 0, 0);
            layoutBotonesVenta.Controls.Add(btnEliminarArticulo, 0, 0);
            layoutBotonesVenta.Controls.Add(btnBuscarArticulo, 0, 0);
            layoutBotonesVenta.Dock = DockStyle.Fill;
            layoutBotonesVenta.Location = new Point(0, 0);
            layoutBotonesVenta.Margin = new Padding(0);
            layoutBotonesVenta.Name = "layoutBotonesVenta";
            layoutBotonesVenta.RowCount = 1;
            layoutBotonesVenta.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBotonesVenta.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBotonesVenta.Size = new Size(389, 64);
            layoutBotonesVenta.TabIndex = 0;
            // 
            // btnCantidadArticulo
            // 
            btnCantidadArticulo.Animated = true;
            btnCantidadArticulo.BackColor = Color.White;
            btnCantidadArticulo.BorderRadius = 10;
            btnCantidadArticulo.CustomizableEdges = customizableEdges5;
            btnCantidadArticulo.Dock = DockStyle.Fill;
            btnCantidadArticulo.FillColor = Color.PeachPuff;
            btnCantidadArticulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCantidadArticulo.ForeColor = Color.Black;
            btnCantidadArticulo.Image = (Image) resources.GetObject("btnCantidadArticulo.Image");
            btnCantidadArticulo.Location = new Point(196, 2);
            btnCantidadArticulo.Margin = new Padding(2);
            btnCantidadArticulo.Name = "btnCantidadArticulo";
            btnCantidadArticulo.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCantidadArticulo.Size = new Size(93, 60);
            btnCantidadArticulo.TabIndex = 11;
            btnCantidadArticulo.Text = "F4";
            btnCantidadArticulo.TextAlign = HorizontalAlignment.Left;
            btnCantidadArticulo.TextOffset = new Point(0, -15);
            // 
            // btnNuevaVenta
            // 
            btnNuevaVenta.Animated = true;
            btnNuevaVenta.BackColor = Color.White;
            btnNuevaVenta.BorderRadius = 10;
            btnNuevaVenta.CustomizableEdges = customizableEdges7;
            btnNuevaVenta.Dock = DockStyle.Fill;
            btnNuevaVenta.FillColor = Color.PeachPuff;
            btnNuevaVenta.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnNuevaVenta.ForeColor = Color.Black;
            btnNuevaVenta.Image = (Image) resources.GetObject("btnNuevaVenta.Image");
            btnNuevaVenta.Location = new Point(293, 2);
            btnNuevaVenta.Margin = new Padding(2);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnNuevaVenta.Size = new Size(94, 60);
            btnNuevaVenta.TabIndex = 10;
            btnNuevaVenta.Text = "F5";
            btnNuevaVenta.TextAlign = HorizontalAlignment.Left;
            btnNuevaVenta.TextOffset = new Point(0, -15);
            // 
            // btnEliminarArticulo
            // 
            btnEliminarArticulo.Animated = true;
            btnEliminarArticulo.BackColor = Color.White;
            btnEliminarArticulo.BorderRadius = 10;
            btnEliminarArticulo.CustomizableEdges = customizableEdges9;
            btnEliminarArticulo.Dock = DockStyle.Fill;
            btnEliminarArticulo.FillColor = Color.PeachPuff;
            btnEliminarArticulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminarArticulo.ForeColor = Color.Black;
            btnEliminarArticulo.Image = (Image) resources.GetObject("btnEliminarArticulo.Image");
            btnEliminarArticulo.Location = new Point(2, 2);
            btnEliminarArticulo.Margin = new Padding(2);
            btnEliminarArticulo.Name = "btnEliminarArticulo";
            btnEliminarArticulo.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnEliminarArticulo.Size = new Size(93, 60);
            btnEliminarArticulo.TabIndex = 9;
            btnEliminarArticulo.TextAlign = HorizontalAlignment.Left;
            // 
            // btnBuscarArticulo
            // 
            btnBuscarArticulo.Animated = true;
            btnBuscarArticulo.BackColor = Color.White;
            btnBuscarArticulo.BorderRadius = 10;
            btnBuscarArticulo.CustomizableEdges = customizableEdges11;
            btnBuscarArticulo.Dock = DockStyle.Fill;
            btnBuscarArticulo.FillColor = Color.PeachPuff;
            btnBuscarArticulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnBuscarArticulo.ForeColor = Color.Black;
            btnBuscarArticulo.Image = (Image) resources.GetObject("btnBuscarArticulo.Image");
            btnBuscarArticulo.Location = new Point(99, 2);
            btnBuscarArticulo.Margin = new Padding(2);
            btnBuscarArticulo.Name = "btnBuscarArticulo";
            btnBuscarArticulo.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnBuscarArticulo.Size = new Size(93, 60);
            btnBuscarArticulo.TabIndex = 8;
            btnBuscarArticulo.Text = "F3";
            btnBuscarArticulo.TextAlign = HorizontalAlignment.Left;
            btnBuscarArticulo.TextOffset = new Point(0, -15);
            // 
            // layoutMetodosPago
            // 
            layoutMetodosPago.Dock = DockStyle.Fill;
            layoutMetodosPago.Location = new Point(0, 64);
            layoutMetodosPago.Margin = new Padding(0);
            layoutMetodosPago.Name = "layoutMetodosPago";
            layoutMetodosPago.Size = new Size(389, 162);
            layoutMetodosPago.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(layoutEncabezadosTabla, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));
            tableLayoutPanel1.Size = new Size(915, 482);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // layoutEncabezadosTabla
            // 
            layoutEncabezadosTabla.BackColor = Color.WhiteSmoke;
            layoutEncabezadosTabla.ColumnCount = 8;
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutEncabezadosTabla.Controls.Add(fieldTituloCantidadArticulo, 0, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloNombreArticulo, 0, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloId, 0, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloTotalArticulo, 4, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloPrecioArticulo, 3, 0);
            layoutEncabezadosTabla.Dock = DockStyle.Fill;
            layoutEncabezadosTabla.Location = new Point(0, 0);
            layoutEncabezadosTabla.Margin = new Padding(0, 0, 0, 2);
            layoutEncabezadosTabla.Name = "layoutEncabezadosTabla";
            layoutEncabezadosTabla.RowCount = 1;
            layoutEncabezadosTabla.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.Size = new Size(915, 62);
            layoutEncabezadosTabla.TabIndex = 20;
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
            fieldTituloId.Size = new Size(58, 60);
            fieldTituloId.TabIndex = 14;
            fieldTituloId.Text = "Id";
            fieldTituloId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloTotalArticulo
            // 
            fieldTituloTotalArticulo.Dock = DockStyle.Fill;
            fieldTituloTotalArticulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloTotalArticulo.ForeColor = Color.Black;
            fieldTituloTotalArticulo.ImeMode = ImeMode.NoControl;
            fieldTituloTotalArticulo.Location = new Point(686, 1);
            fieldTituloTotalArticulo.Margin = new Padding(1);
            fieldTituloTotalArticulo.Name = "fieldTituloTotalArticulo";
            fieldTituloTotalArticulo.Size = new Size(108, 60);
            fieldTituloTotalArticulo.TabIndex = 18;
            fieldTituloTotalArticulo.Text = "Total";
            fieldTituloTotalArticulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloNombreArticulo
            // 
            fieldTituloNombreArticulo.Dock = DockStyle.Fill;
            fieldTituloNombreArticulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloNombreArticulo.ForeColor = Color.Black;
            fieldTituloNombreArticulo.ImeMode = ImeMode.NoControl;
            fieldTituloNombreArticulo.Location = new Point(61, 1);
            fieldTituloNombreArticulo.Margin = new Padding(1);
            fieldTituloNombreArticulo.Name = "fieldTituloNombreArticulo";
            fieldTituloNombreArticulo.Size = new Size(403, 60);
            fieldTituloNombreArticulo.TabIndex = 19;
            fieldTituloNombreArticulo.Text = "Nombre del artículo";
            fieldTituloNombreArticulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloCantidadArticulo
            // 
            fieldTituloCantidadArticulo.Dock = DockStyle.Fill;
            fieldTituloCantidadArticulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloCantidadArticulo.ForeColor = Color.Black;
            fieldTituloCantidadArticulo.ImeMode = ImeMode.NoControl;
            fieldTituloCantidadArticulo.Location = new Point(466, 1);
            fieldTituloCantidadArticulo.Margin = new Padding(1);
            fieldTituloCantidadArticulo.Name = "fieldTituloCantidadArticulo";
            fieldTituloCantidadArticulo.Size = new Size(108, 60);
            fieldTituloCantidadArticulo.TabIndex = 20;
            fieldTituloCantidadArticulo.Text = "Cantidad";
            fieldTituloCantidadArticulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloPrecioArticulo
            // 
            fieldTituloPrecioArticulo.Dock = DockStyle.Fill;
            fieldTituloPrecioArticulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTituloPrecioArticulo.ForeColor = Color.Black;
            fieldTituloPrecioArticulo.ImeMode = ImeMode.NoControl;
            fieldTituloPrecioArticulo.Location = new Point(576, 1);
            fieldTituloPrecioArticulo.Margin = new Padding(1);
            fieldTituloPrecioArticulo.Name = "fieldTituloPrecioArticulo";
            fieldTituloPrecioArticulo.Size = new Size(108, 60);
            fieldTituloPrecioArticulo.TabIndex = 21;
            fieldTituloPrecioArticulo.Text = "Precio";
            fieldTituloPrecioArticulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VistaRegistroVenta
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1356, 608);
            Controls.Add(layoutVista);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaRegistroVenta";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroVenta";
            layoutVista.ResumeLayout(false);
            layoutHerramientas.ResumeLayout(false);
            layoutTituloHerramientas.ResumeLayout(false);
            layoutDistribución1.ResumeLayout(false);
            layoutDistribucionControlesVenta.ResumeLayout(false);
            layoutBotonesVenta.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            layoutEncabezadosTabla.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutVista;
        private Guna2Separator separador1;
        private TableLayoutPanel layoutTituloHerramientas;
        private Label fieldTituloFiltrosBusqueda;
        private TableLayoutPanel layoutHerramientas;
        private Guna2TextBox fieldDatoBusqueda;
        private Guna2ComboBox fieldCriterioBusqueda;
        private TableLayoutPanel layoutDistribución1;
        private TableLayoutPanel layoutDistribucionControlesVenta;
        private TableLayoutPanel layoutBotonesVenta;
        private Guna2Button btnCantidadArticulo;
        private Guna2Button btnNuevaVenta;
        private Guna2Button btnEliminarArticulo;
        private Guna2Button btnBuscarArticulo;
        private FlowLayoutPanel layoutMetodosPago;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel layoutEncabezadosTabla;
        private Label fieldTituloMonto;
        private Label fieldTituloCantidadArticulos;
        private Label fieldTituloId;
        private Label fieldTituloNombreCliente;
        private Label fieldTituloEstadoEntrega;
        private Label fieldTituloTotalArticulo;
        private Label fieldTituloNombreArticulo;
        private Label fieldTituloCantidadArticulo;
        private Label fieldTituloPrecioArticulo;
    }
}