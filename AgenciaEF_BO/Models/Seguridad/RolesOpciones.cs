using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("ROLES_OPCIONES")]
    public class RolesOpciones
    {
 
        [Key]
        public int ROL_OPC_ID { set; get; }

        [Required]
        public int ROL_ID { set; get; }

        [Required]
        public int OPC_ID { set; get; }

        [Required]
        public bool ACTIVO { set; get; }

        public virtual Roles Roles { set; get; }

        public virtual Opciones Opciones { set; get; }

    }
}
