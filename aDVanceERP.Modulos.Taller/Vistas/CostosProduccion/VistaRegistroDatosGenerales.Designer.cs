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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaRegistroDatosGenerales));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            fieldDatoBusquedaFecha = new Guna.UI2.WinForms.Guna2DateTimePicker();
            fieldTituloFecha = new Label();
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
            layoutBase.Controls.Add(fieldDatoBusquedaFecha, 0, 1);
            layoutBase.Controls.Add(fieldTituloFecha, 0, 0);
            layoutBase.Controls.Add(separador1, 0, 6);
            layoutBase.Controls.Add(fieldDescripcionProducto, 0, 5);
            layoutBase.Controls.Add(fieldTituloCategoriaProducto, 0, 3);
            layoutBase.Controls.Add(contenedorVistas, 0, 7);
            layoutBase.Controls.Add(fieldNombreProducto, 0, 4);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 8;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBase.Size = new Size(417, 470);
            layoutBase.TabIndex = 0;
            // 
            // fieldDatoBusquedaFecha
            // 
            fieldDatoBusquedaFecha.BackColor = Color.White;
            fieldDatoBusquedaFecha.BorderColor = Color.Gainsboro;
            fieldDatoBusquedaFecha.BorderRadius = 18;
            fieldDatoBusquedaFecha.BorderThickness = 1;
            fieldDatoBusquedaFecha.Checked = true;
            fieldDatoBusquedaFecha.CheckedState.BorderColor = Color.Gainsboro;
            fieldDatoBusquedaFecha.CheckedState.FillColor = Color.White;
            fieldDatoBusquedaFecha.CheckedState.ForeColor = Color.Black;
            fieldDatoBusquedaFecha.CustomFormat = "yyyy-MM-dd";
            fieldDatoBusquedaFecha.CustomizableEdges = customizableEdges1;
            fieldDatoBusquedaFecha.Dock = DockStyle.Fill;
            fieldDatoBusquedaFecha.FillColor = Color.White;
            fieldDatoBusquedaFecha.Font = new Font("Segoe UI", 11.25F);
            fieldDatoBusquedaFecha.ForeColor = Color.Black;
            fieldDatoBusquedaFecha.Format = DateTimePickerFormat.Long;
            fieldDatoBusquedaFecha.Location = new Point(5, 40);
            fieldDatoBusquedaFecha.Margin = new Padding(5);
            fieldDatoBusquedaFecha.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            fieldDatoBusquedaFecha.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            fieldDatoBusquedaFecha.Name = "fieldDatoBusquedaFecha";
            fieldDatoBusquedaFecha.ShadowDecoration.CustomizableEdges = customizableEdges2;
            fieldDatoBusquedaFecha.Size = new Size(407, 35);
            fieldDatoBusquedaFecha.TabIndex = 26;
            fieldDatoBusquedaFecha.Value = new DateTime(2025, 2, 20, 21, 31, 28, 166);
            // 
            // fieldTituloFecha
            // 
            fieldTituloFecha.Dock = DockStyle.Fill;
            fieldTituloFecha.Font = new Font("Segoe UI", 11.25F);
            fieldTituloFecha.ForeColor = Color.DimGray;
            fieldTituloFecha.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloFecha.ImeMode = ImeMode.NoControl;
            fieldTituloFecha.Location = new Point(15, 5);
            fieldTituloFecha.Margin = new Padding(15, 5, 3, 3);
            fieldTituloFecha.Name = "fieldTituloFecha";
            fieldTituloFecha.Size = new Size(399, 27);
            fieldTituloFecha.TabIndex = 12;
            fieldTituloFecha.Text = "Fecha :";
            fieldTituloFecha.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // separador1
            // 
            separador1.Dock = DockStyle.Fill;
            separador1.FillColor = Color.FromArgb(  208,   197,   188);
            separador1.Location = new Point(3, 245);
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
            fieldDescripcionProducto.Location = new Point(10, 175);
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
            fieldTituloCategoriaProducto.Location = new Point(15, 95);
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
            contenedorVistas.Location = new Point(0, 262);
            contenedorVistas.Margin = new Padding(0);
            contenedorVistas.Name = "contenedorVistas";
            contenedorVistas.Size = new Size(417, 208);
            contenedorVistas.TabIndex = 11;
            // 
            // fieldNombreProducto
            // 
            fieldNombreProducto.Animated = true;
            fieldNombreProducto.BorderColor = Color.Gainsboro;
            fieldNombreProducto.BorderRadius = 16;
            fieldNombreProducto.Cursor = Cursors.IBeam;
            fieldNombreProducto.CustomizableEdges = customizableEdges3;
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
            fieldNombreProducto.Location = new Point(5, 130);
            fieldNombreProducto.Margin = new Padding(5);
            fieldNombreProducto.Name = "fieldNombreProducto";
            fieldNombreProducto.PasswordChar = '\0';
            fieldNombreProducto.PlaceholderForeColor = Color.DimGray;
            fieldNombreProducto.PlaceholderText = "Nombre o identificador";
            fieldNombreProducto.SelectedText = "";
            fieldNombreProducto.ShadowDecoration.CustomizableEdges = customizableEdges4;
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
        private Label fieldTituloFecha;
        private Guna.UI2.WinForms.Guna2DateTimePicker fieldDatoBusquedaFecha;
    }
}