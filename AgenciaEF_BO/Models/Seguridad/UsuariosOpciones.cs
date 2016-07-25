using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("USUARIO_OPCIONES")]
    public class UsuariosOpciones
    {
       
        [Key]
        public int USR_OPC_ID { set; get; }

        [Required]
        public int OPC_ID { set; get; }

        [Required]
        public int USR_MOD_ID { set; get; }

        [Required]
        public bool  ACTIVO { set; get; }

        public virtual UsuariosModulos UsuariosModulos { set; get; }
  

    }
}
