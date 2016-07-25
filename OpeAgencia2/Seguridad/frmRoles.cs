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

namespace OpeAgencia2.Seguridad
{
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
        }

        int _Id;
        int _iModuloId;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmRoles_Load(object sender, EventArgs e)
        {
            this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
            this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
            this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
            this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
            this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
            this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);

            _iModuloId = -1;

            CargarCombos();

            CargarDatosIniciales(_iModuloId);

            ManejarEstado(false);

        }


        protected void CargarCombos()
        {

            var Grupo = from p in unitOfWork.ModulosRepository.Get()
                        select new { Id = p.MOD_ID, Nombre = p.MOD_NOMBRE + "(" + p.Tipos.TIPO_DESCR +")"  };


            //
            cmbModulo.ValueMember = "Id";
            cmbModulo.DisplayMember = "Nombre";
            //
            cmbModulo.DataSource = Grupo.ToList();

            cmbModulo.SelectedValue = -1;
        }
        //
        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {

            _iModuloId = Convert.ToInt32(cmbModulo.SelectedValue);
            CargarDatosIniciales(_iModuloId);
            lblGrupo.Text = cmbModulo.Text.ToString();
        }
        //
        protected void CargarDatosIniciales(int piGrupoId)
        {
            try
            {

                var grupos = from p in unitOfWork.RolesRepository.Get(filter: s => s.MOD_ID == piGrupoId)
                             select new { Id = p.ROL_ID, Nombre = p.NOMBRE, Estado = p.ACTIVO };



                dg.DataSource = grupos.ToList();
                tabMant.SelectedIndex = 0;
            }
            catch(Exception ex )
            {
                MessageBox.Show("Error:" + ex.Message.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region "botones"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabMant.SelectedIndex = 1;
            textGRUPO_TIPO_ID.Text = "";
            LimpiarCampos();
            ManejarEstado(true);

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteData();
            CargarDatosIniciales(_iModuloId);
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
                CargarDatosIniciales(_iModuloId);
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


            int iId = Convert.ToInt32(this.textGRUPO_TIPO_ID.Text);

            var codigo = unitOfWork.RolesRepository.GetByID(iId);

            try
            {
                unitOfWork.RolesRepository.Delete(codigo);
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


            BO.Models.Roles oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textGRUPO_TIPO_ID.Text);
                oCom = unitOfWork.RolesRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.Roles();
            }


            oCom.NOMBRE = this.txtNombre.Text.ToString();
            oCom.MOD_ID =_iModuloId;
            oCom.ACTIVO = chkActivo.Checked;
            oCom.DESCRIPCION = txtDESCR.Text;

          
            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.RolesRepository.Update(oCom);
                else
                    unitOfWork.RolesRepository.Insert(oCom);

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
            var codigos = unitOfWork.RolesRepository.GetByID(Id);

            MoverDatos(codigos);

        }

        void MoverDatos(BO.Models.Roles MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "ROLE_ID":
                        ctr.Text = MyComp.ROL_ID.ToString();
                        break;
                    case "NOMBRE":
                        ctr.Text = MyComp.NOMBRE.ToString();
                        break;
                    case "DESCRIPCION":
                        ctr.Text = MyComp.DESCRIPCION.ToString();
                        break;
                    case "ACTIVO":
                        ((CheckBox)ctr).Checked = MyComp.ACTIVO;
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

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            frmAccesoRoles oFrm = new frmAccesoRoles(_Id, _iModuloId);
            oFrm.ShowDialog();
        }

       

       
    }
}
