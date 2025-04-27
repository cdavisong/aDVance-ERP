namespace aDVanceINSTALL.Desktop.MVP.Vistas {
    partial class VistaInstalacionCompletada {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaInstalacionCompletada));
            formatoBase = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutDistribucion = new TableLayoutPanel();
            fieldImagen = new PictureBox();
            layoutDistribucion2 = new TableLayoutPanel();
            fieldTitulo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            fieldInfo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            layoutBase.SuspendLayout();
            layoutDistribucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) fieldImagen).BeginInit();
            layoutDistribucion2.SuspendLayout();
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
            layoutBase.Size = new Size(796, 387);
            layoutBase.TabIndex = 2;
            // 
            // layoutDistribucion
            // 
            layoutDistribucion.BackColor = Color.White;
            layoutDistribucion.ColumnCount = 2;
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            layoutDistribucion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutDistribucion.Controls.Add(fieldImagen, 0, 0);
            layoutDistribucion.Controls.Add(layoutDistribucion2, 1, 0);
            layoutDistribucion.Dock = DockStyle.Fill;
            layoutDistribucion.Location = new Point(0, 0);
            layoutDistribucion.Margin = new Padding(0);
            layoutDistribucion.Name = "layoutDistribucion";
            layoutDistribucion.RowCount = 1;
            layoutDistribucion.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutDistribucion.Size = new Size(796, 387);
            layoutDistribucion.TabIndex = 1;
            // 
            // fieldImagen
            // 
            fieldImagen.BackgroundImageLayout = ImageLayout.Center;
            fieldImagen.Dock = DockStyle.Fill;
            fieldImagen.Image = (Image) resources.GetObject("fieldImagen.Image");
            fieldImagen.Location = new Point(3, 3);
            fieldImagen.Name = "fieldImagen";
            fieldImagen.Size = new Size(244, 381);
            fieldImagen.TabIndex = 1;
            fieldImagen.TabStop = false;
            // 
            // layoutDistribucion2
            // 
            layoutDistribucion2.ColumnCount = 1;
            layoutDistribucion2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutDistribucion2.Controls.Add(fieldInfo, 0, 1);
            layoutDistribucion2.Controls.Add(fieldTitulo, 0, 0);
            layoutDistribucion2.Dock = DockStyle.Fill;
            layoutDistribucion2.Location = new Point(250, 0);
            layoutDistribucion2.Margin = new Padding(0);
            layoutDistribucion2.Name = "layoutDistribucion2";
            layoutDistribucion2.RowCount = 2;
            layoutDistribucion2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            layoutDistribucion2.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            layoutDistribucion2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutDistribucion2.Size = new Size(546, 387);
            layoutDistribucion2.TabIndex = 2;
            // 
            // fieldTitulo
            // 
            fieldTitulo.AutoSize = false;
            fieldTitulo.BackColor = Color.White;
            fieldTitulo.Dock = DockStyle.Fill;
            fieldTitulo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldTitulo.Location = new Point(10, 10);
            fieldTitulo.Margin = new Padding(10, 10, 30, 10);
            fieldTitulo.Name = "fieldTitulo";
            fieldTitulo.Size = new Size(506, 57);
            fieldTitulo.TabIndex = 3;
            fieldTitulo.Text = "<h3>Instalación completada exitosamente!</h3>";
            fieldTitulo.UseGdiPlusTextRendering = true;
            // 
            // fieldInfo
            // 
            fieldInfo.AutoSize = false;
            fieldInfo.BackColor = Color.White;
            fieldInfo.Dock = DockStyle.Fill;
            fieldInfo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldInfo.Location = new Point(10, 87);
            fieldInfo.Margin = new Padding(10, 10, 30, 10);
            fieldInfo.Name = "fieldInfo";
            fieldInfo.Size = new Size(506, 290);
            fieldInfo.TabIndex = 4;
            fieldInfo.Text = "La aplicación ha sido instalada correctamente en su sistema. \r\n<p>Gracias por instalar aDVance ERP!";
            fieldInfo.UseGdiPlusTextRendering = true;
            // 
            // VistaInstalacionCompletada
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(796, 387);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaInstalacionCompletada";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaInstalacionCompletada";
            layoutBase.ResumeLayout(false);
            layoutDistribucion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) fieldImagen).EndInit();
            layoutDistribucion2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutDistribucion;
        private PictureBox fieldImagen;
        private TableLayoutPanel layoutDistribucion2;
        private Guna.UI2.WinForms.Guna2HtmlLabel fieldTitulo;
        private Guna.UI2.WinForms.Guna2HtmlLabel fieldInfo;
    }
}