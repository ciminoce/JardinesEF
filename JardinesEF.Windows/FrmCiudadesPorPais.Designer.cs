
namespace JardinesEF.Windows
{
    partial class FrmCiudadesPorPais
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
            this.GruposDataGridView = new System.Windows.Forms.DataGridView();
            this.colPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GruposDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GruposDataGridView
            // 
            this.GruposDataGridView.AllowUserToAddRows = false;
            this.GruposDataGridView.AllowUserToDeleteRows = false;
            this.GruposDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GruposDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPais,
            this.colCantidad});
            this.GruposDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GruposDataGridView.Location = new System.Drawing.Point(0, 0);
            this.GruposDataGridView.Name = "GruposDataGridView";
            this.GruposDataGridView.ReadOnly = true;
            this.GruposDataGridView.Size = new System.Drawing.Size(800, 450);
            this.GruposDataGridView.TabIndex = 0;
            // 
            // colPais
            // 
            this.colPais.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPais.HeaderText = "País";
            this.colPais.Name = "colPais";
            this.colPais.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cant. Ciudades";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // FrmCiudadesPorPais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GruposDataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCiudadesPorPais";
            this.Text = "FrmCiudadesPorPais";
            this.Load += new System.EventHandler(this.FrmCiudadesPorPais_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GruposDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GruposDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
    }
}