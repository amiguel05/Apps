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
using ImpresoraFiscal;
using System.Diagnostics;
using System.IO;

namespace OpeAgencia2.Facturacion
{
    public partial class frmManejadorImpresora : Form
    {
        Printer oPrinter;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Terminal oTerm = new BO.Models.Terminal();
        private BO.DAL.dsFactura.FACTURASDataTable oFactura;
        private BO.DAL.dsDatos.DatosPagoDataTable oDatosPago;

        public frmManejadorImpresora()
        {
            InitializeComponent();
            oTerm = unitOfWork.TerminalRepository.GetByID(Parametros.ParametrosSucursal.TermFiscalId);
            oPrinter = new Printer(oTerm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var response = oPrinter.Connect();
            LlenarDatosImpresora();
            ActualizarEstadoPuerto(response == (uint)PrinterResponses.Success);
        }

        void LlenarDatosImpresora()
        {
            txtModoOperacion.Text = oPrinter.GetCountryId();
            txtModeloImpresora.Text = oPrinter.GetPrintingMechanism();
            txtNombreImpresora.Text = oPrinter.GetPrintingMechanismName();
            lblPuerto.Text = oPrinter.GetPort();
        }

        public void ActualizarEstadoPuerto(bool conectado)
        {
            lblEstado.Text = conectado ?
                @"Puerto actualmente conectado" : @"Puerto actualmente desconectado";
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            var response = oPrinter.Disconnect();
            ActualizarEstadoPuerto(false);
            LimpiarCampos();
        }

        void LimpiarCampos()
        {
            txtModoOperacion.Text = "";
            txtModeloImpresora.Text = "";
            txtNombreImpresora.Text = "";
            lblPuerto.Text = "";
        }

        private void cbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFactura.Enabled = (cbOperacion.SelectedIndex != 0 && cbOperacion.SelectedIndex != 2);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (cbOperacion.SelectedIndex)
            {
                case 0:
                    oPrinter.PrinteLastFiscalReceipt();
                    break;
                case 1:
                    GenerarDocumento(1);
                    break;
                case 2:
                    oPrinter.CancelLastFiscalReceipt();
                    break;
                case 3:
                    GenerarDocumento(2);
                    break;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            switch (cbTipoReporte.SelectedIndex)
            {
                case 0:
                    oPrinter.GetReportZ(1);
                    break;
                case 1:
                    oPrinter.GetReportZ(2);
                    break;
                case 2:
                    oPrinter.GetReportClosureZ(0, txtDesde.Text, txtHasta.Text,
                        cbFiltrarPor.SelectedIndex + 1);
                    break;
                case 3:
                    oPrinter.GetReportX();
                    break;

            }
        }

        private void ActualizarPuertoLibroVenta()
        {
            var ruta = Path.Combine(@"C:\AppLibroVenta_RD", "LibroVenta.ini");
            File.WriteAllLines(ruta,
                 File.ReadAllLines(ruta)
                     .Select(x =>
                     {
                         if (x.StartsWith("PUERTO=")) return "PUERTO=" + oTerm.PUERTO;
                         return x;
                     }));
        }

        private void AbrirAplicacionLibroZ()
        {
            ActualizarPuertoLibroVenta();
            var p = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(@"C:\AppLibroVenta_RD", "epsLibroVenta.exe"),
                    Arguments = "/c dir *.cs",
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    Verb = "runas"
                }
            };
            p.Start();
        }

