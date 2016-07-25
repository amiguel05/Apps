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
    public partial class frmTipos : Form
    {
        public frmTipos()
        {
            InitializeComponent();
        }



        int _Id;
        int _iGrupoId;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmCodigos_Load(object sender, EventArgs e)
        {
            this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
            this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
            this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
            this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
            this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
            this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);

            _iGrupoId = -1;

            CargarCombos();

            CargarDatosIniciales(_iGrupoId);

            ManejarEstado(false);
        }

        protected void CargarCombos()
        {
            var Grupo = from p in unitOfWork.GruposTiposRepository.Get()
                        select new { Id = p.GRUPO_TIPO_ID, Nombre = p.DESCR };


            //
            cmbGrupo.ValueMember = "Id";
            cmbGrupo.DisplayMember = "Nombre";
            //
            cmbGrupo.DataSource = Grupo.ToList();

            cmbGrupo.SelectedValue = -1;
        }
        //
        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _iGrupoId = Convert.ToInt32(cmbGrupo.SelectedValue);
            CargarDatosIniciales(_iGrupoId);
            lblGrupo.Text = cmbGrupo.Text.ToString();

        }
        //
        protected void CargarDatosIniciales(int piGrupoId)
        {

            var grupos = from p in unitOfWork.TiposRepository.Get(filter: s => s.GRUPO_TIPO_ID == piGrupoId)
                         select new { Id = p.TIPO_ID, Nombre = p.TIPO_NOMBRE, Código = p.TIPO_CODIGO, Descripción = p.TIPO_DESCR  };



            dg.DataSource = grupos.ToList();
            tabMant.SelectedIndex = 0;
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
            CargarDatosIniciales(_iGrupoId);
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
                CargarDatosIniciales(_iGrupoId);
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

            var codigo = unitOfWork.TiposRepository.GetByID(iId);

            try
            {
                unitOfWork.TiposRepository.Delete(codigo);
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


            BO.Models.Tipos oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textGRUPO_TIPO_ID.Text);
                oCom = unitOfWork.TiposRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.Tipos();
            }
            
            oCom.TIPO_CODIGO = this.txtCodigo.Text.ToString();
            oCom.TIPO_NOMBRE = this.txtNombre.Text.ToString();
            oCom.TIPO_DESCR = this.txtDESCR.Text.ToString().TrimEnd();
            oCom.GRUPO_TIPO_ID = _iGrupoId;


            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.TiposRepository.Update(oCom);
                else
                    unitOfWork.TiposRepository.Insert(oCom);

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
            var codigos = unitOfWork.TiposRepository.GetByID(Id);

            MoverDatos(codigos);

        }

        void MoverDatos(BO.Models.Tipos MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "TIPO_ID":
                        ctr.Text = MyComp.TIPO_ID.ToString();
                        break;
                    case "TIPO_CODIGO":
                        ctr.Text = MyComp.TIPO_CODIGO.ToString();
                        break;
                    case "TIPO_DESCR":
                        ctr.Text = MyComp.TIPO_DESCR.ToString();
                        break;
                    case "TIPO_NOMBRE":
                        ctr.Text = MyComp.TIPO_NOMBRE.ToString();
                        break;
                    case "GRUPO_TIPO_ID":
                        ctr.Text = MyComp.GRUPO_TIPO_ID.ToString();
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
    }
}
