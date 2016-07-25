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

namespace OpeAgencia2.Creditos
{
    public partial class frmCobros : Form
    {
        public frmCobros()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        int iCteId = -1;

        private void txtEPS_Leave(object sender, EventArgs e)
        {
            if (txtEPS.Text != "")
                   BuscarCliente();
        }


        void BuscarCliente()
        {
            unitOfWork = new BO.DAL.UnitOfWork();

            oCliente = unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtEPS.Text 
                            && s.CTE_SUC_ID == Parametros.Parametros.SucursalActual && s.CTE_CREDITO == true).FirstOrDefault();

            if (oCliente != null)
            {
                lblNombres.Text = oCliente.CTE_NOMBRE + " " + oCliente.CTE_APELLIDO;
            
                BuscarRecibos(oCliente.CTE_ID);

                iCteId = oCliente.CTE_ID;
              
            }
            else
            {
                MessageBox.Show("No existe EPS", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtEPS.Text = "";
                txtEPS.Focus();

                lblNombres.Text = "";

                iCteId = -1;
         
            }

        }


        void BuscarRecibos(int iCteId)
        {
            unitOfWork = new BO.DAL.UnitOfWork();

            var oRecibos = from p in unitOfWork.RecibosRepository.Get(filter: s => s.CTE_ID == iCteId && s.ESTADO_ID == 13 && s.Tipos.TIPO_ID != 5)
                          select new
                          {
                              p.RECIBO_ID,
                              p.Tipos.TIPO_DESCR,
                              p.FECHA,
                              p.IMPORTE_TOTAL,
                              p.IMPORTE_CTA,
                              BALANCE = (p.IMPORTE_TOTAL - p.IMPORTE_CTA)
                          };
            this.dgRecibos.DataSource = oRecibos.ToList();
            this.dgRecibos.Columns[0].Visible = false;
        }

        private void dgRecibos_SelectionChanged(object sender, EventArgs e)
        {
            ActualizaTotal();
        }

        void ActualizaTotal()
        {
            int iPaq = 0;
            decimal dMonto = 0;

            for (int i = 0; i < this.dgRecibos.Rows.Count; i++)
            {
                if (dgRecibos.Rows[i].Selected == true)
                {
                    iPaq++;
                    dMonto += Convert.ToDecimal(dgRecibos.Rows[i].Cells[5].Value);
                    txtMontoAplicar.DecimalValue = dMonto;
                }
            }
            //
            /*for (int i = 0; i < this.dgRecibos.Rows.Count; i++)
            {

                iPaq++;
                dMonto += Convert.ToDecimal(dgRecibos.Rows[i].Cells[2].Value);
            }
            */

    
            txtMontoTotal.Text = dMonto.ToString();
        }

        private void txtEPS_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            bool bPagado = false;
            decimal dMontoEfectivo, dMontoOtros, dDevolucion;

            ArrayList oRecibos = new ArrayList();
            BO.DAL.dsDatos.DatosPagoDataTable DatosPago = new BO.DAL.dsDatos.DatosPagoDataTable();

            Facturacion.frmDatosPago x = new Facturacion.frmDatosPago(txtMontoAplicar.DecimalValue);
            x.StartPosition = FormStartPosition.CenterParent;
            x.ShowDialog();
            dMontoEfectivo = x.MontoEfectivo;
            dMontoOtros = x.MontoOtros;
            dDevolucion = x.Devolucion;
            DatosPago = x.DatosPago;
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
                bPagado = true;

            if (bPagado == true)
            {
                foreach (DataGridViewRow oRow in dgRecibos.SelectedRows)
                {
                    oRecibos.Add(oRow.Cells[0].Value);
                }

                if (oRecibos.Count >0 )
                {
                //    RegistrarCobro(ArrayList pRecibos, int iCteId, int iUsuarioId, int iSucId, int iTipoFiscal, decimal pdMontoPagar,
                //   decimal dMontoEfectivo, decimal dMontoOtros, decimal dDevolucion, DAL.dsDatos.DatosPagoDataTable oDatosPago)
                    BO.BO.Facturar oFact = new BO.BO.Facturar();
                    if (oFact.RegistrarCobro(oRecibos, iCteId, Parametros.Parametros.UsuarioId, Parametros.Parametros.SucursalActual, -1,
                        txtMontoAplicar.DecimalValue,dMontoEfectivo,dMontoOtros,dDevolucion,DatosPago) == true)
                    {


                        //ImprimirFactura(oFact.FacturaGenerada);
                        Facturacion.ImprimirFactura oImpFact = new Facturacion.ImprimirFactura();

                        //Aca vamos a imprimir con el numero de omivimento de caja
                        oImpFact.ImprimirComprobate(oFact.FacturaGenerada);


                        LimpiarPantalla();


                        MessageBox.Show("Pago aplicado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            
        }

        void LimpiarPantalla()
        {
            BuscarCliente();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtEPS.Text != "" && e.KeyCode == Keys.Enter)
                BuscarCliente();
        }
    }
}
