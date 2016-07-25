using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("PAGOS_RECIBOS")]
    public class PagosRecibos
    {
        [Key]
        public int PAGO_RECIBO_ID { set; get; }

        [Required]
        public int PAGO_ID { set; get; }

        [Required]
        public int RECIBO_ID { set; get; }

        [Required]
        public decimal IMPORTE_PAGADO { set; get; }

        public virtual Recibos Recibos { set; get; }

        public virtual Pagos Pagos { set; get; }

    }
}
