using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgenciaEF_BO.Models
{
    [Table("CARGVAR")]
    public class CargosVarios
    {
        [Key]
        public int CARGVAR_ID { set; get; }

        [Required]
        public int CTE_ID { set; get; }

        [Required]
        public int CARGO_ID { set; get; }

        [MaxLength(200)]
        public string DESCR { set; get; }

        [Required]
        public decimal IMPORTE { set; get; }

        [Required]
        public int ESTADO_ID { set; get; }

        [Required]
        public DateTime F_CREA { set; get; }

      
        public DateTime F_FACT { set; get; }

        public int RECIBO_ID { set; get;  }

        public virtual Cargos Cargos { set; get; }

        public virtual Estados Estados { set; get; }

        public virtual Clientes Clientews { set; get; }


    }
}
