using Guna.UI2.WinForms;

using System.ComponentModel;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Caja {
    partial class VistaTuplaCaja {
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaTuplaCaja));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            fieldId = new Label();
            fieldFechaApertura = new Label();
            fieldNumero = new Label();
            fieldFechaHoraCierre = new Label();
            btnEliminar = new Guna2Button();
            fieldSaldoInicial = new Label();
            fieldSaldoFinal = new Label();
            simboloPeso1 = new Label();
            simboloPeso2 = new Label();
            fieldNotas = new Label();
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
            layoutVista.ColumnCount = 13;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 230F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.Controls.Add(fieldId, 0, 0);
            layoutVista.Controls.Add(fieldFechaApertura, 2, 0);
            layoutVista.Controls.Add(fieldNumero, 1, 0);
            layoutVista.Controls.Add(fieldFechaHoraCierre, 7, 0);
            layoutVista.Controls.Add(btnEliminar, 12, 0);
            layoutVista.Controls.Add(fieldSaldoInicial, 3, 0);
            layoutVista.Controls.Add(fieldSaldoFinal, 5, 0);
            layoutVista.Controls.Add(simboloPeso1, 4, 0);
            layoutVista.Controls.Add(simboloPeso2, 6, 0);
            layoutVista.Controls.Add(fieldNotas, 8, 0);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(0, 0);
            layoutVista.Margin = new Padding(0, 0, 0, 1);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 1;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.Size = new Size(1241, 41);
            layoutVista.TabIndex = 21;
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
            fieldId.Size = new Size(58, 39);
            fieldId.TabIndex = 13;
            fieldId.Text = "id";
            fieldId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldFechaApertura
            // 
            fieldFechaApertura.Dock = DockStyle.Fill;
            fieldFechaApertura.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldFechaApertura.ForeColor = Color.DimGray;
            fieldFechaApertura.ImeMode = ImeMode.NoControl;
            fieldFechaApertura.Location = new Point(181, 1);
            fieldFechaApertura.Margin = new Padding(1);
            fieldFechaApertura.Name = "fieldFechaApertura";
            fieldFechaApertura.Size = new Size(118, 39);
            fieldFechaApertura.TabIndex = 19;
            fieldFechaApertura.Text = "fechaApertura";
            fieldFechaApertura.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldNumero
            // 
            fieldNumero.Dock = DockStyle.Fill;
            fieldNumero.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNumero.ForeColor = Color.DimGray;
            fieldNumero.ImeMode = ImeMode.NoControl;
            fieldNumero.Location = new Point(61, 1);
            fieldNumero.Margin = new Padding(1);
            fieldNumero.Name = "fieldNumero";
            fieldNumero.Size = new Size(118, 39);
            fieldNumero.TabIndex = 17;
            fieldNumero.Text = "numero";
            fieldNumero.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldFechaHoraCierre
            // 
            fieldFechaHoraCierre.AutoEllipsis = true;
            fieldFechaHoraCierre.Dock = DockStyle.Fill;
            fieldFechaHoraCierre.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldFechaHoraCierre.ForeColor = Color.DimGray;
            fieldFechaHoraCierre.ImeMode = ImeMode.NoControl;
            fieldFechaHoraCierre.Location = new Point(561, 1);
            fieldFechaHoraCierre.Margin = new Padding(1);
            fieldFechaHoraCierre.Name = "fieldFechaHoraCierre";
            fieldFechaHoraCierre.Size = new Size(218, 39);
            fieldFechaHoraCierre.TabIndex = 6;
            fieldFechaHoraCierre.Text = "fechaHoraCierre";
            fieldFechaHoraCierre.TextAlign = ContentAlignment.MiddleCenter;
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
            btnEliminar.CustomizableEdges = customizableEdges1;
            btnEliminar.Dock = DockStyle.Fill;
            btnEliminar.Enabled = false;
            btnEliminar.FillColor = Color.White;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.HoverState.BorderColor = Color.PeachPuff;
            btnEliminar.HoverState.FillColor = Color.PeachPuff;
            btnEliminar.HoverState.ForeColor = Color.White;
            btnEliminar.Location = new Point(1204, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnEliminar.Size = new Size(34, 35);
            btnEliminar.TabIndex = 22;
            // 
            // fieldSaldoInicial
            // 
            fieldSaldoInicial.Dock = DockStyle.Fill;
            fieldSaldoInicial.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldSaldoInicial.ForeColor = Color.Black;
            fieldSaldoInicial.ImeMode = ImeMode.NoControl;
            fieldSaldoInicial.Location = new Point(301, 1);
            fieldSaldoInicial.Margin = new Padding(1);
            fieldSaldoInicial.Name = "fieldSaldoInicial";
            fieldSaldoInicial.Size = new Size(108, 39);
            fieldSaldoInicial.TabIndex = 31;
            fieldSaldoInicial.Text = "saldoInicial";
            fieldSaldoInicial.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldSaldoFinal
            // 
            fieldSaldoFinal.Dock = DockStyle.Fill;
            fieldSaldoFinal.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            fieldSaldoFinal.ForeColor = Color.Black;
            fieldSaldoFinal.ImeMode = ImeMode.NoControl;
            fieldSaldoFinal.Location = new Point(431, 1);
            fieldSaldoFinal.Margin = new Padding(1);
            fieldSaldoFinal.Name = "fieldSaldoFinal";
            fieldSaldoFinal.Size = new Size(108, 39);
            fieldSaldoFinal.TabIndex = 32;
            fieldSaldoFinal.Text = "saldoFinal";
            fieldSaldoFinal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // simboloPeso1
            // 
            simboloPeso1.Dock = DockStyle.Fill;
            simboloPeso1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            simboloPeso1.ForeColor = Color.Black;
            simboloPeso1.ImageAlign = ContentAlignment.MiddleLeft;
            simboloPeso1.ImeMode = ImeMode.NoControl;
            simboloPeso1.Location = new Point(413, 5);
            simboloPeso1.Margin = new Padding(3, 5, 3, 3);
            simboloPeso1.Name = "simboloPeso1";
            simboloPeso1.Size = new Size(14, 33);
            simboloPeso1.TabIndex = 30;
            simboloPeso1.Text = "$";
            simboloPeso1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // simboloPeso2
            // 
            simboloPeso2.Dock = DockStyle.Fill;
            simboloPeso2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            simboloPeso2.ForeColor = Color.Black;
            simboloPeso2.ImageAlign = ContentAlignment.MiddleLeft;
            simboloPeso2.ImeMode = ImeMode.NoControl;
            simboloPeso2.Location = new Point(543, 5);
            simboloPeso2.Margin = new Padding(3, 5, 3, 3);
            simboloPeso2.Name = "simboloPeso2";
            simboloPeso2.Size = new Size(14, 33);
            simboloPeso2.TabIndex = 33;
            simboloPeso2.Text = "$";
            simboloPeso2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldNotas
            // 
            fieldNotas.AutoEllipsis = true;
            fieldNotas.Dock = DockStyle.Fill;
            fieldNotas.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNotas.ForeColor = Color.DimGray;
            fieldNotas.ImeMode = ImeMode.NoControl;
            fieldNotas.Location = new Point(781, 1);
            fieldNotas.Margin = new Padding(1);
            fieldNotas.Name = "fieldNotas";
            fieldNotas.Size = new Size(228, 39);
            fieldNotas.TabIndex = 34;
            fieldNotas.Text = "notas";
            fieldNotas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VistaTuplaCaja
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1241, 42);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaTuplaCaja";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaTuplaCaja";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutVista;
        private Label fieldId;
        private Label fieldFechaApertura;
        private Label fieldNumero;
        private Label fieldFechaHoraCierre;
        private Label fieldMontoTotal;
        private Guna2Button btnEliminar;
        private Label simboloPeso1;
        private Label fieldSaldoInicial;
        private Label fieldSaldoFinal;
        private Label simboloPeso2;
        private Label fieldNotas;
    }
}