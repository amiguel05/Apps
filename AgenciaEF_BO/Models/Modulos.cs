using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("MODULO")]
    public class Modulos
    {
        public Modulos()
        {
            Opciones = new List<Opciones>();
        }

        [Key]
        public int MOD_ID { set; get; }

        [Required]
        public string MOD_NOMBRE { set; get; }

        [Required]
        public string MOD_DESCRIPCION { set; get; }

         [Required]
         public bool MOD_ESTADO { set; get; }

         [Required]
         public int TIPO_ID { set; get; }

         
         public virtual Tipos Tipos { set; get; }


         public virtual ICollection<Opciones> Opciones {get;set;}
    }
}
