using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("PAGOS")]
    public class Pagos
    {
        [Key]
        public int PAGO_ID { set; get; }

        [Required]
        public DateTime F_PAGO { set; get; }

        [Required]
        public int TIPO_ID { set; get; }

        [Required]
        public int COUNTER_ID { set; get; }

        [Required]
        public int ESTADO_ID { set; get; }

        [Required]
        public int SUC_ID { set; get; }

        //IMPORTE
        public decimal IMP_PAGO { set; get; }

        //FPAGO_ID

        [Required]
        public int MOVCAJA_ID { set; get; }

        //CTE_ID
        [Required]
        public int CTE_ID { set; get; }

        public decimal MONTO_EFECTIVO { set; get; }

        public virtual MovCaja MovCaja { set; get; }

        public virtual Clientes Clientes { set; get; }

        public virtual Sucursales Sucursales { set; get; }

        public virtual ICollection<DatosPagos> DatosPago { set; get; }

        public virtual Tipos Tipos { set; get; }

        public virtual Estados Estados { set; get; }

        public virtual ICollection<PagosRecibos> PagosRecibos { set; get; }

   
    }
}
