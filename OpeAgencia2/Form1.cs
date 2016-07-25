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


namespace OpeAgencia2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        int iModId = 1;

        public bool IndicadorCerrar {
            set
            {
                timerClose.Enabled = true;
            }
            get
            {
                return timerClose.Enabled;
            }
        
        }
        
        MenuStrip oMenu = new MenuStrip();
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
       // public  Parametros.ParametrosSucursal oParamSuc;

        ICollection<BO.Models.Opciones> mOpciones;
        ICollection<BO.Models.VW.vw_usuario_opciones> mUsuariosOpciones;

        private void Form1_Load(object sender, EventArgs e)
        {
           // oParamSuc = new Parametros.ParametrosSucursal();
            // oParamSuc.IdSucursal = 5;
            Seguridad.frmLogin x = new Seguridad.frmLogin();
            x.ShowDialog();

            if (x.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                FormClosing -= Form1_FormClosing;
                this.Close();
            }
            else
            {

                if (Parametros.Parametros.SucursalActual == 0)
                {
                    Parametros.Parametros.SucursalActual = unitOfWork.UsuarioSucursalRepository.GetByID(Parametros.Parametros.UsuarioSucursalActual).SUC_ID;
                }

                Parametros.ParametrosSucursal.IdSucursal = Parametros.Parametros.SucursalActual;
                
                InicializaParametros();

                CargarOpciones();

                OrganizaMenu();
                //dataGridView1.DataSource = oCom.CompaniaList();

                if (menuStrip1.Items.Count == 0)
                {
                    MessageBox.Show("No tiene privilegios asignados, para utilizar la aplicación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();

                }

                lblUsuario.Text = Parametros.Parametros.UserName;
                lblSucursal.Text = Parametros.Parametros.NombreSucActual;

                BuscaTerminalFiscal();


                ActivatoolStrip1();
            }
        }


        void ActivatoolStrip1()
        {

            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                if (toolStrip1.Items[i].Tag == null)
                    continue;

                string sTag = toolStrip1.Items[i].Tag.ToString() ;

                var eTag = mUsuariosOpciones
                           .Where(p => p.OPC_FORM != null && p.OPC_FORM.Contains(sTag))
                           .FirstOrDefault();
                          
                           

                          
                if (eTag !=  null )
                {
                    toolStrip1.Items[i].Enabled = true;
                }
                else
                    toolStrip1.Items[i].Enabled = false;

            }

          

            foreach(ToolStripDropDownItem oItem in toolStripSplitButton1.DropDownItems)
            {
                ActivaSubcontros(oItem);
            }
             foreach(ToolStripDropDownItem oItem in toolStripSplitButton2.DropDownItems)
            {
                ActivaSubcontros(oItem);
            }
           


        }

        void ActivaSubcontros(ToolStripDropDownItem oItem)
        {
            if (oItem.Tag ==null)
                return;
            string sTag = oItem.Tag.ToString();
            var eTag = mUsuariosOpciones
                       .Where(p => p.OPC_FORM != null && p.OPC_FORM.Contains(sTag))
                       .FirstOrDefault();
            if (eTag != null)
            {
                oItem.Enabled = true;
            }
            else
                oItem.Enabled = false;
        }

        void CargarOpciones()
        {
            int iUserId, iSucId;
            iUserId = Parametros.Parametros.UsuarioId;
            iSucId = Parametros.Parametros.SucursalActual;
            //  mOpciones = unitOfWork.OpcionesRepository.Get().ToList();
            //  mUsuariosOpciones = unitOfWork.vwUsuarioOpcionesRepository.Get(xy => xy.USUARIO_ID == iUserId).ToList();
            mUsuariosOpciones = unitOfWork.vwUsuarioOpcionesRepository.Get(xy => xy.USUARIO_ID == iUserId && xy.SUC_ID == iSucId).ToList();
            //var mOpcionesRoles = unitOfWork.UsuariosRolesRepository.Get(xy => xy.USR_ROLE_ID == iUserId && xy.USR_SUC_ID == iSucId).ToList();
            //foreach (var rol in mOpcionesRoles)
            //{
            //    foreach (var opcion in unitOfWork.RolesOpcionesRepository.GetByID(rol.ROL_ID))
            //    {
                    
            //    }
            //}
            /*
               var MyQry = from s in mUsuariosOpciones
                        where s.OPC_ID == piOpcId && s.UsuariosModulos.MOD_ID == iModId && s.UsuariosModulos.UsuarioSucursal.USR_SUC_ID == iSucUsrId
                        select new { s.OPC_ID, s.ACTIVO };
            */
        }

        void BuscaTerminalFiscal()
        {
            string sSerial = clsUtils.Utils.ObtenerSerialTerminal();
            BO.Models.Terminal oTerminal = new BO.Models.Terminal();
            var oRetorno = unitOfWork.TerminalRepository.Get(xy => xy.SERIAL == sSerial && xy.SUC_ID == Parametros.Parametros.SucursalActual).FirstOrDefault();
            if (oRetorno !=null)
            {
                Parametros.ParametrosSucursal.PuertoFiscal =oRetorno.PUERTO;
                Parametros.ParametrosSucursal.TermFiscalId = oRetorno.TERM_ID;
            }
            else
            {
                Parametros.ParametrosSucursal.PuertoFiscal = "NA";
                Parametros.ParametrosSucursal.TermFiscalId = -1;
            } 
        }

        void InicializaParametros()
        {
            var sQry = unitOfWork.ProductosRepository.Get(filter: s => s.PRO_CODIGO == "017").FirstOrDefault();
            Parametros.Parametros.ProdCorrespondencia = sQry.PROD_ID;
            Parametros.Parametros.NomProdCorrespondencia = sQry.PRO_DESCRIPCION + "(" + sQry.PRO_CODIGO + ")";
            Parametros.ParametrosSucursal.BuscarEncabezado();
        }

        void OrganizaMenu()
        {
            /*
            var Opciones = from p in unitOfWork.OpcionesRepository.Get(filter: q => q.OPC_PARENT_ID == 0)
                           orderby p.OPC_ORDER
                           select new { p.OPC_NAME, p.OPC_FORM, p.OPC_ID };
             * */
            var Opciones = from p in mUsuariosOpciones
                           where p.OPC_PARENT_ID == 0
                           orderby p.OPC_ORDER
                           select new { p.OPC_NAME, p.OPC_FORM, p.OPC_ID };                          
            foreach (var opc in Opciones)
            {
                /*if (VerificaPermiso(opc.OPC_ID))
                {*/

                    ToolStripMenuItem oItem = new ToolStripMenuItem();
                    oItem.ShowShortcutKeys = true;
                    oItem.Text = opc.OPC_NAME;
                    oItem.Tag = opc.OPC_FORM;

                    AddMenuItem(opc.OPC_ID, ref oItem);

                    menuStrip1.Items.Add(oItem);
                /*}*/
            }
            

        }

        bool VerificaPermiso(int piOpcId)
        {
            //int iOpcId = Convert.ToInt32(oNode.Tag);
            bool bRetorno = false;
            int iSucUsrId = Parametros.Parametros.UsuarioSucursalActual;


            //var MyQry = unitOfWork.UsuariosOpcionesRepository.Get(filter: s => s.OPC_ID == piOpcId && s.UsuariosModulos.MOD_ID == iModId && s.UsuariosModulos.UsuarioSucursal.USR_SUC_ID == iSucUsrId).FirstOrDefault();
/*
            var MyQry = from s in mUsuariosOpciones
                        where s.OPC_ID == piOpcId && s.UsuariosModulos.MOD_ID == iModId && s.UsuariosModulos.UsuarioSucursal.USR_SUC_ID == iSucUsrId
                        select new { s.OPC_ID, s.ACTIVO };
                       
            
            if (MyQry != null)
            {
                if (MyQry.ToList().Count > 0)
                    bRetorno = MyQry.FirstOrDefault().ACTIVO;
            }
       

            */
            return bRetorno;

        }


        bool  VerificaPermisoRole(int iRoleId, int iOpcId)
        {
            bool bRetorno = false;
          
            var MyQry = unitOfWork.RolesOpcionesRepository.Get(filter: s => s.OPC_ID == iOpcId && s.ROL_ID == iRoleId).FirstOrDefault();

            if (MyQry != null)
            {
                bRetorno = MyQry.ACTIVO;
            }

            return bRetorno;

        }



        void AddMenuItem(int OpcId, ref ToolStripMenuItem oItem)
        {
            /*
            var Opciones = from p in unitOfWork.OpcionesRepository.Get(filter: q => q.OPC_PARENT_ID == OpcId)
                           orderby p.OPC_ORDER
                           select new {p.OPC_ID, p.OPC_FORM, p.OPC_NAME};
            


            var Opciones = from p in mOpciones
                           where (p.OPC_PARENT_ID==OpcId)
                           orderby p.OPC_ORDER
                           select new { p.OPC_ID, p.OPC_FORM, p.OPC_NAME };
             */ 


            var Opciones = from p in mUsuariosOpciones
                           where (p.OPC_PARENT_ID == OpcId)
                           orderby p.OPC_ORDER
                           select new { p.OPC_ID, p.OPC_FORM, p.OPC_NAME };



            foreach (var opc in Opciones)
            {
                /*if (VerificaPermiso(opc.OPC_ID))
                {*/
                    ToolStripMenuItem oItem2 = new ToolStripMenuItem(opc.OPC_NAME);
                    oItem2.Tag = opc.OPC_FORM;
                    if (oItem2.Tag != null)
                        oItem2.Click += new EventHandler(dosToolStripMenuItem_Click);

                    AddMenuItem(opc.OPC_ID, ref oItem2);

                    oItem.DropDownItems.Add(oItem2);
                /*}*/
            }


        }


        private void companiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpresa x = new frmEmpresa();
            x.MdiParent = this;
            x.Show();
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOpciones x = new frmOpciones();
            x.MdiParent = this;
            x.Show();

        }

        private void dosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (((ToolStripMenuItem)sender).Tag.ToString() !="")
            {
                //MessageBox.Show(((ToolStripMenuItem)sender).Tag.ToString());
                string sForm = ((ToolStripMenuItem)sender).Tag.ToString();

                MostrarForm(sForm);

            }


        }


        Dictionary<string, Form> Ins = new Dictionary<string, Form>();
        public void MostrarForm(string NombreFormulario)
        {
            try
            {

                Form x;

                if (NombreFormulario == "Frm_ConsultaTasaCambio") 
                   
                {
                    x = (Form)Activator.CreateInstance(null, "OpeAgencia2.Parametros." + NombreFormulario).Unwrap();
                    Ins[NombreFormulario] = x;
                }

                if (!Ins.TryGetValue(NombreFormulario, out x) || x.IsDisposed) 
                {
                    x = (Form)Activator.CreateInstance(null, "OpeAgencia2." + NombreFormulario).Unwrap();
                    Ins[NombreFormulario] = x;

                }
                bool escargado = false;

                foreach (Form frmllamado in this.MdiChildren)
                {
                    if (frmllamado.Text == x.Text)
                        escargado = true;

                }
                if (escargado == false)
                {
                    //Carga el formulario si no esta llamado
                    x.MdiParent = this;
                    x.Show();
                }
                else
                {
                    x.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error llamando formulario\n" + ex.Message.ToString());
            }


        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes.frmConsultaClientes x = new Clientes.frmConsultaClientes();
            x.MdiParent = this;
            x.Show();

            

        }

        private void btnConsultaPaquetes_Click(object sender, EventArgs e)
        {
            Clientes.frmConsultaMercancia x = new Clientes.frmConsultaMercancia();
            x.MdiParent = this;
            x.Show();
        }

        private void paquetesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facturacion.frmFactMercancia x = new Facturacion.frmFactMercancia();
            x.MdiParent = this;
            x.Show();
        }

        private void enviosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facturacion.frmFactEnvios x = new Facturacion.frmFactEnvios();
            x.MdiParent = this;
            x.Show();
        }

        private void movimientosDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facturacion.frmMovCaja x = new Facturacion.frmMovCaja();
            x.MdiParent = this;
            x.Show();
        }

        private void listadoDeTransaccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facturacion.ConsultaOperaciones x = new Facturacion.ConsultaOperaciones();
            x.MdiParent = this;
            x.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("¿Está seguro de que desea salir del sistema?", "Salir del sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void consultaDeTasaDeCambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parametros.Frm_ConsultaTasaCambio x = new Parametros.Frm_ConsultaTasaCambio();
            x.MdiParent = this;
            x.Show();
           

        }
    }
}
