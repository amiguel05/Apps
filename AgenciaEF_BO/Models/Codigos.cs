using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    //TIPO_ID     TIPO_NOMBRE                                                  TIPO_DESCR                                                                                           
    //TIPO_CODIGO GRUPO_TIPO_ID

    [Table("CODIGOS")]
    public class Codigos
    {
        [Key]
        public int CODIGO_ID { set; get; }

        [Required]
        public string CODIGO_NOMBRE { set; get; }
        [Required]
        public string CODIGO_DESCR { set; get; }
        [Required]
        public string CODIGO_COD { set; get; }
        [Required]
        public int GRUPO_COD_ID { set; get; }

        public virtual GruposCodigos GrupoCodigos { set; get; }
    }
}
