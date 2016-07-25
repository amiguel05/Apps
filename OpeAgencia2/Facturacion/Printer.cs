using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpresoraFiscal;
using AgenciaEF_BO.Models;
using AgenciaEF_BO.DAL;
using BO = AgenciaEF_BO;
using clsUtils;

namespace OpeAgencia2.Facturacion
{
    public class Printer
    {
        private readonly FiscalPrinterWrapper _fiscalPrinterWrapper;
        private Invoice _invoice;
        private dsFactura.FACTURASDataTable _factura;
        //private IEnumerable<CargoPaquete> _cargos;
        //private IEnumerable<DesglosePago> _desglosePagos;
        private dsDatos.DatosPagoDataTable _desglosePagos;
        //private Clientes _cliente;
        private IEnumerable<Payment> _payments;
        private IEnumerable<Item> _items;
        private List<string> _linesNoFiscalReceipt;
        private bool _isReimpresion;
        private int _numeroCopias;
        private readonly Terminal _terminal;
        private bool _isinvoiceCxc;
        private decimal _MontoTotalFactura;
        //private CxcDetalle _cxcDetials;



        public Printer(Terminal terminal)
        {
            _terminal = terminal;
            if (_terminal == null)
                return;

            _fiscalPrinterWrapper = new FiscalPrinterWrapper(Convert.ToUInt16(_terminal.PUERTO));
            //Connect();
        }



        public void SetInvoiceData(dsFactura.FACTURASDataTable factura,
            dsDatos.DatosPagoDataTable desglosePagos = null,
            bool isReimpresion = false, int numeroCopias = 0, bool esFacturaCxc = false)
        {

            _factura = factura;
            _desglosePagos = desglosePagos;
            _isReimpresion = isReimpresion;
            _numeroCopias = numeroCopias;
            _isinvoiceCxc = esFacturaCxc;
        }


        private static string GetFiscalInvoiceTypeDescripcion(string invoiceDocumentCode)
        {
            var descripcion = invoiceDocumentCode.StartsWith("NC", StringComparison.OrdinalIgnoreCase) ? "Devolucion" : "Factura";
            return descripcion;
        }

