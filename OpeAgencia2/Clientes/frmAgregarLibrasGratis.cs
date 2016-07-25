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
    public partial class frmAgregarLibrasGratis : Form
    {

        int liCteId;
        string lsCteNombre;
        string lsEPS;


        public frmAgregarLibrasGratis()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();


        public frmAgregarLibrasGratis(int piCteId, string psCteNombre, string psEps)
        {
            InitializeComponent();
            liCteId = piCteId;
            lsCteNombre = psCteNombre;
            lsEPS = psEps;

            LlenarCombo();

            cmbProducto.SelectedIndex = 0;
        }

        private void frmAgregarLibrasGratis_Load(object sender, EventArgs e)
        {
            txtEPS.Text = lsEPS;
            lblEps.Text = lsCteNombre;
            LlenarCombo();

        }


        void LlenarCombo()
        {
            var Productos = from p in unitOfWork.ProductosRepository.Get(filter: xy => xy.Tipos.TIPO_CODIGO == "R")
                            select new { Id = p.PROD_ID, Nombre = p.PRO_CODIGO + "-->" + p.PRO_DESCRIPCION };
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";
            this.cmbProducto.DataSource = Productos.ToList();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            BO.Models.RegistroLibrasGratis oLibras = new BO.Models.RegistroLibrasGratis();

            oLibras.CTE_ID = liCteId;
            oLibras.FECHA = DateTime.Now;
            oLibras.LIBRAS_GRATIS = txtMontoAplicar.IntValue;
            oLibras.PROD_ID = Convert.ToInt32(cmbProducto.SelectedValue);
            oLibras.USUARIO_ID = Parametros.Parametros.UsuarioId;
            
            try
            {
                unitOfWork.RegistroLibrasGratisRepository.Insert(oLibras);

                var oLibrasGratis = unitOfWork.LibrasGratisRepository.Get(filter: xy => xy.CTE_ID == liCteId && xy.PROD_ID == oLibras.PROD_ID).FirstOrDefault();

                if (oLibrasGratis ==null)
                {
                    BO.Models.LibrasGratis oGratis = new BO.Models.LibrasGratis();

                    oGratis.CTE_ID = liCteId;
                    oGratis.FECHA_ULT_ASIGNACION = DateTime.Now;
                    oGratis.LIBRAS_GRATIS = oLibras.LIBRAS_GRATIS;
                    oGratis.PROD_ID = oLibras.PROD_ID;
                    oGratis.USUARIO_ID = Parametros.Parametros.UsuarioId;
                    unitOfWork.LibrasGratisRepository.Insert(oGratis);
                }
                else
                {
                    oLibrasGratis.LIBRAS_GRATIS = oLibrasGratis.LIBRAS_GRATIS + oLibras.LIBRAS_GRATIS;
                    oLibrasGratis.USUARIO_ID = Parametros.Parametros.UsuarioId;
                    oLibrasGratis.FECHA_ULT_ASIGNACION = DateTime.Now;
                    unitOfWork.LibrasGratisRepository.Update(oLibrasGratis);


                }


                unitOfWork.Save();
                this.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }




        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
