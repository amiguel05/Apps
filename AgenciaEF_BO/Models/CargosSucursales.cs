using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaEF_BO.Models
{
    [Table("CARGOS_SUCURSALES")]
    public class CargosSucursales
    {
        [Key]
        public int CARGO_SUC_ID { set; get; }


        [Required]
        public int CARGO_PROD_ID { set; get; }

        [Required]
        public int SUC_ID { set; get; }

    
        [Required]
        public decimal MINIMO_FACTURAR { set; get; }

        [Required]
        public bool ACTIVO { set; get; }


        public virtual CargosProducto CargosProducto {set; get;}

        public virtual Sucursales Sucursales { set; get; }

    }
}
