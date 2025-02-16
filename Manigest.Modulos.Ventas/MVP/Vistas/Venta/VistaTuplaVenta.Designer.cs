using Guna.UI2.WinForms;

using System.ComponentModel;

namespace Manigest.Modulos.Ventas.MVP.Vistas.Venta {
    partial class VistaTuplaVenta {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaTuplaVenta));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            layoutBase = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            fieldId = new Label();
            fieldNombreAlmacen = new Label();
            fieldFecha = new Label();
            fieldNombreCliente = new Label();
            fieldCantidadProductos = new Label();
            fieldTotal = new Label();
            btnEditar = new Guna2Button();
            btnEliminar = new Guna2Button();
            symbolPeso = new Label();
            layoutBase.SuspendLayout();
            layoutVista.SuspendLayout();
            SuspendLayout();
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
            layoutVista.BackColor = Color.FromArgb(  248,   244,   242);
            layoutVista.ColumnCount = 11;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.Controls.Add(fieldId, 0, 0);
            layoutVista.Controls.Add(fieldNombreAlmacen, 2, 0);
            layoutVista.Controls.Add(fieldFecha, 1, 0);
            layoutVista.Controls.Add(fieldNombreCliente, 3, 0);
            layoutVista.Controls.Add(fieldCantidadProductos, 4, 0);
            layoutVista.Controls.Add(fieldTotal, 5, 0);
            layoutVista.Controls.Add(btnEditar, 9, 0);
            layoutVista.Controls.Add(btnEliminar, 10, 0);
            layoutVista.Controls.Add(symbolPeso, 6, 0);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(0, 0);
            layoutVista.Margin = new Padding(0, 0, 0, 2);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 1;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.Size = new Size(1241, 40);
            layoutVista.TabIndex = 19;
            // 
            // fieldId
            // 
            fieldId.Dock = DockStyle.Fill;
            fieldId.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            // fieldNombreAlmacen
            // 
            fieldNombreAlmacen.Dock = DockStyle.Fill;
            fieldNombreAlmacen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreAlmacen.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldNombreAlmacen.ImeMode = ImeMode.NoControl;
            fieldNombreAlmacen.Location = new Point(181, 1);
            fieldNombreAlmacen.Margin = new Padding(1);
            fieldNombreAlmacen.Name = "fieldNombreAlmacen";
            fieldNombreAlmacen.Size = new Size(118, 38);
            fieldNombreAlmacen.TabIndex = 19;
            fieldNombreAlmacen.Text = "nombreAlmacenOrigen";
            fieldNombreAlmacen.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldFecha
            // 
            fieldFecha.Dock = DockStyle.Fill;
            fieldFecha.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldFecha.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldFecha.ImeMode = ImeMode.NoControl;
            fieldFecha.Location = new Point(61, 1);
            fieldFecha.Margin = new Padding(1);
            fieldFecha.Name = "fieldFecha";
            fieldFecha.Size = new Size(118, 38);
            fieldFecha.TabIndex = 17;
            fieldFecha.Text = "fecha";
            fieldFecha.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldNombreCliente
            // 
            fieldNombreCliente.Dock = DockStyle.Fill;
            fieldNombreCliente.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreCliente.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldNombreCliente.ImeMode = ImeMode.NoControl;
            fieldNombreCliente.Location = new Point(301, 1);
            fieldNombreCliente.Margin = new Padding(1);
            fieldNombreCliente.Name = "fieldNombreCliente";
            fieldNombreCliente.Size = new Size(218, 38);
            fieldNombreCliente.TabIndex = 4;
            fieldNombreCliente.Text = "nombreCliente";
            fieldNombreCliente.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldCantidadProductos
            // 
            fieldCantidadProductos.AutoEllipsis = true;
            fieldCantidadProductos.Dock = DockStyle.Fill;
            fieldCantidadProductos.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldCantidadProductos.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldCantidadProductos.ImeMode = ImeMode.NoControl;
            fieldCantidadProductos.Location = new Point(521, 1);
            fieldCantidadProductos.Margin = new Padding(1);
            fieldCantidadProductos.Name = "fieldCantidadProductos";
            fieldCantidadProductos.Size = new Size(108, 38);
            fieldCantidadProductos.TabIndex = 6;
            fieldCantidadProductos.Text = "cantidad";
            fieldCantidadProductos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTotal
            // 
            fieldTotal.Dock = DockStyle.Fill;
            fieldTotal.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTotal.ForeColor = Color.Black;
            fieldTotal.ImeMode = ImeMode.NoControl;
            fieldTotal.Location = new Point(631, 1);
            fieldTotal.Margin = new Padding(1);
            fieldTotal.Name = "fieldTotal";
            fieldTotal.Size = new Size(108, 38);
            fieldTotal.TabIndex = 20;
            fieldTotal.Text = "total";
            fieldTotal.TextAlign = ContentAlignment.MiddleRight;
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
            btnEditar.Location = new Point(1164, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnEditar.Size = new Size(34, 34);
            btnEditar.TabIndex = 21;
            // 
            // btnEliminar
            // 
            btnEliminar.Animated = true;
            btnEliminar.BorderColor = Color.FromArgb(  217,   211,   204);
            btnEliminar.BorderRadius = 16;
            btnEliminar.BorderThickness = 1;
            btnEliminar.CustomImages.HoveredImage = (Image) resources.GetObject("resource.HoveredImage1");
            btnEliminar.CustomImages.Image = (Image) resources.GetObject("resource.Image1");
            btnEliminar.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEliminar.CustomizableEdges = customizableEdges3;
            btnEliminar.Dock = DockStyle.Fill;
            btnEliminar.Enabled = false;
            btnEliminar.FillColor = Color.FromArgb(  250,   250,   250);
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.HoverState.BorderColor = Color.FromArgb(  217,   211,   204);
            btnEliminar.HoverState.FillColor = Color.FromArgb(  217,   211,   204);
            btnEliminar.HoverState.ForeColor = Color.White;
            btnEliminar.Location = new Point(1204, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnEliminar.Size = new Size(34, 34);
            btnEliminar.TabIndex = 22;
            // 
            // symbolPeso
            // 
            symbolPeso.Dock = DockStyle.Fill;
            symbolPeso.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            symbolPeso.ForeColor = Color.Black;
            symbolPeso.ImageAlign = ContentAlignment.MiddleLeft;
            symbolPeso.ImeMode = ImeMode.NoControl;
            symbolPeso.Location = new Point(743, 5);
            symbolPeso.Margin = new Padding(3, 5, 3, 3);
            symbolPeso.Name = "symbolPeso";
            symbolPeso.Size = new Size(14, 32);
            symbolPeso.TabIndex = 30;
            symbolPeso.Text = "$";
            symbolPeso.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VistaTuplaVenta
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(  248,   244,   242);
            ClientSize = new Size(1241, 42);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaTuplaVenta";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaTuplaVenta";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutVista;
        private Label fieldId;
        private Label fieldNombreAlmacen;
        private Label fieldFecha;
        private Label fieldNombreCliente;
        private Label fieldCantidadProductos;
        private Label fieldTotal;
        private Guna2Button btnEditar;
        private Guna2Button btnEliminar;
        private Label symbolPeso;
    }
}