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
using System.Security.Cryptography;
using System.IO;

namespace OpeAgencia2.Seguridad
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        int _Id;

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
            this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
            this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
            this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
            this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
            this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);

            CargarCombo();



            ManejarEstado(false);

            CargarDatosIniciales();
        }


        #region "Combos"


        void CargarCombo()
        {
            ComboCargosTipoUser();

        }



        void ComboCargosTipoUser()
        {
            var sup = from p in unitOfWork.TiposRepository.GetByGroupCode("TUSER")
                      select new { Id = p.TIPO_ID, Nombre = p.TIPO_CODIGO + "-->" + p.TIPO_NOMBRE }
                         ;


            //
            this.cmbTipo.ValueMember = "Id";
            cmbTipo.DisplayMember = "Nombre";
            //
            cmbTipo.DataSource = sup.ToList();

            cmbTipo.SelectedValue = -1;

        }

        void ComboSucursales(int pId)
        {
            var Qry = from p in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == pId)
                      select new { Id = p.USR_SUC_ID, Nombre = p.Sucursales.SUC_CODIGO + " " + p.Sucursales.SUC_DESCRIPCION + "(" + p.Sucursales.Empresas.COM_DESCORTA + ")" }
                        ;


            //
            this.cmbSucursal.ValueMember = "Id";
            cmbSucursal.DisplayMember = "Nombre";
            //
            cmbSucursal.DataSource = Qry.ToList();

            cmbSucursal.SelectedValue = -1;

        }
        #endregion


        protected void CargarDatosIniciales()
        {


            try
            {
                var opciones = from p in unitOfWork.UsuariosRepository.Get()
                               select new { Id = p.USUARIO_ID, Nombre = p.USER_NAME, Descripción = p.NOMBRES + " " + p.APELLIDOS };


                dg.DataSource = opciones.ToList();
                tabMant.SelectedIndex = 0;

            }
            catch (Exception ex)
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
            txtNombres.Focus();
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
                unitOfWork.UsuariosRepository.Delete(iId);
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
            BO.Models.Usuarios oCom;
            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(this.textId.Text);
                oCom = unitOfWork.UsuariosRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.Usuarios();
            }
            oCom.TIPO_ID = Convert.ToInt32(this.cmbTipo.SelectedValue.ToString());
            oCom.NOMBRES = txtNombres.Text;
            oCom.APELLIDOS = this.txtApellidos.Text;
            oCom.ESTADO = chkEstado.Checked;
            oCom.FECHA_CLAVE = DateTime.Now;
            oCom.FECHA_PROX_CAMBIO = DateTime.Now.AddDays(60);
            oCom.USER_NAME = txtUserName.Text;
            oCom.CLAVE = txtClave.Text;
            try
            {
                if (usrbntMant1.bAdiciona == false)
                    unitOfWork.UsuariosRepository.Update(oCom);
                else
                    unitOfWork.UsuariosRepository.Insert(oCom);
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

        void ConsultaSucursales(int Id)
        {
            try
            {
                var Qry = from p in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == Id)
                          select new { Id = p.USR_SUC_ID, Empresa = p.Sucursales.Empresas.COM_DESCORTA, Sucursal = p.Sucursales.SUC_CODIGO, Descripción = p.Sucursales.SUC_DESCRIPCION };
                dgSucursales.DataSource = Qry.ToList();
                tabMant.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ConsultarDatos(int Id)
        {
            var Prod = unitOfWork.UsuariosRepository.GetByID(Id);
            ConsultaSucursales(Id);
            ComboSucursales(Id);
            MoverDatos(Prod);
        }

        void MoverDatos(BO.Models.Usuarios MyComp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach (Control ctr in tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;
                switch (ctr.Tag.ToString())
                {
                    case "USUARIO_ID":
                        ((TextBox)ctr).Text = MyComp.USUARIO_ID.ToString();
                        break;
                    case "USER_NAME":
                        ((TextBox)ctr).Text = MyComp.USER_NAME;
                        break;
                    case "NOMBRES":
                        ((TextBox)ctr).Text = MyComp.NOMBRES;
                        break;
                    case "APELLIDOS":
                        ((TextBox)ctr).Text = MyComp.APELLIDOS;
                        break;
                    case "TIPO_ID":
                        ((ComboBox)ctr).SelectedValue = MyComp.TIPO_ID;
                        break;
                    case "ESTADO":
                        ((CheckBox)ctr).Checked = MyComp.ESTADO;
                        break;
                    case "CLAVE":
                        ((TextBox)ctr).Text = MyComp.CLAVE;
                        break;
                    case "FECHA_CLAVE":
                        ((TextBox)ctr).Text = MyComp.FECHA_CLAVE.ToShortDateString();
                        break;
                    case "FECHA_PROX_CAMBIO":
                        ((TextBox)ctr).Text = MyComp.FECHA_PROX_CAMBIO.ToShortDateString();
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
            else if (tabMant.SelectedIndex == 2)
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
                    tabMant.SelectedTab = tabSucursales;
                }
            }
            else if (tabMant.SelectedIndex == 3)
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
                    tabMant.SelectedTab = tabRoles;
                }
            }
        }

        private void btnAddSucursal_Click(object sender, EventArgs e)
        {
            if (_Id > 0)
            {
                frmAddSucursal oSuc = new frmAddSucursal(_Id);
                oSuc.ShowDialog();
            }
        }

        private void btnQuitarSuc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quiere quitar el acceso a la sucursal seleccionada?", "Quitar acceso a sucursal",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                == System.Windows.Forms.DialogResult.Yes)
            {
                int iUsrSucId = -1;
                iUsrSucId = Convert.ToInt32(dgSucursales.CurrentRow.Cells[0].Value);
                unitOfWork.UsuarioSucursalRepository.Delete(iUsrSucId);
                try
                {
                    unitOfWork.Save();
                    ConsultarDatos(_Id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            if (_Id > 0)
            {
                frmAccesoUsuarioSucursal oFrm = new frmAccesoUsuarioSucursal(_Id);
                oFrm.ShowDialog();
            }
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultaRoles();
        }

        void ConsultaRoles()
        {
            int iUsrSucId = Convert.ToInt32(cmbSucursal.SelectedValue);
            var Qry = from p in unitOfWork.UsuariosRolesRepository.Get(filter: s => s.USR_SUC_ID == iUsrSucId)
                      select new { Id = p.USR_ROLE_ID, Nombre = p.Roles.NOMBRE, Desc = p.Roles.DESCRIPCION };
            dgRoles.DataSource = Qry.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iUsrSucId = Convert.ToInt32(cmbSucursal.SelectedValue);
            frmAgregarRoles ofrm = new frmAgregarRoles(_Id, iUsrSucId);
            ofrm.ShowDialog();
            ConsultaRoles();
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            txtClave.Text = string.Join("", new MD5CryptoServiceProvider().ComputeHash(new MemoryStream(Encoding.UTF8.GetBytes(this.txtClave.Text))).Select(x => x.ToString("X2")));
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            var rolUsuario = unitOfWork.UsuariosRolesRepository.GetByID(dgRoles.CurrentRow.Cells["id"].Value);
            unitOfWork.UsuariosRolesRepository.Delete(dgRoles.CurrentRow.Cells["id"].Value);
            unitOfWork.Save();
            ConsultaRoles();
        }
    }
}
