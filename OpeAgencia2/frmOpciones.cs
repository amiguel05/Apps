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


namespace OpeAgencia2
{
    public partial class frmOpciones : Form
    {
        public frmOpciones()
        {
            InitializeComponent();
        }

       
        int _Id;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
      
        private void usrbntMant1_Load(object sender, EventArgs e)
        {
              
        }

        private void frmOpciones_Load(object sender, EventArgs e)
        {
            this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
            this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
            this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
            this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
            this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
            this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);

            CargarCombo();
            ComboModulos();

            //CargarDatosIniciales();

            ManejarEstado(false);

        }

        void CargarCombo()
        {
            var opciones = from p in unitOfWork.OpcionesRepository.Get()
                           select new { Id = p.OPC_ID, Nombre = p.OPC_NAME };


            //
            cmbPartenId.ValueMember = "Id";
            cmbPartenId.DisplayMember = "Nombre";
            //
            cmbPartenId.DataSource = opciones.ToList();

            cmbPartenId.SelectedValue = -1;

        }

        void ComboModulos()
        {
            var sup = from p in unitOfWork.ModulosRepository.Get()
                      select new { Id = p.MOD_ID, Nombre = p.MOD_NOMBRE +"("+ p.Tipos.TIPO_NOMBRE +")" }
                         ;


            //
            this.cmbModulo.ValueMember = "Id";
            cmbModulo.DisplayMember = "Nombre";
            //
            cmbModulo.DataSource = sup.ToList();

            cmbModulo.SelectedIndex = 0;

        }

        private void cmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iModId = 0;
            iModId = Convert.ToInt32(cmbModulo.SelectedValue);
            CargarDatosIniciales(iModId);

        }

        protected void CargarDatosIniciales(int piModId)
        {

            var opciones = from p in unitOfWork.OpcionesRepository.Get(filter: s => s.MOD_ID == piModId)
                             select new { Id = p.OPC_ID, Nombre = p.OPC_NAME, Descripción = p.OPC_FORM , Padre = p.OPC_PARENT_ID, Orden = p.OPC_ORDER};



            dg.DataSource = opciones.ToList();
            tabMant.SelectedIndex = 0;

        }

        #region "botones"
      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabMant.SelectedIndex = 1;
            textOPC_ID.Text = "";
            LimpiarCampos();
            ManejarEstado(true);
        
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            int iModId = 0;

            DeleteData();
           
            iModId = Convert.ToInt32(cmbModulo.SelectedValue);
            CargarDatosIniciales(iModId);
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

            if(SalvarDatos())
            {
                int iModId = 0;
                usrbntMant1.bExito =true;
                ManejarEstado(false);
                iModId = Convert.ToInt32(cmbModulo.SelectedValue);
                CargarDatosIniciales(iModId);
              

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


            int iId = Convert.ToInt32(this.textOPC_ID.Text);

            //var opciones = unitOfWork.SucursalesRepository.GetByID(iId);

            try
            {

                unitOfWork.OpcionesRepository.Delete(iId);
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


            BO.Models.Opciones oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textOPC_ID.Text);
                oCom = unitOfWork.OpcionesRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.Opciones();
            }

            oCom.MOD_ID = Convert.ToInt32(cmbModulo.SelectedValue);
            oCom.OPC_NAME = this.txtNombre.Text.ToString();
            oCom.OPC_FORM = this.txtFormulario.Text.ToString();
            oCom.OPC_STATE = chkActive.Checked;
            oCom.OPC_PARENT_ID = Convert.ToInt32(cmbPartenId.SelectedValue);
            oCom.OPC_ORDER = oCom.OPC_PARENT_ID +  Convert.ToInt32(txtOrder.Value);


            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.OpcionesRepository.Update(oCom);
                else
                    unitOfWork.OpcionesRepository.Insert(oCom);

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
            var opciones = unitOfWork.OpcionesRepository.GetByID(Id);

            MoverDatos(opciones);
        }

        void MoverDatos(BO.Models.Opciones MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach(Control ctr in  tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;

                
                switch (ctr.Tag.ToString())
                {
                    case "OPC_ID":
                        ctr.Text = MyComp.OPC_ID.ToString();
                        break;
                    case "OPC_FORM":
                        ctr.Text = MyComp.OPC_FORM == null ? "" : MyComp.OPC_FORM.ToString();
                        break;
                    case "OPC_NAME":
                        ctr.Text = MyComp.OPC_NAME.ToString();
                        break;
                    case "OPC_PARENT_ID":
                        ((ComboBox)ctr).SelectedValue = Convert.ToInt32(MyComp.OPC_PARENT_ID);
                         break;
                    case "OPC_STATE":
                         ((CheckBox)ctr).Checked = MyComp.OPC_STATE;
                        break;
                    case "OPC_ORDER":
                        ((NumericUpDown)ctr).Value = MyComp.OPC_ORDER;
                        break;
                  

                }
               

            }
        }

        void ManejarEstado(bool bEstado)
        {
            foreach (Control ctr in tabPage2.Controls)
            {
               if (ctr.GetType().Name =="TextBox")
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
                else if (ctr.GetType().Name == "ComboBox")
                    ((ComboBox)ctr).SelectedValue = -1;
                else if (ctr.GetType().Name == "CheckBox")
                    ((CheckBox)ctr).Checked = false;

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
