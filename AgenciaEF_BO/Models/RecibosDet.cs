using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("RECIBOS_DET")]
    public  class RecibosDet
    {
        [Key]
        public int ID { set; get; }

        [Required]
        public int RECIBO_ID { set; get; }

        [Required]
        public int CARGO_ID { set; get; }

        [Required]
        public decimal MONTO_LOCAL { set; get; }

        public int BLT_NUMERO { set; get; }

        [Required]
        public bool ITBIS { set; get; }


        public virtual Cargos Cargos { set; get; }

        public virtual Bultos Bultos { set; get; }

        [Required]
        public decimal MONTO_ITBIS { set; get; }

        [Required]
        public decimal MONTO_TOTAL { set; get; }
    }
}
