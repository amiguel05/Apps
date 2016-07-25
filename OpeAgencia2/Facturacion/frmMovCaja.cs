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
    public partial class frmMovCaja : Form
    {
        public frmMovCaja()
        {
            InitializeComponent();
        }
  
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        private BO.DAL.dsDatos.EnviosDataTable oEnvio = new BO.DAL.dsDatos.EnviosDataTable();
        BO.DAL.dsDatos.BultosValoresCargosDataTable oUnidades = new BO.DAL.dsDatos.BultosValoresCargosDataTable();
        //
        //CultureInfo oInfo;


        private void frmMovCaja_Load(object sender, EventArgs e)
        {
            CargarCombos();
            //  oInfo =   Thread.CurrentThread.CurrentCulture;
            cmbTipoReporte.SelectedIndex = 0;

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

            dFechaIni = txtFecha.Value.Date;
            dFechaFin = txtFecha.Value.Date.AddDays(1);

            int iCounterId = -1;

            iCounterId = Convert.ToInt32(cmbCounter.SelectedValue);

            var sQuery = from p in unitOfWork.MovCajaRepository.Get(filter: s => s.FECHA >= dFechaIni && s.FECHA < dFechaFin && s.COUNTER_ID == iCounterId
                                     )
                             orderby p.FECHA descending
                             select new { Id = p.MOVCAJA_ID,   Fecha = p.FECHA,  p.COUNTER_ID, Tipo = p.Tipos.TIPO_CODIGO + " " + p.Tipos.TIPO_NOMBRE, p.Clientes.CTE_NUMERO_EPS, Importe = p.IMPORTE };


                dgDatos.DataSource = sQuery.ToList();



        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmbTipoReporte.SelectedIndex == 0)
                CuadredeCaja();
            else
                MovimientosCaja();

        }

        void MovimientosCaja()
        {
            unitOfWork = new BO.DAL.UnitOfWork();

            DateTime dFechaIni;
            DateTime dFechaFin;

            dFechaIni = txtFecha.Value.Date;
            dFechaFin = txtFecha.Value.Date.AddDays(1);

            int iCounterId = -1;

            iCounterId = Convert.ToInt32(cmbCounter.SelectedValue);

            var sQuery = from p in unitOfWork.MovCajaRepository.Get(filter: s => s.FECHA >= dFechaIni && s.FECHA < dFechaFin && s.COUNTER_ID == iCounterId
                                     )
                         orderby p.FECHA descending
                         select new { Id = p.MOVCAJA_ID, Fecha = p.FECHA,Counter = p.Usuarios.NOMBRES+' '+ p.Usuarios.APELLIDOS,
                             p.COUNTER_ID,Tipo=p.Tipos.TIPO_CODIGO, Desc = p.Tipos.TIPO_NOMBRE, p.Clientes.CTE_NUMERO_EPS, Importe = p.IMPORTE };


            dgDatos.DataSource = sQuery.ToList();


            BO.DAL.dsReportes.CuadreCajaDataTable oTable = new BO.DAL.dsReportes.CuadreCajaDataTable();

            foreach (var oQuery in sQuery)
            {
                BO.DAL.dsReportes.CuadreCajaRow oFactRow = oTable.NewCuadreCajaRow();


                oFactRow.Counter = oQuery.Counter;
                oFactRow.EPS = oQuery.CTE_NUMERO_EPS;
                oFactRow.Importe = oQuery.Importe;
                oFactRow.Tipo = oQuery.Tipo;
                oFactRow.Descr = oQuery.Desc;

                var ReciboCaja = unitOfWork.MovCajaRecibosRepository.Get(filter: xy => xy.MOVCAJA_ID == oQuery.Id).FirstOrDefault();

                if (ReciboCaja != null)
                    oFactRow.Factura = ReciboCaja.Recibos.Tipos.TIPO_CODIGO + "-" + ReciboCaja.Recibos.NUM_REC;
                else
                    oFactRow.Factura = oQuery.Tipo+"-"+oQuery.Id.ToString();

               
                /*oFactRow.NUM_FISCAL = oQuery.NUM_FISCAL;
                oFactRow.REC_CREDITO = oQuery.REC_CREDITO;
                oFactRow.RECIBO = oQuery.RECIBO;
                oFactRow.RECIBO_ID = oQuery.RECIBO_ID;
                oFactRow.SUC_ID = oQuery.SUC_ID;
                oFactRow.TIP_MOV = oQuery.TIP_MOV;
                oFactRow.TIPO_DESCR = oQuery.TIPO_DESCR;
                oFactRow.TIPO_REC_DESC = oQuery.TIPO_REC_DESC;
                */


                oTable.Rows.Add(oFactRow);

            }

            oTable.TableName = "CuadreCaja";

            string sPath = @".\Reportes\CuadreCaja.rdlc";
            //string sPath = "OpeAgencia2.Reportes.CuadreCaja.rdlc";

            frmReportViewer x = new frmReportViewer(sPath, oTable, "Reporte de Movimientos de Caja -" + txtFecha.Value.Date.ToShortDateString());

            x.ShowDialog();

        }

        void CuadredeCaja()
        {
            unitOfWork = new BO.DAL.UnitOfWork();

            DateTime dFechaIni;
            DateTime dFechaFin;

            dFechaIni = txtFecha.Value.Date;
            dFechaFin = txtFecha.Value.Date.AddDays(1);

            int iCounterId = -1;

            iCounterId = Convert.ToInt32(cmbCounter.SelectedValue);

            var sQuery = unitOfWork.vwCuadreCajaRepository.Get(filter: s => s.FECHA == dFechaIni && s.COUNTER_ID == iCounterId);
                       

            BO.DAL.dsReportes.VW_CUADRE_CAJADataTable oTable = new BO.DAL.dsReportes.VW_CUADRE_CAJADataTable();

            foreach (var oQuery in sQuery)
            {
                BO.DAL.dsReportes.VW_CUADRE_CAJARow oFactRow = oTable.NewVW_CUADRE_CAJARow();

          

                oFactRow.CAJERO = oQuery.CAJERO;
                oFactRow.COUNTER_ID = oQuery.COUNTER_ID;
                oFactRow.CTE_ID = oQuery.CTE_ID;
                oFactRow.CTE_NUMERO_EPS = oQuery.CTE_NUMERO_EPS;
                oFactRow.IMPORTE = oQuery.IMPORTE;
                oFactRow.MOVCAJA_ID = oQuery.MOVCAJA_ID;
                oFactRow.NUM_FISCAL = oQuery.NUM_FISCAL;
                oFactRow.REC_CREDITO = oQuery.REC_CREDITO;
                oFactRow.RECIBO = oQuery.RECIBO;
                oFactRow.RECIBO_ID = oQuery.RECIBO_ID;
                oFactRow.SUC_ID = oQuery.SUC_ID;
                oFactRow.TIP_MOV = oQuery.TIP_MOV;
                oFactRow.TIPO_DESCR = oQuery.TIPO_DESCR;
                oFactRow.TIPO_REC_DESC = oQuery.TIPO_REC_DESC;
             


                oTable.Rows.Add(oFactRow);

            }

            oTable.TableName = "VW_CUADRE_CAJA";
      
           // string sPath = @".\Reportes\CuandreCaja.rdlc";
            string sPath = @".\Reportes\rCuadreCaja2.rdlc";

            frmReportViewer x = new frmReportViewer(sPath,oTable,"Reporte de Movimientos de Caja -" + txtFecha.Value.Date.ToShortDateString());

            x.ShowDialog();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int iReciboId = -1;

            iReciboId = Convert.ToInt32(dgDatos[0, dgDatos.CurrentCell.RowIndex].Value);

            // MessageBox.Show("Anulación realizada exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //ImprimirFactura(oFact.FacturaGenerada);
            unitOfWork = new BO.DAL.UnitOfWork();
            var Recibos = unitOfWork.MovCajaRepository.GetByID(iReciboId);

            if (Recibos != null && Recibos.TIP_MOV == 55) /*Ingreso de cobros*/
            {
                //ImprimirFactura(oFact.FacturaGenerada);
                Facturacion.ImprimirFactura oImpFact = new Facturacion.ImprimirFactura();

                //Aca vamos a imprimir con el numero de omivimento de caja
                oImpFact.ImprimirComprobate(iReciboId);


           
            }

        }
    }
}
