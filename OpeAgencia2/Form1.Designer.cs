namespace OpeAgencia2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSucursal = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClientes = new System.Windows.Forms.ToolStripButton();
            this.btnConsultaPaquetes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.paquetesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.movimientosDeCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeTransaccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.consultaDeTasaDeCambiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblSucursal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(880, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(50, 17);
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblSucursal
            // 
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(54, 17);
            this.lblSucursal.Text = "Sucursal:";
            // 
            // timerClose
            // 
            this.timerClose.Interval = 1000;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClientes,
            this.toolStripSeparator1,
            this.btnConsultaPaquetes,
            this.toolStripSeparator2,
            this.toolStripSplitButton1,
            this.toolStripSeparator3,
            this.toolStripSplitButton2,
            this.toolStripSeparator4,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(880, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClientes
            // 
            this.btnClientes.Enabled = false;
            this.btnClientes.Image = global::OpeAgencia2.Properties.Resources.Profile;
            this.btnClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(69, 22);
            this.btnClientes.Tag = "frmConsultaClientes";
            this.btnClientes.Text = "Clientes";
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnConsultaPaquetes
            // 
            this.btnConsultaPaquetes.Enabled = false;
            this.btnConsultaPaquetes.Image = global::OpeAgencia2.Properties.Resources.wherehouse;
            this.btnConsultaPaquetes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConsultaPaquetes.Name = "btnConsultaPaquetes";
            this.btnConsultaPaquetes.Size = new System.Drawing.Size(75, 22);
            this.btnConsultaPaquetes.Tag = "frmConsultaMercancia";
            this.btnConsultaPaquetes.Text = "Paquetes";
            this.btnConsultaPaquetes.Click += new System.EventHandler(this.btnConsultaPaquetes_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paquetesToolStripMenuItem,
            this.enviosToolStripMenuItem,
            this.consultaDeTasaDeCambiosToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::OpeAgencia2.Properties.Resources.facturar;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(82, 22);
            this.toolStripSplitButton1.Text = "Facturar";
            // 
            // paquetesToolStripMenuItem
            // 
            this.paquetesToolStripMenuItem.Enabled = false;
            this.paquetesToolStripMenuItem.Name = "paquetesToolStripMenuItem";
            this.paquetesToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.paquetesToolStripMenuItem.Tag = "frmFactMercancia";
            this.paquetesToolStripMenuItem.Text = "Paquetes";
            this.paquetesToolStripMenuItem.Click += new System.EventHandler(this.paquetesToolStripMenuItem_Click);
            // 
            // enviosToolStripMenuItem
            // 
            this.enviosToolStripMenuItem.Enabled = false;
            this.enviosToolStripMenuItem.Name = "enviosToolStripMenuItem";
            this.enviosToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.enviosToolStripMenuItem.Tag = "frmFactEnvios";
            this.enviosToolStripMenuItem.Text = "Envios";
            this.enviosToolStripMenuItem.Click += new System.EventHandler(this.enviosToolStripMenuItem_Click);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movimientosDeCajaToolStripMenuItem,
            this.listadoDeTransaccionesToolStripMenuItem});
            this.toolStripSplitButton2.Image = global::OpeAgencia2.Properties.Resources.btnImprime_Image;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(86, 22);
            this.toolStripSplitButton2.Text = "Informes";
            // 
            // movimientosDeCajaToolStripMenuItem
            // 
            this.movimientosDeCajaToolStripMenuItem.Enabled = false;
            this.movimientosDeCajaToolStripMenuItem.Name = "movimientosDeCajaToolStripMenuItem";
            this.movimientosDeCajaToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.movimientosDeCajaToolStripMenuItem.Tag = "frmMovCaja";
            this.movimientosDeCajaToolStripMenuItem.Text = "Movimientos de caja";
            this.movimientosDeCajaToolStripMenuItem.Click += new System.EventHandler(this.movimientosDeCajaToolStripMenuItem_Click);
            // 
            // listadoDeTransaccionesToolStripMenuItem
            // 
            this.listadoDeTransaccionesToolStripMenuItem.Enabled = false;
            this.listadoDeTransaccionesToolStripMenuItem.Name = "listadoDeTransaccionesToolStripMenuItem";
            this.listadoDeTransaccionesToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.listadoDeTransaccionesToolStripMenuItem.Tag = "ConsultaOperaciones";
            this.listadoDeTransaccionesToolStripMenuItem.Text = "Listado de transacciones";
            this.listadoDeTransaccionesToolStripMenuItem.Click += new System.EventHandler(this.listadoDeTransaccionesToolStripMenuItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::OpeAgencia2.Properties.Resources.btnSalir_Image;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton3.Text = "Salir";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // consultaDeTasaDeCambiosToolStripMenuItem
            // 
            this.consultaDeTasaDeCambiosToolStripMenuItem.Name = "consultaDeTasaDeCambiosToolStripMenuItem";
            this.consultaDeTasaDeCambiosToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.consultaDeTasaDeCambiosToolStripMenuItem.Text = "Consulta de Tasa de Cambios";
            this.consultaDeTasaDeCambiosToolStripMenuItem.Click += new System.EventHandler(this.consultaDeTasaDeCambiosToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 672);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Sistema de Operaciones";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.Timer timerClose;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblSucursal;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClientes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnConsultaPaquetes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem paquetesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem movimientosDeCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeTransaccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem consultaDeTasaDeCambiosToolStripMenuItem;

    }
}

