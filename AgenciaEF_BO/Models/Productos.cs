using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("PRODUCTOS")]
    public class Productos
    {
        [Key]
        public int PROD_ID { set; get;}

        [Required]
        [MaxLength(6)]
        public string PRO_CODIGO { set; get; }

        public int SUP_ID { set; get; }
        public int ORI_ID { set; get; }
        public int GRP_COD_ID { set; get; }

        [Required]
        [MaxLength(40)]
        public string PRO_DESCRIPCION { set; get; }

        [MaxLength(255)]
        public string PRO_COMENTARIO { set; get; }

        [Required]
        public bool PRO_ESTADO { set; get; }

        [Required]
        public int PRO_TIPO_ID { set; get; }

      
        [Required]
        public int DOC_TIPO_ID { set; get; }

        [Required]
        public bool PRO_COURIER { set; get; }
      

        [Required]
        public bool PRO_MENSAJERIA { set; get; }

        [Required]
        public int COD_UND_ID { set; get; }

        [Required]
        public decimal PRO_MINIMO { set; get; }

        public virtual Origen Origen { set; get; }

        public virtual Suplidores Suplidores { set; get; }

        public virtual Tipos Tipos { set; get; }

    }
}
