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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        int iCount = 0;
        bool bAutenticado = false;

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BO.Seg.Seguridad oSeg = new BO.Seg.Seguridad();
            int iUsuarioId =-1;
            if (bAutenticado == true)
            {
                
                Parametros.Parametros.UsuarioSucursalActual = Convert.ToInt32(cmbSucursal.SelectedValue);
                Parametros.Parametros.NombreSucActual = cmbSucursal.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            if (oSeg.Autentica(txtUsuario.Text, txtClave.Text, ref iUsuarioId))
            {
                Parametros.Parametros.UsuarioId = iUsuarioId;
                Parametros.Parametros.UserName = txtUsuario.Text;
                Parametros.Parametros.UsuarioSucursal = oSeg.SucursalUsuarios(iUsuarioId);
                bAutenticado = true;
                if (Parametros.Parametros.UsuarioSucursal.Count > 1)
                {
                    var sQry = from p in Parametros.Parametros.UsuarioSucursal
                                 select new {p.USR_SUC_ID, p.Sucursales.SUC_DESCRIPCION};
                    cmbSucursal.DataSource =  sQry.ToList();
                    cmbSucursal.DisplayMember = "SUC_DESCRIPCION";
                    cmbSucursal.ValueMember = "USR_SUC_ID";
                    cmbSucursal.Visible = true;
                    lblSucursal.Visible = true;
                    grbBotones.Location = new Point(grbBotones.Location.X, grbBotones.Location.Y + 25);
                    cmbSucursal.Focus();
                }
                else
                {
                    Parametros.Parametros.SucursalActual = Convert.ToInt32(cmbSucursal.SelectedValue);
                    Parametros.Parametros.UsuarioSucursalActual = Parametros.Parametros.UsuarioSucursal.FirstOrDefault().USR_SUC_ID;
                    Parametros.Parametros.NombreSucActual = Parametros.Parametros.UsuarioSucursal.FirstOrDefault().Sucursales.SUC_DESCRIPCION;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta. Intente nuevamente", "Datos incorrectos", MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                txtClave.Text = "";
                txtClave.Focus();
                iCount++;
            }
            if (iCount > 2)
            {
                MessageBox.Show("Ha intentado acceder erróneamente 3 veces. Contacte al administrador del sistema",
                    "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }
       
        //

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            grbBotones.Location= new Point(grbBotones.Location.X, grbBotones.Location.Y -25); 
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtClave.Focus();
            }
        }

        private void cmbSucursal_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnAceptar.PerformClick();
        }        
    }
}
