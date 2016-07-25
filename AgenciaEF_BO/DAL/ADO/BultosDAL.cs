using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using AgenciaEF_BO.Models;

namespace AgenciaEF_BO.DAL.ADO
{
    public class BultosDal
    {
        private SqlConnection _connection;

        public bool InsertarCargos(int piBultoLocal, int piBltNumero)
        {
            int iRetorno;

            using (_connection = Acceso.ObtenerConexion())
            {
                iRetorno = _connection.ExecuteScalar<int>(@"[PROC_MFR2_INSERTAR_CARGOS]", new {BLT_NUMERO_LOCAL= piBultoLocal, BLT_NUMERO_EPS=piBltNumero }, commandType: CommandType.StoredProcedure);

                //iRetorno = _connection.ExecuteScalar<int>(@"[PROC_MFR2_INSERTAR_UNIDADES]", new { BLT_NUMERO_LOCAL = piBultoLocal, BLT_NUMERO_EPS = piBltNumero }, commandType: CommandType.StoredProcedure);

                //iRetorno = _connection.ExecuteScalar<int>(@"[PROC_MFR2_INSERTAR_ITEBIS]", new { BLT_NUMERO_LOCAL = piBultoLocal}, commandType: CommandType.StoredProcedure);
                
            }

            return true;
        }


        public bool RecalcularUnidades(int piBultoLocal)
        {
            int iRetorno;

            using (_connection = Acceso.ObtenerConexion())
            {
                iRetorno = _connection.ExecuteScalar<int>(@"[PROC_MFR2_INSERTAR_UNIDADES]", new { BLT_NUMERO_LOCAL = piBultoLocal, BLT_NUMERO_EPS = -1 }, commandType: CommandType.StoredProcedure);

                // iRetorno = _connection.ExecuteScalar<int>(@"[PROC_MFR2_INSERTAR_UNIDADES]", new { BLT_NUMERO_LOCAL = piBultoLocal, BLT_NUMERO_EPS = piBltNumero }, commandType: CommandType.StoredProcedure);

                //  iRetorno = _connection.ExecuteScalar<int>(@"[PROC_MFR2_INSERTAR_ITEBIS]", new { BLT_NUMERO_LOCAL = piBultoLocal}, commandType: CommandType.StoredProcedure);

            }

            return true;
        }

        public bool RecalcularItebis(int piBultoLocal)
        {
            int iRetorno;

            using (_connection = Acceso.ObtenerConexion())
            {
                iRetorno = _connection.ExecuteScalar<int>(@"PROC_MFR2_INSERTAR_ITEBIS", new { BLT_NUMERO_LOCAL = piBultoLocal }, commandType: CommandType.StoredProcedure);

                // iRetorno = _connection.ExecuteScalar<int>(@"[PROC_MFR2_INSERTAR_UNIDADES]", new { BLT_NUMERO_LOCAL = piBultoLocal, BLT_NUMERO_EPS = piBltNumero }, commandType: CommandType.StoredProcedure);

                //  iRetorno = _connection.ExecuteScalar<int>(@"[PROC_MFR2_INSERTAR_ITEBIS]", new { BLT_NUMERO_LOCAL = piBultoLocal}, commandType: CommandType.StoredProcedure);

            }

            return true;
        }



        //(DocCodigo, FacCodigo, Parametros.ParametrosSucursal.CodigoAlmacen, Parametros.ParametrosSucursal.Ubicacion, Parametros.ParametrosSucursal.IdSucursal)
        public IEnumerable<ImportacionAgencia> ImportarBultos(string psDocCodigo, string psFacCodigo, int piCodAlmacen, string psUbicacion, int piSucId, int piUserId)
        {
            IEnumerable<ImportacionAgencia> oImpAgencia;

            using (_connection = Acceso.ObtenerConexion())
            {
                oImpAgencia = _connection.Query<ImportacionAgencia>(@"[SP_MFR2_IMPORTA_MANIFIESTO]", new { DOC_CODIGO = psDocCodigo, FAC_CODIGO = psFacCodigo,
                                                                                                           ALM_CODIGO = piCodAlmacen,
                                                                                                           BLT_UBICACION = psUbicacion,
                                                                                                           SUC_ID = piSucId,
                                                                                                           USUARIO_ID = piUserId
                }, commandType: CommandType.StoredProcedure);

            }

            return oImpAgencia;
        }
    }
}
