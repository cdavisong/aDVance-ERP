namespace aDVanceERP.Modulos.Taller.Vistas.CostosProduccion {
    partial class VistaRegistroManoObra {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaRegistroManoObra));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutSubtotal = new TableLayoutPanel();
            symbolPeso = new Label();
            fieldCostoTotalActividades = new Label();
            fieldTituloCostoTotalManoObra = new Label();
            fieldDescripcionActividad = new Label();
            layoutGestionMateriaPrima = new TableLayoutPanel();
            btnAdicionarMateriaPrima = new Guna.UI2.WinForms.Guna2Button();
            fieldCantidad = new Guna.UI2.WinForms.Guna2TextBox();
            fieldNombreActividad = new Guna.UI2.WinForms.Guna2TextBox();
            fieldTituloManoObraDirecta = new Label();
            contenedorVistas = new Panel();
            separador1 = new Guna.UI2.WinForms.Guna2Separator();
            layoutEncabezadosTabla = new TableLayoutPanel();
            fieldTituloCantidad = new Label();
            fieldTituloCosto = new Label();
            fieldTituloActividad = new Label();
            layoutBase.SuspendLayout();
            layoutSubtotal.SuspendLayout();
            layoutGestionMateriaPrima.SuspendLayout();
            layoutEncabezadosTabla.SuspendLayout();
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
            layoutBase.Controls.Add(layoutSubtotal, 0, 6);
            layoutBase.Controls.Add(fieldDescripcionActividad, 0, 2);
            layoutBase.Controls.Add(layoutGestionMateriaPrima, 0, 1);
            layoutBase.Controls.Add(fieldTituloManoObraDirecta, 0, 0);
            layoutBase.Controls.Add(contenedorVistas, 0, 4);
            layoutBase.Controls.Add(separador1, 0, 5);
            layoutBase.Controls.Add(layoutEncabezadosTabla, 0, 3);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 7;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layoutBase.Size = new Size(417, 470);
            layoutBase.TabIndex = 0;
            // 
            // layoutSubtotal
            // 
            layoutSubtotal.ColumnCount = 3;
            layoutSubtotal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutSubtotal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutSubtotal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutSubtotal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutSubtotal.Controls.Add(symbolPeso, 0, 0);
            layoutSubtotal.Controls.Add(fieldCostoTotalActividades, 0, 0);
            layoutSubtotal.Controls.Add(fieldTituloCostoTotalManoObra, 0, 0);
            layoutSubtotal.Dock = DockStyle.Fill;
            layoutSubtotal.Location = new Point(0, 425);
            layoutSubtotal.Margin = new Padding(0);
            layoutSubtotal.Name = "layoutSubtotal";
            layoutSubtotal.RowCount = 1;
            layoutSubtotal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutSubtotal.Size = new Size(417, 45);
            layoutSubtotal.TabIndex = 24;
            // 
            // symbolPeso
            // 
            symbolPeso.Dock = DockStyle.Fill;
            symbolPeso.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            symbolPeso.ForeColor = Color.Black;
            symbolPeso.ImageAlign = ContentAlignment.MiddleLeft;
            symbolPeso.ImeMode = ImeMode.NoControl;
            symbolPeso.Location = new Point(400, 5);
            symbolPeso.Margin = new Padding(3, 5, 3, 3);
            symbolPeso.Name = "symbolPeso";
            symbolPeso.Size = new Size(14, 37);
            symbolPeso.TabIndex = 2;
            symbolPeso.Text = "$";
            symbolPeso.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldCostoTotalActividades
            // 
            fieldCostoTotalActividades.Dock = DockStyle.Fill;
            fieldCostoTotalActividades.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldCostoTotalActividades.ForeColor = Color.Black;
            fieldCostoTotalActividades.ImageAlign = ContentAlignment.MiddleLeft;
            fieldCostoTotalActividades.ImeMode = ImeMode.NoControl;
            fieldCostoTotalActividades.Location = new Point(302, 5);
            fieldCostoTotalActividades.Margin = new Padding(15, 5, 3, 3);
            fieldCostoTotalActividades.Name = "fieldCostoTotalActividades";
            fieldCostoTotalActividades.Size = new Size(92, 37);
            fieldCostoTotalActividades.TabIndex = 1;
            fieldCostoTotalActividades.Text = "0.00";
            fieldCostoTotalActividades.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldTituloCostoTotalManoObra
            // 
            fieldTituloCostoTotalManoObra.Dock = DockStyle.Fill;
            fieldTituloCostoTotalManoObra.Font = new Font("Segoe UI", 11.25F);
            fieldTituloCostoTotalManoObra.ForeColor = Color.DimGray;
            fieldTituloCostoTotalManoObra.Image = (Image) resources.GetObject("fieldTituloCostoTotalManoObra.Image");
            fieldTituloCostoTotalManoObra.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloCostoTotalManoObra.ImeMode = ImeMode.NoControl;
            fieldTituloCostoTotalManoObra.Location = new Point(15, 5);
            fieldTituloCostoTotalManoObra.Margin = new Padding(15, 5, 3, 3);
            fieldTituloCostoTotalManoObra.Name = "fieldTituloCostoTotalManoObra";
            fieldTituloCostoTotalManoObra.Size = new Size(269, 37);
            fieldTituloCostoTotalManoObra.TabIndex = 0;
            fieldTituloCostoTotalManoObra.Text = "      Costo total en actividades";
            fieldTituloCostoTotalManoObra.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldDescripcionActividad
            // 
            fieldDescripcionActividad.Dock = DockStyle.Fill;
            fieldDescripcionActividad.Font = new Font("Segoe UI", 11.25F);
            fieldDescripcionActividad.ForeColor = Color.Black;
            fieldDescripcionActividad.ImeMode = ImeMode.NoControl;
            fieldDescripcionActividad.Location = new Point(10, 85);
            fieldDescripcionActividad.Margin = new Padding(10, 5, 10, 1);
            fieldDescripcionActividad.Name = "fieldDescripcionActividad";
            fieldDescripcionActividad.Size = new Size(397, 66);
            fieldDescripcionActividad.TabIndex = 20;
            fieldDescripcionActividad.Text = "No ha descripción disponible para la actividad seleccionada";
            // 
            // layoutGestionMateriaPrima
            // 
            layoutGestionMateriaPrima.ColumnCount = 3;
            layoutGestionMateriaPrima.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutGestionMateriaPrima.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95F));
            layoutGestionMateriaPrima.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutGestionMateriaPrima.Controls.Add(btnAdicionarMateriaPrima, 2, 0);
            layoutGestionMateriaPrima.Controls.Add(fieldCantidad, 1, 0);
            layoutGestionMateriaPrima.Controls.Add(fieldNombreActividad, 0, 0);
            layoutGestionMateriaPrima.Dock = DockStyle.Fill;
            layoutGestionMateriaPrima.Location = new Point(0, 35);
            layoutGestionMateriaPrima.Margin = new Padding(0);
            layoutGestionMateriaPrima.Name = "layoutGestionMateriaPrima";
            layoutGestionMateriaPrima.RowCount = 1;
            layoutGestionMateriaPrima.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutGestionMateriaPrima.Size = new Size(417, 45);
            layoutGestionMateriaPrima.TabIndex = 19;
            // 
            // btnAdicionarMateriaPrima
            // 
            btnAdicionarMateriaPrima.Animated = true;
            btnAdicionarMateriaPrima.BorderRadius = 18;
            btnAdicionarMateriaPrima.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnAdicionarMateriaPrima.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnAdicionarMateriaPrima.CustomizableEdges = customizableEdges7;
            btnAdicionarMateriaPrima.DialogResult = DialogResult.Cancel;
            btnAdicionarMateriaPrima.Dock = DockStyle.Fill;
            btnAdicionarMateriaPrima.Enabled = false;
            btnAdicionarMateriaPrima.FillColor = Color.PeachPuff;
            btnAdicionarMateriaPrima.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnAdicionarMateriaPrima.ForeColor = Color.White;
            btnAdicionarMateriaPrima.Location = new Point(372, 5);
            btnAdicionarMateriaPrima.Margin = new Padding(5);
            btnAdicionarMateriaPrima.Name = "btnAdicionarMateriaPrima";
            btnAdicionarMateriaPrima.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnAdicionarMateriaPrima.Size = new Size(40, 35);
            btnAdicionarMateriaPrima.TabIndex = 2;
            // 
            // fieldCantidad
            // 
            fieldCantidad.Animated = true;
            fieldCantidad.BorderColor = Color.Gainsboro;
            fieldCantidad.BorderRadius = 16;
            fieldCantidad.Cursor = Cursors.IBeam;
            fieldCantidad.CustomizableEdges = customizableEdges9;
            fieldCantidad.DefaultText = "";
            fieldCantidad.DisabledState.BorderColor = Color.Gainsboro;
            fieldCantidad.DisabledState.FillColor = Color.White;
            fieldCantidad.DisabledState.ForeColor = Color.DimGray;
            fieldCantidad.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldCantidad.Dock = DockStyle.Fill;
            fieldCantidad.FocusedState.BorderColor = Color.SandyBrown;
            fieldCantidad.Font = new Font("Segoe UI", 11.25F);
            fieldCantidad.ForeColor = Color.Black;
            fieldCantidad.HoverState.BorderColor = Color.SandyBrown;
            fieldCantidad.IconLeftOffset = new Point(10, 0);
            fieldCantidad.IconRight = (Image) resources.GetObject("fieldCantidad.IconRight");
            fieldCantidad.IconRightOffset = new Point(6, 0);
            fieldCantidad.IconRightSize = new Size(12, 12);
            fieldCantidad.Location = new Point(277, 5);
            fieldCantidad.Margin = new Padding(5);
            fieldCantidad.Name = "fieldCantidad";
            fieldCantidad.PasswordChar = '\0';
            fieldCantidad.PlaceholderForeColor = Color.DimGray;
            fieldCantidad.PlaceholderText = "Cant.";
            fieldCantidad.SelectedText = "";
            fieldCantidad.ShadowDecoration.CustomizableEdges = customizableEdges10;
            fieldCantidad.Size = new Size(85, 35);
            fieldCantidad.TabIndex = 1;
            fieldCantidad.TextAlign = HorizontalAlignment.Right;
            fieldCantidad.TextOffset = new Point(5, 0);
            // 
            // fieldNombreActividad
            // 
            fieldNombreActividad.Animated = true;
            fieldNombreActividad.BorderColor = Color.Gainsboro;
            fieldNombreActividad.BorderRadius = 16;
            fieldNombreActividad.Cursor = Cursors.IBeam;
            fieldNombreActividad.CustomizableEdges = customizableEdges11;
            fieldNombreActividad.DefaultText = "";
            fieldNombreActividad.DisabledState.BorderColor = Color.Gainsboro;
            fieldNombreActividad.DisabledState.FillColor = Color.White;
            fieldNombreActividad.DisabledState.ForeColor = Color.DimGray;
            fieldNombreActividad.DisabledState.PlaceholderForeColor = Color.DimGray;
            fieldNombreActividad.Dock = DockStyle.Fill;
            fieldNombreActividad.FocusedState.BorderColor = Color.SandyBrown;
            fieldNombreActividad.Font = new Font("Segoe UI", 11.25F);
            fieldNombreActividad.ForeColor = Color.Black;
            fieldNombreActividad.HoverState.BorderColor = Color.SandyBrown;
            fieldNombreActividad.IconLeft = (Image) resources.GetObject("fieldNombreActividad.IconLeft");
            fieldNombreActividad.IconLeftOffset = new Point(10, 0);
            fieldNombreActividad.Location = new Point(5, 5);
            fieldNombreActividad.Margin = new Padding(5);
            fieldNombreActividad.Name = "fieldNombreActividad";
            fieldNombreActividad.PasswordChar = '\0';
            fieldNombreActividad.PlaceholderForeColor = Color.DimGray;
            fieldNombreActividad.PlaceholderText = "Nombre de la actividad";
            fieldNombreActividad.SelectedText = "";
            fieldNombreActividad.ShadowDecoration.CustomizableEdges = customizableEdges12;
            fieldNombreActividad.Size = new Size(262, 35);
            fieldNombreActividad.TabIndex = 0;
            fieldNombreActividad.TextOffset = new Point(5, 0);
            // 
            // fieldTituloManoObraDirecta
            // 
            fieldTituloManoObraDirecta.Dock = DockStyle.Fill;
            fieldTituloManoObraDirecta.Font = new Font("Segoe UI", 11.25F);
            fieldTituloManoObraDirecta.ForeColor = Color.DimGray;
            fieldTituloManoObraDirecta.Image = (Image) resources.GetObject("fieldTituloManoObraDirecta.Image");
            fieldTituloManoObraDirecta.ImageAlign = ContentAlignment.MiddleLeft;
            fieldTituloManoObraDirecta.ImeMode = ImeMode.NoControl;
            fieldTituloManoObraDirecta.Location = new Point(15, 5);
            fieldTituloManoObraDirecta.Margin = new Padding(15, 5, 3, 3);
            fieldTituloManoObraDirecta.Name = "fieldTituloManoObraDirecta";
            fieldTituloManoObraDirecta.Size = new Size(399, 27);
            fieldTituloManoObraDirecta.TabIndex = 5;
            fieldTituloManoObraDirecta.Text = "      Mano de obra directa :";
            fieldTituloManoObraDirecta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contenedorVistas
            // 
            contenedorVistas.Dock = DockStyle.Fill;
            contenedorVistas.Location = new Point(0, 197);
            contenedorVistas.Margin = new Padding(0);
            contenedorVistas.Name = "contenedorVistas";
            contenedorVistas.Size = new Size(417, 208);
            contenedorVistas.TabIndex = 11;
            // 
            // separador1
            // 
            separador1.Dock = DockStyle.Fill;
            separador1.FillColor = Color.FromArgb(  208,   197,   188);
            separador1.Location = new Point(3, 408);
            separador1.Name = "separador1";
            separador1.Size = new Size(411, 14);
            separador1.TabIndex = 23;
            // 
            // layoutEncabezadosTabla
            // 
            layoutEncabezadosTabla.BackColor = Color.WhiteSmoke;
            layoutEncabezadosTabla.ColumnCount = 5;
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutEncabezadosTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutEncabezadosTabla.Controls.Add(fieldTituloCantidad, 2, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloCosto, 1, 0);
            layoutEncabezadosTabla.Controls.Add(fieldTituloActividad, 0, 0);
            layoutEncabezadosTabla.Dock = DockStyle.Fill;
            layoutEncabezadosTabla.Location = new Point(1, 153);
            layoutEncabezadosTabla.Margin = new Padding(1);
            layoutEncabezadosTabla.Name = "layoutEncabezadosTabla";
            layoutEncabezadosTabla.RowCount = 1;
            layoutEncabezadosTabla.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutEncabezadosTabla.Size = new Size(415, 43);
            layoutEncabezadosTabla.TabIndex = 22;
            // 
            // fieldTituloCantidad
            // 
            fieldTituloCantidad.Dock = DockStyle.Fill;
            fieldTituloCantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldTituloCantidad.ForeColor = Color.Black;
            fieldTituloCantidad.ImeMode = ImeMode.NoControl;
            fieldTituloCantidad.Location = new Point(306, 1);
            fieldTituloCantidad.Margin = new Padding(1);
            fieldTituloCantidad.Name = "fieldTituloCantidad";
            fieldTituloCantidad.Size = new Size(48, 41);
            fieldTituloCantidad.TabIndex = 2;
            fieldTituloCantidad.Text = "C";
            fieldTituloCantidad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloCosto
            // 
            fieldTituloCosto.Dock = DockStyle.Fill;
            fieldTituloCosto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldTituloCosto.ForeColor = Color.Black;
            fieldTituloCosto.ImeMode = ImeMode.NoControl;
            fieldTituloCosto.Location = new Point(176, 1);
            fieldTituloCosto.Margin = new Padding(1);
            fieldTituloCosto.Name = "fieldTituloCosto";
            fieldTituloCosto.Size = new Size(128, 41);
            fieldTituloCosto.TabIndex = 1;
            fieldTituloCosto.Text = "Costo";
            fieldTituloCosto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldTituloActividad
            // 
            fieldTituloActividad.Dock = DockStyle.Fill;
            fieldTituloActividad.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldTituloActividad.ForeColor = Color.Black;
            fieldTituloActividad.ImeMode = ImeMode.NoControl;
            fieldTituloActividad.Location = new Point(1, 1);
            fieldTituloActividad.Margin = new Padding(1);
            fieldTituloActividad.Name = "fieldTituloActividad";
            fieldTituloActividad.Size = new Size(173, 41);
            fieldTituloActividad.TabIndex = 0;
            fieldTituloActividad.Text = "Actividad";
            fieldTituloActividad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VistaRegistroManoObra
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(417, 470);
            Controls.Add(layoutBase);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VistaRegistroManoObra";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaRegistroProductoDatosGenerales";
            layoutBase.ResumeLayout(false);
            layoutSubtotal.ResumeLayout(false);
            layoutGestionMateriaPrima.ResumeLayout(false);
            layoutEncabezadosTabla.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private Label fieldTituloManoObraDirecta;
        private Panel contenedorVistas;
        private TableLayoutPanel layoutGestionMateriaPrima;
        private Guna.UI2.WinForms.Guna2Button btnAdicionarMateriaPrima;
        private Guna.UI2.WinForms.Guna2TextBox fieldCantidad;
        private Guna.UI2.WinForms.Guna2TextBox fieldNombreActividad;
        private Label fieldDescripcionActividad;
        private TableLayoutPanel layoutEncabezadosTabla;
        private Label fieldTituloCantidad;
        private Label fieldTituloCosto;
        private Label fieldTituloActividad;
        private Guna.UI2.WinForms.Guna2Separator separador1;
        private TableLayoutPanel layoutSubtotal;
        private Label symbolPeso;
        private Label fieldCostoTotalActividades;
        private Label fieldTituloCostoTotalManoObra;
    }
}