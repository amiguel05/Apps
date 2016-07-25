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

namespace OpeAgencia2.Operaciones
{
    public partial class frmRecepCorrep : Form
    {
        public frmRecepCorrep()
        {
            InitializeComponent();
        }

        int iNumeroEPS = -1;

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void txtNumeroEPS_Leave(object sender, EventArgs e)
        {
            var Eps = unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtNumeroEPS.Text).FirstOrDefault();
            if (Eps != null)
            {
                lblEps.Text = Eps.CTE_NOMBRE.ToString() + " " + Eps.CTE_APELLIDO;
                iNumeroEPS = Eps.CTE_ID;
               // iSucursalId = Eps.CTE_SUC_ID;
            }
            else
            {
                lblEps.Text = "";
                iNumeroEPS = -1;
               // iSucursalId = -1;
                return;
            }
            if (Eps.CTE_SUC_ID != Parametros.Parametros.SucursalActual)
            {
                MessageBox.Show("No puede registrar correspondencia para este cliente, debe ingresar con la sucursal del cliente ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                Cancelar();
                return;
            }
        }

        void  Cancelar()
        {
            txtNumeroEPS.Text = "";
            txtPesoCorr.IntValue = 0;
            txtPiezaNormal.IntValue = 0;
            lblEps.Text = "";
            txtNumeroEPS.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPesoCorr.DecimalValue <= 0)
            {
                MessageBox.Show("Debe registrar el peso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

             if (txtPiezaNormal.IntValue <= 0)
            {
                MessageBox.Show("Debe registrar el número de piezas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //
            try
            {
                BO.Models.Correspondencia oCorre = new BO.Models.Correspondencia();
                oCorre.CTE_ID = iNumeroEPS;
                oCorre.FECHA = DateTime.Now;
                oCorre.PESO = txtPesoCorr.DecimalValue;
                oCorre.PIEZAS = txtPiezaNormal.IntValue;
                oCorre.USER_ID = Parametros.Parametros.UsuarioId;
                unitOfWork.CorrespondenciaRepository.Insert(oCorre);
                CambiarMensajeCorrespondencia(true);
                Cancelar();
                MessageBox.Show("Correspondencia registrada correctamente", "Correspondencia registrada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        public void CambiarMensajeCorrespondencia(bool activado)
        {
            var oclientes = unitOfWork.ClientesRepository.GetByID(iNumeroEPS);
            if (oclientes == null)
            {
                MessageBox.Show("Debe especificar un cliente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumeroEPS.Focus();
                return;
            }
            oclientes.CTE_CORRESPONDENCIA = activado;
            unitOfWork.ClientesRepository.Update(oclientes);
            unitOfWork.Save();
        }

        private void btnPonerMensaje_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarMensajeCorrespondencia(true);
                MessageBox.Show("Mensaje activado correctamente", "Mensaje activado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnQuitarMensaje_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarMensajeCorrespondencia(false);
                MessageBox.Show("Mensaje desactivado correctamente", "Mensaje desactivado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtNumeroEPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || txtNumeroEPS.Text == string.Empty)
                return;
            var Eps = unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtNumeroEPS.Text).FirstOrDefault();
            if (Eps != null)
            {
                lblEps.Text = Eps.CTE_NOMBRE.ToString() + " " + Eps.CTE_APELLIDO;
                iNumeroEPS = Eps.CTE_ID;
                // iSucursalId = Eps.CTE_SUC_ID;
            }
            else
            {
                lblEps.Text = "";
                iNumeroEPS = -1;
                // iSucursalId = -1;
                return;
            }
            if (Eps.CTE_SUC_ID != Parametros.Parametros.SucursalActual)
            {
                MessageBox.Show("No puede registrar correspondencia para este cliente, debe ingresar con la sucursal del mismo ", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                Cancelar();
                return;
            }
            txtPiezaNormal.Focus();
        }
    }
}