        private void AddItems()
        {
            var items = new List<Item>();
            int ibltnumero = -1;

            /*
             *     cargo.Descuento != null && cargo.Descuento.Equals("s", StringComparison.OrdinalIgnoreCase)
                                ? ItemTypes.DiscountPerItem
                                : ItemTypes.SalesItem
             */

            string[] sDescAdicional;
            sDescAdicional = new[] { " " };


            ibltnumero = Convert.ToInt32(_factura.Rows[0]["BLT_NUMERO"]);
            int i = 0, j = 0;
            decimal dSubTotal = 0;
            foreach (BO.DAL.dsFactura.FACTURASRow oRow in (BO.DAL.dsFactura.FACTURASDataTable)_factura)
            {
                if (i == 0)
                    ibltnumero = oRow.BLT_NUMERO;

                i++;

                if (ibltnumero == oRow.BLT_NUMERO)
                {
                    var itemsBulto =
                     new Item
                     {
                         Description = oRow.CODIGO,
                         Quantity = 1,
                         Rate = oRow.TASA_ITBIS,
                         Price = System.Math.Round(Math.Abs(oRow.MONTO_TOTAL), 2, MidpointRounding.ToEven),
                         Type = (oRow.DESCUENTO ? ItemTypes.DiscountPerItem : ItemTypes.SalesItem)
                     };

                    items.Add(itemsBulto);
                    dSubTotal += System.Math.Round(oRow.MONTO_TOTAL,2, MidpointRounding.ToEven);
                    _MontoTotalFactura += System.Math.Round(oRow.MONTO_TOTAL, 2, MidpointRounding.ToEven);

                    sDescAdicional = new[]{
                        "Servicio-" + oRow.PRODUCTO.Trim() + "-",
                        "--Identificacion -" + oRow.IDENTIFICACION,
                        "Tarifa: "+oRow.TARIFA,
                        "Peso: " + oRow.PESO + " - Piezas: "+oRow.PIEZAS,
                        ("Contenido: "+oRow.CONTENIDO).Trim(),
                        "Remitente: "+oRow.REMITENTE,
                        "Destinatario: "+oRow.CONSIGNATARIO,
                        "Tracking No. "+oRow.TRACKING,
                        "TOTAL ITEM :"+Math.Round(dSubTotal, 2, MidpointRounding.ToEven)
                    };
                }
                else
                {
                    string[] aditionalDescriptions;
                    aditionalDescriptions = new[]
                    {
                        "Servicio-" + oRow.PRODUCTO.Trim() + "-",
                        "--Identificacion -" + oRow.IDENTIFICACION,
                        "Tarifa: "+oRow.TARIFA,
                        "Peso: " + oRow.PESO + " - Piezas: "+oRow.PIEZAS,
                        ("Contenido: "+oRow.CONTENIDO).Trim(),
                        "Remitente: "+oRow.REMITENTE,
                        "Destinatario: "+oRow.CONSIGNATARIO,
                        "Tracking No. "+oRow.TRACKING,
                        "TOTAL ITEM :"+Math.Round(dSubTotal, 2, MidpointRounding.ToEven)
                    };

                    items.Add(new Item
                   {
                       AditionalDescriptions = sDescAdicional,
                       Description = "0.00",
                       Price = 0,
                       Rate = 0,
                       Quantity = 1,
                       Type = ItemTypes.SalesItem
                   });
                    j++;
                    ibltnumero = oRow.BLT_NUMERO;
                    dSubTotal = 0;


                    var itemsBulto =
                     new Item
                     {
                         //AditionalDescriptions = aditionalDescriptions,
                         Description = oRow.CODIGO,
                         Quantity = 1,
                         Rate = oRow.TASA_ITBIS,
                         Price = System.Math.Round(Math.Abs(oRow.MONTO_TOTAL), 2, MidpointRounding.ToEven),
                         Type = (oRow.DESCUENTO ? ItemTypes.DiscountPerItem : ItemTypes.SalesItem)
                     };

                    items.Add(itemsBulto);
                    dSubTotal += Math.Round(oRow.MONTO_TOTAL,2, MidpointRounding.ToEven);
                    _MontoTotalFactura += System.Math.Round(oRow.MONTO_TOTAL, 2, MidpointRounding.ToEven);

                }


            }

            if (dSubTotal > 0)
            {


                items.Add(new Item
                {
                    AditionalDescriptions = sDescAdicional,
                    Description = "0.00",
                    Price = 0,
                    Rate = 0,
                    Quantity = 1,
                    Type = ItemTypes.SalesItem
                });

                dSubTotal = 0;
            }

            _items = items;
        }

        private void AddPayments()
        {
            var payments = new List<Payment>();
            if (_desglosePagos == null) return;


            if (_factura.Rows[0]["REC_CREDITO"].ToString() == "S")
                payments.Add(new Payment
                {
                    PaymentMethod = PaymentMethods.OwnCard,
                    Value = _MontoTotalFactura,
                    PaymentType = PaymentTypes.Payment
                });
            else
            {/*  Agregar desglos de pagos
              Cash = 1,  48 1
              Check = 2,  50 2
               CreditCard = 3, 49 3
              */
                bool bEfectivo = false;
                foreach (System.Data.DataRow drpagos in _desglosePagos.Rows)
                {


                    if (Convert.ToDecimal(drpagos["MontoEfectivo"]) > 0 && bEfectivo == false)
                    {

                        payments.Add(new Payment
                          {
                              PaymentMethod = PaymentMethods.Cash,
                              Value = Convert.ToDecimal(_desglosePagos.Rows[0]["MontoEfectivo"]),
                              PaymentType = PaymentTypes.Payment
                          });
                    }


                    if (Convert.ToInt32(drpagos["TipoPago"]) == 50)
                    {
                        payments.Add(new Payment
                        {
                            PaymentMethod = PaymentMethods.Check,
                            Value = Convert.ToDecimal(_desglosePagos.Rows[0]["Importe"]),
                            PaymentType = PaymentTypes.Payment
                        });
                    }
                    else if (Convert.ToInt32(drpagos["TipoPago"]) == 49)
                    {
                        payments.Add(new Payment
                        {
                            PaymentMethod = PaymentMethods.CreditCard,
                            Value = Convert.ToDecimal(_desglosePagos.Rows[0]["Importe"]),
                            PaymentType = PaymentTypes.Payment
                        });
                    }



                }


            }
            _payments = payments;
        }

