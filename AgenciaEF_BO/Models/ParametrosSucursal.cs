using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AgenciaEF_BO.Models
{
    [Table("PARAMETROS_SUCURSAL")]
    public class ParametrosSucursal
    {

        [Key]
        public int ID { set; get; }

        [Required]
        public int SUC_ID { set; get; }

        [Required]
        public string PARAMETRO { set; get; }

        [Required]
        public string VALOR1  { set; get; }

        public string VALOR2 { set; get; }

        public string VALOR3 { set; get; } 

    }
}
