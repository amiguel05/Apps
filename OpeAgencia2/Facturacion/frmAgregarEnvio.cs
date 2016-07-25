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

namespace OpeAgencia2.Facturacion
{
    public partial class frmAgregarEnvio : Form
    {
        public frmAgregarEnvio()
        {
            InitializeComponent();
        }

        int liCteid = -1;
        int iProductoId = -1;
        BO.DAL.dsDatos.BultosValoresCargosDataTable oCargos = new BO.DAL.dsDatos.BultosValoresCargosDataTable();
        BO.DAL.dsDatos.BultosValoresCargosDataTable oUnidades = new BO.DAL.dsDatos.BultosValoresCargosDataTable();
        BO.DAL.dsDatos.BultosValoresCargosSelectDataTable oCargosSelect = new BO.DAL.dsDatos.BultosValoresCargosSelectDataTable();
        private BO.DAL.dsDatos.EnviosDataTable oEnvio = new BO.DAL.dsDatos.EnviosDataTable();
        BO.DAL.dsDatos.BultosValoresCargosDataTable oUnidadesReturn = new BO.DAL.dsDatos.BultosValoresCargosDataTable();
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();

        public  BO.DAL.dsDatos.EnviosDataTable DatosEnvio
        {
            get { return oEnvio; }
        }

        public    BO.DAL.dsDatos.BultosValoresCargosDataTable UnidadesRetorno
        {
            get { return oUnidadesReturn; }
        }

        public BO.DAL.dsDatos.BultosValoresCargosDataTable CargosRetorno
        {
            get { return oCargos; }
        }

        public frmAgregarEnvio(int piCteId)
        {
            InitializeComponent();
            liCteid = piCteId;
        }

        private void frmAgregarEnvio_Load(object sender, EventArgs e)
        {
            oCliente = unitOfWork.ClientesRepository.GetByID(liCteid);
            txtNumeroEPS.Text = oCliente.CTE_NUMERO_EPS;
            lblEps.Text = oCliente.CTE_NOMBRE + " " + oCliente.CTE_APELLIDO;
            CargarCombos();
            BuscarDatosIniciales();
            iProductoId = Convert.ToInt32(cmbProducto.SelectedValue);
            dgCargos.DataSource = oCargos;
            dgCargos.Columns[0].Visible = false;
            dgCargos.Columns[1].Visible = false;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            iProductoId = Convert.ToInt32(cmbProducto.SelectedValue);
            var oProducto = unitOfWork.EnviosRepository.Get(filter: s => s.PROD_ID == iProductoId).FirstOrDefault();
            txtPeso.Maximum = oProducto.PESO_MAX;
            txtPeso.Minimum = oProducto.PESO_MIN;
            ComboCargos();
            CargarOrigen();
            CargarCargosSelect();
        }

        void BuscarDatosIniciales()
        {
            txtRemitente.Text = oCliente.CTE_NOMBRE + " " + oCliente.CTE_APELLIDO;
            txtRemitenteDir1.Text = oCliente.CTE_DIRECCION_CASA;
            txtRemitenteTel.Text = oCliente.CTE_TELEFONO_CASA;
        }

        void CargarCombos()
        {
            CargarProductos();
            CargarPaises();
            CargarCargosSelect();
            CargarOrigen();
        }

        void CargarProductos()
        {
            var Productos = from p in unitOfWork.ProductosRepository.Get(filter: s => s.PRO_TIPO_ID == 32)
                            select new { Id = p.PROD_ID, Nombre = p.PRO_CODIGO + " " + p.PRO_DESCRIPCION };
            cmbProducto.ValueMember = "Id";
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.DataSource = Productos.ToList();
            cmbProducto.SelectedIndex = 0;
        }

        void CargarOrigen()
        {
            var oOrigen = from p in unitOfWork.TarifaEnvioZonaRepository.Get(xy => xy.Envios.Productos.PROD_ID == 
                iProductoId) select new { Id = p.Origen.ORI_ID, Nombre = p.Origen.ORI_CODIGO + "-" + 
                    p.Origen.ORI_DESCRIPCION };
             /*
            var grupos = from p in unitOfWork.OrigenRepository.Get()
                         select new { Id = p.ORI_ID, Nombre = p.ORI_CODIGO + "-" + p.ORI_DESCRIPCION };
            */
            cmbDestino.DataSource = oOrigen.ToList();
            cmbDestino.ValueMember = "Id";
            cmbDestino.DisplayMember = "Nombre";
        }

