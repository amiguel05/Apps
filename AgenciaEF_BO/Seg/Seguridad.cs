using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;



namespace AgenciaEF_BO.Seg
{
    public class Seguridad
    {

        private DAL.UnitOfWork unitOfWork = new DAL.UnitOfWork();

        public bool Autentica(string psUserName, string psClave, ref int piUsuarioId)
        {

            string sClave = ClaveMD5(psClave);
           
            bool bRetorno = false;
            piUsuarioId = -1;

            var sQry = unitOfWork.UsuariosRepository.Get(filter: s => s.USER_NAME == psUserName).FirstOrDefault();

            if (sQry == null)
                bRetorno = false;
            else if (sQry.USUARIO_ID > 0 && sQry.CLAVE == sClave)
            {
                piUsuarioId = sQry.USUARIO_ID;
                bRetorno = true;
            }
            else
            {
                bRetorno = false;
            }

            return bRetorno;
        }

      

        public string ClaveMD5(string psTexto)
        {
           return string.Join("", new MD5CryptoServiceProvider().ComputeHash(new MemoryStream(Encoding.UTF8.GetBytes(psTexto))).Select(x => x.ToString("X2")));
        }

        public ICollection<Models.UsuarioSucursal> SucursalUsuarios(int piUserId)
        {


            var sQry = unitOfWork.UsuarioSucursalRepository.Get(filter: s => s.Usuarios.USUARIO_ID == piUserId);


            return sQry.ToList();

        }

    }
}
