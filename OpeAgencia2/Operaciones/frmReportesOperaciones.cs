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

namespace OpeAgencia2.Operaciones
{
    public partial class frmReportesOperaciones : Form
    {
        public frmReportesOperaciones()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        private void button2_Click(object sender, EventArgs e)
        {
            // dsFacturaBindingSource.DataSource = CargarDataSet();
            DataSet dsFacturas = new DataSet();
            DataTable dt = new DataTable();
            dt = CargarDatos();
            dt.TableName = "INVENTARIO";
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay estados para imprimir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            dsFacturas.Tables.Add(dt);
            LocalReport report = new LocalReport();
            report.ReportPath = @".\Reportes\rInventariordlc.rdlc";
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            report.SetParameters(new ReportParameter("Fecha", DateTime.Now.ToShortDateString()));
            //report.SetParameters(new ReportParameter("Hora", DateTime.Now.ToShortDateString()));
            //report.SetParameters(new ReportParameter("Sucursal", dt.Rows[0]["SUCURSAL"].ToString()));
            //report.SetParameters(new ReportParameter("Factura", dt.Rows[0]["REC_TIPO"].ToString() + "-" + dt.Rows[0]["REC_ID"].ToString()));
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


        DataTable CargarDatos()
        {
            BO.DAL.dsReportes.INVENTARIODataTable oTable = new BO.DAL.dsReportes.INVENTARIODataTable();

            var Bultos = from p in unitOfWork.BultosRepository.Get(filter: xy => xy.BLT_ESTADO_ID == 2
                              && xy.SUC_ID == Parametros.Parametros.SucursalActual)
                          orderby (p.BLT_NUMERO)
                         select new { p.BLT_NUMERO, p.BLT_CODIGO_BARRA, p.Clientes.CTE_NUMERO_EPS, p.Clientes.CTE_NOMBRE, p.Clientes.CTE_APELLIDO, 
                                      p.CONTENIDO, p.REMITENTE, p.DESTINATARIO, p.BLT_FECHA_RECEPCION, p.Productos.PRO_DESCRIPCION, p.BLT_PESO};



            foreach (var Reg in Bultos)
            {
              
                BO.DAL.dsReportes.INVENTARIORow oRow = oTable.NewINVENTARIORow();
                oRow.BLT_NUMERO = Reg.BLT_NUMERO;
                oRow.CUENTA =Reg.CTE_NUMERO_EPS.ToString().TrimEnd() + "-" + Reg.CTE_NOMBRE.TrimEnd() + " " + Reg.CTE_APELLIDO.TrimEnd();
                oRow.DIAS = DateTime.Now.Date.Subtract(Reg.BLT_FECHA_RECEPCION).Days;
                oRow.BLT_CODIGO_BARRA = Reg.BLT_CODIGO_BARRA;
                oRow.FECHA_RECIBIDO = Reg.BLT_FECHA_RECEPCION.ToString();
                oRow.CONTENIDO = Reg.CONTENIDO;
                oRow.REMITENTE = Reg.REMITENTE;
                oRow.DESTINATARIO = Reg.DESTINATARIO;
                oRow.PESO = Reg.BLT_PESO;
                oRow.PRODUCTO = Reg.PRO_DESCRIPCION;
              
               
                oTable.Rows.Add(oRow);
            }
            return oTable;
        }
    }
}
