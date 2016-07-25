using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VmaxCom;

namespace ImpresoraFiscal
{
  public class FiscalPrinterWrapper : IPrinter
    {
        private readonly VmaxComClass _objVmax;
        private FiscalPrinter _printer;
        public string CountryId { get;private set; }
        public string PrintingMechanism { get; private set; }
        public string PrintingMechanismName { get; private set; }
        public ushort Port { get; private set; }
        public FiscalPrinterWrapper(ushort port)
        {
            Port = port;
            _objVmax = new VmaxComClass();           
        }

        public uint Connect()
        {
          var response = _objVmax.AbrirPuerto(Port);
           ConfiguratePrinterModeOperation(2);
           GetFiscalSpecifications();
          return response;

        }

        private void ConfiguratePrinterModeOperation(ushort mode)
        {
          var response= _objVmax.ConfigModoOperacion(mode);
        }
        private void InitializePrinter()

        {
            //if (PrintingMechanism.Equals("TSP650FP"))
            _printer = new TSP650FPrinter(_objVmax);
            
        }
        private void GetFiscalSpecifications()
        {
            _objVmax.ObtenerCaracteristicasFiscales();
            PrintingMechanism = _objVmax.idMecanismoImpresion;
            PrintingMechanismName = _objVmax.nombreMecanismoImpresion;
            CountryId = _objVmax.idPais;

        }

        public PrinterResponses CancelFiscalReceipt()
        {
            GetFiscalSpecifications();
            if (_printer == null)
            {
                InitializePrinter();
            }
            if (CountryId == string.Empty)
            {
                if (Connect() != (uint)PrinterResponses.Success)
                    return PrinterResponses.OpeningPortError;
            }
            var response =  _printer.CancelFiscalReceipt();
        
            return response;
        }

        public PrinterResponses PrintNoFiscalReceipt(IEnumerable<string> lines, bool disconnectOnFinish = true)
        {
            GetFiscalSpecifications();
            if (_printer == null)
            {
                InitializePrinter();
            }
            if (CountryId == string.Empty)
            {
                if (Connect() != (uint)PrinterResponses.Success)
                    return PrinterResponses.OpeningPortError;
            }
            var response = _printer.PrintNoFiscalReceipt(lines);
           if (disconnectOnFinish)
               Disconnect();
           return response;
        }

        public PrinterResponses GetReportZ(uint tipo)
        {
            if (_printer == null)
                InitializePrinter();
                Connect();
            return _printer == null ? PrinterResponses.GettingReportZError : _printer.GenerateReportZ(tipo);
        }

        public PrinterResponses GetReportX()
        {
            if (_printer == null)
                InitializePrinter();
            Connect();
            return _printer == null ? PrinterResponses.GettingReportZError : _printer.GenerateReportX();
        }

        public PrinterResponses GetReportClosureZ(int tipo, string from, string to, int reportType)
        {
            if (_printer == null)
                InitializePrinter();
                Connect();
            if (_printer == null)
                return PrinterResponses.GettingReportClosureZError;
            _printer.GenerateClosureZ(tipo,from,to,reportType);
            return PrinterResponses.Success;
        }

        public PrinterResponses PrinteLastFiscalReceipt()
        {
            if (_printer == null)
                InitializePrinter();
                Connect();
            return _printer==null?PrinterResponses.PrintingLastReciptError: _printer.PrinteLastFiscalReceipt();
        }

        public uint Disconnect()
        {
            var response = _objVmax.CerrarPuerto();
            _printer = null;
            return response;
        }

        public virtual void AvanzarPapel(ushort quantity)
        {
            _printer.FeedPaper(quantity);
        }

        public PrinterResponses Print(Invoice invoice, uint numOfCopies,bool disconnectOnFinish=true)
        {
            GetFiscalSpecifications();
            if (_printer == null)
            {
                InitializePrinter();
            }
            if (CountryId == string.Empty)
                {
                    if (Connect() != (uint) PrinterResponses.Success)
                        return PrinterResponses.OpeningPortError;
                }

            
            //if (string.IsNullOrEmpty(PrintingMechanism))
            //    return PrinterResponses.GettingPrinterSettingsError;
            var response = _printer.Print(invoice, numOfCopies);
            if (disconnectOnFinish)
                Disconnect();
             return response;
          
        }
    }
}

