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

namespace OpeAgencia2.Clientes
{
    public partial class frmTarEspValores : Form
    {
        public frmTarEspValores()
        {
            InitializeComponent();
        }

        public frmTarEspValores(int piTarEspId, string psEps)
        {
            InitializeComponent();

            liTarEspId = piTarEspId;
            lsEps = psEps;

        }

        int liTarEspId = -1;
        string lsEps = "";
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();


        AgenciaEF_BO.DAL.dsDatos.TARESP_VALDataTable oTable = new AgenciaEF_BO.DAL.dsDatos.TARESP_VALDataTable();


        private void frmTarEspValores_Load(object sender, EventArgs e)
        {
            CargarDatos();
            lblEps.Text = lsEps;

        }


        void CargarDatos()
        {

            var oTablaVal = unitOfWork.TarifasEspecialesValoresRepository.Get(filter: xy=>xy.TAR_ESP_ID== liTarEspId);
            
             foreach(var oVar in oTablaVal)
             {
                 BO.DAL.dsDatos.TARESP_VALRow oRow = oTable.NewTARESP_VALRow();

                 oRow.ID = oVar.ID;
                 oRow.VAL_HASTA = oVar.VAL_HASTA;
                 oRow.VAL_ADICIONAL = oVar.VAL_ADICIONAL;
                 oRow.VAL_PORCENTAJE = oVar.VAL_PORCENTAJE;
                 oRow.VAL_VALOR = oVar.VAL_VALOR;
                 
                 oTable.Rows.Add(oRow);


             }


            dataGridView1.DataSource = oTable;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oTable.AcceptChanges();
            BorrarDatos();
            Guardar();
        }

        void BorrarDatos()
        {

            var oTablaVal = unitOfWork.TarifasEspecialesValoresRepository.Get(filter: xy => xy.TAR_ESP_ID == liTarEspId);

            foreach (var oVar in oTablaVal)
            {
                unitOfWork.TarifasEspecialesValoresRepository.Delete(oVar);

            }

            unitOfWork.Save();
        }


        void Guardar()
        {
            foreach(BO.DAL.dsDatos.TARESP_VALRow oRow  in oTable.Rows)
            {
                BO.Models.TarifasEspecialesValores oVal = new BO.Models.TarifasEspecialesValores();

                oVal.TAR_ESP_ID = liTarEspId;
                oVal.VAL_HASTA = oRow.VAL_HASTA;
                oVal.VAL_PORCENTAJE = oRow.VAL_PORCENTAJE;
                oVal.VAL_VALOR = oRow.VAL_VALOR;
                oVal.VAL_ADICIONAL = oRow.VAL_ADICIONAL;

                unitOfWork.TarifasEspecialesValoresRepository.Insert(oVal);


            }

            unitOfWork.Save();

            MessageBox.Show("Valores guardados exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
