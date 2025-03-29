using Guna.UI2.WinForms;

using System.ComponentModel;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaArticulo {
    partial class VistaTuplaDetalleCompraventaArticulo {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaTuplaDetalleCompraventaArticulo));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            btnEliminar = new Guna2Button();
            fieldNombreArticulo = new Label();
            fieldCantidad = new Label();
            fieldPrecio = new Guna2TextBox();
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
            layoutBase.BackColor = Color.Gainsboro;
            layoutBase.ColumnCount = 1;
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutBase.Controls.Add(layoutVista, 0, 0);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 1;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutBase.Size = new Size(417, 42);
            layoutBase.TabIndex = 0;
            // 
            // layoutVista
            // 
            layoutVista.BackColor = Color.White;
            layoutVista.ColumnCount = 4;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.Controls.Add(fieldPrecio, 0, 0);
            layoutVista.Controls.Add(btnEliminar, 3, 0);
            layoutVista.Controls.Add(fieldNombreArticulo, 0, 0);
            layoutVista.Controls.Add(fieldCantidad, 2, 0);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(0, 0);
            layoutVista.Margin = new Padding(0, 0, 0, 1);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 1;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.Size = new Size(417, 41);
            layoutVista.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.Animated = true;
            btnEliminar.BorderColor = Color.Gainsboro;
            btnEliminar.BorderRadius = 16;
            btnEliminar.BorderThickness = 1;
            btnEliminar.CustomImages.HoveredImage = (Image) resources.GetObject("resource.HoveredImage");
            btnEliminar.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnEliminar.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEliminar.CustomizableEdges = customizableEdges5;
            btnEliminar.Dock = DockStyle.Fill;
            btnEliminar.FillColor = Color.White;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.HoverState.BorderColor = Color.PeachPuff;
            btnEliminar.HoverState.FillColor = Color.PeachPuff;
            btnEliminar.HoverState.ForeColor = Color.White;
            btnEliminar.Location = new Point(380, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnEliminar.Size = new Size(34, 35);
            btnEliminar.TabIndex = 0;
            // 
            // fieldNombreArticulo
            // 
            fieldNombreArticulo.Dock = DockStyle.Fill;
            fieldNombreArticulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreArticulo.ForeColor = Color.DimGray;
            fieldNombreArticulo.ImeMode = ImeMode.NoControl;
            fieldNombreArticulo.Location = new Point(1, 1);
            fieldNombreArticulo.Margin = new Padding(1);
            fieldNombreArticulo.Name = "fieldNombreArticulo";
            fieldNombreArticulo.Size = new Size(195, 39);
            fieldNombreArticulo.TabIndex = 1;
            fieldNombreArticulo.Text = "nombreArticulo";
            fieldNombreArticulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldCantidad
            // 
            fieldCantidad.Dock = DockStyle.Fill;
            fieldCantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldCantidad.ForeColor = Color.DimGray;
            fieldCantidad.ImeMode = ImeMode.NoControl;
            fieldCantidad.Location = new Point(328, 1);
            fieldCantidad.Margin = new Padding(1);
            fieldCantidad.Name = "fieldCantidad";
            fieldCantidad.Size = new Size(48, 39);
            fieldCantidad.TabIndex = 4;
            fieldCantidad.Text = "cant.";
            fieldCantidad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldPrecio
            // 
            fieldPrecio.Animated = true;
            fieldPrecio.BorderColor = Color.Gainsboro;
            fieldPrecio.BorderRadius = 16;
            fieldPrecio.Cursor = Cursors.IBeam;
            fieldPrecio.CustomizableEdges = customizableEdges7;
            fieldPrecio.DefaultText = "";
            fieldPrecio.DisabledState.BorderColor = Color.White;
            fieldPrecio.DisabledState.ForeColor = Color.DimGray;
            fieldPrecio.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldPrecio.Dock = DockStyle.Fill;
            fieldPrecio.FocusedState.BorderColor = Color.SandyBrown;
            fieldPrecio.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldPrecio.ForeColor = Color.Black;
            fieldPrecio.HoverState.BorderColor = Color.SandyBrown;
            fieldPrecio.IconLeftOffset = new Point(10, 0);
            fieldPrecio.IconRight = (Image) resources.GetObject("fieldPrecio.IconRight");
            fieldPrecio.IconRightOffset = new Point(6, 0);
            fieldPrecio.IconRightSize = new Size(12, 12);
            fieldPrecio.Location = new Point(200, 3);
            fieldPrecio.Name = "fieldPrecio";
            fieldPrecio.PasswordChar = '\0';
            fieldPrecio.PlaceholderForeColor = Color.DimGray;
            fieldPrecio.PlaceholderText = "Precio";
            fieldPrecio.SelectedText = "";
            fieldPrecio.ShadowDecoration.CustomizableEdges = customizableEdges8;
            fieldPrecio.Size = new Size(124, 35);
            fieldPrecio.TabIndex = 5;
            fieldPrecio.TextAlign = HorizontalAlignment.Right;
            fieldPrecio.TextOffset = new Point(5, 0);
            // 
            // VistaTuplaDetalleCompraventaArticulo
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(417, 42);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaTuplaDetalleCompraventaArticulo";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaTuplaDetalleVentaArticulo";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutVista;
        private Guna2Button btnEliminar;
        private Label fieldNombreArticulo;
        private Label fieldCantidad;
        private Guna2TextBox fieldPrecio;
    }
}