        private void SetFiscalPrinterData()
        {

            /* if (_isinvoiceCxc)
                 AddItemsCxc();
             else
             {
                 AddItems();
                 AddPayments();
             }*/

            AddItems();
            AddPayments();

            _invoice = new Invoice
            {
                InvoiceType = Convert.ToUInt32(_factura.Rows[0]["TIPO_FISCAL"]),
                Ncf = _factura.Rows[0]["NCF"].ToString(),
                CompanyName = _factura.Rows[0]["CUENTACLI"].ToString(),
                Rnc = _factura.Rows[0]["RNC"].ToString().KeepOnlyNumbers(),
                Items = _items,
                Payments = _payments,
                LogoNumber = 1,
                Subsidiary = "0000", //_terminal.PuntoVenta.PadLeft(4, '0'),
                CashNumber = ((Terminal)_terminal).TERM_ID.ToString().PadLeft(4, '0'),  //.PadLeft(4, '0'),  //_terminal.TermCaja,
                NcfReference = _factura.Rows[0]["NCF_AFECTADO"].ToString(), //ncf afectado''
                Comments = new[]
                    {
                       //_desglosePagos!=null && _desglosePagos.Any(a=>a.DpaTipo=="I")?"RC00":null,
                       // _desglosePagos!=null && _desglosePagos.Any(a=>a.DpaTipo=="R")?"TRANSFERENCIA":null,
                        "Total ITEMS: "+ _factura.Rows[0]["CANT_ELEMENTOS"].ToString(),
                        GetFiscalInvoiceTypeDescripcion(_factura.Rows[0]["REC_TIPO"].ToString()) +": " + _factura.Rows[0]["SUCURSAL"].ToString() + "-" + _factura.Rows[0]["REC_TIPO"].ToString()  + "-" +  _factura.Rows[0]["REC_ID"].ToString() ,
                        _factura.Rows[0]["REC_TIPO_DESC"].ToString() , 
                       _factura.Rows[0]["NCF_TIPO"].ToString(),
                        " ", 
                        " ",
                        "Atendido Por :"+_factura.Rows[0]["USUARIO"].ToString(), 
                        "Entregado a: "+_factura.Rows[0]["ENTREGADO_A"].ToString(),
                        " ",
                        "-------------------------------",
                        "Cliente :"+ _factura.Rows[0]["CUENTACLI"].ToString(),
                        " ",
                        "    Revise su mercancia en nuestro counter al       ",
                        "   momento de recibirla. En caso contrario no   ",
                        "tendra derecho de reclamos por faltante o rotura"
                    }
            };
        }

