namespace OpeAgencia2.Creditos
{
    partial class frmCredito
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
            this.lblNombres = new System.Windows.Forms.Label();
            this.txtEPS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.TextCTE_BALANCE = new clsUtils.NumericTextBox();
            this.textCTE_LIMITE_CREDITO = new clsUtils.NumericTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtDiasCredito = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.chkCredito = new System.Windows.Forms.CheckBox();
            this.label37 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiasCredito)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNombres);
            this.groupBox1.Controls.Add(this.txtEPS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkCredito);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(153, 22);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(55, 13);
            this.lblNombres.TabIndex = 5;
            this.lblNombres.Text = "[Nombres]";
            // 
            // txtEPS
            // 
            this.txtEPS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEPS.Location = new System.Drawing.Point(47, 19);
            this.txtEPS.Name = "txtEPS";
            this.txtEPS.Size = new System.Drawing.Size(100, 20);
            this.txtEPS.TabIndex = 4;
            this.txtEPS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEPS_KeyDown);
            this.txtEPS.Leave += new System.EventHandler(this.txtEPS_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "EPS:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.TextCTE_BALANCE);
            this.groupBox6.Controls.Add(this.textCTE_LIMITE_CREDITO);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.txtDiasCredito);
            this.groupBox6.Controls.Add(this.label30);
            this.groupBox6.Controls.Add(this.label37);
            this.groupBox6.Location = new System.Drawing.Point(12, 61);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(305, 101);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Crédito";
            // 
            // TextCTE_BALANCE
            // 
            this.TextCTE_BALANCE.AllowSpace = false;
            this.TextCTE_BALANCE.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TextCTE_BALANCE.IntValue = 0;
            this.TextCTE_BALANCE.Location = new System.Drawing.Point(114, 67);
            this.TextCTE_BALANCE.Name = "TextCTE_BALANCE";
            this.TextCTE_BALANCE.Size = new System.Drawing.Size(172, 21);
            this.TextCTE_BALANCE.TabIndex = 29;
            // 
            // textCTE_LIMITE_CREDITO
            // 
            this.textCTE_LIMITE_CREDITO.AllowSpace = false;
            this.textCTE_LIMITE_CREDITO.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.textCTE_LIMITE_CREDITO.IntValue = 0;
            this.textCTE_LIMITE_CREDITO.Location = new System.Drawing.Point(114, 40);
            this.textCTE_LIMITE_CREDITO.Name = "textCTE_LIMITE_CREDITO";
            this.textCTE_LIMITE_CREDITO.Size = new System.Drawing.Size(172, 21);
            this.textCTE_LIMITE_CREDITO.TabIndex = 28;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(13, 70);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(99, 13);
            this.label26.TabIndex = 25;
            this.label26.Text = "Balance disponible:";
            // 
            // txtDiasCredito
            // 
            this.txtDiasCredito.Location = new System.Drawing.Point(114, 14);
            this.txtDiasCredito.Name = "txtDiasCredito";
            this.txtDiasCredito.Size = new System.Drawing.Size(120, 20);
            this.txtDiasCredito.TabIndex = 1;
            this.txtDiasCredito.Tag = "CTE_DIAS_CREDITOS";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(44, 16);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(68, 13);
            this.label30.TabIndex = 27;
            this.label30.Text = "Días credito:";
            // 
            // chkCredito
            // 
            this.chkCredito.AutoSize = true;
            this.chkCredito.Location = new System.Drawing.Point(289, 21);
            this.chkCredito.Name = "chkCredito";
            this.chkCredito.Size = new System.Drawing.Size(114, 17);
            this.chkCredito.TabIndex = 0;
            this.chkCredito.Tag = "CTE_CREDITO";
            this.chkCredito.Text = "Cliente con crédito";
            this.chkCredito.UseVisualStyleBackColor = true;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(23, 43);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(89, 13);
            this.label37.TabIndex = 15;
            this.label37.Text = "Límite de crédito:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(349, 97);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 22;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(349, 126);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 172);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCredito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes con crédito";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiasCredito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.TextBox txtEPS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown txtDiasCredito;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.CheckBox chkCredito;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private clsUtils.NumericTextBox TextCTE_BALANCE;
        private clsUtils.NumericTextBox textCTE_LIMITE_CREDITO;
    }
}