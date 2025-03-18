using Guna.UI2.WinForms;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Menu {
    partial class VistaMenuSeguridad {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaMenuSeguridad));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutDistribucion = new TableLayoutPanel();
            fieldTitulo = new Label();
            panelRelleno = new Panel();
            btnUsuarios = new Guna2Button();
            btnRolesUsuarios = new Guna2Button();
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
            layoutBase.BackColor = Color.WhiteSmoke;
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
            layoutDistribucion.BackColor = Color.WhiteSmoke;
            layoutDistribucion.ColumnCount = 4;
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutDistribucion.Controls.Add(fieldTitulo, 0, 0);
            layoutDistribucion.Controls.Add(panelRelleno, 3, 0);
            layoutDistribucion.Controls.Add(btnUsuarios, 1, 0);
            layoutDistribucion.Controls.Add(btnRolesUsuarios, 2, 0);
            layoutDistribucion.Dock = DockStyle.Fill;
            layoutDistribucion.Location = new Point(0, 0);
            layoutDistribucion.Margin = new Padding(0);
            layoutDistribucion.Name = "layoutDistribucion";
            layoutDistribucion.RowCount = 1;
            layoutDistribucion.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutDistribucion.Size = new Size(994, 50);
            layoutDistribucion.TabIndex = 0;
            // 
            // fieldTitulo
            // 
            fieldTitulo.BackColor = Color.WhiteSmoke;
            fieldTitulo.Dock = DockStyle.Fill;
            fieldTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            fieldTitulo.ForeColor = Color.Black;
            fieldTitulo.ImeMode = ImeMode.NoControl;
            fieldTitulo.Location = new Point(0, 0);
            fieldTitulo.Margin = new Padding(0);
            fieldTitulo.Name = "fieldTitulo";
            fieldTitulo.Size = new Size(160, 50);
            fieldTitulo.TabIndex = 4;
            fieldTitulo.Text = "Seguridad";
            fieldTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelRelleno
            // 
            panelRelleno.BackColor = Color.WhiteSmoke;
            panelRelleno.Dock = DockStyle.Fill;
            panelRelleno.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            panelRelleno.Location = new Point(480, 0);
            panelRelleno.Margin = new Padding(0);
            panelRelleno.Name = "panelRelleno";
            panelRelleno.Size = new Size(514, 50);
            panelRelleno.TabIndex = 0;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Animated = true;
            btnUsuarios.BackColor = Color.WhiteSmoke;
            btnUsuarios.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnUsuarios.CheckedState.FillColor = Color.WhiteSmoke;
            btnUsuarios.CheckedState.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnUsuarios.CustomImages.CheckedImage = (Image) resources.GetObject("resource.CheckedImage");
            btnUsuarios.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnUsuarios.CustomImages.ImageOffset = new Point(0, 32);
            btnUsuarios.CustomImages.ImageSize = new Size(131, 8);
            btnUsuarios.CustomizableEdges = customizableEdges1;
            btnUsuarios.Dock = DockStyle.Fill;
            btnUsuarios.FillColor = Color.WhiteSmoke;
            btnUsuarios.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnUsuarios.ForeColor = Color.Black;
            btnUsuarios.Location = new Point(160, 0);
            btnUsuarios.Margin = new Padding(0);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnUsuarios.Size = new Size(160, 50);
            btnUsuarios.TabIndex = 9;
            btnUsuarios.Text = "Usuarios";
            // 
            // btnRolesUsuarios
            // 
            btnRolesUsuarios.Animated = true;
            btnRolesUsuarios.BackColor = Color.WhiteSmoke;
            btnRolesUsuarios.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnRolesUsuarios.CheckedState.FillColor = Color.WhiteSmoke;
            btnRolesUsuarios.CheckedState.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnRolesUsuarios.CustomImages.CheckedImage = (Image) resources.GetObject("resource.CheckedImage1");
            btnRolesUsuarios.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnRolesUsuarios.CustomImages.ImageOffset = new Point(0, 32);
            btnRolesUsuarios.CustomImages.ImageSize = new Size(131, 8);
            btnRolesUsuarios.CustomizableEdges = customizableEdges3;
            btnRolesUsuarios.Dock = DockStyle.Fill;
            btnRolesUsuarios.FillColor = Color.WhiteSmoke;
            btnRolesUsuarios.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnRolesUsuarios.ForeColor = Color.Black;
            btnRolesUsuarios.Location = new Point(320, 0);
            btnRolesUsuarios.Margin = new Padding(0);
            btnRolesUsuarios.Name = "btnRolesUsuarios";
            btnRolesUsuarios.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnRolesUsuarios.Size = new Size(160, 50);
            btnRolesUsuarios.TabIndex = 10;
            btnRolesUsuarios.Text = "Roles de usuario";
            // 
            // VistaMenuSeguridad
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(  245,   245,   245);
            ClientSize = new Size(994, 50);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaMenuSeguridad";
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
        private Guna2Button btnUsuarios;
        private Guna2Button btnRolesUsuarios;
    }
}