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

namespace OpeAgencia2.Precios
{
    public partial class frmTasaCambio : Form
    {
        public frmTasaCambio()
        {
            InitializeComponent();
        }

        int _Id;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();


        private void frmTasaCambio_Load(object sender, EventArgs e)
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

        void CargarCombo()
        {
            ComboMonedaBase();

            ComboMonedaConv();
        }

        void ComboMonedaBase()
        {
            var sup = from p in unitOfWork.CodigosRepository.GetByGroupCode("CMON")
                      select new { Id = p.CODIGO_ID, Nombre = p.CODIGO_COD + "-->" + p.CODIGO_NOMBRE }
                         ;


            //
            cmbMonedaBase.ValueMember = "Id";
            cmbMonedaBase.DisplayMember = "Nombre";
            //
            cmbMonedaBase.DataSource = sup.ToList();

            cmbMonedaBase.SelectedValue = -1;

        }

        void ComboMonedaConv()
        {
            var sup = from p in unitOfWork.CodigosRepository.GetByGroupCode("CMON")
                      select new { Id = p.CODIGO_ID, Nombre = p.CODIGO_COD + "-->" + p.CODIGO_NOMBRE }
                        ;


            //
            cmbMonedaConv.ValueMember = "Id";
            cmbMonedaConv.DisplayMember = "Nombre";
            //
            cmbMonedaConv.DataSource = sup.ToList();

            cmbMonedaConv.SelectedValue = -1;

        }
        #endregion


        protected void CargarDatosIniciales()
        {

            var opciones = from p in unitOfWork.TasaCambioRepository.Get()
                           select new { Id = p.TASA_ID, Código = p.TASA_CODIGO, Descripción = p.TASA_DESCRIPCION };



            dg.DataSource = opciones.ToList();
            tabMant.SelectedIndex = 0;

        }


        #region "botones"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabMant.SelectedIndex = 1;
            textCargoId.Text = "";
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


            int iId = Convert.ToInt32(this.textCargoId.Text);

            //var opciones = unitOfWork.SucursalesRepository.GetByID(iId);

            try
            {

                unitOfWork.TasaCambioRepository.Delete(iId);
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


            BO.Models.TasaCambio oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textCargoId.Text);
                oCom = unitOfWork.TasaCambioRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.TasaCambio();
            }

           
            oCom.TASA_CODIGO = txtCodigo.Text;
            oCom.TASA_DESCRIPCION = txtDescr.Text;
            oCom.MONEDA_BASE_ID = Convert.ToInt32(this.cmbMonedaBase.SelectedValue);
            oCom.MONEDA_CONV_ID = Convert.ToInt32(this.cmbMonedaConv.SelectedValue);
            oCom.FACTOR_CONV = Convert.ToDecimal(txtFactor.Text);
           
            //oCom.CARGO_ID = textCargoId.Text;

            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.TasaCambioRepository.Update(oCom);
                else
                    unitOfWork.TasaCambioRepository.Insert(oCom);

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
            var Prod = unitOfWork.TasaCambioRepository.GetByID(Id);

            MoverDatos(Prod);
        }

        void MoverDatos(BO.Models.TasaCambio MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "TASA_ID":
                        ((TextBox)ctr).Text = MyComp.TASA_ID.ToString();
                        break;
                    case "TASA_CODIGO":
                        ((TextBox)ctr).Text = MyComp.TASA_CODIGO;
                        break;
                    case "MONEDA_BASE_ID":
                        ((ComboBox)ctr).SelectedValue = MyComp.MONEDA_BASE_ID;
                        break;
                    case "MONEDA_CONV_ID":
                        ((ComboBox)ctr).SelectedValue = MyComp.MONEDA_CONV_ID;
                        break;
                    case "FACTOR_CONV":
                        ((TextBox)ctr).Text = MyComp.FACTOR_CONV.ToString();
                        break;
                    case "TASA_DESCRIPCION":
                        ((TextBox)ctr).Text = MyComp.TASA_DESCRIPCION;
                        break;
                  

                }


            }
        }

        void ManejarEstado(bool bEstado)
        {
            foreach (Control ctr in tabPage2.Controls)
            {
                if ((ctr.GetType().Name == "TextBox") || (ctr.GetType().Name == "ComboBox")
                    || (ctr.GetType().Name == "NumericUpDown") || (ctr.GetType().Name == "CheckBox") || (ctr.GetType().Name == "MaskedTextBox"))
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

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            decimal dValor = 0;

            if (decimal.TryParse(txtFactor.Text, out dValor) == false)
                txtFactor.Text = "0" ;
            


        }

        private void txtFactor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFactor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') & ((TextBox)sender).Text.IndexOf('.') == -1)
                e.Handled = false;
            else if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
            else if (e.KeyChar == Convert.ToChar(8))
                e.Handled = false;
            else if (e.KeyChar == Convert.ToChar(13))
                e.Handled = true;
            else
                e.Handled = false;


           /* Dim txt As TextBox = CType(sender, TextBox)

If Not Char.IsDigit(e.KeyChar) Then e.Handled = True

If e.KeyChar = Chr(8) Then e.Handled = False 'allow Backspace

If e.KeyChar = "." And txt.Text.IndexOf(".") = -1 Then e.Handled = False 'allow single decimal point

If e.KeyChar = "-" And txt.SelectionStart = 0 Then e.Handled = False 'allow negative number

If e.KeyChar = Chr(13) Then GetNextControl(txt, True).Focus() 'Enter key moves to next control
                */
        }










    }
}
