using Guna.UI2.WinForms;

namespace Manigest.Modulos.Contactos.MVP.Vistas.Menu {
    partial class VistaMenuContacto {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaMenuContacto));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutDistribucion = new TableLayoutPanel();
            btnContactos = new Guna2Button();
            btnClientes = new Guna2Button();
            fieldTitulo = new Label();
            panelRelleno = new Panel();
            btnProveedores = new Guna2Button();
            layoutBase.SuspendLayout();
            layoutDistribucion.SuspendLayout();
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
            layoutBase.BackColor = Color.FromArgb(  204,   204,   204);
            layoutBase.ColumnCount = 1;
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutBase.Controls.Add(layoutDistribucion, 0, 0);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 1;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutBase.Size = new Size(994, 50);
            layoutBase.TabIndex = 0;
            // 
            // layoutDistribucion
            // 
            layoutDistribucion.ColumnCount = 5;
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutDistribucion.Controls.Add(btnContactos, 3, 0);
            layoutDistribucion.Controls.Add(btnClientes, 2, 0);
            layoutDistribucion.Controls.Add(fieldTitulo, 0, 0);
            layoutDistribucion.Controls.Add(panelRelleno, 4, 0);
            layoutDistribucion.Controls.Add(btnProveedores, 1, 0);
            layoutDistribucion.Dock = DockStyle.Fill;
            layoutDistribucion.Location = new Point(0, 0);
            layoutDistribucion.Margin = new Padding(0);
            layoutDistribucion.Name = "layoutDistribucion";
            layoutDistribucion.RowCount = 1;
            layoutDistribucion.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutDistribucion.Size = new Size(994, 50);
            layoutDistribucion.TabIndex = 0;
            // 
            // btnContactos
            // 
            btnContactos.Animated = true;
            btnContactos.BackColor = Color.FromArgb(  248,   244,   242);
            btnContactos.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnContactos.CheckedState.FillColor = Color.FromArgb(  248,   244,   242);
            btnContactos.CheckedState.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnContactos.CustomImages.CheckedImage = (Image) resources.GetObject("resource.CheckedImage");
            btnContactos.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnContactos.CustomImages.ImageOffset = new Point(0, 30);
            btnContactos.CustomImages.ImageSize = new Size(131, 8);
            btnContactos.CustomizableEdges = customizableEdges1;
            btnContactos.Dock = DockStyle.Fill;
            btnContactos.FillColor = Color.FromArgb(  248,   244,   242);
            btnContactos.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnContactos.ForeColor = Color.FromArgb(  40,   37,   35);
            btnContactos.Location = new Point(440, 0);
            btnContactos.Margin = new Padding(0);
            btnContactos.Name = "btnContactos";
            btnContactos.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnContactos.Size = new Size(160, 50);
            btnContactos.TabIndex = 8;
            btnContactos.Text = "Contactos";
            // 
            // btnClientes
            // 
            btnClientes.Animated = true;
            btnClientes.BackColor = Color.FromArgb(  248,   244,   242);
            btnClientes.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnClientes.CheckedState.FillColor = Color.FromArgb(  248,   244,   242);
            btnClientes.CheckedState.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnClientes.CustomImages.CheckedImage = (Image) resources.GetObject("resource.CheckedImage1");
            btnClientes.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnClientes.CustomImages.ImageOffset = new Point(0, 30);
            btnClientes.CustomImages.ImageSize = new Size(131, 8);
            btnClientes.CustomizableEdges = customizableEdges3;
            btnClientes.Dock = DockStyle.Fill;
            btnClientes.FillColor = Color.FromArgb(  248,   244,   242);
            btnClientes.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnClientes.ForeColor = Color.FromArgb(  40,   37,   35);
            btnClientes.Location = new Point(280, 0);
            btnClientes.Margin = new Padding(0);
            btnClientes.Name = "btnClientes";
            btnClientes.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnClientes.Size = new Size(160, 50);
            btnClientes.TabIndex = 7;
            btnClientes.Text = "Clientes";
            // 
            // fieldTitulo
            // 
            fieldTitulo.BackColor = Color.FromArgb(  248,   244,   242);
            fieldTitulo.Dock = DockStyle.Fill;
            fieldTitulo.Font = new Font("Microsoft PhagsPa", 12F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTitulo.ForeColor = Color.FromArgb(  40,   37,   35);
            fieldTitulo.ImeMode = ImeMode.NoControl;
            fieldTitulo.Location = new Point(0, 0);
            fieldTitulo.Margin = new Padding(0);
            fieldTitulo.Name = "fieldTitulo";
            fieldTitulo.Size = new Size(120, 50);
            fieldTitulo.TabIndex = 4;
            fieldTitulo.Text = "Contacto";
            fieldTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelRelleno
            // 
            panelRelleno.BackColor = Color.FromArgb(  248,   244,   242);
            panelRelleno.Dock = DockStyle.Fill;
            panelRelleno.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            panelRelleno.Location = new Point(600, 0);
            panelRelleno.Margin = new Padding(0);
            panelRelleno.Name = "panelRelleno";
            panelRelleno.Size = new Size(394, 50);
            panelRelleno.TabIndex = 0;
            // 
            // btnProveedores
            // 
            btnProveedores.Animated = true;
            btnProveedores.BackColor = Color.FromArgb(  248,   244,   242);
            btnProveedores.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnProveedores.CheckedState.FillColor = Color.FromArgb(  248,   244,   242);
            btnProveedores.CheckedState.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnProveedores.CustomImages.CheckedImage = (Image) resources.GetObject("resource.CheckedImage2");
            btnProveedores.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnProveedores.CustomImages.ImageOffset = new Point(0, 30);
            btnProveedores.CustomImages.ImageSize = new Size(131, 8);
            btnProveedores.CustomizableEdges = customizableEdges5;
            btnProveedores.Dock = DockStyle.Fill;
            btnProveedores.FillColor = Color.FromArgb(  248,   244,   242);
            btnProveedores.Font = new Font("Microsoft PhagsPa", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnProveedores.ForeColor = Color.FromArgb(  40,   37,   35);
            btnProveedores.Location = new Point(120, 0);
            btnProveedores.Margin = new Padding(0);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnProveedores.Size = new Size(160, 50);
            btnProveedores.TabIndex = 9;
            btnProveedores.Text = "Proveedores";
            // 
            // VistaMenuContacto
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(  2,   52,   107);
            ClientSize = new Size(994, 50);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaMenuContacto";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaMenu";
            layoutBase.ResumeLayout(false);
            layoutDistribucion.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutDistribucion;
        private Panel panelRelleno;
        private Label fieldTitulo;
        private Guna2Button btnClientes;
        private Guna2Button btnContactos;
        private Guna2Button btnProveedores;
    }
}