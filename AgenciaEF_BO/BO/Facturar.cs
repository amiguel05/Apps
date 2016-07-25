using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.DAL;
using AgenciaEF_BO.Models;
using System.Collections;
using System.Data;

namespace AgenciaEF_BO.BO
{
    public class Facturar
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public int FacturaGenerada { set; get; }


        public void RevisarTotales(int iReciboId)
        {
            decimal dMontoTotal = 0;
            decimal dMontoGravado = 0;
            decimal dMontoItebis = 0;

            var reciboDet = from p in unitOfWork.RecibosDetRepository.Get(filter: zx => zx.RECIBO_ID == iReciboId)
                            select new { p.MONTO_TOTAL, p.MONTO_ITBIS, p.MONTO_LOCAL };

            foreach (var dr in reciboDet)
            {
                dMontoTotal += dr.MONTO_TOTAL;
                dMontoItebis += dr.MONTO_ITBIS;
                if (dr.MONTO_ITBIS > 0)
                    dMontoGravado += dr.MONTO_LOCAL;
            }


            var recibos = unitOfWork.RecibosRepository.GetByID(iReciboId);
            recibos.IMPORTE_TOTAL = dMontoTotal;
            recibos.IMPORTE_ITEBIS = dMontoItebis;
            recibos.IMPORTE_GRAVADO = dMontoGravado;

            if (recibos.REC_CREDITO == false)
            {
                recibos.IMPORTE_CTA = dMontoTotal;
            }

            unitOfWork.RecibosRepository.Update(recibos);

            unitOfWork.Save();
        }


        public void ActualizarItbis(int piBltNumero)
        {
            var vQryBultosValores = unitOfWork.BultosValoresRepository.Get(filter: s => s.BLT_NUMERO == piBltNumero);
            decimal dMontoItebis = 0;
            //No se le pone itbis
            if (unitOfWork.BultosRepository.Get(filter: s => s.BLT_NUMERO == piBltNumero).FirstOrDefault().Clientes.CTE_TIPO_FISCAL == 45)
            {
                return;
            };
            var QrycargosProd = unitOfWork.CargosProductoRepository.Get(filter: s => s.Cargos.CAR_CODIGO == "999").FirstOrDefault();
            if (QrycargosProd != null)
            {
                foreach (var sQry in vQryBultosValores)
                {
                    if (sQry.CargosProducto.Cargos.CAR_ITBIS == true && sQry.CargosProducto.Cargos.ITBIS > 0)
                    {
                        dMontoItebis += Math.Round((Math.Round(sQry.BVA_MONTO_LOCAL, 2, MidpointRounding.ToEven) * sQry.CargosProducto.Cargos.ITBIS) / 100, 2, MidpointRounding.ToEven);
                    }
                }
                if (dMontoItebis > 0)
                {
                    AgenciaEF_BO.Models.BultosValores oBultosValores;
                    oBultosValores = unitOfWork.BultosValoresRepository.Get(filter: xy => xy.BLT_NUMERO == piBltNumero && xy.CARGO_PROD_ID == QrycargosProd.CARGO_PROD_ID).FirstOrDefault();
                    if (oBultosValores == null)
                    {
                        oBultosValores = new BultosValores();
                        oBultosValores.BLT_NUMERO = piBltNumero;
                        oBultosValores.BVA_MONTO = dMontoItebis;
                        oBultosValores.BVA_MONTO_APLICAR = dMontoItebis;
                        oBultosValores.BVA_MONTO_LOCAL = dMontoItebis;
                        oBultosValores.BVA_TASA = 18;
                        oBultosValores.CARGO_PROD_ID = QrycargosProd.CARGO_PROD_ID;
                        unitOfWork.BultosValoresRepository.Insert(oBultosValores);
                    }
                    else
                    {
                        oBultosValores.BVA_MONTO = dMontoItebis;
                        oBultosValores.BVA_MONTO_APLICAR = dMontoItebis;
                        oBultosValores.BVA_MONTO_LOCAL = dMontoItebis;
                        unitOfWork.BultosValoresRepository.Update(oBultosValores);
                    }
                }
            }
            unitOfWork.Save();
        }


