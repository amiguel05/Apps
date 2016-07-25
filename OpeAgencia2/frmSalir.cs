using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpeAgencia2
{
    public partial class frmSalir : Form
    {
        public frmSalir()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void frmSalir_Load(object sender, EventArgs e)
        {
           ((Form1)this.MdiParent).IndicadorCerrar = true;
          
        }
    }
}