        void CargarPaises()
        {
            var paises = from p in unitOfWork.CodigosRepository.GetByGroupCode("CP")
                         select new { Id = p.CODIGO_ID, Nombre = p.CODIGO_NOMBRE };
            cmbPaisOrigen.DataSource = paises.ToList();
            cmbPaisOrigen.ValueMember = "Id";
            cmbPaisOrigen.DisplayMember = "Nombre";
            cmbPaisDestino.DataSource = paises.ToList();
            cmbPaisDestino.ValueMember = "Id";
            cmbPaisDestino.DisplayMember = "Nombre";
            cmbPaisOrigen.Enabled = false;
            cmbPaisOrigen.SelectedValue = 5;
        }

        void ComboCargos()
        {
            var cargosExits = from p in unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == 
                iProductoId && s.Cargos.CAR_BASE_ID == 29 && s.Cargos.CAR_ESTADO == true) /*tipo cargos*/
                select new { Id = p.CARGO_PROD_ID, Nombre = p.Cargos.CAR_CODIGO + "-->" + p.Cargos.CAR_DESCRIPCION + 
                    "(" + p.TasaCambio.TASA_CODIGO + ")" };
            //
            this.cmbCargos.ValueMember = "Id";
            cmbCargos.DisplayMember = "Nombre";
            //
            cmbCargos.DataSource = cargosExits.ToList();
            cmbCargos.SelectedValue = -1;
        }

