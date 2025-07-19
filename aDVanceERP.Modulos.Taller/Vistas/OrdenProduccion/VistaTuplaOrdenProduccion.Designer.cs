using Guna.UI2.WinForms;

using System.ComponentModel;

namespace aDVanceERP.Modulos.Taller.Vistas.OrdenProduccion {
    partial class VistaTuplaOrdenProduccion {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaTuplaOrdenProduccion));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            fieldEstado = new Label();
            simboloPeso1 = new Label();
            fieldCostoTotal = new Label();
            fieldObservaciones = new Label();
            fieldFechaCierre = new Label();
            fieldNumeroOrden = new Label();
            fieldId = new Label();
            fieldFechaApertura = new Label();
            fieldNombreProducto = new Label();
            btnEditar = new Guna2Button();
            btnEliminar = new Guna2Button();
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
            layoutBase.Size = new Size(1241, 42);
            layoutBase.TabIndex = 1;
            // 
            // layoutVista
            // 
            layoutVista.BackColor = Color.White;
            layoutVista.ColumnCount = 12;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.Controls.Add(fieldEstado, 6, 0);
            layoutVista.Controls.Add(simboloPeso1, 5, 0);
            layoutVista.Controls.Add(fieldCostoTotal, 4, 0);
            layoutVista.Controls.Add(fieldObservaciones, 8, 0);
            layoutVista.Controls.Add(fieldFechaCierre, 7, 0);
            layoutVista.Controls.Add(fieldNumeroOrden, 0, 0);
            layoutVista.Controls.Add(fieldId, 0, 0);
            layoutVista.Controls.Add(fieldFechaApertura, 2, 0);
            layoutVista.Controls.Add(fieldNombreProducto, 3, 0);
            layoutVista.Controls.Add(btnEditar, 10, 0);
            layoutVista.Controls.Add(btnEliminar, 11, 0);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(0, 0);
            layoutVista.Margin = new Padding(0, 0, 0, 1);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 1;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.Size = new Size(1241, 41);
            layoutVista.TabIndex = 12;
            // 
            // fieldEstado
            // 
            fieldEstado.Dock = DockStyle.Fill;
            fieldEstado.Font = new Font("Segoe UI", 11.25F);
            fieldEstado.ForeColor = Color.DimGray;
            fieldEstado.Image = Properties.Resources.open_sign_20px;
            fieldEstado.ImeMode = ImeMode.NoControl;
            fieldEstado.Location = new Point(597, 1);
            fieldEstado.Margin = new Padding(1);
            fieldEstado.Name = "fieldEstado";
            fieldEstado.Size = new Size(108, 39);
            fieldEstado.TabIndex = 35;
            fieldEstado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // simboloPeso1
            // 
            simboloPeso1.Dock = DockStyle.Fill;
            simboloPeso1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            simboloPeso1.ForeColor = Color.Black;
            simboloPeso1.ImageAlign = ContentAlignment.MiddleLeft;
            simboloPeso1.ImeMode = ImeMode.NoControl;
            simboloPeso1.Location = new Point(579, 5);
            simboloPeso1.Margin = new Padding(3, 5, 3, 3);
            simboloPeso1.Name = "simboloPeso1";
            simboloPeso1.Size = new Size(14, 33);
            simboloPeso1.TabIndex = 32;
            simboloPeso1.Text = "$";
            simboloPeso1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldCostoTotal
            // 
            fieldCostoTotal.Dock = DockStyle.Fill;
            fieldCostoTotal.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldCostoTotal.ForeColor = Color.Black;
            fieldCostoTotal.ImeMode = ImeMode.NoControl;
            fieldCostoTotal.Location = new Point(467, 1);
            fieldCostoTotal.Margin = new Padding(1);
            fieldCostoTotal.Name = "fieldCostoTotal";
            fieldCostoTotal.Size = new Size(108, 39);
            fieldCostoTotal.TabIndex = 23;
            fieldCostoTotal.Text = "costoTotal";
            fieldCostoTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldObservaciones
            // 
            fieldObservaciones.Dock = DockStyle.Fill;
            fieldObservaciones.Font = new Font("Segoe UI", 11.25F);
            fieldObservaciones.ForeColor = Color.DimGray;
            fieldObservaciones.ImeMode = ImeMode.NoControl;
            fieldObservaciones.Location = new Point(857, 1);
            fieldObservaciones.Margin = new Padding(1);
            fieldObservaciones.Name = "fieldObservaciones";
            fieldObservaciones.Size = new Size(262, 39);
            fieldObservaciones.TabIndex = 22;
            fieldObservaciones.Text = "Observaciones";
            fieldObservaciones.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldFechaCierre
            // 
            fieldFechaCierre.Dock = DockStyle.Fill;
            fieldFechaCierre.Font = new Font("Segoe UI", 11.25F);
            fieldFechaCierre.ForeColor = Color.DimGray;
            fieldFechaCierre.ImeMode = ImeMode.NoControl;
            fieldFechaCierre.Location = new Point(707, 1);
            fieldFechaCierre.Margin = new Padding(1);
            fieldFechaCierre.Name = "fieldFechaCierre";
            fieldFechaCierre.Size = new Size(148, 39);
            fieldFechaCierre.TabIndex = 21;
            fieldFechaCierre.Text = "Fecha de cierre";
            fieldFechaCierre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldNumeroOrden
            // 
            fieldNumeroOrden.Dock = DockStyle.Fill;
            fieldNumeroOrden.Font = new Font("Segoe UI", 11.25F);
            fieldNumeroOrden.ForeColor = Color.DimGray;
            fieldNumeroOrden.ImeMode = ImeMode.NoControl;
            fieldNumeroOrden.Location = new Point(61, 1);
            fieldNumeroOrden.Margin = new Padding(1);
            fieldNumeroOrden.Name = "fieldNumeroOrden";
            fieldNumeroOrden.Size = new Size(78, 39);
            fieldNumeroOrden.TabIndex = 15;
            fieldNumeroOrden.Text = "Nro.Orden";
            fieldNumeroOrden.TextAlign = ContentAlignment.MiddleCenter;
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
            fieldId.TabIndex = 14;
            fieldId.Text = "Id";
            fieldId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldFechaApertura
            // 
            fieldFechaApertura.Dock = DockStyle.Fill;
            fieldFechaApertura.Font = new Font("Segoe UI", 11.25F);
            fieldFechaApertura.ForeColor = Color.DimGray;
            fieldFechaApertura.ImeMode = ImeMode.NoControl;
            fieldFechaApertura.Location = new Point(141, 1);
            fieldFechaApertura.Margin = new Padding(1);
            fieldFechaApertura.Name = "fieldFechaApertura";
            fieldFechaApertura.Size = new Size(148, 39);
            fieldFechaApertura.TabIndex = 4;
            fieldFechaApertura.Text = "Fecha de apertura";
            fieldFechaApertura.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldNombreProducto
            // 
            fieldNombreProducto.AutoEllipsis = true;
            fieldNombreProducto.Dock = DockStyle.Fill;
            fieldNombreProducto.Font = new Font("Segoe UI", 11.25F);
            fieldNombreProducto.ForeColor = Color.DimGray;
            fieldNombreProducto.ImeMode = ImeMode.NoControl;
            fieldNombreProducto.Location = new Point(291, 1);
            fieldNombreProducto.Margin = new Padding(1);
            fieldNombreProducto.Name = "fieldNombreProducto";
            fieldNombreProducto.Size = new Size(174, 39);
            fieldNombreProducto.TabIndex = 5;
            fieldNombreProducto.Text = "Producto";
            fieldNombreProducto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnEditar
            // 
            btnEditar.Animated = true;
            btnEditar.BorderColor = Color.Gainsboro;
            btnEditar.BorderRadius = 16;
            btnEditar.BorderThickness = 1;
            btnEditar.CustomImages.HoveredImage = (Image) resources.GetObject("resource.HoveredImage");
            btnEditar.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnEditar.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEditar.CustomizableEdges = customizableEdges9;
            btnEditar.Dock = DockStyle.Fill;
            btnEditar.FillColor = Color.White;
            btnEditar.Font = new Font("Segoe UI", 9.75F);
            btnEditar.ForeColor = Color.White;
            btnEditar.HoverState.BorderColor = Color.PeachPuff;
            btnEditar.HoverState.FillColor = Color.PeachPuff;
            btnEditar.Location = new Point(1163, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnEditar.Size = new Size(34, 35);
            btnEditar.TabIndex = 36;
            // 
            // btnEliminar
            // 
            btnEliminar.Animated = true;
            btnEliminar.BorderColor = Color.Gainsboro;
            btnEliminar.BorderRadius = 16;
            btnEliminar.BorderThickness = 1;
            btnEliminar.CustomImages.HoveredImage = (Image) resources.GetObject("resource.HoveredImage1");
            btnEliminar.CustomImages.Image = (Image) resources.GetObject("resource.Image1");
            btnEliminar.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEliminar.CustomizableEdges = customizableEdges11;
            btnEliminar.Dock = DockStyle.Fill;
            btnEliminar.FillColor = Color.White;
            btnEliminar.Font = new Font("Segoe UI", 9.75F);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.HoverState.BorderColor = Color.PeachPuff;
            btnEliminar.HoverState.FillColor = Color.PeachPuff;
            btnEliminar.HoverState.ForeColor = Color.White;
            btnEliminar.Location = new Point(1203, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnEliminar.Size = new Size(35, 35);
            btnEliminar.TabIndex = 37;
            // 
            // VistaTuplaOrdenProduccion
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1241, 42);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaTuplaOrdenProduccion";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaTuplaOrdenProduccion";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutVista;
        private Label fieldObservaciones;
        private Label fieldFechaCierre;
        private Label fieldNumeroOrden;
        private Label fieldId;
        private Label fieldFechaApertura;
        private Label fieldNombreProducto;
        private Label fieldCostoTotal;
        private Label simboloPeso1;
        private Label fieldEstado;
        private Guna2Button btnEditar;
        private Guna2Button btnEliminar;
    }
}