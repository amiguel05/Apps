using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("DATOS_PAGOS")]
    public class DatosPagos
    {
        [Key]
        public int DATO_PAGO_ID { set; get; }

        [Required]
        public int PAGO_ID { set; get; }

        [Required]
        public string NUMERO { set; get; }

        [Required]
        public int BANCO_ID { set; get; }

        [Required]
        public DateTime FECHA_VENC { set; get; }

        [Required]
        public decimal IMPORTE { set; get; }
    }
}
