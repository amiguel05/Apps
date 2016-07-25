using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
     [Table("ENVIOS")]
    public class Envios
    {
        [Key]
        public int ENV_ID { set; get; }

        [Required]
        public int PROD_ID { set; get; }

        [Required]
        public decimal PESO_MIN { set; get; }

        [Required]
        public decimal PESO_MAX { set; get; }


        public virtual Productos Productos { set; get; }

        
        public ICollection<TarifaEnvio> TarifaEnvio {set; get;}

    }
}
