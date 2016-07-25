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
using System.Collections;
using clsUtils;

namespace OpeAgencia2.Facturacion
{
    public partial class frmFactMercancia : Form
    {
        public frmFactMercancia()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        //
        BO.DAL.dsDatos.CorrespondenciaDataTable oTableCorr;

        Hashtable htValores = new Hashtable();
        decimal dMontoNoVenta;
        decimal dMontoVenta;

        private void frmFactMercancia_Load(object sender, EventArgs e)
        {

            if (Parametros.ParametrosSucursal.NoImpresoraFiscal == false)
            {
                if (Parametros.ParametrosSucursal.TermFiscalId == -1)
                {
                    MessageBox.Show("Esta unidad no tiene configurada una impresora fiscal", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //return;
                }

            }
            
            CargarCorrespondencia();
            LimpiarPantalla();
        }

        void CargarCorrespondencia()
        {
            oTableCorr = new BO.DAL.dsDatos.CorrespondenciaDataTable();
            dgCorr.DataSource = oTableCorr;
            dgCorr.Columns[0].Visible = false;
            dgCorr.Columns[3].Visible = false;
        }

        void BuscarPaquetes(int iCteId)
        {
            var oBultos = from p in unitOfWork.VW_BultosValoresRepository.Get(filter: s => s.CTE_ID == iCteId && s.BLT_ESTADO_ID == 2)
                          select new
                          {
                              p.BLT_NUMERO,
                              p.BLT_CODIGO_BARRA,
                              p.CONTENIDO,
                              p.BLT_PESO,
                              p.BLT_TRACKING_NUMBER,
                              p.MONTO
                          };
            this.dgPaq.DataSource = oBultos.ToList();
            this.dgPaq.Columns[0].Visible = false;
        }

        void BuscarPaquetes2(int iCteId)
        {
            BO.DAL.dsDatos.VW_BULTOSDataTable dt = new BO.DAL.dsDatos.VW_BULTOSDataTable();

            var oBultos = unitOfWork.BultosRepository.Get(filter: s => s.CTE_ID == iCteId && s.BLT_ESTADO_ID == 2);

           

            foreach(var oBulto in oBultos  )
            {
                BO.DAL.dsDatos.VW_BULTOSRow oRow = dt.NewVW_BULTOSRow();
                 decimal dMonto = 0;
                oRow.BLT_CODIGO_BARRA = oBulto.BLT_CODIGO_BARRA;
                oRow.BLT_NUMERO = oBulto.BLT_NUMERO;
                oRow.BLT_PESO = oBulto.BLT_PESO;
                oRow.BLT_TRACKING_NUMBER = oBulto.BLT_TRACKING_NUMBER;
                oRow.CONTENIDO = oBulto.CONTENIDO;
                
                var oBultosDet = unitOfWork.BultosValoresRepository.Get(filter: s=>s.BLT_NUMERO == oBulto.BLT_NUMERO);

                foreach (var v in oBultosDet)
                {
                    dMonto += Math.Round(v.BVA_MONTO_LOCAL, 2, MidpointRounding.ToEven);

                }

                oRow.MONTO = dMonto;

                dt.Rows.Add(oRow);
            }


            this.dgPaq.DataSource = dt;
            this.dgPaq.Columns[0].Visible = false;
        }

        void BuscarCliente()
        {
            unitOfWork = new BO.DAL.UnitOfWork();

            if (oTableCorr != null)
                oTableCorr.Rows.Clear();
            dgPaq.DataSource = null;
            dgResumen.DataSource = null;
            
            lblNombres.Text = "";
            txtMontoTotal.Text = "0";
            txtPaq.Text = "0";
            cmbTipoFact.SelectedIndex = 0;
            txtTarifa.Text = string.Empty;
            lblCorrespondencia.Text = "";


            txtTarifa.Text = "";
            oCliente = unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtEPS.Text && s.CTE_SUC_ID == Parametros.Parametros.SucursalActual).FirstOrDefault();
            if (oCliente != null)
            {
                lblNombres.Text = oCliente.CTE_NOMBRE + " " + oCliente.CTE_APELLIDO;
                dFechaVenc.Value = oCliente.CTE_FECHA_VENCIMIENTO;
                
                //Si el cliente no esta activo, no puede seguir
               if( oCliente.CTE_ESTADO_ID != 8)
               {
                   MessageBox.Show("El cliente no está Activo, no se pudede facturar ", " Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                   return;
               }


                BuscarPaquetes2(oCliente.CTE_ID);
                if (oCliente.CTE_CREDITO == true)
                {
                    cmbTipoFact.Enabled = true;
                    cmbTipoFact.SelectedIndex = 1;
                }
                else
                {
                    cmbTipoFact.Enabled = false;
                }
                //
                if (oCliente.CTE_CORRESPONDENCIA)
                    lblCorrespondencia.Text = "Cliente tiene correspondencia";
                else
                    lblCorrespondencia.Text = "";
                //
                var ctePasaporte = oCliente.CTE_PASAPORTE ?? "";
                if (oCliente.CTE_CEDULA.KeepOnlyNumbers().ToString().TrimEnd() == "" && oCliente.CTE_RNC.KeepOnlyNumbers().ToString().TrimEnd() == "" && ctePasaporte.TrimEnd() == "")
                {
                    if (oCliente.CTE_TIPO_FISCAL != 47) //DIFETENTE DE PERSONA FISICA
                    {
                        if (oCliente.CTE_CEDULA.KeepOnlyNumbers().ToString().TrimEnd() == "" && oCliente.CTE_RNC.KeepOnlyNumbers().ToString().TrimEnd() == "")
                        {
                            MessageBox.Show("Este cliente no tienen un documento de identificación válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            btnFacturar.Enabled = false;
                            return;
                        }
                    }
                    MessageBox.Show("Este cliente no tienen un documento de identificación válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnFacturar.Enabled = false;
                    return;
                }
                btnFacturar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No existe EPS", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                LimpiarPantalla();
                btnFacturar.Enabled = false;
            }
        }

        private void txtEPS_Leave(object sender, EventArgs e)
        {
            if (txtEPS.Text != "")
                BuscarCliente();
        }

        private void dgPaq_SelectionChanged(object sender, EventArgs e)
        {
            ActualizaTotal();
        }

        void ActualizaTotal()
        {
            int iPaq = 0;
            decimal dMonto = 0;
            decimal dMontoCorr = 0;
            htValores.Clear();
            dgResumen.Rows.Clear();
            dMontoNoVenta = 0;
            dMontoVenta = 0;
            for (int i = 0; i < dgPaq.Rows.Count; i++)
            {
                if (dgPaq.Rows[i].Selected == true)
                {
                    iPaq++;
                    dMonto += Math.Round(Convert.ToDecimal(dgPaq.Rows[i].Cells[5].Value), 2, MidpointRounding.ToEven);
                    BuscarValores(Convert.ToInt32(dgPaq.Rows[i].Cells[0].Value));
                }
            }
            //
            for (int i = 0; i < this.dgCorr.Rows.Count; i++)
            {
                iPaq++;
                dMonto += Math.Round(Convert.ToDecimal(dgCorr.Rows[i].Cells[2].Value),2,  MidpointRounding.ToEven);
                dMontoCorr = dMontoCorr + Math.Round(Convert.ToDecimal(dgCorr.Rows[i].Cells[2].Value),2, MidpointRounding.ToEven);
            }
            dMontoVenta += dMontoCorr;
            this.txtPaq.Text = iPaq.ToString();
            txtMontoTotal.Text = string.Format("{0:0,0.00}", dMontoVenta);
            txtMontoNoVenta.Text = string.Format("{0:0,0.00}", dMontoNoVenta);
            foreach (var item in htValores.Keys)
            {
                dgResumen.Rows.Add(item, string.Format("{0:0,0.00}", htValores[item]));
            }
            if (dMontoCorr > 0)
            {
                dgResumen.Rows.Add("Correspondencia", string.Format("{0:0,0.00}", dMontoCorr));
            }
        }

        void BuscarValores(int bltNumero)
        {
            var loBultosVal = from p in unitOfWork.BultosValoresRepository.Get(filter: xy => xy.BLT_NUMERO == bltNumero)
                              select new { Cargo = p.CargosProducto.Cargos.CAR_CODIGO + '-' + p.CargosProducto.Cargos.CAR_DESCRIPCION, 
                                  Monto = p.BVA_MONTO_LOCAL, ncf = p.CargosProducto.Cargos.CAR_NCF, p.CargosProducto.Cargos.CAR_CODIGO,
                                  MontoAplicar = p.BVA_MONTO_APLICAR};
            foreach (var cargo in loBultosVal)
            {
                if (htValores[cargo.Cargo] == null)
                    htValores.Add(cargo.Cargo, Math.Round(cargo.Monto,2,MidpointRounding.ToEven));
                else
                    htValores[cargo.Cargo] = Convert.ToDecimal(htValores[cargo.Cargo]) +  Math.Round(cargo.Monto,2, MidpointRounding.ToEven);
                if (cargo.ncf == false && cargo.CAR_CODIGO != "999")
                    dMontoNoVenta +=  Math.Round(cargo.Monto,2, MidpointRounding.ToEven);
                else
                    dMontoVenta +=  Math.Round(cargo.Monto,2, MidpointRounding.ToEven);

                if (cargo.CAR_CODIGO == "010")
                    txtTarifa.Text = cargo.MontoAplicar.ToString();
            }
        }

        private void btnCorres_Click(object sender, EventArgs e)
        {
            frmCorrespond x = new frmCorrespond();
            x.ShowDialog();
            if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                //Agregar correspondecia.
                if ((x.Peso > 0) || (x.Piezas > 0))
                {
                    RegistraCorrespondencia(x.Peso, x.Piezas);
                    ActualizaTotal();
                }
            }
        }

        void RegistraCorrespondencia(decimal pdPeso, int piPiezas)
        {
            List<BO.Models.BultosValores> oBultosValores = new List<BO.Models.BultosValores>();
            DataRow dr = oTableCorr.NewRow();
            dr["Producto"] = Parametros.Parametros.NomProdCorrespondencia;
            dr["ProdId"] = Parametros.Parametros.ProdCorrespondencia;
            dr["Piezas"] = piPiezas;
            dr["Peso"] = pdPeso;
            dr["Monto"] = 0;
            BO.BO.CalculoTafiras oTar = new BO.BO.CalculoTafiras();
            oBultosValores = oTar.CalcularCorrespondencia(Parametros.Parametros.ProdCorrespondencia, pdPeso, piPiezas, oCliente.CTE_ID);
            foreach (BO.Models.BultosValores oVal in oBultosValores)
            {
                dr["Monto"] = Math.Round((decimal)dr["Monto"] + oVal.BVA_MONTO_LOCAL, 2);
            }
            oTableCorr.Rows.Add(dr);
        }

        private void dgCorr_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ActualizaTotal();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }

        void LimpiarPantalla()
        {
            if (oTableCorr != null)
                oTableCorr.Rows.Clear();
            dgPaq.DataSource = null;
            dgResumen.DataSource = null;
            txtEPS.Text = "";
            txtEPS.Focus();
            lblNombres.Text = "";
            txtMontoTotal.Text = "0";
            txtPaq.Text = "0";
            cmbTipoFact.SelectedIndex = 0;
            txtTarifa.Text = string.Empty;
            lblCorrespondencia.Text = "";
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            /*Prueba*/
            if (dMontoVenta > 0)
                FacturarVenta();
            LimpiarPantalla();
        }

        void FacturarVenta()
        {
            ArrayList oBltNumeros = new ArrayList();
            bool bCredito, bPagado = false;
            decimal dMontoEfectivo = 0;
            decimal dMontoOtros = 0;
            decimal dDevolucion = 0;
            decimal dMontoEfectivoNoventa = 0;
            decimal dMontoOtrosNoVenta = 0;
            decimal dMontoEfectivoVenta = 0;
            decimal dMontoOtrosVenta = 0;
            BO.DAL.dsDatos.DatosPagoDataTable DatosPago = new BO.DAL.dsDatos.DatosPagoDataTable();
            BO.DAL.dsDatos.DatosPagoDataTable DatosPagoNoVenta = new BO.DAL.dsDatos.DatosPagoDataTable();
            BO.DAL.dsDatos.DatosPagoDataTable DatosPagoVenta = new BO.DAL.dsDatos.DatosPagoDataTable();
            bCredito = cmbTipoFact.SelectedIndex == 1;
            if (!bCredito)
            {
                frmDatosPago x = new frmDatosPago(dMontoVenta + dMontoNoVenta);
                x.StartPosition = FormStartPosition.CenterParent;
                x.ShowDialog();
                dMontoEfectivo = x.MontoEfectivo;
                dMontoOtros = x.MontoOtros;
                dDevolucion = x.Devolucion;
                DatosPago = x.DatosPago;
                if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
                    bPagado = true;
                else
                    return;
                if (DatosPago.Rows.Count == 0)
                {
                    BO.DAL.dsDatos.DatosPagoRow oRow = DatosPago.NewDatosPagoRow();
                    oRow.Banco = -1;
                    oRow.BancoDesc = "";
                    oRow.Devolucion = dDevolucion;
                    oRow.Fecha = DateTime.Now;
                    oRow.Importe = Convert.ToDecimal(txtMontoTotal.Text);
                    oRow.MontoEfectivo = dMontoEfectivo;
                    oRow.Numero = 99;
                    oRow.TipoPago = -1;
                    oRow.TipoPagoDesc = "";
                    DatosPago.Rows.Add(oRow);
                }
            }
            else
            {
                //VALIDO  QUE EL CLIENTE TENGA BALANCE
                if (oCliente.CTE_BALANCE_DISPONIBLE - Convert.ToDecimal(txtMontoTotal.Text) < 0)
                {
                    MessageBox.Show("El balance disponible del cliente es de: " + oCliente.CTE_BALANCE_DISPONIBLE.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                bPagado = false;
            }
            /*Tengo que hacer doble desglose*/
            if (dMontoNoVenta > 0)
            {
                if (bCredito == false)
                    RetornaDatosPagos(DatosPago, ref DatosPagoNoVenta, dMontoNoVenta, ref dMontoEfectivoNoventa, ref dMontoOtrosNoVenta);

                FacturarNoVenta(DatosPagoNoVenta, bCredito, dMontoNoVenta, dMontoEfectivoNoventa, dMontoOtrosNoVenta);
            }
            if (dMontoVenta > 0)
            {
                dMontoEfectivoVenta = dMontoEfectivo - dMontoEfectivoNoventa;
                if (!bCredito)
                {
                    if (bCredito == false)
                        RetornaDatosPagos(DatosPago, ref DatosPagoVenta, dMontoVenta, ref dMontoEfectivoVenta, ref dMontoOtrosVenta);
                }
                if ((bCredito == true) || (bPagado == true))
                {

                }//Aqui tengo que ver si el cliente esta suspendido
                BultosAFacturar(ref oBltNumeros);
                BO.BO.Facturar oFact = new BO.BO.Facturar();
                if (oFact.CrearFactura(dMontoEfectivoVenta, dMontoOtrosVenta, dDevolucion, DatosPagoVenta,
                                   oCliente.CTE_ID, oCliente.CTE_TIPO_FISCAL, Parametros.Parametros.SucursalActual,
                                   Parametros.Parametros.UsuarioId, oBltNumeros,
                                   oTableCorr, dMontoVenta, bCredito))
                {//Todo anduvo bien. Entonces Imprimo y limpio la pantalla.
                    //ImprimirFactura(oFact.FacturaGenerada);
                    //BO.BO.Facturar oFact = new BO.BO.Facturar();
                    oFact.RevisarTotales(oFact.FacturaGenerada);

                    if (Parametros.ParametrosSucursal.NoImpresoraFiscal == true)
                    {
                        ImprimirFactura oImpFact = new ImprimirFactura();
                        oImpFact.Imprimir2Printer(oFact.FacturaGenerada);

                    }
                    else
                    {

                        ImprimirFactura oImpFact = new ImprimirFactura();
                        oImpFact.Imprimir(oFact.FacturaGenerada, DatosPago);
                    }

                }
            }
        }

        void RetornaDatosPagos(BO.DAL.dsDatos.DatosPagoDataTable DatosPago, ref BO.DAL.dsDatos.DatosPagoDataTable newDatosPago, decimal dMonto, ref  decimal dMontoEfectvo, ref decimal dMontoOtros)
        {
            decimal dMontoRestante = 0;
            foreach (BO.DAL.dsDatos.DatosPagoRow dr in DatosPago.OrderBy(p => p.TipoPago))
            {
                /*Pago Efect*/
                if (dr.TipoPago == -1)
                {
                    if (dr.MontoEfectivo >= dMonto)
                    {
                        dMontoEfectvo = dMonto;
                        BO.DAL.dsDatos.DatosPagoRow oNewRow = newDatosPago.NewDatosPagoRow();
                        oNewRow.MontoEfectivo = dMonto;
                        oNewRow.Importe = dMonto;
                        oNewRow.Numero = dr.Numero;
                        oNewRow.TipoPago = dr.TipoPago;
                        oNewRow.TipoPagoDesc = dr.TipoPagoDesc;
                        oNewRow.Fecha = dr.Fecha;
                        oNewRow.Devolucion = 0;
                        oNewRow.Banco = dr.Banco;
                        oNewRow.BancoDesc = dr.BancoDesc;
                        newDatosPago.Rows.Add(oNewRow);
                        break;
                    }
                    else
                    {
                        dMontoEfectvo = dr.MontoEfectivo;
                        BO.DAL.dsDatos.DatosPagoRow oNewRow = newDatosPago.NewDatosPagoRow();
                        oNewRow.MontoEfectivo = dr.MontoEfectivo;
                        oNewRow.Importe = dr.MontoEfectivo;
                        oNewRow.Numero = dr.Numero;
                        oNewRow.TipoPago = dr.TipoPago;
                        oNewRow.TipoPagoDesc = dr.TipoPagoDesc;
                        oNewRow.Fecha = dr.Fecha;
                        oNewRow.Devolucion = 0;
                        oNewRow.Banco = dr.Banco;
                        oNewRow.BancoDesc = dr.BancoDesc;
                        newDatosPago.Rows.Add(oNewRow);
                        dMontoRestante = dMonto - dr.MontoEfectivo;
                    }
                }
                else
                {
                    dMontoOtros = dMonto;
                    BO.DAL.dsDatos.DatosPagoRow oNewRow = newDatosPago.NewDatosPagoRow();
                    oNewRow.MontoEfectivo = 0;
                    oNewRow.Importe = dMonto;
                    oNewRow.Numero = dr.Numero;
                    oNewRow.TipoPago = dr.TipoPago;
                    oNewRow.TipoPagoDesc = dr.TipoPagoDesc;
                    oNewRow.Fecha = dr.Fecha;
                    oNewRow.Devolucion = 0;
                    oNewRow.Banco = dr.Banco;
                    oNewRow.BancoDesc = dr.BancoDesc;
                    newDatosPago.Rows.Add(oNewRow);
                    break;
                }
            }
        }

        void FacturarNoVenta(BO.DAL.dsDatos.DatosPagoDataTable DatosPago, bool bCredito, decimal dMontoNoVenta, decimal dMontoEfectivo, decimal dMontoOtros)
        {
            ArrayList oBltNumeros = new ArrayList();
            decimal dDevolucion = 0;
            if (bCredito)
            {
                //VALIDO  QUE EL CLIENTE TENGA BALANCE
                if (oCliente.CTE_BALANCE_DISPONIBLE - Convert.ToDecimal(txtMontoTotal.Text) < 0)
                {
                    MessageBox.Show("El balance disponible del cliente es de: " + oCliente.CTE_BALANCE_DISPONIBLE.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }//Aqui tengo que ver si el cliente esta suspendido
            BultosAFacturar(ref oBltNumeros);
            BO.BO.Facturar oFact = new BO.BO.Facturar();
            if (oFact.CrearFacturaNoVenta(dMontoEfectivo, dMontoOtros, dDevolucion, DatosPago,
                                oCliente.CTE_ID, oCliente.CTE_TIPO_FISCAL, Parametros.Parametros.SucursalActual,
                                Parametros.Parametros.UsuarioId, oBltNumeros,
                                oTableCorr, dMontoNoVenta, bCredito))
            {//Todo anduvo bien. Entonces Imprimo y limpio la pantalla.
                //ImprimirFactura(oFact.FacturaGenerada);
                if (Parametros.ParametrosSucursal.NoImpresoraFiscal == true)
                {
                    ImprimirFactura oImpFact = new ImprimirFactura();
                    oImpFact.Imprimir2Printer(oFact.FacturaGenerada);

                }
                else
                {

                    ImprimirFactura oImpFact = new ImprimirFactura();
                     oImpFact.ImprimirNoVenta(oFact.FacturaGenerada, DatosPago);
                }

               
            }
        }

        void BultosAFacturar(ref ArrayList pBtlNumeros)
        {
            for (int i = 0; i < dgPaq.RowCount; i++)
            {
                if (dgPaq.Rows[i].Selected == true)
                    pBtlNumeros.Add(dgPaq.Rows[i].Cells[0].Value);
            }
        }

        private void txtEPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtEPS.Text != "" && e.KeyCode == Keys.Enter)
                BuscarCliente();
        }

        private void dgPaq_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgPaq.CurrentRow == null || dgPaq.CurrentRow.Index < 0)
            //    return;
            //int iBltNumero = -1;
            //iBltNumero = Convert.ToInt32(dgPaq.CurrentRow.Cells[0].Value);
            //Operaciones.frmRecepcion oFrom = new Operaciones.frmRecepcion(iBltNumero);
            //oFrom.ShowDialog();
        }
    }
}
