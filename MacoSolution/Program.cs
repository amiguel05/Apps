using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.DAL;
using AgenciaEF_BO.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MacoSolution
{
    class Program
    {
        static void Main(string[] args)
        {
         

            DiferenciaMontoFact();

            //CorrigeMontoGravado();
            //CorrigeMontoGravadoAnul();

            
            //Console.Read();
        }

        /*
         * SELECT  A.RECIBO_ID RECIBO_ANUL, B.RECIBO_ID , 
       A.IMPORTE_TOTAL  IMPORTE_TOTAL_ANUL, A.IMPORTE_ITEBIS IMPORTE_ITEBIS_ANUL, A.IMPORTE_GRAVADO IMPORTE_GRAVADO_ANUL,
       B.IMPORTE_TOTAL  IMPORTE_TOTAL, B.IMPORTE_ITEBIS , B.IMPORTE_GRAVADO 
        FROM RECIBOS A, RECIBOS B
 WHERE A.TIPO_REC_ID = 5
 AND B.RECIBO_ID = A.RECIBO_ID_ANUL
 AND A.IMPORTE_GRAVADO <> B.IMPORTE_GRAVADO*/

        private static void CorrigeMontoGravadoAnul()
        {
            UnitOfWork unitOfWork = new UnitOfWork();


            string sSql = "SELECT  A.RECIBO_ID RECIBO_ANUL, B.RECIBO_ID, " +
                           "  A.IMPORTE_TOTAL  IMPORTE_TOTAL_ANUL, A.IMPORTE_ITEBIS IMPORTE_ITEBIS_ANUL, A.IMPORTE_GRAVADO IMPORTE_GRAVADO_ANUL, " +
                          " B.IMPORTE_TOTAL  IMPORTE_TOTAL, B.IMPORTE_ITEBIS , B.IMPORTE_GRAVADO " +
                          "  FROM RECIBOS A, RECIBOS B " +
                          "WHERE A.TIPO_REC_ID = 5 " +
                          "AND B.RECIBO_ID = A.RECIBO_ID_ANUL " +
                          "  AND A.IMPORTE_GRAVADO <> B.IMPORTE_GRAVADO ";

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(sSql, ConfigurationManager.ConnectionStrings["dbepsContext"].ToString());

            da.Fill(dt);


            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {


                i++;
                int iReciboId = 0;

                Console.WriteLine("{0}\t recibo {1} \t ImporteFact {2} \tImporteDet {3}  \n", i, dr["RECIBO_ANUL"].ToString(), dr["IMPORTE_GRAVADO_ANUL"].ToString(), dr["IMPORTE_GRAVADO"].ToString());

                iReciboId = Convert.ToInt32(dr["RECIBO_ANUL"]);
                var oRecibo = unitOfWork.RecibosRepository.GetByID(iReciboId);

                oRecibo.IMPORTE_GRAVADO = Convert.ToDecimal(dr["IMPORTE_GRAVADO"]);
       

                unitOfWork.RecibosRepository.Update(oRecibo);

            }



            unitOfWork.Save();
        }

         


        private static void CorrigeMontoGravado()
        {
            UnitOfWork unitOfWork = new UnitOfWork();


            string sSql = "SELECT A.RECIBO_ID, SUM(A.IMPORTE_GRAVADO) IMPORTE_GRAVADO, SUM(G.MONTO_LOCAL) MontoLocal ,SUM(G.MONTO_GRAVADO) MONTO_GRAVADO, SUM(G.MONTO) MONTO_TOTAL " +
                           " FROM RECIBOS A, (SELECT RECIBO_ID, SUM(MONTO_TOTAL) MONTO, SUM(MONTO_LOCAL) MONTO_LOCAL, SUM(CASE MONTO_ITBIS WHEN 0 THEN 0 ELSE MONTO_LOCAL END) MONTO_GRAVADO FROM RECIBOS_DET B GROUP BY RECIBO_ID) G      " +
                          " WHERE  A.RECIBO_ID = G.RECIBO_ID " +
                          " AND A.RECIBO_ID_ANUL = -1 " +
                          " AND TIPO_REC_ID = 3 " +
                          " Group by a.RECIBO_ID " +
                          " Having ABS( SUM(A.IMPORTE_GRAVADO) - SUM(G.MONTO_GRAVADO)) > 1";

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(sSql, ConfigurationManager.ConnectionStrings["dbepsContext"].ToString());

            da.Fill(dt);


            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {


                i++;
                int iReciboId = 0;

                Console.WriteLine("{0}\t recibo {1} \t ImporteFact {2} \tImporteDet {3}  \n", i, dr["RECIBO_ID"].ToString(), dr["IMPORTE_GRAVADO"].ToString(), dr["MONTO_GRAVADO"].ToString());

                iReciboId = Convert.ToInt32(dr["RECIBO_ID"]);
                var oRecibo = unitOfWork.RecibosRepository.GetByID(iReciboId);
              
                oRecibo.IMPORTE_GRAVADO = Convert.ToDecimal(dr["MONTO_GRAVADO"]);
                oRecibo.IMPORTE_TOTAL = Convert.ToDecimal(dr["MONTO_TOTAL"]);

                unitOfWork.RecibosRepository.Update(oRecibo);
                 
                }

               

                unitOfWork.Save();
            }


       
         


        private static void DiferenciaMontoFact()
        {
             UnitOfWork unitOfWork = new UnitOfWork();


             string sSql = "SELECT A.RECIBO_ID, SUM(A.IMPORTE_TOTAL) MONTO, SUM(G.MONTO) MONTO_DET, SUM(A.IMPORTE_CTA) " +
                            " FROM RECIBOS A, (SELECT RECIBO_ID, SUM(MONTO_TOTAL) MONTO FROM RECIBOS_DET B GROUP BY RECIBO_ID) G   " +
                           " WHERE  A.RECIBO_ID = G.RECIBO_ID " +
                           " AND A.RECIBO_ID_ANUL = -1 " +
                           " AND TIPO_REC_ID IN (1,3) " +
                           " Group by a.RECIBO_ID " +
                           " Having ABS(SUM(A.IMPORTE_TOTAL) - SUM(G.MONTO)) > 1";

             DataTable dt = new DataTable();

             SqlDataAdapter da = new SqlDataAdapter(sSql,ConfigurationManager.ConnectionStrings["dbepsContext"].ToString());

             da.Fill(dt);

         
             int i = 0;
             foreach (DataRow dr in dt.Rows)
             {

               
                     i++;
                     int iReciboId = 0;

                     Console.WriteLine("{0}\t recibo {1} \t ImporteFact {2} \tImporteDet {3}  \n", i, dr["RECIBO_ID"].ToString(), dr["MONTO"].ToString(), dr["MONTO_DET"].ToString());

                    iReciboId = Convert.ToInt32(dr["RECIBO_ID"]);
                     var oRecibo = unitOfWork.RecibosRepository.GetByID(iReciboId);
                     var oReciboDet = unitOfWork.RecibosDetRepository.Get(x => x.RECIBO_ID == iReciboId);
                     decimal dMontoTotal = 0;
                     decimal dMontoGravado = 0;
                     decimal dMontoItebis = 0;

                     foreach(var rdet in oReciboDet)
                     {
                         if (rdet.MONTO_ITBIS != 0)
                             dMontoGravado += rdet.MONTO_LOCAL;
                         dMontoItebis += rdet.MONTO_ITBIS;
                         dMontoTotal += rdet.MONTO_TOTAL;
                     }

                     if (oRecibo.REC_CREDITO == false)
                     {
                         oRecibo.IMPORTE_ITEBIS = dMontoItebis;
                         oRecibo.IMPORTE_TOTAL = dMontoTotal;
                         oRecibo.IMPORTE_GRAVADO = dMontoGravado;
                         oRecibo.IMPORTE_CTA = dMontoTotal;
                     }
                     else
                     {
                         oRecibo.IMPORTE_ITEBIS = dMontoItebis;
                         oRecibo.IMPORTE_TOTAL = dMontoTotal;
                         oRecibo.IMPORTE_GRAVADO = dMontoGravado;
                         
                         //Estado cobrado
                         if (oRecibo.ESTADO_ID == 14)
                         {
                             if (oRecibo.IMPORTE_CTA < dMontoTotal)
                                 oRecibo.ESTADO_ID = 13;  /*Facturado*/
                         }

                     }

                     unitOfWork.RecibosRepository.Update(oRecibo);

             }

             unitOfWork.Save();



        }
    }
}
