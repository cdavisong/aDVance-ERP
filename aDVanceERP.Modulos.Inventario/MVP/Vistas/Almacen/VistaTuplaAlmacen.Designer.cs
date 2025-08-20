using Guna.UI2.WinForms;

using System.ComponentModel;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen {
    partial class VistaTuplaAlmacen {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaTuplaAlmacen));
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
            layoutVista = new TableLayoutPanel();
            btnEliminar = new Guna2Button();
            fieldId = new Label();
            btnEditar = new Guna2Button();
            fieldNotas = new Label();
            btnExportarProductos = new Guna2Button();
            btnExportarDocumentoInventario = new Guna2Button();
            fieldDireccion = new Label();
            fieldNombre = new Label();
            menuFormatoDocumento = new ContextMenuStrip(components);
            btnExportarPdf = new ToolStripMenuItem();
            btnExportarXlsx = new ToolStripMenuItem();
            layoutBase.SuspendLayout();
            layoutVista.SuspendLayout();
            menuFormatoDocumento.SuspendLayout();
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
            layoutBase.BackColor = Color.Gainsboro;
            layoutBase.ColumnCount = 1;
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutBase.Controls.Add(layoutVista, 0, 0);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 1;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutBase.Size = new Size(1241, 42);
            layoutBase.TabIndex = 1;
            // 
            // layoutVista
            // 
            layoutVista.BackColor = Color.White;
            layoutVista.ColumnCount = 9;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.Controls.Add(btnEliminar, 8, 0);
            layoutVista.Controls.Add(fieldId, 0, 0);
            layoutVista.Controls.Add(btnEditar, 7, 0);
            layoutVista.Controls.Add(fieldNotas, 3, 0);
            layoutVista.Controls.Add(btnExportarProductos, 5, 0);
            layoutVista.Controls.Add(btnExportarDocumentoInventario, 6, 0);
            layoutVista.Controls.Add(fieldDireccion, 2, 0);
            layoutVista.Controls.Add(fieldNombre, 1, 0);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(0, 0);
            layoutVista.Margin = new Padding(0, 0, 0, 1);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 1;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.Size = new Size(1241, 41);
            layoutVista.TabIndex = 18;
            // 
            // btnEliminar
            // 
            btnEliminar.Animated = true;
            btnEliminar.BorderColor = Color.Gainsboro;
            btnEliminar.BorderRadius = 16;
            btnEliminar.BorderThickness = 1;
            btnEliminar.CustomImages.HoveredImage = (Image)resources.GetObject("resource.HoveredImage");
            btnEliminar.CustomImages.Image = (Image)resources.GetObject("resource.Image");
            btnEliminar.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEliminar.CustomizableEdges = customizableEdges9;
            btnEliminar.Dock = DockStyle.Fill;
            btnEliminar.FillColor = Color.White;
            btnEliminar.Font = new Font("Segoe UI", 9.75F);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.HoverState.BorderColor = Color.PeachPuff;
            btnEliminar.HoverState.FillColor = Color.PeachPuff;
            btnEliminar.HoverState.ForeColor = Color.White;
            btnEliminar.Location = new Point(1204, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnEliminar.Size = new Size(34, 35);
            btnEliminar.TabIndex = 11;
            // 
            // fieldId
            // 
            fieldId.Dock = DockStyle.Fill;
            fieldId.Font = new Font("Segoe UI", 11.25F);
            fieldId.ForeColor = Color.DimGray;
            fieldId.ImeMode = ImeMode.NoControl;
            fieldId.Location = new Point(1, 1);
            fieldId.Margin = new Padding(1);
            fieldId.Name = "fieldId";
            fieldId.Size = new Size(58, 39);
            fieldId.TabIndex = 13;
            fieldId.Text = "id";
            fieldId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEditar
            // 
            btnEditar.Animated = true;
            btnEditar.BorderColor = Color.Gainsboro;
            btnEditar.BorderRadius = 16;
            btnEditar.BorderThickness = 1;
            btnEditar.CustomImages.HoveredImage = (Image)resources.GetObject("resource.HoveredImage1");
            btnEditar.CustomImages.Image = (Image)resources.GetObject("resource.Image1");
            btnEditar.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEditar.CustomizableEdges = customizableEdges11;
            btnEditar.Dock = DockStyle.Fill;
            btnEditar.FillColor = Color.White;
            btnEditar.Font = new Font("Segoe UI", 9.75F);
            btnEditar.ForeColor = Color.White;
            btnEditar.HoverState.BorderColor = Color.PeachPuff;
            btnEditar.HoverState.FillColor = Color.PeachPuff;
            btnEditar.Location = new Point(1164, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnEditar.Size = new Size(34, 35);
            btnEditar.TabIndex = 9;
            // 
            // fieldNotas
            // 
            fieldNotas.Dock = DockStyle.Fill;
            fieldNotas.Font = new Font("Segoe UI", 11.25F);
            fieldNotas.ForeColor = Color.DimGray;
            fieldNotas.ImeMode = ImeMode.NoControl;
            fieldNotas.Location = new Point(581, 1);
            fieldNotas.Margin = new Padding(1);
            fieldNotas.Name = "fieldNotas";
            fieldNotas.Size = new Size(298, 39);
            fieldNotas.TabIndex = 14;
            fieldNotas.Text = "notas";
            fieldNotas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnExportarProductos
            // 
            btnExportarProductos.Animated = true;
            btnExportarProductos.BorderColor = Color.Gainsboro;
            btnExportarProductos.BorderRadius = 16;
            btnExportarProductos.BorderThickness = 1;
            btnExportarProductos.CustomImages.HoveredImage = (Image)resources.GetObject("resource.HoveredImage2");
            btnExportarProductos.CustomImages.Image = (Image)resources.GetObject("resource.Image2");
            btnExportarProductos.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnExportarProductos.CustomizableEdges = customizableEdges13;
            btnExportarProductos.Dock = DockStyle.Fill;
            btnExportarProductos.FillColor = Color.White;
            btnExportarProductos.Font = new Font("Segoe UI", 9.75F);
            btnExportarProductos.ForeColor = Color.White;
            btnExportarProductos.HoverState.BorderColor = Color.PeachPuff;
            btnExportarProductos.HoverState.FillColor = Color.PeachPuff;
            btnExportarProductos.Location = new Point(1084, 3);
            btnExportarProductos.Name = "btnExportarProductos";
            btnExportarProductos.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnExportarProductos.Size = new Size(34, 35);
            btnExportarProductos.TabIndex = 15;
            // 
            // btnExportarDocumentoInventario
            // 
            btnExportarDocumentoInventario.Animated = true;
            btnExportarDocumentoInventario.BorderColor = Color.Gainsboro;
            btnExportarDocumentoInventario.BorderRadius = 16;
            btnExportarDocumentoInventario.BorderThickness = 1;
            btnExportarDocumentoInventario.ContextMenuStrip = menuFormatoDocumento;
            btnExportarDocumentoInventario.CustomImages.HoveredImage = (Image)resources.GetObject("resource.HoveredImage3");
            btnExportarDocumentoInventario.CustomImages.Image = (Image)resources.GetObject("resource.Image3");
            btnExportarDocumentoInventario.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnExportarDocumentoInventario.CustomizableEdges = customizableEdges15;
            btnExportarDocumentoInventario.Dock = DockStyle.Fill;
            btnExportarDocumentoInventario.FillColor = Color.White;
            btnExportarDocumentoInventario.Font = new Font("Segoe UI", 9.75F);
            btnExportarDocumentoInventario.ForeColor = Color.White;
            btnExportarDocumentoInventario.HoverState.BorderColor = Color.PeachPuff;
            btnExportarDocumentoInventario.HoverState.FillColor = Color.PeachPuff;
            btnExportarDocumentoInventario.Location = new Point(1124, 3);
            btnExportarDocumentoInventario.Name = "btnExportarDocumentoInventario";
            btnExportarDocumentoInventario.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnExportarDocumentoInventario.Size = new Size(34, 35);
            btnExportarDocumentoInventario.TabIndex = 16;
            // 
            // fieldDireccion
            // 
            fieldDireccion.AutoEllipsis = true;
            fieldDireccion.Dock = DockStyle.Fill;
            fieldDireccion.Font = new Font("Segoe UI", 11.25F);
            fieldDireccion.ForeColor = Color.DimGray;
            fieldDireccion.ImeMode = ImeMode.NoControl;
            fieldDireccion.Location = new Point(281, 1);
            fieldDireccion.Margin = new Padding(1);
            fieldDireccion.Name = "fieldDireccion";
            fieldDireccion.Size = new Size(298, 39);
            fieldDireccion.TabIndex = 6;
            fieldDireccion.Text = "direccion";
            fieldDireccion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldNombre
            // 
            fieldNombre.Dock = DockStyle.Fill;
            fieldNombre.Font = new Font("Segoe UI", 11.25F);
            fieldNombre.ForeColor = Color.DimGray;
            fieldNombre.ImeMode = ImeMode.NoControl;
            fieldNombre.Location = new Point(61, 1);
            fieldNombre.Margin = new Padding(1);
            fieldNombre.Name = "fieldNombre";
            fieldNombre.Size = new Size(218, 39);
            fieldNombre.TabIndex = 4;
            fieldNombre.Text = "nombre";
            fieldNombre.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // menuFormatoDocumento
            // 
            menuFormatoDocumento.BackColor = Color.White;
            menuFormatoDocumento.Items.AddRange(new ToolStripItem[] { btnExportarPdf, btnExportarXlsx });
            menuFormatoDocumento.Name = "menuGastoIndirecto";
            menuFormatoDocumento.Size = new Size(185, 78);
            // 
            // btnExportarPdf
            // 
            btnExportarPdf.BackColor = Color.White;
            btnExportarPdf.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportarPdf.Image = (Image)resources.GetObject("btnExportarPdf.Image");
            btnExportarPdf.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportarPdf.ImageScaling = ToolStripItemImageScaling.None;
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(184, 26);
            btnExportarPdf.Text = "PDF";
            btnExportarPdf.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnExportarXlsx
            // 
            btnExportarXlsx.BackColor = Color.White;
            btnExportarXlsx.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExportarXlsx.Image = (Image)resources.GetObject("btnExportarXlsx.Image");
            btnExportarXlsx.ImageAlign = ContentAlignment.MiddleLeft;
            btnExportarXlsx.ImageScaling = ToolStripItemImageScaling.None;
            btnExportarXlsx.Name = "btnExportarXlsx";
            btnExportarXlsx.Size = new Size(184, 26);
            btnExportarXlsx.Text = "XLSX";
            btnExportarXlsx.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VistaTuplaAlmacen
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1241, 42);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaTuplaAlmacen";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaTuplaAlmacen";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            menuFormatoDocumento.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutVista;
        private Guna2Button btnEliminar;
        private Label fieldNombre;
        private Label fieldId;
        private Guna2Button btnEditar;
        private Label fieldNotas;
        private Label fieldDireccion;
        private Guna2Button btnExportarProductos;
        private Guna2Button btnExportarDocumentoInventario;
        private ContextMenuStrip menuFormatoDocumento;
        private ToolStripMenuItem btnExportarPdf;
        private ToolStripMenuItem btnExportarXlsx;
    }
}