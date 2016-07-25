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

    [Table("ESTADOS")]
    public class Estados
    {
        [Key]
        public int ESTADO_ID { set; get; }

        [Required]
        public string ESTADO_NOMBRE { set; get; }
        [Required]
        public string ESTADO_DESCR { set; get; }
        [Required]
        public string ESTADO_CODIGO { set; get; }
        [Required]
        public int GRUPO_EST_ID { set; get; }

        public virtual GruposEstados GrupoEstados { set; get; }
    }
}
