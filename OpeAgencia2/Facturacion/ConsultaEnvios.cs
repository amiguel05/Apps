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
using System.Globalization;
using System.Threading;


namespace OpeAgencia2.Facturacion
{
    public partial class ConsultaOperaciones : Form
    {
        public ConsultaOperaciones()
        {
            InitializeComponent();
        }


        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        private BO.DAL.dsDatos.EnviosDataTable oEnvio = new BO.DAL.dsDatos.EnviosDataTable();
        BO.DAL.dsDatos.BultosValoresCargosDataTable oUnidades = new BO.DAL.dsDatos.BultosValoresCargosDataTable();
        //
        //CultureInfo oInfo;


        private void ConsultaEnvios_Load(object sender, EventArgs e)
        {
            CargarCombos();
            //  oInfo =   Thread.CurrentThread.CurrentCulture;

        }


        void CargarCombos()
        {
            var sQryCounter = from p in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.SUC_ID == Parametros.ParametrosSucursal.IdSucursal)
                              select new { Id = p.Usuarios.USUARIO_ID, Nombre = p.Usuarios.USER_NAME };
            cmbCounter.ValueMember = "Id";
            cmbCounter.DisplayMember = "Nombre";
            cmbCounter.DataSource = sQryCounter.ToList();
            cmbCounter.SelectedValue = Parametros.Parametros.UsuarioId;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        void BuscarDatos()
        {
            unitOfWork = new BO.DAL.UnitOfWork();
            DateTime dFechaIni;
            DateTime dFechaFin;
            int iCounterId = -1;
            dFechaIni = txtFecha.Value.Date;
            dFechaFin = txtFecha.Value.Date.AddDays(1);
            iCounterId = Convert.ToInt32(cmbCounter.SelectedValue);
            if (txtEPS.Text == "")
            {
                var sQuery = from p in unitOfWork.RecibosRepository.Get(filter: s => s.FECHA >= dFechaIni &&
                    s.FECHA < dFechaFin && s.COUNTER_ID == iCounterId)
                             orderby p.FECHA descending
                             select new { Id = p.RECIBO_ID, p.COUNTER_ID, Tipo = p.Tipos.TIPO_CODIGO + " " + p.Tipos.TIPO_NOMBRE, p.Clientes.CTE_NUMERO_EPS, NCF = p.NUM_FISCAL, Importe = p.IMPORTE_TOTAL, Estado = p.Estados.ESTADO_NOMBRE, ImpresoFiscal = p.IMPRESO };
                if (chkNoImpresos.Checked == true)
                {
                    var Query2 = sQuery.Where(xy => xy.ImpresoFiscal == false);
                    dgDatos.DataSource = Query2.ToList();
                }
                else
                {
                    dgDatos.DataSource = sQuery.ToList();
                }
            }
            else
            {
                var sQuery = from p in unitOfWork.RecibosRepository.Get(filter: s => s.FECHA >= dFechaIni && s.FECHA < dFechaFin && s.Clientes.CTE_NUMERO_EPS == txtEPS.Text && s.COUNTER_ID == iCounterId
                                     )
                             orderby p.FECHA descending
                             select new { Id = p.RECIBO_ID, p.COUNTER_ID, Tipo = p.Tipos.TIPO_CODIGO + " " + p.Tipos.TIPO_NOMBRE, p.Clientes.CTE_NUMERO_EPS, NCF = p.NUM_FISCAL, Importe = p.IMPORTE_TOTAL, Estado = p.Estados.ESTADO_NOMBRE, ImpresoFiscal = p.IMPRESO };
                if (chkNoImpresos.Checked == true)
                {
                    var Query2 = sQuery.Where(xy => xy.ImpresoFiscal == false);
                    dgDatos.DataSource = Query2.ToList();
                }
                else
                {
                    dgDatos.DataSource = sQuery.ToList();
                }
            }
        }

        private void dgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnularRecibo();
        }

