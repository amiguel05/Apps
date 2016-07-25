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
    public partial class frmModulos : Form
    {
        public frmModulos()
        {
            InitializeComponent();
        }

        int _Id;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmModulos_Load(object sender, EventArgs e)
        {
            this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
            this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
            this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
            this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
            this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
            this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);

            CargarCombo();

            CargarDatosIniciales();

           

            ManejarEstado(false);
        }


        #region "Combos"

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        void CargarCombo()
        {
            ComboCargosBas();
         


        }

       

        void ComboCargosBas()
        {
            var sup = from p in unitOfWork.TiposRepository.GetByGroupCode("TMON")
                      select new { Id = p.TIPO_ID, Nombre = p.TIPO_CODIGO + "-->" + p.TIPO_NOMBRE }
                         ;


            //
            this.cmbTipoId.ValueMember = "Id";
            cmbTipoId.DisplayMember = "Nombre";
            //
            cmbTipoId.DataSource = sup.ToList();

            cmbTipoId.SelectedValue = -1;

        }
        #endregion


        protected void CargarDatosIniciales()
        {

         
            try
            {
                var opciones = from p in unitOfWork.ModulosRepository.Get()
                               select new { Id = p.MOD_ID, Nombre = p.MOD_NOMBRE, Descripción = p.MOD_DESCRIPCION };


                dg.DataSource = opciones.ToList();
                tabMant.SelectedIndex = 0;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


         

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
                int iModId = 0;
              

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


            int iId = Convert.ToInt32(this.textId.Text);

            //var opciones = unitOfWork.SucursalesRepository.GetByID(iId);

            try
            {

                unitOfWork.ModulosRepository.Delete(iId);
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


            BO.Models.Modulos oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textId.Text);
                oCom = unitOfWork.ModulosRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.Modulos();
            }

            oCom.TIPO_ID = Convert.ToInt32(this.cmbTipoId.SelectedValue.ToString());
            oCom.MOD_NOMBRE = txtNombre.Text;
            oCom.MOD_DESCRIPCION = txtDescripcion.Text;
           
            oCom.MOD_ESTADO = chkEstado.Checked;
          
            //oCom.CARGO_ID = textCargoId.Text;

            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.ModulosRepository.Update(oCom);
                else
                    unitOfWork.ModulosRepository.Insert(oCom);

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
            var Prod = unitOfWork.ModulosRepository.GetByID(Id);

            MoverDatos(Prod);
        }

        void MoverDatos(BO.Models.Modulos MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "MOD_ID":
                        ((TextBox)ctr).Text = MyComp.MOD_ID.ToString();
                        break;
                    case "MOD_NOMBRE":
                        ((TextBox)ctr).Text = MyComp.MOD_NOMBRE;
                        break;
                    case "MOD_DESCRIPCION":
                        ((TextBox)ctr).Text = MyComp.MOD_DESCRIPCION;
                        break;
                    case "MOD_TIPO":
                        ((ComboBox)ctr).SelectedValue = MyComp.TIPO_ID;
                        break;
                    case "MOD_ESTADO":
                        ((CheckBox)ctr).Checked = MyComp.MOD_ESTADO;
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
            if (tabMant.SelectedIndex == 1)
            {
                try
                {
                    _Id = Convert.ToInt32(dg.CurrentRow.Cells[0].Value);
                    ConsultarDatos(_Id);

                }
                catch (Exception ex)
                {
                    //throw ex;
                    _Id = -1;
                }
                if (_Id != -1)
                {
                    tabMant.SelectedTab = tabPage2;

                }
            }

        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       


    }
}
