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


namespace OpeAgencia2.Clientes
{
    public partial class frmTarifasEspeciales : Form
    {
        public frmTarifasEspeciales()
        {
            InitializeComponent();
        }

        int _Id;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();


        private void frmTarifasEspeciales_Load(object sender, EventArgs e)
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

        protected void CargarCombo()
        {
            CargarProductos();
        }


        protected void CargarProductos()
        {
            var Productos = from p in unitOfWork.ProductosRepository.Get(filter: xy => (xy.Tipos.TIPO_CODIGO == "R" || xy.Tipos.TIPO_CODIGO == "E"))
                            select new { Id = p.PROD_ID, Nombre = p.PRO_CODIGO + "-->" + p.PRO_DESCRIPCION };
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "Id";
            this.cmbProducto.DataSource = Productos.ToList();

            cmbProducto.SelectedIndex = 0;

        }

        protected void CargarCargosProd(int iProdId)
        {
            var Cargos = from p in unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProdId && (s.Cargos.CAR_BASE_ID==25 || s.Cargos.CAR_BASE_ID==28) && s.FIJO==true)
                         select new { Id = p.CARGO_PROD_ID, Nombre = p.Cargos.CAR_CODIGO + "-->" + p.Cargos.CAR_DESCRIPCION }
                     ;
            /*
            var cargosExits = from p in unitOfWork.TarifasEspecialesRepository.Get(filter: s => s.PROD_ID == iProdId)
                              select new { Id = p.CARGO_ID, Nombre = p.Cargos.CAR_CODIGO + "-->" + p.Cargos.CAR_DESCRIPCION };

            var filteredList = Cargos.Except(cargosExits);
            */

            //
            this.cmbCargo.ValueMember = "Id";
            cmbCargo.DisplayMember = "Nombre";
            //
           cmbCargo.DataSource = Cargos.ToList();

           cmbCargo.SelectedValue = -1;

        }


        #endregion



        protected void CargarDatosIniciales()
        {
           
            int piUserId;

            piUserId = Parametros.Parametros.UsuarioId;


            var opciones = from p in unitOfWork.TarifasEspecialesRepository.Get(filter: s => s.Clientes.CTE_NUMERO_EPS == "-1")
                           join j in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == piUserId) on p.Clientes.CTE_SUC_ID equals j.SUC_ID
                           select new { Id = p.TAR_ESP_ID, EPS = p.Clientes.CTE_NUMERO_EPS, Nombres = p.Clientes.CTE_NOMBRE, Apellidos = p.Clientes.CTE_APELLIDO, p.CargosProducto.Cargos.CAR_DESCRIPCION };




