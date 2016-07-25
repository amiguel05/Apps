using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace OpeAgencia2
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        //LocalReport report;
        DataTable dt = new DataTable();
        string sReportPath = "";

        string sTitulo = "";

        LocalReport _Report;

        public frmReportViewer(string psReportPath, DataTable pDt)
        {
            InitializeComponent();

            sReportPath = psReportPath;
            dt = pDt;
        }

        public frmReportViewer(LocalReport oReport)
        {
            InitializeComponent();

            _Report = oReport;
        }

        public frmReportViewer(string psReportPath, DataTable pDt, string psTitulo)
        {
            InitializeComponent();

            sReportPath = psReportPath;
            dt = pDt;
            sTitulo = psTitulo;
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {

            if (_Report == null)
            {
                this.reportViewer1.LocalReport.ReportPath = sReportPath; //sReportPath;

                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Encabezado1", Parametros.ParametrosSucursal.EncabezadoFactura1));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Encabezado2", Parametros.ParametrosSucursal.EncabezadoFactura2));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Encabezado3", Parametros.ParametrosSucursal.EncabezadoFactura3));

                if (sTitulo != "")
                {
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Titulo", sTitulo));
                }

                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                this.reportViewer1.LocalReport.Refresh();

                this.reportViewer1.RefreshReport();
                this.reportViewer1.RefreshReport();

            }
            else
            {
                //****************************
                //assign report Path
                reportViewer1.LocalReport.ReportPath = _Report.ReportPath;
                //****************************

                //****************************
                //assign data-sources
                foreach (ReportDataSource MyDS in _Report.DataSources)
                    reportViewer1.LocalReport.DataSources.Add(MyDS);
                //****************************

                //****************************
                //Assign parameters 

                //get a list of actual parameters in the report, with the actual assigned value
                ReportParameterInfoCollection MyOrigParams = _Report.GetParameters(); //I didn't find simpler way to fetch params...

                //create a List of parameter [to feed the reportViewer]
                List<ReportParameter> MyListOfPArams = new List<ReportParameter>();

                //for each params found through GetParameters(), add it to the List<> of params
                for (int i = 0; i < MyOrigParams.Count; i++)
                    MyListOfPArams.Add(new ReportParameter(MyOrigParams[i].Name, MyOrigParams[i].Values[0]));

                //final assignation of the parameters
                reportViewer1.LocalReport.SetParameters(MyListOfPArams);
                //****************************


                //show the report
                reportViewer1.RefreshReport();
            }

        }



    }
}
