namespace OpeAgencia2.Clientes
{
    partial class frmTarEspValores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEps = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tARESPVALDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALHASTADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALVALORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALPORCENTAJEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALADICIONALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tARESPVALDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEps);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblEps
            // 
            this.lblEps.AutoSize = true;
            this.lblEps.Location = new System.Drawing.Point(23, 26);
            this.lblEps.Name = "lblEps";
            this.lblEps.Size = new System.Drawing.Size(35, 13);
            this.lblEps.TabIndex = 0;
            this.lblEps.Text = "lblEps";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 205);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.vALHASTADataGridViewTextBoxColumn,
            this.vALVALORDataGridViewTextBoxColumn,
            this.vALPORCENTAJEDataGridViewTextBoxColumn,
            this.vALADICIONALDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tARESPVALDataTableBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(447, 186);
            this.dataGridView1.TabIndex = 0;
            // 
            // tARESPVALDataTableBindingSource
            // 
            this.tARESPVALDataTableBindingSource.DataSource = typeof(AgenciaEF_BO.DAL.dsDatos.TARESP_VALDataTable);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // vALHASTADataGridViewTextBoxColumn
            // 
            this.vALHASTADataGridViewTextBoxColumn.DataPropertyName = "VAL_HASTA";
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = "0";
            this.vALHASTADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.vALHASTADataGridViewTextBoxColumn.HeaderText = "Hasta";
            this.vALHASTADataGridViewTextBoxColumn.Name = "vALHASTADataGridViewTextBoxColumn";
            // 
            // vALVALORDataGridViewTextBoxColumn
            // 
            this.vALVALORDataGridViewTextBoxColumn.DataPropertyName = "VAL_VALOR";
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0";
            this.vALVALORDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.vALVALORDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.vALVALORDataGridViewTextBoxColumn.Name = "vALVALORDataGridViewTextBoxColumn";
            // 
            // vALPORCENTAJEDataGridViewTextBoxColumn
            // 
            this.vALPORCENTAJEDataGridViewTextBoxColumn.DataPropertyName = "VAL_PORCENTAJE";
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = "0";
            this.vALPORCENTAJEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.vALPORCENTAJEDataGridViewTextBoxColumn.HeaderText = "Porcentaje";
            this.vALPORCENTAJEDataGridViewTextBoxColumn.Name = "vALPORCENTAJEDataGridViewTextBoxColumn";
            // 
            // vALADICIONALDataGridViewTextBoxColumn
            // 
            this.vALADICIONALDataGridViewTextBoxColumn.DataPropertyName = "VAL_ADICIONAL";
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = "0";
            this.vALADICIONALDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.vALADICIONALDataGridViewTextBoxColumn.HeaderText = "Adicional";
            this.vALADICIONALDataGridViewTextBoxColumn.Name = "vALADICIONALDataGridViewTextBoxColumn";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(301, 297);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Aceptar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(382, 298);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmTarEspValores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 332);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTarEspValores";
            this.Text = "frmTarEspValores";
            this.Load += new System.EventHandler(this.frmTarEspValores_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tARESPVALDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEps;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALHASTADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALVALORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALPORCENTAJEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALADICIONALDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource tARESPVALDataTableBindingSource;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}