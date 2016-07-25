using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpeAgencia2
{
    public partial class usrbntMant : UserControl
    {
        public usrbntMant()
        {
            InitializeComponent();
        }

        public bool bExito { set; get; }
        public bool bAdiciona { set; get; }
        public event EventHandler ButtonClickAdd;
        public event EventHandler ButtonClickMod;
        public event EventHandler ButtonClickSave;
        public event EventHandler ButtonClickDel;
        public event EventHandler ButtonClickUndo;
        public event EventHandler ButtonClickSalir;

        #region "Botones"
      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(ButtonClickAdd != null)
                 this.ButtonClickAdd(this, e);
            bAdiciona = true;
            ModoEdicion();
        }
        private void btnMod_Click(object sender, EventArgs e)
        {
            if (ButtonClickMod != null)
                this.ButtonClickMod(this, e);

            bAdiciona = false ; 
            ModoEdicion();
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (ButtonClickDel != null)
                this.ButtonClickDel(this, e);
            bAdiciona = false; 
            ModoConsulta();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ButtonClickSave != null)
                this.ButtonClickSave(this, e);
            if (bExito == true)
            {
                ModoConsulta();
                bAdiciona = false; 
            }

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (ButtonClickUndo != null)
                this.ButtonClickUndo(this, e);

            ModoConsulta();
            bAdiciona = false; 
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (ButtonClickSalir != null)
                this.ButtonClickSalir(this, e);

          
        }


        private void ModoEdicion()
        {
            btnMod.Enabled = false;
            this.btnSave.Enabled = true;
            this.btnUndo.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnDel.Enabled = true;
            if (bAdiciona == true)
                this.btnDel.Enabled = false;
      
        }
        private void ModoConsulta()
        {
            btnMod.Enabled = true;
            this.btnSave.Enabled = false;
            this.btnUndo.Enabled = false;
            this.btnAdd.Enabled = true;
            this.btnDel.Enabled = false;

        }
        #endregion



    }
}
