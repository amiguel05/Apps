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
using System.Collections;

namespace OpeAgencia2.Clientes
{
    public partial class frmConsultaMercancia : Form
    {
        public frmConsultaMercancia()
        {
            InitializeComponent();
        }


        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        Hashtable htValores = new Hashtable();


        private void frmConsultaMercancia_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            unitOfWork = new BO.DAL.UnitOfWork();

                var oEmpresa = unitOfWork.SucursalesRepository.Get(xy=>xy.SUC_ID == Parametros.Parametros.SucursalActual).FirstOrDefault();

                var oBultos = from p in unitOfWork.BultosRepository.GetByNumeroEPS(txtEPS.Text, txtGuiaMadre.Text, txtCodigoBarra.Text, txtTracking.Text, cmbEstado.SelectedIndex, oEmpresa.Empresas.COM_CODIGO)
                                  select new {p.BLT_NUMERO,p.Clientes.CTE_NUMERO_EPS,p.MAN_GUIA, p.BLT_CODIGO_BARRA,p.BLT_TRACKING_NUMBER,
                                      p.Productos.PRO_CODIGO,p.BLT_PESO, p.BLT_PIEZAS, p.REMITENTE, p.DESTINATARIO, p.BLT_ESTADO_ID, Recibido=p.BLT_FECHA_RECEPCION, Entregado=p.BLT_FECHA_ENTREGADO};

                 
           
                dg.DataSource = oBultos.ToList();
                dg.Columns[0].Visible = false;

            if (txtEPS.Text.TrimEnd() != "")
            {
                var oCliente = unitOfWork.ClientesRepository.Get(filter: xy => xy.CTE_NUMERO_EPS == txtEPS.Text ).FirstOrDefault();
                if (oCliente != null)
                {
                    if (oCliente.CTE_CORRESPONDENCIA)
                        lblCorrespondencia.Text = "Cliente tiene correspondencia";
                    else
                        lblCorrespondencia.Text = "";

                }
                else
                    lblCorrespondencia.Text = "";

            }
            else
            {
                lblCorrespondencia.Text = "";
            }
            

        }

        private void dg_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //for (int i = 0; i < dg.RowCount ; i++)
            //{
            //    if (dg.Rows[i].Cells[10].Value.ToString() == "1")
            //    {
            //        dg.Rows[i].DefaultCellStyle.BackColor = Color.Red ;
            //        dg.Rows[i].DefaultCellStyle.ForeColor  = Color.White;
            //    }
            //    if (dg.Rows[i].Cells[10].Value.ToString() == "2")
            //    {
            //        dg.Rows[i].DefaultCellStyle.BackColor = Color.Green;
            //        dg.Rows[i].DefaultCellStyle.ForeColor = Color.White;
            //    }
            //    if (dg.Rows[i].Cells[10].Value.ToString() == "6")
            //    {
            //        dg.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
            //        dg.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
            //    }
            //    if (dg.Rows[i].Cells[10].Value.ToString() == "5")
            //    {
            //        dg.Rows[i].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            //        dg.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
            //    }
            //}
        }

        private void dg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dg.CurrentRow == null || dg.CurrentRow.Index < 0)
                return;
            int iBltNumero = -1;
            iBltNumero = Convert.ToInt32(dg.Rows[dg.CurrentRow.Index].Cells[0].Value);
            Operaciones.frmRecepcion oFrom = new Operaciones.frmRecepcion(iBltNumero);
            oFrom.ShowDialog();
        }

        private void dg_SelectionChanged(object sender, EventArgs e)
        {
            Calculartotal();
        }

        void Calculartotal()
        {


          int iPaq = 0;
            decimal dMonto = 0;
        
            htValores.Clear();
            dgResumen.Rows.Clear();

            for (int i = 0; i < dg.Rows.Count; i++)
            {
                if (dg.Rows[i].Selected == true)
                {
                    iPaq++;
                    //dMonto += Math.Round(Convert.ToDecimal(dg.Rows[i].Cells[5].Value), 2);
                    BuscarValores(Convert.ToInt32(dg.Rows[i].Cells[0].Value));
                }
            }
  
      
            foreach(var item in htValores.Keys)
            {
                dgResumen.Rows.Add(item, string.Format("{0:0,0.00}", htValores[item]));
                dMonto += Convert.ToDecimal(htValores[item]);
            }

         

            this.txtPaq.Text = iPaq.ToString();
            txtMontoTotal.Text = string.Format("{0:0,0.00}", dMonto);
           
        }

        void BuscarValores(int bltNumero)
        {
            var loBultosVal = from p in  unitOfWork.BultosValoresRepository.Get(filter: xy => xy.BLT_NUMERO == bltNumero)
                            select new {Cargo = p.CargosProducto.Cargos.CAR_CODIGO + '-' + p.CargosProducto.Cargos.CAR_DESCRIPCION, Monto = p.BVA_MONTO_LOCAL};
            foreach (var cargo in loBultosVal)
            {
                if (htValores[cargo.Cargo] == null)
                    htValores.Add(cargo.Cargo, cargo.Monto);
                else
                    htValores[cargo.Cargo] = Convert.ToDecimal(htValores[cargo.Cargo]) + cargo.Monto;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void textboxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            btnConsultar.PerformClick();
        }

        private void Limpiar()
        {
            dgResumen.Rows.Clear();
            //dg.Rows.Clear();
            foreach (var textbox in groupBox1.Controls.OfType<TextBox>())
                textbox.Clear();
            //cmbEstado.SelectedIndex = -1;
        }
    }
}
