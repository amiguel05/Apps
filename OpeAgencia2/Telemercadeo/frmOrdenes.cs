using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BO = AgenciaEF_BO;

namespace OpeAgencia2.Telemercadeo
{
    public partial class frmOrdenes : Form
    {
        public frmOrdenes()
        {
            InitializeComponent();
        }
        private void frmOrdenes_Load(object sender, EventArgs e)
        {
            LlenarCombos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        int iCteId = -1;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarOrdenes frm = new frmAgregarOrdenes();
            frm.ShowDialog();

        }

        void LlenarCombos()
        {

            var oEstado = unitOfWork.EstadosRepository.GetByGroupCode("EOC");
            
            cmbEstado.DisplayMember = "ESTADO_NOMBRE";
            cmbEstado.ValueMember = "ESTADO_ID";

            cmbEstado.DataSource = oEstado.ToList();

        }

        private void chkDesde_CheckedChanged(object sender, EventArgs e)
        {
            FechaIni.Enabled = chkDesde.Checked;
        }

        private void chkHasta_CheckedChanged(object sender, EventArgs e)
        {
            FechaFin.Enabled = chkHasta.Checked;
        }


        void BuscarCliente()
        {
            if (txtEPS.Text == "")
            {
                lblEps.Text = string.Empty;
                iCteId = -1;
                return;
            }
            var oCliente = unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtEPS.Text && s.CTE_SUC_ID == Parametros.Parametros.SucursalActual).FirstOrDefault();
            if (oCliente != null)
            {
                lblEps.Text = oCliente.CTE_NOMBRE + " " + oCliente.CTE_APELLIDO;
          
                iCteId = oCliente.CTE_ID;
            }
            else
            {
                MessageBox.Show("No existe EPS", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtEPS.Text = "";
                txtEPS.Focus();
                iCteId = -1;
                lblEps.Text = "";
            
            }

        }

        private void txtEPS_Leave(object sender, EventArgs e)
        {
            BuscarCliente();
        }

       
    }
}
