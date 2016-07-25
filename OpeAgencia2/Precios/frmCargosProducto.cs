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
    public partial class frmCargosProducto : Form
    {
        public frmCargosProducto()
        {
            InitializeComponent();
        }

        public frmCargosProducto(int ProductoId , int CargoProductoId)
        {
            InitializeComponent();
            iId = CargoProductoId;
            iProductoId = ProductoId;

        }

        int iId = -1;
        int iProductoId = -1;

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();


        private void frmCargosProducto_Load(object sender, EventArgs e)
        {

            CargarCombos();
            
            try
            {             
                if (iId != -1)
                ConsultarDatos();
                }
            catch
            {

            }


        }

        void ConsultarDatos()
        {

            var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iId);

            TextId.Text = iId.ToString();

            cmbTasa.SelectedValue = cargosProd.TASA_ID;
            
            chkFijo.Checked = cargosProd.FIJO;

            cmbCargo.SelectedValue = cargosProd.CARGO_ID;


        }

        #region "Combos"
        
        void CargarCombos()
        {
            ComboProductos();
            ComboTasas();
            ComboCargos();

        }

        void ComboProductos()
        {
            var sup = from p in unitOfWork.ProductosRepository.Get()
                      select new { Id = p.PROD_ID, Nombre = p.PRO_CODIGO + "-->" + p.PRO_DESCRIPCION }
                        ;


            //
            this.cmbProducto.ValueMember = "Id";
            cmbProducto.DisplayMember = "Nombre";
            //
            cmbProducto.DataSource = sup.ToList();

            cmbProducto.SelectedValue = iProductoId;
        }

        void ComboTasas()
        {
             var sup = from p in unitOfWork.TasaCambioRepository.Get()
                      select new { Id = p.TASA_ID, Nombre = p.TASA_CODIGO + "-->" + p.TASA_DESCRIPCION }
                        ;


            //
            this.cmbTasa.ValueMember = "Id";
            cmbTasa.DisplayMember = "Nombre";
            //
            cmbTasa.DataSource = sup.ToList();

            cmbTasa.SelectedValue = -1;
        }

        void ComboCargos()
        {
            var Cargos = from p in unitOfWork.CargosRepository.Get()
                      select new { Id = p.CARGO_ID, Nombre = p.CAR_CODIGO + "-->" + p.CAR_DESCRIPCION }
                       ;

            var cargosExits = from p in unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProductoId)
                              select new { Id = p.CARGO_ID, Nombre = p.Cargos.CAR_CODIGO + "-->" + p.Cargos.CAR_DESCRIPCION };

            var filteredList = Cargos.Except(cargosExits);

            //
            this.cmbCargo.ValueMember = "Id";
            cmbCargo.DisplayMember = "Nombre";
            //
            if (iId == -1)
                cmbCargo.DataSource = filteredList.ToList();
            else
                cmbCargo.DataSource = Cargos.ToList();



            cmbCargo.SelectedValue = -1;
        }


        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
            this.Close();
        }


        void Salvar()
        {
          
         
            //CompaniasRecord oCom = new CompaniasRecord();


            BO.Models.CargosProducto oCom;


            if (iId  > 0)
            {
               
                oCom = unitOfWork.CargosProductoRepository.GetByID(iId);
            }
            else
            {
                oCom = new BO.Models.CargosProducto();
            }


            oCom.PROD_ID = Convert.ToInt32(cmbProducto.SelectedValue);
            oCom.TASA_ID = Convert.ToInt32(this.cmbTasa.SelectedValue);
            oCom.CARGO_ID = Convert.ToInt32(this.cmbCargo.SelectedValue);
            oCom.FIJO = chkFijo.Checked;
       
            //oCom.CARGO_ID = textCargoId.Text;

            try
            {
                if (iId > 0 )
                    unitOfWork.CargosProductoRepository.Update(oCom);
                else
                    unitOfWork.CargosProductoRepository.Insert(oCom);

                unitOfWork.Save();

               

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


         
        }

    }
}
