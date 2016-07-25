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
using System.Transactions;

namespace OpeAgencia2.Creditos
{
    public partial class frmCargosVarios : Form
    {
        public frmCargosVarios()
        {
            InitializeComponent();
        }


        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        int iCteId = -1;

        private void frmCargosVarios_Load(object sender, EventArgs e)
        {
            ComboCargos();
        }


        private void txtEPS_Leave(object sender, EventArgs e)
        {
            if (txtEPS.Text != "")
                BuscarCliente();
        }


        void BuscarCliente()
        {

            oCliente = unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtEPS.Text && s.CTE_SUC_ID == Parametros.Parametros.SucursalActual).FirstOrDefault();

            if (oCliente != null)
            {
                lblNombres.Text = oCliente.CTE_NOMBRE + " " + oCliente.CTE_APELLIDO;
                iCteId = oCliente.CTE_ID;

            }
            else
            {
                MessageBox.Show("No existe EPS", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtEPS.Text = "";
                txtEPS.Focus();

                lblNombres.Text = "";
                iCteId = -1;

            }

        }


        void ComboCargos()
        {

            var cargosExits = from p in unitOfWork.CargosRepository.Get(filter: s => s.CAR_BASE_ID == 29 && s.CAR_ESTADO == true && s.CAR_COBROS == true) /*tipo cargos*/
                              select new { Id = p.CARGO_ID, Nombre = p.CAR_CODIGO + "-->" + p.CAR_DESCRIPCION };


            //
            this.cmbCargos.ValueMember = "Id";
            cmbCargos.DisplayMember = "Nombre";
            //


            cmbCargos.DataSource = cargosExits.ToList();



            cmbCargos.SelectedValue = -1;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (iCteId == -1)
            {
                MessageBox.Show("Es necesario registra un numero de eps", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int iCargoId = -1;

            if (txtMonto.DecimalValue == 0)
            {
                MessageBox.Show("El importe debe ser diferente de 0", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
     

            iCargoId = Convert.ToInt32(cmbCargos.SelectedValue);

            var cargosProd = unitOfWork.CargosRepository.GetByID(iCargoId);

            if (cargosProd.CAR_NC == true && txtMonto.DecimalValue > 0)
            {
                MessageBox.Show("Para las Notas de créditos el importe debe ser negativo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (cargosProd.CAR_NC == false && txtMonto.DecimalValue < 0)
            {
                MessageBox.Show("Para las Notas de débitos el importe debe ser positivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }



            BO.Models.CargosVarios oCargos = new BO.Models.CargosVarios();

            oCargos.CARGO_ID = cargosProd.CARGO_ID;

            oCargos.CTE_ID = iCteId;

            oCargos.DESCR = txtDesc.Text;

            oCargos.F_CREA = DateTime.Now;

            oCargos.IMPORTE = txtMonto.DecimalValue;

            oCargos.ESTADO_ID = 17;


            try
            {
                unitOfWork = new BO.DAL.UnitOfWork();

                unitOfWork.CargosVariosRepository.Insert(oCargos);

                unitOfWork.Save();

                LimpiarPantalla();

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        void LimpiarPantalla()
        {
            txtMonto.DecimalValue = 0;
            txtDesc.Text = "";
            cmbCargos.SelectedValue = 0;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                ConsultarDatos();
            }
            if (tabControl1.SelectedIndex == 2)
            {
                ConsultarDatosRecibos();
            }
        }


        void ConsultarDatos()
        {

            unitOfWork = new BO.DAL.UnitOfWork();

            var oCargos = from p in unitOfWork.CargosVariosRepository.Get(filter: s => s.CTE_ID == iCteId)
                          orderby p.F_CREA descending
                          select new { p.CARGVAR_ID,p.ESTADO_ID , Creación = p.F_CREA, Facturación = p.F_FACT, Descripción= p.Cargos.CAR_DESCRIPCION,Estado= p.Estados.ESTADO_DESCR,p.IMPORTE };


            dgCargos.DataSource = oCargos.ToList();

            dgCargos.Columns[0].Visible = false;
            dgCargos.Columns[1].Visible = false;

            unitOfWork.Save();
          
                    
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList oCargos = new ArrayList();
            //
            //Facturacion de cargos varioas.
            foreach(DataGridViewRow gvRow in dgCargos.SelectedRows)
            {
                if (Convert.ToInt32(gvRow.Cells[1].Value)  != 17 )  /*HARD CODE CREADO*/
                {
                    MessageBox.Show( "Solo se pueden facturar cargos creados","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                oCargos.Add(Convert.ToInt32(gvRow.Cells[0].Value));
            }
            //ArrayList pCargVar, int iCteId, int iUsuarioId, int iSucId, int iTipoFiscal
            BO.BO.Facturar oFact = new BO.BO.Facturar();

            if (oCargos.Count > 0)
            {
                if (oFact.CrearFacturaCargoVarios(oCargos, oCliente.CTE_ID,
                    Parametros.Parametros.UsuarioId, Parametros.Parametros.SucursalActual, oCliente.CTE_TIPO_FISCAL) 
                    == true)
                {
                    MessageBox.Show("Factura creada exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectedIndex = 0;
                }
            }
        }

        private void txtEPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtEPS.Text != "" && e.KeyCode == Keys.Enter)
                BuscarCliente();
        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        void ProcesoDeAnulacion()
        {
            ArrayList oFacturas = new ArrayList();
            //
            //Facturacion de cargos varioas.
            foreach (DataGridViewRow gvRow in this.dgFacturas.SelectedRows)
            {
                int iReciboId = -1;
                unitOfWork = new BO.DAL.UnitOfWork();


                iReciboId= Convert.ToInt32(gvRow.Cells[0].Value);

                var oRecibos = unitOfWork.RecibosRepository.GetByID(iReciboId);

                oRecibos.ESTADO_ID = 15;

                unitOfWork.RecibosRepository.Update(oRecibos);

                unitOfWork.Save();
               

            }
            //ArrayList pCargVar, int iCteId, int iUsuarioId, int iSucId, int iTipoFiscal
           
            
        }

        void ConsultarDatosRecibos()
        {
            unitOfWork = new BO.DAL.UnitOfWork();

            var oRecibos = from p in unitOfWork.RecibosRepository.Get(filter: s => s.CTE_ID == iCteId  && s.Tipos.TIPO_ID == 54 && s.IMPORTE_CTA==0)
                           select new
                           {
                               p.RECIBO_ID,
                               Tipo= p.Tipos.TIPO_DESCR,
                               Fecha = p.FECHA,
                               Estado = p.Estados.ESTADO_NOMBRE,
                               Monto= p.IMPORTE_TOTAL
                           };
            this.dgFacturas.DataSource = oRecibos.ToList();
            this.dgFacturas.Columns[0].Visible = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            /*Anular Cargovario*/
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ProcesoDeAnulacion();
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }

        }
    }
}
