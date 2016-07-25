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






namespace OpeAgencia2.Facturacion
{
    public partial class frmImpFactura : Form
    {
        public frmImpFactura()
        {
            InitializeComponent();
        }


        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void button1_Click(object sender, EventArgs e)
        {

            
            

        }

        private int m_currentPageIndex;
        private IList<Stream> m_streams;



        public DataTable CargarDataSet()
        {
            BO.DAL.dsFactura.FACTURASDataTable oTable = new BO.DAL.dsFactura.FACTURASDataTable();

            var oRecibo = unitOfWork.RecibosRepository.GetByID(13);

      
            var oReciboDet = unitOfWork.RecibosDetRepository.Get(filter: xy => xy.RECIBO_ID == oRecibo.RECIBO_ID);

            foreach (var oDet in oReciboDet)
            {
                //var BultosValores = unitOfWork.BultosValoresRepository.GetByID(oDet.BVA_ID);
                /*
                var Bultos = unitOfWork.BultosRepository.GetByID(BultosValores.BLT_NUMERO);

                BO.DAL.dsFactura.FACTURASRow oFactRow = oTable.NewFACTURASRow();


                oFactRow.REC_ID = oRecibo.RECIBO_ID;
                oFactRow.REC_TIPO = unitOfWork.TiposRepository.GetByID(oRecibo.TIPO_REC_ID).TIPO_CODIGO;
                oFactRow.REMITENTE = Bultos.REMITENTE;
                oFactRow.RNC = "NA";
                oFactRow.BLT_NUMERO = BultosValores.BLT_NUMERO;
                oFactRow.CODIGO = BultosValores.CargosProducto.Cargos.CAR_DESCRIPCION;
                oFactRow.CONSIGNATARIO = Bultos.DESTINATARIO;
                oFactRow.CONTENIDO = Bultos.CONTENIDO;
                oFactRow.CUENTACLI = Bultos.Clientes.CTE_NUMERO_EPS + " " + Bultos.Clientes.CTE_NOMBRE + " " + Bultos.Clientes.CTE_APELLIDO;
                oFactRow.DIRECCIONCLI = Bultos.Clientes.CTE_DIRECCION_CASA;
                oFactRow.IDENTIFICACION = Bultos.BLT_CODIGO_BARRA;
                oFactRow.MONTO = BultosValores.BVA_MONTO_LOCAL;
                oFactRow.NCF = "NA";
                oFactRow.NCF_TIPO = unitOfWork.TiposRepository.GetByID(Bultos.Clientes.CTE_TIPO_FISCAL).TIPO_NOMBRE;
                oFactRow.PESO = Bultos.BLT_PESO.ToString();
                oFactRow.PIEZAS = Bultos.BLT_PIEZAS.ToString();
                oFactRow.PRODUCTO = Bultos.Productos.PRO_CODIGO + " " + Bultos.Productos.PRO_DESCRIPCION;
                oFactRow.REC_CREDITO = "NA";
                oFactRow.REC_FECHA = oRecibo.FECHA.ToShortDateString();
                oFactRow.SUCURSAL = Bultos.Sucursales.SUC_DESCRIPCION;
                oFactRow.TARIFA = 0;
                oFactRow.TELEFONO = "NA";
                oFactRow.TELEFONOCLI = Bultos.Clientes.CTE_TELEFONO_CASA;
                oFactRow.TRACKING = Bultos.BLT_TRACKING_NUMBER;

                oTable.Rows.Add(oFactRow);
                */
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

            private Stream CreateStream(string name,
         string fileNameExtension, Encoding encoding,
         string mimeType, bool willSeek)
            {
                Stream stream = new MemoryStream();
                m_streams.Add(stream);
                return stream;
            }


        private void frmImpFactura_Load(object sender, EventArgs e)
        {

           // dsFacturaBindingSource.DataSource = CargarDataSet();
            DataSet dsFacturas = new DataSet();
            DataTable dt = new DataTable();
            dt = CargarDataSet();
            dt.TableName ="FACTURAS";
            //dsFacturas.Tables.Add(dt);


            

            LocalReport report = new LocalReport();
            report.ReportPath = @".\Reportes\rFactura.rdlc";

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
           
            /*
            report.DataSources.Add(
               new ReportDataSource("Sales", LoadSalesData()));
             */ 


            Export(report);
            Print();


            //this.reportViewer1.RefreshReport();

          
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

    
       

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }


    }
}
