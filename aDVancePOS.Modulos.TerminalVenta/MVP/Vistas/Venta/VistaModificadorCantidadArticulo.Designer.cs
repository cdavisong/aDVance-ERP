namespace aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta {
    partial class VistaModificadorCantidadArticulo {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaModificadorCantidadArticulo));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutDistribucion = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            fieldSubtitulo = new Label();
            layoutTitulo = new TableLayoutPanel();
            btnCerrar = new Guna.UI2.WinForms.Guna2Button();
            fieldTitulo = new Label();
            layoutBotones = new TableLayoutPanel();
            btnSalir = new Guna.UI2.WinForms.Guna2Button();
            btnEstablecer = new Guna.UI2.WinForms.Guna2Button();
            fieldCantidad = new Guna.UI2.WinForms.Guna2TextBox();
            layoutBase.SuspendLayout();
            layoutDistribucion.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            layoutVista.SuspendLayout();
            layoutTitulo.SuspendLayout();
            layoutBotones.SuspendLayout();
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
            layoutBase.ColumnCount = 1;
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutBase.Controls.Add(layoutDistribucion, 0, 0);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 1;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutBase.Size = new Size(300, 500);
            layoutBase.TabIndex = 0;
            // 
            // layoutDistribucion
            // 
            layoutDistribucion.ColumnCount = 1;
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutDistribucion.Controls.Add(tableLayoutPanel1, 0, 0);
            layoutDistribucion.Dock = DockStyle.Fill;
            layoutDistribucion.Location = new Point(1, 1);
            layoutDistribucion.Margin = new Padding(1);
            layoutDistribucion.Name = "layoutDistribucion";
            layoutDistribucion.RowCount = 1;
            layoutDistribucion.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutDistribucion.Size = new Size(298, 498);
            layoutDistribucion.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Gainsboro;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(layoutVista, 0, 0);
            tableLayoutPanel1.Controls.Add(layoutBotones, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            tableLayoutPanel1.Size = new Size(292, 492);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // layoutVista
            // 
            layoutVista.BackColor = Color.White;
            layoutVista.ColumnCount = 3;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutVista.Controls.Add(fieldCantidad, 1, 4);
            layoutVista.Controls.Add(fieldSubtitulo, 1, 2);
            layoutVista.Controls.Add(layoutTitulo, 1, 1);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(3, 0);
            layoutVista.Margin = new Padding(3, 0, 0, 0);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 7;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutVista.Size = new Size(289, 417);
            layoutVista.TabIndex = 0;
            // 
            // fieldSubtitulo
            // 
            fieldSubtitulo.Dock = DockStyle.Fill;
            fieldSubtitulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldSubtitulo.ForeColor = Color.DimGray;
            fieldSubtitulo.ImeMode = ImeMode.NoControl;
            fieldSubtitulo.Location = new Point(25, 70);
            fieldSubtitulo.Margin = new Padding(5, 5, 1, 1);
            fieldSubtitulo.Name = "fieldSubtitulo";
            fieldSubtitulo.Size = new Size(243, 39);
            fieldSubtitulo.TabIndex = 0;
            fieldSubtitulo.Text = "Establezca la cantidad del siguiente artículo";
            // 
            // layoutTitulo
            // 
            layoutTitulo.ColumnCount = 2;
            layoutTitulo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutTitulo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutTitulo.Controls.Add(btnCerrar, 1, 0);
            layoutTitulo.Controls.Add(fieldTitulo, 0, 0);
            layoutTitulo.Dock = DockStyle.Fill;
            layoutTitulo.Location = new Point(20, 20);
            layoutTitulo.Margin = new Padding(0);
            layoutTitulo.Name = "layoutTitulo";
            layoutTitulo.RowCount = 1;
            layoutTitulo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutTitulo.Size = new Size(249, 45);
            layoutTitulo.TabIndex = 8;
            // 
            // btnCerrar
            // 
            btnCerrar.Animated = true;
            btnCerrar.AutoRoundedCorners = true;
            btnCerrar.BorderColor = Color.Gray;
            btnCerrar.BorderRadius = 18;
            btnCerrar.CustomizableEdges = customizableEdges3;
            btnCerrar.Dock = DockStyle.Fill;
            btnCerrar.FillColor = Color.White;
            btnCerrar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.Black;
            btnCerrar.HoverState.FillColor = Color.White;
            btnCerrar.Image = (Image) resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(202, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCerrar.Size = new Size(44, 39);
            btnCerrar.TabIndex = 1;
            // 
            // fieldTitulo
            // 
            fieldTitulo.Dock = DockStyle.Fill;
            fieldTitulo.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTitulo.ForeColor = Color.Black;
            fieldTitulo.ImeMode = ImeMode.NoControl;
            fieldTitulo.Location = new Point(3, 0);
            fieldTitulo.Name = "fieldTitulo";
            fieldTitulo.Size = new Size(193, 45);
            fieldTitulo.TabIndex = 0;
            fieldTitulo.Text = "Cantidad";
            fieldTitulo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutBotones
            // 
            layoutBotones.BackColor = Color.White;
            layoutBotones.ColumnCount = 4;
            layoutBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            layoutBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            layoutBotones.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 22F));
            layoutBotones.Controls.Add(btnSalir, 2, 0);
            layoutBotones.Controls.Add(btnEstablecer, 1, 0);
            layoutBotones.Dock = DockStyle.Fill;
            layoutBotones.Location = new Point(3, 417);
            layoutBotones.Margin = new Padding(3, 0, 0, 0);
            layoutBotones.Name = "layoutBotones";
            layoutBotones.RowCount = 2;
            layoutBotones.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBotones.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBotones.Size = new Size(289, 65);
            layoutBotones.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.Animated = true;
            btnSalir.BorderColor = Color.Gainsboro;
            btnSalir.BorderRadius = 18;
            btnSalir.BorderThickness = 1;
            btnSalir.CustomizableEdges = customizableEdges5;
            btnSalir.Dock = DockStyle.Fill;
            btnSalir.FillColor = Color.White;
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.ForeColor = Color.Gainsboro;
            btnSalir.HoverState.BorderColor = Color.PeachPuff;
            btnSalir.HoverState.FillColor = Color.PeachPuff;
            btnSalir.HoverState.ForeColor = Color.Black;
            btnSalir.Location = new Point(171, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSalir.Size = new Size(92, 39);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            // 
            // btnEstablecer
            // 
            btnEstablecer.Animated = true;
            btnEstablecer.BorderRadius = 18;
            btnEstablecer.CustomizableEdges = customizableEdges7;
            btnEstablecer.Dock = DockStyle.Fill;
            btnEstablecer.FillColor = Color.PeachPuff;
            btnEstablecer.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnEstablecer.ForeColor = Color.Black;
            btnEstablecer.Location = new Point(23, 3);
            btnEstablecer.Name = "btnEstablecer";
            btnEstablecer.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnEstablecer.Size = new Size(142, 39);
            btnEstablecer.TabIndex = 0;
            btnEstablecer.Text = "Establecer";
            // 
            // fieldCantidad
            // 
            fieldCantidad.Animated = true;
            fieldCantidad.BorderColor = Color.Gainsboro;
            fieldCantidad.BorderRadius = 16;
            fieldCantidad.Cursor = Cursors.IBeam;
            fieldCantidad.CustomizableEdges = customizableEdges1;
            fieldCantidad.DefaultText = "1";
            fieldCantidad.DisabledState.BorderColor = Color.White;
            fieldCantidad.DisabledState.ForeColor = Color.DimGray;
            fieldCantidad.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldCantidad.Dock = DockStyle.Fill;
            fieldCantidad.FocusedState.BorderColor = Color.SandyBrown;
            fieldCantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldCantidad.ForeColor = Color.Black;
            fieldCantidad.HoverState.BorderColor = Color.SandyBrown;
            fieldCantidad.IconLeftOffset = new Point(10, 0);
            fieldCantidad.Location = new Point(25, 135);
            fieldCantidad.Margin = new Padding(5);
            fieldCantidad.Name = "fieldCantidad";
            fieldCantidad.PasswordChar = '\0';
            fieldCantidad.PlaceholderForeColor = Color.DimGray;
            fieldCantidad.PlaceholderText = "Cantidad";
            fieldCantidad.SelectedText = "";
            fieldCantidad.ShadowDecoration.CustomizableEdges = customizableEdges2;
            fieldCantidad.Size = new Size(239, 35);
            fieldCantidad.TabIndex = 2;
            fieldCantidad.TextAlign = HorizontalAlignment.Right;
            fieldCantidad.TextOffset = new Point(5, 0);
            // 
            // VistaModificadorCantidadArticulo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(300, 500);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaModificadorCantidadArticulo";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaModificadorCantidadArticulo";
            layoutBase.ResumeLayout(false);
            layoutDistribucion.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            layoutTitulo.ResumeLayout(false);
            layoutBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm formatoBase;
        private System.Windows.Forms.TableLayoutPanel layoutBase;
        private System.Windows.Forms.TableLayoutPanel layoutDistribucion;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel layoutVista;
        private Label fieldSubtitulo;
        private TableLayoutPanel layoutTitulo;
        private Guna.UI2.WinForms.Guna2Button btnCerrar;
        private Label fieldTitulo;
        private TableLayoutPanel layoutBotones;
        private Guna.UI2.WinForms.Guna2Button btnSalir;
        private Guna.UI2.WinForms.Guna2Button btnEstablecer;
        private Guna.UI2.WinForms.Guna2TextBox fieldCantidad;
    }
}