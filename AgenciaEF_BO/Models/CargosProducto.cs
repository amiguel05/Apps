using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("CARGOS_PRODUCTO")]
    public class CargosProducto
    {
        [Key]
        public int CARGO_PROD_ID { set; get; }

        [Required]
        public int PROD_ID { set; get; }

        [Required]
        public int CARGO_ID { set; get; }

        [Required]
        public int TASA_ID { set; get; }

        [Required]
        public bool FIJO { set; get; }

        public virtual Productos Producto { set; get; }

        public virtual TasaCambio TasaCambio { set; get; }

        public virtual Cargos Cargos { set; get; }

    }
}
