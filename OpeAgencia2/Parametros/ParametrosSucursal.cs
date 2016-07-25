using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = AgenciaEF_BO;

namespace OpeAgencia2.Parametros
{
    public  static class ParametrosSucursal
    {

        static string sCodigoSucursal;
        static int mIdSucursal;
        static int mAlmacen;
        static string sUbicacion;
        static string sSucursal;
        static string sEncabezadoFactura1;
        static string sEncabezadoFactura2;
        static string sEncabezadoFactura3;

        static int iTermFiscalId;
        static string sPuertoFiscal;

        static bool bNoImpresoraFiscal;

        private  static    BO.DAL.UnitOfWork unitOfWork = new BO.DAL.UnitOfWork();


        public static bool NoImpresoraFiscal
        {
            set { bNoImpresoraFiscal = value;  }
            get {return bNoImpresoraFiscal;  }
        }


        public static int TermFiscalId
        {
            set { iTermFiscalId = value; }
            get { return iTermFiscalId; }
        }

        public static string PuertoFiscal
        {
            set { sPuertoFiscal = value; }
            get { return sPuertoFiscal; }
        }

     
        public static int CodigoAlmacen
        {
            set { mAlmacen = value; }
            get { return mAlmacen; }
        }

        public static string Ubicacion
        {
            set { sUbicacion = value; }
            get { return sUbicacion; }

        }

        public static string  CodigoSucursal
        {
            set { sCodigoSucursal = value; }

            get { return sCodigoSucursal; }
        }


        public static string EncabezadoFactura1
        {
            set { sEncabezadoFactura1 = value; }

            get { return sEncabezadoFactura1; }
        }

        public static string EncabezadoFactura2
        {
            set { sEncabezadoFactura2 = value; }

            get { return sEncabezadoFactura2; }
        }

        public static string EncabezadoFactura3
        {
            set { sEncabezadoFactura3 = value; }

            get { return sEncabezadoFactura3; }
        }

        public  static int  IdSucursal
        {
            set { mIdSucursal= value;
            CodigoSucursal = BuscaSucursal();
            Ubicacion = BuscarUbicacion();
            CodigoAlmacen = BuscarAlmacen();
            bNoImpresoraFiscal = UsaImpresoraFiscal();
            }

            get { return mIdSucursal; }
        }


        public static bool UsaImpresoraFiscal()
        {
            bool bRetorno = false; 

            try
            {
                var sQury = unitOfWork.ParametrosSucursalRepository.Get(filter: s => s.SUC_ID == mIdSucursal && s.PARAMETRO == "NO_PRINTER_FISCAL").FirstOrDefault();

                if (sQury != null)
                    bRetorno = Convert.ToBoolean(sQury.VALOR1);

            }
            catch
            {
                bRetorno = false;
            }
            
            return bRetorno;
        }

        public static string  BuscaSucursal()
        {
            string sRetorno = "-1";

            var sQury = unitOfWork.ParametrosSucursalRepository.Get(filter: s => s.SUC_ID == mIdSucursal && s.PARAMETRO == "AGENCIA").FirstOrDefault();

            if (sQury != null)
                sRetorno =  sQury.VALOR1;

            return sRetorno;
        }

        public static string BuscarUbicacion()
        {
            string sRetorno = "-1";

            var sQury = unitOfWork.ParametrosSucursalRepository.Get(filter: s => s.SUC_ID == mIdSucursal && s.PARAMETRO == "BLT_UBICACION").FirstOrDefault();

            if (sQury != null)
                sRetorno = sQury.VALOR1;

            return sRetorno;
        }

        public static int BuscarAlmacen()
        {
            int iRetorno = -1;

            var sQury = unitOfWork.ParametrosSucursalRepository.Get(filter: s => s.SUC_ID == mIdSucursal && s.PARAMETRO == "ALMACEN").FirstOrDefault();

            if (sQury != null)
                iRetorno = Convert.ToInt32(sQury.VALOR1);

            return iRetorno;
        }


        public static void BuscarEncabezado()
        {
            string sRetorno ="NA";

            var sQury = unitOfWork.ParametrosSucursalRepository.Get(filter: s => s.SUC_ID == mIdSucursal && s.PARAMETRO == "ENCABEZADO_FACT1").FirstOrDefault();

            if (sQury != null)
                sEncabezadoFactura1 = sQury.VALOR1;

            var sQury2 = unitOfWork.ParametrosSucursalRepository.Get(filter: s => s.SUC_ID == mIdSucursal && s.PARAMETRO == "ENCABEZADO_FACT2").FirstOrDefault();

            if (sQury2 != null)
            {
                sEncabezadoFactura2 = sQury2.VALOR1 + "\n";
                sEncabezadoFactura2 += sQury2.VALOR2;
            }
            else
            {
                sEncabezadoFactura2 = "NO PARAMETRIZADO" + "\n";
                sEncabezadoFactura2 +="NO PARAMETRIZADO";

            }

            var sQury3 = unitOfWork.ParametrosSucursalRepository.Get(filter: s => s.SUC_ID == mIdSucursal && s.PARAMETRO == "ENCABEZADO_FACT3").FirstOrDefault();

            if (sQury3 != null)
            {
                sEncabezadoFactura3 = sQury3.VALOR1 + "\n";
                sEncabezadoFactura3 += sQury3.VALOR2;
            }
            else
            {
                sEncabezadoFactura3 = "NO PARAMETRIZADO\n";
                sEncabezadoFactura3 += "NO PARAMETRIZADO\n";
            }

        }
        



    }
}
