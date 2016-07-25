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

namespace OpeAgencia2.Parametros
{
    public partial class frmNumeroFiscal : Form
    {
        public frmNumeroFiscal()
        {
            InitializeComponent();
        }

        int _Id;
        int _iSucId;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmNumeroFiscal_Load(object sender, EventArgs e)
        {
            this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
            this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
            this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
            this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
            this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
            this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);
            _iSucId = -1;
            CargarCombos();
            ComboTipoFiscalCliente();
        }

        protected void CargarCombos()
        {
            var Sucursal = from p in unitOfWork.SucursalesRepository.Get()
                           select new { Id = p.SUC_ID, Nombre = p.SUC_CODIGO + "-->" + p.SUC_DESCRIPCION };
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id";
            cmbSucursal.DataSource = Sucursal.ToList();
            cmbSucursal.SelectedIndex = 0;
            _iSucId = Convert.ToInt32(cmbSucursal.SelectedValue);
        }

        void ComboTipoFiscalCliente()
        {
            var sup = from p in unitOfWork.TiposRepository.GetByGroupCode("TFCLI")
                      select new { Id = p.TIPO_ID, Nombre = p.TIPO_CODIGO + "-->" + p.TIPO_NOMBRE };
            //
            this.cmbTipoId.ValueMember = "Id";
            cmbTipoId.DisplayMember = "Nombre";
            //
            cmbTipoId.DataSource = sup.ToList();
            cmbTipoId.SelectedValue = -1;
        }

        protected void CargarDatosIniciales(int piGrupoId)
        {
            var grupos = from p in unitOfWork.NumeroFicalRepository.Get(filter: s => s.SUC_ID == piGrupoId)
                select new { Id = p.NCF_ID, Nombre = p.tipos.TIPO_DESCR, p.PREFIJO, p.SECUENCIA, p.MAX_SECUENCIA };
            dg.DataSource = grupos.ToList();
            tabMant.SelectedIndex = 0;
        }

        void ManejarEstado(bool bEstado)
        {
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.GetType().Name == "TextBox")
                {
                    if (ctr.Name.Substring(0, 3) == "txt")
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
            }
        }

        #region "CRUD"

        void DeleteData()
        {
            int iId = Convert.ToInt32(this.text_Id.Text);
            var codigo = unitOfWork.NumeroFicalRepository.GetByID(iId);
            try
            {
                unitOfWork.NumeroFicalRepository.Delete(codigo);
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
            BO.Models.NumeroFiscal oCom;
            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.text_Id.Text);
                oCom = unitOfWork.NumeroFicalRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.NumeroFiscal();
            }
            oCom.TIPO_ID = Convert.ToInt32(this.cmbTipoId.SelectedValue);
            oCom.PREFIJO = txtPrefijo.Text;
            oCom.SECUENCIA = txtSecuencia.IntValue;
            oCom.MAX_SECUENCIA = txtMaximo.IntValue;
            oCom.SUC_ID = Convert.ToInt32(cmbSucursal.SelectedValue);
            oCom.TIPO_FISCAL = Convert.ToInt32(txtTIPO_FISCAL.Value);
            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.NumeroFicalRepository.Update(oCom);
                else
                    unitOfWork.NumeroFicalRepository.Insert(oCom);
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
                //throw;
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
            var codigos = unitOfWork.NumeroFicalRepository.GetByID(Id);
            MoverDatos(codigos);
        }

        void MoverDatos(BO.Models.NumeroFiscal MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;
                switch (ctr.Tag.ToString())
                {
                    case "NCF_ID":
                        ctr.Text = MyComp.NCF_ID.ToString();
                        break;
                    case "TIPO_ID":
                        ((ComboBox)ctr).SelectedValue = MyComp.TIPO_ID;
                        break;
                    case "PREFIJO":
                        ctr.Text = MyComp.PREFIJO.ToString();
                        break;
                    case "SECUENCIA":
                        ((clsUtils.NumericTextBox)ctr).IntValue = MyComp.SECUENCIA;
                        break;
                    case "MAX_SECUENCIA":
                        ((clsUtils.NumericTextBox)ctr).IntValue = MyComp.MAX_SECUENCIA;
                        break;
                    case "TIPO_FISCAL":
                          ((NumericUpDown)ctr).Value = MyComp.TIPO_FISCAL;
                        break;
                }
            }
        }

        #endregion

        #region "botones"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabMant.SelectedIndex = 1;
            this.text_Id.Text = "";
            LimpiarCampos();
            ManejarEstado(true);

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteData();
            CargarDatosIniciales(_iSucId);
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
                CargarDatosIniciales(_iSucId);
            }
        }
        private void btnUn_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Deshacer");
            ManejarEstado(false);
            tabMant.SelectedIndex = 0;
        }

        #endregion

        private void tabMant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMant.SelectedIndex == 1)
            {
                try
                {
                    _Id = Convert.ToInt32(dg.CurrentRow.Cells[0].Value);
                    ConsultarDatos(_Id);
                }
                catch
                {
                    _Id = -1;
                }
                if (_Id != -1)
                {
                    tabMant.SelectedTab = tabPage2;
                }
            }
        }

        private void cmbSucursal_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int iSucId = Convert.ToInt32(cmbSucursal.SelectedValue);
            CargarDatosIniciales(iSucId);
        }
    }
}
