namespace Diamond
{
    partial class ProcesoVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcesoVentas));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.grp_venta = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbo_tipo_pago = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_cedula = new System.Windows.Forms.MaskedTextBox();
            this.btn_add_cliente = new System.Windows.Forms.Button();
            this.lbl_cliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_buscar_nombre = new System.Windows.Forms.Button();
            this.btn_buscar_codigo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lst_productos = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dat_resultado = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_nombre_producto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_impuesto = new System.Windows.Forms.TextBox();
            this.grp_venta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dat_resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_venta
            // 
            this.grp_venta.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grp_venta.Controls.Add(this.btnCancelar);
            this.grp_venta.Controls.Add(this.pictureBox1);
            this.grp_venta.Controls.Add(this.btnAceptar);
            this.grp_venta.Controls.Add(this.label10);
            this.grp_venta.Controls.Add(this.cbo_tipo_pago);
            this.grp_venta.Controls.Add(this.label9);
            this.grp_venta.Controls.Add(this.txt_codigo);
            this.grp_venta.Controls.Add(this.label8);
            this.grp_venta.Controls.Add(this.txt_cedula);
            this.grp_venta.Controls.Add(this.btn_add_cliente);
            this.grp_venta.Controls.Add(this.lbl_cliente);
            this.grp_venta.Controls.Add(this.label2);
            this.grp_venta.Controls.Add(this.btn_buscar_nombre);
            this.grp_venta.Controls.Add(this.btn_buscar_codigo);
            this.grp_venta.Controls.Add(this.label5);
            this.grp_venta.Controls.Add(this.label1);
            this.grp_venta.Controls.Add(this.lst_productos);
            this.grp_venta.Controls.Add(this.dat_resultado);
            this.grp_venta.Controls.Add(this.label6);
            this.grp_venta.Controls.Add(this.txt_nombre_producto);
            this.grp_venta.Controls.Add(this.label7);
            this.grp_venta.Controls.Add(this.label4);
            this.grp_venta.Controls.Add(this.txt_total);
            this.grp_venta.Controls.Add(this.label3);
            this.grp_venta.Controls.Add(this.txt_impuesto);
            this.grp_venta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_venta.Location = new System.Drawing.Point(12, 12);
            this.grp_venta.Name = "grp_venta";
            this.grp_venta.Size = new System.Drawing.Size(659, 461);
            this.grp_venta.TabIndex = 48;
            this.grp_venta.TabStop = false;
            this.grp_venta.Text = "Venta";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Beige;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(572, 417);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 23);
            this.btnCancelar.TabIndex = 47;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Image = global::Verdu.Properties.Resources.PAZVERDUSYSTEM__1_1;
            this.pictureBox1.Location = new System.Drawing.Point(549, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Beige;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(478, 417);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(79, 23);
            this.btnAceptar.TabIndex = 46;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(269, 421);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 16);
            this.label10.TabIndex = 65;
            this.label10.Text = "₡";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // cbo_tipo_pago
            // 
            this.cbo_tipo_pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_tipo_pago.FormattingEnabled = true;
            this.cbo_tipo_pago.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta",
            "Sinpe"});
            this.cbo_tipo_pago.Location = new System.Drawing.Point(111, 421);
            this.cbo_tipo_pago.Name = "cbo_tipo_pago";
            this.cbo_tipo_pago.Size = new System.Drawing.Size(121, 24);
            this.cbo_tipo_pago.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(108, 395);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 16);
            this.label9.TabIndex = 64;
            this.label9.Text = "Tipo de pago";
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(9, 37);
            this.txt_codigo.Mask = "000000000";
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(124, 22);
            this.txt_codigo.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(74, 395);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 16);
            this.label8.TabIndex = 62;
            this.label8.Text = "%";
            // 
            // txt_cedula
            // 
            this.txt_cedula.Location = new System.Drawing.Point(385, 35);
            this.txt_cedula.Mask = "000000000000";
            this.txt_cedula.Name = "txt_cedula";
            this.txt_cedula.Size = new System.Drawing.Size(124, 22);
            this.txt_cedula.TabIndex = 4;
            // 
            // btn_add_cliente
            // 
            this.btn_add_cliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_add_cliente.BackgroundImage")));
            this.btn_add_cliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add_cliente.Location = new System.Drawing.Point(515, 37);
            this.btn_add_cliente.Name = "btn_add_cliente";
            this.btn_add_cliente.Size = new System.Drawing.Size(28, 21);
            this.btn_add_cliente.TabIndex = 5;
            this.btn_add_cliente.UseVisualStyleBackColor = true;
            this.btn_add_cliente.Click += new System.EventHandler(this.btn_add_cliente_Click);
            // 
            // lbl_cliente
            // 
            this.lbl_cliente.AutoSize = true;
            this.lbl_cliente.Location = new System.Drawing.Point(306, 72);
            this.lbl_cliente.Name = "lbl_cliente";
            this.lbl_cliente.Size = new System.Drawing.Size(0, 16);
            this.lbl_cliente.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(382, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "Cedula del cliente";
            // 
            // btn_buscar_nombre
            // 
            this.btn_buscar_nombre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_buscar_nombre.BackgroundImage")));
            this.btn_buscar_nombre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_buscar_nombre.Location = new System.Drawing.Point(306, 37);
            this.btn_buscar_nombre.Name = "btn_buscar_nombre";
            this.btn_buscar_nombre.Size = new System.Drawing.Size(25, 20);
            this.btn_buscar_nombre.TabIndex = 3;
            this.btn_buscar_nombre.UseVisualStyleBackColor = true;
            this.btn_buscar_nombre.Click += new System.EventHandler(this.btn_buscar_nombre_Click);
            // 
            // btn_buscar_codigo
            // 
            this.btn_buscar_codigo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_buscar_codigo.BackgroundImage")));
            this.btn_buscar_codigo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_buscar_codigo.Location = new System.Drawing.Point(139, 37);
            this.btn_buscar_codigo.Name = "btn_buscar_codigo";
            this.btn_buscar_codigo.Size = new System.Drawing.Size(25, 20);
            this.btn_buscar_codigo.TabIndex = 1;
            this.btn_buscar_codigo.UseVisualStyleBackColor = true;
            this.btn_buscar_codigo.Click += new System.EventHandler(this.btn_buscar_codigo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(3, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 54;
            this.label5.Text = "Lista de productos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "Resultado Búsqueda";
            // 
            // lst_productos
            // 
            this.lst_productos.CheckBoxes = true;
            this.lst_productos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader8});
            this.lst_productos.FullRowSelect = true;
            this.lst_productos.GridLines = true;
            this.lst_productos.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.lst_productos.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lst_productos.Location = new System.Drawing.Point(6, 250);
            this.lst_productos.Name = "lst_productos";
            this.lst_productos.Size = new System.Drawing.Size(581, 136);
            this.lst_productos.TabIndex = 7;
            this.lst_productos.UseCompatibleStateImageBehavior = false;
            this.lst_productos.View = System.Windows.Forms.View.Details;
            this.lst_productos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lst_productos_ItemCheck);
            this.lst_productos.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lst_productos_ItemChecked);
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 3;
            this.columnHeader9.Text = "Eliminar";
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "Id del producto";
            this.columnHeader1.Width = 76;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 1;
            this.columnHeader6.Text = "Nombre";
            this.columnHeader6.Width = 187;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 2;
            this.columnHeader8.Text = "Precio";
            this.columnHeader8.Width = 220;
            // 
            // dat_resultado
            // 
            this.dat_resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dat_resultado.Location = new System.Drawing.Point(9, 104);
            this.dat_resultado.Name = "dat_resultado";
            this.dat_resultado.RowHeadersWidth = 51;
            this.dat_resultado.Size = new System.Drawing.Size(578, 103);
            this.dat_resultado.TabIndex = 6;
            this.dat_resultado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dat_resultado_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(176, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 16);
            this.label6.TabIndex = 51;
            this.label6.Text = "Nombre del producto";
            // 
            // txt_nombre_producto
            // 
            this.txt_nombre_producto.Location = new System.Drawing.Point(176, 35);
            this.txt_nombre_producto.Name = "txt_nombre_producto";
            this.txt_nombre_producto.Size = new System.Drawing.Size(124, 22);
            this.txt_nombre_producto.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(6, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 16);
            this.label7.TabIndex = 50;
            this.label7.Text = "ID del producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(269, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Total:";
            // 
            // txt_total
            // 
            this.txt_total.Enabled = false;
            this.txt_total.Location = new System.Drawing.Point(294, 418);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(100, 22);
            this.txt_total.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(6, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "Impuesto";
            // 
            // txt_impuesto
            // 
            this.txt_impuesto.Location = new System.Drawing.Point(9, 423);
            this.txt_impuesto.Name = "txt_impuesto";
            this.txt_impuesto.Size = new System.Drawing.Size(47, 22);
            this.txt_impuesto.TabIndex = 8;
            this.txt_impuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_impuesto_KeyPress);
            // 
            // ProcesoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(695, 514);
            this.Controls.Add(this.grp_venta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProcesoVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proceso Ventas";
            this.Load += new System.EventHandler(this.ProcesoVentas_Load);
            this.grp_venta.ResumeLayout(false);
            this.grp_venta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dat_resultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox grp_venta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbo_tipo_pago;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txt_codigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txt_cedula;
        private System.Windows.Forms.Button btn_add_cliente;
        private System.Windows.Forms.Label lbl_cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_buscar_nombre;
        private System.Windows.Forms.Button btn_buscar_codigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lst_productos;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.DataGridView dat_resultado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_nombre_producto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_impuesto;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}