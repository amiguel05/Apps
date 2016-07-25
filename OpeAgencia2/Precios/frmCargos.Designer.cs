namespace OpeAgencia2.Precios
{
    partial class frmCargos
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
            this.chkCobros = new System.Windows.Forms.CheckBox();
            this.chk_NC = new System.Windows.Forms.CheckBox();
            this.txtPorITBIS = new clsUtils.NumericTextBox();
            this.chkNCF = new System.Windows.Forms.CheckBox();
            this.cmbCAR_BASE = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSumar = new System.Windows.Forms.CheckBox();
            this.chkRedondear = new System.Windows.Forms.CheckBox();
            this.txtMinimoFacturar = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.chkRedondearEnteros = new System.Windows.Forms.CheckBox();
            this.chkItebis = new System.Windows.Forms.CheckBox();
            this.cmbCAR_TOPE_MAXIMO = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbCarFijoMultiplicar = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCAR_DESCRIPCION = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCarDirectoTabla = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.cmbTipoId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textCargoId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabMant.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimoFacturar)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(631, 389);
            this.splitContainer1.SplitterDistance = 34;
            this.splitContainer1.TabIndex = 3;
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
            this.tabMant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMant.Location = new System.Drawing.Point(0, 0);
            this.tabMant.Name = "tabMant";
            this.tabMant.SelectedIndex = 0;
            this.tabMant.Size = new System.Drawing.Size(631, 351);
            this.tabMant.TabIndex = 0;
            this.tabMant.SelectedIndexChanged += new System.EventHandler(this.tabMant_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dg);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(623, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.AllowUserToOrderColumns = true;
            this.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg.Location = new System.Drawing.Point(3, 3);
            this.dg.Name = "dg";
            this.dg.ReadOnly = true;
            this.dg.Size = new System.Drawing.Size(617, 319);
            this.dg.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkCobros);
            this.tabPage2.Controls.Add(this.chk_NC);
            this.tabPage2.Controls.Add(this.txtPorITBIS);
            this.tabPage2.Controls.Add(this.chkNCF);
            this.tabPage2.Controls.Add(this.cmbCAR_BASE);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.chkSumar);
            this.tabPage2.Controls.Add(this.chkRedondear);
            this.tabPage2.Controls.Add(this.txtMinimoFacturar);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.chkRedondearEnteros);
            this.tabPage2.Controls.Add(this.chkItebis);
            this.tabPage2.Controls.Add(this.cmbCAR_TOPE_MAXIMO);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.cmbCarFijoMultiplicar);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtCAR_DESCRIPCION);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cmbCarDirectoTabla);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.chkEstado);
            this.tabPage2.Controls.Add(this.cmbTipoId);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtCodigo);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.textCargoId);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(623, 325);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkCobros
            // 
            this.chkCobros.AutoSize = true;
            this.chkCobros.Location = new System.Drawing.Point(436, 183);
            this.chkCobros.Name = "chkCobros";
            this.chkCobros.Size = new System.Drawing.Size(59, 17);
            this.chkCobros.TabIndex = 49;
            this.chkCobros.Tag = "CAR_COBROS";
            this.chkCobros.Text = "Cobros";
            this.chkCobros.UseVisualStyleBackColor = true;
            // 
            // chk_NC
            // 
            this.chk_NC.AutoSize = true;
            this.chk_NC.Location = new System.Drawing.Point(436, 158);
            this.chk_NC.Name = "chk_NC";
            this.chk_NC.Size = new System.Drawing.Size(99, 17);
            this.chk_NC.TabIndex = 48;
            this.chk_NC.Tag = "CAR_NC";
            this.chk_NC.Text = "Nota de crédito";
            this.chk_NC.UseVisualStyleBackColor = true;
            // 
            // txtPorITBIS
            // 
            this.txtPorITBIS.AllowSpace = false;
            this.txtPorITBIS.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPorITBIS.IntValue = 0;
            this.txtPorITBIS.Location = new System.Drawing.Point(495, 99);
            this.txtPorITBIS.Name = "txtPorITBIS";
            this.txtPorITBIS.Size = new System.Drawing.Size(70, 21);
            this.txtPorITBIS.StringValue = "0";
            this.txtPorITBIS.TabIndex = 47;
            this.txtPorITBIS.Tag = "ITBIS";
            // 
            // chkNCF
            // 
            this.chkNCF.AutoSize = true;
            this.chkNCF.Location = new System.Drawing.Point(436, 131);
            this.chkNCF.Name = "chkNCF";
            this.chkNCF.Size = new System.Drawing.Size(47, 17);
            this.chkNCF.TabIndex = 46;
            this.chkNCF.Tag = "CAR_NCF";
            this.chkNCF.Text = "NCF";
            this.chkNCF.UseVisualStyleBackColor = true;
            // 
            // cmbCAR_BASE
            // 
            this.cmbCAR_BASE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCAR_BASE.FormattingEnabled = true;
            this.cmbCAR_BASE.Location = new System.Drawing.Point(121, 251);
            this.cmbCAR_BASE.Name = "cmbCAR_BASE";
            this.cmbCAR_BASE.Size = new System.Drawing.Size(261, 21);
            this.cmbCAR_BASE.TabIndex = 44;
            this.cmbCAR_BASE.Tag = "CAR_BASE_ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Base:";
            // 
            // chkSumar
            // 
            this.chkSumar.AutoSize = true;
            this.chkSumar.Location = new System.Drawing.Point(436, 80);
            this.chkSumar.Name = "chkSumar";
            this.chkSumar.Size = new System.Drawing.Size(56, 17);
            this.chkSumar.TabIndex = 42;
            this.chkSumar.Tag = "CAR_SUMAR";
            this.chkSumar.Text = "Sumar";
            this.chkSumar.UseVisualStyleBackColor = true;
            // 
            // chkRedondear
            // 
            this.chkRedondear.AutoSize = true;
            this.chkRedondear.Location = new System.Drawing.Point(436, 57);
            this.chkRedondear.Name = "chkRedondear";
            this.chkRedondear.Size = new System.Drawing.Size(79, 17);
            this.chkRedondear.TabIndex = 41;
            this.chkRedondear.Tag = "CAR_REDONDEAR";
            this.chkRedondear.Text = "Redondear";
            this.chkRedondear.UseVisualStyleBackColor = true;
            // 
            // txtMinimoFacturar
            // 
            this.txtMinimoFacturar.Location = new System.Drawing.Point(121, 278);
            this.txtMinimoFacturar.Name = "txtMinimoFacturar";
            this.txtMinimoFacturar.Size = new System.Drawing.Size(120, 20);
            this.txtMinimoFacturar.TabIndex = 40;
            this.txtMinimoFacturar.Tag = "CAR_MINIMO_FACTURAR";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 280);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Mínimo a Facturar:";
            // 
            // chkRedondearEnteros
            // 
            this.chkRedondearEnteros.AutoSize = true;
            this.chkRedondearEnteros.Location = new System.Drawing.Point(436, 34);
            this.chkRedondearEnteros.Name = "chkRedondearEnteros";
            this.chkRedondearEnteros.Size = new System.Drawing.Size(117, 17);
            this.chkRedondearEnteros.TabIndex = 36;
            this.chkRedondearEnteros.Tag = "CAR_RED_ENTEROS";
            this.chkRedondearEnteros.Text = "Redondear enteros";
            this.chkRedondearEnteros.UseVisualStyleBackColor = true;
            // 
            // chkItebis
            // 
            this.chkItebis.AutoSize = true;
            this.chkItebis.Location = new System.Drawing.Point(436, 103);
            this.chkItebis.Name = "chkItebis";
            this.chkItebis.Size = new System.Drawing.Size(53, 17);
            this.chkItebis.TabIndex = 35;
            this.chkItebis.Tag = "CAR_ITBIS";
            this.chkItebis.Text = "ITBIS";
            this.chkItebis.UseVisualStyleBackColor = true;
            // 
            // cmbCAR_TOPE_MAXIMO
            // 
            this.cmbCAR_TOPE_MAXIMO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCAR_TOPE_MAXIMO.FormattingEnabled = true;
            this.cmbCAR_TOPE_MAXIMO.Items.AddRange(new object[] {
            "Adicional",
            "Porcentaje",
            "Sin Tope"});
            this.cmbCAR_TOPE_MAXIMO.Location = new System.Drawing.Point(121, 224);
            this.cmbCAR_TOPE_MAXIMO.Name = "cmbCAR_TOPE_MAXIMO";
            this.cmbCAR_TOPE_MAXIMO.Size = new System.Drawing.Size(261, 21);
            this.cmbCAR_TOPE_MAXIMO.TabIndex = 32;
            this.cmbCAR_TOPE_MAXIMO.Tag = "CAR_TOPE_MAXIMO";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Tope tabla:";
            // 
            // cmbCarFijoMultiplicar
            // 
            this.cmbCarFijoMultiplicar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarFijoMultiplicar.FormattingEnabled = true;
            this.cmbCarFijoMultiplicar.Items.AddRange(new object[] {
            "Fijo",
            "Multiplicar"});
            this.cmbCarFijoMultiplicar.Location = new System.Drawing.Point(121, 197);
            this.cmbCarFijoMultiplicar.Name = "cmbCarFijoMultiplicar";
            this.cmbCarFijoMultiplicar.Size = new System.Drawing.Size(261, 21);
            this.cmbCarFijoMultiplicar.TabIndex = 30;
            this.cmbCarFijoMultiplicar.Tag = "CAR_FIJO_MULTIPLICAR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Forma aplicación:";
            // 
            // txtCAR_DESCRIPCION
            // 
            this.txtCAR_DESCRIPCION.Location = new System.Drawing.Point(121, 86);
            this.txtCAR_DESCRIPCION.Multiline = true;
            this.txtCAR_DESCRIPCION.Name = "txtCAR_DESCRIPCION";
            this.txtCAR_DESCRIPCION.Size = new System.Drawing.Size(261, 51);
            this.txtCAR_DESCRIPCION.TabIndex = 28;
            this.txtCAR_DESCRIPCION.Tag = "CAR_DESCRIPCION";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Descripción:";
            // 
            // cmbCarDirectoTabla
            // 
            this.cmbCarDirectoTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarDirectoTabla.FormattingEnabled = true;
            this.cmbCarDirectoTabla.Items.AddRange(new object[] {
            "Directo",
            "Tabla"});
            this.cmbCarDirectoTabla.Location = new System.Drawing.Point(121, 170);
            this.cmbCarDirectoTabla.Name = "cmbCarDirectoTabla";
            this.cmbCarDirectoTabla.Size = new System.Drawing.Size(261, 21);
            this.cmbCarDirectoTabla.TabIndex = 22;
            this.cmbCarDirectoTabla.Tag = "CAR_DIRECTO_TABLA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Valor:";
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(436, 206);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(56, 17);
            this.chkEstado.TabIndex = 20;
            this.chkEstado.Tag = "CAR_ESTADO";
            this.chkEstado.Text = "Activo";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // cmbTipoId
            // 
            this.cmbTipoId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoId.FormattingEnabled = true;
            this.cmbTipoId.Items.AddRange(new object[] {
            "UNIDAD",
            "CARGO"});
            this.cmbTipoId.Location = new System.Drawing.Point(121, 143);
            this.cmbTipoId.Name = "cmbTipoId";
            this.cmbTipoId.Size = new System.Drawing.Size(261, 21);
            this.cmbTipoId.TabIndex = 19;
            this.cmbTipoId.Tag = "CAR_TIPO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tipo:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(121, 60);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.Tag = "CAR_CODIGO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Código:";
            // 
            // textCargoId
            // 
            this.textCargoId.Enabled = false;
            this.textCargoId.Location = new System.Drawing.Point(121, 34);
            this.textCargoId.Name = "textCargoId";
            this.textCargoId.Size = new System.Drawing.Size(100, 20);
            this.textCargoId.TabIndex = 1;
            this.textCargoId.Tag = "CARGO_ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cargo Id:";
            // 
            // frmCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 389);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmCargos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargos";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimoFacturar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private usrbntMant usrbntMant1;
        private System.Windows.Forms.TabControl tabMant;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown txtMinimoFacturar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkRedondearEnteros;
        private System.Windows.Forms.CheckBox chkItebis;
        private System.Windows.Forms.ComboBox cmbCAR_TOPE_MAXIMO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCarFijoMultiplicar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCAR_DESCRIPCION;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCarDirectoTabla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.ComboBox cmbTipoId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textCargoId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCAR_BASE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkSumar;
        private System.Windows.Forms.CheckBox chkRedondear;
        private System.Windows.Forms.CheckBox chkNCF;
        private clsUtils.NumericTextBox txtPorITBIS;
        private System.Windows.Forms.CheckBox chk_NC;
        private System.Windows.Forms.CheckBox chkCobros;
    }
}