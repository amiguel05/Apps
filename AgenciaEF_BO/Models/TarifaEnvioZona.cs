using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
   [Table("TARIFA_ENVIO_ZONA")]
    public  class TarifaEnvioZona
    {

        [Key]
        public int ID { set; get; }

        [Required]
        public int ENV_ID { set; get; }

        [Required]
        public int ORI_ID { set; get; }

        [Required]
        [MaxLength(1)]
        public string ZONA { set; get; }


        public virtual Envios Envios { set; get; }

        public virtual Origen Origen { set; get; }


    }
}
