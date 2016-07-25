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

namespace OpeAgencia2.Organizacion
{
    public partial class frmSuplidores : Form
    {
        public frmSuplidores()
        {
            InitializeComponent();
        }

        int _Id;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        

        private void frmSuplidores_Load(object sender, EventArgs e)
        {
            this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
            this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
            this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
            this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
            this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
            this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);

            CargarCombos();

            CargarDatosIniciales();

            ManejarEstado(false);

        }

        protected void CargarCombos()
        {
            
            var origen = from p in unitOfWork.OrigenRepository.Get()
                           select new { Id = p.ORI_ID, Nombre = p.ORI_DESCRIPCION };

            //
            cmbOrigen.ValueMember = "Id";
            cmbOrigen.DisplayMember = "Nombre";
            //
            cmbOrigen.DataSource = origen.ToList();

            cmbOrigen.SelectedValue = -1;
        }

        protected void CargarDatosIniciales()
        {


            var suplidores = from p in unitOfWork.SuplidoresRepository.Get()
                             select new { Id = p.SUP_ID, Código = p.SUP_CODIGO, Nombre = p.SUP_NOMBRE }; ; ;



            dg.DataSource = suplidores.ToList();

            tabMant.SelectedIndex = 0;

          

        }

        #region "botones"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabMant.SelectedIndex = 1;
            textId.Text = "";
            LimpiarCampos();
            ManejarEstado(true);

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteData();
            CargarDatosIniciales();
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
                CargarDatosIniciales();
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

 
            int iId = -1;

            iId = Convert.ToInt32(this.textId.Text);
            var empresas = unitOfWork.SuplidoresRepository.GetByID(iId);

            try
            {
                unitOfWork.SuplidoresRepository.Delete(empresas);
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
            bool bRetorno = false;
            int iId = -1;

            //CompaniasRecord oCom = new CompaniasRecord();


            BO.Models.Suplidores oCom;




            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textId.Text);
                oCom = unitOfWork.SuplidoresRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.Suplidores();
            }
            

            oCom.SUP_NOMBRE = this.txtNombreCorto.Text.ToString();
            oCom.SUP_CODIGO = this.txtCodigo.Text.ToString();
            oCom.SUP_ESTADO = cmbEstado.Text.ToString();
            oCom.ORI_ID = Convert.ToInt32(cmbOrigen.SelectedValue);


            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.SuplidoresRepository.Update(oCom);
                else
                    unitOfWork.SuplidoresRepository.Insert(oCom);

                unitOfWork.Save();
                bRetorno = true;
                usrbntMant1.bExito = true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    string s = "";


                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += ve.ErrorMessage + "\n";

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
            var suplidores = unitOfWork.SuplidoresRepository.GetByID(Id);

            MoverDatos(suplidores);

        }

        void MoverDatos(BO.Models.Suplidores MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "SUP_ID":
                        ctr.Text = MyComp.SUP_ID.ToString();
                        break;
                    case "SUP_CODIGO":
                        ctr.Text = MyComp.SUP_CODIGO.ToString();
                        break;
                    case "SUP_NOMBRE":
                        ctr.Text = MyComp.SUP_NOMBRE.ToString();
                        break;
                    case "SUP_ESTADO":
                        ctr.Text = MyComp.SUP_ESTADO.ToString();
                        break;
                    case "ORI_ID":
                        if (MyComp.ORI_ID != null)
                            ((ComboBox)ctr).SelectedValue = Convert.ToInt32(MyComp.ORI_ID.ToString());
                        else
                            ((ComboBox)ctr).SelectedValue = -1;

                        break;
                    
                }


            }
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

        private void tabMant_TabIndexChanged(object sender, EventArgs e)
        {


        }

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
