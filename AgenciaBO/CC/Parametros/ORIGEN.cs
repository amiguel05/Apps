// Generated by MyGeneration Version # (1.3.0.3)

using System;
using System.Data;

namespace Agencia2.BO
{
	public class ORIGEN : _ORIGEN
	{
		public ORIGEN()
		{
            //this.s_ORI_APP_GROUP
            //is.s_ORI_CODIGO
            //s.s_ORI_CORREO_INT
            //.s_ORI_COURIER_GROUP
            //s.s_ORI_DESCRIPCION
           //is.s_ORI_EMS_GROUP
            //s.s_ORI_EQUIVALENTE
            //s.s_ORI_ESTADO
            //s.s_ORI_ID
		}
	}


    public class OrigenRecord
    {
        public int ORI_ID { set; get; }

        public string ORI_ESTADO { set; get; }
        public string ORI_EQUIVALENTE { set; get; }
        
        public string ORI_EMS_GROUP { set; get; }
        public string ORI_APP_GROUP { set; get; }
        public string ORI_DESCRIPCION { set; get; }
        public string ORI_COURIER_GROUP { set; get; }
        public string ORI_CORREO_INT { set; get; }
        public string ORI_CODIGO { set; get; }
   
        
    }


    public static class sOrigen
    {

        public static DataView returnView(ref string sMensaje)
        {
            sMensaje = "";
            ORIGEN oCom = new ORIGEN();
            try
            {

                oCom.ConnectionString = Parametros.CadenaConexion;

                oCom.Query.AddResultColumn("ORI_ID");
                oCom.Query.AddResultColumn("ORI_CODIGO");
                oCom.Query.AddResultColumn("ORI_DESCRIPCION");

                oCom.Query.Load();


            }
            catch (Exception ex)
            {
                sMensaje = ex.Message.ToString();


            }

            return oCom.DefaultView;

        }

        public static DataView returnCombo(ref string sMensaje)
        {
            sMensaje = "";
            ORIGEN oCom = new ORIGEN();
            try
            {

                oCom.ConnectionString = Parametros.CadenaConexion;

                oCom.Query.AddResultColumn("ORI_ID");
                oCom.Query.AddResultColumn("ORI_DESCRIPCION");

                oCom.Query.Load();


            }
            catch (Exception ex)
            {
                sMensaje = ex.Message.ToString();


            }
            return oCom.DefaultView;
        }


        public static bool DeleteData(OrigenRecord pComp, ref string sMensaje)
        {
            bool bRetorno = true;

            try
            {
                ORIGEN oCom = new ORIGEN();
                oCom.ConnectionString = Parametros.CadenaConexion;

                oCom.LoadByPrimaryKey(pComp.ORI_ID);


                oCom.MarkAsDeleted();

                oCom.Save();

            }
            catch (Exception ex)
            {
                sMensaje = ex.Message.ToString();
                bRetorno = false;

            }


            return bRetorno;
        }


        public static bool SaveData(OrigenRecord pComp, ref string sMensaje, bool bAdiciona)
        {
            bool bRetorno = true;

            try
            {
                ORIGEN oCom = new ORIGEN();
                oCom.ConnectionString = Parametros.CadenaConexion;

                if (!bAdiciona)
                    oCom.LoadByPrimaryKey(pComp.ORI_ID);
                else
                {
                    oCom.AddNew();
                }

                oCom.ORI_ESTADO = pComp.ORI_ESTADO;
                oCom.ORI_EQUIVALENTE = pComp.ORI_EQUIVALENTE;
                oCom.ORI_EMS_GROUP = pComp.ORI_EMS_GROUP;
                oCom.ORI_DESCRIPCION = pComp.ORI_DESCRIPCION;
                oCom.ORI_COURIER_GROUP = pComp.ORI_COURIER_GROUP;
                oCom.ORI_CORREO_INT = pComp.ORI_CORREO_INT;
                oCom.ORI_CODIGO = pComp.ORI_CODIGO;


                oCom.Save();

            }
            catch (Exception ex)
            {
                sMensaje = ex.Message.ToString();
                bRetorno = false;

            }


            return bRetorno;
        }

        public static bool ReturnById(int Id, ref ORIGEN pComp, ref string sMensaje)
        {
            bool bRetorno = true;

            try
            {
                ORIGEN oCom = new ORIGEN();
                oCom.ConnectionString = Parametros.CadenaConexion;
                oCom.LoadByPrimaryKey(Id);

                pComp = oCom;


            }
            catch (Exception ex)
            {
                sMensaje = ex.Message.ToString();
                bRetorno = false;
            }

            return bRetorno;


        }
    }





}
