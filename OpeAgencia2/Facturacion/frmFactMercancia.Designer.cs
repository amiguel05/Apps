namespace OpeAgencia2.Facturacion
{
    partial class frmFactMercancia
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoFact = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dFechaVenc = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtEPS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMontoNoVenta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPaq = new System.Windows.Forms.TextBox();
            this.lblPaquetes = new System.Windows.Forms.Label();
            this.tabDetalle = new System.Windows.Forms.TabControl();
            this.tabPaq = new System.Windows.Forms.TabPage();
            this.dgResumen = new System.Windows.Forms.DataGridView();
            this.Cargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPaq = new System.Windows.Forms.DataGridView();
            this.txtTarifa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabCorr = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCorres = new System.Windows.Forms.Button();
            this.dgCorr = new System.Windows.Forms.DataGridView();
            this.lblCorrespondencia = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabDetalle.SuspendLayout();
            this.tabPaq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResumen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPaq)).BeginInit();
            this.tabCorr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCorr)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbTipoFact);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dFechaVenc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblNombres);
            this.groupBox1.Controls.Add(this.txtEPS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(838, 40);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbTipoFact
            // 
            this.cmbTipoFact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoFact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoFact.Enabled = false;
            this.cmbTipoFact.FormattingEnabled = true;
            this.cmbTipoFact.Items.AddRange(new object[] {
            "Contado",
            "Crédito"});
            this.cmbTipoFact.Location = new System.Drawing.Point(711, 12);
            this.cmbTipoFact.Name = "cmbTipoFact";
            this.cmbTipoFact.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoFact.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(650, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tipo Fact:";
            // 
            // dFechaVenc
            // 
            this.dFechaVenc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dFechaVenc.Enabled = false;
            this.dFechaVenc.Location = new System.Drawing.Point(444, 12);
            this.dFechaVenc.Name = "dFechaVenc";
            this.dFechaVenc.Size = new System.Drawing.Size(200, 20);
            this.dFechaVenc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Venc.:";
            // 
            // lblNombres
            // 
            this.lblNombres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(155, 16);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(55, 13);
            this.lblNombres.TabIndex = 2;
            this.lblNombres.Text = "[Nombres]";
            // 
            // txtEPS
            // 
            this.txtEPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEPS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEPS.Location = new System.Drawing.Point(49, 13);
            this.txtEPS.Name = "txtEPS";
            this.txtEPS.Size = new System.Drawing.Size(100, 20);
            this.txtEPS.TabIndex = 1;
            this.txtEPS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEPS_KeyDown);
            this.txtEPS.Leave += new System.EventHandler(this.txtEPS_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EPS:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtMontoNoVenta);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnFacturar);
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Controls.Add(this.txtMontoTotal);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtPaq);
            this.groupBox3.Controls.Add(this.lblPaquetes);
            this.groupBox3.Location = new System.Drawing.Point(302, 400);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 64);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // txtMontoNoVenta
            // 
            this.txtMontoNoVenta.Enabled = false;
            this.txtMontoNoVenta.Location = new System.Drawing.Point(227, 36);
            this.txtMontoNoVenta.Name = "txtMontoNoVenta";
            this.txtMontoNoVenta.Size = new System.Drawing.Size(100, 20);
            this.txtMontoNoVenta.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Monto No venta:";
            // 
            // btnFacturar
            // 
            this.btnFacturar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFacturar.Location = new System.Drawing.Point(465, 23);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(75, 23);
            this.btnFacturar.TabIndex = 5;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(384, 23);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Enabled = false;
            this.txtMontoTotal.Location = new System.Drawing.Point(121, 36);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.Size = new System.Drawing.Size(100, 20);
            this.txtMontoTotal.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Monto:";
            // 
            // txtPaq
            // 
            this.txtPaq.Enabled = false;
            this.txtPaq.Location = new System.Drawing.Point(15, 35);
            this.txtPaq.Name = "txtPaq";
            this.txtPaq.Size = new System.Drawing.Size(100, 20);
            this.txtPaq.TabIndex = 1;
            // 
            // lblPaquetes
            // 
            this.lblPaquetes.AutoSize = true;
            this.lblPaquetes.Location = new System.Drawing.Point(12, 20);
            this.lblPaquetes.Name = "lblPaquetes";
            this.lblPaquetes.Size = new System.Drawing.Size(55, 13);
            this.lblPaquetes.TabIndex = 0;
            this.lblPaquetes.Text = "Paquetes:";
            // 
            // tabDetalle
            // 
            this.tabDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDetalle.Controls.Add(this.tabPaq);
            this.tabDetalle.Controls.Add(this.tabCorr);
            this.tabDetalle.Location = new System.Drawing.Point(12, 59);
            this.tabDetalle.Name = "tabDetalle";
            this.tabDetalle.SelectedIndex = 0;
            this.tabDetalle.Size = new System.Drawing.Size(839, 335);
            this.tabDetalle.TabIndex = 0;
            // 
            // tabPaq
            // 
            this.tabPaq.Controls.Add(this.dgResumen);
            this.tabPaq.Controls.Add(this.dgPaq);
            this.tabPaq.Controls.Add(this.txtTarifa);
            this.tabPaq.Controls.Add(this.label7);
            this.tabPaq.Location = new System.Drawing.Point(4, 22);
            this.tabPaq.Name = "tabPaq";
            this.tabPaq.Padding = new System.Windows.Forms.Padding(3);
            this.tabPaq.Size = new System.Drawing.Size(831, 309);
            this.tabPaq.TabIndex = 0;
            this.tabPaq.Text = "Paquetes";
            this.tabPaq.UseVisualStyleBackColor = true;
            // 
            // dgResumen
            // 
            this.dgResumen.AllowUserToAddRows = false;
            this.dgResumen.AllowUserToDeleteRows = false;
            this.dgResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgResumen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResumen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cargo,
            this.Valor});
            this.dgResumen.Location = new System.Drawing.Point(538, 3);
            this.dgResumen.Name = "dgResumen";
            this.dgResumen.ReadOnly = true;
            this.dgResumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResumen.Size = new System.Drawing.Size(292, 273);
            this.dgResumen.TabIndex = 5;
            // 
            // Cargo
            // 
            this.Cargo.HeaderText = "Cargo";
            this.Cargo.Name = "Cargo";
            this.Cargo.ReadOnly = true;
            this.Cargo.Width = 60;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Width = 56;
            // 
            // dgPaq
            // 
            this.dgPaq.AllowUserToAddRows = false;
            this.dgPaq.AllowUserToDeleteRows = false;
            this.dgPaq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPaq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPaq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPaq.Location = new System.Drawing.Point(7, 3);
            this.dgPaq.Name = "dgPaq";
            this.dgPaq.ReadOnly = true;
            this.dgPaq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPaq.Size = new System.Drawing.Size(531, 303);
            this.dgPaq.TabIndex = 4;
            this.dgPaq.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPaq_CellDoubleClick);
            this.dgPaq.SelectionChanged += new System.EventHandler(this.dgPaq_SelectionChanged);
            // 
            // txtTarifa
            // 
            this.txtTarifa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTarifa.Enabled = false;
            this.txtTarifa.Location = new System.Drawing.Point(769, 282);
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.Size = new System.Drawing.Size(56, 20);
            this.txtTarifa.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(729, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tarifa";
            // 
            // tabCorr
            // 
            this.tabCorr.Controls.Add(this.splitContainer1);
            this.tabCorr.Location = new System.Drawing.Point(4, 22);
            this.tabCorr.Name = "tabCorr";
            this.tabCorr.Padding = new System.Windows.Forms.Padding(3);
            this.tabCorr.Size = new System.Drawing.Size(831, 309);
            this.tabCorr.TabIndex = 1;
            this.tabCorr.Text = "Correspondencia";
            this.tabCorr.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnCorres);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgCorr);
            this.splitContainer1.Size = new System.Drawing.Size(825, 303);
            this.splitContainer1.SplitterDistance = 38;
            this.splitContainer1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnCorres
            // 
            this.btnCorres.Location = new System.Drawing.Point(8, 5);
            this.btnCorres.Name = "btnCorres";
            this.btnCorres.Size = new System.Drawing.Size(96, 23);
            this.btnCorres.TabIndex = 5;
            this.btnCorres.Text = "Agregar";
            this.btnCorres.UseVisualStyleBackColor = true;
            this.btnCorres.Click += new System.EventHandler(this.btnCorres_Click);
            // 
            // dgCorr
            // 
            this.dgCorr.AllowUserToAddRows = false;
            this.dgCorr.AllowUserToDeleteRows = false;
            this.dgCorr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgCorr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCorr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCorr.Location = new System.Drawing.Point(0, 0);
            this.dgCorr.Name = "dgCorr";
            this.dgCorr.ReadOnly = true;
            this.dgCorr.Size = new System.Drawing.Size(825, 261);
            this.dgCorr.TabIndex = 1;
            this.dgCorr.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCorr_CellEndEdit);
            // 
            // lblCorrespondencia
            // 
            this.lblCorrespondencia.AutoSize = true;
            this.lblCorrespondencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrespondencia.ForeColor = System.Drawing.Color.Red;
            this.lblCorrespondencia.Location = new System.Drawing.Point(13, 410);
            this.lblCorrespondencia.Name = "lblCorrespondencia";
            this.lblCorrespondencia.Size = new System.Drawing.Size(13, 20);
            this.lblCorrespondencia.TabIndex = 3;
            this.lblCorrespondencia.Text = ".";
            // 
            // frmFactMercancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 470);
            this.Controls.Add(this.lblCorrespondencia);
            this.Controls.Add(this.tabDetalle);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1059, 509);
            this.Name = "frmFactMercancia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación de Mercancía";
            this.Load += new System.EventHandler(this.frmFactMercancia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabDetalle.ResumeLayout(false);
            this.tabPaq.ResumeLayout(false);
            this.tabPaq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResumen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPaq)).EndInit();
            this.tabCorr.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCorr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEPS;
        private System.Windows.Forms.DateTimePicker dFechaVenc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPaq;
        private System.Windows.Forms.Label lblPaquetes;
        private System.Windows.Forms.ComboBox cmbTipoFact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMontoNoVenta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabDetalle;
        private System.Windows.Forms.TabPage tabPaq;
        private System.Windows.Forms.DataGridView dgResumen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridView dgPaq;
        private System.Windows.Forms.TabPage tabCorr;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCorres;
        private System.Windows.Forms.DataGridView dgCorr;
        private System.Windows.Forms.TextBox txtTarifa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCorrespondencia;
    }
}