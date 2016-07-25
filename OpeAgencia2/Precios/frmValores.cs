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

namespace OpeAgencia2.Precios
{
    public partial class frmValores : Form
    {
        public frmValores()
        {
            InitializeComponent();
        }

        int _Id = -1;
        int iEmpresaId = -1;
        int iSucId = -1;
        int iProductoId = -1;
        int iCargoProdId = -1;
        int iTarifaId = -1;

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmValores_Load(object sender, EventArgs e)
        {
            this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
            this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
            this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
            this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
            this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
            this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);
            CargarCombos();
            ManejarEstado(false);
        }

        #region "Combos"

        void CargarCombos()
        {
            CombosEmpresas();
            CombosProductos();
            ComboTarifa();
        }

        void CombosEmpresas()
        {
            var codigoCompania = unitOfWork.SucursalesRepository.GetByID(Parametros.ParametrosSucursal.IdSucursal).COM_CODIGO;
            var Empresas = from p in unitOfWork.EmpresasRepository.Get(filter: xy => xy.COM_CODIGO == codigoCompania)
                           select new { Id = p.COM_CODIGO, Nombre = p.COM_DESCORTA };
            cmbEmpresa.DisplayMember = "Nombre";
            cmbEmpresa.ValueMember ="Id";
            cmbEmpresa.DataSource = Empresas.ToList();
            cmbEmpresa.SelectedIndex = 0;
        }

        void CombosSucursal(int piSucursalId)
        {
            var Sucursal = from p in unitOfWork.SucursalesRepository.Get(filter: s => s.COM_CODIGO == piSucursalId)
                           select new { Id = p.SUC_ID, Nombre = p.SUC_CODIGO +"-->"+p.SUC_DESCRIPCION };
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id";
            cmbSucursal.DataSource = Sucursal.ToList();
            cmbSucursal.SelectedIndex = 0;
            iSucId = Convert.ToInt32(cmbSucursal.SelectedValue);
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            iSucId = Convert.ToInt32(cmbSucursal.SelectedValue);
        }

        void CombosProductos()
        {
            var Productos = from p in unitOfWork.ProductosRepository.Get()
                           select new { Id = p.PROD_ID, Nombre = p.PRO_CODIGO + "-->" + p.PRO_DESCRIPCION };
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";
            this.cmbProducto.DataSource = Productos.ToList();
        }

        void CombosCargos(int iProductoId)
        {   
            var Cargos = from p in unitOfWork.CargosProductoRepository.Get(filter: s => (s.PROD_ID == iProductoId && s.Cargos.CAR_DIRECTO_TABLA == "T"))
                         select new { Id = p.CARGO_PROD_ID, Nombre = p.Cargos.CAR_CODIGO + "-->" + p.Cargos.CAR_DESCRIPCION + "(" + p.TasaCambio.TASA_CODIGO + ")" };
            cmbCargo.DisplayMember = "Nombre";
            cmbCargo.ValueMember = "Id";
            this.cmbCargo.DataSource = Cargos.ToList();
            this.cmbCargo.SelectedIndex = -1;
        }