        public static string GetPrinterReturnMessage(PrinterResponses printerResponse)
        {
            var message = string.Empty;
            switch (printerResponse)
            {
                case PrinterResponses.Success:
                    message = "Comprobante emitido exitosamente!";
                    break;
                case PrinterResponses.OpeningPortError:
                    message = "No se pudo abrir el Puerto";
                    break;
                case PrinterResponses.OpeningFiscalReceiptError:
                    message = "Error abriendo comprobante fiscal";
                    break;
                case PrinterResponses.AddingItemsError:
                    message = "Error agregando ítems al comprobante fiscal";
                    break;
                case PrinterResponses.AddingPaymentsError:
                    message = "Error agregando el/los pagos comprobante fiscal";
                    break;
                case PrinterResponses.GettingSubtotalError:
                    message = "Error obteniendo el subtotal del comprobante fiscal";
                    break;
                case PrinterResponses.AddingCommentsError:
                    message = "Error agregando comentarios al comprobante fiscal";
                    break;
                case PrinterResponses.ClosingFiscalReceiptError:
                    message = "Error cerrando el  comprobante fiscal";
                    break;
                case PrinterResponses.CancellingFiscalReceiptError:
                    message = @"Se ha producido un error generando el comprobante,\n" +
                              @"Debe volver a conectar la corriente para cancelar el comprobante,\n" +
                              @"Presione OK cuando este conecteda";
                    break;
            }
            return message;
        }

        public void CancelLastFiscalReceipt()
        {
            _fiscalPrinterWrapper.CancelFiscalReceipt();
        }

        public PrinterResponses GetReportZ(uint tipo)
        {
            return _fiscalPrinterWrapper.GetReportZ(tipo);
        }
        public PrinterResponses GetReportX()
        {
            return _fiscalPrinterWrapper.GetReportX();
        }

        private void GenerateLinesNoFiscalRecipt()
        {
            /*_linesNoFiscalReceipt = new List<string>
            {
                "Factura  :" + _factura.DocCodigo + "-" + _factura.FacCodigo,
                "Fecha    :" + _factura.FacFecha.ToDatetimeValue().ToString("dd/MM/yyy"),
                "Cobrador :" + _factura.ResCodigo.PutBlankSpaces(12, 'R') + _factura.DetalleFactura,
                "Sucursal :" + _factura.SucCodigo,
                " ",
                "Cliente:",
              _factura.CteNumeroEps+" "+ _factura.FacNombre,
                "_".Repeat(25, 'J'),
                " ",
                "Por concepto: " + _factura.FacObservacion,
                "La suma de  : " + "RD$"+_factura.FacTotal,
                "Monto total : " +"RD$"+ _factura.FacTotal,
                "_".Repeat(25, 'J'),
                " ",
                "Documento".PutBlankSpaces(7,'R',false)+"Tipo transaccion".PutBlankSpaces(7,'R',false)+"Monto"
            };
            foreach (var desglosePago in _desglosePagos)
            {
                _linesNoFiscalReceipt.Add(desglosePago.DpaNumeroRefer.PutBlankSpaces(15, 'R', false) +
                    desglosePago.TipoTransaccion.PutBlankSpaces(11, 'R', false) + "RD$" + desglosePago.DpaMonto);
            }
            _linesNoFiscalReceipt.Add(" ");
            _linesNoFiscalReceipt.Add(" ");
             * */
        }

