using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("ROLES")]
    public class Roles
    {
 
        [Key]
        public int ROL_ID { set; get; }

        [Required]
        public string NOMBRE { set; get; }

        [Required]
        public int MOD_ID { set; get; }

        [Required]
        public string DESCRIPCION { set; get; }

        [Required]
        public bool ACTIVO { set; get; }

        public virtual Modulos Modulos { set; get; }

    }
}
