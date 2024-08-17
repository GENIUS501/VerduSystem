namespace Diamond
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Txt_Usuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reingresarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Procesos = new System.Windows.Forms.ToolStripMenuItem();
            this.Venta = new System.Windows.Forms.ToolStripMenuItem();
            this.Devolucion = new System.Windows.Forms.ToolStripMenuItem();
            this.Reportes = new System.Windows.Forms.ToolStripMenuItem();
            this.Reporte_Cliente = new System.Windows.Forms.ToolStripMenuItem();
            this.Reporte_Producto = new System.Windows.Forms.ToolStripMenuItem();
            this.Reporte_Venta = new System.Windows.Forms.ToolStripMenuItem();
            this.Mantenimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.Clientes = new System.Windows.Forms.ToolStripMenuItem();
            this.Productos = new System.Windows.Forms.ToolStripMenuItem();
            this.Tipo_Productos = new System.Windows.Forms.ToolStripMenuItem();
            this.Seguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.Roles = new System.Windows.Forms.ToolStripMenuItem();
            this.Bitacora_Ingresos = new System.Windows.Forms.ToolStripMenuItem();
            this.Bitacora_Movimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Salir = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Txt_Usuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(841, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Txt_Usuario
            // 
            this.Txt_Usuario.Name = "Txt_Usuario";
            this.Txt_Usuario.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.Procesos,
            this.Reportes,
            this.Mantenimientos,
            this.Seguridad,
            this.acercaDeToolStripMenuItem,
            this.ayudaToolStripMenuItem,
            this.Salir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(841, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reingresarToolStripMenuItem});
            this.inicioToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inicioToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // reingresarToolStripMenuItem
            // 
            this.reingresarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.reingresarToolStripMenuItem.Name = "reingresarToolStripMenuItem";
            this.reingresarToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.reingresarToolStripMenuItem.Text = "Reingresar";
            this.reingresarToolStripMenuItem.Click += new System.EventHandler(this.reingresarToolStripMenuItem_Click);
            // 
            // Procesos
            // 
            this.Procesos.BackColor = System.Drawing.Color.Transparent;
            this.Procesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Venta,
            this.Devolucion});
            this.Procesos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Procesos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Procesos.Name = "Procesos";
            this.Procesos.Size = new System.Drawing.Size(70, 20);
            this.Procesos.Text = "Procesos";
            // 
            // Venta
            // 
            this.Venta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Venta.Name = "Venta";
            this.Venta.Size = new System.Drawing.Size(198, 22);
            this.Venta.Text = "Proceso de venta";
            this.Venta.Click += new System.EventHandler(this.Venta_Click);
            // 
            // Devolucion
            // 
            this.Devolucion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Devolucion.Name = "Devolucion";
            this.Devolucion.Size = new System.Drawing.Size(198, 22);
            this.Devolucion.Text = "Proceso de devolucion";
            this.Devolucion.Click += new System.EventHandler(this.Devolucion_Click);
            // 
            // Reportes
            // 
            this.Reportes.BackColor = System.Drawing.Color.Transparent;
            this.Reportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Reportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Reporte_Cliente,
            this.Reporte_Producto,
            this.Reporte_Venta});
            this.Reportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reportes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Reportes.Name = "Reportes";
            this.Reportes.Size = new System.Drawing.Size(69, 20);
            this.Reportes.Text = "Reportes";
            // 
            // Reporte_Cliente
            // 
            this.Reporte_Cliente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Reporte_Cliente.Name = "Reporte_Cliente";
            this.Reporte_Cliente.Size = new System.Drawing.Size(210, 22);
            this.Reporte_Cliente.Text = "Reporte de clientes";
            this.Reporte_Cliente.Click += new System.EventHandler(this.Reporte_Cliente_Click);
            // 
            // Reporte_Producto
            // 
            this.Reporte_Producto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Reporte_Producto.Name = "Reporte_Producto";
            this.Reporte_Producto.Size = new System.Drawing.Size(210, 22);
            this.Reporte_Producto.Text = "Reporte de devoluciones";
            this.Reporte_Producto.Click += new System.EventHandler(this.Reporte_Producto_Click);
            // 
            // Reporte_Venta
            // 
            this.Reporte_Venta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Reporte_Venta.Name = "Reporte_Venta";
            this.Reporte_Venta.Size = new System.Drawing.Size(210, 22);
            this.Reporte_Venta.Text = "Reporte de ventas";
            this.Reporte_Venta.Click += new System.EventHandler(this.Reporte_Venta_Click);
            // 
            // Mantenimientos
            // 
            this.Mantenimientos.BackColor = System.Drawing.Color.Transparent;
            this.Mantenimientos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Clientes,
            this.Productos,
            this.Tipo_Productos});
            this.Mantenimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mantenimientos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Mantenimientos.Name = "Mantenimientos";
            this.Mantenimientos.Size = new System.Drawing.Size(108, 20);
            this.Mantenimientos.Text = "Mantenimientos";
            // 
            // Clientes
            // 
            this.Clientes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Clientes.Name = "Clientes";
            this.Clientes.Size = new System.Drawing.Size(179, 22);
            this.Clientes.Text = "Clientes";
            this.Clientes.Click += new System.EventHandler(this.Clientes_Click);
            // 
            // Productos
            // 
            this.Productos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Productos.Name = "Productos";
            this.Productos.Size = new System.Drawing.Size(179, 22);
            this.Productos.Text = "Productos";
            this.Productos.Click += new System.EventHandler(this.Productos_Click);
            // 
            // Tipo_Productos
            // 
            this.Tipo_Productos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Tipo_Productos.Name = "Tipo_Productos";
            this.Tipo_Productos.Size = new System.Drawing.Size(179, 22);
            this.Tipo_Productos.Text = "Tipos de Productos";
            this.Tipo_Productos.Click += new System.EventHandler(this.Tipo_Productos_Click);
            // 
            // Seguridad
            // 
            this.Seguridad.BackColor = System.Drawing.Color.Transparent;
            this.Seguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Usuarios,
            this.Roles,
            this.Bitacora_Ingresos,
            this.Bitacora_Movimientos});
            this.Seguridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Seguridad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Seguridad.Name = "Seguridad";
            this.Seguridad.Size = new System.Drawing.Size(76, 20);
            this.Seguridad.Text = "Seguridad";
            // 
            // Usuarios
            // 
            this.Usuarios.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Usuarios.Name = "Usuarios";
            this.Usuarios.Size = new System.Drawing.Size(236, 22);
            this.Usuarios.Text = "Usuarios";
            this.Usuarios.Click += new System.EventHandler(this.Usuarios_Click);
            // 
            // Roles
            // 
            this.Roles.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Roles.Name = "Roles";
            this.Roles.Size = new System.Drawing.Size(236, 22);
            this.Roles.Text = "Roles";
            this.Roles.Click += new System.EventHandler(this.Roles_Click);
            // 
            // Bitacora_Ingresos
            // 
            this.Bitacora_Ingresos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Bitacora_Ingresos.Name = "Bitacora_Ingresos";
            this.Bitacora_Ingresos.Size = new System.Drawing.Size(236, 22);
            this.Bitacora_Ingresos.Text = "Bitacora de ingresos y salidas";
            this.Bitacora_Ingresos.Click += new System.EventHandler(this.Bitacora_Ingresos_Click);
            // 
            // Bitacora_Movimientos
            // 
            this.Bitacora_Movimientos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Bitacora_Movimientos.Name = "Bitacora_Movimientos";
            this.Bitacora_Movimientos.Size = new System.Drawing.Size(236, 22);
            this.Bitacora_Movimientos.Text = "Bitacora de movimientos";
            this.Bitacora_Movimientos.Click += new System.EventHandler(this.Bitacora_Movimientos_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.acercaDeToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acercaDeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ayudaToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ayudaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // Salir
            // 
            this.Salir.BackColor = System.Drawing.Color.Transparent;
            this.Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(44, 20);
            this.Salir.Text = "Salir";
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Verdu.Properties.Resources.PAZVERDUSYSTEM__1_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(841, 440);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Txt_Usuario;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reingresarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Procesos;
        private System.Windows.Forms.ToolStripMenuItem Venta;
        private System.Windows.Forms.ToolStripMenuItem Devolucion;
        private System.Windows.Forms.ToolStripMenuItem Reportes;
        private System.Windows.Forms.ToolStripMenuItem Reporte_Venta;
        private System.Windows.Forms.ToolStripMenuItem Reporte_Cliente;
        private System.Windows.Forms.ToolStripMenuItem Reporte_Producto;
        private System.Windows.Forms.ToolStripMenuItem Mantenimientos;
        private System.Windows.Forms.ToolStripMenuItem Clientes;
        private System.Windows.Forms.ToolStripMenuItem Productos;
        private System.Windows.Forms.ToolStripMenuItem Tipo_Productos;
        private System.Windows.Forms.ToolStripMenuItem Seguridad;
        private System.Windows.Forms.ToolStripMenuItem Usuarios;
        private System.Windows.Forms.ToolStripMenuItem Roles;
        private System.Windows.Forms.ToolStripMenuItem Bitacora_Ingresos;
        private System.Windows.Forms.ToolStripMenuItem Bitacora_Movimientos;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Salir;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
    }
}