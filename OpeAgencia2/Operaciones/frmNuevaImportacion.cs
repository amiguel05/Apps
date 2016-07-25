using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using BO = AgenciaEF_BO;
using System.Linq;


namespace OpeAgencia2.Operaciones
{
    public partial class frmNuevaImportacion : Form
    {
        public frmNuevaImportacion()
        {
            InitializeComponent();
        }

        int iTotal = 0;

        DataSet ds;
        string CodigoAgencia;
        wsAgencias.wsAgenciasSoapClient oAgencias;
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        StringBuilder sErrores = new StringBuilder();

        private void frmNuevaImportacion_Load(object sender, EventArgs e)
        {
            oAgencias = new wsAgencias.wsAgenciasSoapClient();
            oAgencias.InnerChannel.OperationTimeout = System.TimeSpan.FromSeconds(20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CodigoAgencia = Parametros.ParametrosSucursal.CodigoSucursal;
            //((Form1) this.ParentForm).oParamSuc.CodigoSucursal;
            BuscarFacturas();
        }

        void BuscarFacturas()
        {

            string sFecha;
            //Dim ds As New DataSet
            DataSet ds = new DataSet();

            //Dim oAgencias As New wsAgencias.wsAgencias


            //=  new  wsAgencias.wsAgenciasSoap();


            lblMensaje.Visible = true;
            lblMensaje.Text = "[Estableciendo comunicacion con Servidor.]";
            try
            {
                sFecha = DateTimePicker1.Value.Month.ToString().PadLeft(2, '0') + "/" +
                                            DateTimePicker1.Value.Day.ToString().PadLeft(2, '0') + "/" +
                                            DateTimePicker1.Value.Year.ToString();
                ds = oAgencias.FacturasAgencias(CodigoAgencia, sFecha);
                dgFacturas.DataSource = ds.Tables["Facturas"];
                lblMensaje.Text = "[Buscando Facturas]";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "[Error.....]";
                MessageBox.Show("No se puedo hacer conexión con el Servidor " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            lblMensaje.Visible = false;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            IEnumerable<BO.Models.ImportacionAgencia> oImpAgencia;

            // ImportarBultos();
            if (MessageBox.Show("¿Seguro que quiere importar datos a su base de datos local?", "Aviso", 
                MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            try
            {
                string DocCodigo = dgFacturas.Rows[dgFacturas.CurrentRow.Index].Cells[0].Value.ToString();
                string FacCodigo = dgFacturas.Rows[dgFacturas.CurrentRow.Index].Cells[1].Value.ToString();            
                AgenciaEF_BO.DAL.ADO.BultosDal Bultos = new BO.DAL.ADO.BultosDal();
                //EXEC [SP_MFR2_IMPORTA_MANIFIESTO] 'FT01','20898323',4,'656565',4,1
                oImpAgencia = Bultos.ImportarBultos(DocCodigo, FacCodigo, Parametros.ParametrosSucursal.CodigoAlmacen,
                    Parametros.ParametrosSucursal.Ubicacion, 
                    Parametros.ParametrosSucursal.IdSucursal,
                    Parametros.Parametros.UsuarioId);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en proceso... " + ex.Message.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (oImpAgencia != null)
            {
                var oSeleccion = from p in oImpAgencia
                                 from q in unitOfWork.BultosRepository.Get(filter: xy => xy.BLT_CODIGO_BARRA == p.BLT_CODIGO_BARRA)
                                 from r in unitOfWork.ClientesRepository.Get(filter: yz => yz.CTE_ID == q.CTE_ID)
                                 select new { CodigoBarras = p.BLT_CODIGO_BARRA, Importado = p.IMPORTADO, Mensaje = p.MENSAJE, EPC = r.CTE_NUMERO_EPS , p.BLT_NUMERO};
                dg.DataSource = oSeleccion.ToList();

                foreach(var r in oSeleccion)
                {
                    //Hay que actulizar el itebis, en sql server el rendondeo es difernte
                    var oEquiBulto = unitOfWork.EquivalenciaBultosRepository.Get(filter: xy => xy.BLT_NUMERO_SDQ == r.BLT_NUMERO).FirstOrDefault();

                    BO.BO.Facturar oFact = new BO.BO.Facturar();
                    oFact.ActualizarItbis(oEquiBulto.BLT_NUMERO_LOCAL);
                   
                }

            }
            else
                dg.DataSource = null;


            MessageBox.Show("Proceso ejecutado satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
