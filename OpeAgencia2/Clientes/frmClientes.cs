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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        int _Id;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();


        private void frmClientes_Load(object sender, EventArgs e)
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


        protected void CargarDatosIniciales()
        {
            /*
             * var q =
         from c in categories
         join p in products on c equals p.Category
         select new { Category = c, p.ProductName };
             */
            if (txtFindEPS.Text == string.Empty && txtNombreBuscar.Text == string.Empty && txtApellidoBuscar.Text == string.Empty)
            {
                dg.DataSource = null;
                return;
            }
            int piUserId;
            piUserId = Parametros.Parametros.UsuarioId;
            var opciones = from p in unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == "-1")
                           join j in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == piUserId) on p.CTE_SUC_ID 
                           equals j.SUC_ID
                           select new { Id = p.CTE_ID, EPS = p.CTE_NUMERO_EPS, Nombres = p.CTE_NOMBRE, Apellidos = p.CTE_APELLIDO };
            if (txtFindEPS.Text != "")
            {
                opciones = from p in unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtFindEPS.Text &&
                               s.CTE_SUC_ID == Parametros.ParametrosSucursal.IdSucursal)
                           join j in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == piUserId) on p.CTE_SUC_ID 
                           equals j.SUC_ID
                           select new { Id = p.CTE_ID, EPS = p.CTE_NUMERO_EPS, Nombres = p.CTE_NOMBRE, Apellidos = p.CTE_APELLIDO };
            }
            else if (txtNombreBuscar.Text != "" && txtApellidoBuscar.Text == "")
            {
                opciones = from p in unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NOMBRE == txtNombreBuscar.Text &&
                               s.CTE_SUC_ID == Parametros.ParametrosSucursal.IdSucursal)
                           join j in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == piUserId) on p.CTE_SUC_ID 
                           equals j.SUC_ID
                           select new { Id = p.CTE_ID, EPS = p.CTE_NUMERO_EPS, Nombres = p.CTE_NOMBRE, Apellidos = p.CTE_APELLIDO };
            }
            else if (txtNombreBuscar.Text == "" && txtApellidoBuscar.Text != "")
            {
                opciones = from p in unitOfWork.ClientesRepository.Get(filter: s => s.CTE_APELLIDO == txtApellidoBuscar.Text &&
                               s.CTE_SUC_ID == Parametros.ParametrosSucursal.IdSucursal)
                           join j in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == piUserId) on p.CTE_SUC_ID 
                           equals j.SUC_ID
                           select new { Id = p.CTE_ID, EPS = p.CTE_NUMERO_EPS, Nombres = p.CTE_NOMBRE, Apellidos = p.CTE_APELLIDO };
            }
            else if (txtNombreBuscar.Text != "" && txtApellidoBuscar.Text != "")
            {
                opciones = from p in unitOfWork.ClientesRepository.Get(filter: s => s.CTE_APELLIDO == txtApellidoBuscar.Text &&
                    s.CTE_NOMBRE == txtNombreBuscar.Text && s.CTE_SUC_ID == Parametros.ParametrosSucursal.IdSucursal)
                           join j in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == piUserId) on p.CTE_SUC_ID 
                           equals j.SUC_ID
                           select new { Id = p.CTE_ID, EPS = p.CTE_NUMERO_EPS, Nombres = p.CTE_NOMBRE, Apellidos = p.CTE_APELLIDO };
            }
            if (opciones.Any())
                dg.DataSource = opciones.ToList();
            else
            {
                dg.DataSource = null;
                //MessageBox.Show("El número de EPS no está registrado en la agencia.", "EPS no registrado",
                //    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            tabMant.SelectedIndex = 0;
        }

        #region "Combos"

        void CargarCombo()
        {
            ComboTipoCliente();
            ComboNacionalidad();
            ComboEstadoCliente();
            ComboSucursalCliente();
            ComboTipoMensajeria();
            ComboTipoFiscalCliente();
            ComboCodigosTarifa();
        }

        private void cmbCTE_SUC_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSucId = Convert.ToInt32(cmbCTE_SUC_ID.SelectedValue);
            ComboUsuarios(iSucId);
        }

        void ComboTipoCliente()
        {
            var sup = from p in unitOfWork.TiposRepository.GetByGroupCode("TCLI")
                      select new { Id = p.TIPO_ID, Nombre = p.TIPO_CODIGO + "-->" + p.TIPO_NOMBRE };
            //
            this.cmbCTE_TIPO_ID.ValueMember = "Id";
            cmbCTE_TIPO_ID.DisplayMember = "Nombre";
            //
            cmbCTE_TIPO_ID.DataSource = sup.ToList();
            cmbCTE_TIPO_ID.SelectedValue = -1;
        }

        void ComboNacionalidad()
        {
            var Paises = from p in unitOfWork.CodigosRepository.GetByGroupCode("CP")
                         select new { Id = p.CODIGO_ID, Nombre = p.CODIGO_COD + "-->" + p.CODIGO_NOMBRE };
            this.cmbCOD_PAIS.DisplayMember = "Nombre";
            cmbCOD_PAIS.ValueMember = "Id";
            this.cmbCOD_PAIS.DataSource = Paises.ToList();
            cmbCOD_PAIS.SelectedIndex = 0;
        }
        //cmbCTE_ESTADO_ID

        void ComboEstadoCliente()
        {
            var sup = from p in unitOfWork.EstadosRepository.GetByGroupCode("ESTCLI")
                      select new { Id = p.ESTADO_ID, Nombre = p.ESTADO_CODIGO + "-->" + p.ESTADO_NOMBRE };
            //
            this.cmbCTE_ESTADO_ID.ValueMember = "Id";
            cmbCTE_ESTADO_ID.DisplayMember = "Nombre";
            //
            cmbCTE_ESTADO_ID.DataSource = sup.ToList();
            cmbCTE_ESTADO_ID.SelectedValue = -1;
        }

        //cmbCTE_SUC_ID

        void ComboSucursalCliente()
        {
            //Agregar filtro de usuario 
            //piUserId
            int piUserId = -1;
            piUserId = Parametros.Parametros.UsuarioId;
            var Qry = (from p in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == piUserId)
                       select new { Id = p.SUC_ID, Nombre = p.Sucursales.SUC_CODIGO + " " + p.Sucursales.SUC_DESCRIPCION + "(" + p.Sucursales.Empresas.COM_DESCORTA + ")" }
                       ).Distinct();
            //
            this.cmbCTE_SUC_ID.ValueMember = "Id";
            cmbCTE_SUC_ID.DisplayMember = "Nombre";
            //
            cmbCTE_SUC_ID.DataSource = Qry.ToList();
            //cmbCTE_SUC_ID.SelectedValue = -1;
        }

        void ComboUsuarios(int piSucursalId)
        {
            var Qry = from p in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.SUC_ID == piSucursalId)
                      select new { Id = p.Usuarios.USUARIO_ID, Nombre = p.Usuarios.NOMBRES + " " + p.Usuarios.APELLIDOS + 
                          "(" + p.Usuarios.USER_NAME + ")" };


            //
            this.cmbCTE_RESPRESENTANTE_ID.ValueMember = "Id";
            cmbCTE_RESPRESENTANTE_ID.DisplayMember = "Nombre";
            //
            cmbCTE_RESPRESENTANTE_ID.DataSource = Qry.ToList();

            cmbCTE_RESPRESENTANTE_ID.SelectedValue = -1;
        }

        //cmbTIPO_MENSAJERIA_ID

        void ComboTipoMensajeria()
        {
            var sup = from p in unitOfWork.TiposRepository.GetByGroupCode("TM")
                      select new { Id = p.TIPO_ID, Nombre = p.TIPO_CODIGO + "-->" + p.TIPO_NOMBRE }
                         ;


            //
            this.cmbTIPO_MENSAJERIA_ID.ValueMember = "Id";
            cmbTIPO_MENSAJERIA_ID.DisplayMember = "Nombre";
            //
            cmbTIPO_MENSAJERIA_ID.DataSource = sup.ToList();

            cmbTIPO_MENSAJERIA_ID.SelectedValue = -1;

        }
        //cmbCTE_TIPO_FISCAL


        void ComboTipoFiscalCliente()
        {
            var sup = from p in unitOfWork.TiposRepository.GetByGroupCode("TFCLI")
                      select new { Id = p.TIPO_ID, Nombre = p.TIPO_CODIGO + "-->" + p.TIPO_NOMBRE }
                         ;


            //
            this.cmbCTE_TIPO_FISCAL.ValueMember = "Id";
            cmbCTE_TIPO_FISCAL.DisplayMember = "Nombre";
            //
            cmbCTE_TIPO_FISCAL.DataSource = sup.ToList();

            cmbCTE_TIPO_FISCAL.SelectedValue = -1;

        }
        //cmbCOD_TARIFA
        //CTAR

        void ComboCodigosTarifa()
        {
            var sup = from p in unitOfWork.CodigosRepository.GetByGroupCode("CTAR")
                      select new { Id = p.CODIGO_ID, Nombre = p.CODIGO_COD + "-->" + p.CODIGO_NOMBRE }
                         ;


            //
            this.cmbCOD_TARIFA.ValueMember = "Id";
            this.cmbCOD_TARIFA.DisplayMember = "Nombre";
            //
            cmbCOD_TARIFA.DataSource = sup.ToList();

            cmbCOD_TARIFA.SelectedValue = -1;

        }





        #endregion


        #region "botones"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabMant.SelectedIndex = 1;
            // textCargoId.Text = "";
            LimpiarCampos();
            ManejarEstado(true);
            textCTE_NUMERO_EPS.Enabled = true;

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


            BO.Models.Clientes oCom;


            if (usrbntMant1.bAdiciona == false)
            {
                //iId = Convert.ToInt32(this.textCargoId.Text);
                oCom = unitOfWork.ClientesRepository.GetByID(_Id);
            }
            else
            {
                oCom = new BO.Models.Clientes();
            }


            MoverDatos(oCom, false);
            /*
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
            *.
             */
            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.ClientesRepository.Update(oCom);
                else
                    unitOfWork.ClientesRepository.Insert(oCom);

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
            var Prod = unitOfWork.ClientesRepository.GetByID(Id);

            MoverDatos(Prod, true);
        }

        void MoverDatos(BO.Models.Clientes MyComp, bool pbConsulta)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (TabPage mPage in tabControl1.TabPages)
            {
                foreach (Control ctr in mPage.Controls)
                {
                    ProcesaSubControles(ctr, ref MyComp, pbConsulta);



                }
            }
        }

        void ProcesaSubControles(Control pControl, ref BO.Models.Clientes MyComp, bool pbConsulta)
        {

            foreach (Control ctr in pControl.Controls)
            {
                if (ctr.Controls.Count > 0)
                    ProcesaSubControles(ctr, ref MyComp, pbConsulta);


                if (ctr.Tag == null)
                    continue;


                switch (ctr.Tag.ToString())
                {
                    case "CTE_NUMERO_EPS":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_NUMERO_EPS.ToString();
                        else
                            MyComp.CTE_NUMERO_EPS = ((TextBox)ctr).Text;
                        break;
                    case "CTE_EPS_DESTINADO":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_EPS_DESTINADO.ToString();
                        else
                            MyComp.CTE_EPS_DESTINADO = ((TextBox)ctr).Text;
                        break;
                    case "CTE_TIPO_ID":
                        if (pbConsulta)
                            ((ComboBox)ctr).SelectedValue = MyComp.CTE_TIPO_ID;
                        else
                            MyComp.CTE_TIPO_ID = Convert.ToInt32(((ComboBox)ctr).SelectedValue);
                        break;

                    case "CTE_NOMBRE":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_NOMBRE;
                        else
                            MyComp.CTE_NOMBRE = ((TextBox)ctr).Text;
                        break;
                    case "CTE_APELLIDO":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_APELLIDO;
                        else
                            MyComp.CTE_APELLIDO = ((TextBox)ctr).Text;

                        break;
                    case "COD_PAIS":
                        if (pbConsulta)
                            ((ComboBox)ctr).SelectedValue = MyComp.COD_PAIS;
                        else
                            MyComp.COD_PAIS = Convert.ToInt32(((ComboBox)ctr).SelectedValue);

                        break;
                    case "CTE_DIRECCION_OFICINA":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_DIRECCION_OFICINA;
                        else
                            MyComp.CTE_DIRECCION_OFICINA = ((TextBox)ctr).Text;
                        break;
                    case "CTE_DIRECCION_CASA":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_DIRECCION_CASA;
                        else
                            MyComp.CTE_DIRECCION_CASA = ((TextBox)ctr).Text;

                        break;
                    case "CTE_FECHA_NACIMIENTO":
                        if (pbConsulta)
                            ((DateTimePicker)ctr).Value = MyComp.CTE_FECHA_NACIMIENTO;
                        else
                            MyComp.CTE_FECHA_NACIMIENTO = ((DateTimePicker)ctr).Value;


                        break;
                    case "CTE_FECHA_INGRESO":
                        //Adicional   Porcentaje  Sin Tope
                        if (pbConsulta)
                            ((DateTimePicker)ctr).Value = MyComp.CTE_FECHA_INGRESO;
                        else
                        {
                            MyComp.CTE_FECHA_INGRESO = ((DateTimePicker)ctr).Value;
                            MyComp.CTE_FECHA_RENOVACION = ((DateTimePicker)ctr).Value;
                            MyComp.CTE_FECHA_VENCIMIENTO = ((DateTimePicker)ctr).Value;
                            MyComp.CTE_FECHA_VOICE = ((DateTimePicker)ctr).Value;
                            MyComp.CTE_FECHA_CAMBIO = ((DateTimePicker)ctr).Value;
                            MyComp.CTE_ENTRO_WEB = ((DateTimePicker)ctr).Value;
                        }

                        break;
                    case "CTE_FECHA_VENCIMIENTO":
                        if (pbConsulta)
                            ((DateTimePicker)ctr).Value = MyComp.CTE_FECHA_VENCIMIENTO;
                        else
                            MyComp.CTE_FECHA_VENCIMIENTO = ((DateTimePicker)ctr).Value;

                        break;
                    case "CTE_TELEFONO_CASA":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_TELEFONO_CASA;
                        else
                            MyComp.CTE_TELEFONO_CASA = ((TextBox)ctr).Text;

                        break;
                    case "CTE_TELEFONO_OFICINA":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_TELEFONO_OFICINA;
                        else
                            MyComp.CTE_TELEFONO_OFICINA = ((TextBox)ctr).Text;
                        break;
                    case "CTE_FAX":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_FAX;
                        else
                            MyComp.CTE_FAX = ((TextBox)ctr).Text;
                        break;
                    case "CTE_CELULAR":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_CELULAR;
                        else
                            MyComp.CTE_CELULAR = ((TextBox)ctr).Text;
                        break;
                    case "CTE_EXT_TELOFIC":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_EXT_TELOFIC;
                        else
                            MyComp.CTE_EXT_TELOFIC = ((TextBox)ctr).Text;
                        break;

                    case "CTE_ESTADO_ID":
                        if (pbConsulta)
                            ((ComboBox)ctr).SelectedValue = MyComp.CTE_ESTADO_ID;
                        else
                            MyComp.CTE_ESTADO_ID = Convert.ToInt32(((ComboBox)ctr).SelectedValue);
                        break;

                    case "CTE_JUNK_MAIL":
                        if (pbConsulta)
                            ((CheckBox)ctr).Checked = MyComp.CTE_JUNK_MAIL;
                        else
                            MyComp.CTE_JUNK_MAIL = ((CheckBox)ctr).Checked;
                        break;
                    case "CTE_LLAMAR_VOICE":
                        if (pbConsulta)
                            ((CheckBox)ctr).Checked = MyComp.CTE_LLAMAR_VOICE;
                        else
                            MyComp.CTE_LLAMAR_VOICE = ((CheckBox)ctr).Checked;

                        break;
                    case "CTE_PAGO_TARJETA":
                        if (pbConsulta)
                            ((CheckBox)ctr).Checked = MyComp.CTE_PAGO_TARJETA;
                        else
                            MyComp.CTE_PAGO_TARJETA = ((CheckBox)ctr).Checked;

                        break;
                    case "CTE_PAGO_CHEQUE":
                        if (pbConsulta)
                            ((CheckBox)ctr).Checked = MyComp.CTE_PAGO_CHEQUE;
                        else
                            MyComp.CTE_PAGO_CHEQUE = ((CheckBox)ctr).Checked;

                        break;
                    case "CTE_EXONERADO_ADUANA":
                        if (pbConsulta)
                            ((CheckBox)ctr).Checked = MyComp.CTE_EXONERADO_ADUANA;
                        else
                            MyComp.CTE_EXONERADO_ADUANA = ((CheckBox)ctr).Checked;

                        break;
                    case "CTE_ENVIAR_FAX":
                        if (pbConsulta)
                            ((CheckBox)ctr).Checked = MyComp.CTE_ENVIAR_FAX;
                        else
                            MyComp.CTE_ENVIAR_FAX = ((CheckBox)ctr).Checked;

                        break;
                    case "CTE_ENVIAR_EMAIL":
                        if (pbConsulta)
                            ((CheckBox)ctr).Checked = MyComp.CTE_ENVIAR_EMAIL;
                        else
                            MyComp.CTE_ENVIAR_EMAIL = ((CheckBox)ctr).Checked;

                        break;
                    case "CTE_CHEQUES_DEV":
                        if (pbConsulta)
                            ((NumericUpDown)ctr).Value = MyComp.CTE_CHEQUES_DEV;
                        else
                            MyComp.CTE_CHEQUES_DEV = ((NumericUpDown)ctr).Value;

                        break;
                    case "CTE_CEDULA":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_CEDULA;
                        else
                            MyComp.CTE_CEDULA = ((TextBox)ctr).Text;

                        break;
                    case "CTE_RNC":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_RNC;
                        else
                            MyComp.CTE_RNC = ((TextBox)ctr).Text;

                        break;
                    case "CTE_PASAPORTE":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_PASAPORTE;
                        else
                            MyComp.CTE_PASAPORTE = ((TextBox)ctr).Text;
                        break;
                    case "CTE_CREDITO":
                        if (pbConsulta)
                            ((CheckBox)ctr).Checked = MyComp.CTE_CREDITO;
                        else
                            MyComp.CTE_CREDITO = ((CheckBox)ctr).Checked;

                        break;
                    case "CTE_DIAS_CREDITOS":
                        if (pbConsulta)
                            ((NumericUpDown)ctr).Value = MyComp.CTE_DIAS_CREDITOS;
                        else
                            MyComp.CTE_DIAS_CREDITOS = ((NumericUpDown)ctr).Value;

                        break;
                    case "CTE_LIMITE_CREDITO":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_LIMITE_CREDITO.ToString();
                        else
                        {
                            if (((TextBox)ctr).Text == "")
                                MyComp.CTE_LIMITE_CREDITO = 0;
                            else
                                MyComp.CTE_LIMITE_CREDITO = Convert.ToDecimal(((TextBox)ctr).Text);
                        }
                        break;
                    case "CTE_BALANCE_DISPONIBLE":

                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_BALANCE_DISPONIBLE.ToString();
                        else
                        {
                            if (((TextBox)ctr).Text == "")
                                MyComp.CTE_BALANCE_DISPONIBLE = 0;
                            else
                                MyComp.CTE_BALANCE_DISPONIBLE = Convert.ToDecimal(((TextBox)ctr).Text);
                        }
                        break;
                    case "CTE_SUC_ID":
                        if (pbConsulta)
                            ((ComboBox)ctr).SelectedValue = MyComp.CTE_SUC_ID;
                        else
                            MyComp.CTE_SUC_ID = Convert.ToInt32(((ComboBox)ctr).SelectedValue);
                        break;
                    case "CTE_RESPRESENTANTE_ID":
                        if (pbConsulta)
                            ((ComboBox)ctr).SelectedValue = MyComp.CTE_RESPRESENTANTE_ID;
                        else
                            MyComp.CTE_RESPRESENTANTE_ID = Convert.ToInt32(((ComboBox)ctr).SelectedValue);
                        break;
                    case "TIPO_MENSAJERIA_ID":
                        if (pbConsulta)
                            ((ComboBox)ctr).SelectedValue = MyComp.TIPO_MENSAJERIA_ID;
                        else
                            MyComp.TIPO_MENSAJERIA_ID = Convert.ToInt32(((ComboBox)ctr).SelectedValue);
                        break;
                    case "CTE_TIPO_FISCAL":
                        if (pbConsulta)
                            ((ComboBox)ctr).SelectedValue = MyComp.CTE_TIPO_FISCAL;
                        else
                            MyComp.CTE_TIPO_FISCAL = Convert.ToInt32(((ComboBox)ctr).SelectedValue);
                        break;
                    case "COD_TARIFA":
                        if (pbConsulta)
                            ((ComboBox)ctr).SelectedValue = MyComp.COD_TARIFA;
                        else
                            MyComp.COD_TARIFA = Convert.ToInt32(((ComboBox)ctr).SelectedValue);
                        break;
                    case "CFG_METODO_TARIFA":
                        if (pbConsulta)
                            ((ComboBox)ctr).SelectedIndex = MyComp.CFG_METODO_TARIFA;
                        else
                            MyComp.CFG_METODO_TARIFA = ((ComboBox)ctr).SelectedIndex;
                        break;
                    case "CTE_DIA_CORTE":
                        if (pbConsulta)
                            ((NumericUpDown)ctr).Value = MyComp.CTE_DIA_CORTE;
                        else
                            MyComp.CTE_DIA_CORTE = Convert.ToInt32(((NumericUpDown)ctr).Value);
                        break;
                    case "CTE_NOMBRE_COMPANIA":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_NOMBRE_COMPANIA;
                        else
                            MyComp.CTE_NOMBRE_COMPANIA = ((TextBox)ctr).Text;
                        break;
                    case "CTE_CARGO":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_CARGO;
                        else
                            MyComp.CTE_CARGO = ((TextBox)ctr).Text;
                        break;
                    case "CTE_COBRADOR":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_COBRADOR;
                        else
                            MyComp.CTE_COBRADOR = ((TextBox)ctr).Text;
                        break;
                    case "CTE_CODIGO_VOICE":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_CODIGO_VOICE;
                        else
                            MyComp.CTE_CODIGO_VOICE = MyComp.CTE_CODIGO_VOICE;
                        break;
                    case "CTE_LIBRAS_GRATIS":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_LIBRAS_GRATIS.ToString();
                        else
                        {
                            if (((TextBox)ctr).Text == "")
                                MyComp.CTE_LIBRAS_GRATIS = 0;
                            else
                                MyComp.CTE_LIBRAS_GRATIS = Convert.ToDecimal(((TextBox)ctr).Text);
                        }
                        break;
                    case "CTE_LIBRAS_ACUMULADAS":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_LIBRAS_ACUMULADAS.ToString();
                        else
                        {
                            if (((TextBox)ctr).Text == "")
                                MyComp.CTE_LIBRAS_ACUMULADAS = 0;
                            else
                                MyComp.CTE_LIBRAS_ACUMULADAS = Convert.ToDecimal(((TextBox)ctr).Text);
                        }
                        break;
                    case "CTE_MENSAJE_PIE":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_MENSAJE_PIE;
                        else
                            MyComp.CTE_MENSAJE_PIE = ((TextBox)ctr).Text;
                        break;
                    case "CTE_MANEJO_OPERACIONAL":
                        if (pbConsulta)
                            ((ComboBox)ctr).SelectedIndex = MyComp.CTE_MANEJO_OPERACIONAL;
                        else
                            MyComp.CTE_MANEJO_OPERACIONAL = ((ComboBox)ctr).SelectedIndex;
                        break;
                    case "CTE_EMAIL":
                        if (pbConsulta)
                            ((TextBox)ctr).Text = MyComp.CTE_EMAIL;
                        else
                            MyComp.CTE_EMAIL = ((TextBox)ctr).Text;
                        break;
                }
            }
        }

        void ManejarEstado(bool bEstado)
        {
            foreach (Control ctr in tabControl1.Controls)
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
            foreach (Control ctr in tabPage2.Controls)
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
                    tabControl1.SelectedIndex = 0;
                    //tabMant.SelectedTab = tabPage2;
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }

        private void txtFindEPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CargarDatosIniciales();
        }

        private void txtFindEPS_Leave(object sender, EventArgs e)
        {
            CargarDatosIniciales();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BO.DAL.ADO.ClientesDAL oCli = new BO.DAL.ADO.ClientesDAL();

            MessageBox.Show("El código secreto en la base de datos principal es:\n" + oCli.RetornaCodigoVoice_dbeps(this.textCTE_NUMERO_EPS.Text.TrimEnd()), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
