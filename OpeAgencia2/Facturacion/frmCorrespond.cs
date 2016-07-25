using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpeAgencia2.Facturacion
{
    public partial class frmCorrespond : Form
    {
        public frmCorrespond()
        {
            InitializeComponent();
        }


        int iPiezas = 0;
        int iPiezasCatalogo;

        decimal dPeso = 0;
        decimal dPesoCatalogos = 0;



        public int Piezas
        {
            get { return iPiezas; }
         }

        public int PiezasCatalgo
        {
            get { return iPiezasCatalogo; }
        }


        public decimal Peso
        {
            get { return dPeso; }
        }

        public decimal PesoCatalogo
        {
            get { return dPesoCatalogos; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            iPiezas = txtPiezaNormal.IntValue;
            iPiezasCatalogo = txtPiezaCat.IntValue;
            //
            dPeso = txtPesoCorr.DecimalValue;
            dPesoCatalogos = txtPesoCat.DecimalValue;

            this.Close();

        }

    }
}
