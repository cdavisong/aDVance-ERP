using Guna.UI2.WinForms;

using System.ComponentModel;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento {
    partial class VistaTuplaMovimiento {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaTuplaMovimiento));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            fieldNombreArticulo = new Label();
            btnEliminar = new Guna2Button();
            fieldNombreAlmacenDestino = new Label();
            fieldId = new Label();
            btnEditar = new Guna2Button();
            fieldMotivo = new Label();
            fieldCantidadMovida = new Label();
            fieldFecha = new Label();
            fieldIcono = new PictureBox();
            fieldNombreAlmacenOrigen = new Label();
            layoutBase.SuspendLayout();
            layoutVista.SuspendLayout();
            ((ISupportInitialize) fieldIcono).BeginInit();
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
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.Controls.Add(fieldNombreArticulo, 0, 0);
            layoutVista.Controls.Add(btnEliminar, 11, 0);
            layoutVista.Controls.Add(fieldNombreAlmacenDestino, 4, 0);
            layoutVista.Controls.Add(fieldId, 0, 0);
            layoutVista.Controls.Add(btnEditar, 10, 0);
            layoutVista.Controls.Add(fieldMotivo, 6, 0);
            layoutVista.Controls.Add(fieldCantidadMovida, 5, 0);
            layoutVista.Controls.Add(fieldFecha, 7, 0);
            layoutVista.Controls.Add(fieldIcono, 3, 0);
            layoutVista.Controls.Add(fieldNombreAlmacenOrigen, 2, 0);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(0, 0);
            layoutVista.Margin = new Padding(0, 0, 0, 1);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 1;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.Size = new Size(1241, 40);
            layoutVista.TabIndex = 18;
            // 
            // fieldNombreArticulo
            // 
            fieldNombreArticulo.Dock = DockStyle.Fill;
            fieldNombreArticulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreArticulo.ForeColor = Color.DimGray;
            fieldNombreArticulo.ImeMode = ImeMode.NoControl;
            fieldNombreArticulo.Location = new Point(61, 1);
            fieldNombreArticulo.Margin = new Padding(1);
            fieldNombreArticulo.Name = "fieldNombreArticulo";
            fieldNombreArticulo.Size = new Size(218, 38);
            fieldNombreArticulo.TabIndex = 20;
            fieldNombreArticulo.Text = "nombreArticulo";
            fieldNombreArticulo.TextAlign = ContentAlignment.MiddleLeft;
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
            btnEliminar.Location = new Point(1204, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnEliminar.Size = new Size(34, 34);
            btnEliminar.TabIndex = 11;
            // 
            // fieldNombreAlmacenDestino
            // 
            fieldNombreAlmacenDestino.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreAlmacenDestino.ForeColor = Color.DimGray;
            fieldNombreAlmacenDestino.ImeMode = ImeMode.NoControl;
            fieldNombreAlmacenDestino.Location = new Point(441, 1);
            fieldNombreAlmacenDestino.Margin = new Padding(1);
            fieldNombreAlmacenDestino.Name = "fieldNombreAlmacenDestino";
            fieldNombreAlmacenDestino.Size = new Size(118, 38);
            fieldNombreAlmacenDestino.TabIndex = 4;
            fieldNombreAlmacenDestino.Text = "nombreAlmacenDestino";
            fieldNombreAlmacenDestino.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldId
            // 
            fieldId.Dock = DockStyle.Fill;
            fieldId.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldId.ForeColor = Color.DimGray;
            fieldId.ImeMode = ImeMode.NoControl;
            fieldId.Location = new Point(1, 1);
            fieldId.Margin = new Padding(1);
            fieldId.Name = "fieldId";
            fieldId.Size = new Size(58, 38);
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
            btnEditar.CustomImages.HoveredImage = (Image) resources.GetObject("resource.HoveredImage1");
            btnEditar.CustomImages.Image = (Image) resources.GetObject("resource.Image1");
            btnEditar.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEditar.CustomizableEdges = customizableEdges7;
            btnEditar.Dock = DockStyle.Fill;
            btnEditar.FillColor = Color.White;
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditar.ForeColor = Color.White;
            btnEditar.HoverState.BorderColor = Color.PeachPuff;
            btnEditar.HoverState.FillColor = Color.PeachPuff;
            btnEditar.Location = new Point(1164, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnEditar.Size = new Size(34, 34);
            btnEditar.TabIndex = 9;
            // 
            // fieldMotivo
            // 
            fieldMotivo.Dock = DockStyle.Fill;
            fieldMotivo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldMotivo.ForeColor = Color.DimGray;
            fieldMotivo.ImeMode = ImeMode.NoControl;
            fieldMotivo.Location = new Point(671, 1);
            fieldMotivo.Margin = new Padding(1);
            fieldMotivo.Name = "fieldMotivo";
            fieldMotivo.Size = new Size(218, 38);
            fieldMotivo.TabIndex = 14;
            fieldMotivo.Text = "motivo";
            fieldMotivo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldCantidadMovida
            // 
            fieldCantidadMovida.AutoEllipsis = true;
            fieldCantidadMovida.Dock = DockStyle.Fill;
            fieldCantidadMovida.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldCantidadMovida.ForeColor = Color.DimGray;
            fieldCantidadMovida.ImeMode = ImeMode.NoControl;
            fieldCantidadMovida.Location = new Point(561, 1);
            fieldCantidadMovida.Margin = new Padding(1);
            fieldCantidadMovida.Name = "fieldCantidadMovida";
            fieldCantidadMovida.Size = new Size(108, 38);
            fieldCantidadMovida.TabIndex = 6;
            fieldCantidadMovida.Text = "cantidad";
            fieldCantidadMovida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldFecha
            // 
            fieldFecha.Dock = DockStyle.Fill;
            fieldFecha.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldFecha.ForeColor = Color.DimGray;
            fieldFecha.ImeMode = ImeMode.NoControl;
            fieldFecha.Location = new Point(891, 1);
            fieldFecha.Margin = new Padding(1);
            fieldFecha.Name = "fieldFecha";
            fieldFecha.Size = new Size(118, 38);
            fieldFecha.TabIndex = 17;
            fieldFecha.Text = "fecha";
            fieldFecha.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldIcono
            // 
            fieldIcono.BackgroundImage = (Image) resources.GetObject("fieldIcono.BackgroundImage");
            fieldIcono.BackgroundImageLayout = ImageLayout.Center;
            fieldIcono.Dock = DockStyle.Fill;
            fieldIcono.Location = new Point(400, 3);
            fieldIcono.Margin = new Padding(0, 3, 0, 0);
            fieldIcono.Name = "fieldIcono";
            fieldIcono.Size = new Size(40, 37);
            fieldIcono.TabIndex = 18;
            fieldIcono.TabStop = false;
            // 
            // fieldNombreAlmacenOrigen
            // 
            fieldNombreAlmacenOrigen.Dock = DockStyle.Fill;
            fieldNombreAlmacenOrigen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreAlmacenOrigen.ForeColor = Color.DimGray;
            fieldNombreAlmacenOrigen.ImeMode = ImeMode.NoControl;
            fieldNombreAlmacenOrigen.Location = new Point(281, 1);
            fieldNombreAlmacenOrigen.Margin = new Padding(1);
            fieldNombreAlmacenOrigen.Name = "fieldNombreAlmacenOrigen";
            fieldNombreAlmacenOrigen.Size = new Size(118, 38);
            fieldNombreAlmacenOrigen.TabIndex = 19;
            fieldNombreAlmacenOrigen.Text = "nombreAlmacenOrigen";
            fieldNombreAlmacenOrigen.TextAlign = ContentAlignment.MiddleRight;
            // 
            // VistaTuplaMovimiento
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1241, 42);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaTuplaMovimiento";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaTuplaMovimiento";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ((ISupportInitialize) fieldIcono).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutVista;
        private Guna2Button btnEliminar;
        private Label fieldNombreAlmacenDestino;
        private Label fieldId;
        private Guna2Button btnEditar;
        private Label fieldMotivo;
        private Label fieldCantidadMovida;
        private Label fieldFecha;
        private PictureBox fieldIcono;
        private Label fieldNombreAlmacenOrigen;
        private Label fieldNombreArticulo;
    }
}