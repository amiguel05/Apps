using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    //SUP_ID      SUP_CODIGO SUP_NOMBRE                               SUP_ESTADO ORI_ID
    [Table("SUPLIDORES")]
    public class Suplidores
    {
        [Key]
        [DisplayName("Id")]
        public int SUP_ID { set; get; }
        [Required]
        [DisplayName("Código")]
        public string SUP_CODIGO { set; get; }
        [Required]
        [DisplayName("Nombre")]
        public string SUP_NOMBRE { set; get; }
        [Required]
        [DisplayName("Estado")]
        public string SUP_ESTADO { set; get; }
        public int? ORI_ID { set; get; }

        public bool SOCIO { set; get; }
        public virtual Origen Origen {set; get;}
    }
}
