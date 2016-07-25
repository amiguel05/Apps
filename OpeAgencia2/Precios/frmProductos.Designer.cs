namespace OpeAgencia2.Precios
{
    partial class frmProductos
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.usrbntMant1 = new OpeAgencia2.usrbntMant();
            this.tabMant = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dg = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtMinimoFacturar = new clsUtils.NumericTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbUnidad = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkMensajeria = new System.Windows.Forms.CheckBox();
            this.chkCourier = new System.Windows.Forms.CheckBox();
            this.cmbDOC_TIPO_ID = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPRO_COMENTARIO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPRO_DESCRIPCION = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGRP_COD_ID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbORI_ID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.cmbSuplidorId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textPROD_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabCargos = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.btnAddCargo = new System.Windows.Forms.Button();
            this.dgCargos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabMant.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabCargos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCargos)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.usrbntMant1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabMant);
            this.splitContainer1.Size = new System.Drawing.Size(614, 475);
            this.splitContainer1.SplitterDistance = 42;
            this.splitContainer1.TabIndex = 2;
            // 
            // usrbntMant1
            // 
            this.usrbntMant1.bAdiciona = false;
            this.usrbntMant1.bExito = false;
            this.usrbntMant1.Location = new System.Drawing.Point(6, 4);
            this.usrbntMant1.Name = "usrbntMant1";
            this.usrbntMant1.Size = new System.Drawing.Size(479, 28);
            this.usrbntMant1.TabIndex = 0;
            // 
            // tabMant
            // 
            this.tabMant.Controls.Add(this.tabPage1);
            this.tabMant.Controls.Add(this.tabPage2);
            this.tabMant.Controls.Add(this.tabCargos);
            this.tabMant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMant.Location = new System.Drawing.Point(0, 0);
            this.tabMant.Name = "tabMant";
            this.tabMant.SelectedIndex = 0;
            this.tabMant.Size = new System.Drawing.Size(614, 429);
            this.tabMant.TabIndex = 0;
            this.tabMant.SelectedIndexChanged += new System.EventHandler(this.tabMant_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dg);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(606, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg.Location = new System.Drawing.Point(3, 3);
            this.dg.Name = "dg";
            this.dg.ReadOnly = true;
            this.dg.Size = new System.Drawing.Size(600, 397);
            this.dg.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtMinimoFacturar);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.cmbUnidad);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.chkMensajeria);
            this.tabPage2.Controls.Add(this.chkCourier);
            this.tabPage2.Controls.Add(this.cmbDOC_TIPO_ID);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.cmbTipo);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtPRO_COMENTARIO);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtPRO_DESCRIPCION);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.cmbGRP_COD_ID);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cmbORI_ID);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.chkEstado);
            this.tabPage2.Controls.Add(this.cmbSuplidorId);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtCodigo);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.textPROD_ID);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(606, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtMinimoFacturar
            // 
            this.txtMinimoFacturar.AllowSpace = false;
            this.txtMinimoFacturar.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMinimoFacturar.IntValue = 0;
            this.txtMinimoFacturar.Location = new System.Drawing.Point(152, 324);
            this.txtMinimoFacturar.Name = "txtMinimoFacturar";
            this.txtMinimoFacturar.Size = new System.Drawing.Size(96, 21);
            this.txtMinimoFacturar.TabIndex = 41;
            this.txtMinimoFacturar.Tag = "PRO_MINIMO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(50, 324);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Mínimo a Facturar:";
            // 
            // cmbUnidad
            // 
            this.cmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidad.FormattingEnabled = true;
            this.cmbUnidad.Location = new System.Drawing.Point(152, 297);
            this.cmbUnidad.Name = "cmbUnidad";
            this.cmbUnidad.Size = new System.Drawing.Size(261, 21);
            this.cmbUnidad.TabIndex = 38;
            this.cmbUnidad.Tag = "COD_UND_ID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(102, 300);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Unidad:";
            // 
            // chkMensajeria
            // 
            this.chkMensajeria.AutoSize = true;
            this.chkMensajeria.Location = new System.Drawing.Point(435, 160);
            this.chkMensajeria.Name = "chkMensajeria";
            this.chkMensajeria.Size = new System.Drawing.Size(77, 17);
            this.chkMensajeria.TabIndex = 36;
            this.chkMensajeria.Tag = "PRO_MENSAJERIA";
            this.chkMensajeria.Text = "Mensajeria";
            this.chkMensajeria.UseVisualStyleBackColor = true;
            // 
            // chkCourier
            // 
            this.chkCourier.AutoSize = true;
            this.chkCourier.Location = new System.Drawing.Point(435, 189);
            this.chkCourier.Name = "chkCourier";
            this.chkCourier.Size = new System.Drawing.Size(59, 17);
            this.chkCourier.TabIndex = 35;
            this.chkCourier.Tag = "PRO_COURIER";
            this.chkCourier.Text = "Courier";
            this.chkCourier.UseVisualStyleBackColor = true;
            // 
            // cmbDOC_TIPO_ID
            // 
            this.cmbDOC_TIPO_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDOC_TIPO_ID.FormattingEnabled = true;
            this.cmbDOC_TIPO_ID.Location = new System.Drawing.Point(152, 267);
            this.cmbDOC_TIPO_ID.Name = "cmbDOC_TIPO_ID";
            this.cmbDOC_TIPO_ID.Size = new System.Drawing.Size(261, 21);
            this.cmbDOC_TIPO_ID.TabIndex = 32;
            this.cmbDOC_TIPO_ID.Tag = "DOC_TIPO_ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(89, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Doc. Tipo:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(152, 240);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(261, 21);
            this.cmbTipo.TabIndex = 30;
            this.cmbTipo.Tag = "PRO_TIPO_ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(115, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Tipo:";
            // 
            // txtPRO_COMENTARIO
            // 
            this.txtPRO_COMENTARIO.Location = new System.Drawing.Point(152, 183);
            this.txtPRO_COMENTARIO.Multiline = true;
            this.txtPRO_COMENTARIO.Name = "txtPRO_COMENTARIO";
            this.txtPRO_COMENTARIO.Size = new System.Drawing.Size(261, 51);
            this.txtPRO_COMENTARIO.TabIndex = 28;
            this.txtPRO_COMENTARIO.Tag = "PRO_COMENTARIO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Comentario:";
            // 
            // txtPRO_DESCRIPCION
            // 
            this.txtPRO_DESCRIPCION.Location = new System.Drawing.Point(152, 157);
            this.txtPRO_DESCRIPCION.Name = "txtPRO_DESCRIPCION";
            this.txtPRO_DESCRIPCION.Size = new System.Drawing.Size(261, 20);
            this.txtPRO_DESCRIPCION.TabIndex = 26;
            this.txtPRO_DESCRIPCION.Tag = "PRO_DESCRIPCION";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Descripción:";
            // 
            // cmbGRP_COD_ID
            // 
            this.cmbGRP_COD_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGRP_COD_ID.FormattingEnabled = true;
            this.cmbGRP_COD_ID.Location = new System.Drawing.Point(152, 127);
            this.cmbGRP_COD_ID.Name = "cmbGRP_COD_ID";
            this.cmbGRP_COD_ID.Size = new System.Drawing.Size(261, 21);
            this.cmbGRP_COD_ID.TabIndex = 24;
            this.cmbGRP_COD_ID.Tag = "GRP_COD_ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Grupo:";
            // 
            // cmbORI_ID
            // 
            this.cmbORI_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbORI_ID.FormattingEnabled = true;
            this.cmbORI_ID.Location = new System.Drawing.Point(152, 100);
            this.cmbORI_ID.Name = "cmbORI_ID";
            this.cmbORI_ID.Size = new System.Drawing.Size(261, 21);
            this.cmbORI_ID.TabIndex = 22;
            this.cmbORI_ID.Tag = "ORI_ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Origen:";
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(435, 217);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(56, 17);
            this.chkEstado.TabIndex = 20;
            this.chkEstado.Tag = "PRO_ESTADO";
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // cmbSuplidorId
            // 
            this.cmbSuplidorId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuplidorId.FormattingEnabled = true;
            this.cmbSuplidorId.Location = new System.Drawing.Point(152, 73);
            this.cmbSuplidorId.Name = "cmbSuplidorId";
            this.cmbSuplidorId.Size = new System.Drawing.Size(261, 21);
            this.cmbSuplidorId.TabIndex = 19;
            this.cmbSuplidorId.Tag = "SUP_ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Suplidor:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(152, 47);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.Tag = "PRO_CODIGO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(103, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Código:";
            // 
            // textPROD_ID
            // 
            this.textPROD_ID.Enabled = false;
            this.textPROD_ID.Location = new System.Drawing.Point(152, 21);
            this.textPROD_ID.Name = "textPROD_ID";
            this.textPROD_ID.Size = new System.Drawing.Size(100, 20);
            this.textPROD_ID.TabIndex = 1;
            this.textPROD_ID.Tag = "PROD_ID";
            this.textPROD_ID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto Id:";
            this.label1.Visible = false;
            // 
            // tabCargos
            // 
            this.tabCargos.Controls.Add(this.splitContainer2);
            this.tabCargos.Location = new System.Drawing.Point(4, 22);
            this.tabCargos.Name = "tabCargos";
            this.tabCargos.Padding = new System.Windows.Forms.Padding(3);
            this.tabCargos.Size = new System.Drawing.Size(606, 403);
            this.tabCargos.TabIndex = 2;
            this.tabCargos.Text = "Cargos";
            this.tabCargos.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnEliminar);
            this.splitContainer2.Panel1.Controls.Add(this.lblProducto);
            this.splitContainer2.Panel1.Controls.Add(this.btnAddCargo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgCargos);
            this.splitContainer2.Size = new System.Drawing.Size(600, 397);
            this.splitContainer2.SplitterDistance = 43;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(90, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(210, 15);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(13, 13);
            this.lblProducto.TabIndex = 1;
            this.lblProducto.Text = "[]";
            this.lblProducto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAddCargo
            // 
            this.btnAddCargo.Location = new System.Drawing.Point(9, 10);
            this.btnAddCargo.Name = "btnAddCargo";
            this.btnAddCargo.Size = new System.Drawing.Size(75, 23);
            this.btnAddCargo.TabIndex = 0;
            this.btnAddCargo.Text = "Adicionar";
            this.btnAddCargo.UseVisualStyleBackColor = true;
            this.btnAddCargo.Click += new System.EventHandler(this.btnAddCargo_Click);
            // 
            // dgCargos
            // 
            this.dgCargos.AllowUserToAddRows = false;
            this.dgCargos.AllowUserToDeleteRows = false;
            this.dgCargos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCargos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCargos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCargos.Location = new System.Drawing.Point(0, 0);
            this.dgCargos.Name = "dgCargos";
            this.dgCargos.ReadOnly = true;
            this.dgCargos.Size = new System.Drawing.Size(600, 350);
            this.dgCargos.TabIndex = 1;
            this.dgCargos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCargos_CellContentClick);
            this.dgCargos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCargos_CellContentDoubleClick);
            this.dgCargos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgCargos_MouseDoubleClick);
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 475);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.frmProductos_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabMant.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabCargos.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCargos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private usrbntMant usrbntMant1;
        private System.Windows.Forms.TabControl tabMant;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.ComboBox cmbSuplidorId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textPROD_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbGRP_COD_ID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbORI_ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPRO_DESCRIPCION;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPRO_COMENTARIO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDOC_TIPO_ID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkCourier;
        private System.Windows.Forms.CheckBox chkMensajeria;
        private System.Windows.Forms.ComboBox cmbUnidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabCargos;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Button btnAddCargo;
        private System.Windows.Forms.DataGridView dgCargos;
        private clsUtils.NumericTextBox txtMinimoFacturar;
        private System.Windows.Forms.Button btnEliminar;
    }
}