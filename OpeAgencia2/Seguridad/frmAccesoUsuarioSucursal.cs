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
    public partial class frmAccesoUsuarioSucursal : Form
    {
        public frmAccesoUsuarioSucursal()
        {
            InitializeComponent();
        }

        public frmAccesoUsuarioSucursal(int piUserId)
        {
            InitializeComponent();
            iUserId = piUserId;
        }

        int iUserId = -1;
        int iSucUsrId = -1;
        int iModId = -1;

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmAccesoUsuarioSucursal_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        #region "Combos"

        void CargarCombos()
        {
            ComboUsuarios();
            ComboModulos();

        }

        void ComboUsuarios()
        {
            var Qry = from p in unitOfWork.UsuariosRepository.Get()
                      select new { Id = p.USUARIO_ID, Nombre = p.NOMBRES + " " + p.APELLIDOS + "(" + p.USER_NAME + ")" };
            //
            this.cmbUsuario.ValueMember = "Id";
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.DataSource = Qry.ToList();
            cmbUsuario.SelectedValue = iUserId;
        }

        void ComboSucursales(int piUserId)
        {
            var Qry = from p in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == piUserId)
                      select new
                      {
                          Id = p.USR_SUC_ID,
                          Nombre = p.Sucursales.SUC_CODIGO + " " + p.Sucursales.SUC_DESCRIPCION + "(" +
                              p.Sucursales.Empresas.COM_DESCORTA + ")"
                      };
            this.cmbSucursal.ValueMember = "Id";
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.DataSource = Qry.ToList();
            cmbSucursal.SelectedValue = -1;
        }

        void ComboModulos()
        {
            var Qry = from p in unitOfWork.ModulosRepository.Get()
                      select new { Id = p.MOD_ID, Nombre = p.MOD_NOMBRE + "(" + p.Tipos.TIPO_DESCR + ")" }
                         ;


            //
            this.cmbModulo.ValueMember = "Id";
            cmbModulo.DisplayMember = "Nombre";
            //
            cmbModulo.DataSource = Qry.ToList();

            cmbModulo.SelectedValue = -1;
        }


        #endregion

        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int piUserId = Convert.ToInt32(cmbUsuario.SelectedValue);
            ComboSucursales(piUserId);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            iUserId = Convert.ToInt32(cmbUsuario.SelectedValue);
            iSucUsrId = Convert.ToInt32(this.cmbSucursal.SelectedValue);
            iModId = Convert.ToInt32(this.cmbModulo.SelectedValue);
            treeView1.Nodes.Clear();

            BuscarOpciones();
        }

        void BuscarOpciones()
        {



            int iModId = Convert.ToInt32(cmbModulo.SelectedValue);
            var MyQry = unitOfWork.OpcionesRepository.Get(filter: s => s.MOD_ID == iModId && s.OPC_PARENT_ID == 0);

            foreach (var item in MyQry)
            {
                TreeNode oNode = new TreeNode(item.OPC_NAME);
                oNode.Tag = item.OPC_ID.ToString();
                VerificaPermiso(oNode);

                AgregaHijos(oNode, item.OPC_ID);
                treeView1.Nodes.Add(oNode);
            }
        }

        void VerificaPermiso(TreeNode oNode)
        {
            int iOpcId = Convert.ToInt32(oNode.Tag);

            var MyQry = unitOfWork.UsuariosOpcionesRepository.Get(filter: s => s.OPC_ID == iOpcId && s.UsuariosModulos.MOD_ID == iModId && s.UsuariosModulos.UsuarioSucursal.USR_SUC_ID == iSucUsrId).FirstOrDefault();

            if (MyQry != null)
            {
                oNode.Checked = MyQry.ACTIVO;
            }



        }

        void AgregaHijos(TreeNode pNode, int piParentId)
        {

            var MyQry = unitOfWork.OpcionesRepository.Get(filter: s => s.OPC_PARENT_ID == piParentId);

            foreach (var item in MyQry)
            {
                TreeNode oNode = new TreeNode(item.OPC_NAME);
                oNode.Tag = item.OPC_ID.ToString();
                VerificaPermiso(oNode);
                AgregaHijos(oNode, item.OPC_ID);

                pNode.Nodes.Add(oNode);

            }


        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
            MessageBox.Show("Datos guardados con éxito", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        void GuardarDatos()
        {
            foreach (TreeNode oNode in treeView1.Nodes)
            {
                ProcesarNodo(oNode);
            }
        }

        void ProcesarNodo(TreeNode pNode)
        {
            int OpcId = Convert.ToInt32(pNode.Tag);

            var ModUsr = unitOfWork.UsuariosModulosRepository.Get(filter: s => s.USR_SUC_ID == iSucUsrId && s.MOD_ID == iModId).FirstOrDefault();

            GuardaUsuarioModulo(ref ModUsr);

            var UsrOpc = unitOfWork.UsuariosOpcionesRepository.Get(filter: s => s.USR_MOD_ID == ModUsr.USR_MOD_ID && s.OPC_ID == OpcId).FirstOrDefault();

            GuardaUsuarioOpciones(ref UsrOpc, ModUsr, OpcId, pNode.Checked);

            foreach (TreeNode oNode in pNode.Nodes)
            {
                ProcesarNodo(oNode);
            }


        }

        void GuardaUsuarioOpciones(ref BO.Models.UsuariosOpciones pUserOpc, BO.Models.UsuariosModulos pUserMod, int iOpcId, bool bActivo)
        {

            if (pUserOpc == null)
            {
                BO.Models.UsuariosOpciones oUserOpc = new BO.Models.UsuariosOpciones();

                oUserOpc.USR_MOD_ID = pUserMod.USR_MOD_ID;
                oUserOpc.OPC_ID = iOpcId;
                oUserOpc.ACTIVO = bActivo;

                unitOfWork.UsuariosOpcionesRepository.Insert(oUserOpc);


                pUserOpc = oUserOpc;

            }
            else
            {
                pUserOpc.ACTIVO = bActivo;
                unitOfWork.UsuariosOpcionesRepository.Update(pUserOpc);

            }

            try
            {
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error:" + ex.Message.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }


        }

        void GuardaUsuarioModulo(ref BO.Models.UsuariosModulos pUserMod)
        {

            if (pUserMod == null)
            {
                BO.Models.UsuariosModulos oUsrMod = new BO.Models.UsuariosModulos();

                oUsrMod.USR_SUC_ID = iSucUsrId;
                oUsrMod.MOD_ID = iModId;
                oUsrMod.ACTIVO = true;

                unitOfWork.UsuariosModulosRepository.Insert(oUsrMod);

                try
                {
                    unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error:" + ex.Message.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }

                pUserMod = oUsrMod;
            }


        }

        void VerificaParentCheck(TreeNode oNode)
        {
            if (oNode.Level > 0)
            {
                if (oNode.Parent != null)
                {
                    if (oNode.Parent.Checked == false)
                    {
                        oNode.Parent.Checked = oNode.Checked;
                        VerificaParentCheck(oNode.Parent);
                    }
                }
            }
        }

        void VerificaHijosCheck(TreeNode pNode)
        {

            if (pNode.Nodes.Count > 0)
            {
                foreach (TreeNode oNode in pNode.Nodes)
                {
                    oNode.Checked = pNode.Checked;
                    VerificaHijosCheck(oNode);
                }
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckAllChildNodes(e.Node, e.Node.Checked);
            if (e.Node.Checked)
            {
                VerificaParentCheck(e.Node);
                //VerificaHijosCheck(e.Node);
            }
        }





    }
}
