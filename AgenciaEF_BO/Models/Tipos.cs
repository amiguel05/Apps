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

    [Table("TIPOS")]
    public class Tipos
    {
        [Key]
        public int TIPO_ID { set; get; }

        [Required]
        public string TIPO_NOMBRE { set; get; }
        [Required]
        public string TIPO_DESCR { set; get; }
        [Required]
        public string TIPO_CODIGO { set; get; }
        [Required]
        public int  GRUPO_TIPO_ID { set; get; }

        public virtual GruposTipos GruposTipos { set; get; }

        public virtual ICollection<Recibos> Recibos { set; get; }

        public virtual ICollection<MovCaja> MovCaja { set; get; }

        public virtual ICollection<Productos> Productos { set; get; }
    }
}
