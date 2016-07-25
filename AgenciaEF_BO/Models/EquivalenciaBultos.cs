using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgenciaEF_BO.Models
{
    [Table("EQUIVALENCIA_BULTOS")]
    public class EquivalenciaBultos
    {
        [Key]
        public int ID { set; get; }

        public int BLT_NUMERO_LOCAL { set; get; }

        public int BLT_NUMERO_SDQ { set; get; }

        public DateTime FECHA_INGREO { set; get; }

        public DateTime FECHA_CAMBIO { set; get; }


    }
}
