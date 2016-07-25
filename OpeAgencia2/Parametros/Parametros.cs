using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = AgenciaEF_BO;

namespace OpeAgencia2.Parametros
{
    public static class Parametros
    {

        static int iUsuarioId;

        static string sUserName;
        static ICollection<BO.Models.UsuarioSucursal> oUserSuc;

        static int iSucActual;
        static int iUserSucActual;

        static int iProductoCorrespondencia;
        static string  sProductoCorrespondencia;


        static string  sNombreSucActual;


        public static int ProdCorrespondencia
        {
            get { return iProductoCorrespondencia; }
            set { iProductoCorrespondencia = value; }
        }

        public static string  NomProdCorrespondencia
        {
            get { return sProductoCorrespondencia; }
            set { sProductoCorrespondencia = value; }
        }



        public static string UserName
        {
            set { sUserName = value; }
            get { return sUserName; }
        }


        public static string NombreSucActual
        {
            set { sNombreSucActual = value; }
            get { return sNombreSucActual; }
        }


        public static int UsuarioId
        {
            set { iUsuarioId = value; }
            get { return iUsuarioId; }
        }

        public static int UsuarioSucursalActual
        {
            set { iUserSucActual = value; }
            get { return iUserSucActual; }
        }
    

        public static int SucursalActual
        {
            set { iSucActual = value; }
            get { return iSucActual; }
        }
    

        public static ICollection<BO.Models.UsuarioSucursal> UsuarioSucursal
        {
            set { oUserSuc = value; }
            get { return oUserSuc; }
        }


        

    }
}
