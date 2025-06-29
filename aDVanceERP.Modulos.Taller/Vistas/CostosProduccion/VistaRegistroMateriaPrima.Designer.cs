namespace aDVanceERP.Modulos.Taller.Vistas.CostosProduccion {
    partial class VistaRegistroMateriaPrima {
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaRegistroMateriaPrima));
            formatoBase = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            separador1 = new Guna.UI2.WinForms.Guna2Separator();
            fieldCategoriaProducto = new Guna.UI2.WinForms.Guna2ComboBox();
            fieldTituloCategoriaProducto = new Label();
            contenedorVistas = new Panel();
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
            layoutBase.Controls.Add(fieldCategoriaProducto, 0, 1);
            layoutBase.Controls.Add(fieldTituloCategoriaProducto, 0, 0);
            layoutBase.Controls.Add(contenedorVistas, 0, 9);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 10;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
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
            // fieldCategoriaProducto
            // 
            fieldCategoriaProducto.Animated = true;
            fieldCategoriaProducto.BackColor = Color.Transparent;
            fieldCategoriaProducto.BorderColor = Color.Gainsboro;
            fieldCategoriaProducto.BorderRadius = 16;
            fieldCategoriaProducto.CustomizableEdges = customizableEdges1;
            fieldCategoriaProducto.Dock = DockStyle.Fill;
            fieldCategoriaProducto.DrawMode = DrawMode.OwnerDrawFixed;
            fieldCategoriaProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            fieldCategoriaProducto.FocusedColor = Color.SandyBrown;
            fieldCategoriaProducto.FocusedState.BorderColor = Color.SandyBrown;
            fieldCategoriaProducto.Font = new Font("Segoe UI", 11.25F);
            fieldCategoriaProducto.ForeColor = Color.Black;
            fieldCategoriaProducto.ItemHeight = 29;
            fieldCategoriaProducto.Items.AddRange(new object[] { "Mercancía (Productos revendidos)", "Producto terminado", "Materia prima" });
            fieldCategoriaProducto.Location = new Point(5, 40);
            fieldCategoriaProducto.Margin = new Padding(5);
            fieldCategoriaProducto.Name = "fieldCategoriaProducto";
            fieldCategoriaProducto.ShadowDecoration.CustomizableEdges = customizableEdges2;
            fieldCategoriaProducto.Size = new Size(407, 35);
            fieldCategoriaProducto.StartIndex = 0;
            fieldCategoriaProducto.TabIndex = 6;
            fieldCategoriaProducto.TextOffset = new Point(10, 0);
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
            fieldTituloCategoriaProducto.Text = "      Consumo de materias primas :";
            fieldTituloCategoriaProducto.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contenedorVistas
            // 
            contenedorVistas.Dock = DockStyle.Fill;
            contenedorVistas.Location = new Point(0, 354);
            contenedorVistas.Margin = new Padding(0);
            contenedorVistas.Name = "contenedorVistas";
            contenedorVistas.Size = new Size(417, 116);
            contenedorVistas.TabIndex = 11;
            // 
            // VistaRegistroMateriaPrima
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(417, 470);
            Controls.Add(layoutBase);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VistaRegistroMateriaPrima";
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
        private Guna.UI2.WinForms.Guna2Separator separador1;
        private Panel contenedorVistas;
    }
}