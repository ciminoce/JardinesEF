
namespace JardinesEF.Windows
{
    partial class FrmProductosEdit
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
            this.components = new System.ComponentModel.Container();
            this.SuspendidoCheckBox = new System.Windows.Forms.CheckBox();
            this.CategoriaComboBox = new System.Windows.Forms.ComboBox();
            this.ProveedorComboBox = new System.Windows.Forms.ComboBox();
            this.NivelReposicionTextBox = new System.Windows.Forms.TextBox();
            this.StockTextBox = new System.Windows.Forms.TextBox();
            this.PrecioTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ProductoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.NombreLatinTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // SuspendidoCheckBox
            // 
            this.SuspendidoCheckBox.AutoSize = true;
            this.SuspendidoCheckBox.Location = new System.Drawing.Point(643, 149);
            this.SuspendidoCheckBox.Name = "SuspendidoCheckBox";
            this.SuspendidoCheckBox.Size = new System.Drawing.Size(82, 17);
            this.SuspendidoCheckBox.TabIndex = 36;
            this.SuspendidoCheckBox.Text = "Suspendido";
            this.SuspendidoCheckBox.UseVisualStyleBackColor = true;
            // 
            // CategoriaComboBox
            // 
            this.CategoriaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriaComboBox.FormattingEnabled = true;
            this.CategoriaComboBox.Location = new System.Drawing.Point(120, 108);
            this.CategoriaComboBox.Name = "CategoriaComboBox";
            this.CategoriaComboBox.Size = new System.Drawing.Size(476, 21);
            this.CategoriaComboBox.TabIndex = 34;
            // 
            // ProveedorComboBox
            // 
            this.ProveedorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProveedorComboBox.FormattingEnabled = true;
            this.ProveedorComboBox.Location = new System.Drawing.Point(120, 76);
            this.ProveedorComboBox.Name = "ProveedorComboBox";
            this.ProveedorComboBox.Size = new System.Drawing.Size(476, 21);
            this.ProveedorComboBox.TabIndex = 35;
            // 
            // NivelReposicionTextBox
            // 
            this.NivelReposicionTextBox.Location = new System.Drawing.Point(525, 146);
            this.NivelReposicionTextBox.Name = "NivelReposicionTextBox";
            this.NivelReposicionTextBox.Size = new System.Drawing.Size(71, 20);
            this.NivelReposicionTextBox.TabIndex = 30;
            // 
            // StockTextBox
            // 
            this.StockTextBox.Location = new System.Drawing.Point(303, 146);
            this.StockTextBox.Name = "StockTextBox";
            this.StockTextBox.Size = new System.Drawing.Size(97, 20);
            this.StockTextBox.TabIndex = 31;
            // 
            // PrecioTextBox
            // 
            this.PrecioTextBox.Location = new System.Drawing.Point(120, 146);
            this.PrecioTextBox.Name = "PrecioTextBox";
            this.PrecioTextBox.Size = new System.Drawing.Size(97, 20);
            this.PrecioTextBox.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Nivel Repoición:";
            // 
            // ProductoTextBox
            // 
            this.ProductoTextBox.Location = new System.Drawing.Point(120, 12);
            this.ProductoTextBox.Name = "ProductoTextBox";
            this.ProductoTextBox.Size = new System.Drawing.Size(629, 20);
            this.ProductoTextBox.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Stock:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Categoría:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Precio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Proveedor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Producto:";
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::JardinesEF.Windows.Properties.Resources.Cancelar;
            this.CancelButton.Location = new System.Drawing.Point(520, 206);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 53);
            this.CancelButton.TabIndex = 37;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = global::JardinesEF.Windows.Properties.Resources.Guardar;
            this.OkButton.Location = new System.Drawing.Point(192, 206);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(94, 53);
            this.OkButton.TabIndex = 38;
            this.OkButton.Text = "OK";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Nombre Latín:";
            // 
            // NombreLatinTextBox
            // 
            this.NombreLatinTextBox.Location = new System.Drawing.Point(120, 38);
            this.NombreLatinTextBox.MaxLength = 100;
            this.NombreLatinTextBox.Name = "NombreLatinTextBox";
            this.NombreLatinTextBox.Size = new System.Drawing.Size(629, 20);
            this.NombreLatinTextBox.TabIndex = 33;
            // 
            // FrmProductosEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 292);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.SuspendidoCheckBox);
            this.Controls.Add(this.CategoriaComboBox);
            this.Controls.Add(this.ProveedorComboBox);
            this.Controls.Add(this.NivelReposicionTextBox);
            this.Controls.Add(this.StockTextBox);
            this.Controls.Add(this.PrecioTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NombreLatinTextBox);
            this.Controls.Add(this.ProductoTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(840, 331);
            this.MinimumSize = new System.Drawing.Size(840, 331);
            this.Name = "FrmProductosEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProductosEdit";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox SuspendidoCheckBox;
        private System.Windows.Forms.ComboBox CategoriaComboBox;
        private System.Windows.Forms.ComboBox ProveedorComboBox;
        private System.Windows.Forms.TextBox NivelReposicionTextBox;
        private System.Windows.Forms.TextBox StockTextBox;
        private System.Windows.Forms.TextBox PrecioTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ProductoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox NombreLatinTextBox;
        private System.Windows.Forms.Label label7;
    }
}