        void CargarCargosSelect()
        {
            oCargosSelect.Rows.Clear();
            var cargosExits = from p in unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProductoId 
                && s.Cargos.CAR_BASE_ID != 29 && s.Cargos.CAR_TIPO=="C" && s.Cargos.CAR_ESTADO == true) /*tipo cargos*/
                select new { Id = p.CARGO_PROD_ID, Nombre = p.Cargos.CAR_CODIGO + "-->" + p.Cargos.CAR_DESCRIPCION + 
                "(" + p.TasaCambio.TASA_CODIGO + ")" };
            int i = 0;
            foreach(var oVar in cargosExits)
            {
                DataRow dr = oCargosSelect.NewRow();
                dr["ID"] = i;
                dr["Selected"] = false;
                dr["CARGO_PROD_ID"] = oVar.Id;
                dr["Desc"] = oVar.Nombre;
                dr["Tasa"] = 0;
                dr["Monto"] = 0;
                dr["MontoLocal"] = 0;
                dr["MontoAplicar"] = 0;
                oCargosSelect.Rows.Add(dr);
                i++;
            }
            dgCargosCalculados.DataSource = oCargosSelect;
            dgCargosCalculados.Columns[0].Visible = false;
            dgCargosCalculados.Columns[2].Visible = false;
            dgCargosCalculados.Columns[3].Visible = true;
            dgCargosCalculados.Columns[3].ReadOnly = true;
            dgCargosCalculados.Columns[4].Visible = false;
            dgCargosCalculados.Columns[5].Visible = false;
            dgCargosCalculados.Columns[6].Visible = false;
            dgCargosCalculados.Columns[7].Visible = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                if (txtPeso.Value > 0)
                     BuscarUnidades();
            }
        }

        void BuscarUnidades()
        {
            int iDestinoId = Convert.ToInt32(cmbDestino.SelectedValue);
            BO.BO.Facturar x = new BO.BO.Facturar();
            decimal dSellos = 0; 
            oUnidades.Rows.Clear();
            x.CalcUnidadesEnvios(iProductoId, txtPeso.Value, txtValorFOB.DecimalValue, ref oUnidades, iDestinoId, oCliente.CTE_ID, ref dSellos);
            //Aqui calculo las unidaes fijas
            foreach(DataRow dr in oCargosSelect)
            {
                if (Convert.ToBoolean(dr["Selected"]) == true)
                {
                    x.CalcCagosEnvios(iProductoId, txtPeso.Value, dSellos, txtValorFOB.DecimalValue, ref oUnidades, oCliente.CTE_ID, Convert.ToInt32(dr["CARGO_PROD_ID"]));
                }
            }
            txtSellos.DecimalValue = dSellos;
            dgUnidades.DataSource = oUnidades;
            dgUnidades.Columns[0].Visible = false;
            dgUnidades.Columns[1].Visible = false;
            dgUnidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            decimal  dMontoItebis = 0;
            if (Validaciones())
            {
                decimal dMonto = 0;
                BO.DAL.dsDatos.EnviosRow dr = oEnvio.NewEnviosRow();
                dr.Id = 1;
                dr.peso = txtPeso.Value;
                dr.remitente = txtRemitente.Text;
                dr.remitente_ciudad = txtRemitenteCiudad.Text;
                dr.remitente_dir1 = txtRemitenteDir1.Text;
                dr.remitente_dir2 = txtRemitenteDir2.Text;
                dr.remitente_paisId = Convert.ToInt32(cmbPaisOrigen.SelectedValue);
                dr.remitente_region = txtRemitenteRegion.Text;
                dr.remitente_tel = txtRemitenteTel.Text;
                dr.consignatario = txtConsignatario.Text;
                dr.consignatario_ciudad = txtConsignatarioCiudad.Text;
                dr.consignatario_dir1 = txtConsignatarioDir1.Text;
                dr.consignatario_dir2 = txtConsignatarioDir2.Text;
                dr.consignatario_paisId = Convert.ToInt32(cmbPaisDestino.SelectedValue);
                dr.consignatario_region = txtConsignatarioEstado.Text;
                dr.consignatario_tel = txtConsignatarioTel.Text;
                dr.destinoId = Convert.ToInt32(cmbDestino.SelectedValue);
                dr.ProductoId = Convert.ToInt32(cmbProducto.SelectedValue);
                dr.Piezas = Convert.ToInt32(txtPiezas.Value);
                dr.valor = txtValorFOB.DecimalValue;
                BuscarUnidades();
                dr.sellos = txtSellos.DecimalValue;
                foreach(BO.DAL.dsDatos.BultosValoresCargosRow drUnidades in oUnidades.Rows)
                {
                    BO.DAL.dsDatos.BultosValoresCargosRow drBV = oUnidadesReturn.NewBultosValoresCargosRow();
                    drBV.CARGO_PROD_ID = drUnidades.CARGO_PROD_ID;
                    drBV.Desc = drUnidades.Desc;
                    drBV.ID = drUnidades.ID;
                    drBV.Monto = drUnidades.Monto;
                    drBV.MontoAplicar = drUnidades.MontoAplicar;
                    drBV.MontoLocal = drUnidades.MontoLocal;
                    drBV.Tasa = drUnidades.Tasa;
                    dMonto += Math.Round(drBV.MontoLocal, 2);
                    oUnidadesReturn.Rows.Add(drBV);
                }
                foreach (BO.DAL.dsDatos.BultosValoresCargosRow drUnidades in oCargos.Rows)
                {
                    BO.DAL.dsDatos.BultosValoresCargosRow drBV = oUnidadesReturn.NewBultosValoresCargosRow();
                    drBV.CARGO_PROD_ID = drUnidades.CARGO_PROD_ID;
                    drBV.Desc = drUnidades.Desc;
                    drBV.ID = drUnidades.ID;
                    drBV.Monto = drUnidades.Monto;
                    drBV.MontoAplicar = drUnidades.MontoAplicar;
                    drBV.MontoLocal = drUnidades.MontoLocal;
                    drBV.Tasa = drUnidades.Tasa;
                    dMonto += Math.Round(drBV.MontoLocal, 2);
                    oUnidadesReturn.Rows.Add(drBV);
                    // oUnidades.Rows.Add(drBV);
                }
                BO.BO.Facturar oFact = new BO.BO.Facturar();
                dMontoItebis = oFact.ActualizarItbisEnvios(ref oUnidadesReturn);
                dr.Monto = dMonto + dMontoItebis;
                oEnvio.Rows.Add(dr);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        bool Validaciones()
        {
            bool bRetorno = true;
            if (cmbProducto.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el servicio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bRetorno = false;
            }
            else if (txtPeso.Value <= 0)
            {
                MessageBox.Show("El peso del envío debe ser mayor que 0", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bRetorno = false;
            }
            else if (txtRemitente.Text =="")
            {
                MessageBox.Show("Deber revisar el remitente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bRetorno = false;
            }
            else if (this.txtConsignatario.Text == "")
            {
                MessageBox.Show("Deber revisar el consignatario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bRetorno = false;
            }
            else if (this.txtConsignatarioDir1.Text == "" || this.txtConsignatarioDir2.Text == "")
            {
                MessageBox.Show("Deber revisar la dirección del consignatario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bRetorno = false;
            }
            else if (this.txtConsignatarioCiudad.Text == "" || this.txtConsignatarioEstado.Text == "")
            {
                MessageBox.Show("Deber revisar la ciudad/región del consignatario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bRetorno = false;
            }
            else if (cmbPaisDestino.SelectedIndex < 0)
            {
                MessageBox.Show("Deber revisar el país a que se envía", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bRetorno = false;
            }
            return bRetorno;
        }

        private void btnCargoAdd_Click(object sender, EventArgs e)
        {
            int iCargoProd = -1;
            /* select new { p.ID, p.CARGO_PROD_ID, Desc = p.CargosProducto.Cargos.CAR_CODIGO + "-->" + 
             * p.CargosProducto.Cargos.CAR_DESCRIPCION + "(" + p.CargosProducto.TasaCambio.TASA_CODIGO + 
             * ")", Monto = p.BVA_MONTO, Tasa= p.BVA_TASA, MontoLocal = p.BVA_MONTO_LOCAL };*/
            iCargoProd = Convert.ToInt32(cmbCargos.SelectedValue);
            var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);

            DataRow dr = oCargos.NewRow();
            dr["ID"] = -1;
            dr["CARGO_PROD_ID"] = iCargoProd;
            dr["Desc"] = cmbCargos.Text;
            dr["Tasa"] = cargosProd.TasaCambio.FACTOR_CONV;
            dr["Monto"] = Convert.ToDecimal(txtMonto.Text);
            if (cargosProd.Cargos.CAR_DIRECTO_TABLA == "D")
                dr["MontoAplicar"] = Convert.ToDecimal(txtMonto.Text);
            else
            {
                dr["MontoAplicar"] = BuscarMontoAplicar(iCargoProd, Convert.ToDecimal(txtMonto.Text));
            }
            if (Convert.ToDecimal(dr["MontoAplicar"]) < Convert.ToDecimal(cargosProd.Cargos.CAR_MINIMO_FACTURAR))
            {
                Convert.ToDecimal(dr["MontoAplicar"] = Convert.ToDecimal(cargosProd.Cargos.CAR_MINIMO_FACTURAR));
            }
            if (cargosProd.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                dr["MontoLocal"] = Convert.ToInt32(dr["MontoAplicar"]) * cargosProd.TasaCambio.FACTOR_CONV;
            else
                dr["MontoLocal"] = Convert.ToInt32(txtMonto.Text) * Convert.ToInt32(dr["MontoAplicar"]) * cargosProd.TasaCambio.FACTOR_CONV;
            oCargos.Rows.Add(dr);
            cmbCargos.SelectedValue = -1;
            txtMonto.Text = "";
            cmbCargos.Focus();
        }

        decimal BuscarMontoAplicar(int piCargoId, decimal Monto)
        {
            decimal dRetorno = 1;
            var Clientes = unitOfWork.ClientesRepository.GetByID(liCteid);
            var cargosProd = from p in unitOfWork.CargosValoresRepository.Get(filter: s => s.COD_TAR_ID == 
                Clientes.COD_TARIFA && s.SUC_ID == Clientes.CTE_SUC_ID && s.CARGO_PROD_ID == piCargoId)
                             orderby p.VAL_HASTA
                             select new { p.VAL_HASTA, p.VAL_PORCENTAJE, p.VAL_VALOR, p.VAL_ADICIONAL };
            foreach (var valor in cargosProd)
            {
                if (Monto <= valor.VAL_HASTA)
                {
                    dRetorno = valor.VAL_VALOR;
                    break;
                }
            }
            return dRetorno;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
