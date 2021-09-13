
namespace JardinesEF.Windows
{
    partial class FrmOrdenesEdit
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label address1Label;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClientesComboBox = new System.Windows.Forms.ComboBox();
            this.CiudadTextBox = new System.Windows.Forms.TextBox();
            this.DireccionTextBox = new System.Windows.Forms.TextBox();
            this.PaisTextBox = new System.Windows.Forms.TextBox();
            this.CodigoPostalTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FechaPedidoDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ProductoComboBox = new System.Windows.Forms.ComboBox();
            this.CategoriaComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CantidadUpDown = new System.Windows.Forms.NumericUpDown();
            this.PrecioUnitTextBox = new System.Windows.Forms.TextBox();
            this.CancelarProductoButton = new System.Windows.Forms.Button();
            this.AceptarProductoButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PrecioTotalTextoBox = new System.Windows.Forms.TextBox();
            this.EnPedidoTextBox = new System.Windows.Forms.TextBox();
            this.StockTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.TotalPedidoTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PedidoDataGridView = new System.Windows.Forms.DataGridView();
            this.cmnProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBorrar = new System.Windows.Forms.DataGridViewImageColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PedidoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(18, 102);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(61, 13);
            cityLabel.TabIndex = 23;
            cityLabel.Text = "País , C.P.:";
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CancelButton);
            this.splitContainer1.Panel2.Controls.Add(this.OkButton);
            this.splitContainer1.Panel2.Controls.Add(this.TotalPedidoTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.PedidoDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(853, 661);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ClientesComboBox);
            this.groupBox1.Controls.Add(nameLabel);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(address1Label);
            this.groupBox1.Controls.Add(this.CiudadTextBox);
            this.groupBox1.Controls.Add(this.DireccionTextBox);
            this.groupBox1.Controls.Add(cityLabel);
            this.groupBox1.Controls.Add(this.PaisTextBox);
            this.groupBox1.Controls.Add(this.CodigoPostalTextBox);
            this.groupBox1.Location = new System.Drawing.Point(18, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 133);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // ClientesComboBox
            // 
            this.ClientesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientesComboBox.FormattingEnabled = true;
            this.ClientesComboBox.Location = new System.Drawing.Point(84, 14);
            this.ClientesComboBox.Name = "ClientesComboBox";
            this.ClientesComboBox.Size = new System.Drawing.Size(375, 21);
            this.ClientesComboBox.TabIndex = 0;
            this.ClientesComboBox.SelectedIndexChanged += new System.EventHandler(this.ClientesComboBox_SelectedIndexChanged);
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
            // PaisTextBox
            // 
            this.PaisTextBox.Location = new System.Drawing.Point(83, 99);
            this.PaisTextBox.Name = "PaisTextBox";
            this.PaisTextBox.ReadOnly = true;
            this.PaisTextBox.Size = new System.Drawing.Size(173, 20);
            this.PaisTextBox.TabIndex = 24;
            this.PaisTextBox.TabStop = false;
            // 
            // CodigoPostalTextBox
            // 
            this.CodigoPostalTextBox.Location = new System.Drawing.Point(275, 99);
            this.CodigoPostalTextBox.Name = "CodigoPostalTextBox";
            this.CodigoPostalTextBox.ReadOnly = true;
            this.CodigoPostalTextBox.Size = new System.Drawing.Size(100, 20);
            this.CodigoPostalTextBox.TabIndex = 26;
            this.CodigoPostalTextBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FechaPedidoDatePicker);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(629, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 58);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Fecha  ";
            // 
            // FechaPedidoDatePicker
            // 
            this.FechaPedidoDatePicker.Checked = false;
            this.FechaPedidoDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaPedidoDatePicker.Location = new System.Drawing.Point(72, 17);
            this.FechaPedidoDatePicker.Name = "FechaPedidoDatePicker";
            this.FechaPedidoDatePicker.Size = new System.Drawing.Size(122, 20);
            this.FechaPedidoDatePicker.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Venta:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ProductoComboBox);
            this.groupBox3.Controls.Add(this.CategoriaComboBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.CantidadUpDown);
            this.groupBox3.Controls.Add(this.PrecioUnitTextBox);
            this.groupBox3.Controls.Add(this.CancelarProductoButton);
            this.groupBox3.Controls.Add(this.AceptarProductoButton);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.PrecioTotalTextoBox);
            this.groupBox3.Controls.Add(this.EnPedidoTextBox);
            this.groupBox3.Controls.Add(this.StockTextBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(825, 121);
            this.groupBox3.TabIndex = 65;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Producto ";
            // 
            // ProductoComboBox
            // 
            this.ProductoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProductoComboBox.FormattingEnabled = true;
            this.ProductoComboBox.Location = new System.Drawing.Point(72, 50);
            this.ProductoComboBox.Name = "ProductoComboBox";
            this.ProductoComboBox.Size = new System.Drawing.Size(309, 21);
            this.ProductoComboBox.TabIndex = 1;
            this.ProductoComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductoComboBox_SelectedIndexChanged);
            // 
            // CategoriaComboBox
            // 
            this.CategoriaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriaComboBox.FormattingEnabled = true;
            this.CategoriaComboBox.Location = new System.Drawing.Point(72, 20);
            this.CategoriaComboBox.Name = "CategoriaComboBox";
            this.CategoriaComboBox.Size = new System.Drawing.Size(258, 21);
            this.CategoriaComboBox.TabIndex = 0;
            this.CategoriaComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoriaComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Producto:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Categoría:";
            // 
            // CantidadUpDown
            // 
            this.CantidadUpDown.Enabled = false;
            this.CantidadUpDown.Location = new System.Drawing.Point(478, 21);
            this.CantidadUpDown.Name = "CantidadUpDown";
            this.CantidadUpDown.Size = new System.Drawing.Size(120, 20);
            this.CantidadUpDown.TabIndex = 2;
            this.CantidadUpDown.ValueChanged += new System.EventHandler(this.CantidadUpDown_ValueChanged);
            // 
            // PrecioUnitTextBox
            // 
            this.PrecioUnitTextBox.Location = new System.Drawing.Point(72, 83);
            this.PrecioUnitTextBox.Name = "PrecioUnitTextBox";
            this.PrecioUnitTextBox.ReadOnly = true;
            this.PrecioUnitTextBox.Size = new System.Drawing.Size(67, 20);
            this.PrecioUnitTextBox.TabIndex = 2;
            // 
            // CancelarProductoButton
            // 
            this.CancelarProductoButton.Location = new System.Drawing.Point(678, 68);
            this.CancelarProductoButton.Name = "CancelarProductoButton";
            this.CancelarProductoButton.Size = new System.Drawing.Size(132, 43);
            this.CancelarProductoButton.TabIndex = 4;
            this.CancelarProductoButton.Text = "Cancelar";
            this.CancelarProductoButton.UseVisualStyleBackColor = true;
            this.CancelarProductoButton.Click += new System.EventHandler(this.CancelarProductoButton_Click);
            // 
            // AceptarProductoButton
            // 
            this.AceptarProductoButton.Location = new System.Drawing.Point(679, 19);
            this.AceptarProductoButton.Name = "AceptarProductoButton";
            this.AceptarProductoButton.Size = new System.Drawing.Size(131, 43);
            this.AceptarProductoButton.TabIndex = 3;
            this.AceptarProductoButton.Text = "Aceptar";
            this.AceptarProductoButton.UseVisualStyleBackColor = true;
            this.AceptarProductoButton.Click += new System.EventHandler(this.AceptarProductoButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(423, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Cantidad:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(408, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Precio Total:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Precio Unit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Stock:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(265, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "En Pedido:";
            // 
            // PrecioTotalTextoBox
            // 
            this.PrecioTotalTextoBox.Location = new System.Drawing.Point(481, 50);
            this.PrecioTotalTextoBox.Name = "PrecioTotalTextoBox";
            this.PrecioTotalTextoBox.ReadOnly = true;
            this.PrecioTotalTextoBox.Size = new System.Drawing.Size(92, 20);
            this.PrecioTotalTextoBox.TabIndex = 4;
            this.PrecioTotalTextoBox.TabStop = false;
            this.PrecioTotalTextoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EnPedidoTextBox
            // 
            this.EnPedidoTextBox.Location = new System.Drawing.Point(330, 84);
            this.EnPedidoTextBox.Name = "EnPedidoTextBox";
            this.EnPedidoTextBox.ReadOnly = true;
            this.EnPedidoTextBox.Size = new System.Drawing.Size(51, 20);
            this.EnPedidoTextBox.TabIndex = 24;
            this.EnPedidoTextBox.TabStop = false;
            this.EnPedidoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // StockTextBox
            // 
            this.StockTextBox.Location = new System.Drawing.Point(199, 83);
            this.StockTextBox.Name = "StockTextBox";
            this.StockTextBox.ReadOnly = true;
            this.StockTextBox.Size = new System.Drawing.Size(51, 20);
            this.StockTextBox.TabIndex = 24;
            this.StockTextBox.TabStop = false;
            this.StockTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::JardinesEF.Windows.Properties.Resources.Cancelar;
            this.CancelButton.Location = new System.Drawing.Point(547, 267);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 53);
            this.CancelButton.TabIndex = 66;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = global::JardinesEF.Windows.Properties.Resources.Guardar;
            this.OkButton.Location = new System.Drawing.Point(219, 267);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(94, 53);
            this.OkButton.TabIndex = 67;
            this.OkButton.Text = "OK";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // TotalPedidoTextBox
            // 
            this.TotalPedidoTextBox.Location = new System.Drawing.Point(690, 234);
            this.TotalPedidoTextBox.Name = "TotalPedidoTextBox";
            this.TotalPedidoTextBox.ReadOnly = true;
            this.TotalPedidoTextBox.Size = new System.Drawing.Size(104, 20);
            this.TotalPedidoTextBox.TabIndex = 65;
            this.TotalPedidoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(626, 237);
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
            this.cmnTotal,
            this.btnBorrar});
            this.PedidoDataGridView.Location = new System.Drawing.Point(18, 19);
            this.PedidoDataGridView.MultiSelect = false;
            this.PedidoDataGridView.Name = "PedidoDataGridView";
            this.PedidoDataGridView.ReadOnly = true;
            this.PedidoDataGridView.RowHeadersVisible = false;
            this.PedidoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PedidoDataGridView.Size = new System.Drawing.Size(813, 209);
            this.PedidoDataGridView.TabIndex = 63;
            this.PedidoDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PedidoDataGridView_CellContentClick);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnPrecioUnitario.DefaultCellStyle = dataGridViewCellStyle4;
            this.cmnPrecioUnitario.HeaderText = "Precio Unitario";
            this.cmnPrecioUnitario.Name = "cmnPrecioUnitario";
            this.cmnPrecioUnitario.ReadOnly = true;
            // 
            // cmnCantidad
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnCantidad.DefaultCellStyle = dataGridViewCellStyle5;
            this.cmnCantidad.HeaderText = "Cantidad";
            this.cmnCantidad.Name = "cmnCantidad";
            this.cmnCantidad.ReadOnly = true;
            // 
            // cmnTotal
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.cmnTotal.HeaderText = "Total";
            this.cmnTotal.Name = "cmnTotal";
            this.cmnTotal.ReadOnly = true;
            // 
            // btnBorrar
            // 
            this.btnBorrar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.btnBorrar.HeaderText = "Borrar";
            this.btnBorrar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.ReadOnly = true;
            this.btnBorrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnBorrar.Width = 41;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmOrdenesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 661);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmOrdenesEdit";
            this.Text = "FrmOrdenesEdit";
            this.Load += new System.EventHandler(this.FrmOrdenesEdit_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PedidoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ClientesComboBox;
        private System.Windows.Forms.TextBox CiudadTextBox;
        private System.Windows.Forms.TextBox DireccionTextBox;
        private System.Windows.Forms.TextBox PaisTextBox;
        private System.Windows.Forms.TextBox CodigoPostalTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker FechaPedidoDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ProductoComboBox;
        private System.Windows.Forms.ComboBox CategoriaComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown CantidadUpDown;
        private System.Windows.Forms.TextBox PrecioUnitTextBox;
        private System.Windows.Forms.Button CancelarProductoButton;
        private System.Windows.Forms.Button AceptarProductoButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PrecioTotalTextoBox;
        private System.Windows.Forms.TextBox StockTextBox;
        private System.Windows.Forms.TextBox TotalPedidoTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView PedidoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTotal;
        private System.Windows.Forms.DataGridViewImageColumn btnBorrar;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EnPedidoTextBox;
    }
}