        private void GenerateLinesNoFiscalInvoice()
        {
            int ibltnumero = -1;
            string[] sDescAdicional;
            sDescAdicional = new[] { " " };
            ibltnumero = Convert.ToInt32(_factura.Rows[0]["BLT_NUMERO"]);
            int i = 0;
            decimal dSubTotal = 0;
            decimal dMontoTotal = 0;

            _linesNoFiscalReceipt = new List<string>();


            _linesNoFiscalReceipt.Add("RNC:" + _factura.Rows[0]["RNC"].ToString().KeepOnlyNumbers());
            _linesNoFiscalReceipt.Add(_factura.Rows[0]["CUENTACLI"].ToString());
            _linesNoFiscalReceipt.Add("--------------------------------------------------------------------------");
            //_linesNoFiscalReceipt.Add(_factura.DescricpcionNcf.PutBlankSpaces(10, 'L', false));
            _linesNoFiscalReceipt.Add("                                     ");
            _linesNoFiscalReceipt.Add("--------------------------------------------------------------------------");
            _linesNoFiscalReceipt.Add("DESCRIPCION              ITBIS             VALOR ");
            _linesNoFiscalReceipt.Add("--------------------------------------------------------------------------");

            foreach (BO.DAL.dsFactura.FACTURASRow oRow in (BO.DAL.dsFactura.FACTURASDataTable)_factura)
            {
                if (i == 0)
                    ibltnumero = oRow.BLT_NUMERO;

                i++;

                if (ibltnumero == oRow.BLT_NUMERO)
                {
                    var itemsBulto =
                     new Item
                     {
                         Description = oRow.CODIGO,
                         Quantity = 1,
                         Rate = oRow.TASA_ITBIS,
                         Price = oRow.MONTO_TOTAL,
                         Type = ItemTypes.SalesItem
                     };

                    // items.Add(itemsBulto);
                    _linesNoFiscalReceipt.Add("1.00 * " + string.Format("{0:##,###.##}", Math.Abs(oRow.MONTO_TOTAL)));
                    _linesNoFiscalReceipt.Add(oRow.CODIGO.PutBlankSpaces(25, 'R') +
                            string.Format("{0:0.00}", oRow.TASA_ITBIS).PutBlankSpaces(7, 'R') +
                            string.Format("{0:,###.##}", oRow.MONTO_TOTAL));

                    dSubTotal += oRow.MONTO_TOTAL;
                    dMontoTotal += oRow.MONTO_TOTAL;

                    sDescAdicional = new[]{
                          "Servicio-" + oRow.PRODUCTO.Trim() + "-",
                        "--Identificacion -" + oRow.IDENTIFICACION,
                        "Tarifa: "+oRow.TARIFA,
                        "Peso: "+oRow.PESO,
                        ("Contenido: "+oRow.CONTENIDO).Trim(),
                        "Remitente: "+oRow.REMITENTE,
                        "Destinatario: "+oRow.CONSIGNATARIO,
                        "Tracking No. "+oRow.TRACKING,
                         "TOTAL ITEM :"+Math.Round(dSubTotal, 2, MidpointRounding.ToEven)
                    };


                }
                else
                {
                    string[] aditionalDescriptions;

                    aditionalDescriptions = new[]
                    {
                           "Servicio-" + oRow.PRODUCTO.Trim() + "-",
                        "--Identificacion -" + oRow.IDENTIFICACION,
                        "Tarifa: "+oRow.TARIFA,
                        "Peso: "+oRow.PESO,
                        ("Contenido: "+oRow.CONTENIDO).Trim(),
                        "Remitente: "+oRow.REMITENTE,
                        "Destinatario: "+oRow.CONSIGNATARIO,
                        "Tracking No. "+oRow.TRACKING,
                         "TOTAL ITEM :"+Math.Round(dSubTotal, 2, MidpointRounding.ToEven)
                    };

                    foreach (var sDes in aditionalDescriptions)
                    {
                        _linesNoFiscalReceipt.Add(sDes);
                    }
                    _linesNoFiscalReceipt.Add(" ");
                    _linesNoFiscalReceipt.Add("----------------------------------------------------");

                    ibltnumero = oRow.BLT_NUMERO;
                    dSubTotal = 0;


                    var itemsBulto =
                     new Item
                     {
                         Description = oRow.CODIGO,
                         Quantity = 1,
                         Rate = oRow.TASA_ITBIS,
                         Price = oRow.MONTO_TOTAL,
                         Type = ItemTypes.SalesItem
                     };

                    _linesNoFiscalReceipt.Add("1.00 * " + string.Format("{0:##,###.##}", Math.Abs(oRow.MONTO_TOTAL)));
                    _linesNoFiscalReceipt.Add(oRow.CODIGO.PutBlankSpaces(25, 'R') +
                            string.Format("{0:0.00}", oRow.TASA_ITBIS).PutBlankSpaces(7, 'R') +
                            string.Format("{0:,###.##}", oRow.MONTO_TOTAL));

                    dSubTotal += oRow.MONTO_TOTAL;
                    dMontoTotal += oRow.MONTO_TOTAL;

                }


            }

            if (dSubTotal > 0)
            {

                foreach (var sDes in sDescAdicional)
                {
                    _linesNoFiscalReceipt.Add(sDes);
                }
                _linesNoFiscalReceipt.Add(" ");
                _linesNoFiscalReceipt.Add("----------------------------------------------------");


                dSubTotal = 0;
            }
            //

            _linesNoFiscalReceipt.Add("TOTAL A PAGAR".PutBlankSpaces(15, 'R', false) + string.Format("{0:0.##}", 0).PutBlankSpaces(8, 'R', false)
            + "RD$" + string.Format("{0:##,###.##}", dMontoTotal));

            if (_factura.Rows[0]["REC_CREDITO"].ToString() == "S")
                _linesNoFiscalReceipt.Add("Venta a credito".PutBlankSpaces(10, 'R', false) + "0.00".PutBlankSpaces(5, 'R', false) +
                                         "RD$" + string.Format("{0:##,###.##}", dMontoTotal));

            bool bEfectivo = false;
            foreach (System.Data.DataRow drpagos in _desglosePagos.Rows)
            {


                if (Convert.ToDecimal(drpagos["MontoEfectivo"]) > 0 && bEfectivo == false)
                {
                    _linesNoFiscalReceipt.Add("Efectivo".PutBlankSpaces(20, 'R') + "0.00".PutBlankSpaces(5, 'R', false) +
                       "RD$" + string.Format("{0:##,###.##}", Convert.ToDecimal(_desglosePagos.Rows[0]["MontoEfectivo"])));
                }


                if (Convert.ToInt32(drpagos["TipoPago"]) == 50)
                {
                    _linesNoFiscalReceipt.Add("Cheque".PutBlankSpaces(20, 'R') + "0.00".PutBlankSpaces(5, 'R', false) +
                       "RD$" + string.Format("{0:##,###.##}", Convert.ToDecimal(drpagos["Importe"])));
                }
                else if (Convert.ToInt32(drpagos["TipoPago"]) == 49)
                {
                    _linesNoFiscalReceipt.Add("Tarjeta de crédito".PutBlankSpaces(20, 'R') + "0.00".PutBlankSpaces(5, 'R', false) +
                       "RD$" + string.Format("{0:##,###.##}", Convert.ToDecimal(drpagos["Importe"])));
                }

            }


            _linesNoFiscalReceipt.Add(GetFiscalInvoiceTypeDescripcion(_factura.Rows[0]["REC_TIPO"].ToString()) + " : " + _factura.Rows[0]["SUCURSAL"].ToString() + "-" + _factura.Rows[0]["REC_TIPO"].ToString() + "-" + _factura.Rows[0]["REC_ID"].ToString());
            _linesNoFiscalReceipt.Add(_factura.Rows[0]["REC_TIPO_DESC"].ToString());
            _linesNoFiscalReceipt.Add(" "); //NCF
            _linesNoFiscalReceipt.Add(" ");
            _linesNoFiscalReceipt.Add(" ");
            _linesNoFiscalReceipt.Add("Atendido Por :" + ' ' + _factura.Rows[0]["USUARIO"].ToString());
            _linesNoFiscalReceipt.Add(" ");
            _linesNoFiscalReceipt.Add(" ");
            _linesNoFiscalReceipt.Add("-------------------------------");
            _linesNoFiscalReceipt.Add("Cliente :" + _factura.Rows[0]["CUENTACLI"].ToString());
            _linesNoFiscalReceipt.Add(" ");
            _linesNoFiscalReceipt.Add("Revise su mercancia en nuestro counter al");
            _linesNoFiscalReceipt.Add("momento de recibirla. En caso contrario no");
            _linesNoFiscalReceipt.Add("tendra derecho de reclamos por faltante o rotura");


        }


