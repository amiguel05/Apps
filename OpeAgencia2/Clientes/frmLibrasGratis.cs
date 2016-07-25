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


namespace OpeAgencia2.Clientes
{
    public partial class frmLibrasGratis : Form
    {
        public frmLibrasGratis()
        {
            InitializeComponent();
        }

        int liCteId;
        string lsCteNombre;
        string lsEPS;


        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ConsultarDatos();
            
        }

        void ConsultarDatos()
        {

            DateTime dFecha = DateTime.Now.AddMonths(-2);

            if (this.txtEPS.Text != "")
            {

                var oCliente = from p in unitOfWork.ClientesRepository.Get(filter: s => s.CTE_NUMERO_EPS == txtEPS.Text)
                               join j in unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.USUARIO_ID == Parametros.Parametros.UsuarioId) on p.CTE_SUC_ID equals j.SUC_ID
                               select new { Id = p.CTE_ID, Nombres = p.CTE_NOMBRE, Apellidos = p.CTE_APELLIDO };


                if (oCliente != null)
                {
                    liCteId = oCliente.FirstOrDefault().Id;
                    lsEPS = txtEPS.Text;
                    lsCteNombre = oCliente.FirstOrDefault().Nombres + " " + oCliente.FirstOrDefault().Apellidos;


                    var oRegistro = from p in unitOfWork.LibrasGratisRepository.Get(filter: s => s.CTE_ID == liCteId)
                                    select new { Id = p.CTE_ID, Nombres = p.Clientes.CTE_NOMBRE, Apellidos = p.Clientes.CTE_APELLIDO, LibrasGratis=p.LIBRAS_GRATIS, LibrasAcumuladas=p.LIBRAS_GRATIS_ACUMULADAS, FechaAsignacion=p.FECHA_ULT_ASIGNACION };


                    var oRegistrodet = from p in unitOfWork.RegistroLibrasGratisRepository.Get(filter: s => s.CTE_ID == liCteId && s.FECHA >= dFecha)
                                      orderby(p.FECHA)
                                      select new { Fecha = p.FECHA, Libras = p.LIBRAS_GRATIS, Usuario = p.Usuarios.USER_NAME, Producto = p.Productos.PRO_DESCRIPCION };

                    dgLibrasAsignadas.DataSource = oRegistrodet.ToList();

                    dgLibrasGratis.DataSource = oRegistro.ToList();

                    btnAgregarLibras.Enabled = true;
                }
                else
                {
                    btnAgregarLibras.Enabled = false;

                }

            }

        }

        private void btnAgregarLibras_Click(object sender, EventArgs e)
        {
            frmAgregarLibrasGratis x = new frmAgregarLibrasGratis(liCteId, lsCteNombre, txtEPS.Text);
            x.ShowDialog();
            ConsultarDatos();


        }
    }
}
