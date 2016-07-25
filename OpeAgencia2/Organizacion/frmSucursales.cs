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

namespace OpeAgencia2.Organizacion
{
    public partial class frmSucursales : Form
    {
        public frmSucursales()
        {
            InitializeComponent();
        }

        int _Id;
        int _iCodigoEmpresa;
        //
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        //

        private void frmSucursales_Load(object sender, EventArgs e)
        {
            this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
            this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
            this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
            this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
            this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
            this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);

            _iCodigoEmpresa = -1;

            CargarCombos();

            CargarDatosIniciales(_iCodigoEmpresa);

            ManejarEstado(false);
        }

        protected void CargarCombos()
        {
         
            var empresas = from  p in unitOfWork.EmpresasRepository.Get()
                           select new { Id = p.COM_CODIGO, Nombre = p.COM_DESCRIPCION } ;

           
            //
            cmbGrupo.ValueMember = "Id";
            cmbGrupo.DisplayMember = "Nombre";
            //
            cmbGrupo.DataSource = empresas.ToList();

            cmbGrupo.SelectedValue = -1;
        }
        //

        //
        protected void CargarDatosIniciales(int piEmpresa)
        {

            var sucursales = from p in unitOfWork.SucursalesRepository.Get(filter: s => s.COM_CODIGO == piEmpresa)
                             select new { Id = p.SUC_ID, Nombre = p.SUC_CODIGO, Descripción = p.SUC_DESCRIPCION };

          

            dg.DataSource = sucursales.ToList();
            tabMant.SelectedIndex = 0;
        }


        #region "botones"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabMant.SelectedIndex = 1;
            textID.Text = "";
            LimpiarCampos();
            ManejarEstado(true);

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteData();
            CargarDatosIniciales(_iCodigoEmpresa); ;
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
                CargarDatosIniciales(_iCodigoEmpresa);
            }
        }
        private void btnUn_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Deshacer");
            ManejarEstado(false);
            tabMant.SelectedIndex = 0;
        }

        #endregion


        void ManejarEstado(bool bEstado)
        {
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.GetType().Name == "TextBox")
                {
                    if (ctr.Name.Substring(0, 3) == "txt")
                        ctr.Enabled = bEstado;

                }
                else if (ctr.GetType().Name == "ComboBox")
                {
                    if (ctr.Name.Substring(0, 3) == "cmb")
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


            int iId = Convert.ToInt32(this.textID.Text);

            var sucursal = unitOfWork.SucursalesRepository.GetByID(iId);

            try
            {
                unitOfWork.SucursalesRepository.Delete(sucursal);
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


            BO.Models.Sucursales oCom;

            
            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(textID.Text);
                oCom = unitOfWork.SucursalesRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.Sucursales();
            }
            

            oCom.SUC_CODIGO = this.txtCodigo.Text.ToString();
            oCom.SUC_DESCRIPCION = this.txtDESCR.Text.ToString().TrimEnd();
            oCom.SUC_ESTADO = cmbEstado.Text;
            oCom.ALM_CODIGO = Convert.ToInt32(txtAlmacen.Text);
            oCom.BLT_UBICACION = txtUbicacion.Text;
            oCom.COM_CODIGO = _iCodigoEmpresa;

            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.SucursalesRepository.Update(oCom);
                else
                    unitOfWork.SucursalesRepository.Insert(oCom);

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

            var empresas = unitOfWork.SucursalesRepository.GetByID(Id);

            MoverDatos(empresas);

        }

        void MoverDatos(BO.Models.Sucursales MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "SUC_ID":
                        ctr.Text = MyComp.SUC_ID.ToString();
                        break;
                    case "SUC_CODIGO":
                        ctr.Text = MyComp.SUC_CODIGO.ToString();
                        break;
                    case "SUC_DESCRIPCION":
                        ctr.Text = MyComp.SUC_DESCRIPCION.ToString();
                        break;

                    case "SUC_ESTADO":
                        ctr.Text = MyComp.SUC_ESTADO.ToString();
                        break;
                    case "ALM_CODIGO":
                        ctr.Text = MyComp.ALM_CODIGO.ToString();
                        break;
                    case "BLT_UBICACION":
                        ctr.Text = MyComp.BLT_UBICACION.ToString();
                        break;


                }


            }
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

        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            _iCodigoEmpresa = Convert.ToInt32(cmbGrupo.SelectedValue);
            CargarDatosIniciales(_iCodigoEmpresa);
            lblGrupo.Text = cmbGrupo.Text.ToString();
        }
    }
}
