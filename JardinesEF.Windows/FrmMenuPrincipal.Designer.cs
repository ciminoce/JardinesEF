
namespace JardinesEF.Windows
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CategoriasButton = new System.Windows.Forms.Button();
            this.VentasButton = new System.Windows.Forms.Button();
            this.ProductosButton = new System.Windows.Forms.Button();
            this.ProveedoresButton = new System.Windows.Forms.Button();
            this.ClientesButton = new System.Windows.Forms.Button();
            this.CiudadesButton = new System.Windows.Forms.Button();
            this.PaisesButton = new System.Windows.Forms.Button();
            this.CerrarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Neptuno SRL";
            // 
            // CategoriasButton
            // 
            this.CategoriasButton.Image = global::JardinesEF.Windows.Properties.Resources.categorize_50px;
            this.CategoriasButton.Location = new System.Drawing.Point(44, 268);
            this.CategoriasButton.Name = "CategoriasButton";
            this.CategoriasButton.Size = new System.Drawing.Size(147, 76);
            this.CategoriasButton.TabIndex = 5;
            this.CategoriasButton.Text = "Categorías";
            this.CategoriasButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CategoriasButton.UseVisualStyleBackColor = true;
            this.CategoriasButton.Click += new System.EventHandler(this.CategoriasButton_Click);
            // 
            // VentasButton
            // 
            this.VentasButton.Image = global::JardinesEF.Windows.Properties.Resources.cash_register_50px;
            this.VentasButton.Location = new System.Drawing.Point(577, 268);
            this.VentasButton.Name = "VentasButton";
            this.VentasButton.Size = new System.Drawing.Size(147, 76);
            this.VentasButton.TabIndex = 6;
            this.VentasButton.Text = "Ventas";
            this.VentasButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.VentasButton.UseVisualStyleBackColor = true;
            this.VentasButton.Click += new System.EventHandler(this.VentasButton_Click);
            // 
            // ProductosButton
            // 
            this.ProductosButton.Image = global::JardinesEF.Windows.Properties.Resources.used_product_50px;
            this.ProductosButton.Location = new System.Drawing.Point(409, 268);
            this.ProductosButton.Name = "ProductosButton";
            this.ProductosButton.Size = new System.Drawing.Size(147, 76);
            this.ProductosButton.TabIndex = 7;
            this.ProductosButton.Text = "Productos";
            this.ProductosButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ProductosButton.UseVisualStyleBackColor = true;
            this.ProductosButton.Click += new System.EventHandler(this.ProductosButton_Click);
            // 
            // ProveedoresButton
            // 
            this.ProveedoresButton.Image = global::JardinesEF.Windows.Properties.Resources.customer_50px;
            this.ProveedoresButton.Location = new System.Drawing.Point(226, 268);
            this.ProveedoresButton.Name = "ProveedoresButton";
            this.ProveedoresButton.Size = new System.Drawing.Size(147, 76);
            this.ProveedoresButton.TabIndex = 8;
            this.ProveedoresButton.Text = "Proveedores";
            this.ProveedoresButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ProveedoresButton.UseVisualStyleBackColor = true;
            this.ProveedoresButton.Click += new System.EventHandler(this.ProveedoresButton_Click);
            // 
            // ClientesButton
            // 
            this.ClientesButton.Image = global::JardinesEF.Windows.Properties.Resources.client_management_50px;
            this.ClientesButton.Location = new System.Drawing.Point(409, 151);
            this.ClientesButton.Name = "ClientesButton";
            this.ClientesButton.Size = new System.Drawing.Size(147, 76);
            this.ClientesButton.TabIndex = 9;
            this.ClientesButton.Text = "Clientes";
            this.ClientesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ClientesButton.UseVisualStyleBackColor = true;
            this.ClientesButton.Click += new System.EventHandler(this.ClientesButton_Click);
            // 
            // CiudadesButton
            // 
            this.CiudadesButton.Image = global::JardinesEF.Windows.Properties.Resources.city_50px;
            this.CiudadesButton.Location = new System.Drawing.Point(226, 151);
            this.CiudadesButton.Name = "CiudadesButton";
            this.CiudadesButton.Size = new System.Drawing.Size(147, 76);
            this.CiudadesButton.TabIndex = 10;
            this.CiudadesButton.Text = "Ciudades";
            this.CiudadesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CiudadesButton.UseVisualStyleBackColor = true;
            this.CiudadesButton.Click += new System.EventHandler(this.CiudadesButton_Click);
            // 
            // PaisesButton
            // 
            this.PaisesButton.Image = global::JardinesEF.Windows.Properties.Resources.america_50px;
            this.PaisesButton.Location = new System.Drawing.Point(44, 151);
            this.PaisesButton.Name = "PaisesButton";
            this.PaisesButton.Size = new System.Drawing.Size(147, 76);
            this.PaisesButton.TabIndex = 11;
            this.PaisesButton.Text = "Países";
            this.PaisesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PaisesButton.UseVisualStyleBackColor = true;
            this.PaisesButton.Click += new System.EventHandler(this.PaisesButton_Click);
            // 
            // CerrarButton
            // 
            this.CerrarButton.Image = global::JardinesEF.Windows.Properties.Resources.shutdown_30px;
            this.CerrarButton.Location = new System.Drawing.Point(1054, 529);
            this.CerrarButton.Name = "CerrarButton";
            this.CerrarButton.Size = new System.Drawing.Size(75, 59);
            this.CerrarButton.TabIndex = 4;
            this.CerrarButton.UseVisualStyleBackColor = true;
            this.CerrarButton.Click += new System.EventHandler(this.CerrarButton_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 636);
            this.Controls.Add(this.CategoriasButton);
            this.Controls.Add(this.VentasButton);
            this.Controls.Add(this.ProductosButton);
            this.Controls.Add(this.ProveedoresButton);
            this.Controls.Add(this.ClientesButton);
            this.Controls.Add(this.CiudadesButton);
            this.Controls.Add(this.PaisesButton);
            this.Controls.Add(this.CerrarButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMenuPrincipal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CategoriasButton;
        private System.Windows.Forms.Button VentasButton;
        private System.Windows.Forms.Button ProductosButton;
        private System.Windows.Forms.Button ProveedoresButton;
        private System.Windows.Forms.Button ClientesButton;
        private System.Windows.Forms.Button CiudadesButton;
        private System.Windows.Forms.Button PaisesButton;
        private System.Windows.Forms.Button CerrarButton;
        private System.Windows.Forms.Label label1;
    }
}