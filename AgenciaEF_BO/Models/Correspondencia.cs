using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
     [Table("CORRESP_RECEP")]
    public class Correspondencia
    {
         [Key]
         public int ID { set; get; }

         [Required]
         public int CTE_ID { set; get; }

         [Required]
         public int PIEZAS { set; get; }

         [Required]
         public decimal PESO { set; get; }

         [Required]
         public DateTime FECHA { set; get; }

         [Required]
         public int USER_ID { set; get; }

         public virtual Clientes Clientes { set; get; }


    }
}
