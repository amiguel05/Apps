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
using ImpresoraFiscal;

namespace OpeAgencia2.Facturacion
{
    public class ImprimirFactura : IDisposable
    {
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        private Stream CreateStream(string name,
        string fileNameExtension, Encoding encoding,
        string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        public void Imprimir(int iReciboId)
        {
            //dsFacturaBindingSource.DataSource = CargarDataSet();
            DataSet dsFacturas = new DataSet();
            DataTable dt = new DataTable();
            dt = CargarDataSet(iReciboId);
            dt.TableName = "FACTURAS";
            BO.Models.Terminal oTerm = new BO.Models.Terminal();
            //oTerm  =unitOfWork.TerminalRepository.GetByID(Parametros.ParametrosSucursal.TermFiscalId);
            //Printer oPrinter = new Printer(oTerm);
            //oPrinter.SetInvoiceData()
            dsFacturas.Tables.Add(dt);
            LocalReport report = new LocalReport();
            report.ReportPath = @".\Reportes\rFactura.rdlc";
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            report.SetParameters(new ReportParameter("Fecha", Convert.ToDateTime(dt.Rows[0]["REC_FECHA"]).ToShortDateString()));
            report.SetParameters(new ReportParameter("Hora", Convert.ToDateTime(dt.Rows[0]["REC_FECHA"]).ToShortTimeString()));
            report.SetParameters(new ReportParameter("Sucursal", dt.Rows[0]["SUCURSAL"].ToString()));
            report.SetParameters(new ReportParameter("Factura", dt.Rows[0]["REC_TIPO"].ToString() + "-" + dt.Rows[0]["REC_ID"].ToString()));
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
            //Export(report);
            //Print();
        }

        public void Imprimir2Printer(int iReciboId)
        {
            //dsFacturaBindingSource.DataSource = CargarDataSet();
            DataSet dsFacturas = new DataSet();
            DataTable dt = new DataTable();
            dt = CargarDataSet(iReciboId);
            dt.TableName = "FACTURAS";
            BO.Models.Terminal oTerm = new BO.Models.Terminal();
            //oTerm  =unitOfWork.TerminalRepository.GetByID(Parametros.ParametrosSucursal.TermFiscalId);
            //Printer oPrinter = new Printer(oTerm);
            //oPrinter.SetInvoiceData()
            dsFacturas.Tables.Add(dt);
            LocalReport report = new LocalReport();
            report.ReportPath = @".\Reportes\rFactura.rdlc";
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            report.SetParameters(new ReportParameter("Fecha", Convert.ToDateTime(dt.Rows[0]["REC_FECHA"]).ToShortDateString()));
            report.SetParameters(new ReportParameter("Hora", Convert.ToDateTime(dt.Rows[0]["REC_FECHA"]).ToShortTimeString()));
            report.SetParameters(new ReportParameter("Sucursal", dt.Rows[0]["SUCURSAL"].ToString()));
            report.SetParameters(new ReportParameter("Factura", dt.Rows[0]["REC_TIPO"].ToString() + "-" + dt.Rows[0]["REC_ID"].ToString()));
            report.SetParameters(new ReportParameter("Encabezado1", Parametros.ParametrosSucursal.EncabezadoFactura1));
            report.SetParameters(new ReportParameter("Encabezado2", Parametros.ParametrosSucursal.EncabezadoFactura2));
            report.SetParameters(new ReportParameter("Encabezado3", Parametros.ParametrosSucursal.EncabezadoFactura3));
            /*
            report.DataSources.Add(
               new ReportDataSource("Sales", LoadSalesData()));
             -----
          
            frmReportViewer x = new frmReportViewer(report);
            x.ShowDialog();
             */
            Export(report);
            Print();
        }
       
          

        public void Imprimir(int iReciboId, BO.DAL.dsDatos.DatosPagoDataTable oDatosPago, bool pbImpreso = false)
        {
            //bool bError = false;
            PrinterResponses response;
            // dsFacturaBindingSource.DataSource = CargarDataSet();
            BO.DAL.dsFactura.FACTURASDataTable dtFatura = new BO.DAL.dsFactura.FACTURASDataTable();
            // DataTable dt = new DataTable();
            dtFatura = CargarDataSetFiscal(iReciboId);
            //dt.TableName = "FACTURAS";
            BO.Models.Terminal oTerm = new BO.Models.Terminal();
            oTerm = unitOfWork.TerminalRepository.GetByID(Parametros.ParametrosSucursal.TermFiscalId);
            if (oTerm != null)
            {
                Printer oPrinter = new Printer(oTerm);
                oPrinter.SetInvoiceData(dtFatura, oDatosPago, !pbImpreso, 1);
                response = oPrinter.Print();
                if (response == PrinterResponses.Success)
                {
                    var oRecibos = unitOfWork.RecibosRepository.GetByID(iReciboId);
                    oRecibos.IMPRESO = true;
                    unitOfWork.RecibosRepository.Update(oRecibos);
                    unitOfWork.Save();
                }
                else
                {
                    MessageBox.Show(Printer.GetPrinterReturnMessage(response), "Aviso", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }
            
            //dsFacturas.Tables.Add(dt);
        }

        public void ImprimirNoVenta(int iReciboId, BO.DAL.dsDatos.DatosPagoDataTable oDatosPago, bool pbImpreso = false)
        {
            bool bError = false;
            // dsFacturaBindingSource.DataSource = CargarDataSet();
            BO.DAL.dsFactura.FACTURASDataTable dtFatura = new BO.DAL.dsFactura.FACTURASDataTable();
            // DataTable dt = new DataTable();
            dtFatura = CargarDataSetFiscal(iReciboId);
            //dt.TableName = "FACTURAS";
            BO.Models.Terminal oTerm = new BO.Models.Terminal();
            oTerm = unitOfWork.TerminalRepository.GetByID(Parametros.ParametrosSucursal.TermFiscalId);
            Printer oPrinter = new Printer(oTerm);
            oPrinter.SetInvoiceData(dtFatura, oDatosPago, !pbImpreso, 1);
            oPrinter.PrintNoFiscalReceipt();
            /* if (bError == false)
             {
                 var oRecibos = unitOfWork.RecibosRepository.GetByID(iReciboId);
                 oRecibos.IMPRESO = true;
                 unitOfWork.RecibosRepository.Update(oRecibos);
                 unitOfWork.Save();
             }
             else
             {
                 MessageBox.Show("Ha ocurrido un error en la Impresión del recibo, favor revisar la conexión ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             */
            //dsFacturas.Tables.Add(dt);
        }

        public void ImprimirComprobate(int piMovCaja)
        {
            // dsFacturaBindingSource.DataSource = CargarDataSet();
            DataSet dsFacturas = new DataSet();
            DataTable dt = new DataTable();
            dt = CargarDataSetPagos(piMovCaja);
            dt.TableName = "MOVCAJA";
            //dsFacturas.Tables.Add(dt);
            LocalReport report = new LocalReport();
            report.ReportPath = @".\Reportes\rReciboIngreso.rdlc";
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            report.SetParameters(new ReportParameter("Fecha", Convert.ToDateTime(dt.Rows[0]["FECHA"]).ToShortDateString()));
            report.SetParameters(new ReportParameter("Hora", Convert.ToDateTime(dt.Rows[0]["FECHA"]).ToShortTimeString()));
            report.SetParameters(new ReportParameter("Sucursal", dt.Rows[0]["SUCURSAL"].ToString()));
            report.SetParameters(new ReportParameter("Factura", dt.Rows[0]["TIP_MOV"].ToString() + "-" + dt.Rows[0]["MOVCAJA_ID"].ToString()));
            report.SetParameters(new ReportParameter("Encabezado1", Parametros.ParametrosSucursal.EncabezadoFactura1));
            report.SetParameters(new ReportParameter("Encabezado2", Parametros.ParametrosSucursal.EncabezadoFactura2));
            report.SetParameters(new ReportParameter("Encabezado3", Parametros.ParametrosSucursal.EncabezadoFactura3));
            /*
            report.DataSources.Add(
               new ReportDataSource("Sales", LoadSalesData()));
             */
            Export(report);
            Print();
        }

        public DataTable CargarDataSet(int piReciboId)
        {
            BO.DAL.dsFactura.FACTURASDataTable oTable = new BO.DAL.dsFactura.FACTURASDataTable();
            var oRecibo = unitOfWork.RecibosRepository.GetByID(piReciboId);
            var oRecibosDet = unitOfWork.RecibosDetRepository.Get(filter: xy => xy.RECIBO_ID == oRecibo.RECIBO_ID);
            int iCantElementos = 0;
            var elementos = from p in oRecibosDet
                            select new { p.BLT_NUMERO };
            iCantElementos = elementos.Distinct().Count();
            foreach (var oRecDet in oRecibosDet)
            {
                //var BultosValores = unitOfWork.BultosValoresRepository.GetByID(oDet.BVA_ID);
                var Bultos = unitOfWork.BultosRepository.GetByID(oRecDet.BLT_NUMERO);
                BO.DAL.dsFactura.FACTURASRow oFactRow = oTable.NewFACTURASRow();
                oFactRow.REC_ID = oRecibo.NUM_REC;
                var oTipoDoc = unitOfWork.TiposRepository.GetByID(oRecibo.TIPO_REC_ID);
                oFactRow.REC_TIPO = oTipoDoc.TIPO_CODIGO;
                oFactRow.REC_TIPO_DESC = oTipoDoc.TIPO_DESCR;
                oFactRow.REMITENTE = Bultos.REMITENTE;
                if (Bultos.Clientes.CTE_CEDULA == null)
                    oFactRow.RNC = Bultos.Clientes.CTE_RNC;
                else
                {
                    if (Bultos.Clientes.CTE_CEDULA.TrimEnd() == "")
                        oFactRow.RNC = Bultos.Clientes.CTE_RNC;
                    else
                    {
                        oFactRow.RNC = Bultos.Clientes.CTE_CEDULA;
                    }
                }
                oFactRow.BLT_NUMERO = Bultos.BLT_NUMERO;
                oFactRow.CODIGO = oRecDet.Cargos.CAR_DESCRIPCION;
                oFactRow.CONSIGNATARIO = Bultos.DESTINATARIO;
                oFactRow.CONTENIDO = Bultos.CONTENIDO;
                oFactRow.CUENTACLI = Bultos.Clientes.CTE_NUMERO_EPS + " " + Bultos.Clientes.CTE_NOMBRE + " " + Bultos.Clientes.CTE_APELLIDO;
                oFactRow.DIRECCIONCLI = Bultos.Clientes.CTE_DIRECCION_CASA;
                oFactRow.IDENTIFICACION = Bultos.BLT_CODIGO_BARRA;
                oFactRow.MONTO = oRecDet.MONTO_LOCAL;
                oFactRow.NCF = oRecibo.NUM_FISCAL;
                oFactRow.NCF_TIPO = unitOfWork.TiposRepository.GetByID(Bultos.Clientes.CTE_TIPO_FISCAL).TIPO_DESCR;
                oFactRow.PESO = Bultos.BLT_PESO.ToString();
                oFactRow.PIEZAS = Bultos.BLT_PIEZAS.ToString();
                oFactRow.PRODUCTO = Bultos.Productos.PRO_CODIGO + " " + Bultos.Productos.PRO_DESCRIPCION;
                oFactRow.REC_CREDITO = oRecibo.REC_CREDITO == false ? "N" : "S";
                oFactRow.REC_FECHA = oRecibo.FECHA.ToShortDateString();
                oFactRow.SUCURSAL = Bultos.Sucursales.SUC_DESCRIPCION;
                oFactRow.ITBIS = oRecDet.Cargos.CAR_ITBIS;
                oFactRow.MONTO_ITEBIS = oRecDet.MONTO_ITBIS;
                oFactRow.MONTO_TOTAL = oRecDet.MONTO_TOTAL;
                oFactRow.TASA_ITBIS = oRecDet.Cargos.ITBIS;
                oFactRow.USUARIO = oRecibo.USER_CREA;
                oFactRow.TIPO_FISCAL = unitOfWork.NumeroFicalRepository.Get(xy => xy.TIPO_ID == Bultos.Clientes.CTE_TIPO_FISCAL).FirstOrDefault().TIPO_FISCAL;
                if (oRecDet.Cargos.CAR_CODIGO == "010")
                {
                    var BultosValores = unitOfWork.BultosValoresRepository.Get(filter: xy => xy.BLT_NUMERO == oRecDet.BLT_NUMERO && xy.CargosProducto.Cargos.CAR_CODIGO == "010").FirstOrDefault();
                    oFactRow.TARIFA = BultosValores.BVA_MONTO_APLICAR;
                }
                oFactRow.TELEFONO = "NA";
                oFactRow.TELEFONOCLI = Bultos.Clientes.CTE_TELEFONO_CASA;
                oFactRow.TRACKING = Bultos.BLT_TRACKING_NUMBER;
                oFactRow.CANT_ELEMENTOS = iCantElementos;
                oTable.Rows.Add(oFactRow);
            }

            return oTable;
        }

        public BO.DAL.dsFactura.FACTURASDataTable CargarDataSetFiscal(int piReciboId)
        {
            string sNCF_ANUL = "";
            BO.DAL.dsFactura.FACTURASDataTable oTable = new BO.DAL.dsFactura.FACTURASDataTable();
            var oRecibo = unitOfWork.RecibosRepository.GetByID(piReciboId);
            var oReciboAnul = unitOfWork.RecibosRepository.GetByID(oRecibo.RECIBO_ID_ANUL);
            if (oReciboAnul != null)
                sNCF_ANUL = oReciboAnul.NUM_FISCAL;
            var oRecibosDet = unitOfWork.RecibosDetRepository.Get(filter: xy => xy.RECIBO_ID == oRecibo.RECIBO_ID);
            int iCantElementos = 0;
            var elementos = from p in oRecibosDet
                            select new { p.BLT_NUMERO };
            iCantElementos = elementos.Distinct().Count();
            int iBltNumero = -1;
            decimal dTarifa = 1;
            foreach (var oRecDet in oRecibosDet)
            {
                //var BultosValores = unitOfWork.BultosValoresRepository.GetByID(oDet.BVA_ID);
                var Bultos = unitOfWork.BultosRepository.GetByID(oRecDet.BLT_NUMERO);
                BO.DAL.dsFactura.FACTURASRow oFactRow = oTable.NewFACTURASRow();
                /*DEBE IR CON EL SECUENCIAL DE RECIBOS*/ 
                oFactRow.REC_ID = oRecibo.NUM_REC;
                var oTipoDoc = unitOfWork.TiposRepository.GetByID(oRecibo.TIPO_REC_ID);
                oFactRow.REC_TIPO = oTipoDoc.TIPO_CODIGO;
                oFactRow.REC_TIPO_DESC = oTipoDoc.TIPO_DESCR;
                oFactRow.REMITENTE = Bultos.REMITENTE;
                if (Bultos.Clientes.CTE_TIPO_FISCAL == 44 || Bultos.Clientes.CTE_TIPO_FISCAL == 45)      //Empresa
                {
                    if (Bultos.Clientes.CTE_RNC.KeepOnlyNumbers().TrimEnd() != string.Empty)
                        oFactRow.RNC = Bultos.Clientes.CTE_RNC.KeepOnlyNumbers().ToString().TrimEnd();
                    else
                        oFactRow.RNC = Bultos.Clientes.CTE_CEDULA.KeepOnlyNumbers().ToString().TrimEnd();
                }
                else
                {
                    if (Bultos.Clientes.CTE_CEDULA.KeepOnlyNumbers().Trim() != string.Empty)
                        oFactRow.RNC = Bultos.Clientes.CTE_CEDULA.KeepOnlyNumbers().ToString().TrimEnd();
                    else if (Bultos.Clientes.CTE_RNC.Trim() != string.Empty)
                        oFactRow.RNC = Bultos.Clientes.CTE_RNC;
                    else
                        oFactRow.RNC = Bultos.Clientes.CTE_PASAPORTE;
                }
                if (iBltNumero != Bultos.BLT_NUMERO)
                {
                    var BultosValores = unitOfWork.BultosValoresRepository.Get(filter: xy => xy.BLT_NUMERO == oRecDet.BLT_NUMERO && xy.CargosProducto.Cargos.CAR_CODIGO == "010").FirstOrDefault();
                    if (BultosValores != null)
                    {
                        dTarifa = BultosValores.BVA_MONTO_APLICAR;
                    }
                    else
                        dTarifa = 1;

                    iBltNumero = Bultos.BLT_NUMERO;
                }
                oFactRow.TARIFA = dTarifa;
                oFactRow.BLT_NUMERO = Bultos.BLT_NUMERO;
                oFactRow.CODIGO = oRecDet.Cargos.CAR_DESCRIPCION;
                oFactRow.CONSIGNATARIO = Bultos.DESTINATARIO;
                oFactRow.CONTENIDO = Bultos.CONTENIDO;
                oFactRow.CUENTACLI = Bultos.Clientes.CTE_NUMERO_EPS.TrimEnd() + " " + Bultos.Clientes.CTE_NOMBRE + " " + Bultos.Clientes.CTE_APELLIDO;
                oFactRow.DIRECCIONCLI = Bultos.Clientes.CTE_DIRECCION_CASA;
                oFactRow.IDENTIFICACION = Bultos.BLT_CODIGO_BARRA;
                oFactRow.MONTO = oRecDet.MONTO_LOCAL;
                oFactRow.NCF = oRecibo.NUM_FISCAL;
                oFactRow.NCF_TIPO = unitOfWork.TiposRepository.GetByID(Bultos.Clientes.CTE_TIPO_FISCAL).TIPO_DESCR;
                oFactRow.PESO = Bultos.BLT_PESO.ToString();
                oFactRow.PIEZAS = Bultos.BLT_PIEZAS.ToString();
                oFactRow.PRODUCTO = Bultos.Productos.PRO_CODIGO + " " + Bultos.Productos.PRO_DESCRIPCION;
                oFactRow.REC_CREDITO = oRecibo.REC_CREDITO == false ? "N" : "S";
                oFactRow.REC_FECHA = oRecibo.FECHA.ToShortDateString();
                oFactRow.SUCURSAL = Bultos.Sucursales.SUC_CODIGO;

                if (Bultos.Clientes.CTE_TIPO_FISCAL == 45) /*regimenes especiales*/
                {
                    oFactRow.ITBIS = false;
                    oFactRow.TASA_ITBIS = 0;
                }
                else
                {
                    oFactRow.ITBIS = oRecDet.Cargos.CAR_ITBIS;
                    oFactRow.TASA_ITBIS = oRecDet.Cargos.ITBIS;
                }
                oFactRow.MONTO_ITEBIS = oRecDet.MONTO_ITBIS;
                oFactRow.MONTO_TOTAL = oRecDet.MONTO_TOTAL;
                
                oFactRow.USUARIO = oRecibo.USER_CREA;
                if (oRecibo.TIPO_REC_ID == 5)
                    oFactRow.TIPO_FISCAL = 3; //Hay que buscar otra manera. Esto es para la anulacion qu esta por fuera del cliente.
                else
                    oFactRow.TIPO_FISCAL = unitOfWork.NumeroFicalRepository.Get(xy => xy.TIPO_ID == Bultos.Clientes.CTE_TIPO_FISCAL).FirstOrDefault().TIPO_FISCAL;
                oFactRow.TELEFONO = "NA";
                oFactRow.TELEFONOCLI = Bultos.Clientes.CTE_TELEFONO_CASA;
                oFactRow.TRACKING = Bultos.BLT_TRACKING_NUMBER;
                oFactRow.CANT_ELEMENTOS = iCantElementos;
                oFactRow.NCF_AFECTADO = sNCF_ANUL;
                oFactRow.ENTREGADO_A = Bultos.Clientes.CTE_NOMBRE;

                if (oRecDet.Cargos.CAR_CODIGO == "093") //Descuento a fuego
                    oFactRow.DESCUENTO = true;
                else
                    oFactRow.DESCUENTO = false;


                oTable.Rows.Add(oFactRow);

                
            }
            return oTable;
        }

        public DataTable CargarDataSetPagos(int piMovCajaId)
        {
            BO.DAL.dsFactura.MOVCAJADataTable oTable = new BO.DAL.dsFactura.MOVCAJADataTable();
            var oRecibo = unitOfWork.MovCajaRepository.GetByID(piMovCajaId);
            var oRecibosDet = unitOfWork.MovCajaRecibosRepository.Get(filter: xy => xy.MOVCAJA_ID == piMovCajaId);
            foreach (var oRecDet in oRecibosDet)
            {
                //var BultosValores = unitOfWork.BultosValoresRepository.GetByID(oDet.BVA_ID);
                // var Bultos = unitOfWork.BultosRepository.GetByID(oRecDet.BLT_NUMERO);
                BO.DAL.dsFactura.MOVCAJARow oFactRow = oTable.NewMOVCAJARow();
                oFactRow.MOVCAJA_ID = oRecibo.MOV_CAJA_SEC;
                oFactRow.TIP_MOV = unitOfWork.TiposRepository.GetByID(oRecibo.TIP_MOV).TIPO_CODIGO;
                oFactRow.RNC = "NA";
                oFactRow.CUENTACLI = oRecibo.Clientes.CTE_NUMERO_EPS + " " + oRecibo.Clientes.CTE_NOMBRE + " " + oRecibo.Clientes.CTE_APELLIDO;
                oFactRow.DIRECCIONCLI = oRecibo.Clientes.CTE_DIRECCION_CASA;
                oFactRow.IMPORTE = oRecibo.IMPORTE;
                oFactRow.FECHA = oRecibo.FECHA.ToShortDateString();
                oFactRow.SUCURSAL = oRecibo.Sucursales.SUC_DESCRIPCION;
                oFactRow.TELEFONO = "NA";
                oFactRow.TELEFONOCLI = oRecibo.Clientes.CTE_TELEFONO_CASA;
                oFactRow.RECIBO_ID = oRecDet.RECIBO_ID;
                oFactRow.REC_TIPO = unitOfWork.TiposRepository.GetByID(oRecDet.Recibos.TIPO_REC_ID).TIPO_CODIGO + "-" +
                                unitOfWork.TiposRepository.GetByID(oRecDet.Recibos.TIPO_REC_ID).TIPO_NOMBRE;
                oFactRow.IMPORTE_PAGADO = oRecDet.IMPORTE_PAGADO;
                oTable.Rows.Add(oFactRow);
            }
            return oTable;
        }

        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);
            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);
            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);
            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);
            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public void Dispose()
        {
             if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                stream.Close();
                m_streams = null;
            }
        }
    }
}
