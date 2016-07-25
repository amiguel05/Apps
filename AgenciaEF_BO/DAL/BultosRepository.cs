using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.Models;
using System.Linq.Dynamic;

namespace AgenciaEF_BO.DAL
{
    public class BultosRepository : GenericRepository<Bultos>
    {

        public BultosRepository(AgenciasContext context)
            : base(context)
        {

        }

        public IEnumerable<Bultos> GetByNumeroEPS(string psNumeroEPS, string psGuiaMadre, string sCodigoBarra,string sTracking, int piEstado, int piComCodigo)
        {
            //Bultos oBultos = new Bultos();
            //Productos.PRO_TIPO_ID = 31


            string sCadena = " Productos.PRO_TIPO_ID == 31 ";

            if (sCodigoBarra != "")
            {
                if (sCadena != "")
                    sCadena += " && ";

                sCadena = "BLT_CODIGO_BARRA == " + '"' + sCodigoBarra + '"';
            }

           if (psNumeroEPS != "")
           {
               if (sCadena != "")
                   sCadena += " && ";

               sCadena += "Clientes.CTE_NUMERO_EPS =="+'"'+ psNumeroEPS+'"';
           }


           if (psGuiaMadre != "")
           {
               if (sCadena != "")
                   sCadena += " && ";
               sCadena += "MAN_GUIA == " + '"' + psGuiaMadre + '"';
           }

           if (sTracking != "")
           {
               if (sCadena != "")
                   sCadena += " && ";

               sCadena += "BLT_TRACKING_NUMBER == " + '"' + sTracking + '"';
           }

            if (sCadena != "")
                   sCadena += " && ";

            switch (piEstado)
            {
                case 0:
                    sCadena += "(BLT_ESTADO_ID ==1 || BLT_ESTADO_ID ==2  || BLT_ESTADO_ID ==3 || BLT_ESTADO_ID ==4)";


                    break;
                case 1:
                    sCadena += "BLT_ESTADO_ID  == 5";


                    break;
                case 2:
                    sCadena += "BLT_ESTADO_ID  == 6";

                    break;
            }

            if (sCadena != "")
                sCadena += " && ";

            sCadena += "Sucursales.Empresas.COM_CODIGO  == " + piComCodigo.ToString();
               
      


           var Bultos = this.GetDinamic(filter: sCadena);

                       
                         

              return Bultos;


            /*

            if ( (psNumeroEPS != "")  && (psGuiaMadre != "")  && (sCodigoBarra != "") &&  (sTracking != "") )
            {
                var Butos = this.Get(filter: s => s.Clientes.CTE_NUMERO_EPS == psNumeroEPS
                     && s.MAN_GUIA == psGuiaMadre
                     && s.BLT_CODIGO_BARRA == psGuiaMadre
                     && s.BLT_TRACKING_NUMBER == psGuiaMadre);
         
                   return Butos;

            }
            else if ((psNumeroEPS != "") && (psGuiaMadre != "") && (sCodigoBarra != "") && (sTracking == "") )
            {
                var Butos = this.Get(filter: s => s.Clientes.CTE_NUMERO_EPS == psNumeroEPS
                     && s.MAN_GUIA == psGuiaMadre
                     && s.BLT_CODIGO_BARRA == psGuiaMadre);

                return Butos;

            }
            else if ( (psNumeroEPS != "")  && (psGuiaMadre == "")  && (sCodigoBarra == "") &&  (sTracking == "") )
            {
                var Butos = this.Get(filter: s => s.Clientes.CTE_NUMERO_EPS == psNumeroEPS);
                   

                return Butos;

            }
            else if ((psNumeroEPS == "") && (psGuiaMadre != "") && (sCodigoBarra == "") && (sTracking == "") )
            {
                var Butos = this.Get(filter: s => s.MAN_GUIA == psGuiaMadre);


                return Butos;

            }
            else if ((psNumeroEPS == "") && (psGuiaMadre == "") && (sCodigoBarra != "") && (sTracking == "") )
            {
                var Butos = this.Get(filter: s => s.BLT_CODIGO_BARRA == sCodigoBarra);


                return Butos;

            }
            else if ((psNumeroEPS == "") && (psGuiaMadre == "") && (sCodigoBarra == "") && (sTracking != "") )
            {
                var Butos = this.Get(filter: s => s.BLT_TRACKING_NUMBER == sTracking);


                return Butos;

            }
            */
            return null;



        }
      


    }
}