        void ComboTarifa()
        {
            var Tarifa = from p in unitOfWork.CodigosRepository.GetByGroupCode("CTAR")
                         select new { Id = p.CODIGO_ID, Nombre = p.CODIGO_COD + "-->" + p.CODIGO_NOMBRE };
            cmbTarifa.DisplayMember = "Nombre";
            cmbTarifa.ValueMember = "Id";
            this.cmbTarifa.DataSource = Tarifa.ToList();
            cmbTarifa.SelectedIndex = 0;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbProducto.SelectedValue != null)
                CombosCargos(Convert.ToInt32(this.cmbProducto.SelectedValue));
        }

        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpresa.SelectedValue != null)
                CombosSucursal(Convert.ToInt32(cmbEmpresa.SelectedValue));
        }

        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            iCargoProdId = Convert.ToInt32(cmbCargo.SelectedValue);
            CargarDatosIniciales();
        }

        private void cmbTarifa_SelectedIndexChanged(object sender, EventArgs e)
        {
            iTarifaId = Convert.ToInt32(cmbTarifa.SelectedValue);
            CargarDatosIniciales();
        }

        #endregion

        void CargarDatosIniciales()
        {
            if (iCargoProdId > 0 && iTarifaId > 0) {
                try
                {
                    var Valores = from p in unitOfWork.CargosValoresRepository.Get(filter: s => (s.CARGO_PROD_ID 
                        == iCargoProdId && s.SUC_ID == iSucId && s.COD_TAR_ID== iTarifaId))
                    select new { Id = p.TABLA_VAL_ID,Hasta=p.VAL_HASTA, Valor=p.VAL_VALOR, Porcentaje = 
                        p.VAL_PORCENTAJE, Adicional=p.VAL_ADICIONAL};
                    dg.DataSource = Valores.ToList();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        #region "botones"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabMant.SelectedIndex = 1;
            this.TextId.Text = "";
            LimpiarCampos();
            ManejarEstado(true);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteData();
            //CargarDatosIniciales();
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Modificar");
            Modificar();
            ManejarEstado(true);
        }

        private void btnSal_Click(object sender, EventArgs e)
        {
            this.Close();
            /// MessageBox.Show("Salir");
        }

        private void btnSav_Click(object sender, EventArgs e)
        {
            usrbntMant1.bExito = false;
            if (SalvarDatos())
            {
                usrbntMant1.bExito = true;
                ManejarEstado(false);
            }
        }

        private void btnUn_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Deshacer");
            ManejarEstado(false);
            tabMant.SelectedIndex = 0;
        }

        #endregion

        void DeleteData()
        {
            int iId = Convert.ToInt32(this.TextId.Text);
            //var opciones = unitOfWork.SucursalesRepository.GetByID(iId);
            try
            {
                unitOfWork.CargosValoresRepository.Delete(iId);
                unitOfWork.Save();
                MessageBox.Show("Datos Actualizados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                usrbntMant1.bExito = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        bool SalvarDatos()
        {
            int iId = -1;
            bool bRetorno = false;
            //CompaniasRecord oCom = new CompaniasRecord();
            BO.Models.CargosValores oCom;
            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.TextId.Text);
                oCom = unitOfWork.CargosValoresRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.CargosValores();
            }
            oCom.CARGO_PROD_ID = Convert.ToInt32(this.cmbCargo.SelectedValue);
            oCom.SUC_ID = Convert.ToInt32(this.cmbSucursal.SelectedValue.ToString());
            oCom.VAL_ADICIONAL = Convert.ToDecimal(txtAdicional.Text.ToString());
            oCom.VAL_HASTA = Convert.ToDecimal(txtHasta.Text);
            oCom.VAL_PORCENTAJE = Convert.ToDecimal(txtPorcentaje.Text);
            oCom.VAL_VALOR = Convert.ToDecimal(txtValor.Text);
            oCom.COD_TAR_ID = Convert.ToInt32(cmbTarifa.SelectedValue);
            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.CargosValoresRepository.Update(oCom);
                else
                    unitOfWork.CargosValoresRepository.Insert(oCom);
                unitOfWork.Save();
                bRetorno = true;
                usrbntMant1.bExito = true;
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
                    MessageBox.Show("Existen los siguientes errores:" + s, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (DataException ex)
            {
                throw ex;
            }
            return bRetorno;
        }

        public void Modificar()
        {
            try
            {
                _Id = Convert.ToInt32(dg.CurrentRow.Cells[0].Value);
            }
            catch
            {
                _Id = -1;
            }
            if (_Id != -1)
            {
                tabMant.SelectedTab = tabPage2;
            }
            ConsultarDatos(_Id);
        }

        void ConsultarDatos(int Id)
        {
            var Prod = unitOfWork.CargosValoresRepository.GetByID(Id);
            MoverDatos(Prod);
        }
        
        void MoverDatos(BO.Models.CargosValores MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;
                switch (ctr.Tag.ToString())
                {
                    case "TABLA_VAL_ID":
                        ((TextBox)ctr).Text = MyComp.TABLA_VAL_ID.ToString();
                        break;
                    case "VAL_HASTA":
                        ((TextBox)ctr).Text = MyComp.VAL_HASTA.ToString();
                        break;
                    case "VAL_VALOR":
                        ((TextBox)ctr).Text = MyComp.VAL_VALOR.ToString();
                        break;
                    case "VAL_PORCENTAJE":
                        ((TextBox)ctr).Text = MyComp.VAL_PORCENTAJE.ToString();
                        break;
                    case "VAL_ADICIONAL":
                        ((TextBox)ctr).Text = MyComp.VAL_ADICIONAL.ToString();
                        break;
                }
            }
        }

        void ManejarEstado(bool bEstado)
        {
            foreach (Control ctr in tabPage2.Controls)
            {
                if ((ctr.GetType().Name == "TextBox") || (ctr.GetType().Name == "ComboBox")
                    || (ctr.GetType().Name == "NumericUpDown") || (ctr.GetType().Name == "CheckBox"))
                {
                    if (ctr.Name.Substring(0, 4) == "text")
                        ctr.Enabled = false;
                    else
                        ctr.Enabled = bEstado;
                }
            }
        }

        void LimpiarCampos()
        {
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.GetType().Name == "TextBox")
                {
                    if (ctr.Name.Substring(0, 3) == "txt")
                        ctr.Text = "";
                }
                else if (ctr.GetType().Name == "ComboBox")
                    ((ComboBox)ctr).SelectedValue = -1;
                else if (ctr.GetType().Name == "CheckBox")
                    ((CheckBox)ctr).Checked = false;
                else if (ctr.GetType().Name == "NumericUpDown")
                    ((NumericUpDown)ctr).Value = 0;
            }
        }

        private void tabMant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabMant.SelectedIndex == 1) || (tabMant.SelectedIndex == 2))
            {
                try
                {
                    _Id = Convert.ToInt32(dg.CurrentRow.Cells[0].Value);
                    if (!usrbntMant1.bAdiciona)
                        ConsultarDatos(_Id);
                  }
                catch (Exception ex)
                {
                    //throw ex;
                    _Id = -1;
                }
                if ((_Id != -1) && (tabMant.SelectedIndex == 1))
                {
                    tabMant.SelectedTab = tabPage2;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }
    }
}
