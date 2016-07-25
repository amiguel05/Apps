using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("IMPORTACION_AGENCIA")]
   public  class ImportacionAgencia
    {
        [Key]
        public int ID { set; get; }


        public string NUM_FACT { set; get; }

        public DateTime FECHA { set; get; }

        public int BLT_NUMERO { set; get; }

        public string BLT_CODIGO_BARRA { set; get; }

        public bool IMPORTADO { set; get;  }

        public string MENSAJE { set; get; }

        public int SUC_ID { set; get; }
    }
}
