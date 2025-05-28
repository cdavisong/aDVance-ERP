namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto {
    partial class VistaRegistroProductoP3 {
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaRegistroProductoP3));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            separador1 = new Guna.UI2.WinForms.Guna2Separator();
            fieldTituloPrecios = new Label();
            layoutPrecioCompraBase = new TableLayoutPanel();
            fieldPrecioCompraBase = new Guna.UI2.WinForms.Guna2TextBox();
            fieldTituloPrecioCompraBase = new Label();
            layoutPrecioVentaBase = new TableLayoutPanel();
            fieldPrecioVentaBase = new Guna.UI2.WinForms.Guna2TextBox();
            fieldTituloPrecioVentaBase = new Label();
            layoutStockInicial = new TableLayoutPanel();
            fieldStockInicial = new Guna.UI2.WinForms.Guna2TextBox();
            fieldTituloStockInicial = new Label();
            layoutBase.SuspendLayout();
            layoutPrecioCompraBase.SuspendLayout();
            layoutPrecioVentaBase.SuspendLayout();
            layoutStockInicial.SuspendLayout();
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
            layoutBase.Controls.Add(layoutStockInicial, 0, 4);
            layoutBase.Controls.Add(layoutPrecioVentaBase, 0, 2);
            layoutBase.Controls.Add(layoutPrecioCompraBase, 0, 1);
            layoutBase.Controls.Add(separador1, 0, 3);
            layoutBase.Controls.Add(fieldTituloPrecios, 0, 0);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 6;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBase.Size = new Size(417, 470);
            layoutBase.TabIndex = 0;
            // 
            // separador1
            // 
            separador1.Dock = DockStyle.Fill;
            separador1.FillColor = Color.FromArgb(  208,   197,   188);
            separador1.Location = new Point(3, 120);
            separador1.Name = "separador1";
            separador1.Size = new Size(411, 14);
            separador1.TabIndex = 9;
            // 
            // fieldTituloPrecios
            // 
            fieldTituloPrecios.Dock = DockStyle.Fill;
            fieldTituloPrecios.Font = new Font("Segoe UI", 11.25F);
            fieldTituloPrecios.ForeColor = Color.DimGray;
            fieldTituloPrecios.Image = (Image) resources.GetObject("fieldTituloPrecios.Image");
            fieldTituloPrecios.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloPrecios.ImeMode = ImeMode.NoControl;
            fieldTituloPrecios.Location = new Point(15, 5);
            fieldTituloPrecios.Margin = new Padding(15, 5, 3, 3);
            fieldTituloPrecios.Name = "fieldTituloPrecios";
            fieldTituloPrecios.Size = new Size(399, 27);
            fieldTituloPrecios.TabIndex = 5;
            fieldTituloPrecios.Text = "      Precios de compraventa :";
            fieldTituloPrecios.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutPrecioCompraBase
            // 
            layoutPrecioCompraBase.ColumnCount = 2;
            layoutPrecioCompraBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPrecioCompraBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutPrecioCompraBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutPrecioCompraBase.Controls.Add(fieldPrecioCompraBase, 1, 0);
            layoutPrecioCompraBase.Controls.Add(fieldTituloPrecioCompraBase, 0, 0);
            layoutPrecioCompraBase.Dock = DockStyle.Fill;
            layoutPrecioCompraBase.Location = new Point(0, 35);
            layoutPrecioCompraBase.Margin = new Padding(0);
            layoutPrecioCompraBase.Name = "layoutPrecioCompraBase";
            layoutPrecioCompraBase.RowCount = 1;
            layoutPrecioCompraBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutPrecioCompraBase.Size = new Size(417, 41);
            layoutPrecioCompraBase.TabIndex = 20;
            // 
            // fieldPrecioCompraBase
            // 
            fieldPrecioCompraBase.Animated = true;
            fieldPrecioCompraBase.AutoRoundedCorners = true;
            fieldPrecioCompraBase.BorderColor = Color.Gainsboro;
            fieldPrecioCompraBase.BorderRadius = 16;
            fieldPrecioCompraBase.Cursor = Cursors.IBeam;
            fieldPrecioCompraBase.CustomizableEdges = customizableEdges15;
            fieldPrecioCompraBase.DefaultText = "";
            fieldPrecioCompraBase.DisabledState.BorderColor = Color.White;
            fieldPrecioCompraBase.DisabledState.ForeColor = Color.DimGray;
            fieldPrecioCompraBase.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldPrecioCompraBase.Dock = DockStyle.Fill;
            fieldPrecioCompraBase.FocusedState.BorderColor = Color.SandyBrown;
            fieldPrecioCompraBase.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldPrecioCompraBase.ForeColor = Color.Black;
            fieldPrecioCompraBase.HoverState.BorderColor = Color.SandyBrown;
            fieldPrecioCompraBase.IconLeftOffset = new Point(10, 0);
            fieldPrecioCompraBase.IconRight = (Image) resources.GetObject("fieldPrecioCompraBase.IconRight");
            fieldPrecioCompraBase.IconRightOffset = new Point(6, 0);
            fieldPrecioCompraBase.IconRightSize = new Size(12, 12);
            fieldPrecioCompraBase.Location = new Point(290, 3);
            fieldPrecioCompraBase.Name = "fieldPrecioCompraBase";
            fieldPrecioCompraBase.PasswordChar = '\0';
            fieldPrecioCompraBase.PlaceholderForeColor = Color.DimGray;
            fieldPrecioCompraBase.PlaceholderText = "Precio";
            fieldPrecioCompraBase.ReadOnly = true;
            fieldPrecioCompraBase.SelectedText = "";
            fieldPrecioCompraBase.ShadowDecoration.CustomizableEdges = customizableEdges16;
            fieldPrecioCompraBase.Size = new Size(124, 35);
            fieldPrecioCompraBase.TabIndex = 6;
            fieldPrecioCompraBase.TextAlign = HorizontalAlignment.Right;
            fieldPrecioCompraBase.TextOffset = new Point(5, 0);
            // 
            // fieldTituloPrecioCompraBase
            // 
            fieldTituloPrecioCompraBase.Dock = DockStyle.Fill;
            fieldTituloPrecioCompraBase.Font = new Font("Segoe UI", 11.25F);
            fieldTituloPrecioCompraBase.ForeColor = Color.DimGray;
            fieldTituloPrecioCompraBase.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloPrecioCompraBase.ImeMode = ImeMode.NoControl;
            fieldTituloPrecioCompraBase.Location = new Point(15, 5);
            fieldTituloPrecioCompraBase.Margin = new Padding(15, 5, 3, 3);
            fieldTituloPrecioCompraBase.Name = "fieldTituloPrecioCompraBase";
            fieldTituloPrecioCompraBase.Size = new Size(269, 33);
            fieldTituloPrecioCompraBase.TabIndex = 0;
            fieldTituloPrecioCompraBase.Text = "  ●   Precio de compra base";
            fieldTituloPrecioCompraBase.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutPrecioVentaBase
            // 
            layoutPrecioVentaBase.ColumnCount = 2;
            layoutPrecioVentaBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPrecioVentaBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutPrecioVentaBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutPrecioVentaBase.Controls.Add(fieldPrecioVentaBase, 1, 0);
            layoutPrecioVentaBase.Controls.Add(fieldTituloPrecioVentaBase, 0, 0);
            layoutPrecioVentaBase.Dock = DockStyle.Fill;
            layoutPrecioVentaBase.Location = new Point(0, 76);
            layoutPrecioVentaBase.Margin = new Padding(0);
            layoutPrecioVentaBase.Name = "layoutPrecioVentaBase";
            layoutPrecioVentaBase.RowCount = 1;
            layoutPrecioVentaBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutPrecioVentaBase.Size = new Size(417, 41);
            layoutPrecioVentaBase.TabIndex = 21;
            // 
            // fieldPrecioVentaBase
            // 
            fieldPrecioVentaBase.Animated = true;
            fieldPrecioVentaBase.AutoRoundedCorners = true;
            fieldPrecioVentaBase.BorderColor = Color.Gainsboro;
            fieldPrecioVentaBase.BorderRadius = 16;
            fieldPrecioVentaBase.Cursor = Cursors.IBeam;
            fieldPrecioVentaBase.CustomizableEdges = customizableEdges13;
            fieldPrecioVentaBase.DefaultText = "";
            fieldPrecioVentaBase.DisabledState.BorderColor = Color.White;
            fieldPrecioVentaBase.DisabledState.ForeColor = Color.DimGray;
            fieldPrecioVentaBase.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldPrecioVentaBase.Dock = DockStyle.Fill;
            fieldPrecioVentaBase.FocusedState.BorderColor = Color.SandyBrown;
            fieldPrecioVentaBase.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldPrecioVentaBase.ForeColor = Color.Black;
            fieldPrecioVentaBase.HoverState.BorderColor = Color.SandyBrown;
            fieldPrecioVentaBase.IconLeftOffset = new Point(10, 0);
            fieldPrecioVentaBase.IconRight = (Image) resources.GetObject("fieldPrecioVentaBase.IconRight");
            fieldPrecioVentaBase.IconRightOffset = new Point(6, 0);
            fieldPrecioVentaBase.IconRightSize = new Size(12, 12);
            fieldPrecioVentaBase.Location = new Point(290, 3);
            fieldPrecioVentaBase.Name = "fieldPrecioVentaBase";
            fieldPrecioVentaBase.PasswordChar = '\0';
            fieldPrecioVentaBase.PlaceholderForeColor = Color.DimGray;
            fieldPrecioVentaBase.PlaceholderText = "Precio";
            fieldPrecioVentaBase.ReadOnly = true;
            fieldPrecioVentaBase.SelectedText = "";
            fieldPrecioVentaBase.ShadowDecoration.CustomizableEdges = customizableEdges14;
            fieldPrecioVentaBase.Size = new Size(124, 35);
            fieldPrecioVentaBase.TabIndex = 6;
            fieldPrecioVentaBase.TextAlign = HorizontalAlignment.Right;
            fieldPrecioVentaBase.TextOffset = new Point(5, 0);
            // 
            // fieldTituloPrecioVentaBase
            // 
            fieldTituloPrecioVentaBase.Dock = DockStyle.Fill;
            fieldTituloPrecioVentaBase.Font = new Font("Segoe UI", 11.25F);
            fieldTituloPrecioVentaBase.ForeColor = Color.DimGray;
            fieldTituloPrecioVentaBase.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloPrecioVentaBase.ImeMode = ImeMode.NoControl;
            fieldTituloPrecioVentaBase.Location = new Point(15, 5);
            fieldTituloPrecioVentaBase.Margin = new Padding(15, 5, 3, 3);
            fieldTituloPrecioVentaBase.Name = "fieldTituloPrecioVentaBase";
            fieldTituloPrecioVentaBase.Size = new Size(269, 33);
            fieldTituloPrecioVentaBase.TabIndex = 0;
            fieldTituloPrecioVentaBase.Text = "  ●   Precio de venta base";
            fieldTituloPrecioVentaBase.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // layoutStockInicial
            // 
            layoutStockInicial.ColumnCount = 2;
            layoutStockInicial.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutStockInicial.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutStockInicial.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutStockInicial.Controls.Add(fieldStockInicial, 1, 0);
            layoutStockInicial.Controls.Add(fieldTituloStockInicial, 0, 0);
            layoutStockInicial.Dock = DockStyle.Fill;
            layoutStockInicial.Location = new Point(0, 137);
            layoutStockInicial.Margin = new Padding(0);
            layoutStockInicial.Name = "layoutStockInicial";
            layoutStockInicial.RowCount = 1;
            layoutStockInicial.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutStockInicial.Size = new Size(417, 45);
            layoutStockInicial.TabIndex = 25;
            // 
            // fieldStockInicial
            // 
            fieldStockInicial.Animated = true;
            fieldStockInicial.BorderColor = Color.Gainsboro;
            fieldStockInicial.BorderRadius = 16;
            fieldStockInicial.Cursor = Cursors.IBeam;
            fieldStockInicial.CustomizableEdges = customizableEdges17;
            fieldStockInicial.DefaultText = "0";
            fieldStockInicial.DisabledState.BorderColor = Color.Gainsboro;
            fieldStockInicial.DisabledState.FillColor = Color.White;
            fieldStockInicial.DisabledState.ForeColor = Color.DimGray;
            fieldStockInicial.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldStockInicial.Dock = DockStyle.Fill;
            fieldStockInicial.FocusedState.BorderColor = Color.SandyBrown;
            fieldStockInicial.Font = new Font("Segoe UI", 11.25F);
            fieldStockInicial.ForeColor = Color.Black;
            fieldStockInicial.HoverState.BorderColor = Color.SandyBrown;
            fieldStockInicial.IconLeftOffset = new Point(10, 0);
            fieldStockInicial.IconRight = (Image) resources.GetObject("fieldStockInicial.IconRight");
            fieldStockInicial.IconRightOffset = new Point(6, 0);
            fieldStockInicial.IconRightSize = new Size(12, 12);
            fieldStockInicial.Location = new Point(292, 5);
            fieldStockInicial.Margin = new Padding(5);
            fieldStockInicial.Name = "fieldStockInicial";
            fieldStockInicial.PasswordChar = '\0';
            fieldStockInicial.PlaceholderForeColor = Color.DimGray;
            fieldStockInicial.PlaceholderText = "";
            fieldStockInicial.SelectedText = "";
            fieldStockInicial.ShadowDecoration.CustomizableEdges = customizableEdges18;
            fieldStockInicial.Size = new Size(120, 35);
            fieldStockInicial.TabIndex = 2;
            fieldStockInicial.TextAlign = HorizontalAlignment.Right;
            fieldStockInicial.TextOffset = new Point(5, 0);
            // 
            // fieldTituloStockInicial
            // 
            fieldTituloStockInicial.Dock = DockStyle.Fill;
            fieldTituloStockInicial.Font = new Font("Segoe UI", 11.25F);
            fieldTituloStockInicial.ForeColor = Color.DimGray;
            fieldTituloStockInicial.Image = (Image) resources.GetObject("fieldTituloStockInicial.Image");
            fieldTituloStockInicial.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloStockInicial.ImeMode = ImeMode.NoControl;
            fieldTituloStockInicial.Location = new Point(15, 5);
            fieldTituloStockInicial.Margin = new Padding(15, 5, 3, 3);
            fieldTituloStockInicial.Name = "fieldTituloStockInicial";
            fieldTituloStockInicial.Size = new Size(269, 37);
            fieldTituloStockInicial.TabIndex = 0;
            fieldTituloStockInicial.Text = "      Stock inicial del producto";
            fieldTituloStockInicial.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VistaRegistroProductoP6
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(417, 470);
            Controls.Add(layoutBase);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VistaRegistroProductoP6";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroProductoP6";
            layoutBase.ResumeLayout(false);
            layoutPrecioCompraBase.ResumeLayout(false);
            layoutPrecioVentaBase.ResumeLayout(false);
            layoutStockInicial.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private Label fieldTituloPrecios;
        private Guna.UI2.WinForms.Guna2Separator separador1;
        private TableLayoutPanel layoutPrecioCompraBase;
        private Guna.UI2.WinForms.Guna2TextBox fieldPrecioCompraBase;
        private Label fieldTituloPrecioCompraBase;
        private TableLayoutPanel layoutPrecioVentaBase;
        private Guna.UI2.WinForms.Guna2TextBox fieldPrecioVentaBase;
        private Label fieldTituloPrecioVentaBase;
        private TableLayoutPanel layoutStockInicial;
        private Guna.UI2.WinForms.Guna2TextBox fieldStockInicial;
        private Label fieldTituloStockInicial;
    }
}