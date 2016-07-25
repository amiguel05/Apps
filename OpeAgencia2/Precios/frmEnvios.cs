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

    public partial class frmEnvios : Form
    {
        int _Id;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        public frmEnvios()
        {
            InitializeComponent();
        }

        private void frmEnvios_Load(object sender, EventArgs e)
        {
            CargarProductos();
           
        }


        void CargarProductos()
        {

            var Productos = from p in unitOfWork.ProductosRepository.Get(filter: s => s.PRO_TIPO_ID == 32)
                            select new { Id = p.PROD_ID, Codigo = p.PRO_CODIGO, Nombre = p.PRO_DESCRIPCION, Estado = p.PRO_ESTADO };


            dgEnvios.DataSource = Productos.ToList();

        }

        void BuscaInfEnvio()
        {
            if (_Id != -1)
            {
                BO.Models.Envios oEnv = unitOfWork.EnviosRepository.Get(filter: s => s.PROD_ID == _Id).FirstOrDefault();
              
                if (oEnv != null)
                {
                    txtMinimo.Value =oEnv.PESO_MIN;
                    txtMaximo.Value = oEnv.PESO_MAX;
                }

            }

        }

        void BuscaTarifa()
        {
            if (_Id != -1)
            {
                BO.Models.Envios oEnv = unitOfWork.EnviosRepository.Get(filter: s => s.PROD_ID == _Id).FirstOrDefault();

                if (oEnv != null)
                {
                    var q = from p in unitOfWork.TarifaEnvioRepository.Get(filter: s => s.ENV_ID == oEnv.ENV_ID)
                            select new { p.PESO,p.A,p.B,p.C,p.D, p.E, p.F,p.G,p.H};
                    
                    dgTarifas.DataSource = q.ToList();
                   
                }

            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                try
                {
                    _Id = Convert.ToInt32(dgEnvios.CurrentRow.Cells[0].Value);

                    lblProducto.Text = dgEnvios.CurrentRow.Cells[2].Value.ToString();
                }
                catch
                {
                    _Id = -1;
                }
                BuscaInfEnvio();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    _Id = Convert.ToInt32(dgEnvios.CurrentRow.Cells[0].Value);

                    lblProducto.Text = dgEnvios.CurrentRow.Cells[2].Value.ToString();
                }
                catch
                {
                    _Id = -1;
                }
                BuscaTarifa();

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            BO.Models.Envios oEnv = unitOfWork.EnviosRepository.Get(filter: s => s.PROD_ID == _Id).FirstOrDefault();

            if (oEnv != null)
            {
                oEnv.PESO_MIN = txtMinimo.Value;
                oEnv.PESO_MAX = txtMaximo.Value;
                unitOfWork.EnviosRepository.Update(oEnv);
            }
            else
            {
                oEnv = new BO.Models.Envios();

                oEnv.PROD_ID = _Id;
                oEnv.PESO_MIN = oEnv.PESO_MIN;
                oEnv.PESO_MAX = oEnv.PESO_MAX;

                unitOfWork.EnviosRepository.Insert(oEnv);
            }


            try
            {
                unitOfWork.Save();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btnCargarTarifas_Click(object sender, EventArgs e)
        {
            frmCargarTarifaCourier x = new frmCargarTarifaCourier(_Id);
            x.ShowDialog();
        }
    }
}
