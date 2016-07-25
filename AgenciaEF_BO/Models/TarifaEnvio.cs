using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("TARIFA_ENVIO")]
    public class TarifaEnvio
    {
        [Key]
        public int TARIFA_ENV_ID { set; get; }

        [Required]
        public int ENV_ID { set; get; }

        [Required]
        public int PESO { set; get; }

        [Required]
        public decimal A { set; get; }

        [Required]
        public decimal B { set; get; }

        [Required]
        public decimal C { set; get; }

        [Required]
        public decimal D { set; get; }

        [Required]
        public decimal E { set; get; }

        [Required]
        public decimal F { set; get; }

        [Required]
        public decimal G { set; get; }

        [Required]
        public decimal H { set; get; }


        public virtual Envios Envios { set; get; }

    }
}
