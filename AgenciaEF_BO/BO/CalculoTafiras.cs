using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaEF_BO.DAL;
using AgenciaEF_BO.Models;

namespace AgenciaEF_BO.BO
{
    public class CalculoTafiras
    {

        private UnitOfWork unitOfWork = new UnitOfWork();


        public bool AplicarLibrasGratis(int bltNumero, int LibrasGratis, int CteId, int iUserId, ref string  sMensaje )
        {

            var BultosValores = unitOfWork.BultosValoresRepository.Get(filter: xy => xy.CargosProducto.Cargos.CAR_CODIGO == "010" && xy.BLT_NUMERO == bltNumero).FirstOrDefault();

            bool bRetorno = false;

            if (BultosValores != null)
            {

                var oCargosProducto  = unitOfWork.CargosProductoRepository.Get(filter: xy=>xy.Cargos.CAR_CODIGO=="093" && xy.PROD_ID== BultosValores.CargosProducto.PROD_ID).FirstOrDefault();

                if (oCargosProducto != null)
                {
                    Models.BultosValores oCargoExiste = unitOfWork.BultosValoresRepository.Get(filter: xy => xy.BLT_NUMERO == BultosValores.BLT_NUMERO && xy.CargosProducto.Cargos.CAR_CODIGO == "093").FirstOrDefault();

                    if (oCargoExiste !=null)
                    {
                        unitOfWork.BultosValoresRepository.Delete(oCargoExiste);
                    }


                    Models.BultosValores oDescuento = new BultosValores();

                    oDescuento.BLT_NUMERO = BultosValores.BLT_NUMERO;
                    oDescuento.CARGO_PROD_ID = oCargosProducto.CARGO_PROD_ID;
                    oDescuento.BVA_TASA = BultosValores.BVA_TASA;
                    oDescuento.BVA_MONTO_APLICAR = 1;
                    oDescuento.BVA_MONTO  = (LibrasGratis * BultosValores.BVA_MONTO_APLICAR) * -1;
                    oDescuento.BVA_MONTO_LOCAL = (LibrasGratis * BultosValores.BVA_MONTO_APLICAR * BultosValores.BVA_TASA) * -1;

                    unitOfWork.BultosValoresRepository.Insert(oDescuento);

                    var oLibrasGratis = unitOfWork.LibrasGratisRepository.Get(filter: xy => xy.CTE_ID == CteId).FirstOrDefault();

                    oLibrasGratis.LIBRAS_GRATIS = oLibrasGratis.LIBRAS_GRATIS - LibrasGratis;

                    oLibrasGratis.LIBRAS_GRATIS_ACUMULADAS += LibrasGratis;

                    oLibrasGratis.USUARIO_ID = iUserId;
                    oLibrasGratis.FECHA_ULT_ASIGNACION = DateTime.Now;


                    unitOfWork.LibrasGratisRepository.Update(oLibrasGratis);

                    try
                    {
                        unitOfWork.Save();
                        bRetorno = true;
                    }
                    catch(Exception ex)
                    {

                        sMensaje = ex.ToString();
                    }
 
                }

       

            }




            return bRetorno;
        }

        public decimal BuscarMontoAplicar(int piCargoId, decimal Monto, int iNumeroEPS)
        {
            decimal dRetorno = 1;

            var Clientes = unitOfWork.ClientesRepository.GetByID(iNumeroEPS);

            var cargosProd = from p in unitOfWork.CargosValoresRepository.Get(filter: s => s.COD_TAR_ID == Clientes.COD_TARIFA && s.SUC_ID == Clientes.CTE_SUC_ID && s.CARGO_PROD_ID == piCargoId)
                             orderby p.VAL_HASTA
                             select new { p.VAL_HASTA, p.VAL_PORCENTAJE, p.VAL_VALOR, p.VAL_ADICIONAL };


            foreach (var valor in cargosProd)
            {
                if (Monto <= valor.VAL_HASTA)
                {
                    dRetorno = valor.VAL_VALOR;
                    break;
                }


            }



            return dRetorno;

        }

