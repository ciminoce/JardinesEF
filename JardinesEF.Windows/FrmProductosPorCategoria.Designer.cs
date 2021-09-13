
namespace JardinesEF.Windows
{
    partial class FrmProductosPorCategoria
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
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.colCategoria,
            this.colCantidad});
            this.GruposDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GruposDataGridView.Location = new System.Drawing.Point(0, 0);
            this.GruposDataGridView.Name = "GruposDataGridView";
            this.GruposDataGridView.ReadOnly = true;
            this.GruposDataGridView.Size = new System.Drawing.Size(800, 450);
            this.GruposDataGridView.TabIndex = 1;
            // 
            // colCategoria
            // 
            this.colCategoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cant. Productos";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // FrmProductosPorCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GruposDataGridView);
            this.Name = "FrmProductosPorCategoria";
            this.Text = "FrmProductosPorCategoria";
            this.Load += new System.EventHandler(this.FrmProductosPorCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GruposDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GruposDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
    }
}