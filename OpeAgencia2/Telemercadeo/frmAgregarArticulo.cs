using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpeAgencia2.Telemercadeo
{
    public partial class frmAgregarArticulo : Form
    {
        public frmAgregarArticulo()
        {
            InitializeComponent();
        }

        public string Articulo { set; get; }
        public string Descripcion { set; get; }
        public int  Cantidad { set; get; }
        public decimal Valor { set; get; }
        public decimal Total { set; get; }

        
        private void frmAgregarArticulo_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtArticulo.Text == "")
            {
                MessageBox.Show("Debe registrar el articulo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if  (txtDescripcion.Text == "")
            {
                MessageBox.Show("Debe registrar la descripcion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if (txtCantidad.Value == 0)
            {
                MessageBox.Show("Debe registrar la cantidad, mayor que 0 ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if (txtValor.DecimalValue == 0)
            {
                MessageBox.Show("Debe registrar el valor, mayor que 0 ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            Articulo = txtArticulo.Text;
            Descripcion = txtDescripcion.Text;
            Cantidad = Convert.ToInt32(txtCantidad.Value);
            Valor = txtValor.DecimalValue;
            Total = Valor * Cantidad;

            this.Close();

        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            TxtTotal.DecimalValue = txtCantidad.Value * txtValor.DecimalValue;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
