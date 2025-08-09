namespace aDVanceERP.Core.Controles {
    partial class TablaResultadosBusqueda {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TablaResultadosBusqueda));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            layoutBase = new TableLayoutPanel();
            panelResultados = new Panel();
            layoutControlesTabla = new TableLayoutPanel();
            btnPaginaAnterior = new Guna.UI2.WinForms.Guna2Button();
            btnPrimeraPagina = new Guna.UI2.WinForms.Guna2Button();
            btnPaginaSiguiente = new Guna.UI2.WinForms.Guna2Button();
            btnUltimaPagina = new Guna.UI2.WinForms.Guna2Button();
            btnSincronizarDatos = new Guna.UI2.WinForms.Guna2Button();
            fieldPaginaActual = new Label();
            fieldPaginasTotales = new Label();
            layoutBase.SuspendLayout();
            layoutControlesTabla.SuspendLayout();
            SuspendLayout();
            // 
            // layoutBase
            // 
            layoutBase.BackColor = Color.WhiteSmoke;
            layoutBase.ColumnCount = 1;
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            layoutBase.Controls.Add(layoutControlesTabla, 0, 1);
            layoutBase.Controls.Add(panelResultados, 0, 0);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Margin = new Padding(0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 2;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            layoutBase.Size = new Size(700, 200);
            layoutBase.TabIndex = 0;
            // 
            // panelResultados
            // 
            panelResultados.BackColor = Color.White;
            panelResultados.Dock = DockStyle.Fill;
            panelResultados.Location = new Point(0, 0);
            panelResultados.Margin = new Padding(0);
            panelResultados.Name = "panelResultados";
            panelResultados.Size = new Size(700, 165);
            panelResultados.TabIndex = 14;
            // 
            // layoutControlesTabla
            // 
            layoutControlesTabla.BackColor = Color.WhiteSmoke;
            layoutControlesTabla.ColumnCount = 13;
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            layoutControlesTabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutControlesTabla.Controls.Add(btnPaginaAnterior, 1, 0);
            layoutControlesTabla.Controls.Add(btnPrimeraPagina, 0, 0);
            layoutControlesTabla.Controls.Add(btnPaginaSiguiente, 6, 0);
            layoutControlesTabla.Controls.Add(btnUltimaPagina, 7, 0);
            layoutControlesTabla.Controls.Add(btnSincronizarDatos, 9, 0);
            layoutControlesTabla.Controls.Add(fieldPaginaActual, 3, 0);
            layoutControlesTabla.Controls.Add(fieldPaginasTotales, 4, 0);
            layoutControlesTabla.Dock = DockStyle.Fill;
            layoutControlesTabla.Location = new Point(0, 165);
            layoutControlesTabla.Margin = new Padding(0);
            layoutControlesTabla.Name = "layoutControlesTabla";
            layoutControlesTabla.RowCount = 1;
            layoutControlesTabla.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutControlesTabla.Size = new Size(700, 35);
            layoutControlesTabla.TabIndex = 18;
            // 
            // btnPaginaAnterior
            // 
            btnPaginaAnterior.Animated = true;
            btnPaginaAnterior.BackColor = Color.WhiteSmoke;
            btnPaginaAnterior.CheckedState.BorderColor = Color.WhiteSmoke;
            btnPaginaAnterior.CheckedState.FillColor = Color.WhiteSmoke;
            btnPaginaAnterior.CustomImages.Image = (Image)resources.GetObject("resource.Image");
            btnPaginaAnterior.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnPaginaAnterior.CustomImages.ImageSize = new Size(24, 24);
            btnPaginaAnterior.CustomizableEdges = customizableEdges11;
            btnPaginaAnterior.Dock = DockStyle.Fill;
            btnPaginaAnterior.FillColor = Color.WhiteSmoke;
            btnPaginaAnterior.Font = new Font("Segoe UI", 9F);
            btnPaginaAnterior.ForeColor = Color.White;
            btnPaginaAnterior.HoverState.BorderColor = Color.FromArgb(245, 245, 245);
            btnPaginaAnterior.HoverState.FillColor = Color.WhiteSmoke;
            btnPaginaAnterior.ImageSize = new Size(24, 24);
            btnPaginaAnterior.Location = new Point(36, 1);
            btnPaginaAnterior.Margin = new Padding(1);
            btnPaginaAnterior.Name = "btnPaginaAnterior";
            btnPaginaAnterior.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnPaginaAnterior.Size = new Size(33, 33);
            btnPaginaAnterior.TabIndex = 1;
            // 
            // btnPrimeraPagina
            // 
            btnPrimeraPagina.Animated = true;
            btnPrimeraPagina.BackColor = Color.WhiteSmoke;
            btnPrimeraPagina.CheckedState.BorderColor = Color.WhiteSmoke;
            btnPrimeraPagina.CheckedState.FillColor = Color.WhiteSmoke;
            btnPrimeraPagina.CustomImages.Image = (Image)resources.GetObject("resource.Image1");
            btnPrimeraPagina.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnPrimeraPagina.CustomImages.ImageSize = new Size(24, 24);
            btnPrimeraPagina.CustomizableEdges = customizableEdges13;
            btnPrimeraPagina.Dock = DockStyle.Fill;
            btnPrimeraPagina.FillColor = Color.WhiteSmoke;
            btnPrimeraPagina.Font = new Font("Segoe UI", 9F);
            btnPrimeraPagina.ForeColor = Color.White;
            btnPrimeraPagina.HoverState.BorderColor = Color.FromArgb(245, 245, 245);
            btnPrimeraPagina.HoverState.FillColor = Color.WhiteSmoke;
            btnPrimeraPagina.ImageSize = new Size(24, 24);
            btnPrimeraPagina.Location = new Point(1, 1);
            btnPrimeraPagina.Margin = new Padding(1);
            btnPrimeraPagina.Name = "btnPrimeraPagina";
            btnPrimeraPagina.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnPrimeraPagina.Size = new Size(33, 33);
            btnPrimeraPagina.TabIndex = 0;
            // 
            // btnPaginaSiguiente
            // 
            btnPaginaSiguiente.Animated = true;
            btnPaginaSiguiente.BackColor = Color.WhiteSmoke;
            btnPaginaSiguiente.CheckedState.BorderColor = Color.WhiteSmoke;
            btnPaginaSiguiente.CheckedState.FillColor = Color.WhiteSmoke;
            btnPaginaSiguiente.CustomImages.Image = (Image)resources.GetObject("resource.Image2");
            btnPaginaSiguiente.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnPaginaSiguiente.CustomImages.ImageSize = new Size(24, 24);
            btnPaginaSiguiente.CustomizableEdges = customizableEdges15;
            btnPaginaSiguiente.Dock = DockStyle.Fill;
            btnPaginaSiguiente.FillColor = Color.WhiteSmoke;
            btnPaginaSiguiente.Font = new Font("Segoe UI", 9F);
            btnPaginaSiguiente.ForeColor = Color.White;
            btnPaginaSiguiente.HoverState.BorderColor = Color.FromArgb(245, 245, 245);
            btnPaginaSiguiente.HoverState.FillColor = Color.WhiteSmoke;
            btnPaginaSiguiente.ImageSize = new Size(24, 24);
            btnPaginaSiguiente.Location = new Point(311, 1);
            btnPaginaSiguiente.Margin = new Padding(1);
            btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            btnPaginaSiguiente.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnPaginaSiguiente.Size = new Size(33, 33);
            btnPaginaSiguiente.TabIndex = 2;
            // 
            // btnUltimaPagina
            // 
            btnUltimaPagina.Animated = true;
            btnUltimaPagina.BackColor = Color.WhiteSmoke;
            btnUltimaPagina.CheckedState.BorderColor = Color.WhiteSmoke;
            btnUltimaPagina.CheckedState.FillColor = Color.WhiteSmoke;
            btnUltimaPagina.CustomImages.Image = (Image)resources.GetObject("resource.Image3");
            btnUltimaPagina.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnUltimaPagina.CustomImages.ImageSize = new Size(24, 24);
            btnUltimaPagina.CustomizableEdges = customizableEdges17;
            btnUltimaPagina.Dock = DockStyle.Fill;
            btnUltimaPagina.FillColor = Color.WhiteSmoke;
            btnUltimaPagina.Font = new Font("Segoe UI", 9F);
            btnUltimaPagina.ForeColor = Color.White;
            btnUltimaPagina.HoverState.BorderColor = Color.FromArgb(245, 245, 245);
            btnUltimaPagina.HoverState.FillColor = Color.WhiteSmoke;
            btnUltimaPagina.ImageSize = new Size(24, 24);
            btnUltimaPagina.Location = new Point(346, 1);
            btnUltimaPagina.Margin = new Padding(1);
            btnUltimaPagina.Name = "btnUltimaPagina";
            btnUltimaPagina.ShadowDecoration.CustomizableEdges = customizableEdges18;
            btnUltimaPagina.Size = new Size(33, 33);
            btnUltimaPagina.TabIndex = 3;
            // 
            // btnSincronizarDatos
            // 
            btnSincronizarDatos.Animated = true;
            btnSincronizarDatos.BackColor = Color.WhiteSmoke;
            btnSincronizarDatos.CheckedState.BorderColor = Color.WhiteSmoke;
            btnSincronizarDatos.CheckedState.FillColor = Color.WhiteSmoke;
            btnSincronizarDatos.CustomImages.Image = (Image)resources.GetObject("resource.Image4");
            btnSincronizarDatos.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnSincronizarDatos.CustomImages.ImageSize = new Size(24, 24);
            btnSincronizarDatos.CustomizableEdges = customizableEdges19;
            btnSincronizarDatos.Dock = DockStyle.Fill;
            btnSincronizarDatos.FillColor = Color.WhiteSmoke;
            btnSincronizarDatos.Font = new Font("Segoe UI", 9F);
            btnSincronizarDatos.ForeColor = Color.White;
            btnSincronizarDatos.HoverState.BorderColor = Color.FromArgb(245, 245, 245);
            btnSincronizarDatos.HoverState.FillColor = Color.WhiteSmoke;
            btnSincronizarDatos.ImageSize = new Size(24, 24);
            btnSincronizarDatos.Location = new Point(391, 1);
            btnSincronizarDatos.Margin = new Padding(1);
            btnSincronizarDatos.Name = "btnSincronizarDatos";
            btnSincronizarDatos.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnSincronizarDatos.Size = new Size(33, 33);
            btnSincronizarDatos.TabIndex = 4;
            // 
            // fieldPaginaActual
            // 
            fieldPaginaActual.Dock = DockStyle.Fill;
            fieldPaginaActual.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldPaginaActual.ForeColor = Color.Black;
            fieldPaginaActual.ImeMode = ImeMode.NoControl;
            fieldPaginaActual.Location = new Point(81, 1);
            fieldPaginaActual.Margin = new Padding(1, 1, 0, 1);
            fieldPaginaActual.Name = "fieldPaginaActual";
            fieldPaginaActual.Size = new Size(119, 33);
            fieldPaginaActual.TabIndex = 5;
            fieldPaginaActual.Text = "Página 1";
            fieldPaginaActual.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fieldPaginasTotales
            // 
            fieldPaginasTotales.Dock = DockStyle.Fill;
            fieldPaginasTotales.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            fieldPaginasTotales.ForeColor = Color.Black;
            fieldPaginasTotales.ImeMode = ImeMode.NoControl;
            fieldPaginasTotales.Location = new Point(200, 1);
            fieldPaginasTotales.Margin = new Padding(0, 1, 1, 1);
            fieldPaginasTotales.Name = "fieldPaginasTotales";
            fieldPaginasTotales.Size = new Size(99, 33);
            fieldPaginasTotales.TabIndex = 6;
            fieldPaginasTotales.Text = "de 1";
            fieldPaginasTotales.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TablaResultados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutBase);
            Name = "TablaResultados";
            Size = new Size(700, 200);
            layoutBase.ResumeLayout(false);
            layoutControlesTabla.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layoutBase;
        private Panel panelResultados;
        private TableLayoutPanel layoutControlesTabla;
        private Guna.UI2.WinForms.Guna2Button btnPaginaAnterior;
        private Guna.UI2.WinForms.Guna2Button btnPrimeraPagina;
        private Guna.UI2.WinForms.Guna2Button btnPaginaSiguiente;
        private Guna.UI2.WinForms.Guna2Button btnUltimaPagina;
        private Guna.UI2.WinForms.Guna2Button btnSincronizarDatos;
        private Label fieldPaginaActual;
        private Label fieldPaginasTotales;
    }
}
