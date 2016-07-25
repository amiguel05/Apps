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
    public partial class frmCargosSucursales : Form
    {
        public frmCargosSucursales()
        {
            InitializeComponent();
        }

        int _Id;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();


        private void frmCargosSucursales_Load(object sender, EventArgs e)
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
            CargarComboSuc();
            CargarComboProd();


        }

        void CargarComboSuc()
        {
            var sQry = from p in Parametros.Parametros.UsuarioSucursal
                       select new { p.SUC_ID, p.Sucursales.SUC_DESCRIPCION };
            cmbSucursal.DataSource = sQry.ToList();
            cmbSucursal.DisplayMember = "SUC_DESCRIPCION";
            cmbSucursal.ValueMember = "SUC_ID";
            cmbSucursal.Visible = true;

        }

        void CargarComboProd()
        {
            var sQry = from p in unitOfWork.CargosProductoRepository.Get()
                       select new { ID= p.CARGO_PROD_ID, DESC=p.Producto.PRO_DESCRIPCION +"-"+p.Cargos.CAR_DESCRIPCION };
            this.cmbCargoProducto.DataSource = sQry.ToList();
            cmbCargoProducto.DisplayMember = "DESC";
            cmbCargoProducto.ValueMember = "ID";
            cmbCargoProducto.Visible = true;

        }
        #endregion


        protected void CargarDatosIniciales()
        {

            var opciones = from p in unitOfWork.CargosSucursalesRepository.Get()
                           select new { Id = p.CARGO_SUC_ID,Sucursal=p.Sucursales.SUC_CODIGO, Producto=p.CargosProducto.Producto.PRO_DESCRIPCION,Cargo=p.CargosProducto.Cargos.CAR_DESCRIPCION, p.MINIMO_FACTURAR, p.ACTIVO };



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


            BO.Models.CargosSucursales oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textCargoId.Text);
                oCom = unitOfWork.CargosSucursalesRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.CargosSucursales();
            }

            oCom.CARGO_PROD_ID = Convert.ToInt32(this.cmbCargoProducto.SelectedValue.ToString());
            oCom.SUC_ID = Convert.ToInt32(this.cmbSucursal.SelectedValue.ToString());
          

            oCom.MINIMO_FACTURAR = txtMinimoFacturar.Value;

         
            oCom.ACTIVO = chkActivo.Checked;

            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.CargosSucursalesRepository.Update(oCom);
                else
                    unitOfWork.CargosSucursalesRepository.Insert(oCom);

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
            var Prod = unitOfWork.CargosSucursalesRepository.GetByID(Id);

            MoverDatos(Prod);
        }

        void MoverDatos(BO.Models.CargosSucursales MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "CARGO_SUC_ID":
                        ((TextBox)ctr).Text = MyComp.CARGO_SUC_ID.ToString();
                        break;
                    case "CARGO_PROD_ID":
                        ((ComboBox)ctr).SelectedValue = MyComp.CARGO_PROD_ID;
                        break;
                    case "SUC_ID":
                        ((ComboBox)ctr).SelectedValue = MyComp.SUC_ID;
                        break;
                    case "ACTIVO":
                        ((CheckBox)ctr).Checked = MyComp.ACTIVO;
                        break;
                    case "CAR_MINIMO_FACTURAR":
                        ((NumericUpDown)ctr).Value = MyComp.MINIMO_FACTURAR;
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