        private void GenerarDocumento(int tipo)
        {
            //ImprimirFactura imprimirFactura = new ImprimirFactura();
            //var stuff = txtFactura.Text.Split('-');
            //oFactura = imprimirFactura.CargarDataSetFiscal(Convert.ToInt32(stuff[2]));
            //oDatosPago = unitOfWork.DatosPagoRepository.Get(filter: s => s.)
            //oPrinter.SetInvoiceData()
            //factura.AddFACTURASRow()
            //BO.DAL.dsFactura.FACTURASRow factura = new BO.DAL.dsFactura.FACTURASRow();
            //factura = unitOfWork.
            //unitOfWork.
            //   f
            //oPrinter.SetInvoiceData()

            //var numFactura = txtFactura.Value.ToString().Split('-');
            //if (numFactura[0].Equals("nc40", StringComparison.CurrentCultureIgnoreCase) ||
            //    numFactura[0].Equals("bal2", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    SetearDocumentoFiscalCxc(numFactura[0], numFactura[1], numFactura[2]);
            //}
            //else
            //{
            //    _datosFactura = numFactura[0].Equals("nc01", StringComparison.CurrentCultureIgnoreCase)
            //        ? facturaServ.ObtenerDatosDevolucion(numFactura[0], numFactura[1], numFactura[2])
            //        : facturaServ.ObtenerDatosFactura(numFactura[0], numFactura[1], numFactura[2]);

            //    if (_datosFactura == null) return;

            //    Clientes cliente;
            //    using (var clienteServ = new ClientesWrapper())
            //    {
            //        cliente = clienteServ.ObtenerClientePorEPSID(_datosFactura.CteNumeroEps, 2);
            //    }
            //    List<DesglosePago> desglosePagos = null;
            //    if (numFactura[0].Equals("nc01",
            //        StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        desglosePagos = facturaServ.ObtenerPagosFactura(new Facturas
            //        {
            //            DocCodigo = _datosFactura.DocCodigoAfectado,
            //            FacCodigo = _datosFactura.DocNumeroAfectado,
            //            SucCodigo = _datosFactura.SucCodigoAfectado
            //        }).ToList();
            //        desglosePagos.ForEach(a =>
            //        {
            //            a.FacCodigo = _datosFactura.FacCodigo;
            //            a.DocCodigo = _datosFactura.DocCodigo;
            //            a.SucCodigo = _datosFactura.SucCodigo;
            //        });
            //    }
            //    else
            //    {
            //        desglosePagos = facturaServ.ObtenerPagosFactura(_datosFactura).ToList();


            //    }
            //    if (_datosFactura.DocCodigo.Equals("ft08", StringComparison.OrdinalIgnoreCase) ||
            //        _datosFactura.DocCodigo.Equals("ft07", StringComparison.OrdinalIgnoreCase) ||
            //        _datosFactura.DocCodigo.Equals("ft92", StringComparison.OrdinalIgnoreCase)
            //        || _datosFactura.DocCodigo.Equals("ft91", StringComparison.OrdinalIgnoreCase) ||
            //        _datosFactura.DocCodigoAfectado.Equals("ft08", StringComparison.OrdinalIgnoreCase) ||
            //        _datosFactura.DocCodigoAfectado.Equals("ft07", StringComparison.OrdinalIgnoreCase) ||
            //        _datosFactura.DocCodigoAfectado.Equals("ft92", StringComparison.OrdinalIgnoreCase)
            //        || _datosFactura.DocCodigoAfectado.Equals("ft91", StringComparison.OrdinalIgnoreCase))
            //    {
            //        _datosFactura.FacItbis = _configuracion.CfgItbis;
            //        if (_datosFactura.DocCodigo.Equals("ft92", StringComparison.OrdinalIgnoreCase))
            //            _datosFactura.FacTotal =
            //                (_datosFactura.FacTotal / ((_datosFactura.FacItbis / 100) + 1)).ToDecimalValue();
            //    }


            //    var cargos = numFactura[0].Equals("nc01", StringComparison.CurrentCultureIgnoreCase)
            //        ? facturaServ.ObtenerCargosFactura(_datosFactura, 2).ToList()
            //        : facturaServ.ObtenerCargosFactura(_datosFactura).ToList();
            //    if (numFactura[0].Equals("nc01", StringComparison.CurrentCultureIgnoreCase) &&
            //        (_datosFactura.DocCodigoAfectado == "FT08" || _datosFactura.DocCodigoAfectado == "FT07"))
            //    {
            //        cargos.ForEach(a =>
            //        {

            //            a.MontoLocal = a.MontoLocal.ToDecimalValue() + Math.Round(
            //                (Math.Abs(a.MontoLocal.ToDecimalValue()) *
            //                    (_datosFactura.FacItbis.ToDecimalValue() / 100)), 2, MidpointRounding.ToEven);

            //        });
            //    }
            //    _printer.SetInvoiceData(_datosFactura,
            //    numFactura[0].Equals("nc01", StringComparison.CurrentCultureIgnoreCase)
            //        ? facturaServ.ObtenerDetalleBultosFactura(_datosFactura, 3)
            //        : facturaServ.ObtenerDetalleBultosFactura(_datosFactura),
            //    cargos, cliente, desglosePagos
            //    , true);
            //}

            //if (tipo == 1)
            //    _printer.Print(this);
            //else
            //    _printer.PrintNoFiscalReceipt(this);
        }

        private void cbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbFiltro.Enabled = cbTipoReporte.SelectedIndex == 2;
        }
    }
}