        public void  CalcularUnidades(int bltNumero)
        {

            int iProductoId;
            decimal dPeso;
            decimal dValorFOB;
            decimal dSellos; 
            decimal dOverSize;
            int iNumeroEps;

            var vQryBultos = unitOfWork.BultosRepository.GetByID(bltNumero);

            iProductoId = vQryBultos.PROD_ID;
            dPeso = vQryBultos.BLT_PESO;
            dValorFOB = vQryBultos.BLT_VALOR_FOB;
            dSellos = vQryBultos.BLT_MONTO_SELLOS;

            dOverSize = vQryBultos.BLT_VOLUMEN;
            iNumeroEps = vQryBultos.CTE_ID;


            List<BultosValores> lBultosVal = new List<BultosValores>();

            var cargosExits = unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProductoId && s.Cargos.CAR_BASE_ID == 25
                && s.Cargos.CAR_ESTADO == true && s.FIJO == true); /*tipo cargos*/

            // var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);


            foreach (var cargo in cargosExits)
            {
                BultosValores oBultosVal = new BultosValores();

                oBultosVal.BLT_NUMERO = bltNumero;

                var OldBultosVal = unitOfWork.BultosValoresRepository.Get(filter: s => s.CARGO_PROD_ID == cargo.CARGO_PROD_ID && s.BLT_NUMERO == bltNumero).FirstOrDefault();

                if (OldBultosVal != null)
                {
                    unitOfWork.BultosValoresRepository.Delete(OldBultosVal);
                }



                oBultosVal.CARGO_PROD_ID = cargo.CARGO_PROD_ID;
                oBultosVal.BVA_TASA = cargo.TasaCambio.FACTOR_CONV;
                oBultosVal.BVA_MONTO = dPeso;
                oBultosVal.BVA_MONTO_APLICAR = BuscarMontoAplicar(cargo.CARGO_PROD_ID, dPeso, iNumeroEps);


                if (cargo.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                {
                    if ((oBultosVal.BVA_MONTO_APLICAR) < cargo.Cargos.CAR_MINIMO_FACTURAR)
                    {
                        oBultosVal.BVA_MONTO_APLICAR = cargo.Cargos.CAR_MINIMO_FACTURAR;
                    }

                    oBultosVal.BVA_MONTO_LOCAL = oBultosVal.BVA_MONTO_APLICAR * cargo.TasaCambio.FACTOR_CONV;

                }
                else
                {
                    if (dPeso < cargo.Cargos.CAR_MINIMO_FACTURAR)
                    {
                        dPeso = Convert.ToDecimal(cargo.Cargos.CAR_MINIMO_FACTURAR);
                       
                    }

                    oBultosVal.BVA_MONTO_LOCAL = dPeso * oBultosVal.BVA_MONTO_APLICAR * cargo.TasaCambio.FACTOR_CONV;
                }

                unitOfWork.BultosValoresRepository.Insert(oBultosVal);

                lBultosVal.Add(oBultosVal);

                unitOfWork.Save();

            }

        
        }


