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

namespace OpeAgencia2.Facturacion
{
    public partial class frmDatosPago : Form
    {
        public frmDatosPago()
        {
            InitializeComponent();
        }

        public frmDatosPago(decimal pdMonto)
        {
            InitializeComponent();
            dMontoTransacc = pdMonto;
        }

        decimal dMontoTransacc = 0;

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        BO.DAL.dsDatos.DatosPagoDataTable oTable = new BO.DAL.dsDatos.DatosPagoDataTable();

        public BO.DAL.dsDatos.DatosPagoDataTable DatosPago
        {
            get { return oTable; }
        }

        public decimal dMontoPend { set; get; }

        public decimal MontoEfectivo { set; get; }

        public decimal MontoOtros { set; get; }

        public decimal Devolucion { set; get; }



        private void frmDatosPago_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CargarComboTipoPago();
            cargarDataGrid();
            txtPendiente.Text = dMontoTransacc.ToString();
            txtMontoTotal.Text = dMontoTransacc.ToString();
            dMontoPend = dMontoTransacc;
            txtRecibidoEfectivo.Text = "0";
            txtRecibidoOtros.Text = "0";
        }

        void cargarDataGrid()
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();

            var Productos = from p in unitOfWork.TiposRepository.GetByGroupCode("TPAGO")
                            select new { Id = p.TIPO_ID, Nombre = p.TIPO_CODIGO + "-->" + p.TIPO_NOMBRE };


            cmb.DisplayMember = "Nombre";
            cmb.ValueMember = "Id";

            cmb.DataSource = Productos.ToList();


            dg.DataSource = oTable;
            dg.Columns[0].Visible = false;
            dg.Columns[2].Visible = false;
            //

        }

        void CargarCombo()
        {

            var Bancos = from p in unitOfWork.CodigosRepository.GetByGroupCode("CB")
                         select new { Id = p.CODIGO_ID, Nombre = p.CODIGO_NOMBRE + "-->" + p.CODIGO_COD };


            this.cmbBancos.DisplayMember = "Nombre";
            cmbBancos.ValueMember = "Id";

            this.cmbBancos.DataSource = Bancos.ToList();

        }

        void CargarComboTipoPago()
        {

            var Productos = from p in unitOfWork.TiposRepository.GetByGroupCode("TPAGO")
                            where p.TIPO_CODIGO != "EF"
                            select new { Id = p.TIPO_ID, Nombre = p.TIPO_CODIGO + "-->" + p.TIPO_NOMBRE };



            this.cmbFormaPago.DisplayMember = "Nombre";
            cmbFormaPago.ValueMember = "Id";

            this.cmbFormaPago.DataSource = Productos.ToList();

            cmbFormaPago.SelectedIndex = 0;

        }

        private void cmbBancos_TextChanged(object sender, EventArgs e)
        {
            this.cmbBancos.FindString(cmbBancos.Text);
        }

        private void cmbBancos_Enter(object sender, EventArgs e)
        {
            cmbBancos.DroppedDown = true;
        }

        private void txtMontoCk_Leave(object sender, EventArgs e)
        {

        }

        bool Registrar()
        {
            bool bRetorno = false;

            try
            {
                DataRow dr = oTable.NewRow();

                if (txtNumero.IntValue == 0 || cmbBancos.SelectedValue == null || txtMontoCk.DecimalValue == 0)
                {
                    bRetorno = false;
                }
                else
                {
                    dr["TipoPago"] = Convert.ToInt32(cmbFormaPago.SelectedValue);
                    dr["TipoPagoDesc"] = cmbFormaPago.Text;
                    dr["Numero"] = txtNumero.IntValue.ToString();
                    dr["Banco"] = cmbBancos.SelectedValue;
                    dr["BancoDesc"] = cmbBancos.Text;
                    dr["Fecha"] = txtFecha.Value;
                    dr["Importe"] = txtMontoCk.DecimalValue;
                    dr["MontoEfectivo"] = txtEfectivo.DecimalValue;
                    dr["Devolucion"] = txtDevolucion.DecimalValue;

                    oTable.Rows.Add(dr);
                    bRetorno = true;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede registrar \n " + ex.Message.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return bRetorno;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Registrar())
            {
                txtNumero.IntValue = 0;
                cmbBancos.SelectedIndex = 0;
                txtFecha.Value = DateTime.Now;
                txtMontoCk.DecimalValue = 0;
                txtNumero.Focus();
                ActualizaTotales();
            }
        }


        void ActualizaTotales()
        {
            decimal dMonto = 0;

            for (int i = 0; i < dg.Rows.Count; i++)
            {
                dMonto += Convert.ToDecimal(dg.Rows[i].Cells[6].Value);
            }

            MontoOtros = dMonto;
            dMontoPend = dMontoTransacc - (dMonto + txtEfectivo.DecimalValue);

            MontoEfectivo = txtEfectivo.DecimalValue;

            this.txtRecibidoOtros.Text = MontoOtros.ToString();
            txtPendiente.Text = dMontoPend.ToString();

            txtRecibidoEfectivo.Text = txtEfectivo.DecimalValue.ToString();

            txtPendiente.Text = dMontoPend.ToString();

            if (dMontoPend <= 0)
            {
                txtPendiente.Text = "0";
                btnAceptar.Enabled = true;
            }
            txtDevolucion.DecimalValue = dMontoPend;
        }

        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            ActualizaTotales();
        }
    }
}
