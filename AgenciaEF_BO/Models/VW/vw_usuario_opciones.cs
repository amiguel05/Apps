using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models.VW
{
    [Table("VW_USUARIO_OPCIONES")]
    public class vw_usuario_opciones
    {
        //S.USUARIO_ID, S.SUC_ID, S.USR_SUC_ID, M.USR_MOD_ID,M.ACTIVO MOD_ACTIVO, O.MOD_ACTIVO

        [Key]
        public int USR_OPC_ID { set; get; }

        public int USUARIO_ID { set; get; }

        public int SUC_ID { set; get; }

        public int USR_SUC_ID { set; get; }
        public int USR_MOD_ID { set; get; }

        public bool MOD_ACTIVO { set; get; }


        public int OPC_ID { set; get; }
        // OP.OPC_PARENT_ID, OP.OPC_FORM, OP.OPC_NAME,OPC_ORDER

        public int OPC_PARENT_ID { set; get; }

        public string OPC_FORM { set; get; }

        public string OPC_NAME { set; get; }

        public int OPC_ORDER { set; get; }
        

    }
}
