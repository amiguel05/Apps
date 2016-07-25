using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgenciaEF_BO.Models
{
    [Table("TASA_CAMBIO")]
    public class TasaCambio
    {
        [Key]
        public int TASA_ID { set; get; }

        [MaxLength(5)]
        [Required]
        public string TASA_CODIGO { set; get; }
        
        [Required]
        public int MONEDA_BASE_ID { set; get; }
        
        [Required]
        public int MONEDA_CONV_ID { set; get; }

        [Required]
        public decimal FACTOR_CONV { set; get; }

        [MaxLength(500)]
        [Required]
        public string TASA_DESCRIPCION { set; get; }


    }
}
