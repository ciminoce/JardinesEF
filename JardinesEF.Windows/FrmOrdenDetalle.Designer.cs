
namespace JardinesEF.Windows
{
    partial class FrmOrdenDetalle
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label address1Label;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CiudadTextBox = new System.Windows.Forms.TextBox();
            this.DireccionTextBox = new System.Windows.Forms.TextBox();
            this.PaisTextBox = new System.Windows.Forms.TextBox();
            this.CodigoPostalTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CerrarButton = new System.Windows.Forms.Button();
            this.TotalPedidoTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PedidoDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NroVentaLabel = new System.Windows.Forms.Label();
            this.cmnProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVentaTextBox = new System.Windows.Forms.TextBox();
            this.ClienteTextBox = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            address1Label = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PedidoDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CerrarButton);
            this.splitContainer1.Panel2.Controls.Add(this.TotalPedidoTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.PedidoDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(857, 635);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(nameLabel);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(address1Label);
            this.groupBox1.Controls.Add(this.CiudadTextBox);
            this.groupBox1.Controls.Add(this.ClienteTextBox);
            this.groupBox1.Controls.Add(this.DireccionTextBox);
            this.groupBox1.Controls.Add(cityLabel);
            this.groupBox1.Controls.Add(this.PaisTextBox);
            this.groupBox1.Controls.Add(this.CodigoPostalTextBox);
            this.groupBox1.Location = new System.Drawing.Point(18, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 115);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(18, 23);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(42, 13);
            nameLabel.TabIndex = 18;
            nameLabel.Text = "Cliente:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 76);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 13);
            label1.TabIndex = 20;
            label1.Text = "Ciudad:";
            // 
            // address1Label
            // 
            address1Label.AutoSize = true;
            address1Label.Location = new System.Drawing.Point(20, 50);
            address1Label.Name = "address1Label";
            address1Label.Size = new System.Drawing.Size(55, 13);
            address1Label.TabIndex = 20;
            address1Label.Text = "Dirección:";
            // 
            // CiudadTextBox
            // 
            this.CiudadTextBox.Location = new System.Drawing.Point(83, 73);
            this.CiudadTextBox.Name = "CiudadTextBox";
            this.CiudadTextBox.ReadOnly = true;
            this.CiudadTextBox.Size = new System.Drawing.Size(375, 20);
            this.CiudadTextBox.TabIndex = 21;
            this.CiudadTextBox.TabStop = false;
            // 
            // DireccionTextBox
            // 
            this.DireccionTextBox.Location = new System.Drawing.Point(84, 47);
            this.DireccionTextBox.Name = "DireccionTextBox";
            this.DireccionTextBox.ReadOnly = true;
            this.DireccionTextBox.Size = new System.Drawing.Size(483, 20);
            this.DireccionTextBox.TabIndex = 21;
            this.DireccionTextBox.TabStop = false;
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(464, 79);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(61, 13);
            cityLabel.TabIndex = 23;
            cityLabel.Text = "País , C.P.:";
            // 
            // PaisTextBox
            // 
            this.PaisTextBox.Location = new System.Drawing.Point(529, 76);
            this.PaisTextBox.Name = "PaisTextBox";
            this.PaisTextBox.ReadOnly = true;
            this.PaisTextBox.Size = new System.Drawing.Size(173, 20);
            this.PaisTextBox.TabIndex = 24;
            this.PaisTextBox.TabStop = false;
            // 
            // CodigoPostalTextBox
            // 
            this.CodigoPostalTextBox.Location = new System.Drawing.Point(721, 76);
            this.CodigoPostalTextBox.Name = "CodigoPostalTextBox";
            this.CodigoPostalTextBox.ReadOnly = true;
            this.CodigoPostalTextBox.Size = new System.Drawing.Size(100, 20);
            this.CodigoPostalTextBox.TabIndex = 26;
            this.CodigoPostalTextBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FechaVentaTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(229, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 53);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fecha Venta:";
            // 
            // CerrarButton
            // 
            this.CerrarButton.Image = global::JardinesEF.Windows.Properties.Resources.Cancelar;
            this.CerrarButton.Location = new System.Drawing.Point(739, 351);
            this.CerrarButton.Name = "CerrarButton";
            this.CerrarButton.Size = new System.Drawing.Size(94, 53);
            this.CerrarButton.TabIndex = 66;
            this.CerrarButton.Text = "Cerrar";
            this.CerrarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CerrarButton.UseVisualStyleBackColor = true;
            this.CerrarButton.Click += new System.EventHandler(this.CerrarButton_Click);
            // 
            // TotalPedidoTextBox
            // 
            this.TotalPedidoTextBox.Location = new System.Drawing.Point(729, 309);
            this.TotalPedidoTextBox.Name = "TotalPedidoTextBox";
            this.TotalPedidoTextBox.ReadOnly = true;
            this.TotalPedidoTextBox.Size = new System.Drawing.Size(104, 20);
            this.TotalPedidoTextBox.TabIndex = 65;
            this.TotalPedidoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(667, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "Total:";
            // 
            // PedidoDataGridView
            // 
            this.PedidoDataGridView.AllowUserToAddRows = false;
            this.PedidoDataGridView.AllowUserToDeleteRows = false;
            this.PedidoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PedidoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnProducto,
            this.cmnPrecioUnitario,
            this.cmnCantidad,
            this.cmnTotal});
            this.PedidoDataGridView.Location = new System.Drawing.Point(18, 19);
            this.PedidoDataGridView.MultiSelect = false;
            this.PedidoDataGridView.Name = "PedidoDataGridView";
            this.PedidoDataGridView.ReadOnly = true;
            this.PedidoDataGridView.RowHeadersVisible = false;
            this.PedidoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PedidoDataGridView.Size = new System.Drawing.Size(813, 274);
            this.PedidoDataGridView.TabIndex = 63;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.NroVentaLabel);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(23, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 53);
            this.groupBox3.TabIndex = 67;
            this.groupBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nro.Venta:";
            // 
            // NroVentaLabel
            // 
            this.NroVentaLabel.AutoSize = true;
            this.NroVentaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NroVentaLabel.Location = new System.Drawing.Point(81, 21);
            this.NroVentaLabel.Name = "NroVentaLabel";
            this.NroVentaLabel.Size = new System.Drawing.Size(0, 13);
            this.NroVentaLabel.TabIndex = 0;
            // 
            // cmnProducto
            // 
            this.cmnProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnProducto.HeaderText = "Producto";
            this.cmnProducto.Name = "cmnProducto";
            this.cmnProducto.ReadOnly = true;
            // 
            // cmnPrecioUnitario
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnPrecioUnitario.DefaultCellStyle = dataGridViewCellStyle7;
            this.cmnPrecioUnitario.HeaderText = "Precio Unitario";
            this.cmnPrecioUnitario.Name = "cmnPrecioUnitario";
            this.cmnPrecioUnitario.ReadOnly = true;
            // 
            // cmnCantidad
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnCantidad.DefaultCellStyle = dataGridViewCellStyle8;
            this.cmnCantidad.HeaderText = "Cantidad";
            this.cmnCantidad.Name = "cmnCantidad";
            this.cmnCantidad.ReadOnly = true;
            // 
            // cmnTotal
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnTotal.DefaultCellStyle = dataGridViewCellStyle9;
            this.cmnTotal.HeaderText = "Total";
            this.cmnTotal.Name = "cmnTotal";
            this.cmnTotal.ReadOnly = true;
            // 
            // FechaVentaTextBox
            // 
            this.FechaVentaTextBox.Enabled = false;
            this.FechaVentaTextBox.Location = new System.Drawing.Point(84, 17);
            this.FechaVentaTextBox.Name = "FechaVentaTextBox";
            this.FechaVentaTextBox.ReadOnly = true;
            this.FechaVentaTextBox.Size = new System.Drawing.Size(100, 20);
            this.FechaVentaTextBox.TabIndex = 1;
            // 
            // ClienteTextBox
            // 
            this.ClienteTextBox.Location = new System.Drawing.Point(83, 19);
            this.ClienteTextBox.Name = "ClienteTextBox";
            this.ClienteTextBox.ReadOnly = true;
            this.ClienteTextBox.Size = new System.Drawing.Size(483, 20);
            this.ClienteTextBox.TabIndex = 21;
            this.ClienteTextBox.TabStop = false;
            // 
            // FrmOrdenDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 635);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmOrdenDetalle";
            this.Text = "FrmDetallesVenta";
            this.Load += new System.EventHandler(this.FrmOrdenDetalle_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PedidoDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CiudadTextBox;
        private System.Windows.Forms.TextBox DireccionTextBox;
        private System.Windows.Forms.TextBox PaisTextBox;
        private System.Windows.Forms.TextBox CodigoPostalTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label NroVentaLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox FechaVentaTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CerrarButton;
        private System.Windows.Forms.TextBox TotalPedidoTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView PedidoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTotal;
        private System.Windows.Forms.TextBox ClienteTextBox;
    }
}