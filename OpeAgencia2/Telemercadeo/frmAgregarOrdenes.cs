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


namespace OpeAgencia2.Telemercadeo
{
    public partial class frmAgregarOrdenes : Form
    {
        public frmAgregarOrdenes()
        {
            InitializeComponent();
        }
        
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        int iCteId = -1;
        int iSecuencia = 0;
        bool bAdiciona = true;
        bool bPuedeModificar = true;

        BO.DAL.dsDatos.BultosValoresCargosDataTable oUnidades = new BO.DAL.dsDatos.BultosValoresCargosDataTable();


        private BO.DAL.dsFactura.ArticulosDataTable oTableArt = new BO.DAL.dsFactura.ArticulosDataTable();


        private void frmAgregarOrdenes_Load(object sender, EventArgs e)
        {
            LLenarCombos();
            dgArticulos.DataSource = oTableArt;
            CargarTasa();
            dgCargos.DataSource = oUnidades;
            dgCargos.Columns[0].Visible = false; ;
            dgCargos.Columns[1].Visible = false;
            dgCargos.Columns[2].Visible = false;
            dgCargos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        void CargarTasa()
        {
            var oTasa = unitOfWork.TasaCambioRepository.Get(filter: xy => xy.TASA_CODIGO == "US").FirstOrDefault();
            txtTasa.DecimalValue = oTasa.FACTOR_CONV;
        }



        #region "Combos"
        void LLenarCombos()
        {
            LlenarCombosEstado();
            CombosProductos();


        }

        void LlenarCombosEstado()
        {

            var oEstado = unitOfWork.EstadosRepository.GetByGroupCode("EOC");

            cmbEstado.DisplayMember = "ESTADO_NOMBRE";
            cmbEstado.ValueMember = "ESTADO_ID";

            cmbEstado.DataSource = oEstado.ToList();

        }



        void CombosProductos()
        {
            int liCodGrupo = -1;

            var grupos = unitOfWork.CodigosRepository.Get(filter: xy => xy.CODIGO_COD == "020").FirstOrDefault();

            liCodGrupo = grupos.CODIGO_ID;

            var Productos = from p in unitOfWork.ProductosRepository.Get(filter: xy => xy.Tipos.TIPO_CODIGO == "T" && xy.GRP_COD_ID == liCodGrupo)
                            select new { Id = p.PROD_ID, Nombre = p.PRO_CODIGO + "-->" + p.PRO_DESCRIPCION };
            cmbServicio.DisplayMember = "Nombre";
            cmbServicio.ValueMember = "Id";
            this.cmbServicio.DataSource = Productos.ToList();
        }

      

        #endregion

        private void txtEps_Leave(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        void BuscarCliente()
        {
            if (txtEPS.Text == "")
            {
                lblEps.Text = string.Empty;
                iCteId = -1;
                return;
            }
            var oCliente = unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtEPS.Text && s.CTE_SUC_ID == Parametros.Parametros.SucursalActual).FirstOrDefault();
            if (oCliente != null)
            {
                lblEps.Text = oCliente.CTE_NOMBRE + " " + oCliente.CTE_APELLIDO;

                iCteId = oCliente.CTE_ID;

                txtNombres.Text = lblEps.Text;

                txtTelefono.Text = oCliente.CTE_TELEFONO_CASA;

                txtDocumento.Text = oCliente.CTE_CEDULA.ToString();

                txtDireccion.Text = oCliente.CTE_DIRECCION_CASA;

                
            }
            else
            {
                MessageBox.Show("No existe EPS", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtEPS.Text = "";
                txtEPS.Focus();
                iCteId = -1;
                lblEps.Text = "";

            }

        }

        private void agregarElementoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(iCteId <= 0)
            {
                MessageBox.Show("Debe registra un cliente válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            frmAgregarArticulo oArt = new frmAgregarArticulo();
            oArt.ShowDialog();

            if (oArt.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                BO.DAL.dsFactura.ArticulosRow oRow = oTableArt.NewArticulosRow();

                oRow.ArticuloId_ = iSecuencia++;
                oRow.Articulo = oArt.Articulo;
                oRow.Descripcion = oArt.Descripcion;
                oRow.Cantidad = oArt.Cantidad;
                oRow.Valor = oArt.Valor;
                oRow.Total = oArt.Total;

                oTableArt.Rows.Add(oRow);

            }
        }

        private void dgArticulos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ActualizaTotal();
        }


        void ActualizaTotal()
        {

            if (iCteId <= 0)
            {
                MessageBox.Show("Debe registra un cliente válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int iPaq = 0;
            decimal dMonto = 0;


           
        
         
            for (int i = 0; i < dgArticulos.Rows.Count; i++)
            {
          
                    iPaq++;
                    dMonto += Math.Round(Convert.ToDecimal(dgArticulos.Rows[i].Cells[5].Value), 2);
                   /* BuscarValores(Convert.ToInt32(dgPaq.Rows[i].Cells[0].Value));*/
               
            }

            CarcularUnidades(dMonto + txtImpuesto.DecimalValue + txtGastosEnvios.DecimalValue);

            txtImporte.DecimalValue = (dMonto + txtImpuesto.DecimalValue + txtGastosEnvios.DecimalValue + txtGastosManejo.DecimalValue);
            txtImporteLocal.Text = Math.Round((dMonto + txtImpuesto.DecimalValue + txtGastosEnvios.DecimalValue + txtGastosManejo.DecimalValue) * txtTasa.DecimalValue,2).ToString();

         
        }

        private void txtImpuesto_Leave(object sender, EventArgs e)
        {
            ActualizaTotal();
        }

        private void txtGastosEnvios_Leave(object sender, EventArgs e)
        {
            ActualizaTotal();
        }

        void CarcularUnidades(decimal pdValorFOB)
        {
            int iProductoId = Convert.ToInt32(cmbServicio.SelectedValue);
            // s.Cargos.CAR_BASE_ID == 30, VALOR FOB

            var cargosExits = unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProductoId && s.Cargos.CAR_BASE_ID == 30 && s.Cargos.CAR_ESTADO == true && s.FIJO == true); /*tipo cargos*/
            // var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);
            
           oUnidades.Rows.Clear();
            foreach (var cargo in cargosExits)
            {
                decimal dPorcentaje = 0;

                DataRow oRow = oUnidades.NewRow();
                oRow["ID"] = -1;
                oRow["CARGO_PROD_ID"] = cargo.CARGO_PROD_ID;
                oRow["Desc"] = cargo.Cargos.CAR_DESCRIPCION;
                oRow["Tasa"] = cargo.TasaCambio.FACTOR_CONV;
                oRow["Monto"] = pdValorFOB.ToString();

                oRow["MontoAplicar"] = BuscarMontoAplicar(cargo.CARGO_PROD_ID, pdValorFOB, ref dPorcentaje);


                if (cargo.Cargos.CAR_FIJO_MULTIPLICAR == "F" && cargo.Cargos.CAR_DIRECTO_TABLA=="T") 
                {
                    if (Convert.ToDecimal(oRow["MontoAplicar"]) == 0)
                    {
                        if (dPorcentaje > 0)
                            oRow["MontoAplicar"] = Math.Round(pdValorFOB * dPorcentaje / 100,2, MidpointRounding.ToEven);
                    }

                    if (cargo.Cargos.CAR_CODIGO == "146")
                        txtGastosManejo.DecimalValue = Convert.ToDecimal(oRow["MontoAplicar"]);
                
                    oRow["MontoLocal"] = Math.Round(Convert.ToDecimal(oRow["MontoAplicar"]) * cargo.TasaCambio.FACTOR_CONV,2, MidpointRounding.ToEven);
                }
                else if(cargo.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                {
                    oRow["MontoLocal"] = Math.Round(Convert.ToDecimal(oRow["Monto"]) * cargo.TasaCambio.FACTOR_CONV,2, MidpointRounding.ToEven);
                    oRow["MontoAplicar"] = oRow["Monto"];
                }
                oUnidades.Rows.Add(oRow);
            }
        }

        decimal BuscarMontoAplicar(int piCargoId, decimal Monto, ref decimal ValPorcentaje)
        {
            decimal dRetorno = 1;
            var Clientes = unitOfWork.ClientesRepository.GetByID(iCteId);
            var cargosProd = from p in unitOfWork.CargosValoresRepository.Get(filter: s => s.COD_TAR_ID ==
                Clientes.COD_TARIFA && s.SUC_ID == Clientes.CTE_SUC_ID && s.CARGO_PROD_ID == piCargoId)
                             orderby p.VAL_HASTA
                             select new { p.VAL_HASTA, p.VAL_PORCENTAJE, p.VAL_VALOR, p.VAL_ADICIONAL };
            foreach (var valor in cargosProd)
            {
                if (Monto <= valor.VAL_HASTA)
                {
                     dRetorno = valor.VAL_VALOR;
                     ValPorcentaje = valor.VAL_PORCENTAJE;
                    break;
                }
            }
            return dRetorno;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
           {

           }
        }

        bool ValidarDatos()
        {

            if (iCteId == -1)
            {
                MessageBox.Show("Debe digitar un número válido de EPS", "Aviso",  MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtNombres.Text == "")
            {

            MessageBox.Show("Debe digitar un nombre válido", "Aviso",  MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (this.txtDireccion.Text == "")
            {

            MessageBox.Show("Debe digitar la dirección 1", "Aviso",  MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (this.txtDireccion2.Text == "")
            {

            MessageBox.Show("Debe digitar la dirección 2", "Aviso",  MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (this.txtCiudad.Text == "")
            {

            MessageBox.Show("Debe digitar la ciudad ", "Aviso",  MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
             if (this.txtDocumento.Text == "")
            {

            MessageBox.Show("Debe digitar el documento ", "Aviso",  MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

             if (this.cmbServicio.SelectedIndex == -1)
            {

            MessageBox.Show("Debe digitar el servicio ", "Aviso",  MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (this.txtSuplidor.Text =="")
            {

                MessageBox.Show("Debe digitar el Suplidor ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

      


            return true;

        }


    }
}
