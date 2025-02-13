using Guna.UI2.WinForms;

using System.ComponentModel;

namespace Manigest.Modulos.Contactos.MVP.Vistas.Proveedor {
    partial class VistaTuplaProveedor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(VistaTuplaProveedor));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            formatoBase = new Guna2BorderlessForm(components);
            layoutBase = new TableLayoutPanel();
            layoutVista = new TableLayoutPanel();
            btnEliminar = new Guna2Button();
            fieldNumeroIdentificacionTributaria = new Label();
            fieldId = new Label();
            btnEditar = new Guna2Button();
            fieldNombreRepresentante = new Label();
            fieldRazonSocial = new Label();
            layoutBase.SuspendLayout();
            layoutVista.SuspendLayout();
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
            layoutBase.BackColor = Color.FromArgb(  217,   211,   204);
            layoutBase.ColumnCount = 1;
            layoutBase.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutBase.Controls.Add(layoutVista, 0, 0);
            layoutBase.Dock = DockStyle.Fill;
            layoutBase.Location = new Point(0, 0);
            layoutBase.Name = "layoutBase";
            layoutBase.RowCount = 1;
            layoutBase.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            layoutBase.Size = new Size(1241, 42);
            layoutBase.TabIndex = 1;
            // 
            // layoutVista
            // 
            layoutVista.BackColor = Color.FromArgb(  248,   244,   242);
            layoutVista.ColumnCount = 8;
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            layoutVista.Controls.Add(btnEliminar, 7, 0);
            layoutVista.Controls.Add(fieldNumeroIdentificacionTributaria, 1, 0);
            layoutVista.Controls.Add(fieldId, 0, 0);
            layoutVista.Controls.Add(btnEditar, 6, 0);
            layoutVista.Controls.Add(fieldNombreRepresentante, 3, 0);
            layoutVista.Controls.Add(fieldRazonSocial, 2, 0);
            layoutVista.Dock = DockStyle.Fill;
            layoutVista.Location = new Point(0, 0);
            layoutVista.Margin = new Padding(0, 0, 0, 2);
            layoutVista.Name = "layoutVista";
            layoutVista.RowCount = 1;
            layoutVista.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutVista.Size = new Size(1241, 40);
            layoutVista.TabIndex = 18;
            // 
            // btnEliminar
            // 
            btnEliminar.Animated = true;
            btnEliminar.BorderColor = Color.FromArgb(  217,   211,   204);
            btnEliminar.BorderRadius = 16;
            btnEliminar.BorderThickness = 1;
            btnEliminar.CustomImages.HoveredImage = (Image) resources.GetObject("resource.HoveredImage");
            btnEliminar.CustomImages.Image = (Image) resources.GetObject("resource.Image");
            btnEliminar.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEliminar.CustomizableEdges = customizableEdges1;
            btnEliminar.Dock = DockStyle.Fill;
            btnEliminar.FillColor = Color.FromArgb(  250,   250,   250);
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.HoverState.BorderColor = Color.FromArgb(  217,   211,   204);
            btnEliminar.HoverState.FillColor = Color.FromArgb(  217,   211,   204);
            btnEliminar.HoverState.ForeColor = Color.White;
            btnEliminar.Location = new Point(1204, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnEliminar.Size = new Size(34, 34);
            btnEliminar.TabIndex = 11;
            // 
            // fieldNumeroIdentificacionTributaria
            // 
            fieldNumeroIdentificacionTributaria.Dock = DockStyle.Fill;
            fieldNumeroIdentificacionTributaria.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNumeroIdentificacionTributaria.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldNumeroIdentificacionTributaria.ImeMode = ImeMode.NoControl;
            fieldNumeroIdentificacionTributaria.Location = new Point(61, 1);
            fieldNumeroIdentificacionTributaria.Margin = new Padding(1);
            fieldNumeroIdentificacionTributaria.Name = "fieldNumeroIdentificacionTributaria";
            fieldNumeroIdentificacionTributaria.Size = new Size(218, 38);
            fieldNumeroIdentificacionTributaria.TabIndex = 4;
            fieldNumeroIdentificacionTributaria.Text = "nit";
            fieldNumeroIdentificacionTributaria.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldId
            // 
            fieldId.Dock = DockStyle.Fill;
            fieldId.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldId.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldId.ImeMode = ImeMode.NoControl;
            fieldId.Location = new Point(1, 1);
            fieldId.Margin = new Padding(1);
            fieldId.Name = "fieldId";
            fieldId.Size = new Size(58, 38);
            fieldId.TabIndex = 13;
            fieldId.Text = "id";
            fieldId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEditar
            // 
            btnEditar.Animated = true;
            btnEditar.BorderColor = Color.FromArgb(  217,   211,   204);
            btnEditar.BorderRadius = 16;
            btnEditar.BorderThickness = 1;
            btnEditar.CustomImages.HoveredImage = (Image) resources.GetObject("resource.HoveredImage1");
            btnEditar.CustomImages.Image = (Image) resources.GetObject("resource.Image1");
            btnEditar.CustomImages.ImageAlign = HorizontalAlignment.Center;
            btnEditar.CustomizableEdges = customizableEdges3;
            btnEditar.Dock = DockStyle.Fill;
            btnEditar.FillColor = Color.FromArgb(  250,   250,   250);
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditar.ForeColor = Color.White;
            btnEditar.HoverState.BorderColor = Color.FromArgb(  217,   211,   204);
            btnEditar.HoverState.FillColor = Color.FromArgb(  217,   211,   204);
            btnEditar.Location = new Point(1164, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnEditar.Size = new Size(34, 34);
            btnEditar.TabIndex = 9;
            // 
            // fieldNombreRepresentante
            // 
            fieldNombreRepresentante.Dock = DockStyle.Fill;
            fieldNombreRepresentante.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldNombreRepresentante.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldNombreRepresentante.ImeMode = ImeMode.NoControl;
            fieldNombreRepresentante.Location = new Point(531, 1);
            fieldNombreRepresentante.Margin = new Padding(1);
            fieldNombreRepresentante.Name = "fieldNombreRepresentante";
            fieldNombreRepresentante.Size = new Size(248, 38);
            fieldNombreRepresentante.TabIndex = 14;
            fieldNombreRepresentante.Text = "nombreRepresentante";
            fieldNombreRepresentante.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // fieldRazonSocial
            // 
            fieldRazonSocial.AutoEllipsis = true;
            fieldRazonSocial.Dock = DockStyle.Fill;
            fieldRazonSocial.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            fieldRazonSocial.ForeColor = Color.FromArgb(  115,   109,   106);
            fieldRazonSocial.ImeMode = ImeMode.NoControl;
            fieldRazonSocial.Location = new Point(281, 1);
            fieldRazonSocial.Margin = new Padding(1);
            fieldRazonSocial.Name = "fieldRazonSocial";
            fieldRazonSocial.Size = new Size(248, 38);
            fieldRazonSocial.TabIndex = 6;
            fieldRazonSocial.Text = "razonSocial";
            fieldRazonSocial.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // VistaTuplaProveedor
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(  248,   244,   242);
            ClientSize = new Size(1241, 42);
            Controls.Add(layoutBase);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "VistaTuplaProveedor";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "VistaTuplaProveedor";
            layoutBase.ResumeLayout(false);
            layoutVista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna2BorderlessForm formatoBase;
        private TableLayoutPanel layoutBase;
        private TableLayoutPanel layoutVista;
        private Guna2Button btnEliminar;
        private Label fieldNumeroIdentificacionTributaria;
        private Label fieldId;
        private Guna2Button btnEditar;
        private Label fieldNombreRepresentante;
        private Label fieldRazonSocial;
    }
}