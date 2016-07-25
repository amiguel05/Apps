using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgenciaEF_BO.Models
{
    [Table("NCF_SECUENCIA")]
    public   class NumeroFiscal
    {
        [Key]
        public int NCF_ID { set; get; }

        [Required]
        public int TIPO_ID { set; get; }

        [Required]
        public int SUC_ID { set; get; }

        [Required]
        public string PREFIJO { set; get; }

        [Required]
        public int SECUENCIA { set; get; }

  
        public int TIPO_FISCAL { set; get; }

        [Required]
        public int MAX_SECUENCIA { set; get; }

        public virtual Tipos tipos { set; get; }

        public virtual Sucursales Sucursales { set; get; }

    }
}
