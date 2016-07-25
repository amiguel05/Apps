using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BO = AgenciaEF_BO;


namespace OpeAgencia2.Precios
{
    public partial class frmCargarTarifaCourier : Form
    {
        public frmCargarTarifaCourier()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        public frmCargarTarifaCourier(int pId)
        {
            InitializeComponent();

            _Id = pId;

        }


        int _Id;
        int _EnvioId;
        private void frmCargarTarifaCourier_Load(object sender, EventArgs e)
        {

            var p = unitOfWork.EnviosRepository.Get(filter: s => s.PROD_ID == _Id).FirstOrDefault();
            _EnvioId = p.ENV_ID;

        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            opfd.ShowDialog();
            txtPath.Text = opfd.FileName;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            BorrarDatos();
            CargarDatos();
        }

        void BorrarDatos()
        {

            var oTarifas = unitOfWork.TarifaEnvioRepository.Get(filter: s => s.ENV_ID == _EnvioId);

            foreach(var r in oTarifas)
            {
                unitOfWork.TarifaEnvioRepository.Delete(r);
            }
            unitOfWork.Save();

        }



        private void CargarDatos()
        {

            StreamReader sr = new StreamReader(txtPath.Text);
            string sLinea;

            string[] aLineas;
            sLinea = sr.ReadLine();

            while (sr.EndOfStream == false)
            {
                sLinea = sr.ReadLine();
                
                if (sLinea == null)
                    break;

              
             
                aLineas = sLinea.Split(',');

                BO.Models.TarifaEnvio oEnv = new BO.Models.TarifaEnvio();
                oEnv.ENV_ID = _EnvioId;
                oEnv.PESO = Convert.ToInt32(aLineas[0].ToString());
                oEnv.ENV_ID = _EnvioId;
                oEnv.A = Convert.ToDecimal(aLineas[1].ToString());
                oEnv.B = Convert.ToDecimal(aLineas[2].ToString());

                oEnv.C = Convert.ToDecimal(aLineas[3].ToString());

                oEnv.D = Convert.ToDecimal(aLineas[4].ToString());

                oEnv.E = Convert.ToDecimal(aLineas[5].ToString());

                oEnv.F = Convert.ToDecimal(aLineas[6].ToString());

                oEnv.G = Convert.ToDecimal(aLineas[7].ToString());

                oEnv.H = Convert.ToDecimal(aLineas[8].ToString());

                unitOfWork.TarifaEnvioRepository.Insert(oEnv);

            }
            sr.Close();
            unitOfWork.Save();
            MessageBox.Show("Proceso ejecutado con exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        

    }
}
