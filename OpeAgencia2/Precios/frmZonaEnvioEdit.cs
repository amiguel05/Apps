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

namespace OpeAgencia2.Precios
{
    public partial class frmZonaEnvioEdit : Form
    {
        public frmZonaEnvioEdit()
        {
            InitializeComponent();
        }

        int iProdId = -1;
        int iId = -1;

        public frmZonaEnvioEdit(int piProdId, int piId)
        {
            InitializeComponent();

            iProdId = piProdId;
            iId = piId;
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmZonaEnvioEdit_Load(object sender, EventArgs e)
        {
            CargarCombos();

            cmbProducto.SelectedValue = iProdId;

            if (iId !=  -1)
            {
                BuscarDatosPorId(iId);
                cmbOrigen.Enabled = false;
            }
            else
            {
                cmbOrigen.Enabled = true;
            }
        }



        void CargarCombos()
        {
            CargarProductos();
            CargarOrigen();

        }

        void CargarProductos()
        {
            var Productos = from p in unitOfWork.ProductosRepository.Get(filter: s => s.PRO_TIPO_ID == 32)
                            select new { Id = p.PROD_ID, Nombre = p.PRO_CODIGO + " " + p.PRO_DESCRIPCION };


            cmbProducto.DataSource = Productos.ToList();
            cmbProducto.ValueMember = "Id";
            cmbProducto.DisplayMember = "Nombre";
        }



        void CargarOrigen()
        {
            var grupos = from p in unitOfWork.OrigenRepository.Get()
                         select new { Id = p.ORI_ID, Nombre = p.ORI_CODIGO + "-" + p.ORI_DESCRIPCION };

            
           if (iId == -1)
           {
               var oExiste = from p in unitOfWork.TarifaEnvioZonaRepository.Get(filter: s => s.Envios.Productos.PROD_ID == iProdId)
                             select new { Id = p.Origen.ORI_ID, Nombre = p.Origen.ORI_CODIGO + "-" + p.Origen.ORI_DESCRIPCION };


               var grupo2 = grupos.Except(oExiste);

               cmbOrigen.DataSource = grupo2.ToList();
               cmbOrigen.ValueMember = "Id";
               cmbOrigen.DisplayMember = "Nombre";

           }
           else
           {
               cmbOrigen.DataSource = grupos.ToList();
               cmbOrigen.ValueMember = "Id";
               cmbOrigen.DisplayMember = "Nombre";
           }




        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        void BuscarDatosPorId(int piId)
        {
            BO.Models.TarifaEnvioZona oZona = unitOfWork.TarifaEnvioZonaRepository.GetByID(piId);

            cmbOrigen.SelectedValue = oZona.ORI_ID;
            cmbZona.Text = oZona.ZONA;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (iId == -1)
            {
                var oEnv = unitOfWork.EnviosRepository.Get(filter: s => s.PROD_ID == iProdId).FirstOrDefault();

                BO.Models.TarifaEnvioZona oZona = new BO.Models.TarifaEnvioZona();

                oZona.ORI_ID = Convert.ToInt32(cmbOrigen.SelectedValue);

                oZona.ENV_ID = oEnv.ENV_ID;

                oZona.ZONA = cmbZona.Text;


                unitOfWork.TarifaEnvioZonaRepository.Insert(oZona);

               
            }
            else
            {
                BO.Models.TarifaEnvioZona oZona = unitOfWork.TarifaEnvioZonaRepository.GetByID(iId);

                oZona.ZONA = cmbZona.Text;

                unitOfWork.TarifaEnvioZonaRepository.Update(oZona);

            }

            try
            {
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;

            }
           


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
