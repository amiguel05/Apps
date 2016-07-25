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
    public partial class frmProductos : Form
    {
        public frmProductos()
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
            ComboSuplidores();
            ComboOrigen();
            ComboGrupoProd();
            ComboTipoProd();
            ComboTipoDocCred();

            ComboCodUnidad();
          
        }

        void  ComboSuplidores()
        {
             var sup = from p in unitOfWork.SuplidoresRepository.Get(orderBy: s => s.OrderBy(x => x.SUP_NOMBRE),filter: s => s.SOCIO == true)
                           select new { Id = p.SUP_ID, Nombre = p.SUP_NOMBRE + "-->" + p.SUP_CODIGO}
                          ;


            //
            cmbSuplidorId.ValueMember = "Id";
            cmbSuplidorId.DisplayMember = "Nombre";
            //
            cmbSuplidorId.DataSource = sup.ToList();

            cmbSuplidorId.SelectedValue = -1;

        }


        void ComboOrigen()
        {
            var sup = from p in unitOfWork.OrigenRepository.Get(orderBy: s => s.OrderBy(x => x.ORI_CODIGO))
                      select new { Id = p.ORI_ID, Nombre = p.ORI_CODIGO + "-->" + p.ORI_DESCRIPCION };


            //
            cmbORI_ID.ValueMember = "Id";
            cmbORI_ID.DisplayMember = "Nombre";
            //
            cmbORI_ID.DataSource = sup.ToList();

            cmbORI_ID.SelectedValue = -1;

        }

        void ComboGrupoProd()
        {
            var sup = from p in unitOfWork.CodigosRepository.GetByGroupCode("GPRO")
                      select new { Id = p.CODIGO_ID, Nombre = p.CODIGO_NOMBRE };


            //
            cmbGRP_COD_ID.ValueMember = "Id";
            cmbGRP_COD_ID.DisplayMember = "Nombre";
            //
            cmbGRP_COD_ID.DataSource = sup.ToList();

            cmbGRP_COD_ID.SelectedValue = -1;

        }
        //PRO_TIPO_ID
        void ComboTipoProd()
        {
            var sup = from p in unitOfWork.TiposRepository.GetByGroupCode("TP")
                      select new { Id = p.TIPO_ID, Nombre = p.TIPO_DESCR };

            //
            cmbTipo.ValueMember = "Id";
            cmbTipo.DisplayMember = "Nombre";
            //
            cmbTipo.DataSource = sup.ToList();

            cmbTipo.SelectedValue = -1;

        }
        //
        //PRO_TIPO_ID
        void ComboTipoDocCred()
        {
            var sup = from p in unitOfWork.TiposRepository.GetByGroupCode("TF")
                      select new { Id = p.TIPO_ID, Nombre = p.TIPO_DESCR };


            //
            cmbDOC_TIPO_ID.ValueMember = "Id";
            cmbDOC_TIPO_ID.DisplayMember = "Nombre";
            //
            cmbDOC_TIPO_ID.DataSource = sup.ToList();

            cmbDOC_TIPO_ID.SelectedValue = -1;

        }
       
        //COD_UND_ID
        void ComboCodUnidad()
        {
            var sup = from p in unitOfWork.CodigosRepository.GetByGroupCode("UM")
                      select new { Id = p.CODIGO_ID, Nombre = p.CODIGO_NOMBRE };


            //
            cmbUnidad.ValueMember = "Id";
            cmbUnidad.DisplayMember = "Nombre";
            //
            cmbUnidad.DataSource = sup.ToList();

            cmbUnidad.SelectedValue = -1;

        }


        #endregion

        protected void CargarDatosIniciales()
        {

            var opciones = from p in unitOfWork.ProductosRepository.Get()
                           select new { Id = p.PROD_ID, Código = p.PRO_CODIGO, Descripción = p.PRO_DESCRIPCION };



            dg.DataSource = opciones.ToList();
            tabMant.SelectedIndex = 0;

        }


        #region "botones"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabMant.SelectedIndex = 1;
            textPROD_ID.Text = "";
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


            int iId = Convert.ToInt32(this.textPROD_ID.Text);

            //var opciones = unitOfWork.SucursalesRepository.GetByID(iId);

            try
            {

                unitOfWork.ProductosRepository.Delete(iId);
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


            BO.Models.Productos oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textPROD_ID.Text);
                oCom = unitOfWork.ProductosRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.Productos();
            }

            oCom.COD_UND_ID = Convert.ToInt32(cmbUnidad.SelectedValue.ToString());
            oCom.DOC_TIPO_ID = Convert.ToInt32(this.cmbDOC_TIPO_ID.SelectedValue.ToString());
            oCom.GRP_COD_ID = Convert.ToInt32(this.cmbGRP_COD_ID.SelectedValue.ToString());
            oCom.ORI_ID = Convert.ToInt32(this.cmbORI_ID.SelectedValue.ToString());
            oCom.PRO_CODIGO = txtCodigo.Text;
            oCom.PRO_COMENTARIO = txtPRO_COMENTARIO.Text;
            oCom.PRO_COURIER = this.chkCourier.Checked;
            oCom.PRO_DESCRIPCION = this.txtPRO_DESCRIPCION.Text;
            oCom.PRO_ESTADO = this.chkEstado.Checked;
            oCom.PRO_MENSAJERIA = chkMensajeria.Checked;
            oCom.PRO_MINIMO = txtMinimoFacturar.DecimalValue;
            oCom.PRO_TIPO_ID = Convert.ToInt32(cmbTipo.SelectedValue.ToString());
            oCom.SUP_ID = Convert.ToInt32(cmbSuplidorId.SelectedValue.ToString());
                     
            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.ProductosRepository.Update(oCom);
                else
                    unitOfWork.ProductosRepository.Insert(oCom);

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
            var Prod = unitOfWork.ProductosRepository.GetByID(Id);

            MoverDatos(Prod);
            ConsultarCargos(Id);
        }

        void ConsultarCargos(int Id)
        {

            var CargosProd = from p in unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == Id)
                       select new { Id = p.CARGO_PROD_ID, Codigo = p.Cargos.CAR_CODIGO, Desc = p.Cargos.CAR_DESCRIPCION, Moneda = p.TasaCambio.TASA_CODIGO, Fijo = p.FIJO };

            dgCargos.DataSource = CargosProd.ToList();


        }

        void MoverDatos(BO.Models.Productos MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "COD_UND_ID":
                        ((ComboBox)ctr).SelectedValue = Convert.ToInt32(MyComp.COD_UND_ID);
                        break;
                    case "DOC_TIPO_ID":
                        ((ComboBox)ctr).SelectedValue = Convert.ToInt32(MyComp.DOC_TIPO_ID);
                        break;
                    case "GRP_COD_ID":
                        ((ComboBox)ctr).SelectedValue = Convert.ToInt32(MyComp.GRP_COD_ID);
                        break;
                    case "ORI_ID":
                        ((ComboBox)ctr).SelectedValue = Convert.ToInt32(MyComp.ORI_ID);
                        break;
                    case "PRO_CODIGO":
                        ((TextBox)ctr).Text = MyComp.PRO_CODIGO;
                        break;
                    case "PRO_COMENTARIO":
                        ((TextBox)ctr).Text = MyComp.PRO_COMENTARIO;
                        break;
                    case "PRO_COURIER":
                        ((CheckBox)ctr).Checked = MyComp.PRO_COURIER;
                        break;
                    case "PRO_DESCRIPCION":
                        ((TextBox)ctr).Text = MyComp.PRO_DESCRIPCION;
                        break;
                    case "PRO_ESTADO":
                        ((CheckBox)ctr).Checked = MyComp.PRO_ESTADO;
                        break;
                    case "PRO_MENSAJERIA":
                        ((CheckBox)ctr).Checked = MyComp.PRO_MENSAJERIA;
                        break;
                    case "PRO_MINIMO":
                        ((clsUtils.NumericTextBox)ctr).DecimalValue = MyComp.PRO_MINIMO;
                        //txtMinimoFacturar.DecimalValue = MyComp.PRO_MINIMO;
                        break;
                    case "PRO_TIPO_ID":
                        ((ComboBox)ctr).SelectedValue = MyComp.PRO_TIPO_ID;
                        break;
                    case "PROD_ID":
                        ((TextBox)ctr).Text = MyComp.PROD_ID.ToString();
                        break;
                    case "SUP_ID":
                        ((ComboBox)ctr).SelectedValue = Convert.ToInt32(MyComp.SUP_ID.ToString());
                        break;

                }


            }
        }

        void ManejarEstado(bool bEstado)
        {
            foreach (Control ctr in tabPage2.Controls)
            {
                if ((ctr.GetType().Name == "TextBox") || (ctr.GetType().Name == "ComboBox") 
                    || (ctr.GetType().Name == "NumericUpDown") || (ctr.GetType().Name == "CheckBox") || (ctr.GetType().Name == "NumericTextBox"))
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
                else if (ctr.GetType().Name == "NumericTextBox")
                    ((clsUtils.NumericTextBox)ctr).IntValue = 0;
         

            }
        }

        private void tabMant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((tabMant.SelectedIndex == 1) || (tabMant.SelectedIndex == 2))
            {
                try
                {
                    _Id = Convert.ToInt32(dg.CurrentRow.Cells[0].Value);

                    if (!usrbntMant1.bAdiciona)
                       ConsultarDatos(_Id);
                    
                    lblProducto.Text = txtPRO_DESCRIPCION.Text;
                    this.btnAddCargo.Enabled = !usrbntMant1.bAdiciona;
                    dgCargos.Enabled = !usrbntMant1.bAdiciona;
                   
                    

                }
                catch(Exception ex)
                {
                    throw ex;
                    _Id = -1;
                }
                if ((_Id != -1) && (tabMant.SelectedIndex == 1))
                {
                    tabMant.SelectedTab = tabPage2;

                }
            }

        }

        private void btnAddCargo_Click(object sender, EventArgs e)
        {
            frmCargosProducto x = new frmCargosProducto(_Id, -1);
          
            x.ShowDialog();
        }

        private void dgCargos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void dgCargos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgCargos_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            int iCargoId = -1;
            try
            {
                iCargoId = Convert.ToInt32(dgCargos.CurrentRow.Cells[0].Value);
            }
            catch
            {
                iCargoId = -1;
            }

            if (iCargoId > 0)
            {
                frmCargosProducto x = new frmCargosProducto(_Id, iCargoId);

                x.ShowDialog();

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DialogResult x = MessageBox.Show("¿Seguro que quiere borrar el cargo seleccionado?", "Aviso", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);

            if (x == System.Windows.Forms.DialogResult.No)
                return;

            int iCargoId = -1;
            try
            {
                iCargoId = Convert.ToInt32(dgCargos.CurrentRow.Cells[0].Value);
            }
            catch
            {
                iCargoId = -1;
            }

            if (iCargoId > 0)
            {
                BO.Models.CargosProducto oProd = unitOfWork.CargosProductoRepository.GetByID(iCargoId);

                try
                {
                    var oValores = unitOfWork.CargosValoresRepository.Get(filter: s => s.CARGO_PROD_ID == iCargoId);

                    foreach (var oVar in oValores)
                    {
                        unitOfWork.CargosValoresRepository.Delete(oVar.TABLA_VAL_ID);
                    }
                    unitOfWork.Save();

                    unitOfWork.CargosProductoRepository.Delete(oProd);
                    unitOfWork.Save();

                    MessageBox.Show("Cargo eliminando exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

        }
    }
}
