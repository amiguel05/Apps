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

namespace OpeAgencia2.Creditos
{
    public partial class frmCredito : Form
    {
        public frmCredito()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        private void txtEPS_Leave(object sender, EventArgs e)
        {
            if (txtEPS.Text != "")
                BuscarCliente();
        }

        void BuscarCliente()
        {
            oCliente = unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtEPS.Text && s.CTE_SUC_ID == Parametros.Parametros.SucursalActual).FirstOrDefault();
            if (oCliente != null)
            {
                lblNombres.Text = oCliente.CTE_NOMBRE + " " + oCliente.CTE_APELLIDO;
                chkCredito.Checked = oCliente.CTE_CREDITO;
                txtDiasCredito.Value = oCliente.CTE_DIAS_CREDITOS;
                textCTE_LIMITE_CREDITO.DecimalValue = oCliente.CTE_LIMITE_CREDITO;
                TextCTE_BALANCE.DecimalValue = oCliente.CTE_BALANCE_DISPONIBLE;
            }
            else
            {
                MessageBox.Show("No existe EPS", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtEPS.Text = "";
                txtEPS.Focus();
                lblNombres.Text = "";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool bModificacion = false;
            if (MessageBox.Show("Desea actualizar los datos", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                if (oCliente.CTE_CREDITO != chkCredito.Checked)
                {
                    oCliente.CTE_CREDITO = chkCredito.Checked;
                    bModificacion = true;
                }
                if (oCliente.CTE_LIMITE_CREDITO != textCTE_LIMITE_CREDITO.DecimalValue)
                {
                    decimal dDif = 0;
                    dDif = (textCTE_LIMITE_CREDITO.DecimalValue - oCliente.CTE_LIMITE_CREDITO);
                    bModificacion = true;
                    if (oCliente.CTE_BALANCE_DISPONIBLE == 0)
                        oCliente.CTE_BALANCE_DISPONIBLE = textCTE_LIMITE_CREDITO.DecimalValue;
                    else
                    {
                        oCliente.CTE_BALANCE_DISPONIBLE = oCliente.CTE_BALANCE_DISPONIBLE + dDif;
                    }
                    oCliente.CTE_LIMITE_CREDITO = textCTE_LIMITE_CREDITO.DecimalValue;
                }
                if (oCliente.CTE_DIAS_CREDITOS != txtDiasCredito.Value)
                {
                    oCliente.CTE_DIAS_CREDITOS = txtDiasCredito.Value;
                    bModificacion = true;
                }
                if (bModificacion == false)
                    return;
                unitOfWork.ClientesRepository.Update(oCliente);
                try
                {
                    unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtEPS.Text != "" && e.KeyCode == Keys.Enter)
                BuscarCliente();
        }
    }
}
