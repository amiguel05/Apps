using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
   [Table("SECUENCIALES")]
    public class Secuenciales
    {
       [Key]
       public int SEC_ID { set; get; }
       [Required]
       public int SUC_ID { set; get; }
       [Required]
       public int TIPO_ID { set; get; }
       [Required]
       public int VALOR { set; get; }
       public virtual Sucursales Sucursales { set; get; }
       public virtual Tipos Tipos { set; get; }
    }
}
