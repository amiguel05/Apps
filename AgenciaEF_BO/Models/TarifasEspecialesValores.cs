using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgenciaEF_BO.Models
{
    [Table("TARESP_VAL")]
    public class TarifasEspecialesValores
    {
        [Key]
        public int ID { set; get; }

        [Required]
        public int TAR_ESP_ID { set; get; }

        [Required]
        public decimal VAL_HASTA { set; get; }
        [Required]
        public decimal VAL_VALOR { set; get; }

        [Required]
        public decimal VAL_PORCENTAJE { set; get; }

        [Required]
        public decimal VAL_ADICIONAL { set; get; }

     
    }
}
