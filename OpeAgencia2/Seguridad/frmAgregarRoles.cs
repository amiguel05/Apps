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
    public partial class frmAgregarRoles : Form
    {
        public frmAgregarRoles()
        {
            InitializeComponent();
        }

        public frmAgregarRoles(int piUserId, int pISucUsrId)
        {
            InitializeComponent();

             iUserId = piUserId;
             iIsucUsrId = pISucUsrId;

        }

        int iUserId = -1;
        int iIsucUsrId = -1;

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmAgregarRoles_Load(object sender, EventArgs e)
        {

            CargarCombos();
            BuscarRoles();

        }

        void CargarCombos()
        {
            ComboSucursales();
            ComboUsuarios();
        }

        void ComboSucursales()
        {
            var Qry = from p in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == iUserId)
                      select new { Id = p.USR_SUC_ID, Nombre = p.Sucursales.SUC_CODIGO + " " + p.Sucursales.SUC_DESCRIPCION + "(" + p.Sucursales.Empresas.COM_DESCORTA + ")" }
                        ;


            //
            this.cmbSucursal.ValueMember = "Id";
            cmbSucursal.DisplayMember = "Nombre";
            //
            cmbSucursal.DataSource = Qry.ToList();

            cmbSucursal.SelectedValue = iIsucUsrId;

        }

        void ComboUsuarios()
        {
            var Qry = from p in unitOfWork.UsuariosRepository.Get()
                      select new { Id = p.USUARIO_ID, Nombre = p.NOMBRES + " " + p.APELLIDOS + "(" + p.USER_NAME + ")" }
                         ;


            //
            this.cmbUsuario.ValueMember = "Id";
            cmbUsuario.DisplayMember = "Nombre";
            //
            cmbUsuario.DataSource = Qry.ToList();

            cmbUsuario.SelectedValue = iUserId;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }


        void BuscarRoles()
        {

            int iModuloId = -1;

            lstRoles.Items.Clear();

            var Qry = unitOfWork.RolesRepository.Get();
                    
           
            foreach(var item in Qry)
            {
               if (!ExisteRol(item))
                  lstRoles.Items.Add( item.NOMBRE + "(" + item.Modulos.MOD_NOMBRE +")|" + item.ROL_ID.ToString());
               else
                  this.lstRolesUsuario.Items.Add( item.NOMBRE + "(" + item.Modulos.MOD_NOMBRE +")|" + item.ROL_ID.ToString());
            }
            

        }

        bool ExisteRol(BO.Models.Roles oItem)
        {
            var QryUsrRol = unitOfWork.UsuariosRolesRepository.Get(filter: s => s.ROL_ID == oItem.ROL_ID && s.USR_SUC_ID == iIsucUsrId);

            if (QryUsrRol.Count() == 0)
                return false;
            else
                return true;
        }

        private void btnPasar_Click(object sender, EventArgs e)
        {
            try
            {
                lstRolesUsuario.Items.Add(lstRoles.Items[lstRoles.SelectedIndex]);
                lstRoles.Items.RemoveAt(lstRoles.SelectedIndex);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar un rol del panel izquierdo", "Seleccionar rol",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                lstRoles.Items.Add(lstRolesUsuario.Items[lstRolesUsuario.SelectedIndex]);
                lstRolesUsuario.Items.RemoveAt(lstRolesUsuario.SelectedIndex);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar un rol del panel izquierdo", "Seleccionar rol",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarSeleccion();
            MessageBox.Show("Datos actualizados con exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        void GuardarSeleccion()
        {
            //Que lio, primero tengo que borrar todo
            BorrarRolesSucursal();
            foreach(string s in lstRolesUsuario.Items)
            {
                int iRolId = Convert.ToInt32(s.Substring(s.LastIndexOf('|') + 1));
                GuardarAgenciaRol(iRolId);
            }

        }

        void BorrarRolesSucursal()
        {
            var oRolesUsuario = unitOfWork.UsuariosRolesRepository.Get(filter: s => s.USR_SUC_ID == iIsucUsrId);

            foreach(var oItem in oRolesUsuario)
            {
                unitOfWork.UsuariosRolesRepository.Delete(oItem);
            }
            unitOfWork.Save();

        }

        void GuardarAgenciaRol(int piRolId)
        {

            BO.Models.UsuariosRoles oRoles = new BO.Models.UsuariosRoles();

            oRoles.USR_SUC_ID = iIsucUsrId;
            oRoles.ROL_ID = piRolId;
            oRoles.ACTIVO = true;

            unitOfWork.UsuariosRolesRepository.Insert(oRoles);

            unitOfWork.Save();

        }


    }
}
