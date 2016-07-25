using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgenciaEF_BO.Models
{
    [Table("TARIFAS_ESPECIALES")]
    public class TarifasEspeciales
    {
        [Key]
        public int TAR_ESP_ID { set; get; }

        public int CTE_ID { set; get; }

        [Required]
        public DateTime FECHA_DESDE { set; get; }

        [Required]
        public DateTime FECHA_HASTA { set; get; }

        [Required]
        public int PROD_ID { set; get; }

        [Required]
        public int CARGO_PROD_ID { set; get; }

        [Required]
        public bool ACTIVO { set; get; }

        [Required]
        public int USER_ID { set; get; }

        public virtual Clientes Clientes { set; get; }

        public virtual Productos Productos { set; get; }

        public virtual CargosProducto CargosProducto { set; get; }
    }
}
