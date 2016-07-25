using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgenciaEF_BO.Models
{
 
    [Table("V2_OPCIONES")]
    public class Opciones
    {
        [Key]
        public int OPC_ID { set; get; }
        public string OPC_NAME { set; get; }
        public string OPC_FORM { set; get; }
        public bool OPC_STATE { set; get; }
        public int OPC_PARENT_ID { set; get; }

        public int MOD_ID { set; get; }

        [Required]
        public int OPC_ORDER { set; get; }

        public virtual Modulos Modulos { set; get; }
    }
}
