using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("BULTOS_VALORES")]
    public class BultosValores
    {
        [Key]
        public int BVA_ID { set; get; }

        [Required]
        public int CARGO_PROD_ID { set; get; }

        [Required]
        public int BLT_NUMERO { set; get; }

        [Required]
        public decimal BVA_MONTO { set; get; }

        [Required]
        public decimal BVA_MONTO_LOCAL { set; get;  }

        [Required]
        public decimal BVA_MONTO_APLICAR { set; get; }

        [Required]
        public decimal BVA_TASA { set; get; }

        public virtual CargosProducto CargosProducto { set; get; }

    }
}
