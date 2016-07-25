using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models.Telemercadeo
{
    [Table("ORDENES")]
    public class Ordenes
    {
        [Key]
        public int ORD_ID { set; get;  }

        [Required]
        public int ORD_NUM { set; get;  }


        public string SUP_ORDEN_NO { set; get; }

        [Required]
        public int TIPO_ID { set; get; }

        [Required]
        public int CTE_ID { set; get; }

        [Required]
        public int PROD_ID { set; get; }

        [Required]
        public decimal IMPORTE { set; get; }

        [Required]
        public decimal IMPORTE_LOCAL { set; get; }

        [Required]
        public int ESTADO_ID { set; get; }

        [Required]
        public decimal IMPUESTO { set; get; }

        [Required]
        public decimal GATOS_ENVIO { set; get; }

        [Required]
        public decimal GATOS_MANEJO { set; get; }

        [Required]
        public decimal TASA { set; get; }

        [Required]
        public string ORDEN_NOMBRE { set; get; }

        [Required]
        public string ORDEN_DOCUMENTO { set; get; }

        [Required]
        public string  SUPLIDOR { set; get; }


        public string ORDEN_TELEFONO { set; get; }


        public string ORDEN_DIRECCION { set; get; }

        public string ORDEN_DIRECCION2 { set; get; }

        public string ORDEN_CIUDAD { set; get; }


        [Required]
        public DateTime FECHA_ORD { set; get; }

        [Required]
        public string USUARIO_CREA {set; get;}

        [Required]
        public string USUARIO_MODIFICA {set; get;}

        [Required]
        public DateTime FECHA_MODIF {set; get;}

        
        public virtual Productos Productos { set; get; }

        public virtual Estados Estados { set; get; }
        
        public virtual Clientes Clientes { set; get; }


        
    }
}
