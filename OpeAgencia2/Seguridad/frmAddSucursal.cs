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
    public partial class frmAddSucursal : Form
    {
        public frmAddSucursal()
        {
            InitializeComponent();
        }

        public frmAddSucursal(int piUserId)
        {
            InitializeComponent();

            iUserId = piUserId;

        }

        int iUserId = -1;


        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmAddSucursal_Load(object sender, EventArgs e)
        {
            CargarCombos();
            cmbUsuario.SelectedValue = iUserId;
        }


        void CargarCombos()
        {
            ComboSucursal();
            ComboUsuarios();
        }

        void ComboSucursal()
        {
            var sup = from p in unitOfWork.SucursalesRepository.Get()
                      select new { Id = p.SUC_ID, Nombre =  p.SUC_DESCRIPCION +"("+p.SUC_CODIGO+")" }
                        ;


            //
            this.cmbSucursal.ValueMember = "Id";
            cmbSucursal.DisplayMember = "Nombre";
            //
            cmbSucursal.DataSource = sup.ToList();

            cmbSucursal.SelectedValue = -1;
        }

        void ComboUsuarios()
        {
            var sup = from p in unitOfWork.UsuariosRepository.Get()
                      select new { Id = p.USUARIO_ID, Nombre = p.USER_NAME + "(" + p.NOMBRES  + " " + p.APELLIDOS  + ")" }
                        ;


            //
            this.cmbUsuario.ValueMember = "Id";
            cmbUsuario.DisplayMember = "Nombre";
            //
            cmbUsuario.DataSource = sup.ToList();

            cmbUsuario.SelectedValue = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Guardar() == true)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("No se puede registrar la sucursal", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool Guardar()
        {
            bool bRetorno = false;

            AgenciaEF_BO.Models.UsuarioSucursal oUsrSuc = new BO.Models.UsuarioSucursal();

            oUsrSuc.SUC_ID = Convert.ToInt32(cmbSucursal.SelectedValue);
            oUsrSuc.USUARIO_ID = iUserId;

            var suc = unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == oUsrSuc.USUARIO_ID && s.SUC_ID == oUsrSuc.SUC_ID);

            if (suc.ToList().Count <= 0)
            {
                unitOfWork.UsuarioSucursalRepository.Insert(oUsrSuc);
                bRetorno = true;
            }

            try
            {
                unitOfWork.Save();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return bRetorno;

        }



    }
}
