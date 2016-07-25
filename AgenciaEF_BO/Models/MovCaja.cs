using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("MOVCAJAS")]
    public class MovCaja
    {
        [Key]
        public int MOVCAJA_ID { set; get; }

        [Required]
        public DateTime FECHA { set; get; }

        [Required]
        public int TIP_MOV { set; get; }

        [Required]
        public int COUNTER_ID { set; get; }

        [Required]
        public int SUC_ID { set; get; }

        //IMPORTE
        public decimal IMPORTE { set; get; }

        //FPAGO_ID

        [Required]
        public int FPAGO_ID { set; get; }

        //CTE_ID
        [Required]
        public int CTE_ID { set; get; }

        public int MOV_CAJA_SEC { set; get; }

        public virtual Clientes Clientes { set; get; }

        public virtual Sucursales Sucursales { set; get; }

        public virtual Tipos Tipos { set; get; }

        public virtual Usuarios Usuarios {set; get; }

        public virtual ICollection<MovCajaRecibos> MovCajaRecibos { set; get; }
    }
}
