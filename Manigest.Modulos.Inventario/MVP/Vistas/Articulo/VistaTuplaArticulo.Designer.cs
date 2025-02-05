using Guna.UI2.WinForms;

using System.ComponentModel;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Articulo {
    partial class VistaTuplaArticulo {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaTuplaArticulo));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            fieldNombreAlmacen = new Label();
            fieldId = new Label();
            fieldStock = new Label();
            btnEditar = new Guna2Button();
            btnMovimientoNegativo = new Guna2Button();
            btnMovimientoPositivo = new Guna2Button();
            fieldDescripcion = new Label();
            fieldNombre = new Label();
            fieldPrecioCesion = new Label();
            fieldPrecioAdquisicion = new Label();
            fieldCodigo = new Label();
            layoutBase.SuspendLayout();
            layoutVista.SuspendLayout();
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
            layoutBase.BackColor = Color.FromArgb(  217,   211,   204);
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
            layoutVista.BackColor = Color.FromArgb(  250,   250,   250);
            layoutVista.ColumnCount = 12;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.Controls.Add(fieldNombreAlmacen, 0, 0);
            layoutVista.Controls.Add(fieldId, 0, 0);
            layoutVista.Controls.Add(fieldStock, 7, 0);
            layoutVista.Controls.Add(btnEditar, 11, 0);
            layoutVista.Controls.Add(btnMovimientoNegativo, 10, 0);
            layoutVista.Controls.Add(btnMovimientoPositivo, 9, 0);
            layoutVista.Controls.Add(fieldDescripcion, 4, 0);
            layoutVista.Controls.Add(fieldNombre, 3, 0);
            layoutVista.Controls.Add(fieldPrecioCesion, 6, 0);
            layoutVista.Controls.Add(fieldPrecioAdquisicion, 5, 0);
            layoutVista.Controls.Add(fieldCodigo, 2, 0);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(0, 0);
            layoutVista.Margin = new Padding(0, 0, 0, 2);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 1;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.Size = new Size(1241, 40);
            layoutVista.TabIndex = 18;
            // 
            // fieldNombreAlmacen
            // 
            fieldNombreAlmacen.Dock = DockStyle.Fill;
            fieldNombreAlmacen.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreAlmacen.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldNombreAlmacen.ImeMode = ImeMode.NoControl;
            fieldNombreAlmacen.Location = new Point(61, 1);
            fieldNombreAlmacen.Margin = new Padding(1);
            fieldNombreAlmacen.Name = "fieldNombreAlmacen";
            fieldNombreAlmacen.Size = new Size(118, 38);
            fieldNombreAlmacen.TabIndex = 20;
            fieldNombreAlmacen.Text = "nombreAlmacen";
            fieldNombreAlmacen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldId
            // 
            fieldId.Dock = DockStyle.Fill;
            fieldId.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldId.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldId.ImeMode = ImeMode.NoControl;
            fieldId.Location = new Point(1, 1);
            fieldId.Margin = new Padding(1);
            fieldId.Name = "fieldId";
            fieldId.Size = new Size(58, 38);
            fieldId.TabIndex = 13;
            fieldId.Text = "id";
            fieldId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldStock
            // 
            fieldStock.Dock = DockStyle.Fill;
            fieldStock.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldStock.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldStock.ImeMode = ImeMode.NoControl;
            fieldStock.Location = new Point(991, 1);
            fieldStock.Margin = new Padding(1);
            fieldStock.Name = "fieldStock";
            fieldStock.Size = new Size(108, 38);
            fieldStock.TabIndex = 16;
            fieldStock.Text = "stock";
            fieldStock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEditar
            // 
            btnEditar.Animated = true;
            btnEditar.BorderColor = Color.FromArgb(  217,   211,   204);
            btnEditar.BorderRadius = 16;
            btnEditar.BorderThickness = 1;
            btnEditar.CustomImages.HoveredImage = (Image) resources.GetObject("resource.HoveredImage");
            btnEditar.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnEditar.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEditar.CustomizableEdges = customizableEdges1;
            btnEditar.Dock = DockStyle.Fill;
            btnEditar.FillColor = Color.FromArgb(  250,   250,   250);
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditar.ForeColor = Color.White;
            btnEditar.HoverState.BorderColor = Color.FromArgb(  217,   211,   204);
            btnEditar.HoverState.FillColor = Color.FromArgb(  217,   211,   204);
            btnEditar.Location = new Point(1204, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnEditar.Size = new Size(34, 34);
            btnEditar.TabIndex = 9;
            // 
            // btnMovimientoNegativo
            // 
            btnMovimientoNegativo.Animated = true;
            btnMovimientoNegativo.BorderColor = Color.FromArgb(  217,   211,   204);
            btnMovimientoNegativo.BorderRadius = 16;
            btnMovimientoNegativo.BorderThickness = 1;
            btnMovimientoNegativo.CustomImages.HoveredImage = (Image) resources.GetObject("resource.HoveredImage1");
            btnMovimientoNegativo.CustomImages.Image = (Image) resources.GetObject("resource.Image1");
            btnMovimientoNegativo.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnMovimientoNegativo.CustomizableEdges = customizableEdges3;
            btnMovimientoNegativo.Dock = DockStyle.Fill;
            btnMovimientoNegativo.FillColor = Color.FromArgb(  250,   250,   250);
            btnMovimientoNegativo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnMovimientoNegativo.ForeColor = Color.White;
            btnMovimientoNegativo.HoverState.BorderColor = Color.FromArgb(  217,   211,   204);
            btnMovimientoNegativo.HoverState.FillColor = Color.FromArgb(  217,   211,   204);
            btnMovimientoNegativo.Location = new Point(1164, 3);
            btnMovimientoNegativo.Name = "btnMovimientoNegativo";
            btnMovimientoNegativo.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnMovimientoNegativo.Size = new Size(34, 34);
            btnMovimientoNegativo.TabIndex = 18;
            // 
            // btnMovimientoPositivo
            // 
            btnMovimientoPositivo.Animated = true;
            btnMovimientoPositivo.BorderColor = Color.FromArgb(  217,   211,   204);
            btnMovimientoPositivo.BorderRadius = 16;
            btnMovimientoPositivo.BorderThickness = 1;
            btnMovimientoPositivo.CustomImages.HoveredImage = (Image) resources.GetObject("resource.HoveredImage2");
            btnMovimientoPositivo.CustomImages.Image = (Image) resources.GetObject("resource.Image2");
            btnMovimientoPositivo.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnMovimientoPositivo.CustomizableEdges = customizableEdges5;
            btnMovimientoPositivo.Dock = DockStyle.Fill;
            btnMovimientoPositivo.FillColor = Color.FromArgb(  250,   250,   250);
            btnMovimientoPositivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnMovimientoPositivo.ForeColor = Color.White;
            btnMovimientoPositivo.HoverState.BorderColor = Color.FromArgb(  217,   211,   204);
            btnMovimientoPositivo.HoverState.FillColor = Color.FromArgb(  217,   211,   204);
            btnMovimientoPositivo.Location = new Point(1124, 3);
            btnMovimientoPositivo.Name = "btnMovimientoPositivo";
            btnMovimientoPositivo.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnMovimientoPositivo.Size = new Size(34, 34);
            btnMovimientoPositivo.TabIndex = 19;
            // 
            // fieldDescripcion
            // 
            fieldDescripcion.AutoEllipsis = true;
            fieldDescripcion.Dock = DockStyle.Fill;
            fieldDescripcion.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldDescripcion.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldDescripcion.ImeMode = ImeMode.NoControl;
            fieldDescripcion.Location = new Point(521, 1);
            fieldDescripcion.Margin = new Padding(1);
            fieldDescripcion.Name = "fieldDescripcion";
            fieldDescripcion.Size = new Size(248, 38);
            fieldDescripcion.TabIndex = 6;
            fieldDescripcion.Text = "descripcion";
            fieldDescripcion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldNombre
            // 
            fieldNombre.Dock = DockStyle.Fill;
            fieldNombre.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombre.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldNombre.ImeMode = ImeMode.NoControl;
            fieldNombre.Location = new Point(301, 1);
            fieldNombre.Margin = new Padding(1);
            fieldNombre.Name = "fieldNombre";
            fieldNombre.Size = new Size(218, 38);
            fieldNombre.TabIndex = 4;
            fieldNombre.Text = "nombre";
            fieldNombre.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldPrecioCesion
            // 
            fieldPrecioCesion.Dock = DockStyle.Fill;
            fieldPrecioCesion.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldPrecioCesion.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldPrecioCesion.ImeMode = ImeMode.NoControl;
            fieldPrecioCesion.Location = new Point(881, 1);
            fieldPrecioCesion.Margin = new Padding(1);
            fieldPrecioCesion.Name = "fieldPrecioCesion";
            fieldPrecioCesion.Size = new Size(108, 38);
            fieldPrecioCesion.TabIndex = 17;
            fieldPrecioCesion.Text = "precioCesion";
            fieldPrecioCesion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldPrecioAdquisicion
            // 
            fieldPrecioAdquisicion.Dock = DockStyle.Fill;
            fieldPrecioAdquisicion.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldPrecioAdquisicion.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldPrecioAdquisicion.ImeMode = ImeMode.NoControl;
            fieldPrecioAdquisicion.Location = new Point(771, 1);
            fieldPrecioAdquisicion.Margin = new Padding(1);
            fieldPrecioAdquisicion.Name = "fieldPrecioAdquisicion";
            fieldPrecioAdquisicion.Size = new Size(108, 38);
            fieldPrecioAdquisicion.TabIndex = 14;
            fieldPrecioAdquisicion.Text = "precioAdq.";
            fieldPrecioAdquisicion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldCodigo
            // 
            fieldCodigo.Dock = DockStyle.Fill;
            fieldCodigo.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldCodigo.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldCodigo.ImeMode = ImeMode.NoControl;
            fieldCodigo.Location = new Point(181, 1);
            fieldCodigo.Margin = new Padding(1);
            fieldCodigo.Name = "fieldCodigo";
            fieldCodigo.Size = new Size(118, 38);
            fieldCodigo.TabIndex = 15;
            fieldCodigo.Text = "codigo";
            fieldCodigo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VistaTuplaArticulo
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1241, 42);
            Controls.Add(layoutBase);
            Font = new Font("Microsoft PhagsPa", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaTuplaArticulo";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaTuplaArticulo";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutVista;
        private Label fieldNombre;
        private Label fieldId;
        private Guna2Button btnEditar;
        private Label fieldPrecioAdquisicion;
        private Label fieldDescripcion;
        private Label fieldCodigo;
        private Label fieldStock;
        private Label fieldPrecioCesion;
        private Guna2Button btnMovimientoNegativo;
        private Guna2Button btnMovimientoPositivo;
        private Label fieldNombreAlmacen;
    }
}