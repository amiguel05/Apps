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
    public partial class frmAccesoRoles : Form
    {
        public frmAccesoRoles()
        {
            InitializeComponent();
        }

        public frmAccesoRoles(int piRoleId, int piModId)
        {
            InitializeComponent();

            iRoleId = piRoleId;
            iModId = piModId;

        }


        int iRoleId = -1;
        int iModId = -1;

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void frmAccesoRoles_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }



        #region "Combos"

        void CargarCombos()
        {
            ComboRoles();
            ComboModulos();

        }

        void ComboRoles()
        {
            var Qry = from p in unitOfWork.RolesRepository.Get()
                      select new { Id = p.ROL_ID, Nombre = p.NOMBRE  }
                         ;


            //
            this.cmbRole.ValueMember = "Id";
            cmbRole.DisplayMember = "Nombre";
            //
            cmbRole.DataSource = Qry.ToList();

            cmbRole.SelectedValue = iRoleId;
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

            cmbModulo.SelectedValue = iModId;
        }


        #endregion

       
        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
            treeView1.Nodes.Clear();

            BuscarOpciones();
        }

        void BuscarOpciones()
        {


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
            var MyQry = unitOfWork.RolesOpcionesRepository.Get(filter: s => s.OPC_ID == iOpcId && s.ROL_ID == iRoleId).FirstOrDefault();

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

        
        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            GuardarDatos();

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

            var UsrOpc = unitOfWork.RolesOpcionesRepository.Get(filter: s => s.ROL_ID == iRoleId && s.OPC_ID == OpcId).FirstOrDefault();

            GuardaUsuarioOpciones(ref UsrOpc, OpcId, pNode.Checked);

            foreach (TreeNode oNode in pNode.Nodes)
            {

                ProcesarNodo(oNode);
            }


        }

        void GuardaUsuarioOpciones(ref BO.Models.RolesOpciones pUserOpc, int iOpcId, bool bActivo)
        {

            if (pUserOpc == null)
            {
                BO.Models.RolesOpciones oUserOpc = new BO.Models.RolesOpciones();

                oUserOpc.ROL_ID = iRoleId;
                oUserOpc.OPC_ID = iOpcId;
                oUserOpc.ACTIVO = bActivo;

                unitOfWork.RolesOpcionesRepository.Insert(oUserOpc);


                pUserOpc = oUserOpc;

            }
            else
            {
                pUserOpc.ACTIVO = bActivo;
                unitOfWork.RolesOpcionesRepository.Update(pUserOpc);

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

       
        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        void VerificaParentCheck(TreeNode oNode)
        {

            if (oNode.Level > 0)
            {
                if (oNode.Parent != null)
                {
                    if (oNode.Parent.Checked == false)
                    {
                        oNode.Parent.Checked = true;
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

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Checked)
            {
                VerificaParentCheck(e.Node);
                //VerificaHijosCheck(e.Node);
            }
        }

     
           
    }
}
