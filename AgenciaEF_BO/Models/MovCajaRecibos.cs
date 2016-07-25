using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("MOVCAJA_RECIBOS")]
    public class MovCajaRecibos
    {
        [Key]
        public int MOVCAJA_REC_ID { set; get; }

        [Required]
        public int MOVCAJA_ID { set; get; }

        [Required]
        public int RECIBO_ID { set; get; }

        [Required]
        public decimal IMPORTE_PAGADO { set; get; }

        public virtual Recibos Recibos { set; get; }

        public virtual MovCaja MovCaja { set; get; }

    }
}
