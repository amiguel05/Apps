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
    public partial class frmCargos : Form
    {
        public frmCargos()
        {
            InitializeComponent();
        }

        int _Id;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();


        private void frmProductos_Load(object sender, EventArgs e)
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
            ComboCargosBas();
           

        }

        void ComboCargosBas()
        {
            var sup = from p in unitOfWork.TiposRepository.GetByGroupCode("BC") 
                      select new { Id = p.TIPO_ID, Nombre = p.TIPO_CODIGO + "-->" + p.TIPO_NOMBRE }
                         ;


            //
            cmbCAR_BASE.ValueMember = "Id";
            cmbCAR_BASE.DisplayMember = "Nombre";
            //
            cmbCAR_BASE.DataSource = sup.ToList();

            cmbCAR_BASE.SelectedValue = -1;

        }
        #endregion


        protected void CargarDatosIniciales()
        {

            var opciones = from p in unitOfWork.CargosRepository.Get()
                           orderby(p.CAR_CODIGO)
                           select new { Id = p.CARGO_ID, Código = p.CAR_CODIGO, Descripción = p.CAR_DESCRIPCION };



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

                unitOfWork.CargosRepository.Delete(iId);
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


            BO.Models.Cargos oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textCargoId.Text);
                oCom = unitOfWork.CargosRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.Cargos();
            }

            oCom.CAR_BASE_ID = Convert.ToInt32(this.cmbCAR_BASE.SelectedValue.ToString());
            oCom.CAR_CODIGO = txtCodigo.Text;
            oCom.CAR_DESCRIPCION = txtCAR_DESCRIPCION.Text;
            oCom.CAR_DIRECTO_TABLA = cmbCarDirectoTabla.Text.Substring(0, 1);
            oCom.CAR_ESTADO = chkEstado.Checked;
            oCom.CAR_FIJO_MULTIPLICAR = this.cmbCarFijoMultiplicar.Text.Substring(0, 1);
            oCom.CAR_ITBIS = this.chkItebis.Checked;

            oCom.CAR_MINIMO_FACTURAR = txtMinimoFacturar.Value;

            oCom.CAR_RED_ENTEROS = chkRedondearEnteros.Checked;
            oCom.CAR_REDONDEAR = chkRedondear.Checked;
            oCom.CAR_SUMAR = chkSumar.Checked;
            oCom.CAR_TIPO = this.cmbTipoId.Text.Substring(0, 1);
            oCom.CAR_TOPE_MAXIMO = this.cmbCAR_TOPE_MAXIMO.Text.Substring(0, 1);
            //oCom.CARGO_ID = textCargoId.Text;
            oCom.ITBIS = txtPorITBIS.DecimalValue;

            oCom.CAR_NCF = chkNCF.Checked;
            oCom.CAR_NC = chk_NC.Checked;
            oCom.CAR_COBROS = chkCobros.Checked;

            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.CargosRepository.Update(oCom);
                else
                    unitOfWork.CargosRepository.Insert(oCom);

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
            var Prod = unitOfWork.CargosRepository.GetByID(Id);

            MoverDatos(Prod);
        }

        void MoverDatos(BO.Models.Cargos MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "CARGO_ID":
                        ((TextBox)ctr).Text = MyComp.CARGO_ID.ToString();
                        break;
                    case "CAR_CODIGO":
                        ((TextBox)ctr).Text = MyComp.CAR_CODIGO;
                        break;
                    case "CAR_DESCRIPCION":
                        ((TextBox)ctr).Text = MyComp.CAR_DESCRIPCION;
                        break;
                    case "CAR_TIPO":
                        ((ComboBox)ctr).SelectedIndex = MyComp.CAR_TIPO.ToString().TrimEnd() == "U" ? 0 : 1;
                        break;
                    case "CAR_ESTADO":
                        ((CheckBox)ctr).Checked = MyComp.CAR_ESTADO;
                        break;
                    case "CAR_DIRECTO_TABLA":
                        ((ComboBox)ctr).SelectedIndex = MyComp.CAR_DIRECTO_TABLA == "D" ? 0 : 1;
                        break;
                    case "CAR_FIJO_MULTIPLICAR":
                        ((ComboBox)ctr).SelectedIndex = MyComp.CAR_FIJO_MULTIPLICAR == "F" ? 0 : 1;
                        break;
                    case "CAR_ITBIS":
                        ((CheckBox)ctr).Checked = MyComp.CAR_ITBIS;
                        break;
                    case "CAR_TOPE_MAXIMO":
                        //Adicional   Porcentaje  Sin Tope
                        ((ComboBox)ctr).SelectedIndex = ((ComboBox)ctr).SelectedIndex = MyComp.CAR_TIPO == "A" ? 0 : (MyComp.CAR_TIPO == "P" ? 1 : 2);
                        break;
                    case "CAR_MINIMO_FACTURAR":
                        ((NumericUpDown)ctr).Value  = MyComp.CAR_MINIMO_FACTURAR;
                        break;
                    case "CAR_RED_ENTEROS":
                        ((CheckBox)ctr).Checked = MyComp.CAR_RED_ENTEROS;
                        break;
                    case "CAR_REDONDEAR":
                        ((CheckBox)ctr).Checked = MyComp.CAR_REDONDEAR;
                        break;
                    case "CAR_SUMAR":
                        ((CheckBox)ctr).Checked = MyComp.CAR_SUMAR;
                        break;
                    case "CAR_BASE_ID":
                        ((ComboBox)ctr).SelectedValue = MyComp.CAR_BASE_ID;
                        break;
                    case "ITBIS":
                        ((clsUtils.NumericTextBox)ctr).DecimalValue = MyComp.ITBIS;
                        break;
                    case "CAR_NCF":
                        ((CheckBox)ctr).Checked = MyComp.CAR_NCF;
                        break;
                    case "CAR_NC":
                        ((CheckBox)ctr).Checked = MyComp.CAR_NC;
                        break;
                    case "CAR_COBROS":
                        ((CheckBox)ctr).Checked = MyComp.CAR_COBROS;
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



    }
}