        public bool ProcesarAnulacion(int iReciboId, int iUsuarioId, ref string psMensaje)
        {
            Boolean bRetorno = false;


            //1. Cargar los datos del recibo y el detalle de recibo 

            var recibo = unitOfWork.RecibosRepository.GetByID(iReciboId);
            var reciboDet = unitOfWork.RecibosDetRepository.Get(filter: s => s.RECIBO_ID == iReciboId);
            var oClientes = unitOfWork.ClientesRepository.GetByID(recibo.CTE_ID);

            if (recibo == null)
            {
                psMensaje = " Recibo inexistente";
                return false;
            }

            if (recibo.Tipos.TIPO_CODIGO == "NC01" || recibo.Tipos.TIPO_CODIGO == "FT10")
            {
                psMensaje = " Recibo inválido";
                return false;
            }

            try
            {
                Models.Recibos RecAnul = new Recibos();


                RecAnul.RECIBO_ID_ANUL = recibo.RECIBO_ID;
                RecAnul.REC_CREDITO = false;
                RecAnul.SUC_ID = recibo.SUC_ID;

                var oSecuencial = unitOfWork.SecuencialesRepository.Get(filter: xy => xy.SUC_ID == recibo.SUC_ID && xy.TIPO_ID == 5).FirstOrDefault();

                RecAnul.NUM_REC = oSecuencial.VALOR + 1;

                oSecuencial.VALOR += 1;

                unitOfWork.SecuencialesRepository.Update(oSecuencial);

                //RecAnul.SUC_ID = recibo.SUC_ID;
                RecAnul.TIP_FISCAL = recibo.TIP_FISCAL;
                RecAnul.TIPO_REC_ID = 5;  //Anulaciones
                RecAnul.USER_CREA = recibo.USER_CREA;
                RecAnul.USER_MODIFICA = recibo.USER_MODIFICA;
                RecAnul.IMPORTE_TOTAL = recibo.IMPORTE_TOTAL;
                RecAnul.IMPORTE_ITEBIS = recibo.IMPORTE_ITEBIS;
                RecAnul.IMPORTE_CTA = recibo.IMPORTE_CTA;
                RecAnul.IMPORTE_GRAVADO = recibo.IMPORTE_GRAVADO;
                RecAnul.FECHA_MODIF = DateTime.Now;
                RecAnul.FECHA_CREA = DateTime.Now;
                RecAnul.FECHA = DateTime.Now;
                RecAnul.F_VCTO = DateTime.Now;
                RecAnul.F_COBRO = DateTime.Now;
                RecAnul.ESTADO_ID = recibo.ESTADO_ID;
                RecAnul.CTE_ID = recibo.CTE_ID;
                RecAnul.COUNTER_ID = iUsuarioId;
                RecAnul.NUM_FISCAL = FindNextNCF_ANUL(oClientes.CTE_SUC_ID);
                RecAnul.IMPRESO = false;

                unitOfWork.RecibosRepository.Insert(RecAnul);

                ArrayList oBultosProc = new ArrayList();

                foreach (var oRecDet in reciboDet.ToList())
                {
                    Models.RecibosDet RecAnulDet = new RecibosDet();
                    RecAnulDet.RECIBO_ID = RecAnul.RECIBO_ID;
                    RecAnulDet.ITBIS = oRecDet.ITBIS;
                    RecAnulDet.MONTO_ITBIS = oRecDet.MONTO_ITBIS;
                    RecAnulDet.MONTO_LOCAL = oRecDet.MONTO_LOCAL;
                    RecAnulDet.MONTO_TOTAL = oRecDet.MONTO_TOTAL;
                    RecAnulDet.BLT_NUMERO = oRecDet.BLT_NUMERO;
                    RecAnulDet.CARGO_ID = oRecDet.CARGO_ID;



                    if (oBultosProc.Contains(oRecDet.BLT_NUMERO) == false)
                    {

                        Models.Bultos oBultos = unitOfWork.BultosRepository.Get(filter: s => s.BLT_NUMERO == oRecDet.BLT_NUMERO).FirstOrDefault();

                        if (oBultos.Productos.PRO_TIPO_ID == 31)
                            oBultos.BLT_ESTADO_ID = 2; // Inventario
                        else
                            oBultos.BLT_ESTADO_ID = 6; // Inventario

                        unitOfWork.BultosRepository.Update(oBultos);
                        oBultosProc.Add(oBultos.BLT_NUMERO);
                    }



                    unitOfWork.RecibosDetRepository.Insert(RecAnulDet);

                }

                //Inserta movimiento de caja

                MovCaja oCaja = new MovCaja();
                oCaja.FPAGO_ID = -1;
                oCaja.FECHA = DateTime.Now;
                oCaja.CTE_ID = RecAnul.CTE_ID;
                oCaja.COUNTER_ID = iUsuarioId;
                oCaja.IMPORTE = RecAnul.IMPORTE_TOTAL * -1;
                oCaja.SUC_ID = RecAnul.SUC_ID;

                oCaja.TIP_MOV = 60;// Registor de cobros;

                var oSecuencialCaja = unitOfWork.SecuencialesRepository.Get(filter: xy => xy.SUC_ID == RecAnul.SUC_ID && xy.TIPO_ID == 60).FirstOrDefault();

                oCaja.MOV_CAJA_SEC = oSecuencialCaja.VALOR + 1;

                oSecuencialCaja.VALOR += 1;

                unitOfWork.SecuencialesRepository.Update(oSecuencialCaja);


                unitOfWork.MovCajaRepository.Insert(oCaja);

                //
                if (recibo.REC_CREDITO == true)
                {
                    oClientes.CTE_BALANCE_DISPONIBLE = oClientes.CTE_BALANCE_DISPONIBLE + RecAnul.IMPORTE_TOTAL;
                    unitOfWork.ClientesRepository.Update(oClientes);

                }

                recibo.ESTADO_ID = 15;

                unitOfWork.RecibosRepository.Update(recibo);

                bRetorno = true;
                unitOfWork.Save();
                this.FacturaGenerada = RecAnul.RECIBO_ID;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    string s = "";
                    /*
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    */


                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += ve.ErrorMessage + "\n";
                        /*Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);*/
                    }
                    // MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw e;
                }
                //throw;
            }
            catch (DataException ex)
            {

                throw ex;
            }

            //2. Crear el nuevo reicbo
            //3. Si es un bulto hay que ir al estado anterior de inventario.
            //4. Si es a credito hay que reversar el balance.
            //4. Cambiar el estado del recibo

            return bRetorno;

        }

        /*en esta version van sin codigos fiscales*/
        public bool CrearFacturaCargoVarios(ArrayList pCargVar, int iCteId, int iUsuarioId, int iSucId, int iTipoFiscal)
        {
            bool bRetorno = true;

            var oCliente = unitOfWork.ClientesRepository.GetByID(iCteId);

            Recibos oRecibos = new Recibos();

            decimal MontoFact = 0; ;
            decimal MontoItebis = 0;

            oRecibos.COUNTER_ID = iUsuarioId;
            oRecibos.CTE_ID = iCteId;
            oRecibos.ESTADO_ID = 14;   //Cobrado
            oRecibos.F_COBRO = DateTime.Now; //Hay que ver si es de credito.
            oRecibos.F_VCTO = DateTime.Now;  //Depende del cliente para la fecha del vencimiento.
            oRecibos.FECHA = DateTime.Now;
            oRecibos.FECHA_CREA = DateTime.Now;
            oRecibos.FECHA_MODIF = DateTime.Now;
            oRecibos.IMPORTE_CTA = 0;
            oRecibos.IMPORTE_TOTAL = 0;
            oRecibos.NUM_FISCAL = "NA"; //Numero Fiscal
            var oSecuencial = unitOfWork.SecuencialesRepository.Get(filter: xy => xy.SUC_ID == iSucId && xy.TIPO_ID == 54).FirstOrDefault();

            oRecibos.NUM_REC = oSecuencial.VALOR + 1;

            oSecuencial.VALOR += 1;

            unitOfWork.SecuencialesRepository.Update(oSecuencial);

            oRecibos.RECIBO_ID_ANUL = -1;
            oRecibos.SUC_ID = iSucId;
            oRecibos.TIP_FISCAL = iTipoFiscal;
            oRecibos.TIPO_REC_ID = 54; //FT10 FACTURA DE CARGOS VARIOS.
            oRecibos.USER_CREA = "NA";
            oRecibos.USER_MODIFICA = "NA";
            oRecibos.REC_CREDITO = true;
            oRecibos.IMPRESO = false;

            foreach (int iCargoVario in pCargVar)
            {

                var sQry = unitOfWork.CargosVariosRepository.GetByID(iCargoVario);

                RecibosDet oRecDet = new RecibosDet();
                oRecDet.BLT_NUMERO = -1;
                oRecDet.RECIBO_ID = oRecibos.RECIBO_ID;
                oRecDet.CARGO_ID = sQry.Cargos.CARGO_ID;
                oRecDet.MONTO_LOCAL = sQry.IMPORTE;
                if (sQry.Cargos.CAR_ITBIS == true && sQry.Cargos.ITBIS > 0 && oCliente.CTE_TIPO_FISCAL != 45)
                {
                    oRecDet.MONTO_ITBIS = Math.Round((sQry.IMPORTE * sQry.Cargos.ITBIS) / 100, 2, MidpointRounding.ToEven);
                    oRecDet.MONTO_TOTAL = sQry.IMPORTE + oRecDet.MONTO_ITBIS;
                }
                else
                {
                    oRecDet.MONTO_ITBIS = 0;
                    oRecDet.MONTO_TOTAL = sQry.IMPORTE;
                }

                MontoFact += oRecDet.MONTO_TOTAL;
                MontoItebis += oRecDet.MONTO_ITBIS;

                unitOfWork.RecibosDetRepository.Insert(oRecDet);
                sQry.F_FACT = oRecibos.FECHA;
                sQry.ESTADO_ID = 19; //Facturado
                unitOfWork.CargosVariosRepository.Update(sQry);

            }
            oRecibos.IMPORTE_ITEBIS = MontoItebis;
            oRecibos.IMPORTE_TOTAL = MontoFact + MontoItebis;

            //BUSCA COMPROVANTE FISCAL.
            //oRecibos.NUM_FISCAL
            /*not yet
            var oClientes = unitOfWork.ClientesRepository.GetByID(oRecibos.CTE_ID);

            oRecibos.TIP_FISCAL = oClientes.CTE_TIPO_FISCAL;
            oRecibos.NUM_FISCAL = FindNextNCF(oRecibos.TIP_FISCAL);
            */


            oRecibos.ESTADO_ID = 13;   //Facturado
            oRecibos.IMPORTE_CTA = 0;
            //oRecibos.F_VCTO = oRecibos.F_VCTO.AddDays(Convert.ToDouble(oClientes.CTE_DIAS_CREDITOS)).Date;

            var oClientes = unitOfWork.ClientesRepository.GetByID(iCteId);

            oClientes.CTE_BALANCE_DISPONIBLE = oClientes.CTE_BALANCE_DISPONIBLE - oRecibos.IMPORTE_TOTAL;
            unitOfWork.ClientesRepository.Update(oClientes);


            unitOfWork.RecibosRepository.Insert(oRecibos);

            try
            {
                unitOfWork.Save();
                FacturaGenerada = oRecibos.RECIBO_ID;

            }

            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    string s = "";
                    /*
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    */


                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += ve.ErrorMessage + "\n";
                        /*Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);*/
                    }
                    // MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw e;
                }
                //throw;
            }
            catch (DataException ex)
            {

                throw ex;
            }



            return bRetorno;

        }



        public bool RegistrarCobro(ArrayList pRecibos, int piCteId, int iUsuarioId, int iSucId, int iTipoFiscal, decimal pdMontoPagar,
            decimal dMontoEfectivo, decimal dMontoOtros, decimal dDevolucion, DAL.dsDatos.DatosPagoDataTable pDatosPago)
        {
            ArrayList oRecibosCobrados = new ArrayList();

            bool bRetorno = false;

            decimal dMontoPagar = pdMontoPagar;

            MovCaja oCaja = new MovCaja();
            oCaja.FPAGO_ID = -1;
            oCaja.FECHA = DateTime.Now;
            oCaja.CTE_ID = piCteId;
            oCaja.COUNTER_ID = iUsuarioId;
            oCaja.IMPORTE = dMontoPagar;
            oCaja.SUC_ID = iSucId;

            oCaja.TIP_MOV = 55;// Registor de cobros;

            var oSecuencial = unitOfWork.SecuencialesRepository.Get(filter: xy => xy.SUC_ID == iSucId && xy.TIPO_ID == 55).FirstOrDefault();

            oCaja.MOV_CAJA_SEC = oSecuencial.VALOR + 1;

            oSecuencial.VALOR += 1;

            unitOfWork.SecuencialesRepository.Update(oSecuencial);

            unitOfWork.MovCajaRepository.Insert(oCaja);

            //

            Pagos oPagos = new Pagos();

            oPagos.CTE_ID = piCteId;
            oPagos.COUNTER_ID = iUsuarioId;
            oPagos.ESTADO_ID = 14;  /*cobrado*/
            oPagos.F_PAGO = oCaja.FECHA;
            oPagos.IMP_PAGO = dMontoPagar;
            oPagos.SUC_ID = iSucId;

            oPagos.TIPO_ID = 48; /*efectivo*/

            if (pDatosPago.Rows.Count > 0)
                oPagos.TIPO_ID = Convert.ToInt32(pDatosPago.Rows[0]["TipoPago"]);

            unitOfWork.PagosRepository.Insert(oPagos);

            //

            foreach (int i in pRecibos)
            {
                var oRecibos = unitOfWork.RecibosRepository.GetByID(i);

                MovCajaRecibos oCajaRecibos = new MovCajaRecibos();
                oCajaRecibos.MOVCAJA_ID = oCaja.MOVCAJA_ID;
                oCajaRecibos.RECIBO_ID = i;

                PagosRecibos oPagosRec = new PagosRecibos();

                oPagosRec.PAGO_ID = oPagos.PAGO_ID;
                oPagosRec.RECIBO_ID = i;



                if (oRecibos.IMPORTE_CTA == 0)
                {
                    if (pdMontoPagar >= oRecibos.IMPORTE_TOTAL)
                    {
                        oCajaRecibos.IMPORTE_PAGADO = oRecibos.IMPORTE_TOTAL;

                        oPagosRec.IMPORTE_PAGADO = oRecibos.IMPORTE_TOTAL;

                        oRecibos.IMPORTE_CTA = oRecibos.IMPORTE_TOTAL;
                        oRecibos.ESTADO_ID = 14; //cobrado;
                        pdMontoPagar = pdMontoPagar - oRecibos.IMPORTE_TOTAL;
                    }
                    else
                    {
                        oCajaRecibos.IMPORTE_PAGADO = pdMontoPagar;

                        oPagosRec.IMPORTE_PAGADO = pdMontoPagar;

                        oRecibos.IMPORTE_CTA = pdMontoPagar;
                        pdMontoPagar = 0;
                    }
                }
                else
                {/* ha que ver cuando tiene importe a cuenta*/


                    if (pdMontoPagar >= (oRecibos.IMPORTE_TOTAL - oRecibos.IMPORTE_CTA))
                    {
                        oCajaRecibos.IMPORTE_PAGADO = oRecibos.IMPORTE_TOTAL;

                        oPagosRec.IMPORTE_PAGADO = oRecibos.IMPORTE_TOTAL;

                        oRecibos.IMPORTE_CTA = oRecibos.IMPORTE_TOTAL;
                        oRecibos.ESTADO_ID = 14; //cobrado;
                        pdMontoPagar = pdMontoPagar - (oRecibos.IMPORTE_TOTAL - oRecibos.IMPORTE_CTA);
                    }
                    else
                    {
                        oCajaRecibos.IMPORTE_PAGADO = pdMontoPagar;

                        oPagosRec.IMPORTE_PAGADO = pdMontoPagar;

                        oRecibos.IMPORTE_CTA += pdMontoPagar;
                        pdMontoPagar = 0;
                    }


                }

                oRecibosCobrados.Add(i);

                unitOfWork.RecibosRepository.Update(oRecibos);

                unitOfWork.MovCajaRecibosRepository.Insert(oCajaRecibos);

                unitOfWork.PagosRecibosRepository.Insert(oPagosRec);

                if (pdMontoPagar == 0)
                {
                    break;
                }


            }


            //Datos pago
            foreach (DataRow dr in pDatosPago.Rows)
            {
                DatosPagos oDatosPagos = new DatosPagos();
                oDatosPagos.BANCO_ID = Convert.ToInt32(dr["Banco"]);
                oDatosPagos.FECHA_VENC = Convert.ToDateTime(dr["Fecha"]);
                oDatosPagos.IMPORTE = Convert.ToDecimal(dr["Importe"]);
                oDatosPagos.PAGO_ID = oPagos.PAGO_ID;
                oDatosPagos.NUMERO = dr["Numero"].ToString();

                unitOfWork.DatosPagoRepository.Insert(oDatosPagos);


            }
            //Estao esta doble hay que revisarlo algun dia
            foreach (int i in oRecibosCobrados)
            {
                PagosRecibos oPagosRec = new PagosRecibos();

                oPagosRec.PAGO_ID = oPagos.PAGO_ID;
                oPagosRec.RECIBO_ID = i;

                unitOfWork.PagosRecibosRepository.Insert(oPagosRec);
            }


            var oClientes = unitOfWork.ClientesRepository.GetByID(piCteId);

            oClientes.CTE_BALANCE_DISPONIBLE = oClientes.CTE_BALANCE_DISPONIBLE + dMontoPagar;
            unitOfWork.ClientesRepository.Update(oClientes);


            //

            try
            {
                unitOfWork.Save();
                FacturaGenerada = oCaja.MOVCAJA_ID;
                bRetorno = true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    string s = "";
                    /*
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    */


                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += ve.ErrorMessage + "\n";
                        /*Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);*/
                    }
                    // MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw e;
                }
                //throw;
            }
            catch (DataException ex)
            {

                throw ex;
            }

            return bRetorno;

        }

        //x.FormaPago, x.MontoEfectivo, x.MontoOtros, x.Devolucion, x.DatosPago, 
        public bool CrearFactura(decimal dMontoEfectivo, decimal dMontoOtros, decimal dDevolucion, DAL.dsDatos.DatosPagoDataTable pDatosPago,
                  int iCteId, int iTipoFiscal, int iSucId, int iUsuarioId, ArrayList pBultos, dsDatos.CorrespondenciaDataTable pTableCorr, decimal pdMontoFacturado, bool bCredito)
        {
            bool bRetornoCorr = true;
            bool bRetorno = true;
            Recibos oRecibos = new Recibos();
            decimal MontoFact = 0; ;
            decimal MontoItebis = 0;
            decimal dTasaItbis = 0;
            decimal dMontoGrabado = 0;
            string sUsuario = "";

            sUsuario = unitOfWork.UsuariosRepository.GetByID(iUsuarioId).NOMBRES.TrimEnd() + " " + unitOfWork.UsuariosRepository.GetByID(iUsuarioId).APELLIDOS.TrimEnd();

            var oCliente = unitOfWork.ClientesRepository.GetByID(iCteId);

            //1. CrearLos bultos de la mensajeria.
            if (pTableCorr.Rows.Count > 0)
            {
                bRetornoCorr = RegistroCorrespondencia(iCteId, iSucId, pTableCorr, iUsuarioId, ref pBultos);
                oCliente.CTE_CORRESPONDENCIA = false;
                unitOfWork.ClientesRepository.Update(oCliente);
            }

            if (bRetornoCorr == true)
            {
                //Si funciona la correspondencia, 

                oRecibos.COUNTER_ID = iUsuarioId;
                oRecibos.CTE_ID = iCteId;
                oRecibos.ESTADO_ID = 14;   //Cobrado
                oRecibos.F_COBRO = DateTime.Now; //Hay que ver si es de credito.
                oRecibos.F_VCTO = DateTime.Now;  //Depende del cliente para la fecha del vencimiento.
                oRecibos.FECHA = DateTime.Now;
                oRecibos.FECHA_CREA = DateTime.Now;
                oRecibos.FECHA_MODIF = DateTime.Now;
                oRecibos.IMPORTE_CTA = pdMontoFacturado;
                oRecibos.IMPORTE_TOTAL = pdMontoFacturado;
                oRecibos.NUM_FISCAL = "NA"; //Numero Fiscal


                var oSecuencial = unitOfWork.SecuencialesRepository.Get(filter: xy => xy.SUC_ID == iSucId && xy.TIPO_ID == 1).FirstOrDefault();

                oRecibos.NUM_REC = oSecuencial.VALOR + 1;

                oSecuencial.VALOR += 1;

                unitOfWork.SecuencialesRepository.Update(oSecuencial);

                oRecibos.RECIBO_ID_ANUL = -1;
                oRecibos.SUC_ID = iSucId;
                oRecibos.TIP_FISCAL = iTipoFiscal;
                oRecibos.TIPO_REC_ID = 1; //FT00  RECEPCION.
                oRecibos.USER_CREA = sUsuario;
                oRecibos.USER_MODIFICA = sUsuario;
                oRecibos.REC_CREDITO = bCredito;
                oRecibos.IMPRESO = false;


                foreach (object s in pBultos)
                {

                    int iBltNumero = Convert.ToInt32(s);


                    var sQueryValores = unitOfWork.BultosValoresRepository.Get(filter: a => a.BLT_NUMERO == iBltNumero && a.CargosProducto.Cargos.CAR_NCF == true);
                    foreach (var sQry in sQueryValores)
                    {
                        RecibosDet oRecDet = new RecibosDet();
                        oRecDet.BLT_NUMERO = iBltNumero;
                        oRecDet.RECIBO_ID = oRecibos.RECIBO_ID;
                        oRecDet.CARGO_ID = unitOfWork.CargosProductoRepository.GetByID(sQry.CARGO_PROD_ID).CARGO_ID;

                        oRecDet.MONTO_LOCAL = Math.Round(sQry.BVA_MONTO_LOCAL,2, MidpointRounding.ToEven);
                        if (sQry.CargosProducto.Cargos.CAR_ITBIS == true && sQry.CargosProducto.Cargos.ITBIS > 0 && oCliente.CTE_TIPO_FISCAL != 45) //zona franca
                        {
                            oRecDet.MONTO_ITBIS = Math.Round((oRecDet.MONTO_LOCAL * sQry.CargosProducto.Cargos.ITBIS) / 100, 2, MidpointRounding.ToEven);
                            oRecDet.MONTO_TOTAL = oRecDet.MONTO_LOCAL + oRecDet.MONTO_ITBIS;
                            dTasaItbis = sQry.CargosProducto.Cargos.ITBIS;
                            dMontoGrabado += oRecDet.MONTO_LOCAL;

                        }
                        else
                        {
                            oRecDet.MONTO_ITBIS = 0;
                            oRecDet.MONTO_TOTAL = oRecDet.MONTO_LOCAL;
                        }

                        MontoFact += oRecDet.MONTO_TOTAL;
                        MontoItebis += oRecDet.MONTO_ITBIS;

                        unitOfWork.RecibosDetRepository.Insert(oRecDet);
                        var sQueryButos = unitOfWork.BultosRepository.GetByID(iBltNumero); //Entregado al cliente;
                        sQueryButos.BLT_ESTADO_ID = 5;//Entregado al cliente
                        sQueryButos.BLT_FECHA_ENTREGADO = DateTime.Now;
                        unitOfWork.BultosRepository.Update(sQueryButos);

                    }


                }
                oRecibos.IMPORTE_ITEBIS = MontoItebis;
                oRecibos.ITBIS = dTasaItbis;
                oRecibos.IMPORTE_GRAVADO = dMontoGrabado;
                //oRecibos.IMPORTE_TOTAL = MontoFact + MontoItebis;

                oRecibos.USER_CREA = sUsuario;
                oRecibos.USER_MODIFICA = sUsuario;

                //BUSCA COMPROVANTE FISCAL.
                //oRecibos.NUM_FISCAL
                var oClientes = unitOfWork.ClientesRepository.GetByID(oRecibos.CTE_ID);

                oRecibos.TIP_FISCAL = oClientes.CTE_TIPO_FISCAL;
                oRecibos.NUM_FISCAL = FindNextNCF(oRecibos.TIP_FISCAL, iSucId);


                if (bCredito)
                {
                    oRecibos.ESTADO_ID = 13;   //Facturado
                    oRecibos.IMPORTE_CTA = 0;
                    oRecibos.F_VCTO = oRecibos.F_VCTO.AddDays(Convert.ToDouble(oClientes.CTE_DIAS_CREDITOS)).Date;
                }
                else
                    oRecibos.IMPORTE_CTA = oRecibos.IMPORTE_TOTAL;


                unitOfWork.RecibosRepository.Insert(oRecibos);
                //
                int iTipoMovCaja = -1;

                //registrar el movimiento de caja
                MovCaja oCaja = new MovCaja();
                oCaja.FPAGO_ID = -1;
                oCaja.FECHA = DateTime.Now;
                oCaja.CTE_ID = iCteId;
                oCaja.COUNTER_ID = iUsuarioId;
                oCaja.IMPORTE = pdMontoFacturado;
                oCaja.SUC_ID = iSucId;
                if (bCredito)
                {
                    iTipoMovCaja = 53;
                    oCaja.TIP_MOV = 53;// "MV001"  Facturacion de mercancia;
                }
                else
                {
                    oCaja.TIP_MOV = 51;// "MV001"  Facturacion de mercancia;
                    iTipoMovCaja = 51;
                }


                var oSecuencialCaja = unitOfWork.SecuencialesRepository.Get(filter: xy => xy.SUC_ID == iSucId && xy.TIPO_ID == iTipoMovCaja).FirstOrDefault();

                oCaja.MOV_CAJA_SEC = oSecuencialCaja.VALOR + 1;

                oSecuencialCaja.VALOR += 1;

                unitOfWork.SecuencialesRepository.Update(oSecuencialCaja);

                MovCajaRecibos oCajaRec = new MovCajaRecibos();
                oCajaRec.MOVCAJA_ID = oCaja.MOVCAJA_ID;
                oCajaRec.RECIBO_ID = oRecibos.RECIBO_ID;


                unitOfWork.MovCajaRepository.Insert(oCaja);

                unitOfWork.MovCajaRecibosRepository.Insert(oCajaRec);

                Pagos oPagos = new Pagos();

                if (!bCredito)
                {                 //Datos pago


                    oPagos.CTE_ID = iCteId;
                    oPagos.COUNTER_ID = oCaja.COUNTER_ID;
                    oPagos.ESTADO_ID = 14;
                    /*
                     * 14  COBRADO
                        15  ANULADO
                     */
                    oPagos.F_PAGO = oCaja.FECHA;
                    oPagos.IMP_PAGO = pdMontoFacturado;
                    oPagos.MOVCAJA_ID = oCaja.MOVCAJA_ID;
                    oPagos.SUC_ID = iSucId;
                    oPagos.TIPO_ID = 48; /*efectivo*/
                    oPagos.MONTO_EFECTIVO = Convert.ToDecimal(pDatosPago.Rows[0]["MontoEfectivo"]);

                    if (pDatosPago.Rows.Count > 0)
                        unitOfWork.PagosRepository.Insert(oPagos);

                    foreach (DataRow dr in pDatosPago.Rows)
                    {
                        if (Convert.ToInt32(dr["TipoPago"]) != -1)
                        {
                            oPagos.TIPO_ID = Convert.ToInt32(pDatosPago.Rows[0]["TipoPago"]);

                            DatosPagos oDatosPagos = new DatosPagos();
                            oDatosPagos.BANCO_ID = Convert.ToInt32(dr["Banco"]);
                            oDatosPagos.FECHA_VENC = Convert.ToDateTime(dr["Fecha"]);
                            oDatosPagos.IMPORTE = Convert.ToDecimal(dr["Importe"]);
                            oDatosPagos.PAGO_ID = oPagos.PAGO_ID;
                            oDatosPagos.NUMERO = dr["Numero"].ToString();
                            oPagos.MONTO_EFECTIVO = 0;

                            unitOfWork.DatosPagoRepository.Insert(oDatosPagos);
                        }
                    }



                    PagosRecibos oPagosRec = new PagosRecibos();
                    oPagosRec.PAGO_ID = oPagos.PAGO_ID;
                    oPagosRec.RECIBO_ID = oRecibos.RECIBO_ID;



                    unitOfWork.PagosRecibosRepository.Insert(oPagosRec);


                }
                else
                {
                    oClientes.CTE_BALANCE_DISPONIBLE = oClientes.CTE_BALANCE_DISPONIBLE - oRecibos.IMPORTE_TOTAL;
                    unitOfWork.ClientesRepository.Update(oClientes);

                }

                //

                try
                {
                    unitOfWork.Save();
                    FacturaGenerada = oRecibos.RECIBO_ID;
                    //Esto es un parcho muy mal hecho

                    //
                    // unitOfWork.Save();

                }

                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        string s = "";
                        /*
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        */


                        foreach (var ve in eve.ValidationErrors)
                        {
                            s += ve.ErrorMessage + "\n";
                            /*Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);*/
                        }
                        // MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw e;
                    }
                    //throw;
                }
                catch (DataException ex)
                {

                    throw ex;
                }


            }



            return bRetorno;
        }


        //x.FormaPago, x.MontoEfectivo, x.MontoOtros, x.Devolucion, x.DatosPago, 
        public bool CrearFacturaNoVenta(decimal dMontoEfectivo, decimal dMontoOtros, decimal dDevolucion, DAL.dsDatos.DatosPagoDataTable pDatosPago,
                  int iCteId, int iTipoFiscal, int iSucId, int iUsuarioId, ArrayList pBultos, dsDatos.CorrespondenciaDataTable pTableCorr, decimal pdMontoFacturado, bool bCredito)
        {
            bool bExiste = false;
            bool bRetorno = true;
            Recibos oRecibos = new Recibos();
            decimal MontoFact = 0; ;
            decimal MontoItebis = 0;
            decimal dTasaItbis = 0;
            decimal dMontoGrabado = 0;
            string sUsuario = "";

            sUsuario = unitOfWork.UsuariosRepository.GetByID(iUsuarioId).NOMBRES.TrimEnd() + " " + unitOfWork.UsuariosRepository.GetByID(iUsuarioId).APELLIDOS.TrimEnd();




            //Si funciona la correspondencia, 

            oRecibos.COUNTER_ID = iUsuarioId;
            oRecibos.CTE_ID = iCteId;
            oRecibos.ESTADO_ID = 14;   //Cobrado
            oRecibos.F_COBRO = DateTime.Now; //Hay que ver si es de credito.
            oRecibos.F_VCTO = DateTime.Now;  //Depende del cliente para la fecha del vencimiento.
            oRecibos.FECHA = DateTime.Now;
            oRecibos.FECHA_CREA = DateTime.Now;
            oRecibos.FECHA_MODIF = DateTime.Now;
            oRecibos.IMPORTE_CTA = pdMontoFacturado;
            oRecibos.IMPORTE_TOTAL = pdMontoFacturado;
            oRecibos.NUM_FISCAL = "NA"; //Numero Fiscal

            var oSecuencial = unitOfWork.SecuencialesRepository.Get(filter: xy => xy.SUC_ID == iSucId && xy.TIPO_ID == 62).FirstOrDefault();

            oRecibos.NUM_REC = oSecuencial.VALOR + 1;

            oSecuencial.VALOR += 1;

            unitOfWork.SecuencialesRepository.Update(oSecuencial);

            oRecibos.RECIBO_ID_ANUL = -1;
            oRecibos.SUC_ID = iSucId;
            oRecibos.TIP_FISCAL = -1;
            oRecibos.TIPO_REC_ID = 62; //FT06  NO VENTA.
            oRecibos.USER_CREA = sUsuario;
            oRecibos.USER_MODIFICA = sUsuario;
            oRecibos.REC_CREDITO = bCredito;
            oRecibos.IMPRESO = false;


            foreach (object s in pBultos)
            {

                int iBltNumero = Convert.ToInt32(s);


                var sQueryValores = unitOfWork.BultosValoresRepository.Get(filter: a => a.BLT_NUMERO == iBltNumero && a.CargosProducto.Cargos.CAR_NCF == false && a.CargosProducto.Cargos.CAR_CODIGO != "999");
                foreach (var sQry in sQueryValores)
                {
                    bExiste = true;

                    RecibosDet oRecDet = new RecibosDet();
                    oRecDet.BLT_NUMERO = iBltNumero;
                    oRecDet.RECIBO_ID = oRecibos.RECIBO_ID;
                    oRecDet.CARGO_ID = unitOfWork.CargosProductoRepository.GetByID(sQry.CARGO_PROD_ID).CARGO_ID;

                    oRecDet.MONTO_LOCAL = sQry.BVA_MONTO_LOCAL;

                    oRecDet.MONTO_ITBIS = 0;
                    oRecDet.MONTO_TOTAL = sQry.BVA_MONTO_LOCAL;


                    MontoFact += oRecDet.MONTO_TOTAL;
                    MontoItebis += oRecDet.MONTO_ITBIS;

                    unitOfWork.RecibosDetRepository.Insert(oRecDet);
                    var sQueryButos = unitOfWork.BultosRepository.GetByID(iBltNumero); //Entregado al cliente;
                    sQueryButos.BLT_ESTADO_ID = 5;//Entregado al cliente
                    sQueryButos.BLT_FECHA_ENTREGADO = DateTime.Now;
                    unitOfWork.BultosRepository.Update(sQueryButos);

                }


            }

            if (bExiste == true)
            {
                oRecibos.IMPORTE_ITEBIS = MontoItebis;
                oRecibos.ITBIS = dTasaItbis;
                oRecibos.IMPORTE_GRAVADO = dMontoGrabado;
                //oRecibos.IMPORTE_TOTAL = MontoFact + MontoItebis;

                oRecibos.USER_CREA = sUsuario;
                oRecibos.USER_MODIFICA = sUsuario;

                //BUSCA COMPROVANTE FISCAL.
                //oRecibos.NUM_FISCAL
                var oClientes = unitOfWork.ClientesRepository.GetByID(oRecibos.CTE_ID);

                oRecibos.TIP_FISCAL = 0;
                oRecibos.NUM_FISCAL = " ";


                if (bCredito)
                {
                    oRecibos.ESTADO_ID = 13;   //Facturado
                    oRecibos.IMPORTE_CTA = 0;
                    oRecibos.F_VCTO = oRecibos.F_VCTO.AddDays(Convert.ToDouble(oClientes.CTE_DIAS_CREDITOS)).Date;
                }
                else
                    oRecibos.IMPORTE_CTA = oRecibos.IMPORTE_TOTAL;


                unitOfWork.RecibosRepository.Insert(oRecibos);
                //
                //registrar el movimiento de caja
                MovCaja oCaja = new MovCaja();
                oCaja.FPAGO_ID = -1;
                oCaja.FECHA = DateTime.Now;
                oCaja.CTE_ID = iCteId;
                oCaja.COUNTER_ID = iUsuarioId;
                oCaja.IMPORTE = pdMontoFacturado;
                oCaja.SUC_ID = iSucId;

                oCaja.TIP_MOV = 63;// "MV007"  NO VENTA;

                var oSecuencialCaja = unitOfWork.SecuencialesRepository.Get(filter: xy => xy.SUC_ID == iSucId && xy.TIPO_ID == 63).FirstOrDefault();

                oCaja.MOV_CAJA_SEC = oSecuencialCaja.VALOR + 1;

                oSecuencialCaja.VALOR += 1;

                unitOfWork.SecuencialesRepository.Update(oSecuencialCaja);


                MovCajaRecibos oCajaRec = new MovCajaRecibos();
                oCajaRec.MOVCAJA_ID = oCaja.MOVCAJA_ID;
                oCajaRec.RECIBO_ID = oRecibos.RECIBO_ID;


                unitOfWork.MovCajaRepository.Insert(oCaja);

                unitOfWork.MovCajaRecibosRepository.Insert(oCajaRec);

                Pagos oPagos = new Pagos();

                if (!bCredito)
                {                 //Datos pago


                    oPagos.CTE_ID = iCteId;
                    oPagos.COUNTER_ID = oCaja.COUNTER_ID;
                    oPagos.ESTADO_ID = 14;
                    /*
                     * 14  COBRADO
                        15  ANULADO
                     */
                    oPagos.F_PAGO = oCaja.FECHA;
                    oPagos.IMP_PAGO = pdMontoFacturado;
                    oPagos.MOVCAJA_ID = oCaja.MOVCAJA_ID;
                    oPagos.SUC_ID = iSucId;
                    oPagos.TIPO_ID = 48; /*efectivo*/
                    oPagos.MONTO_EFECTIVO = Convert.ToDecimal(pDatosPago.Rows[0]["MontoEfectivo"]);

                    if (pDatosPago.Rows.Count > 0)
                        unitOfWork.PagosRepository.Insert(oPagos);

                    foreach (DataRow dr in pDatosPago.Rows)
                    {
                        if (Convert.ToInt32(dr["TipoPago"]) != -1)
                        {
                            oPagos.TIPO_ID = Convert.ToInt32(pDatosPago.Rows[0]["TipoPago"]);

                            DatosPagos oDatosPagos = new DatosPagos();
                            oDatosPagos.BANCO_ID = Convert.ToInt32(dr["Banco"]);
                            oDatosPagos.FECHA_VENC = Convert.ToDateTime(dr["Fecha"]);
                            oDatosPagos.IMPORTE = Convert.ToDecimal(dr["Importe"]);
                            oDatosPagos.PAGO_ID = oPagos.PAGO_ID;
                            oDatosPagos.NUMERO = dr["Numero"].ToString();
                            oPagos.MONTO_EFECTIVO = 0;

                            unitOfWork.DatosPagoRepository.Insert(oDatosPagos);
                        }
                    }



                    PagosRecibos oPagosRec = new PagosRecibos();
                    oPagosRec.PAGO_ID = oPagos.PAGO_ID;
                    oPagosRec.RECIBO_ID = oRecibos.RECIBO_ID;



                    unitOfWork.PagosRecibosRepository.Insert(oPagosRec);


                }
                else
                {
                    oClientes.CTE_BALANCE_DISPONIBLE = oClientes.CTE_BALANCE_DISPONIBLE - oRecibos.IMPORTE_TOTAL;
                    unitOfWork.ClientesRepository.Update(oClientes);

                }

                //

                try
                {
                    unitOfWork.Save();
                    FacturaGenerada = oRecibos.RECIBO_ID;


                }

                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        string s = "";
                        /*
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        */


                        foreach (var ve in eve.ValidationErrors)
                        {
                            s += ve.ErrorMessage + "\n";
                            /*Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);*/
                        }
                        // MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw e;
                    }
                    //throw;
                }
                catch (DataException ex)
                {

                    throw ex;
                }




            }
            else
                bRetorno = true;

            return bRetorno;
        }



        //x.FormaPago, x.MontoEfectivo, x.MontoOtros, x.Devolucion, x.DatosPago, 
        public bool CrearFacturaEnvio(decimal dMontoEfectivo, decimal dMontoOtros, decimal dDevolucion, DAL.dsDatos.DatosPagoDataTable pDatosPago,
                  int iCteId, int iTipoFiscal, int iSucId, int iUsuarioId, DAL.dsDatos.EnviosDataTable pTableEnvios, DAL.dsDatos.BultosValoresCargosDataTable oUnidades
                 , decimal pdMontoFacturado, bool bCredito)
        {
            bool bRetornoCorr = true;
            bool bRetorno = true;
            Recibos oRecibos = new Recibos();
            decimal MontoFact = 0; ;
            decimal MontoItebis = 0;
            decimal dTasaItbis = 0;
            decimal dMontoGrabado = 0;

            ArrayList pBultos = new ArrayList();

            string sUsuario = "";

            sUsuario = unitOfWork.UsuariosRepository.GetByID(iUsuarioId).NOMBRES.TrimEnd() + " " + unitOfWork.UsuariosRepository.GetByID(iUsuarioId).APELLIDOS.TrimEnd();

            var oCliente = unitOfWork.ClientesRepository.GetByID(iCteId);


            //bRetornoCorr = RegistroCorrespondencia(iCteId, iSucId, pTableCorr, iUsuarioId, ref pBultos);
            bRetornoCorr = RegistroBultosEnvio(iCteId, iSucId, pTableEnvios, oUnidades, iUsuarioId, ref pBultos);


            if (bRetornoCorr == true)
            {
                //Si funciona la correspondencia, 

                oRecibos.COUNTER_ID = iUsuarioId;
                oRecibos.CTE_ID = iCteId;
                oRecibos.ESTADO_ID = 14;   //Cobrado
                oRecibos.F_COBRO = DateTime.Now; //Hay que ver si es de credito.
                oRecibos.F_VCTO = DateTime.Now;  //Depende del cliente para la fecha del vencimiento.
                oRecibos.FECHA = DateTime.Now;
                oRecibos.FECHA_CREA = DateTime.Now;
                oRecibos.FECHA_MODIF = DateTime.Now;
                oRecibos.IMPORTE_CTA = pdMontoFacturado;
                oRecibos.IMPORTE_TOTAL = pdMontoFacturado;
                oRecibos.NUM_FISCAL = "NA"; //Numero Fiscal

                var oSecuencial = unitOfWork.SecuencialesRepository.Get(filter: xy => xy.SUC_ID == iSucId && xy.TIPO_ID == 3).FirstOrDefault();

                oRecibos.NUM_REC = oSecuencial.VALOR + 1;

                oSecuencial.VALOR += 1;

                unitOfWork.SecuencialesRepository.Update(oSecuencial);

                oRecibos.RECIBO_ID_ANUL = -1;
                oRecibos.SUC_ID = iSucId;
                oRecibos.TIP_FISCAL = iTipoFiscal;
                oRecibos.TIPO_REC_ID = 3; //FT07  ENVIOS.
                oRecibos.USER_CREA = sUsuario;
                oRecibos.USER_MODIFICA = sUsuario;
                oRecibos.REC_CREDITO = bCredito;
                oRecibos.IMPRESO = false;



                foreach (object s in pBultos)
                {

                    int iBltNumero = Convert.ToInt32(s);


                    var sQueryValores = unitOfWork.BultosValoresRepository.Get(filter: a => a.BLT_NUMERO == iBltNumero && a.CargosProducto.Cargos.CAR_NCF == true);
                    foreach (var sQry in sQueryValores)
                    {
                        RecibosDet oRecDet = new RecibosDet();
                        oRecDet.BLT_NUMERO = iBltNumero;
                        oRecDet.RECIBO_ID = oRecibos.RECIBO_ID;
                        oRecDet.CARGO_ID = unitOfWork.CargosProductoRepository.GetByID(sQry.CARGO_PROD_ID).CARGO_ID;

                        oRecDet.MONTO_LOCAL = sQry.BVA_MONTO_LOCAL;
                        if (sQry.CargosProducto.Cargos.CAR_ITBIS == true && sQry.CargosProducto.Cargos.ITBIS > 0 && oCliente.CTE_TIPO_FISCAL != 45)
                        {
                            oRecDet.MONTO_ITBIS = Math.Round((sQry.BVA_MONTO_LOCAL * sQry.CargosProducto.Cargos.ITBIS) / 100, 2, MidpointRounding.ToEven);
                            oRecDet.MONTO_TOTAL = sQry.BVA_MONTO_LOCAL + oRecDet.MONTO_ITBIS;
                            dTasaItbis = sQry.CargosProducto.Cargos.ITBIS;
                            dMontoGrabado += sQry.BVA_MONTO_LOCAL;
                        }
                        else
                        {
                            oRecDet.MONTO_ITBIS = 0;
                            oRecDet.MONTO_TOTAL = sQry.BVA_MONTO_LOCAL;
                        }

                        MontoFact += oRecDet.MONTO_TOTAL;
                        MontoItebis += oRecDet.MONTO_ITBIS;

                        unitOfWork.RecibosDetRepository.Insert(oRecDet);
                        var sQueryButos = unitOfWork.BultosRepository.GetByID(iBltNumero); //Entregado al cliente;
                        sQueryButos.BLT_ESTADO_ID = 5;//Entregado al cliente
                        sQueryButos.BLT_FECHA_ENTREGADO = DateTime.Now;
                        unitOfWork.BultosRepository.Update(sQueryButos);

                    }


                }
                oRecibos.IMPORTE_ITEBIS = MontoItebis;
                oRecibos.ITBIS = dTasaItbis;
                oRecibos.IMPORTE_GRAVADO = dMontoGrabado;
                //oRecibos.IMPORTE_TOTAL = MontoFact + MontoItebis;

                //BUSCA COMPROVANTE FISCAL.
                //oRecibos.NUM_FISCAL
                var oClientes = unitOfWork.ClientesRepository.GetByID(oRecibos.CTE_ID);

                oRecibos.TIP_FISCAL = oClientes.CTE_TIPO_FISCAL;
                oRecibos.NUM_FISCAL = FindNextNCF(oRecibos.TIP_FISCAL,iSucId);


                if (bCredito)
                {
                    oRecibos.ESTADO_ID = 13;   //Facturado
                    oRecibos.IMPORTE_CTA = 0;
                    oRecibos.F_VCTO = oRecibos.F_VCTO.AddDays(Convert.ToDouble(oClientes.CTE_DIAS_CREDITOS)).Date;
                }
                else
                    oRecibos.IMPORTE_CTA = oRecibos.IMPORTE_TOTAL;




                unitOfWork.RecibosRepository.Insert(oRecibos);
                //
                int iTipoMovCaja = -1;
                //registrar el movimiento de caja
                MovCaja oCaja = new MovCaja();
                oCaja.FPAGO_ID = -1;
                oCaja.FECHA = DateTime.Now;
                oCaja.CTE_ID = iCteId;
                oCaja.COUNTER_ID = iUsuarioId;
                oCaja.IMPORTE = pdMontoFacturado;
                oCaja.SUC_ID = iSucId;
                if (bCredito)
                {
                    oCaja.TIP_MOV = 59;// "MV001"  Facturacion de mercancia;
                    iTipoMovCaja = 59;
                }
                else
                {
                    oCaja.TIP_MOV = 58;// "MV001"  Facturacion de mercancia;
                    iTipoMovCaja = 58;
                }




                var oSecuencialCaja = unitOfWork.SecuencialesRepository.Get(filter: xy => xy.SUC_ID == iSucId && xy.TIPO_ID == iTipoMovCaja).FirstOrDefault();

                oCaja.MOV_CAJA_SEC = oSecuencialCaja.VALOR + 1;

                oSecuencialCaja.VALOR += 1;

                unitOfWork.SecuencialesRepository.Update(oSecuencialCaja);


                MovCajaRecibos oCajaRec = new MovCajaRecibos();
                oCajaRec.MOVCAJA_ID = oCaja.MOVCAJA_ID;
                oCajaRec.RECIBO_ID = oRecibos.RECIBO_ID;


                unitOfWork.MovCajaRepository.Insert(oCaja);

                unitOfWork.MovCajaRecibosRepository.Insert(oCajaRec);

                if (!bCredito)
                {                 //Datos pago

                    Pagos oPagos = new Pagos();
                    oPagos.CTE_ID = iCteId;
                    oPagos.COUNTER_ID = oCaja.COUNTER_ID;
                    oPagos.ESTADO_ID = 14;
                    /*
                     * 14  COBRADO
                        15  ANULADO
                     */
                    oPagos.F_PAGO = oCaja.FECHA;
                    oPagos.IMP_PAGO = pdMontoFacturado;
                    oPagos.MOVCAJA_ID = oCaja.MOVCAJA_ID;
                    oPagos.SUC_ID = iSucId;
                    oPagos.TIPO_ID = 48; /*efectivo*/
                    oPagos.MONTO_EFECTIVO = Convert.ToDecimal(pDatosPago.Rows[0]["MontoEfectivo"]);


                    if (pDatosPago.Rows.Count > 0)
                        unitOfWork.PagosRepository.Insert(oPagos);


                    foreach (DataRow dr in pDatosPago.Rows)
                    {
                        if (Convert.ToInt32(dr["TipoPago"]) != -1)
                        {
                            oPagos.TIPO_ID = Convert.ToInt32(pDatosPago.Rows[0]["TipoPago"]);

                            DatosPagos oDatosPagos = new DatosPagos();
                            oDatosPagos.BANCO_ID = Convert.ToInt32(dr["Banco"]);
                            oDatosPagos.FECHA_VENC = Convert.ToDateTime(dr["Fecha"]);
                            oDatosPagos.IMPORTE = Convert.ToDecimal(dr["Importe"]);
                            oDatosPagos.PAGO_ID = oPagos.PAGO_ID;
                            oDatosPagos.NUMERO = dr["Numero"].ToString();
                            oPagos.MONTO_EFECTIVO = 0;


                            unitOfWork.DatosPagoRepository.Insert(oDatosPagos);
                        }

                    }

                    PagosRecibos oPagosRec = new PagosRecibos();
                    oPagosRec.PAGO_ID = oPagos.PAGO_ID;
                    oPagosRec.RECIBO_ID = oRecibos.RECIBO_ID;

                    unitOfWork.PagosRecibosRepository.Insert(oPagosRec);


                }
                else
                {
                    oClientes.CTE_BALANCE_DISPONIBLE = oClientes.CTE_BALANCE_DISPONIBLE - oRecibos.IMPORTE_TOTAL;
                    unitOfWork.ClientesRepository.Update(oClientes);

                }

                //

                try
                {
                    unitOfWork.Save();
                    FacturaGenerada = oRecibos.RECIBO_ID;
                }

                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        string s = "";
                        /*
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        */


                        foreach (var ve in eve.ValidationErrors)
                        {
                            s += ve.ErrorMessage + "\n";
                            /*Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);*/
                        }
                        // MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw e;
                    }
                    //throw;
                }
                catch (DataException ex)
                {

                    throw ex;
                }


            }



            return bRetorno;
        }



        public bool CalcUnidadesEnvios(int ProductoId, decimal pdPeso, decimal pdValorFOB, ref dsDatos.BultosValoresCargosDataTable oUnidades, int piOrigenId, int iCteId, ref decimal pdSellos)
        {

            int iProductoId = ProductoId;


            var cargosExits = unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProductoId &&
                                                (s.Cargos.CAR_BASE_ID == 28 || s.Cargos.CAR_BASE_ID == 25 || s.Cargos.CAR_BASE_ID == 30)
                                                && s.Cargos.CAR_ESTADO == true && s.Cargos.CAR_TIPO == "U");

            // var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);

            decimal dPeso = pdPeso;

            oUnidades.Rows.Clear();

            foreach (var cargo in cargosExits)
            {
                DataRow oRow = oUnidades.NewRow();

                oRow["ID"] = -1;
                oRow["CARGO_PROD_ID"] = cargo.CARGO_PROD_ID;
                oRow["Desc"] = cargo.Cargos.CAR_DESCRIPCION;
                oRow["Tasa"] = cargo.TasaCambio.FACTOR_CONV;

                if (cargo.Cargos.CAR_BASE_ID == 28 && cargo.Cargos.CAR_CODIGO == "024") /*Sellos*/
                {
                    oRow["Monto"] = dPeso.ToString();

                    oRow["MontoAplicar"] = BuscarMontoAplicarEnvio(iProductoId, cargo.CARGO_PROD_ID, dPeso, piOrigenId);

                    pdSellos = Convert.ToDecimal(oRow["MontoAplicar"]);

                }
                if (cargo.Cargos.CAR_BASE_ID == 28 && cargo.Cargos.CAR_CODIGO != "024") /*en base a Sellos*/
                {
                    oRow["Monto"] = BuscarMontoAplicarEnvio(iProductoId, cargo.CARGO_PROD_ID, dPeso, piOrigenId);

                    oRow["MontoAplicar"] = BuscarMontoAplicar(cargo.CARGO_PROD_ID, Convert.ToDecimal(oRow["Monto"]), iCteId);

                }
                else if (cargo.Cargos.CAR_BASE_ID == 25) /*Peso*/
                {
                    oRow["Monto"] = dPeso.ToString();

                    oRow["MontoAplicar"] = BuscarMontoAplicar(cargo.CARGO_PROD_ID, dPeso, iCteId);

                }
                else if (cargo.Cargos.CAR_BASE_ID == 30) /*FOB*/
                {
                    oRow["Monto"] = pdValorFOB.ToString();

                    oRow["MontoAplicar"] = BuscarMontoAplicar(cargo.CARGO_PROD_ID, pdValorFOB, iCteId);

                }



                if (cargo.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                {
                    if (Convert.ToDecimal(oRow["MontoAplicar"]) < Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR))
                    {
                        Convert.ToDecimal(oRow["MontoAplicar"] = Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR));
                    }

                    oRow["MontoLocal"] = Convert.ToDecimal(oRow["MontoAplicar"]) * cargo.TasaCambio.FACTOR_CONV;

                }
                else
                {
                    if (Convert.ToDecimal(oRow["Monto"]) < Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR))
                    {
                        oRow["Monto"] = Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR);
                    }

                    oRow["MontoLocal"] = Convert.ToDecimal(oRow["Monto"]) * Convert.ToDecimal(oRow["MontoAplicar"]) * cargo.TasaCambio.FACTOR_CONV;
                }



                oUnidades.Rows.Add(oRow);


            }
            return true;
        }


        public bool CalcCagosEnvios(int ProductoId, decimal pdPeso, decimal dSellos, decimal pdValorFOB, ref dsDatos.BultosValoresCargosDataTable oUnidades, int iCteId, int iCargoProdId)
        {

            int iProductoId = ProductoId;


            var cargo = unitOfWork.CargosProductoRepository.GetByID(iCargoProdId);

            // var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);

            decimal dPeso = pdPeso;

            // oUnidades.Rows.Clear();


            DataRow oRow = oUnidades.NewRow();

            oRow["ID"] = -1;
            oRow["CARGO_PROD_ID"] = cargo.CARGO_PROD_ID;
            oRow["Desc"] = cargo.Cargos.CAR_DESCRIPCION;
            oRow["Tasa"] = cargo.TasaCambio.FACTOR_CONV;


            if (cargo.Cargos.CAR_BASE_ID == 28 && cargo.Cargos.CAR_CODIGO != "024") /*en base a Sellos*/
            {
                oRow["Monto"] = dSellos;

                oRow["MontoAplicar"] = BuscarMontoAplicar(cargo.CARGO_PROD_ID, Convert.ToDecimal(oRow["Monto"]), iCteId);

            }
            else if (cargo.Cargos.CAR_BASE_ID == 25) /*Peso*/
            {
                oRow["Monto"] = dPeso.ToString();

                oRow["MontoAplicar"] = BuscarMontoAplicar(cargo.CARGO_PROD_ID, dPeso, iCteId);

            }
            else if (cargo.Cargos.CAR_BASE_ID == 30) /*FOB*/
            {
                oRow["Monto"] = pdValorFOB.ToString();

                oRow["MontoAplicar"] = BuscarMontoAplicar(cargo.CARGO_PROD_ID, pdValorFOB, iCteId);

            }



            if (cargo.Cargos.CAR_FIJO_MULTIPLICAR == "F")
            {
                if (Convert.ToDecimal(oRow["MontoAplicar"]) < Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR))
                {
                    Convert.ToDecimal(oRow["MontoAplicar"] = Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR));
                }

                oRow["MontoLocal"] = Convert.ToDecimal(oRow["MontoAplicar"]) * cargo.TasaCambio.FACTOR_CONV;

            }
            else
            {
                if (Convert.ToDecimal(oRow["Monto"]) < Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR))
                {
                    oRow["Monto"] = Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR);
                }

                oRow["MontoLocal"] = Convert.ToDecimal(oRow["Monto"]) * Convert.ToDecimal(oRow["MontoAplicar"]) * cargo.TasaCambio.FACTOR_CONV;
            }



            oUnidades.Rows.Add(oRow);


            return true;
        }


        decimal BuscarMontoAplicar(int piCargoId, decimal Monto, int iNumeroEPS)
        {
            decimal dRetorno = 1;

            var Clientes = unitOfWork.ClientesRepository.GetByID(iNumeroEPS);

            var cargosProd = from p in unitOfWork.CargosValoresRepository.Get(filter: s => s.COD_TAR_ID == Clientes.COD_TARIFA && s.SUC_ID == Clientes.CTE_SUC_ID && s.CARGO_PROD_ID == piCargoId)
                             orderby p.VAL_HASTA
                             select new { p.VAL_HASTA, p.VAL_PORCENTAJE, p.VAL_VALOR, p.VAL_ADICIONAL };


            foreach (var valor in cargosProd)
            {
                if (Monto <= valor.VAL_HASTA)
                {
                    if (valor.VAL_VALOR != 0)
                        dRetorno = valor.VAL_VALOR;
                    else if (valor.VAL_PORCENTAJE != 0)
                        dRetorno = valor.VAL_PORCENTAJE / 100;

                    break;
                }


            }



            return dRetorno;

        }

        decimal BuscarMontoAplicarEnvio(int piProductoId, int piCargoId, decimal pPeso, int piOrigenId)
        {

            decimal dSellos = 0;

            var oValores = from p in unitOfWork.TarifaEnvioRepository.Get(filter: s => s.Envios.PROD_ID == piProductoId && s.PESO <= pPeso)
                           orderby p.PESO descending
                           select new { p.A, p.B, p.C, p.D, p.E, p.F, p.G, p.H };


            var oZona = unitOfWork.TarifaEnvioZonaRepository.Get(filter: s => s.ORI_ID == piOrigenId && s.Envios.PROD_ID == piProductoId).FirstOrDefault();



            if (oZona.ZONA == "A")
                dSellos = oValores.First().A;
            else if (oZona.ZONA == "B")
                dSellos = oValores.First().B;
            else if (oZona.ZONA == "C")
                dSellos = oValores.First().C;
            else if (oZona.ZONA == "D")
                dSellos = oValores.First().D;
            else if (oZona.ZONA == "E")
                dSellos = oValores.First().E;
            else if (oZona.ZONA == "F")
                dSellos = oValores.First().F;
            else if (oZona.ZONA == "G")
                dSellos = oValores.First().G;
            else if (oZona.ZONA == "H")
                dSellos = oValores.First().H;

            return dSellos;

        }


        public decimal ActualizarItbisEnvios(ref dsDatos.BultosValoresCargosDataTable oUnidades)
        {

            decimal dMontoItebis = 0;


            var QrycargosProd = unitOfWork.CargosProductoRepository.Get(filter: s => s.Cargos.CAR_CODIGO == "999").FirstOrDefault();

            if (QrycargosProd != null)
            {

                foreach (AgenciaEF_BO.DAL.dsDatos.BultosValoresCargosRow oRow in oUnidades)
                {
                    var sQry = unitOfWork.CargosProductoRepository.GetByID(oRow.CARGO_PROD_ID);

                    if (sQry.Cargos.CAR_ITBIS == true && sQry.Cargos.ITBIS > 0)
                    {
                        dMontoItebis += Math.Round((oRow.MontoLocal * sQry.Cargos.ITBIS) / 100, 2);

                    }
                }

                if (dMontoItebis > 0)
                {


                    DataRow oRow = oUnidades.NewRow();

                    oRow["ID"] = -1;
                    oRow["CARGO_PROD_ID"] = QrycargosProd.CARGO_PROD_ID;
                    oRow["Desc"] = QrycargosProd.Cargos.CAR_DESCRIPCION;
                    oRow["Tasa"] = QrycargosProd.TasaCambio.FACTOR_CONV;
                    oRow["Monto"] = dMontoItebis;
                    oRow["MontoAplicar"] = dMontoItebis;
                    oRow["MontoLocal"] = dMontoItebis;

                    oUnidades.Rows.Add(oRow);

                }


            }

            return dMontoItebis;
        }

        /*Hay que ponerlo por sucursal*/
        string FindNextNCF(int iTipFiscal)
        {
            string sRetorno = "";

            NumeroFiscal oFiscal = unitOfWork.NumeroFicalRepository.Get(filter: xy => xy.TIPO_ID == iTipFiscal).FirstOrDefault();

            if (oFiscal != null)
            {
                sRetorno = oFiscal.PREFIJO + oFiscal.SECUENCIA.ToString().PadLeft(6, '0');

                oFiscal.SECUENCIA += 1;

                unitOfWork.NumeroFicalRepository.Update(oFiscal);


            }


            return sRetorno;
        }

          string FindNextNCF(int iTipFiscal, int iSucursal)
        {
            string sRetorno = "";

            NumeroFiscal oFiscal = unitOfWork.NumeroFicalRepository.Get(filter: xy => xy.TIPO_ID == iTipFiscal && xy.SUC_ID == iSucursal).FirstOrDefault();

            if (oFiscal != null)
            {
                sRetorno = oFiscal.PREFIJO + oFiscal.SECUENCIA.ToString().PadLeft(6, '0');

                oFiscal.SECUENCIA += 1;

                unitOfWork.NumeroFicalRepository.Update(oFiscal);


            }


            return sRetorno;
        }

        string FindNextNCF_ANUL()
        {
            string sRetorno = "";

            NumeroFiscal oFiscal = unitOfWork.NumeroFicalRepository.Get(filter: xy => xy.TIPO_ID == 61).FirstOrDefault();

            if (oFiscal != null)
            {
                sRetorno = oFiscal.PREFIJO + oFiscal.SECUENCIA.ToString().PadLeft(6, '0');

                oFiscal.SECUENCIA += 1;

                unitOfWork.NumeroFicalRepository.Update(oFiscal);


            }


            return sRetorno;
        }


        string FindNextNCF_ANUL(int iSucId)
        {
            string sRetorno = "";

            NumeroFiscal oFiscal = unitOfWork.NumeroFicalRepository.Get(filter: xy => xy.TIPO_ID == 61 && xy.SUC_ID == iSucId).FirstOrDefault();

            if (oFiscal != null)
            {
                sRetorno = oFiscal.PREFIJO + oFiscal.SECUENCIA.ToString().PadLeft(6, '0');

                oFiscal.SECUENCIA += 1;

                unitOfWork.NumeroFicalRepository.Update(oFiscal);


            }


            return sRetorno;
        }

        bool RegistroBultosEnvio(int iCteId, int iSucId, dsDatos.EnviosDataTable pTableEnvio,
            dsDatos.BultosValoresCargosDataTable oUnidades, int iUsuarioId, ref  ArrayList pBultos)
        {
            bool bRetorno = false;


            try
            {



                foreach (dsDatos.EnviosRow dr in pTableEnvio.Rows)
                {
                    Bultos oButos = new Bultos();

                    BultosEnvios oBultosEnvios = new BultosEnvios();


                    oButos.ALM_CODIGO = 0;
                    oButos.BLT_ABIERTO_ADUANA = false;
                    oButos.BLT_ADUANA = false;
                    oButos.BLT_ALTO = 0;
                    oButos.BLT_ANCHO = 0;
                    oButos.BLT_BOLSA_SUCURSAL = "0";
                    oButos.BLT_BOLSA_SUPLIDOR = "0";
                    oButos.BLT_CODIGO_BARRA = "E-" + iCteId.ToString() + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" +
                                               DateTime.Now.Year.ToString() + "-" + DateTime.Now.Minute.ToString();

                    oButos.BLT_DESPA_SUPLIDOR = DateTime.Now;
                    oButos.BLT_ENTREGAR = true;
                    oButos.BLT_ESTADO_ID = 1;
                    oButos.BLT_FECHA_ENTREGADO = DateTime.Now;
                    oButos.BLT_FECHA_RECEPCION = DateTime.Now;
                    oButos.BLT_GUIA_HIJA = "E-" + iCteId.ToString() + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" +
                                               DateTime.Now.Year.ToString() + "-" + DateTime.Now.Minute.ToString();

                    oButos.BLT_HORA_ENTREGADO = "0";
                    oButos.BLT_HORA_RECIBIDO = "0";
                    oButos.BLT_LARGO = 0;
                    oButos.BLT_LIQUIDADOR = "0";
                    oButos.BLT_MANIFIESTO_SUCURSAL = "0";
                    oButos.BLT_MONTO_SELLOS = 0;
                    oButos.BLT_OBSERVACION = "CORRESPONDENCIA";
                    oButos.BLT_PESO = dr.peso;
                    oButos.BLT_PESO_REAL = dr.peso;
                    oButos.BLT_PESO_SUPLIDOR = Convert.ToDecimal(dr["Peso"]);
                    oButos.BLT_PIEZAS = dr.Piezas;
                    oButos.BLT_PIEZAS_SUPLIDOR = dr.Piezas;
                    oButos.BLT_PONUMBER = "0";
                    oButos.BLT_PORCIENTO_SELLO = 0;
                    oButos.BLT_RECEP_SUPLIDOR = DateTime.Now;
                    oButos.BLT_TRACKING_NUMBER = "NA";
                    oButos.BLT_UBICACION = "NA";
                    oButos.BLT_VALOR_FOB = dr.valor;
                    oButos.BLT_VENTANILLA = 0;
                    oButos.BLT_VOLUMEN = 0;
                    oButos.BLT_WAREHOUSE = "NA";
                    oButos.CON_CODIGO_ID = 7; //Condición Normal
                    oButos.CONTENIDO = "NA";
                    oButos.CTE_ID = iCteId;
                    oButos.DEST_ID = dr.destinoId;
                    oButos.DESTINATARIO = dr.consignatario;
                    oButos.FECHA_MODIF = DateTime.Now;
                    oButos.MAN_GUIA = "NA";
                    oButos.MAN_MANIFIESTO = "NA";
                    oButos.ORI_ID = 168; //SDQ
                    oButos.PROD_ID = dr.ProductoId;
                    oButos.REMITENTE = dr.remitente;
                    oButos.SUC_ID = iSucId;
                    oButos.UBI_CODIGO = "NA";
                    oButos.USUARIO_ID = iUsuarioId;
                    unitOfWork.BultosRepository.Insert(oButos);
                    // Agrego la informacion relacionada con el envio.


                    oBultosEnvios.DEST_CIUDAD = dr.consignatario_ciudad;
                    oBultosEnvios.DEST_DIR1 = dr.consignatario_dir1;
                    oBultosEnvios.DEST_DIR2 = dr.consignatario_dir2;
                    oBultosEnvios.DEST_PAIS_ID = dr.consignatario_paisId;
                    oBultosEnvios.DEST_PROVINCIA = dr.consignatario_region;
                    oBultosEnvios.DEST_TEL = dr.consignatario_tel;
                    oBultosEnvios.DEST_ZIP = "";
                    oBultosEnvios.DESTINATARIO = dr.consignatario;

                    oBultosEnvios.REM_CIUDAD = dr.remitente_ciudad;
                    oBultosEnvios.REM_EMAIL = " ";
                    oBultosEnvios.REM_PAIS_ID = dr.remitente_paisId;
                    oBultosEnvios.REM_PROVINCIA = dr.remitente_region;
                    oBultosEnvios.REM_TELEFONO = dr.remitente_tel;
                    oBultosEnvios.REM_ZIP = " ";
                    oBultosEnvios.REMITENTE = dr.remitente;
                    oBultosEnvios.REMITENTE_DIR1 = dr.remitente_dir1;
                    oBultosEnvios.REMITENTE_DIR2 = dr.remitente_dir2;
                    unitOfWork.Save();
                    oBultosEnvios.BLT_NUMERO = oButos.BLT_NUMERO;

                    unitOfWork.BultosEnviosRepository.Insert(oBultosEnvios);
                    //Agrego los bultos de correspondencia
                    pBultos.Add(oButos.BLT_NUMERO);


                    foreach (dsDatos.BultosValoresCargosRow drUnidades in oUnidades.Rows)
                    {
                        if (drUnidades.ID == dr.Id)
                        {
                            BultosValores oBultosVal = new BultosValores();

                            oBultosVal.BLT_NUMERO = oButos.BLT_NUMERO;
                            oBultosVal.BVA_MONTO = drUnidades.Monto;

                            oBultosVal.BVA_MONTO_APLICAR = drUnidades.MontoAplicar;
                            oBultosVal.BVA_MONTO_LOCAL = drUnidades.MontoLocal;
                            oBultosVal.BVA_TASA = drUnidades.Tasa;
                            oBultosVal.CARGO_PROD_ID = drUnidades.CARGO_PROD_ID;

                            unitOfWork.BultosValoresRepository.Insert(oBultosVal);
                        }

                    }

                    unitOfWork.Save();
                    bRetorno = true;

                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    string s = "";


                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += ve.ErrorMessage + "\n";

                    }
                    throw e;
                }
                //throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bRetorno;

        }



        bool RegistroCorrespondencia(int iCteId, int iSucId, dsDatos.CorrespondenciaDataTable pTableCorr, int iUsuarioId, ref  ArrayList pBultos)
        {
            bool bRetorno = false;


            try
            {



                foreach (DataRow dr in pTableCorr.Rows)
                {
                    Bultos oButos = new Bultos();


                    oButos.ALM_CODIGO = 0;
                    oButos.BLT_ABIERTO_ADUANA = false;
                    oButos.BLT_ADUANA = false;
                    oButos.BLT_ALTO = 0;
                    oButos.BLT_ANCHO = 0;
                    oButos.BLT_BOLSA_SUCURSAL = "0";
                    oButos.BLT_BOLSA_SUPLIDOR = "0";
                    oButos.BLT_CODIGO_BARRA = "C-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" +
                                               DateTime.Now.Year.ToString() + "-" + DateTime.Now.Minute.ToString();

                    oButos.BLT_DESPA_SUPLIDOR = DateTime.Now;
                    oButos.BLT_ENTREGAR = true;
                    oButos.BLT_ESTADO_ID = 1;
                    oButos.BLT_FECHA_ENTREGADO = DateTime.Now;
                    oButos.BLT_FECHA_RECEPCION = DateTime.Now;
                    oButos.BLT_GUIA_HIJA = "C-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" +
                                               DateTime.Now.Year.ToString() + "-" + DateTime.Now.Minute.ToString();

                    oButos.BLT_HORA_ENTREGADO = "0";
                    oButos.BLT_HORA_RECIBIDO = "0";
                    oButos.BLT_LARGO = 0;
                    oButos.BLT_LIQUIDADOR = "0";
                    oButos.BLT_MANIFIESTO_SUCURSAL = "0";
                    oButos.BLT_MONTO_SELLOS = 0;
                    oButos.BLT_OBSERVACION = "CORRESPONDENCIA";
                    oButos.BLT_PESO = Convert.ToDecimal(dr["Peso"]);
                    oButos.BLT_PESO_REAL = Convert.ToDecimal(dr["Peso"]);
                    oButos.BLT_PESO_SUPLIDOR = Convert.ToDecimal(dr["Peso"]);
                    oButos.BLT_PIEZAS = Convert.ToInt32(dr["Piezas"]);
                    oButos.BLT_PIEZAS_SUPLIDOR = Convert.ToInt32(dr["Piezas"]);
                    oButos.BLT_PONUMBER = "0";
                    oButos.BLT_PORCIENTO_SELLO = 0;
                    oButos.BLT_RECEP_SUPLIDOR = DateTime.Now;
                    oButos.BLT_TRACKING_NUMBER = "NA";
                    oButos.BLT_UBICACION = "NA";
                    oButos.BLT_VALOR_FOB = 0;
                    oButos.BLT_VENTANILLA = 0;
                    oButos.BLT_VOLUMEN = 0;
                    oButos.BLT_WAREHOUSE = "NA";
                    oButos.CON_CODIGO_ID = 7; //Condición Normal
                    oButos.CONTENIDO = dr["Producto"].ToString();
                    oButos.CTE_ID = iCteId;
                    oButos.DEST_ID = -1;
                    oButos.DESTINATARIO = "NA";
                    oButos.FECHA_MODIF = DateTime.Now;
                    oButos.MAN_GUIA = "NA";
                    oButos.MAN_MANIFIESTO = "NA";
                    oButos.ORI_ID = 168; //SDQ
                    oButos.PROD_ID = Convert.ToInt32(dr["ProdId"]);
                    oButos.REMITENTE = "NA";
                    oButos.SUC_ID = iSucId;
                    oButos.UBI_CODIGO = "NA";
                    oButos.USUARIO_ID = iUsuarioId;
                    unitOfWork.BultosRepository.Insert(oButos);

                    unitOfWork.Save();
                    //Agrego los bultos de correspondencia
                    pBultos.Add(oButos.BLT_NUMERO);

                    List<BultosValores> oBultosValores = new List<BultosValores>();


                    CalculoTafiras oTar = new CalculoTafiras();

                    oBultosValores = oTar.CalcularCorrespondencia(oButos.PROD_ID, oButos.BLT_PESO, oButos.BLT_PIEZAS, oButos.CTE_ID);

                    foreach (BultosValores oVal in oBultosValores)
                    {
                        BultosValores oBultosVal = new BultosValores();

                        oBultosVal.BLT_NUMERO = oButos.BLT_NUMERO;
                        oBultosVal.BVA_MONTO = oVal.BVA_MONTO;
                        oBultosVal.BVA_MONTO_APLICAR = oVal.BVA_MONTO_APLICAR;
                        oBultosVal.BVA_MONTO_LOCAL = oVal.BVA_MONTO_LOCAL;
                        oBultosVal.BVA_TASA = oVal.BVA_TASA;
                        oBultosVal.CARGO_PROD_ID = oVal.CARGO_PROD_ID;

                        unitOfWork.BultosValoresRepository.Insert(oBultosVal);

                    }


                    unitOfWork.Save();
                    bRetorno = true;

                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    string s = "";


                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += ve.ErrorMessage + "\n";

                    }
                    throw e;
                }
                //throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bRetorno;

        }


    }
}
