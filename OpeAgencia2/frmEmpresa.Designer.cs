namespace OpeAgencia2
{
    partial class frmEmpresa
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
            this.txtNombreCorto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCOM_EMAIL = new System.Windows.Forms.TextBox();
            this.txtCOM_FAX = new System.Windows.Forms.TextBox();
            this.txtCOM_TELEFONO = new System.Windows.Forms.TextBox();
            this.txtCOM_DIRECCION = new System.Windows.Forms.TextBox();
            this.txtCOM_RESPONSABLE = new System.Windows.Forms.TextBox();
            this.txtCOM_RNC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCOM_DESCRIPCION = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.textCom_Codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabMant.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.tabPage2.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(606, 426);
            this.splitContainer1.SplitterDistance = 39;
            this.splitContainer1.TabIndex = 0;
            // 
            // usrbntMant1
            // 
            this.usrbntMant1.bAdiciona = false;
            this.usrbntMant1.bExito = false;
            this.usrbntMant1.Location = new System.Drawing.Point(6, 4);
            this.usrbntMant1.Name = "usrbntMant1";
            this.usrbntMant1.Size = new System.Drawing.Size(479, 28);
            this.usrbntMant1.TabIndex = 0;
            this.usrbntMant1.Load += new System.EventHandler(this.usrbntMant1_Load);
            // 
            // tabMant
            // 
            this.tabMant.Controls.Add(this.tabPage1);
            this.tabMant.Controls.Add(this.tabPage2);
            this.tabMant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMant.Location = new System.Drawing.Point(0, 0);
            this.tabMant.Name = "tabMant";
            this.tabMant.SelectedIndex = 0;
            this.tabMant.Size = new System.Drawing.Size(606, 383);
            this.tabMant.TabIndex = 0;
            this.tabMant.SelectedIndexChanged += new System.EventHandler(this.tabMant_SelectedIndexChanged);
            this.tabMant.TabIndexChanged += new System.EventHandler(this.tabMant_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dg);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(598, 357);
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
            this.dg.Size = new System.Drawing.Size(592, 351);
            this.dg.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtNombreCorto);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtCOM_EMAIL);
            this.tabPage2.Controls.Add(this.txtCOM_FAX);
            this.tabPage2.Controls.Add(this.txtCOM_TELEFONO);
            this.tabPage2.Controls.Add(this.txtCOM_DIRECCION);
            this.tabPage2.Controls.Add(this.txtCOM_RESPONSABLE);
            this.tabPage2.Controls.Add(this.txtCOM_RNC);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtCOM_DESCRIPCION);
            this.tabPage2.Controls.Add(this.lblDesc);
            this.tabPage2.Controls.Add(this.textCom_Codigo);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(572, 346);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtNombreCorto
            // 
            this.txtNombreCorto.Location = new System.Drawing.Point(88, 60);
            this.txtNombreCorto.Name = "txtNombreCorto";
            this.txtNombreCorto.Size = new System.Drawing.Size(261, 20);
            this.txtNombreCorto.TabIndex = 17;
            this.txtNombreCorto.Tag = "COM_DESCORTA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Código:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Fax:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Telefono:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Dirección:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Responsable:";
            // 
            // txtCOM_EMAIL
            // 
            this.txtCOM_EMAIL.Location = new System.Drawing.Point(88, 292);
            this.txtCOM_EMAIL.Name = "txtCOM_EMAIL";
            this.txtCOM_EMAIL.Size = new System.Drawing.Size(305, 20);
            this.txtCOM_EMAIL.TabIndex = 10;
            this.txtCOM_EMAIL.Tag = "COM_EMAIL";
            // 
            // txtCOM_FAX
            // 
            this.txtCOM_FAX.Location = new System.Drawing.Point(88, 257);
            this.txtCOM_FAX.Name = "txtCOM_FAX";
            this.txtCOM_FAX.Size = new System.Drawing.Size(127, 20);
            this.txtCOM_FAX.TabIndex = 9;
            this.txtCOM_FAX.Tag = "COM_FAX";
            // 
            // txtCOM_TELEFONO
            // 
            this.txtCOM_TELEFONO.Location = new System.Drawing.Point(88, 224);
            this.txtCOM_TELEFONO.Name = "txtCOM_TELEFONO";
            this.txtCOM_TELEFONO.Size = new System.Drawing.Size(127, 20);
            this.txtCOM_TELEFONO.TabIndex = 8;
            this.txtCOM_TELEFONO.Tag = "COM_TELEFONO";
            // 
            // txtCOM_DIRECCION
            // 
            this.txtCOM_DIRECCION.Location = new System.Drawing.Point(88, 190);
            this.txtCOM_DIRECCION.Name = "txtCOM_DIRECCION";
            this.txtCOM_DIRECCION.Size = new System.Drawing.Size(305, 20);
            this.txtCOM_DIRECCION.TabIndex = 7;
            this.txtCOM_DIRECCION.Tag = "COM_DIRECCION";
            // 
            // txtCOM_RESPONSABLE
            // 
            this.txtCOM_RESPONSABLE.Location = new System.Drawing.Point(88, 158);
            this.txtCOM_RESPONSABLE.Name = "txtCOM_RESPONSABLE";
            this.txtCOM_RESPONSABLE.Size = new System.Drawing.Size(305, 20);
            this.txtCOM_RESPONSABLE.TabIndex = 6;
            this.txtCOM_RESPONSABLE.Tag = "COM_RESPONSABLE";
            // 
            // txtCOM_RNC
            // 
            this.txtCOM_RNC.Location = new System.Drawing.Point(88, 125);
            this.txtCOM_RNC.Name = "txtCOM_RNC";
            this.txtCOM_RNC.Size = new System.Drawing.Size(100, 20);
            this.txtCOM_RNC.TabIndex = 5;
            this.txtCOM_RNC.Tag = "COM_RNC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "RNC:";
            // 
            // txtCOM_DESCRIPCION
            // 
            this.txtCOM_DESCRIPCION.Location = new System.Drawing.Point(88, 91);
            this.txtCOM_DESCRIPCION.Name = "txtCOM_DESCRIPCION";
            this.txtCOM_DESCRIPCION.Size = new System.Drawing.Size(261, 20);
            this.txtCOM_DESCRIPCION.TabIndex = 3;
            this.txtCOM_DESCRIPCION.Tag = "COM_DESCRIPCION";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(13, 91);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(63, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Descripción";
            // 
            // textCom_Codigo
            // 
            this.textCom_Codigo.Enabled = false;
            this.textCom_Codigo.Location = new System.Drawing.Point(88, 27);
            this.textCom_Codigo.Name = "textCom_Codigo";
            this.textCom_Codigo.Size = new System.Drawing.Size(100, 20);
            this.textCom_Codigo.TabIndex = 1;
            this.textCom_Codigo.Tag = "COM_CODIGO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // frmEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 426);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmEmpresa";
            this.Text = "Empresas";
            this.Load += new System.EventHandler(this.frmEmpresa_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabMant.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabMant;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.TabPage tabPage2;
        private usrbntMant usrbntMant1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCOM_EMAIL;
        private System.Windows.Forms.TextBox txtCOM_FAX;
        private System.Windows.Forms.TextBox txtCOM_TELEFONO;
        private System.Windows.Forms.TextBox txtCOM_DIRECCION;
        private System.Windows.Forms.TextBox txtCOM_RESPONSABLE;
        private System.Windows.Forms.TextBox txtCOM_RNC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCOM_DESCRIPCION;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox textCom_Codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreCorto;
        private System.Windows.Forms.Label label8;
    }
}