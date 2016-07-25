using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("USUARIOS_ROLES")]
    public class UsuariosRoles
    {
 
        [Key]
        public int USR_ROLE_ID { set; get; }

        [Required]
        public int  USR_SUC_ID { set; get; }

        [Required]
        public int ROL_ID { set; get; }

        [Required]
        public bool ACTIVO { set; get; }

        public virtual Roles  Roles { set; get; }

        public virtual UsuarioSucursal UsuarioSucursal { set; get; }


    }
}
