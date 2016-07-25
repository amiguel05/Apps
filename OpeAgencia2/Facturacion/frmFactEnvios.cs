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
using clsUtils;

namespace OpeAgencia2.Facturacion
{
    public partial class frmFactEnvios : Form
    {
        public frmFactEnvios()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        private BO.DAL.dsDatos.EnviosDataTable oEnvio = new BO.DAL.dsDatos.EnviosDataTable();
        BO.DAL.dsDatos.BultosValoresCargosDataTable oUnidades = new BO.DAL.dsDatos.BultosValoresCargosDataTable();
        //
        int iSecuenciaId = 0;


        int iCteId = -1;

        private void frmFactEnvios_Load(object sender, EventArgs e)
        {

            CargarDataGrid();

        }

        void CargarDataGrid()
        {
            dgEnvios.DataSource = oEnvio;

            for (int i = 0; i < oEnvio.Columns.Count; i++)
            {

                dgEnvios.Columns[i].Visible = false;
                dgEnvios.Columns[i].ReadOnly = true;

            }

            dgEnvios.Columns[2].Visible = true;
            dgEnvios.Columns[4].Visible = true;
            dgEnvios.Columns[5].Visible = true;
            dgEnvios.Columns[13].Visible = true;
            dgEnvios.Columns[20].Visible = true;



        }

        void ActualizaTotal()
        {
            int iPaq = 0;
            decimal dMonto = 0;

            for (int i = 0; i < dgEnvios.Rows.Count; i++)
            {
                iPaq++;
                dMonto += Convert.ToDecimal(dgEnvios.Rows[i].Cells[20].Value);
            }
            this.txtPaq.Text = iPaq.ToString();
            txtMontoTotal.Text = dMonto.ToString();
        }