        public List<BultosValores> CalcularCorrespondencia(int piProdId, decimal pdPeso, int piPiezas, int piNumeroEPS)
        {

            int iProductoId;
            decimal dPeso;
      
            int iNumeroEps;
            int iPiezas; 
          

            iProductoId = piProdId;
            dPeso = pdPeso;
            iPiezas = piPiezas;
            iNumeroEps = piNumeroEPS;


            List<BultosValores> lBultosVal = new List<BultosValores>();

            var cargosExits = unitOfWork.CargosProductoRepository.Get(filter: s => s.PROD_ID == iProductoId && (s.Cargos.CAR_BASE_ID == 25 || s.Cargos.CAR_BASE_ID==27) && s.Cargos.CAR_ESTADO == true); /*tipo cargos*/

            // var cargosProd = unitOfWork.CargosProductoRepository.GetByID(iCargoProd);

            var Clientes = unitOfWork.ClientesRepository.GetByID(iNumeroEps);


            foreach (var cargo in cargosExits)
            {
                BultosValores oBultosVal = new BultosValores();

                oBultosVal.CARGO_PROD_ID = cargo.CARGO_PROD_ID;
                oBultosVal.BVA_TASA = cargo.TasaCambio.FACTOR_CONV;
                if (cargo.Cargos.CAR_BASE_ID==27)
                {
                    oBultosVal.BVA_MONTO = iPiezas;
                    oBultosVal.BVA_MONTO_APLICAR = BuscarMontoAplicar(cargo.CARGO_PROD_ID, iPiezas, iNumeroEps);

                }
                else
                {
                    oBultosVal.BVA_MONTO = dPeso;
                    oBultosVal.BVA_MONTO_APLICAR = BuscarMontoAplicar(cargo.CARGO_PROD_ID, dPeso, iNumeroEps);
                }
               


                if (cargo.Cargos.CAR_FIJO_MULTIPLICAR == "F")
                {
                    if ((oBultosVal.BVA_MONTO_APLICAR) < cargo.Cargos.CAR_MINIMO_FACTURAR)
                    {
                        oBultosVal.BVA_MONTO_APLICAR = cargo.Cargos.CAR_MINIMO_FACTURAR;
                    }

                    oBultosVal.BVA_MONTO_LOCAL = oBultosVal.BVA_MONTO_APLICAR * cargo.TasaCambio.FACTOR_CONV;

                }
                else
                {
                    if (cargo.Cargos.CAR_BASE_ID==27)
                    {
                        if (iPiezas < cargo.Producto.PRO_MINIMO)
                        {
                            iPiezas = Convert.ToInt32(cargo.Producto.PRO_MINIMO);

                        }

                        oBultosVal.BVA_MONTO_LOCAL = iPiezas * oBultosVal.BVA_MONTO_APLICAR * cargo.TasaCambio.FACTOR_CONV;

                    }
                    else
                    {
                        if (dPeso < cargo.Producto.PRO_MINIMO)
                        {
                            dPeso = Convert.ToDecimal(cargo.Producto.PRO_MINIMO);

                        }

                        oBultosVal.BVA_MONTO_LOCAL = dPeso * oBultosVal.BVA_MONTO_APLICAR * cargo.TasaCambio.FACTOR_CONV;
                    }
                    
                }

                //unitOfWork.BultosValoresRepository.Insert(oBultosVal);

                lBultosVal.Add(oBultosVal); 

            }

            //Actualiza Itebis
            decimal dMontoItebis = 0;

            if (Clientes.CTE_TIPO_FISCAL == 45)
                return lBultosVal;


            var QrycargosProd = unitOfWork.CargosProductoRepository.Get(filter: s => s.Cargos.CAR_CODIGO == "999").FirstOrDefault();
            
            if (QrycargosProd != null)
            {
                foreach (var bultos in lBultosVal)
                {
                    var sQry = unitOfWork.CargosProductoRepository.Get(filter: s => s.CARGO_PROD_ID == bultos.CARGO_PROD_ID).FirstOrDefault();


                    if (sQry.Cargos.CAR_ITBIS == true && sQry.Cargos.ITBIS > 0)
                    {
                        dMontoItebis += Math.Round((bultos.BVA_MONTO_LOCAL * sQry.Cargos.ITBIS) / 100, 2);
                    }
                }

                if  ( dMontoItebis > 0 )
                {
                    BultosValores oBultosVal = new BultosValores();

                    oBultosVal.CARGO_PROD_ID = QrycargosProd.CARGO_PROD_ID;
                    oBultosVal.BVA_TASA = QrycargosProd.Cargos.ITBIS;
                    oBultosVal.BVA_MONTO = dMontoItebis;
                    oBultosVal.BVA_MONTO_APLICAR = dMontoItebis;
                    oBultosVal.BVA_MONTO_LOCAL = dMontoItebis;

                    lBultosVal.Add(oBultosVal); 

                }


            }

          

            return lBultosVal;


        }


    }
}
