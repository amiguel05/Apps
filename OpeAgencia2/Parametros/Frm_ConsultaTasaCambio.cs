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
using System.Data.SqlClient; 


namespace OpeAgencia2.Parametros
{
    public partial class Frm_ConsultaTasaCambio : Form
    {

        private SqlConnection con = new SqlConnection("Data Source=192.168.199.15;Initial Catalog=dbAgencia;User ID=usrAgencia;Password=Prueba12345;");

        
        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();
        private BO.Models.Clientes oCliente = new BO.Models.Clientes();
        

        public Frm_ConsultaTasaCambio()
        {
            InitializeComponent();
        }

        
        private void cargartasa()
        {
            con.Open() ;
            SqlDataAdapter datasa = new SqlDataAdapter("Select Tasa_codigo as Codigo ,TASA_DESCRIPCION as Moneda, Factor_conv as Tasa from  TASA_CAMBIO (nolock)", con); 
            
            DataSet dstasa = new DataSet();
            
            datasa.Fill(dstasa, "TASA_CAMBIO") ;

            dataGridView1.DataSource = dstasa;
            dataGridView1.DataMember = "TASA_CAMBIO"; 
            con.Close();


            
        }

        private void Frm_ConsultaTasaCambio_Load(object sender, EventArgs e)
        {

            ((Frm_ConsultaTasaCambio)(sender)).label28.Text = "Consulta de Tasa de Cambios";

          
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargartasa();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_ConsultaTasaCambio_Shown(object sender, EventArgs e)
        {
            button1.PerformClick();
            button1.Visible = false;
        }

       

       

     


    }
}
