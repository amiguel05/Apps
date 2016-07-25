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


namespace OpeAgencia2.Facturacion
{
    public partial class frmRegistraImpresora : Form
    {
        public frmRegistraImpresora()
        {
            InitializeComponent();
        }

        int _Id;
        int _iSucId;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmRegistraImpresora_Load(object sender, EventArgs e)
        {
            try
            {
                this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
                this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
                this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
                this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
                this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
                this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);

                _iSucId = -1;

               CargarCombos();

//                CargarDatosIniciales(_iGrupoId);

  //              ManejarEstado(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarCombos()
        {

            var sQry = from p in Parametros.Parametros.UsuarioSucursal
                       select new { Id=p.Sucursales.SUC_ID, Nombre=p.Sucursales.SUC_DESCRIPCION };

            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "Id";
            cmbSucursal.DataSource = sQry.ToList();

            cmbSucursal.Visible = true;

        }
        //

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            _iSucId = Convert.ToInt32(cmbSucursal.SelectedValue);
            CargarDatosIniciales(_iSucId);
            //lblGrupo.Text = cmbGrupo.Text.ToString();

        }

        protected void CargarDatosIniciales(int piGrupoId)
        {

            var grupos = from p in unitOfWork.TerminalRepository.Get(filter: s => s.SUC_ID == piGrupoId)
                         select new { Id = p.TERM_ID, Nombre = p.TERM_DESC, Descripción = p.SERIAL };


            dg.DataSource = grupos.ToList();
            tabMant.SelectedIndex = 0;
        }
        //

        #region "botones"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabMant.SelectedIndex = 1;
            textTERM_ID.Text = "";
            TextSerial.Text = "";
            _iSucId = Convert.ToInt32(cmbSucursal.SelectedValue);
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


            int iId = Convert.ToInt32(this.textTERM_ID.Text);

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


            BO.Models.Terminal oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textTERM_ID.Text);
                oCom = unitOfWork.TerminalRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.Terminal();
            }


            oCom.TERM_DESC = this.txtTermDesc.Text.ToString();
            oCom.SERIAL = this.TextSerial.Text.ToString();
        
            oCom.PUERTO = this.txtPuerto.Text.ToString();
           
            oCom.SUC_ID = _iSucId;


            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.TerminalRepository.Update(oCom);
                else
                    unitOfWork.TerminalRepository.Insert(oCom);

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
            var objetoneg = unitOfWork.TerminalRepository.GetByID(Id);

            MoverDatos(objetoneg);

        }

        void MoverDatos(BO.Models.Terminal MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "TERM_ID":
                        ctr.Text = MyComp.TERM_ID.ToString();
                        break;
                    case "TERM_DESC":
                        ctr.Text = MyComp.TERM_DESC.ToString();
                        break;
                    case "SERIAL":
                        ctr.Text = MyComp.SERIAL.ToString();
                        break;
                    case "PUERTO":
                        ctr.Text = MyComp.PUERTO.ToString();
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

        private void btnSerial_Click(object sender, EventArgs e)
        {
            TextSerial.Text = clsUtils.Utils.ObtenerSerialTerminal();
            txtTermDesc.Text = Environment.MachineName;
        }

        private void cmbSucursal_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _iSucId = Convert.ToInt32(cmbSucursal.SelectedValue);
            CargarDatosIniciales(_iSucId);
            
        }

       
    }
}
