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
    public partial class frmRecalcularTarifas : Form
    {
        public frmRecalcularTarifas()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        int iCteId = -1;


        private void txtNumeroEps_Leave(object sender, EventArgs e)
        {
            var eps = unitOfWork.ClientesRepository.Get(filter: xy => xy.CTE_NUMERO_EPS == txtNumeroEps.Text).FirstOrDefault();

            if (eps != null)
            {
                iCteId = eps.CTE_ID;
                lblNombres.Text = eps.CTE_NOMBRE.ToString() + " " + eps.CTE_APELLIDO.ToString();
            }
            else
            {
                iCteId = -1;
                lblNombres.Text = "";

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //estado id 2 inventario
            // 31 recepcion
            var oBultos = unitOfWork.BultosRepository.Get(filter: xy => xy.CTE_ID == iCteId && xy.BLT_ESTADO_ID == 2 && xy.Productos.PRO_TIPO_ID == 31);

            foreach(var oBulto in oBultos )
            {

                AgenciaEF_BO.DAL.ADO.BultosDal Bultos = new BO.DAL.ADO.BultosDal();

                Bultos.RecalcularUnidades(oBulto.BLT_NUMERO);
                //Bultos.RecalcularItebis(oBulto.BLT_NUMERO);
                BO.BO.Facturar oFact = new BO.BO.Facturar();
                oFact.ActualizarItbis(oBulto.BLT_NUMERO);
                

            }

            MessageBox.Show("Proceso ejecutado exitosamente","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
