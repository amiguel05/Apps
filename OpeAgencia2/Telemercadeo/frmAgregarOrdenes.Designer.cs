namespace OpeAgencia2.Telemercadeo
{
    partial class frmAgregarOrdenes
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEps = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDireccion2 = new System.Windows.Forms.TextBox();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEPS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.textORD_NUM = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtOrdenSuplidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbServicio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImporteLocal = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImpuesto = new clsUtils.NumericTextBox();
            this.txtGastosEnvios = new clsUtils.NumericTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGastosManejo = new clsUtils.NumericTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTasa = new clsUtils.NumericTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtImporte = new clsUtils.NumericTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PagesArticulos = new System.Windows.Forms.TabPage();
            this.dgArticulos = new System.Windows.Forms.DataGridView();
            this.articuloIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmArticulo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agregarElementoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarElmentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PageCargos = new System.Windows.Forms.TabPage();
            this.dgCargos = new System.Windows.Forms.DataGridView();
            this.txtSuplidor = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.PagesArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulos)).BeginInit();
            this.cmArticulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.articulosBindingSource)).BeginInit();
            this.PageCargos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCargos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEps);
            this.groupBox1.Controls.Add(this.txtCiudad);
            this.groupBox1.Controls.Add(this.txtDocumento);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtDireccion2);
            this.groupBox1.Controls.Add(this.txtNombres);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtEPS);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.textORD_NUM);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblEps
            // 
            this.lblEps.AutoSize = true;
            this.lblEps.Location = new System.Drawing.Point(176, 55);
            this.lblEps.Name = "lblEps";
            this.lblEps.Size = new System.Drawing.Size(13, 13);
            this.lblEps.TabIndex = 27;
            this.lblEps.Text = "[]";
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(70, 208);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(284, 20);
            this.txtCiudad.TabIndex = 8;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(70, 104);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtDocumento.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 208);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 13);
            this.label18.TabIndex = 25;
            this.label18.Text = "Ciudad";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Documento:";
            // 
            // txtDireccion2
            // 
            this.txtDireccion2.Location = new System.Drawing.Point(70, 182);
            this.txtDireccion2.Name = "txtDireccion2";
            this.txtDireccion2.Size = new System.Drawing.Size(284, 20);
            this.txtDireccion2.TabIndex = 7;
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(70, 78);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(284, 20);
            this.txtNombres.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 182);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Dirección 2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Nombres:";
            // 
            // txtEPS
            // 
            this.txtEPS.Location = new System.Drawing.Point(70, 52);
            this.txtEPS.Name = "txtEPS";
            this.txtEPS.Size = new System.Drawing.Size(100, 20);
            this.txtEPS.TabIndex = 2;
            this.txtEPS.Leave += new System.EventHandler(this.txtEps_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Eps:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(70, 156);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(284, 20);
            this.txtDireccion.TabIndex = 6;
            // 
            // textORD_NUM
            // 
            this.textORD_NUM.Enabled = false;
            this.textORD_NUM.Location = new System.Drawing.Point(70, 26);
            this.textORD_NUM.Name = "textORD_NUM";
            this.textORD_NUM.Size = new System.Drawing.Size(100, 20);
            this.textORD_NUM.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 156);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Dirección";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(70, 130);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(284, 20);
            this.txtTelefono.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Telefono:";
            // 
            // txtOrdenSuplidor
            // 
            this.txtOrdenSuplidor.Location = new System.Drawing.Point(96, 104);
            this.txtOrdenSuplidor.Name = "txtOrdenSuplidor";
            this.txtOrdenSuplidor.Size = new System.Drawing.Size(100, 20);
            this.txtOrdenSuplidor.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Orden Suplidor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Servicio:";
            // 
            // cmbServicio
            // 
            this.cmbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServicio.FormattingEnabled = true;
            this.cmbServicio.Location = new System.Drawing.Point(96, 47);
            this.cmbServicio.Name = "cmbServicio";
            this.cmbServicio.Size = new System.Drawing.Size(208, 21);
            this.cmbServicio.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Importe:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Importe local:";
            // 
            // txtImporteLocal
            // 
            this.txtImporteLocal.Enabled = false;
            this.txtImporteLocal.Location = new System.Drawing.Point(79, 68);
            this.txtImporteLocal.Name = "txtImporteLocal";
            this.txtImporteLocal.Size = new System.Drawing.Size(81, 20);
            this.txtImporteLocal.TabIndex = 11;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Enabled = false;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(96, 18);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(208, 21);
            this.cmbEstado.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Estado:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Tax:";
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.AllowSpace = false;
            this.txtImpuesto.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtImpuesto.IntValue = 0;
            this.txtImpuesto.Location = new System.Drawing.Point(68, 16);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Size = new System.Drawing.Size(76, 21);
            this.txtImpuesto.StringValue = "";
            this.txtImpuesto.TabIndex = 13;
            this.txtImpuesto.Leave += new System.EventHandler(this.txtImpuesto_Leave);
            // 
            // txtGastosEnvios
            // 
            this.txtGastosEnvios.AllowSpace = false;
            this.txtGastosEnvios.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGastosEnvios.IntValue = 0;
            this.txtGastosEnvios.Location = new System.Drawing.Point(68, 43);
            this.txtGastosEnvios.Name = "txtGastosEnvios";
            this.txtGastosEnvios.Size = new System.Drawing.Size(76, 21);
            this.txtGastosEnvios.StringValue = "";
            this.txtGastosEnvios.TabIndex = 14;
            this.txtGastosEnvios.Leave += new System.EventHandler(this.txtGastosEnvios_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Shipping";
            // 
            // txtGastosManejo
            // 
            this.txtGastosManejo.AllowSpace = false;
            this.txtGastosManejo.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGastosManejo.Enabled = false;
            this.txtGastosManejo.IntValue = 0;
            this.txtGastosManejo.Location = new System.Drawing.Point(79, 16);
            this.txtGastosManejo.Name = "txtGastosManejo";
            this.txtGastosManejo.Size = new System.Drawing.Size(81, 21);
            this.txtGastosManejo.StringValue = "";
            this.txtGastosManejo.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Handling";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Tasa:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Suplidor:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSuplidor);
            this.groupBox2.Controls.Add(this.cmbServicio);
            this.groupBox2.Controls.Add(this.cmbEstado);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtOrdenSuplidor);
            this.groupBox2.Location = new System.Drawing.Point(382, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 143);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTasa);
            this.groupBox3.Controls.Add(this.txtImpuesto);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtGastosEnvios);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(383, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 98);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // txtTasa
            // 
            this.txtTasa.AllowSpace = false;
            this.txtTasa.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTasa.Enabled = false;
            this.txtTasa.IntValue = 0;
            this.txtTasa.Location = new System.Drawing.Point(68, 69);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.Size = new System.Drawing.Size(76, 21);
            this.txtTasa.StringValue = "";
            this.txtTasa.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtImporte);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtGastosManejo);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtImporteLocal);
            this.groupBox4.Location = new System.Drawing.Point(547, 152);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(169, 100);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            // 
            // txtImporte
            // 
            this.txtImporte.AllowSpace = false;
            this.txtImporte.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtImporte.IntValue = 0;
            this.txtImporte.Location = new System.Drawing.Point(79, 41);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(76, 21);
            this.txtImporte.StringValue = "";
            this.txtImporte.TabIndex = 15;
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
            this.splitContainer1.Panel1.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel1.Controls.Add(this.btnGuardar);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(797, 598);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 22;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(710, 54);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(710, 24);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 22;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PagesArticulos);
            this.tabControl1.Controls.Add(this.PageCargos);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 331);
            this.tabControl1.TabIndex = 0;
            // 
            // PagesArticulos
            // 
            this.PagesArticulos.Controls.Add(this.dgArticulos);
            this.PagesArticulos.Location = new System.Drawing.Point(4, 22);
            this.PagesArticulos.Name = "PagesArticulos";
            this.PagesArticulos.Padding = new System.Windows.Forms.Padding(3);
            this.PagesArticulos.Size = new System.Drawing.Size(789, 305);
            this.PagesArticulos.TabIndex = 0;
            this.PagesArticulos.Text = "Articulos";
            this.PagesArticulos.UseVisualStyleBackColor = true;
            // 
            // dgArticulos
            // 
            this.dgArticulos.AllowUserToAddRows = false;
            this.dgArticulos.AllowUserToDeleteRows = false;
            this.dgArticulos.AutoGenerateColumns = false;
            this.dgArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.articuloIdDataGridViewTextBoxColumn,
            this.articuloDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn});
            this.dgArticulos.ContextMenuStrip = this.cmArticulo;
            this.dgArticulos.DataSource = this.articulosBindingSource;
            this.dgArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgArticulos.Location = new System.Drawing.Point(3, 3);
            this.dgArticulos.Name = "dgArticulos";
            this.dgArticulos.ReadOnly = true;
            this.dgArticulos.Size = new System.Drawing.Size(783, 299);
            this.dgArticulos.TabIndex = 0;
            this.dgArticulos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgArticulos_RowsAdded);
            // 
            // articuloIdDataGridViewTextBoxColumn
            // 
            this.articuloIdDataGridViewTextBoxColumn.DataPropertyName = "ArticuloId ";
            this.articuloIdDataGridViewTextBoxColumn.HeaderText = "ArticuloId ";
            this.articuloIdDataGridViewTextBoxColumn.Name = "articuloIdDataGridViewTextBoxColumn";
            this.articuloIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.articuloIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // articuloDataGridViewTextBoxColumn
            // 
            this.articuloDataGridViewTextBoxColumn.DataPropertyName = "Articulo";
            this.articuloDataGridViewTextBoxColumn.HeaderText = "Articulo";
            this.articuloDataGridViewTextBoxColumn.Name = "articuloDataGridViewTextBoxColumn";
            this.articuloDataGridViewTextBoxColumn.ReadOnly = true;
            this.articuloDataGridViewTextBoxColumn.Width = 67;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.Width = 88;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Width = 74;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            this.valorDataGridViewTextBoxColumn.Width = 56;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.Width = 56;
            // 
            // cmArticulo
            // 
            this.cmArticulo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarElementoToolStripMenuItem,
            this.eliminarElmentoToolStripMenuItem});
            this.cmArticulo.Name = "cmArticulo";
            this.cmArticulo.Size = new System.Drawing.Size(170, 48);
            // 
            // agregarElementoToolStripMenuItem
            // 
            this.agregarElementoToolStripMenuItem.Name = "agregarElementoToolStripMenuItem";
            this.agregarElementoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.agregarElementoToolStripMenuItem.Text = "Agregar Elemento";
            this.agregarElementoToolStripMenuItem.Click += new System.EventHandler(this.agregarElementoToolStripMenuItem_Click);
            // 
            // eliminarElmentoToolStripMenuItem
            // 
            this.eliminarElmentoToolStripMenuItem.Name = "eliminarElmentoToolStripMenuItem";
            this.eliminarElmentoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.eliminarElmentoToolStripMenuItem.Text = "Eliminar Elmento";
            // 
            // articulosBindingSource
            // 
            this.articulosBindingSource.DataMember = "Articulos";
            this.articulosBindingSource.DataSource = typeof(AgenciaEF_BO.DAL.dsFactura);
            // 
            // PageCargos
            // 
            this.PageCargos.Controls.Add(this.dgCargos);
            this.PageCargos.Location = new System.Drawing.Point(4, 22);
            this.PageCargos.Name = "PageCargos";
            this.PageCargos.Padding = new System.Windows.Forms.Padding(3);
            this.PageCargos.Size = new System.Drawing.Size(789, 305);
            this.PageCargos.TabIndex = 1;
            this.PageCargos.Text = "Cargos";
            this.PageCargos.UseVisualStyleBackColor = true;
            // 
            // dgCargos
            // 
            this.dgCargos.AllowUserToAddRows = false;
            this.dgCargos.AllowUserToDeleteRows = false;
            this.dgCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCargos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCargos.Location = new System.Drawing.Point(3, 3);
            this.dgCargos.Name = "dgCargos";
            this.dgCargos.ReadOnly = true;
            this.dgCargos.Size = new System.Drawing.Size(783, 299);
            this.dgCargos.TabIndex = 0;
            // 
            // txtSuplidor
            // 
            this.txtSuplidor.Location = new System.Drawing.Point(96, 78);
            this.txtSuplidor.Name = "txtSuplidor";
            this.txtSuplidor.Size = new System.Drawing.Size(208, 20);
            this.txtSuplidor.TabIndex = 18;
            // 
            // frmAgregarOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 598);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmAgregarOrdenes";
            this.Text = "REGISTRO DE ORDENES DE COMPRA";
            this.Load += new System.EventHandler(this.frmAgregarOrdenes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.PagesArticulos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgArticulos)).EndInit();
            this.cmArticulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.articulosBindingSource)).EndInit();
            this.PageCargos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCargos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textORD_NUM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrdenSuplidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbServicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtImporteLocal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private clsUtils.NumericTextBox txtImpuesto;
        private clsUtils.NumericTextBox txtGastosEnvios;
        private System.Windows.Forms.Label label9;
        private clsUtils.NumericTextBox txtGastosManejo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDireccion2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PagesArticulos;
        private System.Windows.Forms.TabPage PageCargos;
        private System.Windows.Forms.DataGridView dgArticulos;
        private System.Windows.Forms.DataGridView dgCargos;
        private System.Windows.Forms.Label lblEps;
        private System.Windows.Forms.ContextMenuStrip cmArticulo;
        private System.Windows.Forms.ToolStripMenuItem agregarElementoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarElmentoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn articuloIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn articuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource articulosBindingSource;
        private clsUtils.NumericTextBox txtTasa;
        private clsUtils.NumericTextBox txtImporte;
        private System.Windows.Forms.TextBox txtSuplidor;
    }
}