        public uint Connect()
        {
            return _fiscalPrinterWrapper.Connect();
        }

        public PrinterResponses PrinteLastFiscalReceipt()
        {
            return _fiscalPrinterWrapper.PrinteLastFiscalReceipt();
        }

        public PrinterResponses GetReportClosureZ(int tipo, string from, string to, int reportType)
        {
            return _fiscalPrinterWrapper.GetReportClosureZ(tipo, from, to, reportType);
        }
        public string GetCountryId()
        {
            return _fiscalPrinterWrapper.CountryId;
        }
        public string GetPrintingMechanism()
        {
            return _fiscalPrinterWrapper.PrintingMechanism;
        }
        public string GetPrintingMechanismName()
        {
            return _fiscalPrinterWrapper.PrintingMechanismName;
        }
        public string GetPort()
        {
            return _fiscalPrinterWrapper.Port.ToString();
        }

        public uint Disconnect()
        {
            return _fiscalPrinterWrapper.Disconnect();
        }

        public void PrintNoFiscalReceipt()
        {
            GenerateLinesNoFiscalInvoice();
            /* if (_factura.DocCodigo.StartsWith("FT", StringComparison.OrdinalIgnoreCase) ||
                 _factura.DocCodigo.StartsWith("NC", StringComparison.OrdinalIgnoreCase))
                 GenerateLinesNoFiscalInvoice();
             else
                 GenerateLinesNoFiscalRecipt();
             */
            for (var i = 0; i <= _numeroCopias; i++)
            {
                var result = _fiscalPrinterWrapper.PrintNoFiscalReceipt(_linesNoFiscalReceipt, !_isReimpresion);
                //errores.MostrarMensaje(GetPrinterReturnMessage(result));  
            }
        }

