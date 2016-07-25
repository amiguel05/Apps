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
    public partial class frmParametrosSucursal : Form
    {
        public frmParametrosSucursal()
        {
            InitializeComponent();
        }

        int _Id;
        int iSucId;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmParametrosSucursal_Load(object sender, EventArgs e)
        {

            this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
            this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
            this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
            this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
            this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
            this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);

            iSucId = -1;

            CargarCombos();

            CargarDatosIniciales(iSucId);

            ManejarEstado(false);

        }


        protected void CargarCombos()
        {
            var Sucursal = from p in unitOfWork.SucursalesRepository.Get()
                           select new { Id = p.SUC_ID, Nombre = p.SUC_CODIGO + "-->" + p.SUC_DESCRIPCION };


            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id";

            cmbSucursal.DataSource = Sucursal.ToList();

            cmbSucursal.SelectedIndex = 0;

            iSucId = Convert.ToInt32(cmbSucursal.SelectedValue);
        }


        protected void CargarDatosIniciales(int piGrupoId)
        {

            var grupos = from p in unitOfWork.ParametrosSucursalRepository.Get(filter: s => s.SUC_ID == piGrupoId)
                         select new { Id = p.ID, Nombre = p.PARAMETRO, p.VALOR1, p.VALOR2, p.VALOR3};



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

            int iId = Convert.ToInt32(this.TextParametroId.Text);

            var codigo = unitOfWork.ParametrosSucursalRepository.GetByID(iId);

            try
            {
                unitOfWork.ParametrosSucursalRepository.Delete(codigo);
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


            BO.Models.ParametrosSucursal oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.TextParametroId.Text);
                oCom = unitOfWork.ParametrosSucursalRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.ParametrosSucursal();
            }

            oCom.PARAMETRO = this.txtCodigo.Text.ToString();
            oCom.VALOR1 = this.txtValor1.Text.ToString();
            oCom.VALOR2 = this.txtValor2.Text.ToString();
            oCom.VALOR3 = this.txtValor3.Text.ToString();

            oCom.SUC_ID = Convert.ToInt32(cmbSucursal.SelectedValue) ;


            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.ParametrosSucursalRepository.Update(oCom);
                else
                    unitOfWork.ParametrosSucursalRepository.Insert(oCom);

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
            var codigos = unitOfWork.ParametrosSucursalRepository.GetByID(Id);

            MoverDatos(codigos);

        }

        void MoverDatos(BO.Models.ParametrosSucursal MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "ID":
                        ctr.Text = MyComp.ID.ToString();
                        break;
                    case "PARAMETRO":
                        ctr.Text = MyComp.PARAMETRO.ToString();
                        break;
                    case "VALOR1":
                        ctr.Text = MyComp.VALOR1.ToString();
                        break;
                    case "VALOR2":
                        ctr.Text = MyComp.VALOR2.ToString();
                        break;
                    case "VALOR3":
                        ctr.Text = MyComp.VALOR3.ToString();
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
            this.TextParametroId.Text = "";
            LimpiarCampos();
            ManejarEstado(true);

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteData();
            CargarDatosIniciales(iSucId);
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
                CargarDatosIniciales(iSucId);
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

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSucId = Convert.ToInt32(cmbSucursal.SelectedValue);
            CargarDatosIniciales(iSucId);
        }
    }
}
