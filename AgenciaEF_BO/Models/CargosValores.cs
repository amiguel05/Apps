using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgenciaEF_BO.Models
{
    [Table("TABLA_VALORES")]
   public  class CargosValores
    {
        [Key]
        public int TABLA_VAL_ID { set; get; }

        [Required]
        public int CARGO_PROD_ID { set; get; }

        [Required]
        public decimal VAL_HASTA { set; get; }

        [Required]
        public decimal VAL_VALOR { set; get; }
        
         [Required]
        public decimal  VAL_PORCENTAJE { set; get; }
        //CAR_FACTURAR_APARTE

         [Required]
         public decimal  VAL_ADICIONAL { set; get; }

         [Required]
         public int COD_TAR_ID { set; get; }

         [Required]
         public int  SUC_ID { set; get; }

         public virtual Sucursales Sucursales { set; get; }

  

    }
}