        public PrinterResponses Print()
        {
            SetFiscalPrinterData();
            var response = _fiscalPrinterWrapper.Print(_invoice, (uint)_numeroCopias, !_isReimpresion);
            if (response == PrinterResponses.CancellingFiscalReceiptError)
            {
                //errores.MostrarMensaje(GetPrinterReturnMessage(result), true);
                CancelLastFiscalReceipt();
            }
            if (response == PrinterResponses.OpeningFiscalReceiptError)
            {
                var resultError = _fiscalPrinterWrapper.Print(_invoice, (uint)_numeroCopias, !_isReimpresion);
                //errores.MostrarMensaje(GetPrinterReturnMessage(resultError));
            }
            //errores.MostrarMensaje(GetPrinterReturnMessage(result));
            Disconnect();
            return response;
        }

        //public bool Print()
        //{
        //    bool bError = false;
        //    SetFiscalPrinterData();
        //    var result = _fiscalPrinterWrapper.Print(_invoice, (uint)_numeroCopias, !_isReimpresion);
        //    if (result == PrinterResponses.CancellingFiscalReceiptError)
        //    {
        //        bError = true;
        //        //errores.MostrarMensaje(GetPrinterReturnMessage(result), true);
        //        CancelLastFiscalReceipt();
        //    }
        //    if (result == PrinterResponses.OpeningFiscalReceiptError)
        //    {
        //        var resultError = _fiscalPrinterWrapper.Print(_invoice, (uint)_numeroCopias, !_isReimpresion);
        //        if (resultError != PrinterResponses.Success)
        //            bError = true;
        //         //errores.MostrarMensaje(GetPrinterReturnMessage(resultError));
        //    }
        //    else if (result != PrinterResponses.Success)
        //        bError = true;
        //    //errores.MostrarMensaje(GetPrinterReturnMessage(result));
        //    Disconnect();
        //    return bError;
        //}
    }
}
