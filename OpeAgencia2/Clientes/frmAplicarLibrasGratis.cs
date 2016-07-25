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
    public partial class frmAplicarLibrasGratis : Form
    {
        public frmAplicarLibrasGratis()
        {
            InitializeComponent();
        }

        private BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();

        int liCteId = -1;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarLibrasDisponibles();
        }



        void BuscarLibrasDisponibles()
        {
             BO.DAL.dsDatos.EntregaPaq2DataTable oData = new BO.DAL.dsDatos.EntregaPaq2DataTable();
            DataTable dt = new DataTable();


            var oLibrasGratis = unitOfWork.LibrasGratisRepository.Get(filter: xy => xy.Clientes.CTE_NUMERO_EPS == txtEPS.Text.TrimEnd().ToUpper());

            liCteId = oLibrasGratis.FirstOrDefault().CTE_ID;

            this.txtLibrasGratis.Text = oLibrasGratis.FirstOrDefault().LIBRAS_GRATIS.ToString();
            this.txtSelec.Text = this.txtLibrasGratis.Text;

            var oEmpresa = unitOfWork.SucursalesRepository.Get(xy => xy.SUC_ID == Parametros.Parametros.SucursalActual).FirstOrDefault();

            var oBultos = from p in unitOfWork.BultosRepository.GetByNumeroEPS(txtEPS.Text, "", "", "", 0, oEmpresa.Empresas.COM_CODIGO)
                          select new
                          {
                              p.BLT_NUMERO,
                              p.Clientes.CTE_NUMERO_EPS,
                              p.MAN_GUIA,
                              p.BLT_CODIGO_BARRA,
                              p.BLT_TRACKING_NUMBER,
                              p.Productos.PRO_CODIGO,
                              p.BLT_PESO,
                              p.BLT_PIEZAS,
                              p.REMITENTE,
                              p.DESTINATARIO,
                              p.BLT_ESTADO_ID,
                              Recibido = p.BLT_FECHA_RECEPCION,
                              Entregado = p.BLT_FECHA_ENTREGADO,
                              p.CONTENIDO
                          };

                 

            foreach (var dr in oBultos)
            {

                // myPaq.Monto = Math.Round(Convert.ToDecimal(dr["MONTO"]), 2);
                // myPaq.TrackingNumber = dr["TRAKIN"].ToString();
                //myPaq.Contenido = dr["COB_CONTENIDO"].ToString();
                //myPaq.Peso = Convert.ToDouble(dr["PESO"].ToString());

                DataRow dr2 = oData.NewRow();
                dr2["BLT_NUMERO"] = dr.BLT_NUMERO;
                dr2["CODIGO_BARRA"] =dr.BLT_CODIGO_BARRA;
                dr2["CONTENIDO"] = dr.CONTENIDO;
                dr2["PESO"] =dr.BLT_PESO;
                dr2["VALOR"] = 0;
                dr2["LIBRAS_GRATIS"] = 0;
                oData.Rows.Add(dr2);

            }

            dg.DataSource = oData;


            dg.EditMode = DataGridViewEditMode.EditOnEnter;



        }

        private void dg_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dg.Rows[dg.CurrentCell.RowIndex].Cells[5].Value.ToString() == "")
                dg.Rows[dg.CurrentCell.RowIndex].Cells[5].Value = 0;

            if (e.ColumnIndex == 5)
            {
                dg.EndEdit();



                try
                {
                    DataGridViewTextBoxCell cell = dg.Rows[dg.CurrentCell.RowIndex].Cells[5] as DataGridViewTextBoxCell;
                    int dValor = Convert.ToInt32(cell.Value);



                    decimal liLibrasGratis = Convert.ToDecimal(txtLibrasGratis.Text);

                    for (int i = 0; i < dg.RowCount; i++)
                    {
                        if (dg.Rows[i].Cells[5].Value.ToString() == "")
                            dg.Rows[i].Cells[5].Value = 0;

                        if (liLibrasGratis - Convert.ToDecimal(dg.Rows[i].Cells[5].Value.ToString()) >= 0)
                        {
                            liLibrasGratis = liLibrasGratis - Convert.ToDecimal(dg.Rows[i].Cells[5].Value.ToString());
                            txtSelec.Text = liLibrasGratis.ToString();
                        }
                        else
                            dg.Rows[dg.CurrentCell.RowIndex].Cells[5].Value = 0;
                    }


                }
                catch (Exception ex)
                {
                    dg.Rows[dg.CurrentCell.RowIndex].Cells[5].Value = 0;

                }


            }
        }

        private void dg_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            AplicarLibras();
        }


        bool AplicarLibras()
        {

            foreach(var dr in dg.Rows)
            {
              int bltNumero =   Convert.ToInt32( ((System.Windows.Forms.DataGridViewRow)(dr)).Cells[0].Value);   //blt_numero
              decimal bltPeso = Convert.ToDecimal(((System.Windows.Forms.DataGridViewRow)(dr)).Cells[3].Value) ; //blt_peso

             string bltCodigobarra = ((System.Windows.Forms.DataGridViewRow)(dr)).Cells[1].Value.ToString();  //codigo de barra

             int bltLibrasGratis = Convert.ToInt32(((System.Windows.Forms.DataGridViewRow)(dr)).Cells[5].Value);  //Libras a aplicar

             if (bltPeso < 1)
                 bltPeso = 1;

             if (bltLibrasGratis > 0 && bltLibrasGratis<= bltPeso)
             {
                 string sMensaje=""; 
                 BO.BO.CalculoTafiras oFact = new BO.BO.CalculoTafiras();

                 if (oFact.AplicarLibrasGratis(bltNumero, bltLibrasGratis,liCteId, Parametros.Parametros.UsuarioId,  ref sMensaje) == false)
                 {
                     MessageBox.Show("Error aplicando libras \n" + sMensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     break;
                 };

             }

                
            }


            return false;
        }
    }
}