        void BuscarCliente()
        {
            if (txtEPS.Text == "")
            {
                lblNombres.Text = string.Empty;
                iCteId = -1;
                return;
            }
            oCliente = unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtEPS.Text && s.CTE_SUC_ID == Parametros.Parametros.SucursalActual).FirstOrDefault();
            if (oCliente != null)
            {
                lblNombres.Text = oCliente.CTE_NOMBRE + " " + oCliente.CTE_APELLIDO;
                dFechaVenc.Value = oCliente.CTE_FECHA_VENCIMIENTO;

                //Si el cliente no esta activo, no puede seguir
                if (oCliente.CTE_ESTADO_ID != 8)
                {
                    MessageBox.Show("El cliente no está Activo, no se pudede facturar ", " Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                cmbTipoFact.SelectedIndex = 0;
                if (oCliente.CTE_CEDULA.KeepOnlyNumbers().ToString().TrimEnd() == "" && oCliente.CTE_RNC.KeepOnlyNumbers().ToString().TrimEnd() == "" && oCliente.CTE_PASAPORTE.ToString().TrimEnd() == "")
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
                else
                { 
                    btnFacturar.Enabled = true; 
                }
                if (oCliente.CTE_CREDITO == true)
                {
                    cmbTipoFact.Enabled = true;
                }
                else
                {
                    cmbTipoFact.Enabled = false;
                }
                iCteId = oCliente.CTE_ID;
            }
            else
            {
                MessageBox.Show("No existe EPS", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtEPS.Text = "";
                txtEPS.Focus();
                iCteId = -1;
                lblNombres.Text = "";
                // dgPaq.DataSource = null;
                // dgCorr.DataSource = null;
            }

        }

        private void txtEPS_Leave(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (iCteId != -1)
            {
                frmAgregarEnvio x = new frmAgregarEnvio(iCteId);
                x.ShowDialog();
                if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    iSecuenciaId++;

                    BO.DAL.dsDatos.EnviosRow dr = (BO.DAL.dsDatos.EnviosRow)x.DatosEnvio.Rows[0];

                    BO.DAL.dsDatos.EnviosRow oEnvioRow = oEnvio.NewEnviosRow();

                    for (int i = 1; i < oEnvio.Columns.Count; i++)
                    {
                        oEnvioRow[i] = dr[i];

                    }
                    oEnvioRow.Id = iSecuenciaId;

                    oEnvio.Rows.Add(oEnvioRow);


                    foreach (DataRow drnew in x.UnidadesRetorno.Rows)
                    {
                        BO.DAL.dsDatos.BultosValoresCargosRow oUnidaesRow = oUnidades.NewBultosValoresCargosRow();

                        for (int i = 0; i < oUnidades.Columns.Count; i++)
                        {
                            oUnidaesRow[i] = drnew[i];
                        }
                        oUnidaesRow.ID = iSecuenciaId;
                        oUnidades.Rows.Add(oUnidaesRow);
                    }

                    /*foreach (DataRow drnew in x.CargosRetorno.Rows)
                    {
                        BO.DAL.dsDatos.BultosValoresCargosRow oUnidaesRow = oUnidades.NewBultosValoresCargosRow();

                        for (int i = 0; i < oUnidades.Columns.Count; i++)
                        {
                            oUnidaesRow[i] = drnew[i];
                        }
                        oUnidaesRow.ID = iSecuenciaId;
                        oUnidades.Rows.Add(oUnidaesRow);
                    }*/

                    ActualizaTotal();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente para agregar envíos", "Cliente", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txtEPS.Focus();
            }
        }

        private void dgEnvios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ActualizaTotal();

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrarEnvio();
        }

        void BorrarEnvio()
        {
            int iEnvioId = -1;

            try
            {
                iEnvioId = Convert.ToInt32(dgEnvios.Rows[dgEnvios.CurrentCell.RowIndex].Cells[0].Value);

                for (int i = 0; i < oUnidades.Rows.Count; i++)
                {
                    if (Convert.ToInt32(oUnidades.Rows[i][0]) == iEnvioId)
                    {
                        oUnidades.Rows[i].Delete();
                        oUnidades.AcceptChanges();
                    }
                }
                for (int i = 0; i < oEnvio.Rows.Count; i++)
                {
                    if (Convert.ToInt32(oEnvio.Rows[i][0]) == iEnvioId)
                    {
                        oEnvio.Rows[i].Delete();
                        oEnvio.AcceptChanges();
                    }
                }
            }
            catch
            {

            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {

            bool bCredito, bPagado = false;
            decimal dMontoEfectivo = 0;
            decimal dMontoOtros = 0;
            decimal dDevolucion = 0;
            BO.DAL.dsDatos.DatosPagoDataTable DatosPago = new BO.DAL.dsDatos.DatosPagoDataTable();

            if (cmbTipoFact.SelectedIndex == 1)
                bCredito = true;
            else
                bCredito = false;

            if (!bCredito)
            {
                frmDatosPago x = new frmDatosPago(Convert.ToDecimal(txtMontoTotal.Text));
                x.StartPosition = FormStartPosition.CenterParent;
                x.ShowDialog();
                dMontoEfectivo = x.MontoEfectivo;
                dMontoOtros = x.MontoOtros;
                dDevolucion = x.Devolucion;
                DatosPago = x.DatosPago;
                if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
                    bPagado = true;

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
                bPagado = false;

            }

            if ((bCredito == true) || (bPagado == true))
            {
                if (bCredito)
                {
                    //VALIDO  QUE EL CLIENTE TENGA BALANCE
                    if (oCliente.CTE_BALANCE_DISPONIBLE - Convert.ToDecimal(txtMontoTotal.Text) < 0)
                    {
                        MessageBox.Show("El balance disponible del cliente es de: " + oCliente.CTE_BALANCE_DISPONIBLE.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }//Aqui tengo que ver si el cliente esta suspendido


                BO.BO.Facturar oFact = new BO.BO.Facturar();
                if (oFact.CrearFacturaEnvio(dMontoEfectivo, dMontoOtros, dDevolucion, DatosPago,
                                   oCliente.CTE_ID, oCliente.CTE_TIPO_FISCAL, Parametros.Parametros.SucursalActual,
                                   Parametros.Parametros.UsuarioId,
                                   oEnvio, oUnidades, Convert.ToDecimal(txtMontoTotal.Text), bCredito))
                {//Todo anduvo bien. Entonces Imprimo y limpio la pantalla.

                    oFact.RevisarTotales(oFact.FacturaGenerada);

                    if (Parametros.ParametrosSucursal.NoImpresoraFiscal == true)
                    {
                        ImprimirFactura oImpFact = new ImprimirFactura();
                        oImpFact.Imprimir2Printer(oFact.FacturaGenerada);

                    }
                    else
                    {

                        //ImprimirFactura(oFact.FacturaGenerada);
                        ImprimirFactura oImpFact = new ImprimirFactura();
                        oImpFact.Imprimir(oFact.FacturaGenerada, DatosPago);

                    }


              

                    LimpiarPantalla();
                }

            }
        }


        void LimpiarPantalla()
        {
            oEnvio.Rows.Clear();
            oUnidades.Rows.Clear();
            //dgEnvios.DataSource = null;
            txtEPS.Text = "";
            txtEPS.Focus();
            lblNombres.Text = "";
            txtMontoTotal.Text = "0";
            txtPaq.Text = "0";
            cmbTipoFact.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BuscarCliente();
        }
    }
}
