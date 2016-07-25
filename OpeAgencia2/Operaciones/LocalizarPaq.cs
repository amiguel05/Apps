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
    public partial class LocalizarPaq : Form
    {
        public LocalizarPaq()
        {
            InitializeComponent();
        }
        int iBltNumero = -1;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private void textBox1_Leave(object sender, EventArgs e)
        {
            BuscarCodigoBarra();
        }
        // 1 == Recepcionado.
        BO.Models.Bultos oBultos;
        void BuscarCodigoBarra()
        {
            int iEstadoOrigen = 0;
            int iEstadoDestino = 0;
            if (cmbEstado.SelectedIndex == 0){
                iEstadoOrigen = 1;
                iEstadoDestino = 2;
            }
            else
            {
                iEstadoOrigen = 2;
                iEstadoDestino = 6;
            }
            oBultos = unitOfWork.BultosRepository.Get(filter: xy => xy.BLT_CODIGO_BARRA == txtCodigoBarra.Text).FirstOrDefault();
            if (oBultos != null)
            {
                if (oBultos.BLT_ESTADO_ID == 5)
                {
                    MessageBox.Show("Este paquete ya fué entregado al cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    iBltNumero = -1;
                    return;
                }
               iBltNumero = oBultos.BLT_NUMERO;
            }
            else
            {
                MessageBox.Show("No existe paquete para la operación solicitada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                iBltNumero = -1;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int iEstadoOrigen = 0;
            int iEstadoDestino = 0;

            if (cmbEstado.SelectedIndex == 0)
            {
                iEstadoOrigen = 1;
                iEstadoDestino = 2;
            }
            else
            {
                iEstadoOrigen = 2;
                iEstadoDestino = 6;
            }
            if (iBltNumero == -1)
                return;
            oBultos = unitOfWork.BultosRepository.GetByID(iBltNumero);
            if (oBultos != null)
            {
                oBultos.BLT_ESTADO_ID = iEstadoDestino;
                unitOfWork.BultosRepository.Update(oBultos);
                unitOfWork.Save();
                MessageBox.Show("Operación realizada con exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No existe paquete para la operación solicitada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void LocalizarPaq_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
        }
    }
}
