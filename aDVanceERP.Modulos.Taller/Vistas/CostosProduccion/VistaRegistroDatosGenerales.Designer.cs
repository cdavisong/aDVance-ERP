namespace aDVanceERP.Modulos.Taller.Vistas.CostosProduccion {
    partial class VistaRegistroDatosGenerales {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaRegistroDatosGenerales));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            separador1 = new Guna.UI2.WinForms.Guna2Separator();
            fieldDescripcionProducto = new Label();
            fieldTituloCategoriaProducto = new Label();
            contenedorVistas = new Panel();
            fieldNombreProducto = new Guna.UI2.WinForms.Guna2TextBox();
            layoutBase.SuspendLayout();
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
            layoutBase.BackColor = Color.White;
            layoutBase.ColumnCount = 1;
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutBase.Controls.Add(separador1, 0, 3);
            layoutBase.Controls.Add(fieldDescripcionProducto, 0, 2);
            layoutBase.Controls.Add(fieldTituloCategoriaProducto, 0, 0);
            layoutBase.Controls.Add(contenedorVistas, 0, 4);
            layoutBase.Controls.Add(fieldNombreProducto, 0, 1);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 5;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.Size = new Size(417, 470);
            layoutBase.TabIndex = 0;
            // 
            // separador1
            // 
            separador1.Dock = DockStyle.Fill;
            separador1.FillColor = Color.FromArgb(  208,   197,   188);
            separador1.Location = new Point(3, 155);
            separador1.Name = "separador1";
            separador1.Size = new Size(411, 14);
            separador1.TabIndex = 9;
            // 
            // fieldDescripcionProducto
            // 
            fieldDescripcionProducto.Dock = DockStyle.Fill;
            fieldDescripcionProducto.Font = new Font("Segoe UI", 11.25F);
            fieldDescripcionProducto.ForeColor = Color.Black;
            fieldDescripcionProducto.ImeMode = ImeMode.NoControl;
            fieldDescripcionProducto.Location = new Point(10, 85);
            fieldDescripcionProducto.Margin = new Padding(10, 5, 10, 1);
            fieldDescripcionProducto.Name = "fieldDescripcionProducto";
            fieldDescripcionProducto.Size = new Size(397, 66);
            fieldDescripcionProducto.TabIndex = 8;
            fieldDescripcionProducto.Text = "No ha descripción disponible para el producto seleccionado";
            // 
            // fieldTituloCategoriaProducto
            // 
            fieldTituloCategoriaProducto.Dock = DockStyle.Fill;
            fieldTituloCategoriaProducto.Font = new Font("Segoe UI", 11.25F);
            fieldTituloCategoriaProducto.ForeColor = Color.DimGray;
            fieldTituloCategoriaProducto.Image = (Image) resources.GetObject("fieldTituloCategoriaProducto.Image");
            fieldTituloCategoriaProducto.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloCategoriaProducto.ImeMode = ImeMode.NoControl;
            fieldTituloCategoriaProducto.Location = new Point(15, 5);
            fieldTituloCategoriaProducto.Margin = new Padding(15, 5, 3, 3);
            fieldTituloCategoriaProducto.Name = "fieldTituloCategoriaProducto";
            fieldTituloCategoriaProducto.Size = new Size(399, 27);
            fieldTituloCategoriaProducto.TabIndex = 5;
            fieldTituloCategoriaProducto.Text = "      Producto :";
            fieldTituloCategoriaProducto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contenedorVistas
            // 
            contenedorVistas.Dock = DockStyle.Fill;
            contenedorVistas.Location = new Point(0, 172);
            contenedorVistas.Margin = new Padding(0);
            contenedorVistas.Name = "contenedorVistas";
            contenedorVistas.Size = new Size(417, 298);
            contenedorVistas.TabIndex = 11;
            // 
            // fieldNombreProducto
            // 
            fieldNombreProducto.Animated = true;
            fieldNombreProducto.BorderColor = Color.Gainsboro;
            fieldNombreProducto.BorderRadius = 16;
            fieldNombreProducto.Cursor = Cursors.IBeam;
            fieldNombreProducto.CustomizableEdges = customizableEdges1;
            fieldNombreProducto.DefaultText = "";
            fieldNombreProducto.DisabledState.BorderColor = Color.White;
            fieldNombreProducto.DisabledState.ForeColor = Color.DimGray;
            fieldNombreProducto.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldNombreProducto.Dock = DockStyle.Fill;
            fieldNombreProducto.FocusedState.BorderColor = Color.SandyBrown;
            fieldNombreProducto.Font = new Font("Segoe UI", 11.25F);
            fieldNombreProducto.ForeColor = Color.Black;
            fieldNombreProducto.HoverState.BorderColor = Color.SandyBrown;
            fieldNombreProducto.IconLeft = (Image) resources.GetObject("fieldNombreProducto.IconLeft");
            fieldNombreProducto.IconLeftOffset = new Point(10, 0);
            fieldNombreProducto.Location = new Point(5, 40);
            fieldNombreProducto.Margin = new Padding(5);
            fieldNombreProducto.Name = "fieldNombreProducto";
            fieldNombreProducto.PasswordChar = '\0';
            fieldNombreProducto.PlaceholderForeColor = Color.DimGray;
            fieldNombreProducto.PlaceholderText = "Nombre o identificador";
            fieldNombreProducto.SelectedText = "";
            fieldNombreProducto.ShadowDecoration.CustomizableEdges = customizableEdges2;
            fieldNombreProducto.Size = new Size(407, 35);
            fieldNombreProducto.TabIndex = 7;
            fieldNombreProducto.TextOffset = new Point(5, 0);
            // 
            // VistaRegistroDatosGenerales
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(417, 470);
            Controls.Add(layoutBase);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VistaRegistroDatosGenerales";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroProductoDatosGenerales";
            layoutBase.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private Label fieldTituloCategoriaProducto;
        private Guna.UI2.WinForms.Guna2ComboBox fieldCategoriaProducto;
        private Guna.UI2.WinForms.Guna2TextBox fieldNombreProducto;
        private Label fieldDescripcionProducto;
        private Guna.UI2.WinForms.Guna2Separator separador1;
        private Panel contenedorVistas;
    }
}