using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("GRUPO_CODIGOS")]
    public class GruposCodigos
    {
        //GRUPO_TIPO_ID CODIGO     NOMBRE                                                       DESCR

        [Key]
        public int GRUPO_COD_ID { set; get; }
        [Required]
        public string CODIGO { set; get; }

        [Required]
        public string NOMBRE { set; get; }
        public string DESCR { set; get; }


    }
}
