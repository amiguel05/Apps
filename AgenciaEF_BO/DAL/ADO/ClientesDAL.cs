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
    public class ClientesDAL
    {

        private SqlConnection _connection;

        public string  RetornaCodigoVoice_dbeps(string psCteNumeroEPS)
        {
            string sRetorno;

            using (_connection = Acceso.ObtenerConexion())
            {
                string sCadena = "SELECT CTE_CODIGO_VOICE FROM EPSINT01.dbeps.dbo.CLIENTES WHERE CTE_NUMERO_EPS = '" + psCteNumeroEPS + "'";
                sRetorno = _connection.Query<string>(sCadena, commandType: CommandType.Text).SingleOrDefault();

            }

            return sRetorno;
        }

    }
}