        void AnularRecibo()
        {
            int iReciboId = -1;

            iReciboId = Convert.ToInt32(dgDatos[0, dgDatos.CurrentCell.RowIndex].Value);

            var recibo = unitOfWork.RecibosRepository.GetByID(iReciboId);
            if (recibo.ESTADO_ID == 15)
            {
                MessageBox.Show("Este recibo ya fue anulado", "Recibo anulado", MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                return;
            }
            if (recibo != null)
            {//"0,0.00", CultureInfo.InvariantCulture
                if (MessageBox.Show("¿Desea anular el recibo por un monto de: " + recibo.IMPORTE_TOTAL.ToString("0,0.00", 
                    CultureInfo.InvariantCulture) + "?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == 
                    System.Windows.Forms.DialogResult.Yes)
                {
                    if (ProcesoAnulacion(iReciboId) == false)
                    {
                        MessageBox.Show("Error procesando anulación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        bool ProcesoAnulacion(int iReciboId)
        {
            Boolean bRetorno = false;
            string sMensaje = "";

            BO.BO.Facturar oFact = new BO.BO.Facturar();

            bRetorno = oFact.ProcesarAnulacion(iReciboId, Parametros.Parametros.UsuarioId, ref sMensaje);

            if (bRetorno == false)
            {
                MessageBox.Show(sMensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Anulación realizada exitosamente en el sistema", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ImprimirFactura(oFact.FacturaGenerada);
                ImprimirFactura oImpFact = new ImprimirFactura();
                BO.DAL.dsDatos.DatosPagoDataTable oDatosPago = null;

                oImpFact.Imprimir(oFact.FacturaGenerada, oDatosPago);


                //LimpiarPantalla();
            }

            return bRetorno;
        }

        private void reImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            

            if (Parametros.ParametrosSucursal.NoImpresoraFiscal == true)
            {
                MessageBox.Show("Esta opción es solo para impresoras fiscales", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int iReciboId = -1;

            iReciboId = Convert.ToInt32(dgDatos[0, dgDatos.CurrentCell.RowIndex].Value);

            //BO.BO.Facturar oFact = new BO.BO.Facturar();
            //oFact.RevisarTotales(iReciboId);

            // MessageBox.Show("Anulación realizada exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //ImprimirFactura(oFact.FacturaGenerada);
            unitOfWork = new BO.DAL.UnitOfWork();
            var Recibos = unitOfWork.RecibosRepository.GetByID(iReciboId);

            if (Recibos != null)
            {
                BO.DAL.dsDatos.DatosPagoDataTable oPagos = new BO.DAL.dsDatos.DatosPagoDataTable();

                bool bImpreso = Recibos.IMPRESO;

                if (bImpreso == false && Recibos.ESTADO_ID != 15)
                {
                    DialogResult oResult = MessageBox.Show("Este recibo no se ha impreso fiscalmente, ¿desea imprimirlo ahora?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (oResult == System.Windows.Forms.DialogResult.No)
                        return;
                }
                else if (Recibos.ESTADO_ID == 15)
                {
                    DialogResult oResult = MessageBox.Show("Este recibo fue anulado, no es posible reimprimir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    DialogResult oResult = MessageBox.Show("Este recibo ya fue impreso fiscalmente, no es posible reimprimir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    return;
                }
                var PagosRecibos = unitOfWork.PagosRecibosRepository.Get(xy => xy.RECIBO_ID == iReciboId).FirstOrDefault();
                if (PagosRecibos != null)
                {
                    var pagos = unitOfWork.PagosRepository.Get(filter: xy => xy.PAGO_ID == PagosRecibos.PAGO_ID).FirstOrDefault();
                    var DatosPagos = unitOfWork.DatosPagoRepository.Get(xy => xy.PAGO_ID == pagos.PAGO_ID);
                    foreach (var datosPago in DatosPagos)
                    {
                        BO.DAL.dsDatos.DatosPagoRow oRow = oPagos.NewDatosPagoRow();
                        oRow.Banco = datosPago.BANCO_ID;
                        oRow.BancoDesc = "";
                        oRow.Devolucion = 0;
                        oRow.Fecha = DateTime.Now;
                        oRow.Importe = datosPago.IMPORTE;
                        oRow.MontoEfectivo = pagos.MONTO_EFECTIVO;
                        oRow.Numero = 0;
                        oRow.TipoPago = pagos.TIPO_ID;
                        oRow.TipoPagoDesc = "";
                        oPagos.Rows.Add(oRow);
                    }
                    if (DatosPagos == null || DatosPagos.Any() == false)
                    {
                        BO.DAL.dsDatos.DatosPagoRow oRow = oPagos.NewDatosPagoRow();
                        oRow.Banco = -1;
                        oRow.BancoDesc = "";
                        oRow.Devolucion = 0;
                        oRow.Fecha = DateTime.Now;
                        oRow.Importe = pagos.IMP_PAGO;
                        oRow.MontoEfectivo = pagos.MONTO_EFECTIVO;
                        oRow.Numero = 99;
                        oRow.TipoPago = -1;
                        oRow.TipoPagoDesc = "";
                        oPagos.Rows.Add(oRow);
                    }
                }

                
                if (Recibos.TIPO_REC_ID == 62)  //No venta
                {
                    ImprimirFactura oImpFact = new ImprimirFactura();
                    oImpFact.ImprimirNoVenta(iReciboId, oPagos);
                }
                else
                {
                    ImprimirFactura oImpFact = new ImprimirFactura();
                    oImpFact.Imprimir(iReciboId, oPagos);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void verEnPantallaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int iReciboId = -1;

            iReciboId = Convert.ToInt32(dgDatos[0, dgDatos.CurrentCell.RowIndex].Value);

            ImprimirFactura oImpFact = new ImprimirFactura();
            oImpFact.Imprimir(iReciboId);

        }
    }
}
