using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("TERMINAL")]
    public class Terminal
    {
         [Key]
         public int TERM_ID { set; get; }

         [Required]
         public int SUC_ID { set; get; }

         [Required]
         public string TERM_DESC { set; get; }

         [Required]
         public string SERIAL { set; get; }
         
         [Required]
         public string PUERTO { set; get;  }

         public virtual Sucursales Sucursales { set; get; }

    }
}
