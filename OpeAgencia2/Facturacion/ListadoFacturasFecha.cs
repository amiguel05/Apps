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
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using clsUtils;

namespace OpeAgencia2.Facturacion
{
    public partial class ListadoFacturasFecha : Form
    {
        public ListadoFacturasFecha()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        void GenerarReporte()
        {
            unitOfWork = new BO.DAL.UnitOfWork();
            DateTime dFechaIni;
            DateTime dFechaFin;
            dFechaIni = this.txtFechaDesde.Value.Date;
            dFechaFin = this.txtFechaHasta.Value.Date.AddDays(1);
            //&& s.RECIBO_ID_ANUL == -1 && s.Tipos.TIPO_CODIGO != "NC01"
            var sQuery = from p in unitOfWork.RecibosRepository.Get(filter: s => s.FECHA >= dFechaIni && s.FECHA < 
                dFechaFin && s.SUC_ID == Parametros.ParametrosSucursal.IdSucursal )
                         orderby p.FECHA
                         select new { Fecha = p.FECHA, Cliente = p.Clientes.CTE_NUMERO_EPS.TrimEnd() + "-" + p.Clientes.CTE_NOMBRE.TrimEnd() + " " + p.Clientes.CTE_APELLIDO.TrimEnd() ,
                                      Factura = p.Tipos.TIPO_CODIGO + "-" + p.NUM_REC,
                                      MontoGrabado = p.IMPORTE_GRAVADO,
                                      MontoExcento = p.IMPORTE_TOTAL - p.IMPORTE_GRAVADO - p.IMPORTE_ITEBIS,
                                      MontoItebis = p.IMPORTE_ITEBIS,
                                      p.ITBIS,MontoFact=p.IMPORTE_TOTAL,Usuario=p.USER_CREA,NCF=p.NUM_FISCAL,
                                      TipoReciboId = p.TIPO_REC_ID };
            BO.DAL.dsReportes.FacturaFechaDataTable oTable = new BO.DAL.dsReportes.FacturaFechaDataTable();
            foreach (var oQuery in sQuery)
            {
                BO.DAL.dsReportes.FacturaFechaRow oFactRow = oTable.NewFacturaFechaRow();
                oFactRow.Fecha = oQuery.Fecha;
                oFactRow.Cliente = oQuery.Cliente;
                oFactRow.Factura = oQuery.Factura;
                oFactRow.Fecha = oQuery.Fecha;
                oFactRow.MontoGrabado = oQuery.MontoGrabado * (oQuery.TipoReciboId == 5 ? -1 : 1);
                oFactRow.MontoExcento = oQuery.MontoExcento * (oQuery.TipoReciboId == 5 ? -1 : 1);
                oFactRow.MontoFact = oQuery.MontoFact * (oQuery.TipoReciboId == 5 ? -1 : 1);
                oFactRow.Usuario = oQuery.Usuario;
                oFactRow.ITBIS = (oQuery.MontoItebis) * (oQuery.TipoReciboId == 5 ? -1 : 1);
                oFactRow.NCF = oQuery.NCF;
                oTable.Rows.Add(oFactRow);
            }
            oTable.TableName = "FacturaFecha";
            //string sPath = @".\Reportes\rReporteFacturacionFecha.rdlc";
            //string sPath = "OpeAgencia2.Reportes.rReporteFacturacionFecha.rdlc";
            string sTitulo = "Listado de Facturas por Fecha (" + txtFechaDesde.Value.ToShortDateString() + " - " + txtFechaHasta.Value.ToShortDateString() +")";
            LocalReport report = new LocalReport();
            report.ReportPath = @".\Reportes\rReporteFacturacionFecha.rdlc";
            report.DataSources.Add(new ReportDataSource("DataSet1", oTable.Copy()));
         //   report.SetParameters(new ReportParameter("Fecha", DateTime.Now.ToShortDateString()));
           // report.SetParameters(new ReportParameter("Hora", DateTime.Now.ToShortDateString()));
            //report.SetParameters(new ReportParameter("Sucursal", dt.Rows[0]["SUCURSAL"].ToString()));
            //report.SetParameters(new ReportParameter("Factura", dt.Rows[0]["REC_TIPO"].ToString() + "-" + dt.Rows[0]["REC_ID"].ToString()));
            report.SetParameters(new ReportParameter("Titulo", sTitulo));
            report.SetParameters(new ReportParameter("Encabezado1", Parametros.ParametrosSucursal.EncabezadoFactura1));
            report.SetParameters(new ReportParameter("Encabezado2", Parametros.ParametrosSucursal.EncabezadoFactura2));
            report.SetParameters(new ReportParameter("Encabezado3", Parametros.ParametrosSucursal.EncabezadoFactura3));
            /*
              report.DataSources.Add(
                 new ReportDataSource("Sales", LoadSalesData()));
               -----
              */
            frmReportViewer x = new frmReportViewer(report);
            x.ShowDialog();
            //x.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
