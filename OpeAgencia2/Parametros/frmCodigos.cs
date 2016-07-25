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
    public partial class frmCodigos : Form
    {
        public frmCodigos()
        {
            InitializeComponent();
        }

        int _Id;
        int _iGrupoId;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmCodigos_Load(object sender, EventArgs e)
        {

            try
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarCombos()
        {
          
            var Grupo = from p in unitOfWork.GruposCodigosRepository.Get()
                           select new { Id = p.GRUPO_COD_ID, Nombre = p.DESCR };


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
            lblGrupo.Text = cmbGrupo.Text.ToString() ;
         
        }
        //
        protected void CargarDatosIniciales(int piGrupoId)
        {

            var grupos = from p in unitOfWork.CodigosRepository.Get(filter: s => s.GRUPO_COD_ID == piGrupoId)
                             select new { Id = p.CODIGO_ID, Nombre = p.CODIGO_NOMBRE, Descripción = p.CODIGO_DESCR };



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

            var codigo = unitOfWork.CodigosRepository.GetByID(iId);

            try
            {
                unitOfWork.CodigosRepository.Delete(codigo);
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


            BO.Models.Codigos oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textGRUPO_TIPO_ID.Text);
                oCom = unitOfWork.CodigosRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.Codigos();
            }
            

            oCom.CODIGO_COD = this.txtCodigo.Text.ToString();
            oCom.CODIGO_NOMBRE = this.txtNombre.Text.ToString();
            oCom.CODIGO_DESCR = this.txtDESCR.Text.ToString().TrimEnd();
            oCom.GRUPO_COD_ID = _iGrupoId;


            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.CodigosRepository.Update(oCom);
                else
                    unitOfWork.CodigosRepository.Insert(oCom);

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
            var codigos = unitOfWork.CodigosRepository.GetByID(Id);

            MoverDatos(codigos);

        }

        void MoverDatos(BO.Models.Codigos MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "CODIGO_ID":
                        ctr.Text = MyComp.CODIGO_ID.ToString();
                        break;
                    case "CODIGO_COD":
                        ctr.Text = MyComp.CODIGO_COD.ToString();
                        break;
                    case "CODIGO_DESCR":
                        ctr.Text = MyComp.CODIGO_DESCR.ToString();
                        break;
                    case "CODIGO_NOMBRE":
                        ctr.Text = MyComp.CODIGO_NOMBRE.ToString();
                        break;
                    case "GRUPO_COD_ID":
                        ctr.Text = MyComp.GRUPO_COD_ID.ToString();
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
