using Guna.UI2.WinForms;

using System.ComponentModel;

namespace aDVanceERP.Modulos.Taller.Vistas.CostosProduccion {
    partial class VistaTuplaCostoDirecto {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaTuplaCostoDirecto));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            fieldId = new Label();
            btnEditar = new Guna2Button();
            fieldManoObraDirecta = new Label();
            fieldCostoIndirecto = new Label();
            fieldFecha = new Label();
            btnEliminar = new Guna2Button();
            fieldNombre = new Label();
            fieldMateriaPrimaDirecta = new Label();
            fieldCostoTotal = new Label();
            fieldObservaciones = new Label();
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
            layoutVista.ColumnCount = 10;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.Controls.Add(fieldId, 0, 0);
            layoutVista.Controls.Add(btnEditar, 8, 0);
            layoutVista.Controls.Add(fieldManoObraDirecta, 3, 0);
            layoutVista.Controls.Add(fieldCostoIndirecto, 5, 0);
            layoutVista.Controls.Add(fieldFecha, 1, 0);
            layoutVista.Controls.Add(btnEliminar, 9, 0);
            layoutVista.Controls.Add(fieldNombre, 1, 0);
            layoutVista.Controls.Add(fieldMateriaPrimaDirecta, 3, 0);
            layoutVista.Controls.Add(fieldCostoTotal, 6, 0);
            layoutVista.Controls.Add(fieldObservaciones, 7, 0);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(0, 0);
            layoutVista.Margin = new Padding(0, 0, 0, 1);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 1;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.Size = new Size(1241, 41);
            layoutVista.TabIndex = 18;
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
            btnEditar.CustomImages.HoveredImage = (Image) resources.GetObject("resource.HoveredImage");
            btnEditar.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnEditar.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEditar.CustomizableEdges = customizableEdges5;
            btnEditar.Dock = DockStyle.Fill;
            btnEditar.FillColor = Color.White;
            btnEditar.Font = new Font("Segoe UI", 9.75F);
            btnEditar.ForeColor = Color.White;
            btnEditar.HoverState.BorderColor = Color.PeachPuff;
            btnEditar.HoverState.FillColor = Color.PeachPuff;
            btnEditar.Location = new Point(1163, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnEditar.Size = new Size(34, 35);
            btnEditar.TabIndex = 9;
            // 
            // fieldManoObraDirecta
            // 
            fieldManoObraDirecta.AutoEllipsis = true;
            fieldManoObraDirecta.Dock = DockStyle.Fill;
            fieldManoObraDirecta.Font = new Font("Segoe UI", 11.25F);
            fieldManoObraDirecta.ForeColor = Color.DimGray;
            fieldManoObraDirecta.ImeMode = ImeMode.NoControl;
            fieldManoObraDirecta.Location = new Point(495, 1);
            fieldManoObraDirecta.Margin = new Padding(1);
            fieldManoObraDirecta.Name = "fieldManoObraDirecta";
            fieldManoObraDirecta.Size = new Size(128, 39);
            fieldManoObraDirecta.TabIndex = 6;
            fieldManoObraDirecta.Text = "manoObra";
            fieldManoObraDirecta.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldCostoIndirecto
            // 
            fieldCostoIndirecto.Dock = DockStyle.Fill;
            fieldCostoIndirecto.Font = new Font("Segoe UI", 11.25F);
            fieldCostoIndirecto.ForeColor = Color.DimGray;
            fieldCostoIndirecto.ImeMode = ImeMode.NoControl;
            fieldCostoIndirecto.Location = new Point(625, 1);
            fieldCostoIndirecto.Margin = new Padding(1);
            fieldCostoIndirecto.Name = "fieldCostoIndirecto";
            fieldCostoIndirecto.Size = new Size(128, 39);
            fieldCostoIndirecto.TabIndex = 17;
            fieldCostoIndirecto.Text = "costoIndirecto";
            fieldCostoIndirecto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldFecha
            // 
            fieldFecha.Dock = DockStyle.Fill;
            fieldFecha.Font = new Font("Segoe UI", 11.25F);
            fieldFecha.ForeColor = Color.DimGray;
            fieldFecha.ImeMode = ImeMode.NoControl;
            fieldFecha.Location = new Point(61, 1);
            fieldFecha.Margin = new Padding(1);
            fieldFecha.Name = "fieldFecha";
            fieldFecha.Size = new Size(118, 39);
            fieldFecha.TabIndex = 15;
            fieldFecha.Text = "fecha";
            fieldFecha.TextAlign = ContentAlignment.MiddleCenter;
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
            btnEliminar.CustomizableEdges = customizableEdges7;
            btnEliminar.Dock = DockStyle.Fill;
            btnEliminar.FillColor = Color.White;
            btnEliminar.Font = new Font("Segoe UI", 9.75F);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.HoverState.BorderColor = Color.PeachPuff;
            btnEliminar.HoverState.FillColor = Color.PeachPuff;
            btnEliminar.HoverState.ForeColor = Color.White;
            btnEliminar.Location = new Point(1203, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnEliminar.Size = new Size(35, 35);
            btnEliminar.TabIndex = 21;
            // 
            // fieldNombre
            // 
            fieldNombre.AutoEllipsis = true;
            fieldNombre.Dock = DockStyle.Fill;
            fieldNombre.Font = new Font("Segoe UI", 11.25F);
            fieldNombre.ForeColor = Color.DimGray;
            fieldNombre.ImeMode = ImeMode.NoControl;
            fieldNombre.Location = new Point(181, 1);
            fieldNombre.Margin = new Padding(1);
            fieldNombre.Name = "fieldNombre";
            fieldNombre.Size = new Size(182, 39);
            fieldNombre.TabIndex = 4;
            fieldNombre.Text = "nombre";
            fieldNombre.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldMateriaPrimaDirecta
            // 
            fieldMateriaPrimaDirecta.Dock = DockStyle.Fill;
            fieldMateriaPrimaDirecta.Font = new Font("Segoe UI", 11.25F);
            fieldMateriaPrimaDirecta.ForeColor = Color.DimGray;
            fieldMateriaPrimaDirecta.ImeMode = ImeMode.NoControl;
            fieldMateriaPrimaDirecta.Location = new Point(365, 1);
            fieldMateriaPrimaDirecta.Margin = new Padding(1);
            fieldMateriaPrimaDirecta.Name = "fieldMateriaPrimaDirecta";
            fieldMateriaPrimaDirecta.Size = new Size(128, 39);
            fieldMateriaPrimaDirecta.TabIndex = 14;
            fieldMateriaPrimaDirecta.Text = "materiaPrima";
            fieldMateriaPrimaDirecta.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldCostoTotal
            // 
            fieldCostoTotal.Dock = DockStyle.Fill;
            fieldCostoTotal.Font = new Font("Segoe UI", 11.25F);
            fieldCostoTotal.ForeColor = Color.DimGray;
            fieldCostoTotal.ImeMode = ImeMode.NoControl;
            fieldCostoTotal.Location = new Point(755, 1);
            fieldCostoTotal.Margin = new Padding(1);
            fieldCostoTotal.Name = "fieldCostoTotal";
            fieldCostoTotal.Size = new Size(128, 39);
            fieldCostoTotal.TabIndex = 16;
            fieldCostoTotal.Text = "costoTotal";
            fieldCostoTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldObservaciones
            // 
            fieldObservaciones.Dock = DockStyle.Fill;
            fieldObservaciones.Font = new Font("Segoe UI", 11.25F);
            fieldObservaciones.ForeColor = Color.DimGray;
            fieldObservaciones.ImeMode = ImeMode.NoControl;
            fieldObservaciones.Location = new Point(885, 1);
            fieldObservaciones.Margin = new Padding(1);
            fieldObservaciones.Name = "fieldObservaciones";
            fieldObservaciones.Size = new Size(274, 39);
            fieldObservaciones.TabIndex = 22;
            fieldObservaciones.Text = "observaciones";
            fieldObservaciones.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VistaTuplaCostoProduccion
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1241, 42);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaTuplaCostoProduccion";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaTuplaProducto";
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
        private Label fieldMateriaPrimaDirecta;
        private Label fieldManoObraDirecta;
        private Label fieldFecha;
        private Label fieldCostoTotal;
        private Label fieldCostoIndirecto;
        private Guna2Button btnEliminar;
        private Label fieldObservaciones;
    }
}