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
    public partial class frmZonasEnvios : Form
    {
        public frmZonasEnvios()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        int iProdId;
        int iId = -1;

        private void frmZonasEnvios_Load(object sender, EventArgs e)
        {
            CargarCombos();
            BuscarDatosIniciales();

        }

        void BuscarDatosIniciales()
        {
            iProdId = Convert.ToInt32(cmbProducto.SelectedValue);
            var oQry = from p in unitOfWork.TarifaEnvioZonaRepository.Get(filter: s => s.Envios.Productos.PROD_ID == iProdId)
                       select new { Id = p.ID, Origen = p.Origen.ORI_CODIGO, Nombre = p.Origen.ORI_DESCRIPCION , Zona = p.ZONA };


            dgZonas.DataSource = oQry.ToList();

            dgZonas.Columns[0].Visible = false;



        }


        void CargarCombos()
        {

            var Productos = from p in unitOfWork.ProductosRepository.Get(filter: s => s.PRO_TIPO_ID == 32)
                            select new { Id = p.PROD_ID, Nombre = p.PRO_CODIGO +" "+ p.PRO_DESCRIPCION};

            cmbProducto.ValueMember = "Id";
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.DataSource = Productos.ToList();
           


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            iProdId = Convert.ToInt32(cmbProducto.SelectedValue);


            frmZonaEnvioEdit x = new frmZonaEnvioEdit(iProdId, -1);
            x.ShowDialog();

            BuscarDatosIniciales();
        }

        private void dgZonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgZonas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            iProdId = Convert.ToInt32(cmbProducto.SelectedValue);

            iId = Convert.ToInt32(dgZonas.CurrentRow.Cells[0].Value);
            frmZonaEnvioEdit x = new frmZonaEnvioEdit(iProdId, iId);
            x.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarDatosIniciales();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            int iZonaId = -1;

            iZonaId = Convert.ToInt32(dgZonas.Rows[dgZonas.CurrentCell.RowIndex].Cells[0].Value);

           var zona =  unitOfWork.TarifaEnvioZonaRepository.GetByID(iZonaId);

           unitOfWork.TarifaEnvioZonaRepository.Delete(zona);

           unitOfWork.Save();

            BuscarDatosIniciales();
        }



    }
}
