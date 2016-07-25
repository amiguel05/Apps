using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("LIBRAS_GRATIS")]
    public class LibrasGratis
    {
        [Key]
        public int ID { set; get; }

        public int CTE_ID { set; get; }

        public int LIBRAS_GRATIS { set; get; }

        public int LIBRAS_GRATIS_ACUMULADAS { set; get; }

        public int PROD_ID { set; get; }

        public DateTime FECHA_ULT_ASIGNACION { set; get; }

        public int  USUARIO_ID { set; get; }


        public virtual Clientes Clientes { set; get; }

        public virtual Productos Productos { set; get; }

        public virtual Usuarios Usuarios { set; get; }
    }
}
