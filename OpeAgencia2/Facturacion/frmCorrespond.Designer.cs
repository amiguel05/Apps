namespace OpeAgencia2.Facturacion
{
    partial class frmCorrespond
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
            this.txtPesoCat = new clsUtils.NumericTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPiezaCat = new clsUtils.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPesoCorr = new clsUtils.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPiezaNormal = new clsUtils.NumericTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPesoCat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPiezaCat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPesoCorr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPiezaNormal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnCancelar);
            this.groupBox1.Controls.Add(this.btnAceptar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtPesoCat
            // 
            this.txtPesoCat.AllowSpace = false;
            this.txtPesoCat.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPesoCat.IntValue = 0;
            this.txtPesoCat.Location = new System.Drawing.Point(239, 46);
            this.txtPesoCat.Name = "txtPesoCat";
            this.txtPesoCat.Size = new System.Drawing.Size(47, 21);
            this.txtPesoCat.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Peso Catálogo:";
            // 
            // txtPiezaCat
            // 
            this.txtPiezaCat.AllowSpace = false;
            this.txtPiezaCat.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPiezaCat.IntValue = 0;
            this.txtPiezaCat.Location = new System.Drawing.Point(98, 46);
            this.txtPiezaCat.Name = "txtPiezaCat";
            this.txtPiezaCat.Size = new System.Drawing.Size(47, 21);
            this.txtPiezaCat.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Piezas catálogo:";
            // 
            // txtPesoCorr
            // 
            this.txtPesoCorr.AllowSpace = false;
            this.txtPesoCorr.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPesoCorr.IntValue = 0;
            this.txtPesoCorr.Location = new System.Drawing.Point(239, 19);
            this.txtPesoCorr.Name = "txtPesoCorr";
            this.txtPesoCorr.Size = new System.Drawing.Size(47, 21);
            this.txtPesoCorr.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Peso Normal:";
            // 
            // txtPiezaNormal
            // 
            this.txtPiezaNormal.AllowSpace = false;
            this.txtPiezaNormal.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPiezaNormal.IntValue = 0;
            this.txtPiezaNormal.Location = new System.Drawing.Point(98, 19);
            this.txtPiezaNormal.Name = "txtPiezaNormal";
            this.txtPiezaNormal.Size = new System.Drawing.Size(47, 21);
            this.txtPiezaNormal.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Piezas Normal:";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.Location = new System.Drawing.Point(156, 99);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelar.TabIndex = 1;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(70, 99);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmCorrespond
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(300, 131);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCorrespond";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digitación de correspondencia";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private clsUtils.NumericTextBox txtPiezaNormal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private clsUtils.NumericTextBox txtPesoCat;
        private System.Windows.Forms.Label label3;
        private clsUtils.NumericTextBox txtPiezaCat;
        private System.Windows.Forms.Label label4;
        private clsUtils.NumericTextBox txtPesoCorr;
        private System.Windows.Forms.Label label2;
    }
}