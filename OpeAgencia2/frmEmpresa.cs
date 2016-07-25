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
    public partial class frmEmpresa : Form
    {
        public frmEmpresa()
        {
            InitializeComponent();
        }
        
        int _Id;

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
      
        private void usrbntMant1_Load(object sender, EventArgs e)
        {
              
        }

        private void frmEmpresa_Load(object sender, EventArgs e)
        {
            this.usrbntMant1.ButtonClickAdd += new EventHandler(btnAdd_Click);
            this.usrbntMant1.ButtonClickDel += new EventHandler(btnDel_Click);
            this.usrbntMant1.ButtonClickMod += new EventHandler(btnMod_Click);
            this.usrbntMant1.ButtonClickSalir += new EventHandler(btnSal_Click);
            this.usrbntMant1.ButtonClickSave += new EventHandler(btnSav_Click);
            this.usrbntMant1.ButtonClickUndo += new EventHandler(btnUn_Click);

            CargarDatosIniciales();

            ManejarEstado(false);

        }

        protected void CargarDatosIniciales()
        {
           

            
            var empresas  = unitOfWork.EmpresasRepository.Get();

            var empresasview  =  from p in empresas
                                 select new { Id= p.COM_CODIGO , Código=p.COM_DESCORTA, Nombre=p.COM_DESCRIPCION }; ;


            dg.DataSource = empresasview.ToList();   
                //sCompania.returnView(ref sMensaje);
            tabMant.SelectedIndex = 0;

        }

        #region "botones"
      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Agregando");
            tabMant.SelectedIndex = 1;
            textCom_Codigo.Text = "";
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

            if(SalvarDatos())
            { 
                usrbntMant1.bExito =true;
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


           int iId = -1;

           iId = Convert.ToInt32(textCom_Codigo.Text);
           var empresas = unitOfWork.EmpresasRepository.GetByID(iId);

            try
            {
                unitOfWork.EmpresasRepository.Delete(empresas);
                unitOfWork.Save();
                MessageBox.Show("Datos Actualizados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                usrbntMant1.bExito = true;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }



        }

        bool SalvarDatos()
        {
            bool bRetorno = false;
            int iId = -1;

            //CompaniasRecord oCom = new CompaniasRecord();


            BO.Models.Empresas oCom;




            if (usrbntMant1.bAdiciona == false)
            {
                iId = Convert.ToInt32(textCom_Codigo.Text);
              oCom = unitOfWork.EmpresasRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.Empresas();
            }
            

            //oCom.COM_CODIGO = Convert.ToInt32(textCom_Codigo.Text);

            oCom.COM_DESCORTA = this.txtNombreCorto.Text.ToString();
            oCom.COM_DESCRIPCION = this.txtCOM_DESCRIPCION.Text.ToString();
            oCom.COM_RESPONSABLE = this.txtCOM_RESPONSABLE.Text.ToString().TrimEnd();
            oCom.COM_DIRECCION = this.txtCOM_DIRECCION.Text.ToString();
            oCom.COM_EMAIL = this.txtCOM_EMAIL.Text.ToString();
            oCom.COM_TELEFONO = this.txtCOM_TELEFONO.Text.ToString();
            oCom.COM_FAX = this.txtCOM_FAX.Text.ToString();
            oCom.COM_RNC = this.txtCOM_RNC.Text.ToString();


            try
            {
                if (usrbntMant1.bAdiciona == false)
                     unitOfWork.EmpresasRepository.Update(oCom);
                else
                    unitOfWork.EmpresasRepository.Insert(oCom);

                unitOfWork.Save();
                bRetorno = true;
                usrbntMant1.bExito = true;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    string s ="";
                  

                    foreach (var ve in eve.ValidationErrors)
                    {
                        s +=  ve.ErrorMessage +"\n";
                       
                    }
                    MessageBox.Show("Existen los siguientes errores:" + s,"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
                //throw;
            }
            catch (DataException  ex)
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
           

            var empresas = unitOfWork.EmpresasRepository.GetByID(Id);


            MoverDatos(empresas);

        }

        void MoverDatos(BO.Models.Empresas oEmp)
        {
            //else if(ctr.Tag == MyComp.COM_DESCRIPCION)
            foreach(Control ctr in  tabPage2.Controls)
            {
                if (ctr.Tag == null)
                    continue;

                
                switch (ctr.Tag.ToString())
                {
                    case "COM_CODIGO":
                        ctr.Text = oEmp.COM_CODIGO.ToString();
                        break;
                    case "COM_DESCRIPCION":
                        ctr.Text = oEmp.COM_DESCRIPCION.ToString();
                        break;
                    case "COM_DESCORTA":
                        ctr.Text = oEmp.COM_DESCORTA.ToString();
                        break;
                    case "COM_RNC":
                        if (oEmp.COM_RNC != null)
                            ctr.Text = oEmp.COM_RNC.ToString();
                        else
                            ctr.Text = "";
                        break;
                    case "COM_RESPONSABLE":
                        ctr.Text = oEmp.COM_RESPONSABLE.ToString();
                        break;
                    case "COM_DIRECCION":
                        ctr.Text = oEmp.COM_DIRECCION.ToString();
                        break;
                    case "COM_TELEFONO":
                        ctr.Text = oEmp.COM_TELEFONO.ToString();
                        break;
                    case "COM_FAX":
                        ctr.Text = oEmp.COM_FAX.ToString();
                        break;
                    case "COM_EMAIL":
                        ctr.Text = oEmp.COM_EMAIL.ToString();
                        break;
                    case "COM_ESTADO":
                        ctr.Text = oEmp.COM_ESTADO.ToString();
                        break;


                }
               

            }
        }

        void ManejarEstado(bool bEstado)
        {
            foreach (Control ctr in tabPage2.Controls)
            {
               if (ctr.GetType().Name =="TextBox")
               {
                   if (ctr.Name.Substring(0, 3) == "txt")
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
            }
        }

        private void tabMant_TabIndexChanged(object sender, EventArgs e)
        {

           
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
                catch
                {
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