            if (txtFindEPS.Text != "")
            {
               
                opciones = from p in unitOfWork.TarifasEspecialesRepository.Get(filter: s => s.Clientes.CTE_NUMERO_EPS == txtFindEPS.Text)
                           join j in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == piUserId) on p.Clientes.CTE_SUC_ID equals j.SUC_ID
                           select new { Id = p.TAR_ESP_ID, EPS = p.Clientes.CTE_NUMERO_EPS, Nombres = p.Clientes.CTE_NOMBRE, Apellidos = p.Clientes.CTE_APELLIDO, p.CargosProducto.Cargos.CAR_DESCRIPCION };


            }
          

            if (opciones != null)
                dg.DataSource = opciones.ToList();
            else
                dg.DataSource = null;


            tabControl1.SelectedIndex = 0;

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }

        #region "ManejarEstados"

        void ManejarEstado(bool bEstado)
        {
            foreach (Control ctr in tabMant.Controls)
            {
                ManejaEstados(ctr, bEstado);
            }
        }

        void ManejaEstados(Control oControl, bool bEstado)
        {
            foreach (Control ctr in oControl.Controls)
            {
                if ((ctr.GetType().Name == "TextBox") || (ctr.GetType().Name == "ComboBox")
                       || (ctr.GetType().Name == "NumericUpDown") || (ctr.GetType().Name == "CheckBox"))
                {
                    if (ctr.Name.Substring(0, 4) == "text")
                        ctr.Enabled = false;
                    else
                        ctr.Enabled = bEstado;
                }
                if (ctr.Controls.Count > 0)
                    ManejaEstados(ctr, bEstado);
            }
        }



        void LimpiarCampos()
        {
            foreach (Control ctr in tabMant.Controls)
            {
                LimpiarCampos(ctr);
            }
        }

        void LimpiarCampos(Control oControl)
        {
            foreach (Control ctr in oControl.Controls)
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
                if (ctr.Controls.Count > 0)
                    LimpiarCampos(ctr);
            }
        }


        #endregion



        #region "botones"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabControl1.SelectedIndex = 1;
            // textCargoId.Text = "";
            LimpiarCampos();
            ManejarEstado(true);
            //textCTE_NUMERO_EPS.Enabled = true;

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
           // DeleteData();
           // CargarDatosIniciales();
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
            tabControl1.SelectedIndex = 0;
        }

        #endregion


        void DeleteData()
        {


            //int iId = Convert.ToInt32(this.textCargoId.Text);

            //var opciones = unitOfWork.SucursalesRepository.GetByID(iId);

            try
            {

                unitOfWork.CargosRepository.Delete(_Id);
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


            BO.Models.TarifasEspeciales oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                //iId = Convert.ToInt32(this.textCargoId.Text);
                oCom = unitOfWork.TarifasEspecialesRepository.GetByID(_Id);
            }
            else
            {
                oCom = new BO.Models.TarifasEspeciales();
            }


            MoverDatos(oCom, false);
          
            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.TarifasEspecialesRepository.Update(oCom);
                else
                    unitOfWork.TarifasEspecialesRepository.Insert(oCom);

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
                tabControl1.SelectedIndex = 0;

            }
            ConsultarDatos(_Id);

        }


        void ConsultarDatos(int Id)
        {
            unitOfWork = new BO.DAL.UnitOfWork();
            var Prod = unitOfWork.TarifasEspecialesRepository.GetByID(Id);

            MoverDatos(Prod, true);

            BuscarEps(Prod.CTE_ID);

        }

        void BuscarEps(int piCteId)
        {
            var oCli = unitOfWork.ClientesRepository.GetByID(piCteId);

            txtNumeroEps.Text = oCli.CTE_NUMERO_EPS;
            lblNombres.Text = oCli.CTE_NOMBRE + " " + oCli.CTE_APELLIDO;
        }

        void MoverDatos(BO.Models.TarifasEspeciales MyComp, bool pbConsulta)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabMant.Controls)
            {
              
                    ProcesaSubControles(ctr, ref MyComp, pbConsulta);
            }
        }

        void ProcesaSubControles(Control pControl, ref BO.Models.TarifasEspeciales MyComp, bool pbConsulta)
        {

            foreach (Control ctr in pControl.Controls)
            {
                if (ctr.Controls.Count > 0)
                    ProcesaSubControles(ctr, ref MyComp, pbConsulta);


                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "CTE_ID":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_ID.ToString();
                        else
                            MyComp.CTE_ID = Convert.ToInt32(((TextBox)ctr).Text);
                        break;
                    case "TAR_ESP_ID":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.TAR_ESP_ID.ToString();
                        
                        break;
                    case "PROD_ID":
                        if (pbConsulta)
                            ((ComboBox)ctr).SelectedValue = MyComp.PROD_ID;
                        else
                            MyComp.PROD_ID = Convert.ToInt32(((ComboBox)ctr).SelectedValue);
                        break;
                    case "CARGO_PROD_ID":
                        if (pbConsulta)
                            ((ComboBox)ctr).SelectedValue = MyComp.CARGO_PROD_ID;
                        else
                            MyComp.CARGO_PROD_ID = Convert.ToInt32(((ComboBox)ctr).SelectedValue);
                        break;

                    case "FECHA_DESDE":
                        if (pbConsulta)
                            ((DateTimePicker)ctr).Value = MyComp.FECHA_DESDE;
                        else
                            MyComp.FECHA_DESDE = ((DateTimePicker)ctr).Value;
                        break;
                    case "FECHA_HASTA":
                        //Adicional   Porcentaje  Sin Tope
                        if (pbConsulta)
                            ((DateTimePicker)ctr).Value = MyComp.FECHA_HASTA;
                        else
                        {
                            MyComp.FECHA_HASTA = ((DateTimePicker)ctr).Value;
                        }

                        break;

                    case "ACTIVO":
                        if (pbConsulta)
                            ((CheckBox)ctr).Checked = MyComp.ACTIVO;
                        else
                            MyComp.ACTIVO = ((CheckBox)ctr).Checked;
                        break;
                }
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iProdId = Convert.ToInt32(cmbProducto.SelectedValue);
            CargarCargosProd(iProdId);
        }


        private void tabMant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
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
                    tabControl1.SelectedIndex = 1;
                    //tabMant.SelectedTab = tabPage2;
                }
            }
        }

        private void textFindEPS_Leave(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }

        private void txtNumeroEps_Leave(object sender, EventArgs e)
        {
            var eps = unitOfWork.ClientesRepository.Get(filter: xy => xy.CTE_NUMERO_EPS == txtNumeroEps.Text).FirstOrDefault();

            if (eps != null)
            {
                txtCteId.Text = eps.CTE_ID.ToString();
                lblNombres.Text = eps.CTE_NOMBRE.ToString() + " " + eps.CTE_APELLIDO.ToString();
            }
            else
            {
                txtCteId.Text = "-1";
                lblNombres.Text = "";

            }

        }

        private void btnValores_Click(object sender, EventArgs e)
        {
            if (_Id != -1)
            {
                frmTarEspValores oForm = new frmTarEspValores(_Id, this.txtNumeroEps.Text + "-" + lblNombres.Text);
                oForm.ShowDialog();
            }
        }
    }
}
