using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("USUARIOS_MODULOS")]
    public class UsuariosModulos
    {
       
        [Key]
        public int USR_MOD_ID { set; get; }

        [Required]
        public int USR_SUC_ID { set; get; }

        [Required]
        public int MOD_ID { set; get; }

        [Required]
        public bool  ACTIVO { set; get; }

        public virtual UsuarioSucursal UsuarioSucursal { set; get; }

        public List<UsuariosOpciones> UsuariosOpciones { set; get; }
  

    }
}
